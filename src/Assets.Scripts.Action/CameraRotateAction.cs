using Assets.Scripts.Action.Core;
using Assets.Scripts.Tools.Component;
using Assets.Tools.Script.Go;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace Assets.Scripts.Action
{
	[Category("✫ GOG/Camera"), Name("Rotate camera")]
	public class CameraRotateAction : DevisableAction
	{
		public enum CameraRotateActionType
		{
			CurrPosition,
			CirclePosition
		}

		public static CameraRotateAction LastAction;

		public CameraRotateAction.CameraRotateActionType Type;

		public BBParameter<GameObject> Center;

		public Vector3 CenterOffset;

		public float Circle;

		public float Radius;

		public Vector3 Orientation;

		public float MoveToCenterDistance;

		public float Time;

		public bool IgnoreTimeScale;

		public iTween.EaseType EaseType = iTween.EaseType.linear;

		public bool IsPlayForward;

		public bool LockTarget;

		public BBParameter<GameObject> LookAt;

		public Vector3 LookAtOffset;

		private float moveToCenterSpeed;

		private Func<float, float, float, float> easeFunction;

		private DateTime startDateTime;

		private float toRotate;

		private GameObject cameraAgent;

		private GameObject cameraAgent2;

		protected override void OnExecute()
		{
			this.moveToCenterSpeed = this.MoveToCenterDistance / this.Time;
			CameraRotateAction.LastAction = this;
			this.cameraAgent = ParasiticComponent.GetSecondaryHost("CameraRotateActioncAgent");
			this.cameraAgent.transform.parent = this.Center.value.transform;
			this.cameraAgent.transform.localPosition = this.CenterOffset;
			this.cameraAgent.transform.localRotation = Quaternion.Euler(this.Orientation);
			if (this.cameraAgent.transform.childCount == 0)
			{
				this.cameraAgent2 = new GameObject();
				this.cameraAgent2.name = "CameraRotateActioncAgent2";
				this.cameraAgent2.transform.parent = this.cameraAgent.transform;
			}
			else
			{
				this.cameraAgent2 = this.cameraAgent.transform.GetChild(0).gameObject;
			}
			this.cameraAgent2.transform.localPosition = Vector3.zero;
			this.cameraAgent2.transform.localRotation = Quaternion.identity;
			if (this.Type == CameraRotateAction.CameraRotateActionType.CurrPosition)
			{
				this.Orientation = Vector3.zero;
				Vector3 up = this.cameraAgent2.transform.up;
				this.cameraAgent2.transform.localRotation = Quaternion.identity;
				Vector3 position = Main3DCamera.Instance.Level1.position;
				Vector3 position2 = this.Center.value.transform.position;
				Vector3 vector = this.CalPlaneLineIntersectPoint(up, position, up, position2);
				this.Radius = Vector3.Distance(position, vector);
				this.cameraAgent.transform.position = vector;
				this.cameraAgent.transform.localRotation = Quaternion.Euler(this.Orientation);
				this.cameraAgent.transform.LookAt(Main3DCamera.Instance.Level1, this.cameraAgent.transform.up);
				this.cameraAgent.transform.localRotation = Quaternion.Euler(this.cameraAgent.transform.localRotation.eulerAngles + new Vector3(0f, -90f, 0f));
				this.cameraAgent2.transform.localPosition = Vector3.zero;
				this.cameraAgent2.transform.localRotation = Quaternion.identity;
			}
			this.toRotate = (float)((!this.IsPlayForward) ? -1 : 1) * this.Circle * 360f;
			this.cameraAgent2.transform.localRotation = Quaternion.identity;
			Vector3 position3 = this.cameraAgent2.transform.right * this.Radius + this.cameraAgent2.transform.position;
			Main3DCamera.Instance.Level1.position = position3;
			if (this.LockTarget)
			{
				GameObject value = this.LookAt.value;
				Main3DCamera.Instance.LookAt(value.transform, this.LookAtOffset);
			}
			if (this.IgnoreTimeScale)
			{
				this.startDateTime = DateTime.Now;
			}
			this.easeFunction = iTween.GetEaseFunction(this.EaseType);
		}

		private Vector3 CalPlaneLineIntersectPoint(Vector3 planeVector, Vector3 planePoint, Vector3 lineVector, Vector3 linePoint)
		{
			Vector3 zero = Vector3.zero;
			float x = planeVector.x;
			float y = planeVector.y;
			float z = planeVector.z;
			float x2 = planePoint.x;
			float y2 = planePoint.y;
			float z2 = planePoint.z;
			float x3 = lineVector.x;
			float y3 = lineVector.y;
			float z3 = lineVector.z;
			float x4 = linePoint.x;
			float y4 = linePoint.y;
			float z4 = linePoint.z;
			float num = x3 * x + y3 * y + z3 * z;
			if (num == 0f)
			{
				zero = Vector3.zero;
			}
			else
			{
				float num2 = ((x2 - x4) * x + (y2 - y4) * y + (z2 - z4) * z) / num;
				zero.x = x4 + x3 * num2;
				zero.y = y4 + y3 * num2;
				zero.z = z4 + z3 * num2;
			}
			return zero;
		}

		protected override void OnUpdate()
		{
			if (this.easeFunction == null)
			{
				return;
			}
			float num = this.GetRunTime();
			if (num > this.Time)
			{
				num = this.Time;
			}
			float y = this.easeFunction(0f, this.toRotate, num / this.Time);
			this.cameraAgent2.transform.localRotation = Quaternion.Euler(new Vector3(0f, y, 0f));
			Vector3 position = this.cameraAgent2.transform.right * (this.Radius - this.moveToCenterSpeed * num) + this.cameraAgent2.transform.position;
			Main3DCamera.Instance.Level1.position = position;
			if (this.LockTarget)
			{
				GameObject value = this.LookAt.value;
				Main3DCamera.Instance.LookAt(value.transform, this.LookAtOffset);
			}
			if (num >= this.Time)
			{
				this.cameraAgent2.transform.localRotation = Quaternion.Euler(new Vector3(0f, this.toRotate, 0f));
				position = this.cameraAgent2.transform.right * (this.Radius - this.moveToCenterSpeed * num) + this.cameraAgent2.transform.position;
				Main3DCamera.Instance.Level1.position = position;
				this.cameraAgent.transform.parent = ParasiticComponent.parasiteHost.transform;
				this.Stop();
			}
		}

		public void Stop()
		{
			CameraRotateAction.LastAction = null;
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
