using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("Mecanim"), Name("Set Mecanim Bool")]
	public class MecanimSetBool : ActionTask<Animator>
	{
		[RequiredField]
		public BBParameter<string> parameter;

		public BBParameter<bool> setTo;

		protected override string info
		{
			get
			{
				return string.Concat(new object[]
				{
					"Mec.SetBool '",
					this.parameter.ToString(),
					"' to ",
					this.setTo
				});
			}
		}

		protected override void OnExecute()
		{
			base.agent.SetBool(this.parameter.value, this.setTo.value);
			base.EndAction(new bool?(true));
		}
	}
}
