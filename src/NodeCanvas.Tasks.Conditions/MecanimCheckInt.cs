using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("Mecanim"), Name("Check Mecanim Int")]
	public class MecanimCheckInt : ConditionTask<Animator>
	{
		[RequiredField]
		public BBParameter<string> parameter;

		public CompareMethod comparison;

		public BBParameter<int> value;

		protected override string info
		{
			get
			{
				return string.Concat(new object[]
				{
					"Mec.Int ",
					this.parameter.ToString(),
					OperationTools.GetCompareString(this.comparison),
					this.value
				});
			}
		}

		protected override bool OnCheck()
		{
			return OperationTools.Compare(base.agent.GetInteger(this.parameter.value), this.value.value, this.comparison);
		}
	}
}
