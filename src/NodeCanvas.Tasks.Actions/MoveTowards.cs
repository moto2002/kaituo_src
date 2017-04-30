using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("Movement")]
	public class MoveTowards : ActionTask<Transform>
	{
		[RequiredField]
		public BBParameter<GameObject> target;

		public BBParameter<float> speed = 2f;

		[SliderField(0.1f, 10f)]
		public BBParameter<float> stopDistance = 0.1f;

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
			if ((base.agent.position - this.target.value.transform.position).magnitude > this.stopDistance.value)
			{
				base.agent.position = Vector3.MoveTowards(base.agent.position, this.target.value.transform.position, this.speed.value * Time.deltaTime);
			}
			else if (!this.repeat)
			{
				base.EndAction();
			}
		}
	}
}
