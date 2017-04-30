using Assets.Scripts.Action.Core;
using Assets.Scripts.Tools.Sound;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;

namespace Assets.Scripts.Action
{
	[Category("✫ GOG/Sound"), Name("Play effect sound")]
	public class PlayEffectSound : DevisableAction
	{
		public BBParameter<string> EffectSound;

		public bool IgnoreTimeScale = true;

		protected override void OnExecute()
		{
			if (this.EffectSound != null && this.EffectSound.value != null)
			{
				BattleEffectSound.Play(this.EffectSound.value, this.IgnoreTimeScale);
			}
			base.EndAction();
		}
	}
}
