using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("Physics"), Description("Gets a lists of game objects that are in the physics overlap sphere at the position of the agent, excluding the agent")]
	public class GetOverlapSphereObjects : ActionTask<Transform>
	{
		public LayerMask layerMask = -1;

		public BBParameter<float> radius = 2f;

		[BlackboardOnly]
		public BBParameter<List<GameObject>> saveObjectsAs;

		protected override void OnExecute()
		{
			Collider[] source = Physics.OverlapSphere(base.agent.position, this.radius.value, this.layerMask);
			this.saveObjectsAs.value = (from c in source
			select c.gameObject).ToList<GameObject>();
			this.saveObjectsAs.value.Remove(base.agent.gameObject);
			if (this.saveObjectsAs.value.Count == 0)
			{
				base.EndAction(new bool?(false));
				return;
			}
			base.EndAction(new bool?(true));
		}

		public override void OnDrawGizmosSelected()
		{
			if (base.agent != null)
			{
				Gizmos.color = new Color(1f, 1f, 1f, 0.2f);
				Gizmos.DrawSphere(base.agent.position, this.radius.value);
			}
		}
	}
}
