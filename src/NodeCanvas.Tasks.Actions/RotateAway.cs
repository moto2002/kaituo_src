using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("Movement")]
	public class RotateAway : ActionTask<Transform>
	{
		[RequiredField]
		public BBParameter<GameObject> target;

		public BBParameter<float> speed;

		[SliderField(1, 180)]
		public BBParameter<float> angleDifference = 5f;

		public bool repeat;

		protected override void OnExecute()
		{
			this.Rotate();
		}

		protected override void OnUpdate()
		{
			this.Rotate();
		}

		private void Rotate()
		{
			if (Vector3.Angle(this.target.value.transform.position - base.agent.position, -base.agent.forward) > this.angleDifference.value)
			{
				Vector3 vector = this.target.value.transform.position - base.agent.position;
				base.agent.rotation = Quaternion.LookRotation(Vector3.RotateTowards(base.agent.forward, vector, -this.speed.value * Time.deltaTime, 0f));
			}
			else if (!this.repeat)
			{
				base.EndAction();
			}
		}
	}
}
