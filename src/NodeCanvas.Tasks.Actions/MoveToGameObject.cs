using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("Movement"), Name("Move To Target")]
	public class MoveToGameObject : ActionTask<NavMeshAgent>
	{
		[RequiredField]
		public BBParameter<GameObject> target;

		public BBParameter<float> speed = 3f;

		public float keepDistance = 0.1f;

		private Vector3? lastRequest;

		protected override string info
		{
			get
			{
				return "GoTo " + this.target.ToString();
			}
		}

		protected override void OnExecute()
		{
			base.agent.speed = this.speed.value;
			if ((base.agent.transform.position - this.target.value.transform.position).magnitude < base.agent.stoppingDistance + this.keepDistance)
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
			Vector3 position = this.target.value.transform.position;
			if (this.lastRequest != position && !base.agent.SetDestination(position))
			{
				base.EndAction(new bool?(false));
				return;
			}
			this.lastRequest = new Vector3?(position);
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
