using System;
using UnityEngine;

namespace XQ.Framework.Lua
{
	public class TextureCache
	{
		public AssetBundleRef refFileHandle;

		public Texture2D refTexture;

		public string resName;

		public int textureSize;

		public long ttl = DateTime.Now.Ticks;

		public void UpdateTTL()
		{
			this.ttl = DateTime.Now.Ticks;
		}
	}
}
