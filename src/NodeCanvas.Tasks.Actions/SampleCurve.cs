using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Blackboard")]
	public class SampleCurve : ActionTask
	{
		[RequiredField]
		public BBParameter<AnimationCurve> curve;

		[SliderField(0, 1)]
		public BBParameter<float> sampleAt;

		[BlackboardOnly]
		public BBParameter<float> saveAs;

		protected override void OnExecute()
		{
			this.saveAs.value = this.curve.value.Evaluate(this.sampleAt.value);
			base.EndAction();
		}
	}
}
