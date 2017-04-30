using Assets.Tools.Script.Serialized.LocalCache;
using System;
using UnityEngine;

namespace Assets.Tools.Script.Net.Downloader
{
	public class PictureLoader : LocalVersionEnableLoader
	{
		private LcTexture2DFile _localCache;

		public Texture2D texture
		{
			get;
			private set;
		}

		public PictureLoader(string url, int version) : base(url, version)
		{
			this._localCache = new LcTexture2DFile(base.cacheName);
		}

		protected override string GetCacheName()
		{
			return "img/" + base.GetCacheName();
		}

		protected override void LoadFromLocal()
		{
			try
			{
				this.texture = this._localCache.Value;
				base.LoadComplete();
			}
			catch (Exception)
			{
				this._localCache.DeleteCache();
				throw;
			}
		}

		protected override void OnSaveToLocal()
		{
			base.OnSaveToLocal();
			this._localCache.Value = this.texture;
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
				this.texture = base.www.texture;
			}
			base.OnLoadCompleteHandler();
		}

		protected override void OnUnload()
		{
			base.OnUnload();
			this.texture = null;
			this._localCache = null;
		}

		public override bool HasLocal()
		{
			return this._localCache.HasCache();
		}

		protected override void CopyFrom(UrlLoader loader)
		{
			base.CopyFrom(loader);
			this.texture = (loader as PictureLoader).texture;
			this._localCache = (loader as PictureLoader)._localCache;
		}
	}
}
