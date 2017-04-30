using System;
using System.Collections.Generic;
using UnityEngine;

namespace NodeCanvas.Framework
{
	public class ConditionList : ConditionTask
	{
		public enum ConditionsCheckMode
		{
			AllTrueRequired,
			AnyTrueSuffice
		}

		public ConditionList.ConditionsCheckMode checkMode;

		public List<ConditionTask> conditions = new List<ConditionTask>();

		private bool allTrueRequired
		{
			get
			{
				return this.checkMode == ConditionList.ConditionsCheckMode.AllTrueRequired;
			}
		}

		protected override string info
		{
			get
			{
				string text = (this.conditions.Count == 0) ? "No Conditions" : string.Empty;
				if (this.conditions.Count > 1)
				{
					text = text + "<b>(" + ((!this.allTrueRequired) ? "ANY True" : "ALL True") + ")</b>\n";
				}
				for (int i = 0; i < this.conditions.Count; i++)
				{
					if (this.conditions[i] != null)
					{
						if (this.conditions[i].isActive)
						{
							text = text + this.conditions[i].summaryInfo + ((i != this.conditions.Count - 1) ? "\n" : string.Empty);
						}
					}
				}
				return text;
			}
		}

		public override Task Duplicate(ITaskSystem newOwnerSystem)
		{
			ConditionList conditionList = (ConditionList)base.Duplicate(newOwnerSystem);
			conditionList.conditions.Clear();
			foreach (ConditionTask current in this.conditions)
			{
				conditionList.AddCondition((ConditionTask)current.Duplicate(newOwnerSystem));
			}
			return conditionList;
		}

		protected override bool OnCheck()
		{
			int num = 0;
			for (int i = 0; i < this.conditions.Count; i++)
			{
				if (!this.conditions[i].isActive)
				{
					num++;
				}
				else if (this.conditions[i].CheckCondition(base.agent, base.blackboard))
				{
					if (!this.allTrueRequired)
					{
						return true;
					}
					num++;
				}
				else if (this.allTrueRequired)
				{
					return false;
				}
			}
			return num == this.conditions.Count;
		}

		public override void OnDrawGizmos()
		{
			foreach (ConditionTask current in this.conditions)
			{
				current.OnDrawGizmos();
			}
		}

		public override void OnDrawGizmosSelected()
		{
			foreach (ConditionTask current in this.conditions)
			{
				current.OnDrawGizmosSelected();
			}
		}

		private void AddCondition(ConditionTask condition)
		{
			if (condition is ConditionList)
			{
				Debug.LogWarning("Adding an ConditionList within an ConditionList is not allowed");
				return;
			}
			this.conditions.Add(condition);
			condition.SetOwnerSystem(base.ownerSystem);
		}
	}
}
