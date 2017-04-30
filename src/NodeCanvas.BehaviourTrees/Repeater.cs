using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Category("Decorators"), Description("Repeat the child either x times or until it returns the specified status, or forever"), Icon("Repeat", false), Name("Repeat")]
	public class Repeater : BTDecorator
	{
		public enum RepeaterMode
		{
			RepeatTimes,
			RepeatUntil,
			RepeatForever
		}

		public enum RepeatUntilStatus
		{
			Failure,
			Success
		}

		public Repeater.RepeaterMode repeaterMode;

		public Repeater.RepeatUntilStatus repeatUntilStatus = Repeater.RepeatUntilStatus.Success;

		public BBParameter<int> repeatTimes = 1;

		private int currentIteration = 1;

		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			if (base.decoratedConnection == null)
			{
				return Status.Resting;
			}
			base.status = base.decoratedConnection.Execute(agent, blackboard);
			Status status = base.status;
			if (status == Status.Running)
			{
				return base.status;
			}
			if (status != Status.Resting)
			{
				Repeater.RepeaterMode repeaterMode = this.repeaterMode;
				if (repeaterMode != Repeater.RepeaterMode.RepeatTimes)
				{
					if (repeaterMode == Repeater.RepeaterMode.RepeatUntil)
					{
						if (base.status == (Status)this.repeatUntilStatus)
						{
							return base.status;
						}
					}
				}
				else
				{
					if (this.currentIteration >= this.repeatTimes.value)
					{
						return base.status;
					}
					this.currentIteration++;
				}
				base.decoratedConnection.Reset(true);
				return Status.Running;
			}
			return Status.Running;
		}

		protected override void OnReset()
		{
			this.currentIteration = 1;
		}
	}
}
