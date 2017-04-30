using Assets.Tools.Script.Caller;
using Assets.Tools.Script.File;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

namespace Assets.Tools.Script.Net.Downloader
{
	public class AssetBundleLoader : LocalVersionEnableLoader
	{
		public AssetBundle assetBundle;

		public AssetBundleLoader(string url, int version) : base(url, version)
		{
		}

		protected override void LoadFromLocal()
		{
			CoroutineCall.Call(new Func<IEnumerator>(this.StartLoadLocal));
		}

		[DebuggerHidden]
		private IEnumerator StartLoadLocal()
		{
			AssetBundleLoader.<StartLoadLocal>c__Iterator2E <StartLoadLocal>c__Iterator2E = new AssetBundleLoader.<StartLoadLocal>c__Iterator2E();
			<StartLoadLocal>c__Iterator2E.<>f__this = this;
			return <StartLoadLocal>c__Iterator2E;
		}

		protected override void OnUnload()
		{
			base.OnUnload();
			this.assetBundle = null;
		}

		protected override string GetCacheName()
		{
			return LoadPath.replace("bundle/" + base.GetCacheName() + ".assetbundle");
		}

		protected override void OnSaveToLocal()
		{
			base.OnSaveToLocal();
			if (base.www != null)
			{
				ESFile.SaveRaw(base.www.bytes, base.cacheName);
			}
		}

		protected override void OnUnloadLocal()
		{
			base.OnUnloadLocal();
			ESFile.Delete(base.cacheName);
		}

		protected override void OnLoadCompleteHandler()
		{
			base.OnLoadCompleteHandler();
			this.assetBundle = base.www.assetBundle;
		}

		public override bool HasLocal()
		{
			return ESFile.Exists(base.cacheName);
		}

		protected override void CopyFrom(UrlLoader loader)
		{
			base.CopyFrom(loader);
			AssetBundleLoader assetBundleLoader = loader as AssetBundleLoader;
			if (assetBundleLoader != null)
			{
				this.assetBundle = assetBundleLoader.assetBundle;
			}
		}
	}
}
