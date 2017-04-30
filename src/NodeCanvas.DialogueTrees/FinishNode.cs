using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.DialogueTrees
{
	[Description("End the dialogue in Success or Failure.\nNote: A Dialogue will anyway End in Succcess if it has reached a node without child connections."), Name("Finish")]
	public class FinishNode : DTNode
	{
		public DialogueTree.EndState endState = DialogueTree.EndState.Success;

		public override string name
		{
			get
			{
				return "FINISH";
			}
		}

		public override int maxOutConnections
		{
			get
			{
				return 0;
			}
		}

		protected override Status OnExecute(Component agent, IBlackboard bb)
		{
			base.status = (Status)this.endState;
			base.DLGTree.Stop();
			return base.status;
		}
	}
}
