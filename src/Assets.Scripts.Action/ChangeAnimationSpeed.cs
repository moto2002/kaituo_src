using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;

namespace Assets.Scripts.Action
{
	[Category("✫ GOG/Animation"), Name("Change animation speed")]
	public class ChangeAnimationSpeed : ActionWithEndType
	{
		public BBParameter<RpgCharacter> Character;

		public BBParameter<float> Speed;

		protected override void OnExecute()
		{
			RpgCharacter value = this.Character.value;
			value.Animator.ChangeSpeed(this.Speed.value);
			base.EndAction();
		}
	}
}
