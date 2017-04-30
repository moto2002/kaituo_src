using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Category("Composites"), Description("Works like a normal Selector, but when a child node returns Success, that child will be moved to the end.\nAs a result, previously Failed children will always be checked first and recently Successful children last"), Icon("FlipSelector", false)]
	public class FlipSelector : BTComposite
	{
		private int current;

		public override string name
		{
			get
			{
				return string.Format("<color=#b3ff7f>{0}</color>", base.name.ToUpper());
			}
		}

		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			for (int i = this.current; i < base.outConnections.Count; i++)
			{
				base.status = base.outConnections[i].Execute(agent, blackboard);
				if (base.status == Status.Running)
				{
					this.current = i;
					return Status.Running;
				}
				if (base.status == Status.Success)
				{
					this.SendToBack(i);
					return Status.Success;
				}
			}
			return Status.Failure;
		}

		private void SendToBack(int i)
		{
			Connection item = base.outConnections[i];
			base.outConnections.RemoveAt(i);
			base.outConnections.Add(item);
		}

		protected override void OnReset()
		{
			this.current = 0;
		}
	}
}
