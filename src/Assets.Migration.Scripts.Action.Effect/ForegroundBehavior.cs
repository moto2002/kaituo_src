using System;
using UnityEngine;

namespace Assets.Migration.Scripts.Action.Effect
{
	public class ForegroundBehavior : MonoBehaviour
	{
		public static ForegroundBehavior Instance;

		public GameObject ForegroundBackground;

		public Camera ForegroundCamera;

		public Color Color;

		private Material colorMaterial;

		private ForegroundColorTweener colorTweener;

		public void Show()
		{
		}

		public void Close()
		{
		}

		public void TweenColor(float time, Color from, Color to, Action onTweenEnd)
		{
			if (this.colorTweener == null)
			{
				this.colorTweener = base.gameObject.AddComponent<ForegroundColorTweener>();
			}
			this.colorTweener.Play(time, from, to, onTweenEnd);
		}

		public void SetBackgroundColor(Color color)
		{
			this.Color = color;
			if (this.colorMaterial == null)
			{
				this.colorMaterial = this.ForegroundBackground.GetComponent<Renderer>().material;
			}
			this.colorMaterial.color = color;
		}

		private void Start()
		{
			ForegroundBehavior.Instance = this;
			this.ForegroundBackground.transform.localScale = new Vector3(300f, 300f, 300f);
			if (this.ForegroundCamera == null)
			{
				this.ForegroundCamera = base.GetComponent<Camera>();
			}
		}
	}
}
