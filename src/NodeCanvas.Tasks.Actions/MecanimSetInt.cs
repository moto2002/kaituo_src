using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("Mecanim"), Name("Set Mecanim Int")]
	public class MecanimSetInt : ActionTask<Animator>
	{
		[RequiredField]
		public BBParameter<string> parameter;

		public BBParameter<int> setTo;

		protected override string info
		{
			get
			{
				return string.Concat(new object[]
				{
					"Mec.SetInt '",
					this.parameter,
					"' to ",
					this.setTo
				});
			}
		}

		protected override void OnExecute()
		{
			base.agent.SetInteger(this.parameter.value, this.setTo.value);
			base.EndAction();
		}
	}
}
