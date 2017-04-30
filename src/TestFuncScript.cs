using Assets.Extends.EXNGUI.Compoment;
using Assets.Tools.Script.Caller;
using System;
using UnityEngine;

public class TestFuncScript : MonoBehaviour
{
	public UISprite Sprite;

	public UIClip Clip;

	public UIAtlas Atlas;

	private void Start()
	{
		DelayCall.Call(delegate
		{
			this.Sprite.atlas = this.Atlas;
			this.Clip.clipName = "SJ_pixel_07_W_";
			this.Clip.RebuildSpriteList();
		}, 1f, false);
	}
}
