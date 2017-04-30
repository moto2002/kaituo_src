using NodeCanvas.BehaviourTrees;
using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NodeCanvas.StateMachines
{
	[Category("Nested"), Description("Execute a Behaviour Tree OnEnter. OnExit that Behavior Tree will be stoped. You can optionaly specify a Success Event and a Failure Event which will be sent when the BT's root node status returns either of the two. If so, use alongside with a CheckEvent on a transition."), Name("BehaviourTree")]
	public class NestedBTState : FSMState, IGraphAssignable
	{
		public enum BTExecutionMode
		{
			RunOnce,
			RunForever
		}

		[SerializeField]
		private BBParameter<BehaviourTree> _nestedBT;

		public NestedBTState.BTExecutionMode executionMode = NestedBTState.BTExecutionMode.RunForever;

		public float updateInterval;

		public string successEvent;

		public string failureEvent;

		private readonly Dictionary<BehaviourTree, BehaviourTree> instances = new Dictionary<BehaviourTree, BehaviourTree>();

		private bool BTIsFinished;

		public BehaviourTree nestedBT
		{
			get
			{
				return this._nestedBT.value;
			}
			set
			{
				this._nestedBT.value = value;
				if (this._nestedBT.value != null)
				{
					this._nestedBT.value.agent = base.graphAgent;
					this._nestedBT.value.blackboard = base.graphBlackboard;
				}
			}
		}

		public Graph nestedGraph
		{
			get
			{
				return this.nestedBT;
			}
			set
			{
				this.nestedBT = (BehaviourTree)value;
			}
		}

		protected override void OnInit()
		{
			if (this.nestedBT != null)
			{
				this.CheckInstance();
			}
		}

		protected override void OnEnter()
		{
			if (this.nestedBT == null)
			{
				base.Finish(false);
				return;
			}
			this.CheckInstance();
			this.BTIsFinished = false;
			this.nestedBT.repeat = (this.executionMode == NestedBTState.BTExecutionMode.RunForever);
			this.nestedBT.updateInterval = this.updateInterval;
			this.nestedBT.StartGraph(base.graphAgent, base.graphBlackboard, delegate
			{
				this.BTIsFinished = true;
			});
		}

		protected override void OnUpdate()
		{
			if (!string.IsNullOrEmpty(this.successEvent) && this.nestedBT.rootStatus == Status.Success)
			{
				base.SendEvent(new EventData(this.successEvent));
			}
			if (!string.IsNullOrEmpty(this.failureEvent) && this.nestedBT.rootStatus == Status.Failure)
			{
				base.SendEvent(new EventData(this.failureEvent));
			}
			if (this.BTIsFinished)
			{
				base.Finish();
			}
		}

		protected override void OnExit()
		{
			if (this.nestedBT && this.nestedBT.isRunning)
			{
				this.nestedBT.Stop();
			}
		}

		protected override void OnPause()
		{
			if (this.nestedBT && this.nestedBT.isRunning)
			{
				this.nestedBT.Pause();
			}
		}

		private void CheckInstance()
		{
			if (this.instances.Values.Contains(this.nestedBT))
			{
				return;
			}
			if (!this.instances.ContainsKey(this.nestedBT))
			{
				Dictionary<BehaviourTree, BehaviourTree> arg_52_0 = this.instances;
				BehaviourTree arg_52_1 = this.nestedBT;
				BehaviourTree behaviourTree = Graph.Clone<BehaviourTree>(this.nestedBT);
				this.nestedBT = behaviourTree;
				arg_52_0[arg_52_1] = behaviourTree;
			}
		}
	}
}
