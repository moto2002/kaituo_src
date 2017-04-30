using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Category("Decorators"), Description("Remap the child node's status to another status. Used to either invert the child's return status or to always return a specific status."), Icon("Remap", false), Name("Remap")]
	public class Remapper : BTDecorator
	{
		public enum RemapStatus
		{
			Failure,
			Success
		}

		public Remapper.RemapStatus successRemap = Remapper.RemapStatus.Success;

		public Remapper.RemapStatus failureRemap;

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
				return (Status)this.failureRemap;
			}
			if (status != Status.Success)
			{
				return base.status;
			}
			return (Status)this.successRemap;
		}
	}
}
