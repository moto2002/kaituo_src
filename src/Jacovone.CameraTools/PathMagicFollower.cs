using System;
using UnityEngine;

namespace Jacovone.CameraTools
{
	[ExecuteInEditMode]
	public class PathMagicFollower : MonoBehaviour
	{
		public PathMagic pathMagic;

		public PathMagicAnimator pathMagicAnimator;

		public Transform target;

		public int precision = 1000;

		public bool accurate;

		public bool waypointsOnly;

		public bool lerpPosition = true;

		public float lerpFactor = 0.1f;

		public Transform Target
		{
			get
			{
				return this.target;
			}
			set
			{
				this.target = value;
			}
		}

		public int Precision
		{
			get
			{
				return this.precision;
			}
			set
			{
				this.precision = value;
			}
		}

		public bool Accurate
		{
			get
			{
				return this.accurate;
			}
			set
			{
				this.accurate = value;
			}
		}

		public bool WaypointsOnly
		{
			get
			{
				return this.waypointsOnly;
			}
			set
			{
				this.waypointsOnly = value;
			}
		}

		public bool LerpPosition
		{
			get
			{
				return this.lerpPosition;
			}
			set
			{
				this.lerpPosition = value;
			}
		}

		public float LerpFactor
		{
			get
			{
				return this.lerpFactor;
			}
			set
			{
				this.lerpFactor = value;
			}
		}

		public float CurrentPos
		{
			get
			{
				if (this.pathMagic != null)
				{
					return this.pathMagic.CurrentPos;
				}
				if (this.pathMagicAnimator != null)
				{
					return this.pathMagicAnimator.CurrentPos;
				}
				return 0f;
			}
			set
			{
				if (this.pathMagic != null)
				{
					this.pathMagic.CurrentPos = value;
					this.pathMagic.UpdateTarget();
				}
				else if (this.pathMagicAnimator != null)
				{
					this.pathMagicAnimator.CurrentPos = value;
					this.pathMagicAnimator.UpdateTarget();
				}
			}
		}

		public PathMagic Path
		{
			get
			{
				if (this.pathMagic != null)
				{
					return this.pathMagic;
				}
				if (this.pathMagicAnimator != null)
				{
					return this.pathMagicAnimator.pathMagic;
				}
				return null;
			}
		}

		public Vector3 PointOfView
		{
			get
			{
				Vector3 position = Vector3.zero;
				Quaternion identity = Quaternion.identity;
				float num = 1f;
				int num2 = 0;
				if (this.Path.presampledPath)
				{
					this.Path.sampledPositionAndRotationAndVelocityAndWaypointAtPos(this.CurrentPos, out position, out identity, out num, out num2);
				}
				else
				{
					position = this.Path.computePositionAtPos(this.CurrentPos);
				}
				return this.Path.transform.TransformPoint(position);
			}
		}

		private void Awake()
		{
			PathMagic component = base.GetComponent<PathMagic>();
			if (component != null)
			{
				this.pathMagic = component;
				this.pathMagicAnimator = null;
			}
			else
			{
				PathMagicAnimator component2 = base.GetComponent<PathMagicAnimator>();
				if (component2 != null)
				{
					this.pathMagicAnimator = component2;
					this.pathMagic = null;
				}
			}
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void Update()
		{
			float num;
			if (this.waypointsOnly)
			{
				num = this.computeWaypointPosAtMinDistance();
			}
			else
			{
				num = this.computePosAtMinDistance();
			}
			if (this.Path.Loop)
			{
				if (Mathf.Abs(this.CurrentPos - num) > Mathf.Abs(this.CurrentPos - (1f + num)))
				{
					num = 1f + num;
				}
				if (Mathf.Abs(this.CurrentPos - num) > Mathf.Abs(this.CurrentPos - (num - 1f)))
				{
					num -= 1f;
				}
			}
			float num2;
			if (this.lerpPosition)
			{
				num2 = Mathf.Lerp(this.CurrentPos, num, this.lerpFactor);
			}
			else
			{
				num2 = num;
			}
			while (num2 > 1f)
			{
				num2 -= 1f;
			}
			while (num2 < 0f)
			{
				num2 += 1f;
			}
			this.CurrentPos = num2;
		}

		private float computeWaypointPosAtMinDistance()
		{
			float num = 3.40282347E+38f;
			float num2 = 0f;
			int num3 = 0;
			float num4 = 1f / (float)this.precision;
			for (int i = 0; i < this.Path.Waypoints.Length; i++)
			{
				Vector3 a = this.Path.transform.TransformPoint(this.Path.Waypoints[i].position);
				float num5 = Vector3.Distance(a, this.target.position);
				if (num5 < num)
				{
					num3 = i;
					num = num5;
				}
			}
			if (!this.Path.presampledPath)
			{
				while (this.Path.GetWaypointFromPos(num2) != num3)
				{
					num2 += num4;
				}
				if (num2 > 1f)
				{
					num2 = 1f;
				}
			}
			else
			{
				int num6 = 0;
				while (this.Path.WaypointSamples[num6] != num3)
				{
					num2 += this.Path.SamplesDistances[num6++];
				}
				num2 /= this.Path.TotalDistance;
			}
			return num2;
		}

		private float computePosAtMinDistance()
		{
			if (this.target == null)
			{
				return 0f;
			}
			if (this.Path == null)
			{
				return 0f;
			}
			float num = 3.40282347E+38f;
			float num2 = 1f / (float)this.precision;
			float num3 = 0f;
			for (int i = 0; i < this.precision; i++)
			{
				Vector3 positionForPos = this.GetPositionForPos((float)i * num2);
				float num4 = Vector3.Distance(positionForPos, this.target.position);
				if (num4 < num)
				{
					num3 = (float)i * num2;
					num = num4;
				}
			}
			if (this.accurate)
			{
				float num5 = num3;
				for (float num6 = num5 - num2; num6 < num5 + num2; num6 += num2 / 100f)
				{
					Vector3 positionForPos2 = this.GetPositionForPos(num6);
					float num7 = Vector3.Distance(positionForPos2, this.target.position);
					if (num7 < num)
					{
						num3 = num6;
						num = num7;
					}
				}
			}
			return num3;
		}

		private Vector3 GetPositionForPos(float pos)
		{
			Vector3 position = Vector3.zero;
			Quaternion identity = Quaternion.identity;
			float num = 1f;
			int num2 = 0;
			if (this.Path.presampledPath)
			{
				this.Path.sampledPositionAndRotationAndVelocityAndWaypointAtPos(pos, out position, out identity, out num, out num2);
			}
			else
			{
				position = this.Path.computePositionAtPos(pos);
			}
			return this.Path.transform.TransformPoint(position);
		}
	}
}
