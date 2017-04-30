using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Category("Composites"), Description("Very similar to the normal Selector, but executes it's child nodes sorted by their Priority from higher to lower"), Icon("Priority", false)]
	public class PrioritySelector : BTComposite
	{
		public List<BBParameter<float>> priorities = new List<BBParameter<float>>();

		private List<Connection> orderedConnections = new List<Connection>();

		private int current;

		public override void OnChildConnected(int index)
		{
			this.priorities.Insert(index, new BBParameter<float>
			{
				value = 1f,
				bb = base.graphBlackboard
			});
		}

		public override void OnChildDisconnected(int index)
		{
			this.priorities.RemoveAt(index);
		}

		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			if (base.status == Status.Resting)
			{
				this.orderedConnections = (from c in base.outConnections
				orderby this.priorities[base.outConnections.IndexOf(c)].value
				select c).Reverse<Connection>().ToList<Connection>();
			}
			for (int i = this.current; i < this.orderedConnections.Count; i++)
			{
				base.status = this.orderedConnections[i].Execute(agent, blackboard);
				if (base.status == Status.Success)
				{
					return Status.Success;
				}
				if (base.status == Status.Running)
				{
					this.current = i;
					return Status.Running;
				}
			}
			return Status.Failure;
		}

		protected override void OnReset()
		{
			this.current = 0;
		}
	}
}
