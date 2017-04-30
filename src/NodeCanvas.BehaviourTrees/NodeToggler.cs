using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Category("Mutators (beta)"), Description("Enable, Disable or Toggle one or more nodes with provided tag. In practise their incomming connections are disabled\nBeta Feature!"), DoNotList, Name("Node Toggler")]
	public class NodeToggler : BTNode
	{
		public enum ToggleMode
		{
			Enable,
			Disable,
			Toggle
		}

		public NodeToggler.ToggleMode toggleMode = NodeToggler.ToggleMode.Toggle;

		public string targetNodeTag;

		private List<Node> targetNodes;

		public override void OnGraphStarted()
		{
			this.targetNodes = base.graph.GetNodesWithTag<Node>(this.targetNodeTag);
		}

		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			if (string.IsNullOrEmpty(this.targetNodeTag))
			{
				return Status.Failure;
			}
			if (this.targetNodes.Count == 0)
			{
				return Status.Failure;
			}
			if (this.toggleMode == NodeToggler.ToggleMode.Enable)
			{
				foreach (Node current in this.targetNodes)
				{
					current.inConnections[0].isActive = true;
				}
			}
			if (this.toggleMode == NodeToggler.ToggleMode.Disable)
			{
				foreach (Node current2 in this.targetNodes)
				{
					current2.inConnections[0].isActive = false;
				}
			}
			if (this.toggleMode == NodeToggler.ToggleMode.Toggle)
			{
				foreach (Node current3 in this.targetNodes)
				{
					current3.inConnections[0].isActive = !current3.inConnections[0].isActive;
				}
			}
			return Status.Success;
		}
	}
}
