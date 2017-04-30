using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using System;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("✫ Blackboard")]
	public class CheckInt : ConditionTask
	{
		[BlackboardOnly]
		public BBParameter<int> valueA;

		public CompareMethod checkType;

		public BBParameter<int> valueB;

		protected override string info
		{
			get
			{
				return this.valueA + OperationTools.GetCompareString(this.checkType) + this.valueB;
			}
		}

		protected override bool OnCheck()
		{
			return OperationTools.Compare(this.valueA.value, this.valueB.value, this.checkType);
		}
	}
}
