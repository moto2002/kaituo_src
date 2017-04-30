using System;
using UnityEngine;

namespace Assets.Scripts.Tools.NGUI.Component
{
	public class UITweenIntNumberLabel : UITweener
	{
		public bool Bold;

		public int from;

		public int to;

		private UILabel mlabel;

		private UILabel label
		{
			get
			{
				if (this.mlabel == null)
				{
					this.mlabel = base.GetComponent<UILabel>();
					this.Bold = this.mlabel.text.Contains("[b]");
				}
				return this.mlabel;
			}
		}

		public float value
		{
			set
			{
				if (this.Bold)
				{
					this.label.text = string.Format("[b]{0}[/b]", Mathf.RoundToInt(value));
				}
				else
				{
					this.label.text = Mathf.RoundToInt(value).ToString();
				}
			}
		}

		protected override void OnUpdate(float factor, bool isFinished)
		{
			this.value = (float)this.from * (1f - factor) + (float)this.to * factor;
		}

		public void PlayFromCurrTo(int to)
		{
			this.to = to;
			try
			{
				if (this.Bold)
				{
					string value = this.label.text.Replace("[b]", string.Empty).Replace("[/b]", string.Empty);
					this.from = Convert.ToInt32(value);
				}
				else
				{
					this.from = Convert.ToInt32(this.label.text);
				}
			}
			catch (Exception)
			{
				this.from = 0;
			}
			this.ResetToBeginning();
			base.PlayForward();
		}
	}
}
