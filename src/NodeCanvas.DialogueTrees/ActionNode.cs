using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

namespace NodeCanvas.DialogueTrees
{
	[Description("Execute an Action Task for the Dialogue Actor selected."), Name("Action")]
	public class ActionNode : DTNode, ITaskAssignable, ITaskAssignable<ActionTask>
	{
		[SerializeField]
		private ActionTask _action;

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

		protected override Status OnExecute(Component agent, IBlackboard bb)
		{
			if (this.action == null)
			{
				return base.Error("Action is null on Dialogue Action Node");
			}
			base.status = Status.Running;
			base.StartCoroutine(this.UpdateAction(base.finalActor.transform));
			return base.status;
		}

		[DebuggerHidden]
		private IEnumerator UpdateAction(Component actionAgent)
		{
			ActionNode.<UpdateAction>c__Iterator1B <UpdateAction>c__Iterator1B = new ActionNode.<UpdateAction>c__Iterator1B();
			<UpdateAction>c__Iterator1B.actionAgent = actionAgent;
			<UpdateAction>c__Iterator1B.<$>actionAgent = actionAgent;
			<UpdateAction>c__Iterator1B.<>f__this = this;
			return <UpdateAction>c__Iterator1B;
		}

		private void OnActionEnd(bool success)
		{
			if (success)
			{
				base.status = Status.Success;
				base.DLGTree.Continue(0);
				return;
			}
			base.status = Status.Failure;
			base.DLGTree.Stop();
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
