using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Task.EventReceiverAttribute(new string[]
	{
		"OnAnimatorIK"
	}), Category("Mecanim"), Name("Set Mecanim Look At")]
	public class MecanimSetLookAt : ActionTask<Animator>
	{
		public BBParameter<GameObject> targetPosition;

		public BBParameter<float> targetWeight;

		protected override string info
		{
			get
			{
				return "Mec.SetLookAt " + this.targetPosition;
			}
		}

		public void OnAnimatorIK()
		{
			base.agent.SetLookAtPosition(this.targetPosition.value.transform.position);
			base.agent.SetLookAtWeight(this.targetWeight.value);
			base.EndAction();
		}
	}
}
