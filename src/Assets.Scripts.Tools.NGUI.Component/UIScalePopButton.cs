using System;
using UnityEngine;

namespace Assets.Scripts.Tools.NGUI.Component
{
	public class UIScalePopButton : MonoBehaviour
	{
		public Vector3 Scale = new Vector3(1.05f, 1.05f, 1.05f);

		public Color Color = new Color(1f, 1f, 1f, 1f);

		public UIWidget Widget;

		public float Time = 0.1f;

		private Color fromColor;

		public void OnPress(bool press)
		{
			if (press)
			{
				TweenScale tweenScale = TweenScale.Begin(base.gameObject, this.Time, this.Scale);
				tweenScale.onFinished.Clear();
				tweenScale.AddOnFinished(new EventDelegate.Callback(this.OnFinishPop));
				if (this.Widget != null)
				{
					this.fromColor = this.Widget.color;
					TweenColor.Begin(base.gameObject, this.Time, this.Color);
				}
			}
		}

		private void OnFinishPop()
		{
			TweenScale tweenScale = TweenScale.Begin(base.gameObject, this.Time, Vector3.one);
			tweenScale.onFinished.Clear();
			if (this.Widget != null)
			{
				TweenColor.Begin(base.gameObject, this.Time, this.fromColor);
			}
		}
	}
}
