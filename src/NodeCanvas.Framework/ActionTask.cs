using ParadoxNotion.Services;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

namespace NodeCanvas.Framework
{
	public abstract class ActionTask<T> : ActionTask where T : Component
	{
		public override Type agentType
		{
			get
			{
				return typeof(T);
			}
		}

		public new T agent
		{
			get
			{
				T result;
				try
				{
					result = (T)((object)base.agent);
				}
				catch
				{
					result = (T)((object)null);
				}
				return result;
			}
		}
	}
	public abstract class ActionTask : Task
	{
		[NonSerialized]
		private Status status = Status.Resting;

		[NonSerialized]
		private float startedTime;

		[NonSerialized]
		private float pausedTime;

		[NonSerialized]
		private bool latch;

		[NonSerialized]
		private bool _isPaused;

		public float elapsedTime
		{
			get
			{
				if (this.isPaused)
				{
					return this.pausedTime - this.startedTime;
				}
				if (this.isRunning)
				{
					return Time.time - this.startedTime;
				}
				return 0f;
			}
		}

		public bool isRunning
		{
			get
			{
				return this.status == Status.Running;
			}
		}

		public bool isPaused
		{
			get
			{
				return this._isPaused;
			}
			private set
			{
				this._isPaused = value;
			}
		}

		public void ExecuteAction(Component agent, Action<bool> callback)
		{
			this.ExecuteAction(agent, null, callback);
		}

		public void ExecuteAction(Component agent, IBlackboard blackboard, Action<bool> callback)
		{
			if (!this.isRunning)
			{
				MonoManager.current.StartCoroutine(this.ActionUpdater(agent, blackboard, callback));
			}
		}

		[DebuggerHidden]
		private IEnumerator ActionUpdater(Component agent, IBlackboard blackboard, Action<bool> callback)
		{
			ActionTask.<ActionUpdater>c__IteratorD <ActionUpdater>c__IteratorD = new ActionTask.<ActionUpdater>c__IteratorD();
			<ActionUpdater>c__IteratorD.agent = agent;
			<ActionUpdater>c__IteratorD.blackboard = blackboard;
			<ActionUpdater>c__IteratorD.callback = callback;
			<ActionUpdater>c__IteratorD.<$>agent = agent;
			<ActionUpdater>c__IteratorD.<$>blackboard = blackboard;
			<ActionUpdater>c__IteratorD.<$>callback = callback;
			<ActionUpdater>c__IteratorD.<>f__this = this;
			return <ActionUpdater>c__IteratorD;
		}

		public Status ExecuteAction(Component agent, IBlackboard blackboard)
		{
			if (!base.isActive)
			{
				return Status.Failure;
			}
			if (this.isPaused)
			{
				this.startedTime += Time.time - this.pausedTime;
				this.isPaused = false;
			}
			if (this.status == Status.Running)
			{
				this.OnUpdate();
				this.latch = false;
				return this.status;
			}
			if (this.latch)
			{
				this.latch = false;
				return this.status;
			}
			if (!base.Set(agent, blackboard))
			{
				base.isActive = false;
				return Status.Failure;
			}
			this.startedTime = Time.time;
			this.status = Status.Running;
			this.OnExecute();
			this.latch = false;
			return this.status;
		}

		public void EndAction()
		{
			this.EndAction(new bool?(true));
		}

		public void EndAction(bool? success)
		{
			if (this.status != Status.Running)
			{
				return;
			}
			this.isPaused = false;
			this.status = ((!(success == true)) ? Status.Failure : Status.Success);
			this.latch = success.HasValue;
			this.OnStop();
		}

		public void PauseAction()
		{
			if (this.status != Status.Running)
			{
				return;
			}
			this.pausedTime = Time.time;
			this.isPaused = true;
			this.OnPause();
		}

		protected virtual void OnExecute()
		{
		}

		protected virtual void OnUpdate()
		{
		}

		protected virtual void OnStop()
		{
		}

		protected virtual void OnPause()
		{
		}
	}
}
