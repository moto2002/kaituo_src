using Assets.Scripts.Action.Core;
using Assets.Scripts.Tools.Component;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace Assets.Scripts.Action
{
	[Category("obsolete/Camera"), Name("Rotate Camera self")]
	public class CameraRotateSelfAction : DevisableAction
	{
		public Vector3 Rotate;

		public float Time;

		public bool IgnoreTimeScale;

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
			iTween.RotateAdd(Main3DCamera.Instance.Level1.gameObject, iTween.Hash(new object[]
			{
				"time",
				this.Time,
				"x",
				this.Rotate.x,
				"y",
				this.Rotate.y,
				"z",
				this.Rotate.z,
				"ignoretimescale",
				this.IgnoreTimeScale
			}));
		}

		protected override void OnUpdate()
		{
			float runTime = this.RunTime;
			if (this.Time <= runTime)
			{
				base.EndAction();
			}
		}
	}
}
