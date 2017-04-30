using System;
using UnityEngine;

namespace Assets.Scripts.Tools.NGUI.Component
{
	public class UITweenCurrColor : UITweener
	{
		private Color from = Color.white;

		public Color to = Color.white;

		private UIWidget mWidget;

		public Color value
		{
			get
			{
				return this.mWidget.color;
			}
			set
			{
				this.mWidget.color = value;
			}
		}

		public override void Play(bool forward)
		{
			if (this.mWidget == null)
			{
				this.mWidget = base.GetComponent<UIWidget>();
			}
			base.Play(forward);
		}

		public override void ResetToBeginning()
		{
			if (this.mWidget == null)
			{
				this.mWidget = base.GetComponent<UIWidget>();
			}
			this.from = this.mWidget.color;
			base.ResetToBeginning();
		}

		protected override void OnUpdate(float factor, bool isFinished)
		{
			this.value = Color.Lerp(this.from, this.to, factor);
		}
	}
}
