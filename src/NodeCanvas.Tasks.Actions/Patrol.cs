using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("Movement"), Description("Move randomly between various game object positions taken from the list provided")]
	public class Patrol : ActionTask<NavMeshAgent>
	{
		[RequiredField]
		public BBParameter<List<GameObject>> targetList;

		public BBParameter<float> speed = 3f;

		public float keepDistance = 0.1f;

		private int index;

		private Vector3? lastRequest;

		protected override string info
		{
			get
			{
				return "Random Patrol " + this.targetList;
			}
		}

		protected override void OnExecute()
		{
			int num;
			for (num = UnityEngine.Random.Range(0, this.targetList.value.Count); num == this.index; num = UnityEngine.Random.Range(0, this.targetList.value.Count))
			{
			}
			this.index = num;
			GameObject gameObject = this.targetList.value[this.index];
			if (gameObject == null)
			{
				Debug.LogWarning("List's game object is null on MoveToFromList Action");
				base.EndAction(new bool?(false));
				return;
			}
			Vector3 position = gameObject.transform.position;
			base.agent.speed = this.speed.value;
			if ((base.agent.transform.position - position).magnitude < base.agent.stoppingDistance + this.keepDistance)
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
			Vector3 position = this.targetList.value[this.index].transform.position;
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

		public override void OnDrawGizmosSelected()
		{
			if (base.agent && this.targetList.value != null)
			{
				foreach (GameObject current in this.targetList.value)
				{
					if (current)
					{
						Gizmos.DrawSphere(current.transform.position, 0.1f);
					}
				}
			}
		}
	}
}
