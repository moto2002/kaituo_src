using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Blackboard")]
	public class GetToString : ActionTask
	{
		[BlackboardOnly]
		public BBParameter<object> variable;

		[BlackboardOnly]
		public BBParameter<string> toString;

		protected override void OnExecute()
		{
			this.toString.value = (this.variable.isNull ? "NULL" : this.variable.value.ToString());
			base.EndAction();
		}
	}
}
