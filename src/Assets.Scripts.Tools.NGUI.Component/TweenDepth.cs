using System;

namespace Assets.Scripts.Tools.NGUI.Component
{
	public class TweenDepth : UITweener
	{
		public float from;

		public float to;

		private UIWidget uiWidget;

		public float value
		{
			set
			{
				if (this.uiWidget == null)
				{
					this.uiWidget = base.GetComponent<UIWidget>();
				}
				this.uiWidget.depth = (int)value;
			}
		}

		protected override void OnUpdate(float factor, bool isFinished)
		{
			this.value = this.from * (1f - factor) + this.to * factor;
		}
	}
}
