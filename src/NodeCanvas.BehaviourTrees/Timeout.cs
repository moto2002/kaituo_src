using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Category("Decorators"), Description("Interupts decorated child node and returns Failure if the child node is still Running after the timeout period"), Icon("Timeout", false)]
	public class Timeout : BTDecorator
	{
		public BBParameter<float> timeout = 1f;

		private float timer;

		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			if (base.decoratedConnection == null)
			{
				return Status.Resting;
			}
			base.status = base.decoratedConnection.Execute(agent, blackboard);
			if (base.status == Status.Running)
			{
				this.timer += Time.deltaTime;
			}
			if (this.timer < this.timeout.value)
			{
				return base.status;
			}
			this.timer = 0f;
			base.decoratedConnection.Reset(true);
			return Status.Failure;
		}

		protected override void OnReset()
		{
			this.timer = 0f;
		}
	}
}
