using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Blackboard")]
	public class EvaluateCurve : ActionTask
	{
		[RequiredField]
		public BBParameter<AnimationCurve> curve;

		public BBParameter<float> from;

		public BBParameter<float> to = 1f;

		public BBParameter<float> time = 1f;

		[BlackboardOnly]
		public BBParameter<float> saveAs;

		protected override void OnUpdate()
		{
			this.saveAs.value = this.curve.value.Evaluate(Mathf.Lerp(this.from.value, this.to.value, base.elapsedTime / this.time.value));
			if (base.elapsedTime > this.time.value)
			{
				base.EndAction();
			}
		}
	}
}
