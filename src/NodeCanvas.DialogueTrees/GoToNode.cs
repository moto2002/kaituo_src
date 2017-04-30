using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.DialogueTrees
{
	[Description("Jump to another Dialogue node"), Name("GO TO")]
	public class GoToNode : DTNode
	{
		[SerializeField]
		private DTNode _targetNode;

		public override int maxOutConnections
		{
			get
			{
				return 0;
			}
		}

		public override string name
		{
			get
			{
				return "<color=#00b9e8><GO TO></color>";
			}
		}

		protected override Status OnExecute(Component agent, IBlackboard bb)
		{
			if (this._targetNode == null)
			{
				return base.Error("Target node of GOTO node is null");
			}
			base.DLGTree.EnterNode(this._targetNode);
			return Status.Success;
		}
	}
}
