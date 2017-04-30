using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;

namespace Assets.Scripts.Action.Blackboard
{
	[Category("obsolete/Blackboard"), Name("Set character by id")]
	public class SetCharacterById : ActionTask
	{
		public BBParameter<int> InstanceId;

		public BBParameter<RpgCharacter> Target;

		protected override void OnExecute()
		{
			if (this.Target == null)
			{
				base.EndAction();
				return;
			}
			string varName = string.Format("Unit_{0}", this.InstanceId.value);
			this.Target.value = base.blackboard.GetValue<RpgCharacter>(varName);
			base.EndAction();
		}
	}
}
