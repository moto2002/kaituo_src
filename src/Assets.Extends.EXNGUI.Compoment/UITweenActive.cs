using System;

namespace Assets.Extends.EXNGUI.Compoment
{
	public class UITweenActive : UITweener
	{
		public bool from;

		public bool to;

		public bool replayOnActive;

		protected override void OnUpdate(float factor, bool isFinished)
		{
			if (isFinished)
			{
				base.gameObject.SetActive(this.to);
			}
			else if (base.gameObject.activeSelf != this.from)
			{
				base.gameObject.SetActive(this.from);
			}
		}

		public void OnEnable()
		{
			if (this.replayOnActive)
			{
				this.ResetToBeginning();
				base.PlayForward();
			}
		}
	}
}
