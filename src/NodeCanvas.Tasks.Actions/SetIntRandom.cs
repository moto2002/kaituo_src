using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Blackboard"), Description("Set a blackboard integer variable at random between min and max value"), Name("Set Integer Random")]
	public class SetIntRandom : ActionTask
	{
		public BBParameter<int> minValue;

		public BBParameter<int> maxValue;

		[BlackboardOnly]
		public BBParameter<int> intVariable;

		protected override string info
		{
			get
			{
				return string.Concat(new object[]
				{
					"Set ",
					this.intVariable,
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
			this.intVariable.value = UnityEngine.Random.Range(this.minValue.value, this.maxValue.value + 1);
			base.EndAction();
		}
	}
}
