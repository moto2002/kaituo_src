using System;
using UnityEngine;

namespace Assets.Scripts.Tools.NGUI.Component
{
	public class UIScaleButton : MonoBehaviour
	{
		private TweenScale tweenScale;

		public float Time = 0.15f;

		public float To = 0.9f;

		private void OnPress(bool isDown)
		{
			if (this.tweenScale == null)
			{
				this.tweenScale = base.gameObject.AddComponent<TweenScale>();
				this.tweenScale.tweenGroup = 624548;
			}
			this.tweenScale.from = base.transform.localScale;
			if (isDown)
			{
				this.tweenScale.to = new Vector3(this.To, this.To, this.To);
				this.tweenScale.duration = this.Time * Mathf.Abs((this.tweenScale.from.x - this.To) / (1f - this.To));
			}
			else
			{
				this.tweenScale.to = Vector3.one;
				this.tweenScale.duration = this.Time * Mathf.Abs((this.tweenScale.from.x - 1f) / (1f - this.To));
			}
			this.tweenScale.ResetToBeginning();
			this.tweenScale.PlayForward();
		}
	}
}
