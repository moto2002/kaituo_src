using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Category("Composites"), Description("Executes ONE child based on the provided int or enum and return it's status. If 'case' change while a child is running, that child will be interrupted before the new child is executed"), Icon("IndexSwitcher", false)]
	public class Switch : BTComposite
	{
		public enum CaseSelectionMode
		{
			IndexBased,
			EnumBased
		}

		public enum OutOfRangeMode
		{
			ReturnFailure,
			LoopIndex
		}

		[BlackboardOnly]
		public BBObjectParameter enumCase = new BBObjectParameter(typeof(Enum));

		public BBParameter<int> intCase;

		public Switch.CaseSelectionMode selectionMode = Switch.CaseSelectionMode.EnumBased;

		public Switch.OutOfRangeMode outOfRangeMode;

		private int current;

		private int runningIndex;

		public override string name
		{
			get
			{
				return string.Format("<color=#b3ff7f>{0}</color>", base.name.ToUpper());
			}
		}

		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			if (base.outConnections.Count == 0)
			{
				return Status.Failure;
			}
			if (this.selectionMode == Switch.CaseSelectionMode.IndexBased)
			{
				this.current = this.intCase.value;
				if (this.outOfRangeMode == Switch.OutOfRangeMode.LoopIndex)
				{
					this.current = Mathf.Abs(this.current) % base.outConnections.Count;
				}
			}
			else
			{
				this.current = (int)Enum.Parse(this.enumCase.value.GetType(), this.enumCase.value.ToString());
			}
			if (this.runningIndex != this.current)
			{
				base.outConnections[this.runningIndex].Reset(true);
			}
			if (this.current < 0 || this.current >= base.outConnections.Count)
			{
				return Status.Failure;
			}
			base.status = base.outConnections[this.current].Execute(agent, blackboard);
			if (base.status == Status.Running)
			{
				this.runningIndex = this.current;
			}
			return base.status;
		}
	}
}
