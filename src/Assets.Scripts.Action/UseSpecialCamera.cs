using Assets.Migration.Scripts.Action;
using Assets.Scripts.Action.Core;
using Assets.Scripts.Tools.Component;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace Assets.Scripts.Action
{
	[Category("✫ GOG/Camera"), Name("Use special camera position")]
	public class UseSpecialCamera : DevisableAction
	{
		public AnchorPointType AnchorType;

		public BBParameter<Transform> CameraPosition;

		public BBParameter<GameObject> CameraPositionGo;

		protected override void OnExecute()
		{
			Transform level = Main3DCamera.Instance.Level1;
			level.parent = this.AnchorType.GetTransform(this.CameraPosition, this.CameraPositionGo);
			level.localPosition = Vector3.zero;
			level.localRotation = Quaternion.identity;
			level.parent = null;
			base.EndAction();
		}
	}
}
