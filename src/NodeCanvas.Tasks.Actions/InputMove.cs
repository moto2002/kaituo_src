using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("Movement"), Description("Move & turn the agent based on input values provided ranging from -1 to 1. Per frame and in delta time")]
	public class InputMove : ActionTask<Transform>
	{
		[BlackboardOnly]
		public BBParameter<float> strafe;

		[BlackboardOnly]
		public BBParameter<float> turn;

		[BlackboardOnly]
		public BBParameter<float> forward;

		public BBParameter<float> moveSpeed = 1f;

		public BBParameter<float> rotationSpeed = 1f;

		public bool repeat;

		protected override void OnExecute()
		{
			this.Move();
		}

		protected override void OnUpdate()
		{
			this.Move();
		}

		private void Move()
		{
			Quaternion b = base.agent.rotation * Quaternion.Euler(Vector3.up * this.turn.value * 10f);
			base.agent.rotation = Quaternion.Slerp(base.agent.rotation, b, this.rotationSpeed.value * Time.deltaTime);
			Vector3 b2 = base.agent.forward * this.forward.value * this.moveSpeed.value * Time.deltaTime;
			Vector3 a = base.agent.right * this.strafe.value * this.moveSpeed.value * Time.deltaTime;
			base.agent.position += a + b2;
			if (!this.repeat)
			{
				base.EndAction();
			}
		}
	}
}
