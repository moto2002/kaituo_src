using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class CameraFader : MonoBehaviour
{
	private static CameraFader _current;

	private float alpha;

	private Texture2D _blackTexture;

	private Texture2D blackTexture
	{
		get
		{
			if (this._blackTexture == null)
			{
				this._blackTexture = new Texture2D(1, 1);
				this._blackTexture.SetPixel(1, 1, Color.black);
				this._blackTexture.Apply();
			}
			return this._blackTexture;
		}
	}

	public static CameraFader current
	{
		get
		{
			if (CameraFader._current == null)
			{
				CameraFader._current = UnityEngine.Object.FindObjectOfType<CameraFader>();
			}
			if (CameraFader._current == null)
			{
				CameraFader._current = new GameObject("_CameraFader").AddComponent<CameraFader>();
			}
			return CameraFader._current;
		}
	}

	public void FadeIn(float time)
	{
		base.StartCoroutine(this.CoroutineFadeIn(time));
	}

	public void FadeOut(float time)
	{
		base.StartCoroutine(this.CoroutineFadeOut(time));
	}

	[DebuggerHidden]
	private IEnumerator CoroutineFadeIn(float time)
	{
		CameraFader.<CoroutineFadeIn>c__Iterator1E <CoroutineFadeIn>c__Iterator1E = new CameraFader.<CoroutineFadeIn>c__Iterator1E();
		<CoroutineFadeIn>c__Iterator1E.time = time;
		<CoroutineFadeIn>c__Iterator1E.<$>time = time;
		<CoroutineFadeIn>c__Iterator1E.<>f__this = this;
		return <CoroutineFadeIn>c__Iterator1E;
	}

	[DebuggerHidden]
	private IEnumerator CoroutineFadeOut(float time)
	{
		CameraFader.<CoroutineFadeOut>c__Iterator1F <CoroutineFadeOut>c__Iterator1F = new CameraFader.<CoroutineFadeOut>c__Iterator1F();
		<CoroutineFadeOut>c__Iterator1F.time = time;
		<CoroutineFadeOut>c__Iterator1F.<$>time = time;
		<CoroutineFadeOut>c__Iterator1F.<>f__this = this;
		return <CoroutineFadeOut>c__Iterator1F;
	}

	private void OnGUI()
	{
		if (this.alpha <= 0f)
		{
			return;
		}
		GUI.color = new Color(1f, 1f, 1f, this.alpha);
		GUI.DrawTexture(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height), this.blackTexture);
		GUI.color = Color.white;
	}
}
