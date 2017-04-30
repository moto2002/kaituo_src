using NodeCanvas;
using NodeCanvas.BehaviourTrees;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace Assets.Scripts.Action.Program
{
	[Category("✫ GOG/Program"), Name("if else")]
	public class IfElseNode : BTNode, ITaskAssignable, ITaskAssignable<ConditionTask>
	{
		[SerializeField]
		private ConditionTask _condition;

		public override string name
		{
			get
			{
				return string.Format("<color=#b3ff7f>{0}</color>", base.name);
			}
		}

		public Task task
		{
			get
			{
				return this.condition;
			}
			set
			{
				this.condition = (ConditionTask)value;
			}
		}

		private ConditionTask condition
		{
			get
			{
				return this._condition;
			}
			set
			{
				this._condition = value;
			}
		}

		public override int maxOutConnections
		{
			get
			{
				return 2;
			}
		}

		public Connection TrueConnection
		{
			get
			{
				return base.outConnections[0];
			}
		}

		public Node TrueNode
		{
			get
			{
				return base.outConnections[0].targetNode;
			}
		}

		public Connection FalseConnection
		{
			get
			{
				return base.outConnections[1];
			}
		}

		public Node FalseNode
		{
			get
			{
				return base.outConnections[1].targetNode;
			}
		}

		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			if (base.outConnections.Count == 0)
			{
				return Status.Resting;
			}
			if (this.condition == null || this.condition.CheckCondition(agent, blackboard))
			{
				return this.TrueConnection.Execute(agent, blackboard);
			}
			return this.FalseConnection.Execute(agent, blackboard);
		}
	}
}
