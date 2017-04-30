using System;
using UnityEngine;

namespace Assets.Scripts.Tools.NGUI.Component
{
	public class UITweenSize : UITweener
	{
		public Vector2 from;

		public Vector2 to;

		private UIWidget uiWidget;

		public Vector2 value
		{
			set
			{
				if (this.uiWidget == null)
				{
					this.uiWidget = base.GetComponent<UIWidget>();
				}
				this.uiWidget.width = (int)value.x;
				this.uiWidget.height = (int)value.y;
			}
		}

		protected override void OnUpdate(float factor, bool isFinished)
		{
			this.value = this.from * (1f - factor) + this.to * factor;
		}

		public void PlayFromCurrTo(Vector2 to)
		{
			if (this.uiWidget == null)
			{
				this.uiWidget = base.GetComponent<UIWidget>();
			}
			this.to = to;
			this.from = new Vector2((float)this.uiWidget.width, (float)this.uiWidget.height);
			this.ResetToBeginning();
			base.PlayForward();
		}
	}
}
