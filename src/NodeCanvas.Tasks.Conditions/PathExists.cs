using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("Movement"), Description("Check if a path exists for the agent and optionaly save the resulting path positions")]
	public class PathExists : ConditionTask<NavMeshAgent>
	{
		public BBParameter<Vector3> targetPosition;

		[BlackboardOnly]
		public BBParameter<List<Vector3>> savePathAs;

		protected override bool OnCheck()
		{
			NavMeshPath navMeshPath = new NavMeshPath();
			base.agent.CalculatePath(this.targetPosition.value, navMeshPath);
			this.savePathAs.value = navMeshPath.corners.ToList<Vector3>();
			return navMeshPath.status == NavMeshPathStatus.PathComplete;
		}
	}
}
