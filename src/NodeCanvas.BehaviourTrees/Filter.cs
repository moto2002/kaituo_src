using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Category("Decorators"), Description("Filters the access of it's child node either a specific number of times, or every specific amount of time. By default the node is 'Treated as Inactive' to it's parent when child is Filtered. Unchecking this option will instead return Failure when Filtered."), Icon("Lock", false), Name("Filter")]
	public class Filter : BTDecorator
	{
		public enum FilterMode
		{
			LimitNumberOfTimes,
			CoolDown
		}

		public Filter.FilterMode filterMode = Filter.FilterMode.CoolDown;

		public BBParameter<int> maxCount = new BBParameter<int>
		{
			value = 1
		};

		public BBParameter<float> coolDownTime = new BBParameter<float>
		{
			value = 5f
		};

		public bool inactiveWhenLimited = true;

		private int executedCount;

		private float currentTime;

		public override void OnGraphStarted()
		{
			this.executedCount = 0;
			this.currentTime = 0f;
		}

		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			if (base.decoratedConnection == null)
			{
				return Status.Resting;
			}
			Filter.FilterMode filterMode = this.filterMode;
			if (filterMode != Filter.FilterMode.LimitNumberOfTimes)
			{
				if (filterMode == Filter.FilterMode.CoolDown)
				{
					if (this.currentTime > 0f)
					{
						return (!this.inactiveWhenLimited) ? Status.Failure : Status.Resting;
					}
					base.status = base.decoratedConnection.Execute(agent, blackboard);
					if (base.status == Status.Success || base.status == Status.Failure)
					{
						base.StartCoroutine(this.Cooldown());
					}
				}
			}
			else
			{
				if (this.executedCount >= this.maxCount.value)
				{
					return (!this.inactiveWhenLimited) ? Status.Failure : Status.Resting;
				}
				base.status = base.decoratedConnection.Execute(agent, blackboard);
				if (base.status == Status.Success || base.status == Status.Failure)
				{
					this.executedCount++;
				}
			}
			return base.status;
		}

		[DebuggerHidden]
		private IEnumerator Cooldown()
		{
			Filter.<Cooldown>c__Iterator19 <Cooldown>c__Iterator = new Filter.<Cooldown>c__Iterator19();
			<Cooldown>c__Iterator.<>f__this = this;
			return <Cooldown>c__Iterator;
		}
	}
}
