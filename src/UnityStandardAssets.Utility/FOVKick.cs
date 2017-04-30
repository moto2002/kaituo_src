using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

namespace UnityStandardAssets.Utility
{
	[Serializable]
	public class FOVKick
	{
		public Camera Camera;

		[HideInInspector]
		public float originalFov;

		public float FOVIncrease = 3f;

		public float TimeToIncrease = 1f;

		public float TimeToDecrease = 1f;

		public AnimationCurve IncreaseCurve;

		public void Setup(Camera camera)
		{
			this.CheckStatus(camera);
			this.Camera = camera;
			this.originalFov = camera.fieldOfView;
		}

		private void CheckStatus(Camera camera)
		{
			if (camera == null)
			{
				throw new Exception("FOVKick camera is null, please supply the camera to the constructor");
			}
			if (this.IncreaseCurve == null)
			{
				throw new Exception("FOVKick Increase curve is null, please define the curve for the field of view kicks");
			}
		}

		public void ChangeCamera(Camera camera)
		{
			this.Camera = camera;
		}

		[DebuggerHidden]
		public IEnumerator FOVKickUp()
		{
			FOVKick.<FOVKickUp>c__Iterator4 <FOVKickUp>c__Iterator = new FOVKick.<FOVKickUp>c__Iterator4();
			<FOVKickUp>c__Iterator.<>f__this = this;
			return <FOVKickUp>c__Iterator;
		}

		[DebuggerHidden]
		public IEnumerator FOVKickDown()
		{
			FOVKick.<FOVKickDown>c__Iterator5 <FOVKickDown>c__Iterator = new FOVKick.<FOVKickDown>c__Iterator5();
			<FOVKickDown>c__Iterator.<>f__this = this;
			return <FOVKickDown>c__Iterator;
		}
	}
}
