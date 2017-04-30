using Assets.Tools.Script.Caller;
using Assets.Tools.Script.Event;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Assets.Tools.Script.Net.Downloader
{
	public abstract class UrlLoader : ILoader
	{
		public static int defaultAttempts = 1;

		protected static Dictionary<string, List<UrlLoader>> loadingLoaders = new Dictionary<string, List<UrlLoader>>();

		protected static Dictionary<string, UrlLoader> cacheMemoryLoaders = new Dictionary<string, UrlLoader>();

		private int _currAttempts;

		public Signal<ILoader> onLoadStart
		{
			get;
			private set;
		}

		public Signal<ILoader> onLoadComplete
		{
			get;
			private set;
		}

		public Signal<ILoader> onLoadError
		{
			get;
			private set;
		}

		public Signal<ILoader> onUnloadLocalStart
		{
			get;
			private set;
		}

		public Signal<ILoader> onUnloadLocalComplete
		{
			get;
			private set;
		}

		public Signal<ILoader> onUnloadLocalError
		{
			get;
			private set;
		}

		public int attempts
		{
			get;
			private set;
		}

		public string url
		{
			get;
			private set;
		}

		public int version
		{
			get;
			private set;
		}

		public WWW www
		{
			get;
			protected set;
		}

		public bool isCatchMemory
		{
			get;
			private set;
		}

		protected UrlLoader(string url, int version)
		{
			this.attempts = UrlLoader.defaultAttempts;
			this.onLoadStart = new Signal<ILoader>();
			this.onLoadComplete = new Signal<ILoader>();
			this.onLoadError = new Signal<ILoader>();
			this.onUnloadLocalStart = new Signal<ILoader>();
			this.onUnloadLocalComplete = new Signal<ILoader>();
			this.onUnloadLocalError = new Signal<ILoader>();
			this.url = url;
			this.version = version;
		}

		public UrlLoader SetAttempts(int value)
		{
			this.attempts = value;
			return this;
		}

		public void UnloadLocal()
		{
			try
			{
				this.onUnloadLocalStart.Dispatch(this);
				if (this.HasLocal())
				{
					this.OnUnloadLocal();
				}
				this.onUnloadLocalComplete.Dispatch(this);
			}
			catch (Exception var_0_2E)
			{
				this.onUnloadLocalError.Dispatch(this);
			}
		}

		public bool HasNewVersion()
		{
			return this.version > this.GetLocalVersion();
		}

		public int GetLocalVersion()
		{
			return this.OnGetLocalVersion();
		}

		public void Load(bool catchMemory = true)
		{
			this.isCatchMemory = catchMemory;
			this._currAttempts = 0;
			Dictionary<string, List<UrlLoader>> obj = UrlLoader.loadingLoaders;
			lock (obj)
			{
				this.onLoadStart.Dispatch(this);
				if (UrlLoader.cacheMemoryLoaders.ContainsKey(this.url))
				{
					this.CopyFrom(UrlLoader.cacheMemoryLoaders[this.url]);
					this.OnLoadCompleteHandler();
					if (this.version > 0 && this.www != null && this.HasNewVersion())
					{
						this.SaveToLocal();
					}
					this.onLoadComplete.Dispatch(this);
				}
				else if (UrlLoader.loadingLoaders.ContainsKey(this.url))
				{
					UrlLoader.loadingLoaders[this.url].Add(this);
				}
				else
				{
					UrlLoader.loadingLoaders.Add(this.url, new List<UrlLoader>());
					UrlLoader.loadingLoaders[this.url].Add(this);
					this.LoadResource();
				}
			}
		}

		public void Unload()
		{
			try
			{
				this.OnUnload();
			}
			catch (Exception ex)
			{
				DebugConsole.Log(new object[]
				{
					ex
				});
			}
		}

		protected void LoadResource()
		{
			if (this.version >= 0)
			{
				if (this.HasLocal())
				{
					if (this.HasNewVersion())
					{
						this.onUnloadLocalComplete.AddEventListener(delegate(ILoader thisloader)
						{
							this.LoadFromUrl();
						});
						this.onUnloadLocalError.AddEventListener(delegate(ILoader thisloader)
						{
							this.LoadFromUrl();
						});
						this.UnloadLocal();
					}
					else
					{
						try
						{
							this.LoadFromLocal();
						}
						catch (Exception ex)
						{
							DebugConsole.Log(new object[]
							{
								ex
							});
						}
					}
				}
				else
				{
					this.LoadFromUrl();
				}
			}
			else
			{
				this.LoadFromUrl();
			}
		}

		private void LoadFromUrl()
		{
			CoroutineCall.Call(new Func<IEnumerator>(this.StartLoad));
		}

		[DebuggerHidden]
		private IEnumerator StartLoad()
		{
			UrlLoader.<StartLoad>c__Iterator2D <StartLoad>c__Iterator2D = new UrlLoader.<StartLoad>c__Iterator2D();
			<StartLoad>c__Iterator2D.<>f__this = this;
			return <StartLoad>c__Iterator2D;
		}

		protected void LoadComplete()
		{
			List<UrlLoader> list = null;
			Dictionary<string, List<UrlLoader>> obj = UrlLoader.loadingLoaders;
			lock (obj)
			{
				if (UrlLoader.loadingLoaders.ContainsKey(this.url))
				{
					list = UrlLoader.loadingLoaders[this.url];
					UrlLoader.loadingLoaders.Remove(this.url);
				}
			}
			if (list != null)
			{
				bool flag = false;
				foreach (UrlLoader current in list)
				{
					flag = (flag || current.isCatchMemory);
					current.CopyFrom(this);
					current.OnLoadCompleteHandler();
				}
				if (this.version > 0 && this.www != null)
				{
					this.SaveToLocal();
				}
				if (flag)
				{
					UrlLoader.cacheMemoryLoaders.Add(this.url, this);
				}
				foreach (UrlLoader current2 in list)
				{
					current2.onLoadComplete.Dispatch(current2);
				}
				if (!flag)
				{
					this.Unload();
					Resources.UnloadUnusedAssets();
					GC.Collect();
				}
			}
		}

		protected void LoadError(string ErrorString = "")
		{
			if (string.IsNullOrEmpty(ErrorString))
			{
				DebugConsole.Log(new object[]
				{
					"[LoadError]" + this.www.url + ":" + this.www.error,
					base.GetType().ToString()
				});
			}
			else
			{
				DebugConsole.Log("[LoadError]" + ErrorString);
			}
			List<UrlLoader> list = null;
			Dictionary<string, List<UrlLoader>> obj = UrlLoader.loadingLoaders;
			lock (obj)
			{
				if (UrlLoader.loadingLoaders.ContainsKey(this.www.url))
				{
					list = UrlLoader.loadingLoaders[this.www.url];
					UrlLoader.loadingLoaders.Remove(this.www.url);
				}
			}
			if (list != null)
			{
				foreach (UrlLoader current in list)
				{
					current.CopyFrom(this);
					current.onLoadError.Dispatch(current);
					current.OnLoadErrorHandler();
				}
			}
		}

		private void SaveToLocal()
		{
			try
			{
				this.OnSaveToLocal();
			}
			catch (Exception ex)
			{
				DebugConsole.Log(new object[]
				{
					ex
				});
				this.UnloadLocal();
			}
		}

		public abstract bool HasLocal();

		protected virtual void CopyFrom(UrlLoader loader)
		{
			this.www = loader.www;
		}

		protected virtual void OnUnload()
		{
			this.www = null;
		}

		protected virtual void OnLoadCompleteHandler()
		{
		}

		protected virtual void OnLoadErrorHandler()
		{
		}

		protected abstract void OnSaveToLocal();

		protected abstract void OnUnloadLocal();

		protected abstract void LoadFromLocal();

		protected abstract int OnGetLocalVersion();
	}
}
