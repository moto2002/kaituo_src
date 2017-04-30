using System;
using UnityEngine;

namespace Assets.Scripts.Tools.NGUI.Component
{
	public class UIButtonLabelStatus : UIButtonColor
	{
		public UILabel Label;

		public Color NormalColor = Color.white;

		public Color NormalTopColor = Color.white;

		public Color NormalBottomColor = Color.white;

		public Color NormalEffectColor = Color.white;

		public Color PressColor = Color.white;

		public Color PressTopColor = Color.white;

		public Color PressBottomColor = Color.white;

		public Color PressEffectColor = Color.white;

		protected override void OnDragOver()
		{
			if (this.isEnabled && UICamera.currentTouch.pressed == base.gameObject)
			{
				base.OnDragOver();
			}
		}

		public override void SetState(UIButtonColor.State state, bool instant)
		{
			switch (state)
			{
			case UIButtonColor.State.Normal:
				this.SetPressStatus(false);
				break;
			case UIButtonColor.State.Hover:
				this.SetPressStatus(false);
				break;
			case UIButtonColor.State.Pressed:
				this.SetPressStatus(true);
				break;
			case UIButtonColor.State.Disabled:
				break;
			default:
				throw new ArgumentOutOfRangeException("state", state, null);
			}
		}

		private void SetPressStatus(bool isPress)
		{
			if (isPress)
			{
				this.Label.color = this.PressColor;
				this.Label.effectColor = this.PressEffectColor;
				this.Label.gradientTop = this.PressTopColor;
				this.Label.gradientBottom = this.PressBottomColor;
			}
			else
			{
				this.Label.color = this.NormalColor;
				this.Label.effectColor = this.NormalEffectColor;
				this.Label.gradientTop = this.NormalTopColor;
				this.Label.gradientBottom = this.NormalBottomColor;
			}
		}
	}
}
