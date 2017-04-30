using System;
using System.Collections.Generic;
using UnityEngine;
using XQ.Framework.Utility.Debug;
using XQ.Game.Framework.Concurrent;

namespace XQ.Framework.Lua
{
	public class AssetBundleRef
	{
		public AssetBundle OpenAssetBundleHandle;

		private Dictionary<string, AssetBundleRef> depRef;

		private readonly AtomicInteger refCnt = new AtomicInteger();

		public int RefCnt
		{
			get
			{
				return this.refCnt.Value;
			}
		}

		public void Increment()
		{
			this.refCnt.Increment();
		}

		public void Decrement(string depName = null)
		{
			if (depName != null)
			{
				AssetBundleRef assetBundleRef = null;
				if (this.depRef.TryGetValue(depName, out assetBundleRef))
				{
					assetBundleRef.Decrement(null);
				}
				else
				{
					UDebug.Error("资源引用不配套？name：{0}", new object[]
					{
						depName
					});
				}
			}
			if (this.RefCnt == 0 || this.refCnt.Decrement() == 0)
			{
				this.CloseHandle(true);
			}
		}

		public void CloseHandle(bool destroy = true)
		{
			if (this.OpenAssetBundleHandle != null)
			{
				this.OpenAssetBundleHandle.Unload(destroy);
				if (destroy)
				{
					this.OpenAssetBundleHandle = null;
				}
			}
		}

		public void TryLoadAssetBundle(string path)
		{
			if (this.RefCnt == 0)
			{
				this.OpenAssetBundleHandle = AssetBundle.LoadFromFile(path);
			}
		}

		public UnityEngine.Object LoadAsset(string abname)
		{
			return this.OpenAssetBundleHandle.LoadAsset(abname);
		}

		public AssetBundleRef TryGetDepRefHandle(string depName)
		{
			if (this.depRef == null)
			{
				AssetBundleRef assetBundleRef = new AssetBundleRef();
				this.depRef = new Dictionary<string, AssetBundleRef>
				{
					{
						depName,
						assetBundleRef
					}
				};
				return assetBundleRef;
			}
			AssetBundleRef assetBundleRef2 = null;
			if (!this.depRef.TryGetValue(depName, out assetBundleRef2))
			{
				assetBundleRef2 = new AssetBundleRef();
				this.depRef.Add(depName, assetBundleRef2);
			}
			return assetBundleRef2;
		}
	}
}
