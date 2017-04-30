using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Category("Decorators"), Description("Set another Agent for the rest of the Tree dynamicaly from this point and on. All nodes under this will be executed for the new agent"), Icon("Set", false), Name("Override Agent")]
	public class Setter : BTDecorator
	{
		public BBParameter<GameObject> newAgent;

		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			if (base.decoratedConnection == null)
			{
				return Status.Resting;
			}
			if (this.newAgent.value != null)
			{
				agent = this.newAgent.value.transform;
			}
			return base.decoratedConnection.Execute(agent, blackboard);
		}
	}
}
