using NodeCanvas.Framework;
using NodeCanvas.StateMachines;
using ParadoxNotion.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Category("Nested"), Description("NestedFSM can be assigned an entire FSM. This node will return Running for as long as the FSM is Running. If a Success or Failure State is selected, then it will return Success or Failure as soon as the Nested FSM enters that state at which point the FSM will also be stoped. If the Nested FSM ends otherwise, this node will return Success."), Icon("FSM", false), Name("FSM")]
	public class NestedFSM : BTNode, IGraphAssignable
	{
		[SerializeField]
		private BBParameter<FSM> _nestedFSM;

		private readonly Dictionary<FSM, FSM> instances = new Dictionary<FSM, FSM>();

		public string successState;

		public string failureState;

		public FSM nestedFSM
		{
			get
			{
				return this._nestedFSM.value;
			}
			set
			{
				this._nestedFSM.value = value;
				if (this._nestedFSM.value == null)
				{
					return;
				}
				this._nestedFSM.value.agent = base.graphAgent;
				this._nestedFSM.value.blackboard = base.graphBlackboard;
			}
		}

		public Graph nestedGraph
		{
			get
			{
				return this.nestedFSM;
			}
			set
			{
				this.nestedFSM = (FSM)value;
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
			if (this.nestedFSM == null || this.nestedFSM.primeNode == null)
			{
				return Status.Failure;
			}
			if (base.status == Status.Resting || this.nestedFSM.isPaused)
			{
				base.status = Status.Running;
				this.nestedFSM.StartGraph(agent, blackboard, new Action(this.OnFSMFinish));
			}
			if (!string.IsNullOrEmpty(this.successState) && this.nestedFSM.currentStateName == this.successState)
			{
				this.nestedFSM.Stop();
				return Status.Success;
			}
			if (!string.IsNullOrEmpty(this.failureState) && this.nestedFSM.currentStateName == this.failureState)
			{
				this.nestedFSM.Stop();
				return Status.Failure;
			}
			return base.status;
		}

		private void OnFSMFinish()
		{
			if (base.status == Status.Running)
			{
				base.status = Status.Success;
			}
		}

		protected override void OnReset()
		{
			if (this.nestedFSM != null)
			{
				this.nestedFSM.Stop();
			}
		}

		public override void OnGraphStarted()
		{
			if (this.nestedFSM != null)
			{
				this.CheckInstance();
			}
		}

		public override void OnGraphPaused()
		{
			if (this.nestedFSM != null)
			{
				this.nestedFSM.Pause();
			}
		}

		public override void OnGraphStoped()
		{
			if (this.nestedFSM != null)
			{
				this.nestedFSM.Stop();
			}
		}

		private void CheckInstance()
		{
			if (this.instances.Values.Contains(this.nestedFSM))
			{
				return;
			}
			if (!this.instances.ContainsKey(this.nestedFSM))
			{
				Dictionary<FSM, FSM> arg_52_0 = this.instances;
				FSM arg_52_1 = this.nestedFSM;
				FSM fSM = Graph.Clone<FSM>(this.nestedFSM);
				this.nestedFSM = fSM;
				arg_52_0[arg_52_1] = fSM;
			}
		}
	}
}
