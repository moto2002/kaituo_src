using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Blackboard"), Description("Set a blackboard boolean variable at random between min and max value")]
	public class SetBooleanRandom : ActionTask
	{
		[BlackboardOnly]
		public BBParameter<bool> boolVariable;

		protected override string info
		{
			get
			{
				return "Set " + this.boolVariable + " Random";
			}
		}

		protected override void OnExecute()
		{
			this.boolVariable.value = (UnityEngine.Random.Range(0, 2) != 0);
			base.EndAction();
		}
	}
}
