using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("Movement"), Description("Flees away from the target")]
	public class Flee : ActionTask<NavMeshAgent>
	{
		[RequiredField]
		public BBParameter<GameObject> target;

		public BBParameter<float> speed = 4f;

		public BBParameter<float> fledDistance = 10f;

		public BBParameter<float> lookAheadDistance = 5f;

		protected override void OnExecute()
		{
			base.agent.speed = this.speed.value;
			if ((base.agent.transform.position - this.target.value.transform.position).magnitude >= this.fledDistance.value)
			{
				base.EndAction();
				return;
			}
			this.DoFlee();
		}

		protected override void OnUpdate()
		{
			if (!base.agent.pathPending && (base.agent.transform.position - this.target.value.transform.position).magnitude >= this.fledDistance.value)
			{
				base.EndAction();
				return;
			}
			this.DoFlee();
		}

		private void DoFlee()
		{
			Vector3 destination = base.agent.transform.position + (base.agent.transform.position - this.target.value.transform.position).normalized * this.lookAheadDistance.value;
			base.agent.SetDestination(destination);
		}

		protected override void OnPause()
		{
			this.OnStop();
		}

		protected override void OnStop()
		{
			if (base.agent.gameObject.activeSelf)
			{
				base.agent.ResetPath();
			}
		}
	}
}
