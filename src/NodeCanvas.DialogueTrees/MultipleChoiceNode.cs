using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;

namespace NodeCanvas.DialogueTrees
{
	[Description("Prompt a Dialogue Multiple Choice. A choice will be available if the connection's condition is true or there is no condition on that connection. The Actor selected is used for the Condition checks as well as will Say the selection if the option is checked."), Name("✫ Multiple Choice")]
	public class MultipleChoiceNode : DTNode, ISubTasksContainer
	{
		[Serializable]
		public class Choice
		{
			public bool isUnfolded = true;

			public Statement statement;

			public ConditionTask condition;

			public Choice()
			{
			}

			public Choice(Statement statement)
			{
				this.statement = statement;
			}
		}

		public float availableTime;

		public bool saySelection;

		public List<MultipleChoiceNode.Choice> availableChoices = new List<MultipleChoiceNode.Choice>();

		private bool isWaitingChoice;

		public override int maxOutConnections
		{
			get
			{
				return -1;
			}
		}

		public Task[] GetTasks()
		{
			Task[] arg_3E_0;
			if (this.availableChoices != null)
			{
				arg_3E_0 = (from c in this.availableChoices
				select c.condition).ToArray<ConditionTask>();
			}
			else
			{
				arg_3E_0 = null;
			}
			return arg_3E_0;
		}

		public override void OnChildConnected(int index)
		{
			if (this.availableChoices.Count < base.outConnections.Count)
			{
				this.availableChoices.Insert(index, new MultipleChoiceNode.Choice(new Statement("...")));
			}
		}

		public override void OnChildDisconnected(int index)
		{
			if (this.availableChoices.Count < base.outConnections.Count)
			{
				this.availableChoices.RemoveAt(index);
			}
		}

		protected override Status OnExecute(Component agent, IBlackboard bb)
		{
			if (base.outConnections.Count == 0)
			{
				return base.Error("There are no connections to the Multiple Choice Node!");
			}
			Dictionary<IStatement, int> dictionary = new Dictionary<IStatement, int>();
			for (int i = 0; i < this.availableChoices.Count; i++)
			{
				ConditionTask condition = this.availableChoices[i].condition;
				if (condition == null || condition.CheckCondition(base.finalActor.transform, bb))
				{
					Statement key = this.availableChoices[i].statement.BlackboardReplace(bb);
					dictionary[key] = i;
				}
			}
			if (dictionary.Count == 0)
			{
				Debug.Log("Multiple Choice Node has no available options. Dialogue Ends");
				base.DLGTree.Stop();
				return Status.Failure;
			}
			if (this.availableTime > 0f)
			{
				base.StartCoroutine(this.CountDown());
			}
			MultipleChoiceRequestInfo info = new MultipleChoiceRequestInfo(dictionary, this.availableTime, new Action<int>(this.OnOptionSelected));
			DialogueTree.RequestMultipleChoices(info);
			return Status.Running;
		}

		[DebuggerHidden]
		private IEnumerator CountDown()
		{
			MultipleChoiceNode.<CountDown>c__Iterator1C <CountDown>c__Iterator1C = new MultipleChoiceNode.<CountDown>c__Iterator1C();
			<CountDown>c__Iterator1C.<>f__this = this;
			return <CountDown>c__Iterator1C;
		}

		private void OnOptionSelected(int index)
		{
			base.status = Status.Success;
			this.isWaitingChoice = false;
			Action action = delegate
			{
				this.DLGTree.Continue(index);
			};
			if (this.saySelection)
			{
				Statement statement = this.availableChoices[index].statement.BlackboardReplace(base.graphBlackboard);
				SubtitlesRequestInfo info = new SubtitlesRequestInfo(base.finalActor, statement, action);
				DialogueTree.RequestSubtitles(info);
			}
			else
			{
				action();
			}
		}
	}
}
