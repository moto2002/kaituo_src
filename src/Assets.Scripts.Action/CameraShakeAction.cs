using Assets.Scripts.Action.Core;
using Assets.Scripts.Tools.Component;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace Assets.Scripts.Action
{
	[Category("✫ GOG/Camera"), Name("Shake the camera")]
	public class CameraShakeAction : DevisableAction
	{
		public AnimationCurve CurveX;

		public AnimationCurve CurveY;

		public bool IgnoreTimeScale;

		private Transform camera;

		private float shakeTime;

		private Vector3 originalPos;

		private DateTime startDataTime;

		private float RunTime
		{
			get
			{
				if (this.IgnoreTimeScale)
				{
					return (float)(DateTime.Now - this.startDataTime).TotalSeconds;
				}
				return base.elapsedTime;
			}
		}

		protected override void OnExecute()
		{
			if (this.IgnoreTimeScale)
			{
				this.startDataTime = DateTime.Now;
			}
			if (this.CurveX.keys.Length < 2)
			{
				base.EndAction();
			}
			else
			{
				this.camera = Main3DCamera.Instance.Level3;
				this.originalPos = this.camera.localPosition;
				this.shakeTime = this.CurveX.keys[this.CurveX.keys.Length - 1].time;
			}
		}

		protected override void OnUpdate()
		{
			float runTime = this.RunTime;
			if (this.shakeTime > runTime)
			{
				float d = this.CurveX.Evaluate(runTime);
				float d2 = this.CurveY.Evaluate(runTime);
				this.camera.localPosition = this.originalPos + this.camera.right * d + this.camera.up * d2;
			}
			else
			{
				this.camera.transform.localPosition = this.originalPos;
				base.EndAction();
			}
		}
	}
}
