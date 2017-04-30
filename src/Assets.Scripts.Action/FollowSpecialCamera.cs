using Assets.Migration.Scripts.Action;
using Assets.Scripts.Action.Core;
using Assets.Scripts.Tools.Component;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace Assets.Scripts.Action
{
	[Category("✫ GOG/Camera"), Name("Follow special camera position")]
	public class FollowSpecialCamera : DevisableAction
	{
		public AnchorPointType AnchorType;

		public BBParameter<Transform> CameraPosition;

		public BBParameter<GameObject> CameraPositionGo;

		private DateTime startDataTime;

		protected override void OnExecute()
		{
			Transform level = Main3DCamera.Instance.Level1;
			level.parent = this.AnchorType.GetTransform(this.CameraPosition, this.CameraPositionGo);
			level.localPosition = Vector3.zero;
			level.localRotation = Quaternion.identity;
			level.parent = null;
			TargetFollowTool targetFollowTool = level.gameObject.AddComponent<TargetFollowTool>();
			targetFollowTool.Target = this.AnchorType.GetTransform(this.CameraPosition, this.CameraPositionGo).gameObject;
			base.EndAction();
		}
	}
}
