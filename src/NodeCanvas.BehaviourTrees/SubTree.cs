using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Category("Nested"), Description("SubTree Node can be assigned an entire Sub BehaviorTree. The root node of that behaviour will be considered child node of this node and will return whatever it returns.\nThe SubTree can also be parametrized using Blackboard variables as normal."), Icon("BT", false), Name("SubTree")]
	public class SubTree : BTNode, IGraphAssignable
	{
		[SerializeField]
		private BBParameter<BehaviourTree> _subTree;

		private readonly Dictionary<BehaviourTree, BehaviourTree> instances = new Dictionary<BehaviourTree, BehaviourTree>();

		public BehaviourTree subTree
		{
			get
			{
				return this._subTree.value;
			}
			set
			{
				this._subTree.value = value;
				if (this._subTree.value == null)
				{
					return;
				}
				this._subTree.value.agent = base.graphAgent;
				this._subTree.value.blackboard = base.graphBlackboard;
			}
		}

		public Graph nestedGraph
		{
			get
			{
				return this.subTree;
			}
			set
			{
				this.subTree = (BehaviourTree)value;
			}
		}

		public override string name
		{
			get
			{
				return base.name.ToUpper();
			}
		}

		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			if (this.subTree == null || this.subTree.primeNode == null)
			{
				return Status.Failure;
			}
			if (base.status == Status.Resting)
			{
				this.CheckInstance();
			}
			return this.subTree.Tick(agent, blackboard);
		}

		protected override void OnReset()
		{
			if (this.subTree != null && this.subTree.primeNode != null)
			{
				this.subTree.primeNode.Reset(true);
			}
		}

		public override void OnGraphStarted()
		{
			if (this.subTree != null)
			{
				this.CheckInstance();
				foreach (Node current in this.subTree.allNodes)
				{
					current.OnGraphStarted();
				}
			}
		}

		public override void OnGraphStoped()
		{
			if (this.subTree != null)
			{
				foreach (Node current in this.subTree.allNodes)
				{
					current.OnGraphStoped();
				}
			}
		}

		public override void OnGraphPaused()
		{
			if (this.subTree != null)
			{
				foreach (Node current in this.subTree.allNodes)
				{
					current.OnGraphPaused();
				}
			}
		}

		private void CheckInstance()
		{
			if (this.instances.Values.Contains(this.subTree))
			{
				return;
			}
			if (!this.instances.ContainsKey(this.subTree))
			{
				Dictionary<BehaviourTree, BehaviourTree> arg_52_0 = this.instances;
				BehaviourTree arg_52_1 = this.subTree;
				BehaviourTree behaviourTree = Graph.Clone<BehaviourTree>(this.subTree);
				this.subTree = behaviourTree;
				arg_52_0[arg_52_1] = behaviourTree;
			}
		}
	}
}
