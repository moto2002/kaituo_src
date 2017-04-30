using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Description("Check a condition and return Success or Failure"), Icon("Condition", false), Name("Condition")]
	public class ConditionNode : BTNode, ITaskAssignable, ITaskAssignable<ConditionTask>
	{
		[SerializeField]
		private ConditionTask _condition;

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

		public override string name
		{
			get
			{
				return base.name.ToUpper();
			}
		}

		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			if (this.condition != null)
			{
				return (!this.condition.CheckCondition(agent, blackboard)) ? Status.Failure : Status.Success;
			}
			return Status.Failure;
		}
	}
}
