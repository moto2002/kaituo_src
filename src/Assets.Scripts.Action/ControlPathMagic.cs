using Assets.Scripts.Action.Core;
using ParadoxNotion.Design;
using System;

namespace Assets.Scripts.Action
{
	[Category("✫ GOG/PathMagic"), Name("Control Path Magic")]
	public class ControlPathMagic : DevisableAction
	{
		public PathControlType Control;

		public PathControlPathType ControlPath;

		public int PlayId;

		protected override void OnExecute()
		{
			PlayPathMagic playPathMagic = null;
			if (this.ControlPath == PathControlPathType.Current)
			{
				playPathMagic = PlayPathMagic.LastPlayPath;
			}
			else if (this.ControlPath == PathControlPathType.PlayId)
			{
				PlayPathMagic.PlayingPath.TryGetValue(this.PlayId, out playPathMagic);
			}
			if (playPathMagic != null)
			{
				switch (this.Control)
				{
				case PathControlType.Pause:
					playPathMagic.Pause();
					break;
				case PathControlType.Resume:
					playPathMagic.Resume();
					break;
				case PathControlType.Stop:
					playPathMagic.Stop();
					break;
				default:
					throw new ArgumentOutOfRangeException();
				}
			}
			base.EndAction();
		}
	}
}
