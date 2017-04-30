using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace NodeCanvas.DialogueTrees
{
	[Description("Will continue with the first child node which condition returns true. The Dialogue Actor selected will be used for the checks"), Name("Multiple Condition")]
	public class MultipleConditionNode : DTNode, ISubTasksContainer
	{
		public List<ConditionTask> conditions = new List<ConditionTask>();

		public override int maxOutConnections
		{
			get
			{
				return -1;
			}
		}

		public Task[] GetTasks()
		{
			return this.conditions.ToArray();
		}

		public override void OnChildConnected(int index)
		{
			this.conditions.Insert(index, null);
		}

		public override void OnChildDisconnected(int index)
		{
			this.conditions.RemoveAt(index);
		}

		protected override Status OnExecute(Component agent, IBlackboard bb)
		{
			if (base.outConnections.Count == 0)
			{
				return base.Error("There are no connections on the Dialogue Condition Node");
			}
			for (int i = 0; i < base.outConnections.Count; i++)
			{
				if (this.conditions[i] == null || this.conditions[i].CheckCondition(base.finalActor.transform, base.graphBlackboard))
				{
					base.DLGTree.Continue(i);
					return Status.Success;
				}
			}
			Debug.LogWarning("No condition is true. Dialogue Stops");
			base.DLGTree.Stop();
			return Status.Failure;
		}
	}
}
