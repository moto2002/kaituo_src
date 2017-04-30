using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Category("Composites"), Description("Execute all child nodes once but simultaneously and return Success or Failure depending on the selected ParallelPolicy.\nIf is Dynamic higher priority chilren status are revaluated"), Icon("Parallel", false)]
	public class Parallel : BTComposite
	{
		public enum ParallelPolicy
		{
			FirstFailure,
			FirstSuccess,
			FirstSuccessOrFailure
		}

		public Parallel.ParallelPolicy policy;

		public bool dynamic;

		private readonly List<Connection> finishedConnections = new List<Connection>();

		public override string name
		{
			get
			{
				return string.Format("<color=#ff64cb>{0}</color>", base.name.ToUpper());
			}
		}

		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			for (int i = 0; i < base.outConnections.Count; i++)
			{
				if (this.dynamic || !this.finishedConnections.Contains(base.outConnections[i]))
				{
					base.status = base.outConnections[i].Execute(agent, blackboard);
					if (base.status == Status.Failure && (this.policy == Parallel.ParallelPolicy.FirstFailure || this.policy == Parallel.ParallelPolicy.FirstSuccessOrFailure))
					{
						this.ResetRunning();
						return Status.Failure;
					}
					if (base.status == Status.Success && (this.policy == Parallel.ParallelPolicy.FirstSuccess || this.policy == Parallel.ParallelPolicy.FirstSuccessOrFailure))
					{
						this.ResetRunning();
						return Status.Success;
					}
					if (base.status != Status.Running && !this.finishedConnections.Contains(base.outConnections[i]))
					{
						this.finishedConnections.Add(base.outConnections[i]);
					}
				}
			}
			if (this.finishedConnections.Count != base.outConnections.Count)
			{
				return Status.Running;
			}
			Parallel.ParallelPolicy parallelPolicy = this.policy;
			if (parallelPolicy == Parallel.ParallelPolicy.FirstFailure)
			{
				return Status.Success;
			}
			if (parallelPolicy != Parallel.ParallelPolicy.FirstSuccess)
			{
				return Status.Running;
			}
			return Status.Failure;
		}

		protected override void OnReset()
		{
			this.finishedConnections.Clear();
		}

		private void ResetRunning()
		{
			for (int i = 0; i < base.outConnections.Count; i++)
			{
				if (base.outConnections[i].connectionStatus == Status.Running)
				{
					base.outConnections[i].Reset(true);
				}
			}
		}
	}
}
