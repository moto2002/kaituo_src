using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Task.EventReceiverAttribute(new string[]
	{
		"OnAnimatorIK"
	}), Category("Mecanim"), Name("Set IK")]
	public class MecanimSetIK : ActionTask<Animator>
	{
		public AvatarIKGoal IKGoal;

		[RequiredField]
		public BBParameter<GameObject> goal;

		public BBParameter<float> weight;

		protected override string info
		{
			get
			{
				return string.Concat(new object[]
				{
					"Set '",
					this.IKGoal,
					"' ",
					this.goal
				});
			}
		}

		public void OnAnimatorIK()
		{
			base.agent.SetIKPositionWeight(this.IKGoal, this.weight.value);
			base.agent.SetIKPosition(this.IKGoal, this.goal.value.transform.position);
			base.EndAction();
		}
	}
}
