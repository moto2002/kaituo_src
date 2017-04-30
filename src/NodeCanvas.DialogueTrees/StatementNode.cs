using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.DialogueTrees
{
	[Description("Make the selected Dialogue Actor to talk. You can make the text more dynamic by using variable names in square brackets\ne.g. [myVarName]"), Name("✫ Say")]
	public class StatementNode : DTNode
	{
		public Statement statement = new Statement("This is a dialogue text");

		protected override Status OnExecute(Component agent, IBlackboard bb)
		{
			Statement statement = this.statement.BlackboardReplace(bb);
			DialogueTree.RequestSubtitles(new SubtitlesRequestInfo(base.finalActor, statement, new Action(this.OnStatementFinish)));
			return Status.Running;
		}

		private void OnStatementFinish()
		{
			base.status = Status.Success;
			base.DLGTree.Continue(0);
		}
	}
}
