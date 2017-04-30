using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Utility
{
	public class SimpleMouseRotator : MonoBehaviour
	{
		public Vector2 rotationRange = new Vector3(70f, 70f);

		public float rotationSpeed = 10f;

		public float dampingTime = 0.2f;

		public bool autoZeroVerticalOnMobile = true;

		public bool autoZeroHorizontalOnMobile;

		public bool relative = true;

		private Vector3 m_TargetAngles;

		private Vector3 m_FollowAngles;

		private Vector3 m_FollowVelocity;

		private Quaternion m_OriginalRotation;

		private void Start()
		{
			this.m_OriginalRotation = base.transform.localRotation;
		}

		private void Update()
		{
			base.transform.localRotation = this.m_OriginalRotation;
			if (this.relative)
			{
				float num = CrossPlatformInputManager.GetAxis("Mouse X");
				float num2 = CrossPlatformInputManager.GetAxis("Mouse Y");
				if (this.m_TargetAngles.y > 180f)
				{
					this.m_TargetAngles.y = this.m_TargetAngles.y - 360f;
					this.m_FollowAngles.y = this.m_FollowAngles.y - 360f;
				}
				if (this.m_TargetAngles.x > 180f)
				{
					this.m_TargetAngles.x = this.m_TargetAngles.x - 360f;
					this.m_FollowAngles.x = this.m_FollowAngles.x - 360f;
				}
				if (this.m_TargetAngles.y < -180f)
				{
					this.m_TargetAngles.y = this.m_TargetAngles.y + 360f;
					this.m_FollowAngles.y = this.m_FollowAngles.y + 360f;
				}
				if (this.m_TargetAngles.x < -180f)
				{
					this.m_TargetAngles.x = this.m_TargetAngles.x + 360f;
					this.m_FollowAngles.x = this.m_FollowAngles.x + 360f;
				}
				this.m_TargetAngles.y = this.m_TargetAngles.y + num * this.rotationSpeed;
				this.m_TargetAngles.x = this.m_TargetAngles.x + num2 * this.rotationSpeed;
				this.m_TargetAngles.y = Mathf.Clamp(this.m_TargetAngles.y, -this.rotationRange.y * 0.5f, this.rotationRange.y * 0.5f);
				this.m_TargetAngles.x = Mathf.Clamp(this.m_TargetAngles.x, -this.rotationRange.x * 0.5f, this.rotationRange.x * 0.5f);
			}
			else
			{
				float num = Input.mousePosition.x;
				float num2 = Input.mousePosition.y;
				this.m_TargetAngles.y = Mathf.Lerp(-this.rotationRange.y * 0.5f, this.rotationRange.y * 0.5f, num / (float)Screen.width);
				this.m_TargetAngles.x = Mathf.Lerp(-this.rotationRange.x * 0.5f, this.rotationRange.x * 0.5f, num2 / (float)Screen.height);
			}
			this.m_FollowAngles = Vector3.SmoothDamp(this.m_FollowAngles, this.m_TargetAngles, ref this.m_FollowVelocity, this.dampingTime);
			base.transform.localRotation = this.m_OriginalRotation * Quaternion.Euler(-this.m_FollowAngles.x, this.m_FollowAngles.y, 0f);
		}
	}
}
