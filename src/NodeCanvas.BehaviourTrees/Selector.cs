using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Category("Composites"), Description("Execute the child nodes in order or randonly until the first that returns Success and return Success as well. If none returns Success, then returns Failure.\nIf is Dynamic, then higher priority children Status are revaluated and if one returns Success the Selector will select that one and bail out immediately in Success too"), Icon("Selector", false)]
	public class Selector : BTComposite
	{
		public bool dynamic;

		public bool random;

		private int lastRunningNodeIndex;

		public override string name
		{
			get
			{
				return string.Format("<color=#b3ff7f>{0}</color>", base.name.ToUpper());
			}
		}

		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			for (int i = (!this.dynamic) ? this.lastRunningNodeIndex : 0; i < base.outConnections.Count; i++)
			{
				base.status = base.outConnections[i].Execute(agent, blackboard);
				Status status = base.status;
				if (status == Status.Success)
				{
					if (this.dynamic && i < this.lastRunningNodeIndex)
					{
						base.outConnections[this.lastRunningNodeIndex].Reset(true);
					}
					return Status.Success;
				}
				if (status == Status.Running)
				{
					if (this.dynamic && i < this.lastRunningNodeIndex)
					{
						base.outConnections[this.lastRunningNodeIndex].Reset(true);
					}
					this.lastRunningNodeIndex = i;
					return Status.Running;
				}
			}
			return Status.Failure;
		}

		protected override void OnReset()
		{
			this.lastRunningNodeIndex = 0;
			if (this.random)
			{
				base.outConnections = this.Shuffle(base.outConnections);
			}
		}

		public override void OnChildDisconnected(int index)
		{
			if (index != 0 && index == this.lastRunningNodeIndex)
			{
				this.lastRunningNodeIndex--;
			}
		}

		public override void OnGraphStarted()
		{
			this.OnReset();
		}

		private List<Connection> Shuffle(List<Connection> list)
		{
			for (int i = list.Count - 1; i > 0; i--)
			{
				int index = (int)Mathf.Floor(UnityEngine.Random.value * (float)(i + 1));
				Connection value = list[i];
				list[i] = list[index];
				list[index] = value;
			}
			return list;
		}
	}
}
