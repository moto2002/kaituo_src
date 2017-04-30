using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("✫ Blackboard"), Description("It's best to use the respective Condition for a type if existant for performance reasons")]
	public class CheckVariable<T> : ConditionTask
	{
		[BlackboardOnly]
		public BBParameter<T> valueA;

		public BBParameter<T> valueB;

		protected override string info
		{
			get
			{
				return this.valueA + " == " + this.valueB;
			}
		}

		protected override bool OnCheck()
		{
			return object.Equals(this.valueA.value, this.valueB.value);
		}
	}
}
