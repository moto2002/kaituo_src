using DG.Tweening;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("Tween"), Icon("DOTTween", true)]
	public class TweenPunchPosition : ActionTask<Transform>
	{
		public BBParameter<Vector3> ammount;

		public BBParameter<float> delay = 0f;

		public BBParameter<float> duration = 0.5f;

		public Ease easeType = Ease.Linear;

		public int vibrato = 10;

		public float elasticity = 1f;

		public bool useSnapping;

		public bool waitActionFinish = true;

		protected override void OnExecute()
		{
			Tweener t = base.agent.DOPunchPosition(this.ammount.value, this.duration.value, this.vibrato, this.elasticity, this.useSnapping);
			t.SetDelay(this.delay.value);
			t.SetEase(this.easeType);
			if (!this.waitActionFinish)
			{
				base.EndAction();
			}
		}

		protected override void OnUpdate()
		{
			if (base.elapsedTime >= this.duration.value + this.delay.value)
			{
				base.EndAction();
			}
		}
	}
}
