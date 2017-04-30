using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using System;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Blackboard"), Description("Set a blackboard integer variable"), Name("Set Integer")]
	public class SetInt : ActionTask
	{
		[BlackboardOnly]
		public BBParameter<int> valueA;

		public OperationMethod Operation;

		public BBParameter<int> valueB;

		protected override string info
		{
			get
			{
				return this.valueA + OperationTools.GetOperationString(this.Operation) + this.valueB;
			}
		}

		protected override void OnExecute()
		{
			this.valueA.value = OperationTools.Operate(this.valueA.value, this.valueB.value, this.Operation);
			base.EndAction();
		}
	}
}
