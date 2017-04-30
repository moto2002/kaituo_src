using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.DialogueTrees
{
	[Description("Execute the first child node if a Condition is true, or the second one if that Condition is false. The Actor selected is used for the Condition check"), Name("Condition")]
	public class ConditionNode : DTNode, ITaskAssignable, ITaskAssignable<ConditionTask>
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

		public override int maxOutConnections
		{
			get
			{
				return 2;
			}
		}

		protected override Status OnExecute(Component agent, IBlackboard bb)
		{
			if (base.outConnections.Count == 0)
			{
				return base.Error("There are no connections on the Dialogue Condition Node");
			}
			if (this.condition == null)
			{
				return base.Error("There is no Conidition on the Dialoge Condition Node");
			}
			bool flag = this.condition.CheckCondition(base.finalActor.transform, base.graphBlackboard);
			base.DLGTree.Continue((!flag) ? 1 : 0);
			return Status.Success;
		}
	}
}
