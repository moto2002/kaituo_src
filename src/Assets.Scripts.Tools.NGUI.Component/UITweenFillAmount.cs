using System;

namespace Assets.Scripts.Tools.NGUI.Component
{
	public class UITweenFillAmount : UITweener
	{
		public float from;

		public float to;

		private UISprite uiSprite;

		public float value
		{
			set
			{
				if (this.uiSprite == null)
				{
					this.uiSprite = base.GetComponent<UISprite>();
				}
				this.uiSprite.fillAmount = value;
			}
		}

		protected override void OnUpdate(float factor, bool isFinished)
		{
			this.value = this.from * (1f - factor) + this.to * factor;
		}

		public void PlayFromCurrTo(float to)
		{
			if (this.uiSprite == null)
			{
				this.uiSprite = base.GetComponent<UISprite>();
			}
			this.to = to;
			this.from = 0f;
			this.ResetToBeginning();
			base.PlayForward();
		}
	}
}
