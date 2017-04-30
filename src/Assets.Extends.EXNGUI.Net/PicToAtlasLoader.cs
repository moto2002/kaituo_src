using Assets.Tools.Script.Go;
using Assets.Tools.Script.Net.Downloader;
using System;
using UnityEngine;

namespace Assets.Extends.EXNGUI.Net
{
	public class PicToAtlasLoader : PictureLoader
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

		public PicToAtlasLoader(string url, int version) : base(url, version)
		{
		}

		protected override void OnLoadCompleteHandler()
		{
			this.ImageLoad();
			this.SetImgToSprite();
		}

		private void ImageLoad()
		{
			if (base.texture == null)
			{
				return;
			}
			if (this.uiAtlas == null)
			{
				Shader shader = Shader.Find("Unlit/Transparent Colored");
				Material spriteMaterial = new Material(shader);
				this.uiAtlas = ParasiticComponent.GetSecondaryHost("Loaded_UIAtlas_" + base.url).AddComponent<UIAtlas>();
				this.uiAtlas.spriteMaterial = spriteMaterial;
			}
			this.uiAtlas.spriteMaterial.mainTexture = base.texture;
			UISpriteData uISpriteData = new UISpriteData();
			uISpriteData.name = base.url;
			uISpriteData.SetRect(0, 0, base.texture.width, base.texture.height);
			this.uiAtlas.spriteList.Clear();
			this.uiAtlas.spriteList.Add(uISpriteData);
		}

		private void SetImgToSprite()
		{
			if (this.loadTo != null)
			{
				this.loadTo.atlas = this.uiAtlas;
				this.loadTo.spriteName = this.uiAtlas.spriteList[0].name;
				if (this.resizeNeed)
				{
					this.loadTo.width = this.uiAtlas.spriteList[0].width;
					this.loadTo.height = this.uiAtlas.spriteList[0].height;
				}
			}
		}

		protected override void CopyFrom(UrlLoader loader)
		{
			base.CopyFrom(loader);
			this.uiAtlas = (loader as PicToAtlasLoader).uiAtlas;
		}
	}
}
