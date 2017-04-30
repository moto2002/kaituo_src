using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Category("Mutators (beta)"), Description("Switch the root node of the behaviour tree to a new one defined by tag\nBeta Feature!"), DoNotList, Name("Root Switcher")]
	public class RootSwitcher : BTNode
	{
		public string targetNodeTag;

		private Node targetNode;

		public override void OnGraphStarted()
		{
			this.targetNode = base.graph.GetNodeWithTag<Node>(this.targetNodeTag);
		}

		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			if (string.IsNullOrEmpty(this.targetNodeTag))
			{
				return Status.Failure;
			}
			if (this.targetNode == null)
			{
				return Status.Failure;
			}
			if (base.graph.primeNode != this.targetNode)
			{
				base.graph.primeNode = this.targetNode;
			}
			return Status.Success;
		}
	}
}
