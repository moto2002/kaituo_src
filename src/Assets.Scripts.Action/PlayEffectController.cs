using Assets.Scripts.Action.Core;
using ParadoxNotion.Design;
using System;

namespace Assets.Scripts.Action
{
	[Category("✫ GOG/Effect"), Name("Prefab effect control")]
	public class PlayEffectController : DevisableAction
	{
		public enum PrefabEffectControlType
		{
			Close,
			Pause,
			Resume
		}

		public PlayEffectController.PrefabEffectControlType ControlType;

		protected override void OnExecute()
		{
			PlayEffect lastPlay = PlayEffect.LastPlay;
			switch (this.ControlType)
			{
			case PlayEffectController.PrefabEffectControlType.Close:
				lastPlay.Close();
				break;
			case PlayEffectController.PrefabEffectControlType.Pause:
				lastPlay.Pause();
				break;
			case PlayEffectController.PrefabEffectControlType.Resume:
				lastPlay.Resume();
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			base.EndAction();
		}
	}
}
