using NodeCanvas.Framework;
using System;
using UnityEngine;

namespace NodeCanvas.StateMachines
{
	public class FSMConnection : Connection, ITaskAssignable, ITaskAssignable<ConditionTask>
	{
		[SerializeField]
		private ConditionTask _condition;

		public ConditionTask condition
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

		public void PerformTransition()
		{
			(base.graph as FSM).EnterState((FSMState)base.targetNode);
		}
	}
}
