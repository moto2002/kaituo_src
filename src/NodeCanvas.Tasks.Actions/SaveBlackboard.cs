using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Blackboard"), Description("Saves the blackboard variables in the provided key and to be loaded later on")]
	public class SaveBlackboard : ActionTask<Blackboard>
	{
		[RequiredField]
		public BBParameter<string> saveKey;

		protected override string info
		{
			get
			{
				return string.Format("Save Blackboard [{0}]", this.saveKey.ToString());
			}
		}

		protected override void OnExecute()
		{
			base.agent.Save(this.saveKey.value);
			base.EndAction();
		}
	}
}
