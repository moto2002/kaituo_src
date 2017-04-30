using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Blackboard")]
	public class SetVariable<T> : ActionTask
	{
		[BlackboardOnly]
		public BBParameter<T> valueA;

		public BBParameter<T> valueB;

		protected override string info
		{
			get
			{
				return this.valueA + " = " + this.valueB;
			}
		}

		protected override void OnExecute()
		{
			this.valueA.value = this.valueB.value;
			base.EndAction();
		}
	}
}
