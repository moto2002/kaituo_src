using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Blackboard"), Description("Set a blackboard Vector3 variable")]
	public class SetVector3 : ActionTask
	{
		[BlackboardOnly]
		public BBParameter<Vector3> valueA;

		public OperationMethod operation;

		public BBParameter<Vector3> valueB;

		protected override string info
		{
			get
			{
				return this.valueA + OperationTools.GetOperationString(this.operation) + this.valueB;
			}
		}

		protected override void OnExecute()
		{
			this.valueA.value = OperationTools.Operate(this.valueA.value, this.valueB.value, this.operation);
			base.EndAction();
		}
	}
}
