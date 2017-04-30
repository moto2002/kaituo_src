using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("Movement"), Description("Makes the agent wander randomly within the navigation map")]
	public class Wander : ActionTask<NavMeshAgent>
	{
		public BBParameter<float> speed = 4f;

		public BBParameter<float> stoppingDistance = 0.1f;

		public BBParameter<float> minWanderDistance = 5f;

		public BBParameter<float> maxWanderDistance = 20f;

		public bool repeat = true;

		protected override void OnExecute()
		{
			base.agent.speed = this.speed.value;
			base.agent.stoppingDistance = this.stoppingDistance.value;
			this.DoWander();
		}

		protected override void OnUpdate()
		{
			if (!base.agent.pathPending && base.agent.remainingDistance <= base.agent.stoppingDistance)
			{
				if (this.repeat)
				{
					this.DoWander();
				}
				else
				{
					base.EndAction();
				}
			}
		}

		private void DoWander()
		{
			this.minWanderDistance.value = Mathf.Min(this.minWanderDistance.value, this.maxWanderDistance.value);
			Vector3 vector = UnityEngine.Random.insideUnitSphere * this.maxWanderDistance.value + base.agent.transform.position;
			while ((vector - base.agent.transform.position).sqrMagnitude < this.minWanderDistance.value)
			{
				vector = UnityEngine.Random.insideUnitSphere * this.maxWanderDistance.value + base.agent.transform.position;
			}
			base.agent.SetDestination(vector);
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
