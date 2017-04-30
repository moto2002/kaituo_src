using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Utility"), Description("Sends an event to all GraphOwners within range of the agent and over time like a shockwave.")]
	public class ShoutEvent : ActionTask<Transform>
	{
		[RequiredField]
		public BBParameter<string> eventName;

		public BBParameter<float> shoutRange = 10f;

		public BBParameter<float> completionTime = 1f;

		private GraphOwner[] owners;

		private List<GraphOwner> receivedOwners = new List<GraphOwner>();

		private float traveledDistance;

		protected override string info
		{
			get
			{
				return string.Format("Shout Event [{0}]", this.eventName.ToString());
			}
		}

		protected override void OnExecute()
		{
			this.owners = UnityEngine.Object.FindObjectsOfType<GraphOwner>();
			this.receivedOwners.Clear();
		}

		protected override void OnUpdate()
		{
			if (base.elapsedTime >= this.completionTime.value)
			{
				base.EndAction();
				return;
			}
			this.traveledDistance = Mathf.Lerp(0f, this.shoutRange.value, base.elapsedTime / this.completionTime.value);
			GraphOwner[] array = this.owners;
			for (int i = 0; i < array.Length; i++)
			{
				GraphOwner graphOwner = array[i];
				float magnitude = (base.agent.position - graphOwner.transform.position).magnitude;
				if (magnitude <= this.traveledDistance && !this.receivedOwners.Contains(graphOwner))
				{
					graphOwner.SendEvent(this.eventName.value);
					this.receivedOwners.Add(graphOwner);
				}
			}
		}

		public override void OnDrawGizmosSelected()
		{
			if (base.agent != null)
			{
				Gizmos.color = new Color(1f, 1f, 1f, 0.2f);
				Gizmos.DrawWireSphere(base.agent.position, (!base.isRunning) ? this.shoutRange.value : this.traveledDistance);
			}
		}
	}
}
