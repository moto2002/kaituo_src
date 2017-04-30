using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("✫ Blackboard")]
	public class CheckString : ConditionTask
	{
		[BlackboardOnly]
		public BBParameter<string> valueA;

		public BBParameter<string> valueB;

		protected override string info
		{
			get
			{
				return this.valueA + " == " + this.valueB;
			}
		}

		protected override bool OnCheck()
		{
			return this.valueA.value == this.valueB.value;
		}
	}
}
