using Assets.Scripts.Action.Core;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Action
{
	[Category("obsolete/Animation"), Name("Play character attack animation")]
	public class PlayCharacterAttackAnimation : DevisableAction
	{
		public BBParameter<RpgCharacter> Character;

		public BBParameter<List<RpgCharacter>> TargetCharacter;

		public string AnimName;

		protected override void OnExecute()
		{
			DebugConsole.Log(new object[]
			{
				"AttackAnimation",
				this.AnimName
			});
			RpgCharacter value = this.Character.value;
			AnimationClip animationClip = value.Animator.Play(this.AnimName);
			if (animationClip.wrapMode != WrapMode.Loop)
			{
				value.OnAnimEndSignal.AddEventListener(new Action<CharacterAnimator>(this.OnAnimEndHandler));
				value.OnAttackSignal.AddEventListener(new Action<RpgCharacter>(this.OnAttackHandler));
				return;
			}
			throw new Exception("can't play loop animation on this aciton");
		}

		private void OnAttackHandler(RpgCharacter obj)
		{
			if (this.TargetCharacter != null)
			{
				List<RpgCharacter> value = this.TargetCharacter.value;
				if (value != null)
				{
					for (int i = 0; i < value.Count; i++)
					{
						RpgCharacter rpgCharacter = value[i];
						rpgCharacter.Animator.Play("Hit");
					}
				}
			}
		}

		private void OnAnimEndHandler(CharacterAnimator obj)
		{
			RpgCharacter value = this.Character.value;
			value.OnAttackSignal.RemoveEventListener(new Action<RpgCharacter>(this.OnAttackHandler));
			value.OnAnimEndSignal.RemoveEventListener(new Action<CharacterAnimator>(this.OnAnimEndHandler));
			base.EndAction();
		}
	}
}
