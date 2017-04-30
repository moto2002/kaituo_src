using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Category("Composites"), Description("Executes AND immediately returns children node status ONE-BY-ONE. Step Iterator always moves forward by one and loops it's index"), Icon("StepIterator", false)]
	public class StepIterator : BTComposite
	{
		private int current;

		public override string name
		{
			get
			{
				return string.Format("<color=#bf7fff>{0}</color>", base.name.ToUpper());
			}
		}

		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			this.current %= base.outConnections.Count;
			return base.outConnections[this.current].Execute(agent, blackboard);
		}

		protected override void OnReset()
		{
			this.current++;
		}
	}
}
