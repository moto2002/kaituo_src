using Assets.Scripts.Action.Core;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;
using XQ.Framework.Utility.Debug;

namespace Assets.Scripts.Action
{
	[Category("✫ GOG/Animation"), Name("Play character animation")]
	public class PlayCharacterAnimation : DevisableAction
	{
		public BBParameter<RpgCharacter> Character;

		public string AnimName;

		private RpgCharacter lastCharacter;

		private AnimationClip currClip;

		protected override void OnExecute()
		{
			try
			{
				RpgCharacter value = this.Character.value;
				this.currClip = value.Animator.Play(this.AnimName);
				if (this.currClip.wrapMode != WrapMode.Loop)
				{
					this.lastCharacter = value;
					value.OnAnimEndSignal.AddEventListener(new Action<CharacterAnimator>(this.OnAnimEndHandler));
				}
				else
				{
					this.lastCharacter = null;
					this.currClip = null;
					base.EndAction();
				}
			}
			catch (Exception ex)
			{
				RpgCharacter value2 = this.Character.value;
				if (value2 == null)
				{
					throw new ArgumentNullException(string.Format("character{0}播放失败 {1}", this.AnimName, ex));
				}
				UDebug.Debug(ex);
				throw new Exception(string.Format("{0}:{1}播放失败 {2}", value2.name, this.AnimName, ex));
			}
		}

		private void OnAnimEndHandler(CharacterAnimator obj)
		{
			if (this.lastCharacter != null)
			{
				this.lastCharacter.OnAnimEndSignal.RemoveEventListener(new Action<CharacterAnimator>(this.OnAnimEndHandler));
				this.lastCharacter = null;
				this.currClip = null;
			}
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
