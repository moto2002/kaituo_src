using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion.Design;
using System;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Blackboard")]
	public class SetEnum : ActionTask
	{
		[BlackboardOnly, RequiredField]
		public BBObjectParameter valueA = new BBObjectParameter(typeof(Enum));

		public BBObjectParameter valueB = new BBObjectParameter(typeof(Enum));

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
