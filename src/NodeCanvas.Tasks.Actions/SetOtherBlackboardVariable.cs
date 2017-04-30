using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;

namespace NodeCanvas.Tasks.Actions
{
	[Task.AgentTypeAttribute(typeof(Blackboard)), Category("✫ Blackboard"), Description("Use this to set a variable on any blackboard by overriding the agent")]
	public class SetOtherBlackboardVariable : ActionTask
	{
		[RequiredField]
		public BBParameter<string> targetVariableName;

		public BBParameter newValue;

		protected override string info
		{
			get
			{
				return string.Format("<b>{0}</b> = {1}", this.targetVariableName.ToString(), (this.newValue == null) ? string.Empty : this.newValue.ToString());
			}
		}

		protected override void OnExecute()
		{
			(base.agent as IBlackboard).SetValue(this.targetVariableName.value, this.newValue.value);
			base.EndAction();
		}
	}
}
