using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	[ExecuteInEditMode]
	public class AutoCam : PivotBasedCameraRig
	{
		[SerializeField]
		private float m_MoveSpeed = 3f;

		[SerializeField]
		private float m_TurnSpeed = 1f;

		[SerializeField]
		private float m_RollSpeed = 0.2f;

		[SerializeField]
		private bool m_FollowVelocity;

		[SerializeField]
		private bool m_FollowTilt = true;

		[SerializeField]
		private float m_SpinTurnLimit = 90f;

		[SerializeField]
		private float m_TargetVelocityLowerLimit = 4f;

		[SerializeField]
		private float m_SmoothTurnTime = 0.2f;

		private float m_LastFlatAngle;

		private float m_CurrentTurnAmount;

		private float m_TurnSpeedVelocityChange;

		private Vector3 m_RollUp = Vector3.up;

		protected override void FollowTarget(float deltaTime)
		{
			if (deltaTime <= 0f || this.m_Target == null)
			{
				return;
			}
			Vector3 forward = this.m_Target.forward;
			Vector3 up = this.m_Target.up;
			if (this.m_FollowVelocity && Application.isPlaying)
			{
				if (this.targetRigidbody.velocity.magnitude > this.m_TargetVelocityLowerLimit)
				{
					forward = this.targetRigidbody.velocity.normalized;
					up = Vector3.up;
				}
				else
				{
					up = Vector3.up;
				}
				this.m_CurrentTurnAmount = Mathf.SmoothDamp(this.m_CurrentTurnAmount, 1f, ref this.m_TurnSpeedVelocityChange, this.m_SmoothTurnTime);
			}
			else
			{
				float num = Mathf.Atan2(forward.x, forward.z) * 57.29578f;
				if (this.m_SpinTurnLimit > 0f)
				{
					float value = Mathf.Abs(Mathf.DeltaAngle(this.m_LastFlatAngle, num)) / deltaTime;
					float num2 = Mathf.InverseLerp(this.m_SpinTurnLimit, this.m_SpinTurnLimit * 0.75f, value);
					float smoothTime = (this.m_CurrentTurnAmount <= num2) ? 1f : 0.1f;
					if (Application.isPlaying)
					{
						this.m_CurrentTurnAmount = Mathf.SmoothDamp(this.m_CurrentTurnAmount, num2, ref this.m_TurnSpeedVelocityChange, smoothTime);
					}
					else
					{
						this.m_CurrentTurnAmount = num2;
					}
				}
				else
				{
					this.m_CurrentTurnAmount = 1f;
				}
				this.m_LastFlatAngle = num;
			}
			base.transform.position = Vector3.Lerp(base.transform.position, this.m_Target.position, deltaTime * this.m_MoveSpeed);
			if (!this.m_FollowTilt)
			{
				forward.y = 0f;
				if (forward.sqrMagnitude < 1.401298E-45f)
				{
					forward = base.transform.forward;
				}
			}
			Quaternion b = Quaternion.LookRotation(forward, this.m_RollUp);
			this.m_RollUp = ((this.m_RollSpeed <= 0f) ? Vector3.up : Vector3.Slerp(this.m_RollUp, up, this.m_RollSpeed * deltaTime));
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, b, this.m_TurnSpeed * this.m_CurrentTurnAmount * deltaTime);
		}
	}
}
