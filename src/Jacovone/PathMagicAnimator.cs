using System;
using UnityEngine;
using UnityEngine.Events;

namespace Jacovone
{
	public class PathMagicAnimator : MonoBehaviour
	{
		[Serializable]
		public class WaypointChangedEvent : UnityEvent<int>
		{
		}

		public enum UpdateModeType
		{
			OnUpdate,
			OnFixedUpdate
		}

		public PathMagic pathMagic;

		public Transform target;

		public PathMagicAnimator.UpdateModeType updateMode;

		public bool autoStart = true;

		public float velocityBias = 1f;

		public float currentPos;

		public bool isPlaying;

		public Transform globalLookAt;

		public bool disableOrientation;

		public bool globalFollowPath;

		public PathMagicAnimator.WaypointChangedEvent waypointChanged;

		private int _lastPassedWayponint;

		private float _lastVelocity = 1f;

		public PathMagic PathMagic
		{
			get
			{
				return this.pathMagic;
			}
			set
			{
				this.pathMagic = value;
			}
		}

		public Transform Target
		{
			get
			{
				return this.target;
			}
		}

		public PathMagicAnimator.UpdateModeType UpdateMode
		{
			get
			{
				return this.updateMode;
			}
			set
			{
				this.updateMode = value;
			}
		}

		public bool AutoStart
		{
			get
			{
				return this.autoStart;
			}
			set
			{
				this.autoStart = value;
			}
		}

		public float VelocityBias
		{
			get
			{
				return this.velocityBias;
			}
			set
			{
				this.velocityBias = value;
			}
		}

		public float CurrentPos
		{
			get
			{
				return this.currentPos;
			}
			set
			{
				this.currentPos = value;
			}
		}

		public bool IsPlaying
		{
			get
			{
				return this.isPlaying;
			}
		}

		public Transform GlobalLookAt
		{
			get
			{
				return this.globalLookAt;
			}
			set
			{
				this.globalLookAt = value;
			}
		}

		public bool DisableOrientation
		{
			get
			{
				return this.disableOrientation;
			}
			set
			{
				this.disableOrientation = value;
			}
		}

		public PathMagicAnimator.WaypointChangedEvent WaypointChanged
		{
			get
			{
				return this.waypointChanged;
			}
			set
			{
				this.waypointChanged = value;
			}
		}

		public int LastPassedWayponint
		{
			get
			{
				return this._lastPassedWayponint;
			}
		}

		private void OnEnable()
		{
			this.target = base.GetComponent<Transform>();
			this.isPlaying = false;
		}

		private void OnDisable()
		{
		}

		private void Start()
		{
			if (Application.isPlaying)
			{
				this.isPlaying = this.autoStart;
			}
			else
			{
				this.isPlaying = false;
			}
		}

		private void Update()
		{
			if (this.updateMode == PathMagicAnimator.UpdateModeType.OnUpdate || !Application.isPlaying)
			{
				this.DoUpdate();
			}
		}

		private void FixedUpdate()
		{
			if (this.updateMode == PathMagicAnimator.UpdateModeType.OnFixedUpdate)
			{
				this.DoUpdate();
			}
		}

		public void DoUpdate()
		{
			if (this.pathMagic == null)
			{
				return;
			}
			if (this.pathMagic.waypoints.Length == 0)
			{
				return;
			}
			if (this.isPlaying)
			{
				float num = 0.5f * this.velocityBias * this._lastVelocity * ((!Application.isPlaying) ? 0.008f : Time.deltaTime);
				this.currentPos += num;
				if (this.currentPos >= 1f)
				{
					if (this.pathMagic.loop)
					{
						this.currentPos -= 1f;
					}
					else
					{
						this.currentPos = 1f;
						this.Pause();
					}
				}
				else if (this.currentPos <= 0f)
				{
					if (this.pathMagic.loop)
					{
						this.currentPos += 1f;
					}
					else
					{
						this.currentPos = 0f;
						this.Pause();
					}
				}
				this.UpdateTarget();
			}
		}

		public void Play()
		{
			if (this.pathMagic.waypoints.Length == 0)
			{
				return;
			}
			this._lastVelocity = this.pathMagic.waypoints[0].velocity;
			this.isPlaying = true;
		}

		public void Pause()
		{
			if (this.pathMagic.waypoints.Length == 0)
			{
				return;
			}
			this.isPlaying = false;
		}

		public void Rewind()
		{
			if (this.pathMagic.waypoints.Length == 0)
			{
				return;
			}
			this.currentPos = 0f;
		}

		public void Stop()
		{
			if (this.pathMagic.waypoints.Length == 0)
			{
				return;
			}
			this.isPlaying = false;
			this.currentPos = 0f;
			this.UpdateTarget(this.pathMagic.computePositionAtPos(this.currentPos), this.pathMagic.computeRotationAtPos(this.currentPos));
		}

		public void UpdateTarget(Vector3 position, Quaternion rotation)
		{
			if (this.target != null)
			{
				this.target.position = this.pathMagic.transform.TransformPoint(position);
				if (!this.disableOrientation)
				{
					this.target.rotation = this.pathMagic.transform.rotation * rotation;
				}
			}
		}

		public void UpdateTarget()
		{
			Vector3 vector = Vector3.zero;
			Quaternion rotation = Quaternion.identity;
			float lastVelocity = 1f;
			int num = 0;
			if (this.pathMagic.presampledPath)
			{
				this.pathMagic.sampledPositionAndRotationAndVelocityAndWaypointAtPos(this.currentPos, out vector, out rotation, out lastVelocity, out num);
			}
			else
			{
				vector = this.pathMagic.computePositionAtPos(this.currentPos);
				rotation = this.pathMagic.computeRotationAtPos(this.currentPos);
				lastVelocity = this.pathMagic.computeVelocityAtPos(this.currentPos);
				num = this.pathMagic.GetWaypointFromPos(this.currentPos);
			}
			if (this.globalFollowPath)
			{
				rotation = this.pathMagic.GetFaceForwardForPos(this.currentPos);
			}
			else if (this.globalLookAt != null)
			{
				rotation = Quaternion.LookRotation(this.pathMagic.transform.InverseTransformPoint(this.globalLookAt.position) - vector);
			}
			this._lastVelocity = lastVelocity;
			this.UpdateTarget(vector, rotation);
			if (num != this._lastPassedWayponint)
			{
				if (this.waypointChanged != null)
				{
					this.waypointChanged.Invoke(num);
				}
				if (this.pathMagic.waypoints[num].reached != null)
				{
					this.pathMagic.waypoints[num].reached.Invoke();
				}
			}
			this._lastPassedWayponint = num;
		}
	}
}
