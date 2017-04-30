using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Category("Decorators"), Description("Protect the decorated child from running if another Guard with the same token is already guarding (Running) that token.\nGuarding is global for all of the agent's Behaviour Trees."), Icon("Shield", false), Name("Guard")]
	public class Guard : BTDecorator
	{
		public enum GuardMode
		{
			ReturnFailure,
			WaitUntilReleased
		}

		public BBParameter<string> token;

		public Guard.GuardMode ifGuarded;

		private bool isGuarding;

		private static readonly Dictionary<GameObject, List<Guard>> guards = new Dictionary<GameObject, List<Guard>>();

		private static List<Guard> AgentGuards(Component agent)
		{
			return Guard.guards[agent.gameObject];
		}

		public override void OnGraphStarted()
		{
			this.SetGuards(base.graphAgent);
		}

		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			if (base.decoratedConnection == null)
			{
				return Status.Failure;
			}
			if (agent != base.graphAgent)
			{
				this.SetGuards(agent);
			}
			for (int i = 0; i < Guard.AgentGuards(agent).Count; i++)
			{
				Guard guard = Guard.AgentGuards(agent)[i];
				if (guard != this && guard.isGuarding && guard.token.value == this.token.value)
				{
					return (this.ifGuarded != Guard.GuardMode.ReturnFailure) ? Status.Running : Status.Failure;
				}
			}
			base.status = base.decoratedConnection.Execute(agent, blackboard);
			if (base.status == Status.Running)
			{
				this.isGuarding = true;
				return Status.Running;
			}
			this.isGuarding = false;
			return base.status;
		}

		protected override void OnReset()
		{
			this.isGuarding = false;
		}

		private void SetGuards(Component guardAgent)
		{
			if (!Guard.guards.ContainsKey(guardAgent.gameObject))
			{
				Guard.guards[guardAgent.gameObject] = new List<Guard>();
			}
			if (!Guard.AgentGuards(guardAgent).Contains(this) && !string.IsNullOrEmpty(this.token.value))
			{
				Guard.AgentGuards(guardAgent).Add(this);
			}
		}
	}
}
