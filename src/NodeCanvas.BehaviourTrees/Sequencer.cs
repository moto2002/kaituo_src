using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Category("Composites"), Description("Execute the child nodes in order or randonly and return Success if all children return Success, else return Failure\nIf is Dynamic, higher priority child status is revaluated. If a child returns Failure the Sequencer will bail out immediately in Failure too."), Icon("Sequencer", false)]
	public class Sequencer : BTComposite
	{
		public bool dynamic;

		public bool random;

		private int lastRunningNodeIndex;

		public override string name
		{
			get
			{
				return string.Format("<color=#bf7fff>{0}</color>", base.name.ToUpper());
			}
		}

		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			for (int i = (!this.dynamic) ? this.lastRunningNodeIndex : 0; i < base.outConnections.Count; i++)
			{
				base.status = base.outConnections[i].Execute(agent, blackboard);
				switch (base.status)
				{
				case Status.Failure:
					if (this.dynamic && i < this.lastRunningNodeIndex)
					{
						base.outConnections[this.lastRunningNodeIndex].Reset(true);
					}
					return Status.Failure;
				case Status.Running:
					if (this.dynamic && i < this.lastRunningNodeIndex)
					{
						base.outConnections[this.lastRunningNodeIndex].Reset(true);
					}
					this.lastRunningNodeIndex = i;
					return Status.Running;
				}
			}
			return Status.Success;
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
