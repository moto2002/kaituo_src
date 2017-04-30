using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("✫ Blackboard")]
	public class CheckBoolean : ConditionTask
	{
		[BlackboardOnly]
		public BBParameter<bool> valueA;

		public BBParameter<bool> valueB = true;

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
