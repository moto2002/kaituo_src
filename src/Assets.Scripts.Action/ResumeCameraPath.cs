using Assets.Scripts.Action.Core;
using ParadoxNotion.Design;
using System;

namespace Assets.Scripts.Action
{
	[Category("obsolete/Camera"), Name("Resume camera path")]
	public class ResumeCameraPath : DevisableAction
	{
		protected override void OnExecute()
		{
			base.EndAction();
		}
	}
}
