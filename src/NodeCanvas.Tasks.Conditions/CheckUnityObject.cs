using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("✫ Blackboard")]
	public class CheckUnityObject : ConditionTask
	{
		[BlackboardOnly]
		public BBParameter<UnityEngine.Object> valueA;

		public BBParameter<UnityEngine.Object> valueB;

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
