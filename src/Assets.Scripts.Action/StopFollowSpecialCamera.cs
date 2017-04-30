using Assets.Migration.Scripts.Action;
using Assets.Scripts.Action.Core;
using Assets.Scripts.Tools.Component;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace Assets.Scripts.Action
{
	[Category("✫ GOG/Camera"), Name("Stop follow special camera position")]
	public class StopFollowSpecialCamera : DevisableAction
	{
		protected override void OnExecute()
		{
			Transform level = Main3DCamera.Instance.Level1;
			level.parent = null;
			TargetFollowTool component = level.GetComponent<TargetFollowTool>();
			if (component != null)
			{
				level.GetComponent<TargetFollowTool>().Stop();
			}
			base.EndAction();
		}
	}
}
