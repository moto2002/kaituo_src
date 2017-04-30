using System;
using UnityEngine;
using UnityEngine.Events;

namespace Jacovone
{
	public class PathMagic : MonoBehaviour
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

		public Action OnStopPlay;

		public bool IgnoreTimeScale;

		public Color pathColor = Color.white;

		public Waypoint[] waypoints = new Waypoint[0];

		public Transform target;

		public bool disableOrientation;

		public Transform globalLookAt;

		public bool globalFollowPath;

		public float globalFollowPathBias = 0.001f;

		public PathMagic.UpdateModeType updateMode;

		public bool loop;

		public bool autoStart;

		public float velocityBias = 0.1f;

		public float currentPos;

		public bool isPlaying;

		public PathMagic.WaypointChangedEvent waypointChanged;

		public bool presampledPath;

		public int samplesNum = 100;

		private int _lastPassedWayponint;

		public Vector3[] positionSamples;

		public Quaternion[] rotationSamples;

		public float[] velocitySamples;

		public int[] waypointSamples;

		public float[] samplesDistances;

		public float totalDistance;

		private float _lastVelocity = 1f;

		public Waypoint[] Waypoints
		{
			get
			{
				return this.waypoints;
			}
			set
			{
				this.waypoints = value;
				if (this.presampledPath)
				{
					this.UpdatePathSamples();
				}
				this.UpdateTarget();
			}
		}

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

		public bool GlobalFollowPath
		{
			get
			{
				return this.globalFollowPath;
			}
			set
			{
				this.globalFollowPath = value;
			}
		}

		public float GlobalFollowPathBias
		{
			get
			{
				return this.globalFollowPathBias;
			}
			set
			{
				this.globalFollowPathBias = value;
			}
		}

		public PathMagic.UpdateModeType UpdateMode
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

		public bool Loop
		{
			get
			{
				return this.loop;
			}
			set
			{
				this.loop = value;
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
				this.UpdateTarget();
			}
		}

		public bool IsPlaying
		{
			get
			{
				return this.isPlaying;
			}
		}

		public PathMagic.WaypointChangedEvent WaypointChanged
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

		public bool PresampledPath
		{
			get
			{
				return this.presampledPath;
			}
		}

		public int SamplesNum
		{
			get
			{
				return this.samplesNum;
			}
		}

		public int LastPassedWayponint
		{
			get
			{
				return this._lastPassedWayponint;
			}
		}

		public Vector3[] PositionSamples
		{
			get
			{
				return this.positionSamples;
			}
		}

		public Quaternion[] RotationSamples
		{
			get
			{
				return this.rotationSamples;
			}
		}

		public float[] VelocitySamples
		{
			get
			{
				return this.velocitySamples;
			}
		}

		public int[] WaypointSamples
		{
			get
			{
				return this.waypointSamples;
			}
		}

		public float[] SamplesDistances
		{
			get
			{
				return this.samplesDistances;
			}
		}

		public float TotalDistance
		{
			get
			{
				return this.totalDistance;
			}
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void Start()
		{
			if (this.presampledPath)
			{
				this.UpdatePathSamples();
			}
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
			if (this.updateMode == PathMagic.UpdateModeType.OnUpdate || !Application.isPlaying)
			{
				this.DoUpdate();
			}
		}

		private void FixedUpdate()
		{
			if (this.updateMode == PathMagic.UpdateModeType.OnFixedUpdate)
			{
				this.DoUpdate();
			}
		}

		public void DoUpdate()
		{
			if (this.waypoints.Length == 0)
			{
				return;
			}
			if (this.isPlaying)
			{
				float num = 0.5f * this.velocityBias * this._lastVelocity * ((!Application.isPlaying) ? 0.008f : ((!this.IgnoreTimeScale) ? Time.deltaTime : Time.unscaledDeltaTime));
				this.currentPos += num;
				if (this.currentPos >= 1f)
				{
					if (this.loop)
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
					if (this.loop)
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
			if (this.waypoints.Length == 0)
			{
				return;
			}
			this.isPlaying = true;
		}

		public void Pause()
		{
			if (this.waypoints.Length == 0)
			{
				return;
			}
			this.isPlaying = false;
			if (this.OnStopPlay != null)
			{
				this.OnStopPlay();
			}
		}

		public void Rewind()
		{
			if (this.waypoints.Length == 0)
			{
				return;
			}
			this.currentPos = 0f;
		}

		public void Stop()
		{
			if (this.waypoints.Length == 0)
			{
				return;
			}
			this.isPlaying = false;
			this.currentPos = 0f;
			this.UpdateTarget(this.computePositionAtPos(this.currentPos), this.computeRotationAtPos(this.currentPos));
			if (this.OnStopPlay != null)
			{
				this.OnStopPlay();
			}
		}

		public void sampledPositionAndRotationAndVelocityAndWaypointAtPos(float pos, out Vector3 position, out Quaternion rotation, out float velocity, out int waypoint)
		{
			float num = pos * this.totalDistance;
			float num2 = 0f;
			for (int i = 1; i < this.samplesNum; i++)
			{
				num2 += this.samplesDistances[i];
				if (num2 >= num)
				{
					float t = 1f - (num2 - num) / this.samplesDistances[i];
					position = Vector3.Lerp(this.positionSamples[i - 1], this.positionSamples[i], t);
					if (this.globalLookAt != null)
					{
						rotation = Quaternion.LookRotation(base.transform.InverseTransformPoint(this.globalLookAt.position) - position);
					}
					else
					{
						rotation = Quaternion.Lerp(this.rotationSamples[i - 1], this.rotationSamples[i], t);
					}
					velocity = Mathf.Lerp(this.velocitySamples[i - 1], this.velocitySamples[i], t);
					if (pos >= 1f)
					{
						if (this.loop)
						{
							waypoint = 0;
						}
						else
						{
							waypoint = this.waypoints.Length - 1;
						}
					}
					else
					{
						waypoint = this.waypointSamples[i - 1];
					}
					return;
				}
			}
			position = this.positionSamples[this.samplesNum - 1];
			rotation = this.rotationSamples[this.samplesNum - 1];
			velocity = this.velocitySamples[this.samplesNum - 1];
			waypoint = this.waypoints.Length - 1;
		}

		public Quaternion computeRotationAtPos(float pos)
		{
			if (this.globalFollowPath)
			{
				return this.GetFaceForwardForPos(pos);
			}
			if (this.globalLookAt != null)
			{
				return Quaternion.LookRotation(base.transform.InverseTransformPoint(this.globalLookAt.position) - this.computePositionAtPos(pos));
			}
			if (this.waypoints.Length < 1)
			{
				return Quaternion.identity;
			}
			if (this.waypoints.Length == 1)
			{
				return this.GetWaypointRotation(0);
			}
			if (pos < 1f)
			{
				float num = 1f / (float)(this.waypoints.Length - ((!this.loop) ? 1 : 0));
				int waypointFromPos = this.GetWaypointFromPos(pos);
				float num2 = pos - (float)waypointFromPos * num;
				float stepPos = num2 / num;
				Quaternion waypointRotation = this.GetWaypointRotation(waypointFromPos);
				Quaternion waypointRotation2 = this.GetWaypointRotation(waypointFromPos - 1);
				Quaternion waypointRotation3 = this.GetWaypointRotation(waypointFromPos + 1);
				Quaternion waypointRotation4 = this.GetWaypointRotation(waypointFromPos + 2);
				return MathUtils.QuaternionBezier(waypointRotation, waypointRotation2, waypointRotation3, waypointRotation4, stepPos);
			}
			if (this.loop)
			{
				return this.GetWaypointRotation(0);
			}
			return this.GetWaypointRotation(this.waypoints.Length - 1);
		}

		public Quaternion GetWaypointRotation(int index)
		{
			if (index < 0)
			{
				index += this.waypoints.Length;
			}
			index %= this.waypoints.Length;
			return (!(this.waypoints[index].lookAt != null)) ? Quaternion.Euler(this.waypoints[index].rotation) : Quaternion.LookRotation(base.transform.InverseTransformPoint(this.waypoints[index].lookAt.position) - this.waypoints[index].position);
		}

		public Vector3 computePositionAtPos(float pos)
		{
			if (this.waypoints.Length < 1)
			{
				return Vector3.zero;
			}
			if (this.waypoints.Length == 1)
			{
				return this.waypoints[0].position;
			}
			if (pos < 1f)
			{
				float num = 1f / (float)(this.waypoints.Length - ((!this.loop) ? 1 : 0));
				int waypointFromPos = this.GetWaypointFromPos(pos);
				float num2 = pos - (float)waypointFromPos * num;
				float t = num2 / num;
				return MathUtils.Vector3Bezier(this.waypoints[waypointFromPos % this.waypoints.Length].position, this.waypoints[waypointFromPos % this.waypoints.Length].outTangent + this.waypoints[waypointFromPos % this.waypoints.Length].position, this.waypoints[(waypointFromPos + 1) % this.waypoints.Length].inTangent + this.waypoints[(waypointFromPos + 1) % this.waypoints.Length].position, this.waypoints[(waypointFromPos + 1) % this.waypoints.Length].position, t);
			}
			if (this.loop)
			{
				return this.waypoints[0].position;
			}
			return this.waypoints[this.waypoints.Length - 1].position;
		}

		public float computeVelocityAtPos(float pos)
		{
			if (this.waypoints.Length < 1)
			{
				return 1f;
			}
			if (this.waypoints.Length == 1)
			{
				return this.waypoints[0].velocity;
			}
			if (pos < 1f)
			{
				float num = 1f / (float)(this.waypoints.Length - ((!this.loop) ? 1 : 0));
				int waypointFromPos = this.GetWaypointFromPos(pos);
				float num2 = pos - (float)waypointFromPos * num;
				float t = num2 / num;
				Waypoint waypoint = this.waypoints[waypointFromPos % this.waypoints.Length];
				Waypoint waypoint2 = this.waypoints[(waypointFromPos + 1) % this.waypoints.Length];
				float p;
				if (waypoint.outVariation == Waypoint.VelocityVariation.Fast)
				{
					p = waypoint2.velocity;
				}
				else if (waypoint.outVariation == Waypoint.VelocityVariation.Medium)
				{
					p = Mathf.Lerp(waypoint.velocity, waypoint2.velocity, 0.5f);
				}
				else
				{
					p = waypoint.velocity;
				}
				float p2;
				if (waypoint2.inVariation == Waypoint.VelocityVariation.Fast)
				{
					p2 = waypoint.velocity;
				}
				else if (waypoint2.inVariation == Waypoint.VelocityVariation.Medium)
				{
					p2 = Mathf.Lerp(waypoint.velocity, waypoint2.velocity, 0.5f);
				}
				else
				{
					p2 = waypoint2.velocity;
				}
				return MathUtils.FloatBezier(waypoint.velocity, p, p2, waypoint2.velocity, t);
			}
			if (this.loop)
			{
				return this.waypoints[0].velocity;
			}
			return this.waypoints[this.waypoints.Length - 1].velocity;
		}

		public void UpdateTarget(Vector3 position, Quaternion rotation)
		{
			if (this.target != null)
			{
				this.target.position = base.transform.TransformPoint(position);
				if (!this.disableOrientation)
				{
					this.target.rotation = base.transform.rotation * rotation;
				}
			}
		}

		public void UpdateTarget()
		{
			Vector3 position = Vector3.zero;
			Quaternion rotation = Quaternion.identity;
			float lastVelocity = 1f;
			int num = 0;
			if (this.presampledPath)
			{
				this.sampledPositionAndRotationAndVelocityAndWaypointAtPos(this.currentPos, out position, out rotation, out lastVelocity, out num);
			}
			else
			{
				position = this.computePositionAtPos(this.currentPos);
				rotation = this.computeRotationAtPos(this.currentPos);
				lastVelocity = this.computeVelocityAtPos(this.currentPos);
				num = this.GetWaypointFromPos(this.currentPos);
			}
			this._lastVelocity = lastVelocity;
			this.UpdateTarget(position, rotation);
			if (num != this._lastPassedWayponint)
			{
				if (this.waypointChanged != null)
				{
					this.waypointChanged.Invoke(num);
				}
				if (this.waypoints[num].reached != null)
				{
					this.waypoints[num].reached.Invoke();
				}
			}
			this._lastPassedWayponint = num;
		}

		public int GetCurrentWaypoint()
		{
			return this.GetWaypointFromPos(this.currentPos);
		}

		public int GetWaypointFromPos(float pos)
		{
			float num = 1f / (float)(this.waypoints.Length - ((!this.loop) ? 1 : 0));
			int num2 = Mathf.FloorToInt(pos / num) % this.waypoints.Length;
			if (num2 < 0)
			{
				num2 += this.waypoints.Length;
			}
			return num2;
		}

		public Quaternion GetFaceForwardForPos(float pos)
		{
			Quaternion result;
			if (this.waypoints.Length <= 1)
			{
				result = Quaternion.identity;
			}
			else if (this.loop)
			{
				Vector3 a = this.computePositionAtPos((pos + this.globalFollowPathBias) % 1f);
				Vector3 b = this.computePositionAtPos(pos);
				result = Quaternion.LookRotation(a - b, Vector3.up);
			}
			else
			{
				float pos2 = Mathf.Clamp01(pos + this.globalFollowPathBias);
				Vector3 vector = this.computePositionAtPos(pos2);
				Vector3 vector2 = this.computePositionAtPos(pos);
				if (vector == vector2)
				{
					vector = this.waypoints[this.waypoints.Length - 1].outTangent;
					vector2 = this.waypoints[this.waypoints.Length - 1].inTangent;
				}
				result = Quaternion.LookRotation(vector - vector2, Vector3.up);
			}
			return result;
		}

		public void UpdatePathSamples()
		{
			this.totalDistance = 0f;
			float num = 0f;
			this.positionSamples = new Vector3[this.samplesNum];
			this.rotationSamples = new Quaternion[this.samplesNum];
			this.samplesDistances = new float[this.samplesNum];
			this.velocitySamples = new float[this.samplesNum];
			this.waypointSamples = new int[this.samplesNum];
			if (this.waypoints.Length == 0)
			{
				return;
			}
			for (int i = 0; i < this.samplesNum - 1; i++)
			{
				this.positionSamples[i] = this.computePositionAtPos(num);
				this.rotationSamples[i] = this.computeRotationAtPos(num);
				this.velocitySamples[i] = this.computeVelocityAtPos(num);
				this.waypointSamples[i] = this.GetWaypointFromPos(num);
				if (i == 0)
				{
					this.samplesDistances[i] = 0f;
				}
				else
				{
					this.samplesDistances[i] = Vector3.Distance(this.positionSamples[i], this.positionSamples[i - 1]);
				}
				this.totalDistance += this.samplesDistances[i];
				num += 1f / ((float)this.samplesNum - 1f);
			}
			this.positionSamples[this.samplesNum - 1] = this.computePositionAtPos((!this.loop) ? 1f : 0f);
			this.rotationSamples[this.samplesNum - 1] = this.computeRotationAtPos((!this.loop) ? 1f : 0f);
			this.velocitySamples[this.samplesNum - 1] = this.computeVelocityAtPos((!this.loop) ? 1f : 0f);
			this.waypointSamples[this.samplesNum - 1] = this.GetWaypointFromPos((!this.loop) ? 1f : 0f);
			this.samplesDistances[this.samplesNum - 1] = Vector3.Distance(this.positionSamples[this.samplesNum - 1], this.positionSamples[this.samplesNum - 2]);
			this.totalDistance += this.samplesDistances[this.samplesNum - 1];
		}

		private void OnDrawGizmos()
		{
		}
	}
}
