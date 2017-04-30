using Assets.Scripts.Action.Core;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;

namespace Assets.Scripts.Action
{
	[Category("✫ GOG/Animation"), Name("Stop character animation")]
	public class StopCharacterAnimation : DevisableAction
	{
		public BBParameter<RpgCharacter> Character;

		protected override void OnExecute()
		{
			RpgCharacter value = this.Character.value;
			value.Animator.StopAnim();
			base.EndAction();
		}
	}
}
