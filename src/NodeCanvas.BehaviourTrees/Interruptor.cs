using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Category("Decorators"), Description("Interrupt the child node and return Failure if the condition is or becomes true while running. Otherwise execute and return the child Status"), Icon("Interruptor", false), Name("Interrupt")]
	public class Interruptor : BTDecorator, ITaskAssignable, ITaskAssignable<ConditionTask>
	{
		[SerializeField]
		private ConditionTask _condition;

		public ConditionTask condition
		{
			get
			{
				return this._condition;
			}
			set
			{
				this._condition = value;
			}
		}

		public Task task
		{
			get
			{
				return this.condition;
			}
			set
			{
				this.condition = (ConditionTask)value;
			}
		}

		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			if (base.decoratedConnection == null)
			{
				return Status.Resting;
			}
			if (this.condition == null || !this.condition.CheckCondition(agent, blackboard))
			{
				return base.decoratedConnection.Execute(agent, blackboard);
			}
			if (base.decoratedConnection.connectionStatus == Status.Running)
			{
				base.decoratedConnection.Reset(true);
			}
			return Status.Failure;
		}
	}
}
