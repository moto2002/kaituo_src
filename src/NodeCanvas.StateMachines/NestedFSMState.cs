using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NodeCanvas.StateMachines
{
	[Category("Nested"), Description("Execute a nested FSM OnEnter and Stop that FSM OnExit. This state is Finished when the nested FSM is finished as well"), Name("FSM")]
	public class NestedFSMState : FSMState, IGraphAssignable
	{
		[SerializeField]
		private BBParameter<FSM> _nestedFSM;

		private readonly Dictionary<FSM, FSM> instances = new Dictionary<FSM, FSM>();

		public FSM nestedFSM
		{
			get
			{
				return this._nestedFSM.value;
			}
			set
			{
				this._nestedFSM.value = value;
				if (this._nestedFSM.value != null)
				{
					this._nestedFSM.value.agent = base.graphAgent;
					this._nestedFSM.value.blackboard = base.graphBlackboard;
				}
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

		protected override void OnInit()
		{
			if (this.nestedFSM != null)
			{
				this.CheckInstance();
			}
		}

		protected override void OnEnter()
		{
			if (this.nestedFSM == null)
			{
				base.Finish(false);
				return;
			}
			this.CheckInstance();
			this.nestedFSM.StartGraph(base.graphAgent, base.graphBlackboard, new Action(base.Finish));
		}

		protected override void OnExit()
		{
			if (this.nestedFSM != null && (this.nestedFSM.isRunning || this.nestedFSM.isPaused))
			{
				this.nestedFSM.Stop();
			}
		}

		protected override void OnPause()
		{
			if (this.nestedFSM != null)
			{
				this.nestedFSM.Pause();
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
