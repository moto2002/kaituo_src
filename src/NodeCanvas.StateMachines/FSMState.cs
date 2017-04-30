using NodeCanvas.Framework;
using System;
using System.Linq;
using UnityEngine;

namespace NodeCanvas.StateMachines
{
	public abstract class FSMState : Node, IState
	{
		public enum TransitionEvaluationMode
		{
			CheckContinuously,
			CheckAfterStateFinished,
			CheckManualy
		}

		[SerializeField]
		private FSMState.TransitionEvaluationMode _transitionEvaluation;

		private float _elapsedTime;

		public override int maxInConnections
		{
			get
			{
				return -1;
			}
		}

		public override int maxOutConnections
		{
			get
			{
				return -1;
			}
		}

		public sealed override Type outConnectionType
		{
			get
			{
				return typeof(FSMConnection);
			}
		}

		public override bool allowAsPrime
		{
			get
			{
				return true;
			}
		}

		public sealed override bool showCommentsBottom
		{
			get
			{
				return true;
			}
		}

		public FSMState.TransitionEvaluationMode transitionEvaluation
		{
			get
			{
				return this._transitionEvaluation;
			}
			set
			{
				this._transitionEvaluation = value;
			}
		}

		public float elapsedTime
		{
			get
			{
				return this._elapsedTime;
			}
			private set
			{
				this._elapsedTime = value;
			}
		}

		public FSM FSM
		{
			get
			{
				return (FSM)base.graph;
			}
		}

		public FSMConnection[] GetTransitions()
		{
			return base.outConnections.Cast<FSMConnection>().ToArray<FSMConnection>();
		}

		public void Finish()
		{
			this.Finish(true);
		}

		public void Finish(bool inSuccess)
		{
			base.status = ((!inSuccess) ? Status.Failure : Status.Success);
		}

		public sealed override void OnGraphStarted()
		{
			this.OnInit();
		}

		public sealed override void OnGraphStoped()
		{
			base.status = Status.Resting;
		}

		public sealed override void OnGraphPaused()
		{
			if (base.status == Status.Running)
			{
				this.OnPause();
			}
		}

		protected sealed override Status OnExecute(Component agent, IBlackboard bb)
		{
			if (base.status == Status.Resting || base.status == Status.Running)
			{
				base.status = Status.Running;
				this.OnEnter();
			}
			return base.status;
		}

		public void Update()
		{
			this.elapsedTime += Time.deltaTime;
			if (this.transitionEvaluation == FSMState.TransitionEvaluationMode.CheckContinuously)
			{
				this.CheckTransitions();
			}
			else if (this.transitionEvaluation == FSMState.TransitionEvaluationMode.CheckAfterStateFinished && base.status != Status.Running)
			{
				this.CheckTransitions();
			}
			if (base.status == Status.Running)
			{
				this.OnUpdate();
			}
		}

		public bool CheckTransitions()
		{
			for (int i = 0; i < base.outConnections.Count; i++)
			{
				FSMConnection fSMConnection = (FSMConnection)base.outConnections[i];
				ConditionTask condition = fSMConnection.condition;
				if (fSMConnection.isActive)
				{
					if ((condition != null && condition.CheckCondition(base.graphAgent, base.graphBlackboard)) || (condition == null && base.status != Status.Running))
					{
						this.FSM.EnterState((FSMState)fSMConnection.targetNode);
						fSMConnection.connectionStatus = Status.Success;
						return true;
					}
					fSMConnection.connectionStatus = Status.Failure;
				}
			}
			return false;
		}

		protected sealed override void OnReset()
		{
			base.status = Status.Resting;
			this.elapsedTime = 0f;
			this.OnExit();
		}

		protected virtual void OnInit()
		{
		}

		protected virtual void OnEnter()
		{
		}

		protected virtual void OnUpdate()
		{
		}

		protected virtual void OnExit()
		{
		}

		protected virtual void OnPause()
		{
		}

		virtual string get_tag()
		{
			return base.tag;
		}
	}
}
