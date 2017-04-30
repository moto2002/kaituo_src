using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Category("Decorators"), Description("Inverts Success to Failure and Failure to Success"), Icon("Remap", false), Name("Invert")]
	public class Inverter : BTDecorator
	{
		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			if (base.decoratedConnection == null)
			{
				return Status.Resting;
			}
			base.status = base.decoratedConnection.Execute(agent, blackboard);
			Status status = base.status;
			if (status == Status.Failure)
			{
				return Status.Success;
			}
			if (status != Status.Success)
			{
				return base.status;
			}
			return Status.Failure;
		}
	}
}
