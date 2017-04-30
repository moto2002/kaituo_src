using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Description("Executes an action and returns Success or Failure. Returns Running until the action is finished"), Icon("Action", false), Name("Action")]
	public class ActionNode : BTNode, ITaskAssignable, ITaskAssignable<ActionTask>
	{
		[SerializeField]
		private ActionTask _action;

		public Task task
		{
			get
			{
				return this.action;
			}
			set
			{
				this.action = (ActionTask)value;
			}
		}

		public ActionTask action
		{
			get
			{
				return this._action;
			}
			set
			{
				this._action = value;
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
			if (this.action == null)
			{
				return Status.Failure;
			}
			if (base.status == Status.Resting || base.status == Status.Running)
			{
				return this.action.ExecuteAction(agent, blackboard);
			}
			return base.status;
		}

		protected override void OnReset()
		{
			if (this.action != null)
			{
				this.action.EndAction(null);
			}
		}

		public override void OnGraphPaused()
		{
			if (this.action != null)
			{
				this.action.PauseAction();
			}
		}
	}
}
