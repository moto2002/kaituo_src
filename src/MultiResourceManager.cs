using System;
using System.Collections.Generic;
using UnityEngine;
using XQ.Framework.Language;
using XQ.Framework.Utility;

public abstract class MultiResourceManager : MonoBehaviour
{
	internal static readonly WeakDictionary<string, UIAtlas> langAtlas = new WeakDictionary<string, UIAtlas>();

	internal static readonly WeakDictionary<string, UIAtlas> updateAtlas = new WeakDictionary<string, UIAtlas>();

	internal static readonly WeakDictionary<string, Texture> langTexture = new WeakDictionary<string, Texture>();

	internal static readonly WeakDictionary<string, Texture> updateTexture = new WeakDictionary<string, Texture>();

	private static readonly Type spriteType = typeof(UISprite);

	private static readonly Type textureType = typeof(UITexture);

	internal string refName = string.Empty;

	private UISprite sp;

	private UITexture texture;

	protected virtual void Awake()
	{
		Type type = base.GetType();
		this.sp = ((type != MultiResourceManager.spriteType) ? null : (this as UISprite));
		this.texture = ((type != MultiResourceManager.textureType) ? null : (this as UITexture));
		if (this.sp)
		{
			if (this.sp.mAtlas)
			{
				this.refName = this.sp.mAtlas.name;
				if (!MultiResourceManager.langAtlas.ContainsKey(this.refName))
				{
					UIAtlas uIAtlas = LanguageManager.MultiResource<UIAtlas>(this.refName);
					if (uIAtlas)
					{
						MultiResourceManager.langAtlas.Add(this.refName, uIAtlas);
					}
				}
				this.ReplaceResCheck();
			}
		}
		else if (this.texture && this.texture.mTexture)
		{
			this.refName = this.texture.mTexture.name;
			if (!MultiResourceManager.langTexture.ContainsKey(this.refName))
			{
				Texture texture = LanguageManager.MultiResource<Texture>(this.refName);
				if (texture)
				{
					MultiResourceManager.langTexture.Add(this.refName, texture);
				}
			}
			this.ReplaceResCheck();
		}
	}

	internal void ReplaceResCheck()
	{
		if (this.sp)
		{
			this.replaceSprite();
		}
		else if (this.texture)
		{
			this.replaceTexture();
		}
	}

	private void replaceSprite()
	{
		UIAtlas uIAtlas = null;
		if (!MultiResourceManager.langAtlas.TryGetValue(this.refName, out uIAtlas))
		{
			if (!MultiResourceManager.updateAtlas.TryGetValue(this.refName, out uIAtlas))
			{
				uIAtlas = LanguageManager.UpdateMutilResource<UIAtlas>(this.refName);
				if (uIAtlas)
				{
					MultiResourceManager.updateAtlas.Add(this.refName, uIAtlas);
				}
			}
			if (uIAtlas && this.sp.mAtlas != uIAtlas)
			{
				this.sp.mAtlas = uIAtlas;
			}
			return;
		}
		if (this.sp.mAtlas == uIAtlas)
		{
			return;
		}
		List<UISpriteData> spriteList = uIAtlas.spriteList;
		for (int i = 0; i < spriteList.Count; i++)
		{
			UISpriteData uISpriteData = spriteList[i];
			if (uISpriteData.name == this.sp.spriteName)
			{
				this.sp.mAtlas = uIAtlas;
				this.sp.MakePixelPerfect();
				break;
			}
		}
	}

	private void replaceTexture()
	{
		Texture texture = null;
		if (!MultiResourceManager.langTexture.TryGetValue(this.refName, out texture))
		{
			if (!MultiResourceManager.updateTexture.TryGetValue(this.refName, out texture))
			{
				texture = LanguageManager.UpdateMutilResource<Texture>(this.refName);
				if (texture)
				{
					MultiResourceManager.updateTexture.Add(this.refName, texture);
				}
			}
			if (texture && this.texture.mTexture != texture)
			{
				this.texture.mTexture = texture;
			}
			return;
		}
		this.texture.mTexture = texture;
		this.texture.MakePixelPerfect();
	}
}
