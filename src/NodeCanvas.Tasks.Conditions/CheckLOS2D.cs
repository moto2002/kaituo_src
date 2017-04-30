using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using System.Linq;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("GameObject"), Description("Check of agent is in line of sight with target by doing a linecast and optionaly save the distance"), Name("Target In Line Of Sight 2D")]
	public class CheckLOS2D : ConditionTask<Transform>
	{
		[RequiredField]
		public BBParameter<GameObject> LOSTarget;

		[BlackboardOnly]
		public BBParameter<float> saveDistanceAs;

		[Task.GetFromAgentAttribute]
		private Collider2D agentCollider;

		private RaycastHit2D[] hits;

		protected override string info
		{
			get
			{
				return "LOS with " + this.LOSTarget.ToString();
			}
		}

		protected override bool OnCheck()
		{
			this.hits = Physics2D.LinecastAll(base.agent.position, this.LOSTarget.value.transform.position);
			foreach (Collider2D current in from h in this.hits
			select h.collider)
			{
				if (current != this.agentCollider && current != this.LOSTarget.value.GetComponent<Collider2D>())
				{
					return false;
				}
			}
			return true;
		}

		public override void OnDrawGizmosSelected()
		{
			if (base.agent && this.LOSTarget.value)
			{
				Gizmos.DrawLine(base.agent.position, this.LOSTarget.value.transform.position);
			}
		}
	}
}
