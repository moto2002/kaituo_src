using Assets.Tools.Script.File;
using Assets.Tools.Script.Serialized.LocalCache.Core;
using Assets.Tools.Script.Serialized.LocalCache.xml;
using System;
using UnityEngine;

namespace Assets.Tools.Script.Serialized.LocalCache
{
	public class LcTexture2DFile : UnityLocalCache<Texture2D>
	{
		private class TextureCache
		{
			public byte[] Bytes;

			public TextureCacheConfig Config;

			public LcTexture2DFile.TextureCache Init(Texture2D texture2D)
			{
				this.Bytes = texture2D.EncodeToPNG();
				this.Config = new TextureCacheConfig();
				this.Config.Format = texture2D.format;
				this.Config.Width = texture2D.width;
				this.Config.Height = texture2D.height;
				return this;
			}

			public LcTexture2DFile.TextureCache Init(TextureCacheConfig config, byte[] bytes)
			{
				this.Bytes = bytes;
				this.Config = config;
				return this;
			}

			public Texture2D GetTexture2D()
			{
				if (this.Bytes == null || this.Config == null)
				{
					return null;
				}
				Texture2D texture2D = new Texture2D(this.Config.Width, this.Config.Height, this.Config.Format, false, false);
				texture2D.LoadImage(this.Bytes);
				return texture2D;
			}
		}

		private readonly LcXMLFile<TextureCacheConfig> _cacheDataConfig;

		public LcTexture2DFile(string fileName) : base(fileName)
		{
			this._cacheDataConfig = new LcXMLFile<TextureCacheConfig>(fileName);
		}

		protected override Texture2D GetLocalCache()
		{
			byte[] bytes = ESFile.LoadRaw(this.CacheName + ".png");
			LcTexture2DFile.TextureCache textureCache = new LcTexture2DFile.TextureCache();
			textureCache.Init(this._cacheDataConfig.Value, bytes);
			return textureCache.GetTexture2D();
		}

		protected override void SaveLocalCache(Texture2D value)
		{
			LcTexture2DFile.TextureCache textureCache = new LcTexture2DFile.TextureCache();
			textureCache.Init(value);
			this._cacheDataConfig.Value = textureCache.Config;
			ESFile.SaveRaw(textureCache.Bytes, this.CacheName + ".png");
		}

		public override bool HasCache()
		{
			return this._cacheDataConfig.HasCache();
		}

		public override void DeleteCache()
		{
			this._cacheDataConfig.DeleteCache();
			ESFile.Delete(this.CacheName + ".png");
		}
	}
}
