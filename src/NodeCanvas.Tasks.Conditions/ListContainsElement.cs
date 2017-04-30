using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using System.Collections.Generic;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("✫ Blackboard/Lists"), Description("Check if an element is contained in the target list")]
	public class ListContainsElement<T> : ConditionTask
	{
		[BlackboardOnly, RequiredField]
		public BBParameter<List<T>> targetList;

		public BBParameter<T> checkElement;

		protected override string info
		{
			get
			{
				return this.targetList + " contains " + this.checkElement;
			}
		}

		protected override bool OnCheck()
		{
			return this.targetList.value.Contains(this.checkElement.value);
		}
	}
}
