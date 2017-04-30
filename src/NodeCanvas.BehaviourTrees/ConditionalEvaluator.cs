using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Category("Decorators"), Description("Execute and return the child node status if the condition is true, otherwise return Failure. The condition is evaluated only once in the first Tick and when the node is not already Running unless it is set as 'Dynamic' in which case it will revaluate even while running"), Icon("Accessor", false), Name("Conditional")]
	public class ConditionalEvaluator : BTDecorator, ITaskAssignable, ITaskAssignable<ConditionTask>
	{
		public bool isDynamic;

		[SerializeField]
		private ConditionTask _condition;

		private bool accessed;

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

		private ConditionTask condition
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

		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			if (base.decoratedConnection == null)
			{
				return Status.Resting;
			}
			if (this.condition == null)
			{
				return base.decoratedConnection.Execute(agent, blackboard);
			}
			if (!this.isDynamic)
			{
				if (base.status != Status.Running && this.condition.CheckCondition(agent, blackboard))
				{
					this.accessed = true;
				}
				return (!this.accessed) ? Status.Failure : base.decoratedConnection.Execute(agent, blackboard);
			}
			if (this.condition.CheckCondition(agent, blackboard))
			{
				return base.decoratedConnection.Execute(agent, blackboard);
			}
			base.decoratedConnection.Reset(true);
			return Status.Failure;
		}

		protected override void OnReset()
		{
			this.accessed = false;
		}
	}
}
