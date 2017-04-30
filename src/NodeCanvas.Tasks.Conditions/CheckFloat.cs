using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using System;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("✫ Blackboard")]
	public class CheckFloat : ConditionTask
	{
		[BlackboardOnly]
		public BBParameter<float> valueA;

		public CompareMethod checkType;

		public BBParameter<float> valueB;

		[SliderField(0f, 0.1f)]
		public float differenceThreshold = 0.05f;

		protected override string info
		{
			get
			{
				return this.valueA + OperationTools.GetCompareString(this.checkType) + this.valueB;
			}
		}

		protected override bool OnCheck()
		{
			return OperationTools.Compare(this.valueA.value, this.valueB.value, this.checkType, this.differenceThreshold);
		}
	}
}
