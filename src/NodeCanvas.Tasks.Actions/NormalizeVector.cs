using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Blackboard")]
	public class NormalizeVector : ActionTask
	{
		public BBParameter<Vector3> targetVector;

		public BBParameter<float> multiply = 1f;

		protected override void OnExecute()
		{
			this.targetVector.value = this.targetVector.value.normalized * this.multiply.value;
			base.EndAction(new bool?(true));
		}
	}
}
