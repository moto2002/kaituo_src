using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion.Design;
using System;
using System.Collections;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Category("Decorators"), Description("Iterate any type of list and execute the child node for each element in the list. Keeps iterating until the Termination Condition is met or the whole list is iterated and return the child node status"), Icon("List", false), Name("Iterate")]
	public class Iterator : BTDecorator
	{
		public enum TerminationConditions
		{
			None,
			FirstSuccess,
			FirstFailure
		}

		[BlackboardOnly, RequiredField]
		public BBParameter<IList> targetList;

		[BlackboardOnly]
		public BBObjectParameter current;

		public BBParameter<int> maxIteration = -1;

		public Iterator.TerminationConditions terminationCondition;

		public bool resetIndex = true;

		private int currentIndex;

		private IList list
		{
			get
			{
				IList arg_1E_0;
				if (this.targetList != null)
				{
					IList value = this.targetList.value;
					arg_1E_0 = value;
				}
				else
				{
					arg_1E_0 = null;
				}
				return arg_1E_0;
			}
		}

		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			if (base.decoratedConnection == null)
			{
				return Status.Resting;
			}
			if (this.list == null || this.list.Count == 0)
			{
				return Status.Failure;
			}
			this.current.value = this.list[this.currentIndex];
			base.status = base.decoratedConnection.Execute(agent, blackboard);
			if (base.status == Status.Success && this.terminationCondition == Iterator.TerminationConditions.FirstSuccess)
			{
				return Status.Success;
			}
			if (base.status == Status.Failure && this.terminationCondition == Iterator.TerminationConditions.FirstFailure)
			{
				return Status.Failure;
			}
			if (base.status == Status.Running)
			{
				return base.status;
			}
			if (this.currentIndex == this.list.Count - 1 || this.currentIndex == this.maxIteration.value - 1)
			{
				return base.status;
			}
			base.decoratedConnection.Reset(true);
			this.currentIndex++;
			return Status.Running;
		}

		protected override void OnReset()
		{
			if (this.resetIndex || this.currentIndex == this.list.Count - 1 || this.currentIndex == this.maxIteration.value - 1)
			{
				this.currentIndex = 0;
			}
		}
	}
}
