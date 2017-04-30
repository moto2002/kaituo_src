using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("GameObject"), Description("Check of agent is in line of sight with target by doing a linecast and optionaly save the distance"), Name("Target In Line Of Sight")]
	public class CheckLOS : ConditionTask<Transform>
	{
		[RequiredField]
		public BBParameter<GameObject> LOSTarget;

		public Vector3 offset;

		[BlackboardOnly]
		public BBParameter<float> saveDistanceAs;

		private RaycastHit hit = default(RaycastHit);

		protected override string info
		{
			get
			{
				return "LOS with " + this.LOSTarget.ToString();
			}
		}

		protected override bool OnCheck()
		{
			Transform transform = this.LOSTarget.value.transform;
			if (Physics.Linecast(base.agent.position + this.offset, transform.position + this.offset, out this.hit) && this.hit.collider != transform.GetComponent<Collider>())
			{
				this.saveDistanceAs.value = this.hit.distance;
				return false;
			}
			return true;
		}

		public override void OnDrawGizmosSelected()
		{
			if (base.agent && this.LOSTarget.value)
			{
				Gizmos.DrawLine(base.agent.position + this.offset, this.LOSTarget.value.transform.position + this.offset);
			}
		}
	}
}
