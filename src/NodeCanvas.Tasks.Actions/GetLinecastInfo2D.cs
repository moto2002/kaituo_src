using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("Physics")]
	public class GetLinecastInfo2D : ActionTask<Transform>
	{
		[RequiredField]
		public BBParameter<GameObject> target;

		public LayerMask mask = -1;

		[BlackboardOnly]
		public BBParameter<GameObject> saveHitGameObjectAs;

		[BlackboardOnly]
		public BBParameter<float> saveDistanceAs;

		[BlackboardOnly]
		public BBParameter<Vector3> savePointAs;

		[BlackboardOnly]
		public BBParameter<Vector3> saveNormalAs;

		private RaycastHit2D hit;

		protected override void OnExecute()
		{
			this.hit = Physics2D.Linecast(base.agent.position, this.target.value.transform.position, this.mask);
			if (this.hit.collider != null)
			{
				this.saveHitGameObjectAs.value = this.hit.collider.gameObject;
				this.saveDistanceAs.value = this.hit.fraction;
				this.savePointAs.value = this.hit.point;
				this.saveNormalAs.value = this.hit.normal;
				base.EndAction(new bool?(true));
				return;
			}
			base.EndAction(new bool?(false));
		}

		public override void OnDrawGizmosSelected()
		{
			if (base.agent && this.target.value)
			{
				Gizmos.DrawLine(base.agent.position, this.target.value.transform.position);
			}
		}
	}
}
