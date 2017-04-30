using System;
using UnityEngine;

namespace Assets.Scripts.Tools.NGUI.Component
{
	public class UITweenScrollView : UITweener
	{
		public Vector2 from;

		public Vector2 to;

		private UIPanel panel;

		private Transform panelTransform;

		public Vector2 value
		{
			set
			{
				if (this.panel == null)
				{
					this.panel = base.GetComponent<UIPanel>();
					this.panelTransform = base.transform;
				}
				this.panel.clipOffset = value;
				this.panelTransform.localPosition = value * -1f;
			}
		}

		protected override void OnUpdate(float factor, bool isFinished)
		{
			this.value = this.from * (1f - factor) + this.to * factor;
		}

		public void PlayFromCurrTo(Vector2 to)
		{
			if (this.panel == null)
			{
				this.panel = base.GetComponent<UIPanel>();
				this.panelTransform = base.transform;
			}
			this.to = to;
			this.from = this.panel.clipOffset;
			this.ResetToBeginning();
			base.PlayForward();
		}
	}
}
