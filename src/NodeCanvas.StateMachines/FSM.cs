using NodeCanvas.Framework;
using ParadoxNotion;
using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace NodeCanvas.StateMachines
{
	public class FSM : Graph
	{
		private FSMState currentState;

		private FSMState previousState;

		private IUpdatable[] updatableNodes;

		private event Action<IState> CallbackEnter
		{
			[MethodImpl(32)]
			add
			{
				this.CallbackEnter = (Action<IState>)Delegate.Combine(this.CallbackEnter, value);
			}
			[MethodImpl(32)]
			remove
			{
				this.CallbackEnter = (Action<IState>)Delegate.Remove(this.CallbackEnter, value);
			}
		}

		private event Action<IState> CallbackStay
		{
			[MethodImpl(32)]
			add
			{
				this.CallbackStay = (Action<IState>)Delegate.Combine(this.CallbackStay, value);
			}
			[MethodImpl(32)]
			remove
			{
				this.CallbackStay = (Action<IState>)Delegate.Remove(this.CallbackStay, value);
			}
		}

		private event Action<IState> CallbackExit
		{
			[MethodImpl(32)]
			add
			{
				this.CallbackExit = (Action<IState>)Delegate.Combine(this.CallbackExit, value);
			}
			[MethodImpl(32)]
			remove
			{
				this.CallbackExit = (Action<IState>)Delegate.Remove(this.CallbackExit, value);
			}
		}

		public string currentStateName
		{
			get
			{
				return (this.currentState == null) ? null : this.currentState.name;
			}
		}

		public string previousStateName
		{
			get
			{
				return (this.previousState == null) ? null : this.previousState.name;
			}
		}

		public override Type baseNodeType
		{
			get
			{
				return typeof(FSMState);
			}
		}

		public override bool requiresAgent
		{
			get
			{
				return true;
			}
		}

		public override bool requiresPrimeNode
		{
			get
			{
				return true;
			}
		}

		public override bool autoSort
		{
			get
			{
				return false;
			}
		}

		protected override void OnGraphStarted()
		{
			this.GatherDelegates();
			this.updatableNodes = base.allNodes.OfType<IUpdatable>().ToArray<IUpdatable>();
			foreach (ConcurrentState current in this.updatableNodes.OfType<ConcurrentState>())
			{
				current.Execute(this.agent, this.blackboard);
			}
			this.EnterState((this.previousState != null) ? this.previousState : ((FSMState)base.primeNode));
		}

		protected override void OnGraphUpdate()
		{
			if (this.currentState == null)
			{
				Debug.LogError("Current FSM State is or became null. Stopping FSM...");
				base.Stop();
			}
			if (this.currentState.status != Status.Running && this.currentState.outConnections.Count == 0)
			{
				base.Stop();
				return;
			}
			for (int i = 0; i < this.updatableNodes.Length; i++)
			{
				this.updatableNodes[i].Update();
			}
			this.currentState.Update();
			if (this.CallbackStay != null && this.currentState != null && this.currentState.status == Status.Running)
			{
				this.CallbackStay(this.currentState);
			}
		}

		protected override void OnGraphStoped()
		{
			this.previousState = null;
			this.currentState = null;
		}

		protected override void OnGraphPaused()
		{
			this.previousState = this.currentState;
			this.currentState = null;
		}

		public bool EnterState(FSMState newState)
		{
			if (!base.isRunning)
			{
				Debug.LogWarning("Tried to EnterState on an FSM that was not running", this);
				return false;
			}
			if (newState == null)
			{
				Debug.LogWarning("Tried to Enter Null State");
				return false;
			}
			if (this.currentState != null)
			{
				this.currentState.Finish();
				this.currentState.Reset(true);
				if (this.CallbackExit != null)
				{
					this.CallbackExit(this.currentState);
				}
				foreach (Connection current in this.currentState.inConnections)
				{
					current.connectionStatus = Status.Resting;
				}
			}
			this.previousState = this.currentState;
			this.currentState = newState;
			this.currentState.Execute(this.agent, this.blackboard);
			if (this.CallbackEnter != null)
			{
				this.CallbackEnter(this.currentState);
			}
			return true;
		}

		public FSMState TriggerState(string stateName)
		{
			FSMState stateWithName = this.GetStateWithName(stateName);
			if (stateWithName != null)
			{
				this.EnterState(stateWithName);
				return stateWithName;
			}
			Debug.LogWarning(string.Concat(new string[]
			{
				"No State with name '",
				stateName,
				"' found on FSM '",
				base.name,
				"'"
			}));
			return null;
		}

		public string[] GetStateNames()
		{
			return (from n in base.allNodes
			where n.allowAsPrime
			select n.name).ToArray<string>();
		}

		public FSMState GetStateWithName(string name)
		{
			return (FSMState)base.allNodes.Find((Node n) => n.allowAsPrime && n.name == name);
		}

		private void GatherDelegates()
		{
			MonoBehaviour[] components = this.agent.gameObject.GetComponents<MonoBehaviour>();
			for (int i = 0; i < components.Length; i++)
			{
				MonoBehaviour monoBehaviour = components[i];
				MethodInfo methodInfo = monoBehaviour.GetType().RTGetMethod("OnStateEnter", false);
				MethodInfo methodInfo2 = monoBehaviour.GetType().RTGetMethod("OnStateUpdate", false);
				MethodInfo methodInfo3 = monoBehaviour.GetType().RTGetMethod("OnStateExit", false);
				if (methodInfo != null)
				{
					this.CallbackEnter = (Action<IState>)Delegate.Combine(this.CallbackEnter, methodInfo.RTCreateDelegate(monoBehaviour));
				}
				if (methodInfo2 != null)
				{
					this.CallbackStay = (Action<IState>)Delegate.Combine(this.CallbackStay, methodInfo2.RTCreateDelegate(monoBehaviour));
				}
				if (methodInfo3 != null)
				{
					this.CallbackExit = (Action<IState>)Delegate.Combine(this.CallbackExit, methodInfo3.RTCreateDelegate(monoBehaviour));
				}
			}
		}
	}
}
