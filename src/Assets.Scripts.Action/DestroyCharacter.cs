using Assets.Migration.Scripts.Node.Loader;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;

namespace Assets.Scripts.Action
{
	[Category("obsolete/Character"), Name("Destroy character")]
	public class DestroyCharacter : ActionWithEndType
	{
		public BBParameter<RpgCharacter> Character;

		protected override void OnExecute()
		{
			RpgCharacter value = this.Character.value;
			if (value.InstanceId > 0)
			{
				string blackboardCharacterMark = NcrCharacterLoader.GetBlackboardCharacterMark(value.InstanceId);
				base.blackboard.variables.Remove(blackboardCharacterMark);
			}
			base.EndAction();
		}
	}
}
