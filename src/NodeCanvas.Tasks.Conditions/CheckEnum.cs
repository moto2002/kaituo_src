using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion.Design;
using System;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("✫ Blackboard")]
	public class CheckEnum : ConditionTask
	{
		[BlackboardOnly]
		public BBObjectParameter valueA = new BBObjectParameter(typeof(Enum));

		public BBObjectParameter valueB = new BBObjectParameter(typeof(Enum));

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
