using Assets.Tools.Script.Caller;
using Assets.Tools.Script.Event;
using System;
using System.Collections.Generic;

namespace Assets.Tools.Script.Net.Downloader.Tool
{
	public class UrlLoadQueue
	{
		protected class UrlLoadQueueData
		{
			public UrlLoader urlLoader;

			public string url;

			public int version;

			public int maxRetry;

			public int currRetry;

			public UrlLoadQueueData(UrlLoader loader, string url, int version = -1, int retry = 0)
			{
				this.urlLoader = loader;
				this.url = url;
				this.version = version;
				this.maxRetry = retry;
			}
		}

		public readonly Signal<float> onTotalScheduleSignal = new Signal<float>();

		public readonly Signal<float> onCurrLoaderScheduleSignal = new Signal<float>();

		public readonly Signal<UrlLoadQueue> onCompleteSignal = new Signal<UrlLoadQueue>();

		public readonly Signal<UrlLoadQueue> onErrorSignal = new Signal<UrlLoadQueue>();

		public bool cacheMemory = true;

		protected UrlLoadQueue.UrlLoadQueueData currLoader;

		private readonly Dictionary<string, UrlLoadQueue.UrlLoadQueueData> _loaders = new Dictionary<string, UrlLoadQueue.UrlLoadQueueData>();

		private readonly List<string> _urls = new List<string>();

		private int _currLoadIndex;

		private float _progressInOne;

		private FrameCall _progressFrameCall;

		public bool isLoading
		{
			get;
			private set;
		}

		public int retry
		{
			get;
			set;
		}

		public bool ignoreError
		{
			get;
			set;
		}

		public UrlLoader Add(string url, int version = 0)
		{
			UrlLoader loader = UrlLoaderCreator.GetLoader(url, version);
			if (loader == null)
			{
				throw new Exception("can't find a loader for this url");
			}
			this.Add(loader);
			return loader;
		}

		public UrlLoadQueue Add(UrlLoader loader)
		{
			if (this.isLoading)
			{
				throw new Exception("can't add on loading");
			}
			string url = loader.url;
			int version = loader.version;
			if (this._loaders.ContainsKey(url))
			{
				if (version > this._loaders[url].version)
				{
					this._loaders[url].version = version;
				}
			}
			else
			{
				this._loaders.Add(url, new UrlLoadQueue.UrlLoadQueueData(loader, url, version, this.retry));
				this._urls.Add(url);
			}
			return this;
		}

		public void Load()
		{
			this.isLoading = true;
			bool flag = this.LoadNext();
			if (flag)
			{
				this._progressInOne = 1f / (float)this._loaders.Count;
				if (this._progressFrameCall != null)
				{
					this._progressFrameCall.Run();
				}
				this._progressFrameCall = FrameCall.CreateCall(new Func<bool>(this.ScheduleUpdate));
			}
			else
			{
				this.onTotalScheduleSignal.Dispatch(1f);
			}
		}

		public UrlLoader GetLoader(string url)
		{
			foreach (UrlLoadQueue.UrlLoadQueueData current in this._loaders.Values)
			{
				if (current.url == url)
				{
					return current.urlLoader;
				}
			}
			return null;
		}

		private bool ScheduleUpdate()
		{
			bool result;
			try
			{
				int num = (this._currLoadIndex >= this._loaders.Count) ? (this._loaders.Count - 1) : this._currLoadIndex;
				float num2 = (this.currLoader.urlLoader.www == null) ? 0f : this.currLoader.urlLoader.www.progress;
				float arg = this._progressInOne * (float)num + this._progressInOne * num2;
				this.onCurrLoaderScheduleSignal.Dispatch(num2);
				this.onTotalScheduleSignal.Dispatch(arg);
				result = this.isLoading;
			}
			catch (Exception ex)
			{
				DebugConsole.Log(new object[]
				{
					ex
				});
				result = false;
			}
			return result;
		}

		private bool LoadNext()
		{
			if (this._currLoadIndex < this._loaders.Count)
			{
				this.currLoader = this._loaders[this._urls[this._currLoadIndex]];
				if (this.cacheMemory || !this.currLoader.urlLoader.HasNewVersion())
				{
					this.currLoader.urlLoader.onLoadComplete.AddEventListener(new Action<ILoader>(this.OnOneLoadCompleteHandler));
					this.currLoader.urlLoader.onLoadError.AddEventListener(new Action<ILoader>(this.OnOneLoadErrorHandler));
					FrameCall.DelayFrame(delegate
					{
						this.currLoader.urlLoader.Load(this.cacheMemory);
					});
				}
				else
				{
					this.OnOneLoadCompleteHandler(this.currLoader.urlLoader);
				}
				return true;
			}
			this.isLoading = false;
			this.onCompleteSignal.Dispatch(this);
			return false;
		}

		private void OnOneLoadErrorHandler(ILoader obj)
		{
			if (this.currLoader.currRetry < this.currLoader.maxRetry)
			{
				this.currLoader.currRetry++;
				this.LoadNext();
			}
			else if (this.ignoreError)
			{
				if (!this.cacheMemory)
				{
					this._loaders[this._urls[this._currLoadIndex]] = null;
				}
				if (this._progressFrameCall != null)
				{
					this._progressFrameCall.Run();
				}
				this._progressFrameCall = null;
				this._currLoadIndex++;
				this.LoadNext();
			}
			else
			{
				this.OnOneEndHandler(obj);
				this.isLoading = false;
				this.onErrorSignal.Dispatch(this);
			}
		}

		private void OnOneLoadCompleteHandler(ILoader obj)
		{
			if (!this.cacheMemory)
			{
				this._loaders[this._urls[this._currLoadIndex]] = null;
			}
			if (this._progressFrameCall != null)
			{
				this._progressFrameCall.Run();
			}
			this._progressFrameCall = null;
			this.OnOneEndHandler(obj);
			this._currLoadIndex++;
			this.LoadNext();
		}

		private void OnOneEndHandler(ILoader obj)
		{
			obj.onLoadComplete.RemoveEventListener(new Action<ILoader>(this.OnOneLoadCompleteHandler));
			obj.onLoadError.RemoveEventListener(new Action<ILoader>(this.OnOneLoadErrorHandler));
		}
	}
}
