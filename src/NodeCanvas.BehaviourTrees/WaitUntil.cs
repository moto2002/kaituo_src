using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Category("Decorators"), Description("Returns Running until the assigned condition becomes true"), Icon("WaitUntil", false)]
	public class WaitUntil : BTDecorator, ITaskAssignable, ITaskAssignable<ConditionTask>
	{
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
			if (this.accessed)
			{
				return base.decoratedConnection.Execute(agent, blackboard);
			}
			if (this.condition.CheckCondition(agent, blackboard))
			{
				this.accessed = true;
			}
			return (!this.accessed) ? Status.Running : base.decoratedConnection.Execute(agent, blackboard);
		}

		protected override void OnReset()
		{
			this.accessed = false;
		}
	}
}
