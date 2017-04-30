using Assets.Scripts.Action.Core;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;

namespace Assets.Scripts.Action
{
	[Category("✫ GOG/Animation"), Name("Pause|Resume animation")]
	public class PauseResumeCharacterAnimState : DevisableAction
	{
		public enum ChangeOperation
		{
			Pause,
			Resume
		}

		public BBParameter<RpgCharacter> Character;

		public PauseResumeCharacterAnimState.ChangeOperation Operation;

		protected override void OnExecute()
		{
			RpgCharacter value = this.Character.value;
			PauseResumeCharacterAnimState.ChangeOperation operation = this.Operation;
			if (operation != PauseResumeCharacterAnimState.ChangeOperation.Pause)
			{
				if (operation != PauseResumeCharacterAnimState.ChangeOperation.Resume)
				{
					throw new ArgumentOutOfRangeException();
				}
				value.Animator.ResumeAnim();
				base.EndAction();
			}
			else
			{
				value.Animator.PauseAnim();
				base.EndAction();
			}
		}
	}
}
