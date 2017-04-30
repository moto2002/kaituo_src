using Assets.Scripts.Action.Core;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace Assets.Scripts.Action
{
	[Category("✫ GOG/Animation"), Name("Play animation(Advance)")]
	public class PlayCharacterAnimationAdvance : DevisableAction
	{
		public enum PlayType
		{
			Play,
			PlayTo,
			PlayBetween,
			GotoAndPlay,
			GotoAndStop
		}

		public BBParameter<RpgCharacter> Character;

		public BBParameter<string> AnimName;

		public PlayCharacterAnimationAdvance.PlayType AnimPlayType;

		public float From;

		public float To;

		private RpgCharacter lastCharacter;

		private AnimationClip currClip;

		protected override void OnExecute()
		{
			this.lastCharacter = this.Character.value;
			switch (this.AnimPlayType)
			{
			case PlayCharacterAnimationAdvance.PlayType.Play:
				this.currClip = this.lastCharacter.Animator.Play(this.AnimName.value);
				break;
			case PlayCharacterAnimationAdvance.PlayType.PlayTo:
				this.currClip = this.lastCharacter.Animator.PlayTo(this.AnimName.value, this.To);
				break;
			case PlayCharacterAnimationAdvance.PlayType.PlayBetween:
				this.currClip = this.lastCharacter.Animator.PlayBetween(this.AnimName.value, this.From, this.To);
				break;
			case PlayCharacterAnimationAdvance.PlayType.GotoAndPlay:
				this.currClip = this.lastCharacter.Animator.GotoAndPlay(this.AnimName.value, this.To);
				break;
			case PlayCharacterAnimationAdvance.PlayType.GotoAndStop:
				this.currClip = this.lastCharacter.Animator.GotoAndStop(this.AnimName.value, this.To);
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			if (this.currClip != null && this.currClip.wrapMode != WrapMode.Loop)
			{
				this.lastCharacter.OnAnimEndSignal.AddEventListener(new Action<CharacterAnimator>(this.OnAnimEndHandler));
			}
			else
			{
				this.currClip = null;
				this.lastCharacter = null;
				base.EndAction();
			}
		}

		private void OnAnimEndHandler(CharacterAnimator obj)
		{
			RpgCharacter value = this.Character.value;
			value.OnAnimEndSignal.RemoveEventListener(new Action<CharacterAnimator>(this.OnAnimEndHandler));
			this.currClip = null;
			this.lastCharacter = null;
			base.EndAction();
		}

		protected override void OnUpdate()
		{
			if (this.lastCharacter != null && this.lastCharacter.Animator.LastAnimClip != this.currClip)
			{
				this.lastCharacter.OnAnimEndSignal.RemoveEventListener(new Action<CharacterAnimator>(this.OnAnimEndHandler));
				this.lastCharacter = null;
				this.currClip = null;
				base.EndAction();
			}
		}
	}
}
