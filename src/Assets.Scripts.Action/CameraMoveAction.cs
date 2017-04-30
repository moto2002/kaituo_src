using Assets.Scripts.Action.Core;
using Assets.Scripts.Tools.Component;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace Assets.Scripts.Action
{
	[Category("✫ GOG/Camera"), Name("Move camera")]
	public class CameraMoveAction : DevisableAction
	{
		public static CameraMoveAction LastAction;

		public Vector3 MoveOffset;

		public float Time;

		public bool IgnoreTimeScale;

		public iTween.EaseType EaseType = iTween.EaseType.linear;

		public bool UseWorldCoordinate;

		public bool LockTarget;

		public BBParameter<GameObject> LookAt;

		public Vector3 LookAtOffset;

		private Func<float, float, float, float> easeFunction;

		private Vector3 startPosition;

		private Vector3 toPosition;

		private DateTime startDateTime;

		protected override void OnExecute()
		{
			CameraMoveAction.LastAction = this;
			if (this.IgnoreTimeScale)
			{
				this.startDateTime = DateTime.Now;
			}
			this.startPosition = Main3DCamera.Instance.Level1.localPosition;
			if (this.UseWorldCoordinate)
			{
				this.toPosition = this.startPosition + this.MoveOffset;
			}
			else
			{
				Vector3 b = Main3DCamera.Instance.Level1.right * this.MoveOffset.x;
				Vector3 b2 = Main3DCamera.Instance.Level1.up * this.MoveOffset.y;
				Vector3 b3 = Main3DCamera.Instance.Level1.forward * this.MoveOffset.z;
				this.toPosition = this.startPosition + b + b2 + b3;
			}
			this.easeFunction = iTween.GetEaseFunction(this.EaseType);
		}

		protected override void OnUpdate()
		{
			float num = this.GetRunTime();
			if (num > this.Time)
			{
				num = this.Time;
			}
			float x = this.easeFunction(this.startPosition.x, this.toPosition.x, num / this.Time);
			float y = this.easeFunction(this.startPosition.y, this.toPosition.y, num / this.Time);
			float z = this.easeFunction(this.startPosition.z, this.toPosition.z, num / this.Time);
			Main3DCamera.Instance.Level1.localPosition = new Vector3(x, y, z);
			if (this.LockTarget)
			{
				GameObject value = this.LookAt.value;
				Main3DCamera.Instance.LookAt(value.transform, this.LookAtOffset);
			}
			if (num >= this.Time)
			{
				Main3DCamera.Instance.Level1.localPosition = this.toPosition;
				this.Stop();
			}
		}

		public void Stop()
		{
			CameraMoveAction.LastAction = null;
			base.EndAction();
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
