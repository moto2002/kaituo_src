using Assets.Scripts.Action.Core;
using Assets.Scripts.Tools.Component;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace Assets.Scripts.Action
{
	[Category("obsolete/Camera"), Name("Use general camera")]
	public class UseGeneralCamera : DevisableAction
	{
		protected override void OnExecute()
		{
			Transform level = Main3DCamera.Instance.Level1;
			level.parent = null;
			base.EndAction();
		}
	}
}
