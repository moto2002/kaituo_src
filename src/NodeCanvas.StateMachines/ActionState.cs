using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.StateMachines
{
	[Description("Execute a number of Action Tasks OnEnter. All actions will be stoped OnExit. This state is Finished when all Actions are finished as well"), Name("Action State")]
	public class ActionState : FSMState, ITaskAssignable
	{
		[SerializeField]
		private ActionList _actionList;

		[SerializeField]
		private bool _repeatStateActions;

		public Task task
		{
			get
			{
				return this.actionList;
			}
			set
			{
				this.actionList = (ActionList)value;
			}
		}

		public ActionList actionList
		{
			get
			{
				return this._actionList;
			}
			set
			{
				this._actionList = value;
			}
		}

		public bool repeatStateActions
		{
			get
			{
				return this._repeatStateActions;
			}
			set
			{
				this._repeatStateActions = value;
			}
		}

		public override void OnValidate(Graph assignedGraph)
		{
			if (this.actionList == null)
			{
				this.actionList = (ActionList)Task.Create(typeof(ActionList), assignedGraph);
				this.actionList.executionMode = ActionList.ActionsExecutionMode.ActionsRunInParallel;
			}
		}

		protected override void OnEnter()
		{
			this.OnUpdate();
		}

		protected override void OnUpdate()
		{
			if (this.actionList.ExecuteAction(base.graphAgent, base.graphBlackboard) != Status.Running && !this.repeatStateActions)
			{
				base.Finish();
			}
		}

		protected override void OnExit()
		{
			this.actionList.EndAction(null);
		}

		protected override void OnPause()
		{
			this.actionList.PauseAction();
		}
	}
}
