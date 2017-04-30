using Assets.Scripts.Action.Core;
using Assets.Scripts.Tools.Component;
using ParadoxNotion.Design;
using System;

namespace Assets.Scripts.Action
{
	[Category("✫ GOG/Camera"), Name("Change camera FOV")]
	public class CameraFOVAction : DevisableAction
	{
		public float ToFOV;

		public float Time;

		public bool IgnoreTimeScale;

		public iTween.EaseType EaseType = iTween.EaseType.linear;

		private Func<float, float, float, float> easeFunction;

		private float startFieldOfView;

		private DateTime startDateTime;

		protected override void OnExecute()
		{
			if (this.IgnoreTimeScale)
			{
				this.startDateTime = DateTime.Now;
			}
			this.startFieldOfView = Main3DCamera.Instance.Camera.fieldOfView;
			this.easeFunction = iTween.GetEaseFunction(this.EaseType);
		}

		protected override void OnUpdate()
		{
			float num = this.GetRunTime();
			if (num > this.Time)
			{
				num = this.Time;
			}
			float fieldOfView = this.easeFunction(this.startFieldOfView, this.ToFOV, num / this.Time);
			Main3DCamera.Instance.Camera.fieldOfView = fieldOfView;
			if (num >= this.Time)
			{
				Main3DCamera.Instance.Camera.fieldOfView = this.ToFOV;
				base.EndAction();
			}
		}

		private float GetRunTime()
		{
			if (this.IgnoreTimeScale)
			{
				return (float)(DateTime.Now - this.startDateTime).TotalSeconds;
			}
			return base.elapsedTime;
		}
	}
}
