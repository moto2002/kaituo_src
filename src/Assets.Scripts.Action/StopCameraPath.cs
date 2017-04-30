using Assets.Scripts.Action.Core;
using ParadoxNotion.Design;
using System;

namespace Assets.Scripts.Action
{
	[Category("obsolete/Camera"), Name("Stop camera path")]
	public class StopCameraPath : DevisableAction
	{
		protected override void OnExecute()
		{
			base.EndAction();
		}
	}
}
