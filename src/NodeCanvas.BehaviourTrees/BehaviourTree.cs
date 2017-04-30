using NodeCanvas.Framework;
using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	public class BehaviourTree : Graph
	{
		public bool repeat = true;

		public float updateInterval;

		private float intervalCounter;

		private Status _rootStatus = Status.Resting;

		public event Action<BehaviourTree, Status> onRootStatusChanged
		{
			[MethodImpl(32)]
			add
			{
				this.onRootStatusChanged = (Action<BehaviourTree, Status>)Delegate.Combine(this.onRootStatusChanged, value);
			}
			[MethodImpl(32)]
			remove
			{
				this.onRootStatusChanged = (Action<BehaviourTree, Status>)Delegate.Remove(this.onRootStatusChanged, value);
			}
		}

		public Status rootStatus
		{
			get
			{
				return this._rootStatus;
			}
			private set
			{
				if (this._rootStatus != value)
				{
					this._rootStatus = value;
					if (this.onRootStatusChanged != null)
					{
						this.onRootStatusChanged(this, value);
					}
				}
			}
		}

		public override Type baseNodeType
		{
			get
			{
				return typeof(BTNode);
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
				return true;
			}
		}

		protected override void OnGraphStarted()
		{
			this.intervalCounter = this.updateInterval;
			this.rootStatus = base.primeNode.status;
		}

		protected override void OnGraphUpdate()
		{
			if (this.intervalCounter >= this.updateInterval)
			{
				this.intervalCounter = 0f;
				if (this.Tick(this.agent, this.blackboard) != Status.Running && !this.repeat)
				{
					base.Stop();
				}
			}
			if (this.updateInterval > 0f)
			{
				this.intervalCounter += Time.deltaTime;
			}
		}

		public Status Tick(Component agent, IBlackboard blackboard)
		{
			if (this.rootStatus != Status.Running)
			{
				base.primeNode.Reset(true);
			}
			this.rootStatus = base.primeNode.Execute(agent, blackboard);
			return this.rootStatus;
		}
	}
}
