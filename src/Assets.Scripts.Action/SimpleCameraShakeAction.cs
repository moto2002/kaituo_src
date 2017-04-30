using Assets.Scripts.Action.Core;
using Assets.Scripts.Tools.Component;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace Assets.Scripts.Action
{
	[Category("✫ GOG/Camera"), Name("Shake the camera(Simple)")]
	public class SimpleCameraShakeAction : DevisableAction
	{
		public float XAmplitude = 0.12f;

		public float YAmplitude = 0.9f;

		public float XFrequency = 100f;

		public float YFrequency = 120f;

		public float ShakeTime = 1f;

		public bool IgnoreTimeScale;

		private Transform camera;

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
			this.camera = Main3DCamera.Instance.Level3;
			this.originalPos = this.camera.localPosition;
		}

		protected override void OnUpdate()
		{
			float runTime = this.RunTime;
			if (this.ShakeTime > runTime)
			{
				float d = Mathf.Sin(runTime / 3.14159274f * this.XFrequency) * this.XAmplitude;
				float d2 = Mathf.Sin(runTime / 3.14159274f * this.YFrequency) * this.YAmplitude;
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
