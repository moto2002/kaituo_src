using Assets.Scripts.Action.Core;
using Assets.Scripts.Tools.Component;
using ParadoxNotion.Design;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Action
{
	[Category("✫ GOG/Camera"), Name("Change camera layer")]
	public class ChangeCameraLayer : DevisableAction
	{
		public enum ChangeCameraLayerEnum
		{
			ToLayer,
			Recover
		}

		private static Dictionary<string, LayerMask> lastCameraLayerMasks = new Dictionary<string, LayerMask>();

		public string CameraName;

		public ChangeCameraLayer.ChangeCameraLayerEnum Type;

		public LayerMask Mask;

		protected override void OnExecute()
		{
			Camera camera = Main3DCamera.Instance.GetCamera(this.CameraName);
			if (this.Type == ChangeCameraLayer.ChangeCameraLayerEnum.ToLayer)
			{
				ChangeCameraLayer.lastCameraLayerMasks[this.CameraName] = camera.cullingMask;
				camera.cullingMask = this.Mask;
			}
			else if (this.Type == ChangeCameraLayer.ChangeCameraLayerEnum.Recover)
			{
				camera.cullingMask = ChangeCameraLayer.lastCameraLayerMasks[this.CameraName];
			}
		}
	}
}
