using Assets.Scripts.Action.Core;
using ParadoxNotion.Design;
using System;

namespace Assets.Scripts.Action
{
	[Category("✫ GOG/Effect"), Name("Prefab effect control(UI)")]
	public class PlayUIEffectController : DevisableAction
	{
		public enum PrefabEffectControlType
		{
			Close,
			Pause,
			Resume
		}

		public PlayUIEffectController.PrefabEffectControlType ControlType;

		protected override void OnExecute()
		{
			PlayUIEffect lastPlay = PlayUIEffect.LastPlay;
			switch (this.ControlType)
			{
			case PlayUIEffectController.PrefabEffectControlType.Close:
				lastPlay.Close();
				break;
			case PlayUIEffectController.PrefabEffectControlType.Pause:
				lastPlay.Pause();
				break;
			case PlayUIEffectController.PrefabEffectControlType.Resume:
				lastPlay.Resume();
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			base.EndAction();
		}
	}
}
