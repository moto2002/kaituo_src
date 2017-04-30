using System;
using UnityEngine;
using UnityEngine.Events;

namespace Jacovone
{
	[Serializable]
	public class Waypoint
	{
		[Serializable]
		public class ReachedEvent : UnityEvent
		{
		}

		public enum VelocityVariation
		{
			Slow,
			Medium,
			Fast
		}

		public Vector3 position;

		public Vector3 rotation;

		public Transform lookAt;

		public Vector3 inTangent;

		public Vector3 outTangent;

		public bool symmetricTangents;

		public float velocity;

		public Waypoint.VelocityVariation inVariation;

		public Waypoint.VelocityVariation outVariation;

		public Waypoint.ReachedEvent reached;

		public Vector3 Position
		{
			get
			{
				return this.position;
			}
			set
			{
				this.position = value;
			}
		}

		public Vector3 Rotation
		{
			get
			{
				return this.rotation;
			}
			set
			{
				this.rotation = value;
			}
		}

		public Transform LookAt
		{
			get
			{
				return this.lookAt;
			}
			set
			{
				this.lookAt = value;
			}
		}

		public Vector3 InTangent
		{
			get
			{
				return this.inTangent;
			}
			set
			{
				this.inTangent = value;
			}
		}

		public Vector3 OutTangent
		{
			get
			{
				return this.outTangent;
			}
			set
			{
				this.outTangent = value;
			}
		}

		public bool SymmetricTangents
		{
			get
			{
				return this.symmetricTangents;
			}
			set
			{
				this.symmetricTangents = value;
			}
		}

		public Waypoint.VelocityVariation InVariation
		{
			get
			{
				return this.inVariation;
			}
			set
			{
				this.inVariation = value;
			}
		}

		public Waypoint.VelocityVariation OutVariation
		{
			get
			{
				return this.outVariation;
			}
			set
			{
				this.outVariation = value;
			}
		}

		public float Velocity
		{
			get
			{
				return this.velocity;
			}
			set
			{
				this.velocity = value;
			}
		}

		public Waypoint.ReachedEvent Reached
		{
			get
			{
				return this.reached;
			}
			set
			{
				this.reached = value;
			}
		}

		public Waypoint()
		{
			this.position = Vector3.zero;
			this.rotation = Vector3.zero;
			this.velocity = 1f;
			this.outTangent = Vector3.forward;
			this.inTangent = -Vector3.forward;
			this.symmetricTangents = true;
			this.inVariation = Waypoint.VelocityVariation.Medium;
			this.outVariation = Waypoint.VelocityVariation.Medium;
			this.reached = null;
		}
	}
}
