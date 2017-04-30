using System;
using UnityEngine;

namespace Assets.Scripts.Tools.NGUI.Component
{
	public class UITweenUV : UITweener
	{
		public Vector4 from;

		public Vector4 to;

		private UITexture uiTexture;

		public Vector4 value
		{
			set
			{
				if (this.uiTexture == null)
				{
					this.uiTexture = base.GetComponent<UITexture>();
				}
				this.uiTexture.uvRect = new Rect(value.x, value.y, value.z, value.w);
			}
		}

		protected override void OnUpdate(float factor, bool isFinished)
		{
			this.value = this.from * (1f - factor) + this.to * factor;
		}

		public void PlayFromCurrTo(Vector4 to)
		{
			if (this.uiTexture == null)
			{
				this.uiTexture = base.GetComponent<UITexture>();
			}
			this.to = to;
			this.from = new Vector2((float)this.uiTexture.width, (float)this.uiTexture.height);
			this.ResetToBeginning();
			base.PlayForward();
		}
	}
}
