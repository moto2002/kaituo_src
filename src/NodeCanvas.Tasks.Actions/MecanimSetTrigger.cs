using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("Mecanim"), Name("Set Mecanim Trigger")]
	public class MecanimSetTrigger : ActionTask<Animator>
	{
		[RequiredField]
		public BBParameter<string> parameter;

		protected override string info
		{
			get
			{
				return "Mec.SetTrigger " + this.parameter;
			}
		}

		protected override void OnExecute()
		{
			base.agent.SetTrigger(this.parameter.value);
			base.EndAction();
		}
	}
}
