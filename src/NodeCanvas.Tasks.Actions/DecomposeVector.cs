using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Blackboard"), Description("Create up to 3 floats from a Vector and save them to blackboard")]
	public class DecomposeVector : ActionTask
	{
		public BBParameter<Vector3> targetVector;

		[BlackboardOnly]
		public BBParameter<float> x;

		[BlackboardOnly]
		public BBParameter<float> y;

		[BlackboardOnly]
		public BBParameter<float> z;

		protected override string info
		{
			get
			{
				return "Decompose Vector " + this.targetVector;
			}
		}

		protected override void OnExecute()
		{
			this.x.value = this.targetVector.value.x;
			this.y.value = this.targetVector.value.y;
			this.z.value = this.targetVector.value.z;
			base.EndAction();
		}
	}
}
