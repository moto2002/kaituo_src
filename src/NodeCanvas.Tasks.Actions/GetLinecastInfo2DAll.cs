using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("Physics"), Description("Get hit info for ALL objects in the linecast, in Lists")]
	public class GetLinecastInfo2DAll : ActionTask<Transform>
	{
		[RequiredField]
		public BBParameter<GameObject> target;

		public LayerMask mask = -1;

		[BlackboardOnly]
		public BBParameter<List<GameObject>> saveHitGameObjectsAs;

		[BlackboardOnly]
		public BBParameter<List<float>> saveDistancesAs;

		[BlackboardOnly]
		public BBParameter<List<Vector3>> savePointsAs;

		[BlackboardOnly]
		public BBParameter<List<Vector3>> saveNormalsAs;

		private RaycastHit2D[] hits;

		protected override void OnExecute()
		{
			this.hits = Physics2D.LinecastAll(base.agent.position, this.target.value.transform.position, this.mask);
			if (this.hits.Length > 0)
			{
				this.saveHitGameObjectsAs.value = (from h in this.hits
				select h.collider.gameObject).ToList<GameObject>();
				this.saveDistancesAs.value = (from h in this.hits
				select h.fraction).ToList<float>();
				this.savePointsAs.value = (from h in this.hits
				select h.point).Cast<Vector3>().ToList<Vector3>();
				this.saveNormalsAs.value = (from h in this.hits
				select h.normal).Cast<Vector3>().ToList<Vector3>();
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
