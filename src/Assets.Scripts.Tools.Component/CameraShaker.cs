using System;
using UnityEngine;

namespace Assets.Scripts.Tools.Component
{
	public class CameraShaker : MonoBehaviour
	{
		public AnimationCurve CurveX;

		public AnimationCurve CurveY;

		public Transform CameraTransform;

		public float Swing;

		public string ShakerName;

		private float shakeTime;

		private Action onEndCallback;

		private Vector3 originalPos;

		private float startTime;

		public static CameraShaker FindShaker(GameObject obj, string shakerName)
		{
			for (int i = 0; i < obj.GetComponents<CameraShaker>().Length; i++)
			{
				CameraShaker cameraShaker = obj.GetComponents<CameraShaker>()[i];
				if (cameraShaker.ShakerName == shakerName)
				{
					return cameraShaker;
				}
			}
			return null;
		}

		public static void CopyShaker(GameObject from, GameObject to)
		{
			CameraShaker[] components = from.GetComponents<CameraShaker>();
			for (int i = 0; i < components.Length; i++)
			{
				CameraShaker cameraShaker = components[i];
				CameraShaker cameraShaker2 = to.AddComponent<CameraShaker>();
				cameraShaker2.CurveX = new AnimationCurve(cameraShaker.CurveX.keys);
				cameraShaker2.CurveY = new AnimationCurve(cameraShaker.CurveY.keys);
				cameraShaker2.Swing = cameraShaker.Swing;
				cameraShaker2.ShakerName = cameraShaker.ShakerName;
			}
		}

		public void Play(float swing, Action onEnd)
		{
			this.Swing = swing;
			if (this.CameraTransform == null)
			{
				this.CameraTransform = base.transform;
				this.originalPos = this.CameraTransform.localPosition;
			}
			this.startTime = Time.time;
			if (this.CurveX.keys.Length < 2)
			{
				if (onEnd != null)
				{
					onEnd();
				}
			}
			else
			{
				this.onEndCallback = onEnd;
				this.shakeTime = this.CurveX.keys[this.CurveX.keys.Length - 1].time;
				base.CancelInvoke("ShakeUpdate");
				base.InvokeRepeating("ShakeUpdate", 0.03f, 0.03f);
			}
		}

		protected void ShakeUpdate()
		{
			float num = Time.time - this.startTime;
			if (num < this.shakeTime)
			{
				float d = this.CurveX.Evaluate(num);
				float d2 = this.CurveY.Evaluate(num);
				this.CameraTransform.localPosition = this.originalPos + this.CameraTransform.right * d * this.Swing + this.CameraTransform.up * d2 * this.Swing;
			}
			else
			{
				base.CancelInvoke("ShakeUpdate");
				this.CameraTransform.transform.localPosition = this.originalPos;
				Action action = this.onEndCallback;
				this.onEndCallback = null;
				if (action != null)
				{
					action();
				}
			}
		}
	}
}
