using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("Mecanim"), Name("Check Mecanim Float")]
	public class MecanimCheckFloat : ConditionTask<Animator>
	{
		[RequiredField]
		public BBParameter<string> parameter;

		public CompareMethod comparison;

		public BBParameter<float> value;

		protected override string info
		{
			get
			{
				return string.Concat(new object[]
				{
					"Mec.Float ",
					this.parameter.ToString(),
					OperationTools.GetCompareString(this.comparison),
					this.value
				});
			}
		}

		protected override bool OnCheck()
		{
			return OperationTools.Compare(base.agent.GetFloat(this.parameter.value), this.value.value, this.comparison, 0.1f);
		}
	}
}
