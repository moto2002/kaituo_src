using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.StateMachines
{
	[Description("Execute a number of Action Tasks and in parallel to any other state, as soon as the FSM is started. All Action Tasks will prematurely be stoped if the FSM stops as well.\nThis is not a state per se and thus it has no transitions as well as it can't be Entered by transitions."), Name("Concurrent")]
	public class ConcurrentState : FSMState, IUpdatable, ITaskAssignable
	{
		[SerializeField]
		private ActionList _actionList;

		[SerializeField]
		private bool _repeatStateActions;

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

		public override string name
		{
			get
			{
				return string.Format("<color=#ff64cb>{0}</color>", base.name.ToUpper());
			}
		}

		public override int maxInConnections
		{
			get
			{
				return 0;
			}
		}

		public override int maxOutConnections
		{
			get
			{
				return 0;
			}
		}

		public override bool allowAsPrime
		{
			get
			{
				return false;
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

		public new void Update()
		{
			if ((base.status == Status.Resting || base.status == Status.Running) && this.actionList.ExecuteAction(base.graphAgent, base.graphBlackboard) != Status.Running && !this.repeatStateActions)
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
