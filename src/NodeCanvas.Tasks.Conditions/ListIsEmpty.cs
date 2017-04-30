using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using System.Collections;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("✫ Blackboard/Lists")]
	public class ListIsEmpty : ConditionTask
	{
		[BlackboardOnly, RequiredField]
		public BBParameter<IList> targetList;

		protected override bool OnCheck()
		{
			return this.targetList.value.Count == 0;
		}
	}
}
