using System;
using System.Collections.Generic;
using UnityEngine;

namespace NodeCanvas.Framework
{
	public class ActionList : ActionTask
	{
		public enum ActionsExecutionMode
		{
			ActionsRunInSequence,
			ActionsRunInParallel
		}

		public ActionList.ActionsExecutionMode executionMode;

		public List<ActionTask> actions = new List<ActionTask>();

		private int currentActionIndex;

		private readonly List<int> finishedIndeces = new List<int>();

		protected override string info
		{
			get
			{
				if (this.actions.Count == 0)
				{
					return "No Actions";
				}
				string text = string.Empty;
				for (int i = 0; i < this.actions.Count; i++)
				{
					ActionTask actionTask = this.actions[i];
					if (actionTask != null)
					{
						if (actionTask.isActive)
						{
							string str = (!actionTask.isPaused) ? ((!actionTask.isRunning) ? string.Empty : "► ") : "<b>||</b> ";
							text = text + str + actionTask.summaryInfo + ((i != this.actions.Count - 1) ? "\n" : string.Empty);
						}
					}
				}
				return text;
			}
		}

		public override Task Duplicate(ITaskSystem newOwnerSystem)
		{
			ActionList actionList = (ActionList)base.Duplicate(newOwnerSystem);
			actionList.actions.Clear();
			foreach (ActionTask current in this.actions)
			{
				actionList.AddAction((ActionTask)current.Duplicate(newOwnerSystem));
			}
			return actionList;
		}

		protected override void OnExecute()
		{
			this.finishedIndeces.Clear();
			this.currentActionIndex = 0;
			this.OnUpdate();
		}

		protected override void OnUpdate()
		{
			if (this.actions.Count == 0)
			{
				base.EndAction();
				return;
			}
			if (this.executionMode == ActionList.ActionsExecutionMode.ActionsRunInParallel)
			{
				for (int i = 0; i < this.actions.Count; i++)
				{
					if (!this.finishedIndeces.Contains(i))
					{
						if (!this.actions[i].isActive)
						{
							this.finishedIndeces.Add(i);
						}
						Status status = this.actions[i].ExecuteAction(base.agent, base.blackboard);
						if (status == Status.Failure)
						{
							base.EndAction(new bool?(false));
							return;
						}
						if (status == Status.Success)
						{
							this.finishedIndeces.Add(i);
						}
					}
				}
				if (this.finishedIndeces.Count == this.actions.Count)
				{
					base.EndAction(new bool?(true));
				}
			}
			else
			{
				for (int j = this.currentActionIndex; j < this.actions.Count; j++)
				{
					if (this.actions[j].isActive)
					{
						Status status2 = this.actions[j].ExecuteAction(base.agent, base.blackboard);
						if (status2 == Status.Failure)
						{
							base.EndAction(new bool?(false));
							return;
						}
						if (status2 == Status.Running)
						{
							this.currentActionIndex = j;
							return;
						}
					}
				}
				base.EndAction(new bool?(true));
			}
		}

		protected override void OnStop()
		{
			foreach (ActionTask current in this.actions)
			{
				current.EndAction(null);
			}
		}

		protected override void OnPause()
		{
			foreach (ActionTask current in this.actions)
			{
				current.PauseAction();
			}
		}

		public override void OnDrawGizmos()
		{
			foreach (ActionTask current in this.actions)
			{
				current.OnDrawGizmos();
			}
		}

		public override void OnDrawGizmosSelected()
		{
			foreach (ActionTask current in this.actions)
			{
				current.OnDrawGizmosSelected();
			}
		}

		private void AddAction(ActionTask action)
		{
			if (action is ActionList)
			{
				Debug.LogWarning("Adding an ActionList within an ActionList is not allowed for clarity");
				return;
			}
			this.actions.Add(action);
			action.SetOwnerSystem(base.ownerSystem);
		}
	}
}
