using Assets.Scripts.Action.Core;
using Assets.Scripts.Tools.Component;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace Assets.Scripts.Action
{
	[Category("✫ GOG/Camera"), Name("Camera look at")]
	public class CameraLookAt : DevisableAction
	{
		public BBParameter<GameObject> LookAt;

		public Vector3 LookAtOffset;

		protected override void OnExecute()
		{
			Main3DCamera.Instance.LookAt(this.LookAt.value.transform, this.LookAtOffset);
			base.EndAction();
		}
	}
}
