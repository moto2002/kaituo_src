using Assets.Tools.Script.Net.Downloader;
using System;
using UnityEngine;

namespace Assets.Extends.EXNGUI.Net
{
	public class UIAtlasLoader : AssetBundleLoader
	{
		public UIAtlas uiAtlas
		{
			get;
			private set;
		}

		public UISprite loadTo
		{
			get;
			set;
		}

		public bool resizeNeed
		{
			get;
			set;
		}

		public UIAtlasLoader(string url, int version) : base(url, version)
		{
		}

		protected override void OnLoadCompleteHandler()
		{
			if (this.loadTo != null)
			{
				this.uiAtlas = (base.www.assetBundle.mainAsset as GameObject).GetComponent<UIAtlas>();
				this.loadTo.atlas = this.uiAtlas;
				this.loadTo.spriteName = this.uiAtlas.spriteList[0].name;
				if (this.resizeNeed)
				{
					this.loadTo.width = this.uiAtlas.spriteList[0].width;
					this.loadTo.height = this.uiAtlas.spriteList[0].height;
				}
			}
			base.OnLoadCompleteHandler();
		}

		protected override void CopyFrom(UrlLoader loader)
		{
			base.CopyFrom(loader);
			UIAtlasLoader uIAtlasLoader = loader as UIAtlasLoader;
			this.uiAtlas = uIAtlasLoader.uiAtlas;
		}
	}
}
