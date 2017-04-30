using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("Movement"), Description("Find the closes Navigation Mesh position to the target position"), Name("Find Closest NavMesh Edge")]
	public class FindClosestEdge : ActionTask
	{
		public BBParameter<Vector3> targetPosition;

		[BlackboardOnly]
		public BBParameter<Vector3> saveFoundPosition;

		private NavMeshHit hit;

		protected override void OnExecute()
		{
			if (NavMesh.FindClosestEdge(this.targetPosition.value, out this.hit, -1))
			{
				this.saveFoundPosition.value = this.hit.position;
				base.EndAction(new bool?(true));
			}
			base.EndAction(new bool?(false));
		}
	}
}
