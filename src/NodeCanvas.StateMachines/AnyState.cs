using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;

namespace NodeCanvas.StateMachines
{
	[Description("The Transitions of this node will constantly be checked. If any becomes true, the target connected State will Enter regardless of the current State. This node can have no incomming transitions."), Name("Any State")]
	public class AnyState : FSMState, IUpdatable
	{
		public override string name
		{
			get
			{
				return string.Format("<color=#b3ff7f>{0}</color>", base.name.ToUpper());
			}
		}

		public override int maxInConnections
		{
			get
			{
				return 0;
			}
		}

		public override int maxOutConnections
		{
			get
			{
				return -1;
			}
		}

		public override bool allowAsPrime
		{
			get
			{
				return false;
			}
		}

		public new void Update()
		{
			if (base.outConnections.Count == 0)
			{
				return;
			}
			base.status = Status.Running;
			for (int i = 0; i < base.outConnections.Count; i++)
			{
				FSMConnection fSMConnection = (FSMConnection)base.outConnections[i];
				ConditionTask condition = fSMConnection.condition;
				if (fSMConnection.isActive && fSMConnection.condition != null)
				{
					if (condition.CheckCondition(base.graphAgent, base.graphBlackboard))
					{
						this.FSM.EnterState((FSMState)fSMConnection.targetNode);
						fSMConnection.connectionStatus = Status.Success;
						return;
					}
					fSMConnection.connectionStatus = Status.Failure;
				}
			}
		}
	}
}
