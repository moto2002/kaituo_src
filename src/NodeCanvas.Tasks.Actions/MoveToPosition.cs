using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("Movement"), Name("Move To Target Position")]
	public class MoveToPosition : ActionTask<NavMeshAgent>
	{
		public BBParameter<Vector3> targetPosition;

		public BBParameter<float> speed = 3f;

		public float keepDistance = 0.1f;

		private Vector3? lastRequest;

		protected override string info
		{
			get
			{
				return "GoTo " + this.targetPosition.ToString();
			}
		}

		protected override void OnExecute()
		{
			base.agent.speed = this.speed.value;
			if ((base.agent.transform.position - this.targetPosition.value).magnitude < base.agent.stoppingDistance + this.keepDistance)
			{
				base.EndAction(new bool?(true));
				return;
			}
			this.Go();
		}

		protected override void OnUpdate()
		{
			this.Go();
		}

		private void Go()
		{
			if (this.lastRequest != this.targetPosition.value && !base.agent.SetDestination(this.targetPosition.value))
			{
				base.EndAction(new bool?(false));
				return;
			}
			this.lastRequest = new Vector3?(this.targetPosition.value);
			if (!base.agent.pathPending && base.agent.remainingDistance <= base.agent.stoppingDistance + this.keepDistance)
			{
				base.EndAction(new bool?(true));
			}
		}

		protected override void OnStop()
		{
			this.lastRequest = null;
			if (base.agent.gameObject.activeSelf)
			{
				base.agent.ResetPath();
			}
		}

		protected override void OnPause()
		{
			this.OnStop();
		}
	}
}
