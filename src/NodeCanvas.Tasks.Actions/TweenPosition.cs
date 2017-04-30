using DG.Tweening;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("Tween"), Icon("DOTTween", true)]
	public class TweenPosition : ActionTask<Transform>
	{
		public BBParameter<Vector3> vector;

		public BBParameter<float> delay = 0f;

		public BBParameter<float> duration = 0.5f;

		public Ease easeType = Ease.Linear;

		public bool relative;

		public bool useSnapping;

		public bool waitActionFinish = true;

		protected override void OnExecute()
		{
			if (!this.relative && (base.agent.position - this.vector.value).sqrMagnitude <= 0.01f)
			{
				base.EndAction();
				return;
			}
			Tweener t = base.agent.DOMove(this.vector.value, this.duration.value, this.useSnapping);
			t.SetDelay(this.delay.value);
			t.SetEase(this.easeType);
			if (this.relative)
			{
				t.SetRelative<Tweener>();
			}
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
