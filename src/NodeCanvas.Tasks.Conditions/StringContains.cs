using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("✫ Blackboard")]
	public class StringContains : ConditionTask
	{
		[BlackboardOnly, RequiredField]
		public BBParameter<string> targetString;

		public BBParameter<string> checkString;

		protected override bool OnCheck()
		{
			return this.targetString.value.Contains(this.checkString.value);
		}
	}
}
