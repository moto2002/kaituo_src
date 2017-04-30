using System;
using UnityEngine;

namespace Assets.Scripts.Tools.NGUI.Component
{
	public class UITweenTargetActive : UITweener
	{
		public float from;

		public float to;

		public GameObject Target;

		protected override void OnUpdate(float factor, bool isFinished)
		{
			float num = this.from * (1f - factor) + this.to * factor;
			if (this.Target == null)
			{
				this.Target = base.gameObject;
			}
			this.Target.SetActive((double)num >= 0.9999);
		}
	}
}
