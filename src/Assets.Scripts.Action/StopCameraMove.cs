using Assets.Scripts.Action.Core;
using ParadoxNotion.Design;
using System;

namespace Assets.Scripts.Action
{
	[Category("✫ GOG/Camera"), Name("Stop camera move")]
	public class StopCameraMove : DevisableAction
	{
		protected override void OnExecute()
		{
			if (CameraRotateAction.LastAction != null)
			{
				CameraRotateAction.LastAction.Stop();
			}
			if (CameraMoveAction.LastAction != null)
			{
				CameraMoveAction.LastAction.Stop();
			}
			base.EndAction();
		}
	}
}
