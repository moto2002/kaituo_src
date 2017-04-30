using Assets.Tools.Script.Serialized.LocalCache;
using System;

namespace Assets.Tools.Script.Net.Downloader
{
	public abstract class LocalVersionEnableLoader : UrlLoader
	{
		private LcInt _localVer;

		private string _cacheName;

		public string cacheName
		{
			get
			{
				string arg_1C_0;
				if ((arg_1C_0 = this._cacheName) == null)
				{
					arg_1C_0 = (this._cacheName = this.GetCacheName());
				}
				return arg_1C_0;
			}
			set
			{
				this._cacheName = value;
			}
		}

		protected LocalVersionEnableLoader(string url, int version) : base(url, version)
		{
			this._localVer = new LcInt(this.cacheName + "_Ver");
		}

		protected override void OnSaveToLocal()
		{
			this._localVer.Value = base.version;
		}

		protected override void OnUnloadLocal()
		{
			this._localVer.DeleteCache();
		}

		protected override void CopyFrom(UrlLoader loader)
		{
			base.CopyFrom(loader);
			LocalVersionEnableLoader localVersionEnableLoader = loader as LocalVersionEnableLoader;
			this._localVer = localVersionEnableLoader._localVer;
			this.cacheName = localVersionEnableLoader.cacheName;
		}

		protected sealed override int OnGetLocalVersion()
		{
			if (!this.HasLocal())
			{
				return 0;
			}
			return this._localVer.Value;
		}

		protected virtual string GetCacheName()
		{
			string text = base.url.Replace("http://", string.Empty);
			text = base.url.Replace(":", string.Empty);
			text = text.Replace(".", "_");
			text = text.Replace("/", "_");
			text = text.Replace("*", string.Empty);
			return text.Replace("?", string.Empty);
		}
	}
}
