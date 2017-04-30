using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Blackboard"), Description("Set a blackboard float variable at random between min and max value")]
	public class SetFloatRandom : ActionTask
	{
		public BBParameter<float> minValue;

		public BBParameter<float> maxValue;

		[BlackboardOnly]
		public BBParameter<float> floatVariable;

		protected override string info
		{
			get
			{
				return string.Concat(new object[]
				{
					"Set ",
					this.floatVariable,
					" Random(",
					this.minValue,
					", ",
					this.maxValue,
					")"
				});
			}
		}

		protected override void OnExecute()
		{
			this.floatVariable.value = UnityEngine.Random.Range(this.minValue.value, this.maxValue.value);
			base.EndAction();
		}
	}
}
