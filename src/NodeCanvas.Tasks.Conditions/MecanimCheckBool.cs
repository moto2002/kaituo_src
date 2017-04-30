using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("Mecanim"), Name("Check Mecanim Bool")]
	public class MecanimCheckBool : ConditionTask<Animator>
	{
		[RequiredField]
		public BBParameter<string> parameter;

		public BBParameter<bool> value;

		protected override string info
		{
			get
			{
				return string.Concat(new object[]
				{
					"Mec.Bool ",
					this.parameter.ToString(),
					" == ",
					this.value
				});
			}
		}

		protected override bool OnCheck()
		{
			return base.agent.GetBool(this.parameter.value) == this.value.value;
		}
	}
}
