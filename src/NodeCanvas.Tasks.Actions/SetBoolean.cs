using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Blackboard"), Description("Set a blackboard boolean variable")]
	public class SetBoolean : ActionTask
	{
		public enum BoolSetModes
		{
			False,
			True,
			Toggle
		}

		[BlackboardOnly, RequiredField]
		public BBParameter<bool> boolVariable;

		public SetBoolean.BoolSetModes setTo = SetBoolean.BoolSetModes.True;

		protected override string info
		{
			get
			{
				if (this.setTo == SetBoolean.BoolSetModes.Toggle)
				{
					return "Toggle " + this.boolVariable.ToString();
				}
				return "Set " + this.boolVariable.ToString() + " to " + this.setTo.ToString();
			}
		}

		protected override void OnExecute()
		{
			if (this.setTo == SetBoolean.BoolSetModes.Toggle)
			{
				this.boolVariable.value = !this.boolVariable.value;
			}
			else
			{
				bool value = this.setTo == SetBoolean.BoolSetModes.True;
				this.boolVariable.value = value;
			}
			base.EndAction();
		}
	}
}
