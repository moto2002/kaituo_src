using Assets.Scripts.Action.Core;
using ParadoxNotion.Design;
using System;

namespace Assets.Scripts.Action
{
	[Category("obsolete/Camera"), Name("Pause camera path")]
	public class PauseCameraPath : DevisableAction
	{
		protected override void OnExecute()
		{
			base.EndAction();
		}
	}
}
