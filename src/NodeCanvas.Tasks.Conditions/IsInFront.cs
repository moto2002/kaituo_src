using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("GameObject"), Description("Checks whether the target is in the view angle of the agent"), Name("Target In View Angle")]
	public class IsInFront : ConditionTask<Transform>
	{
		[RequiredField]
		public BBParameter<GameObject> checkTarget;

		[SliderField(1, 180)]
		public BBParameter<float> viewAngle = 70f;

		protected override string info
		{
			get
			{
				return this.checkTarget + " in view angle";
			}
		}

		protected override bool OnCheck()
		{
			return Vector3.Angle(this.checkTarget.value.transform.position - base.agent.position, base.agent.forward) < this.viewAngle.value;
		}
	}
}
