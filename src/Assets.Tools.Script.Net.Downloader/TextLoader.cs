using Assets.Tools.Script.Serialized.LocalCache;
using System;

namespace Assets.Tools.Script.Net.Downloader
{
	public class TextLoader : LocalVersionEnableLoader
	{
		private LcString _localCache;

		public string text
		{
			get;
			private set;
		}

		public TextLoader(string url, int version) : base(url, version)
		{
			this._localCache = new LcString(base.cacheName);
		}

		protected override string GetCacheName()
		{
			return base.url;
		}

		protected override void LoadFromLocal()
		{
			this.text = this._localCache.Value;
			base.LoadComplete();
		}

		protected override void OnSaveToLocal()
		{
			base.OnSaveToLocal();
			this._localCache.Value = this.text;
		}

		protected override void OnUnloadLocal()
		{
			base.OnUnloadLocal();
			this._localCache.DeleteCache();
		}

		protected override void OnLoadCompleteHandler()
		{
			if (base.www != null)
			{
				this.text = base.www.text;
			}
		}

		protected override void OnUnload()
		{
			base.OnUnload();
			this.text = null;
			this._localCache = null;
		}

		public override bool HasLocal()
		{
			return this._localCache.HasCache();
		}

		protected override void CopyFrom(UrlLoader loader)
		{
			base.CopyFrom(loader);
			this.text = (loader as TextLoader).text;
		}
	}
}
