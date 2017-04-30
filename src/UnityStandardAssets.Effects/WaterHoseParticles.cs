using System;
using UnityEngine;

namespace UnityStandardAssets.Effects
{
	public class WaterHoseParticles : MonoBehaviour
	{
		public static float lastSoundTime;

		public float force = 1f;

		private ParticleCollisionEvent[] m_CollisionEvents = new ParticleCollisionEvent[16];

		private ParticleSystem m_ParticleSystem;

		private void Start()
		{
			this.m_ParticleSystem = base.GetComponent<ParticleSystem>();
		}

		private void OnParticleCollision(GameObject other)
		{
			int safeCollisionEventSize = this.m_ParticleSystem.GetSafeCollisionEventSize();
			if (this.m_CollisionEvents.Length < safeCollisionEventSize)
			{
				this.m_CollisionEvents = new ParticleCollisionEvent[safeCollisionEventSize];
			}
			int collisionEvents = this.m_ParticleSystem.GetCollisionEvents(other, this.m_CollisionEvents);
			for (int i = 0; i < collisionEvents; i++)
			{
				if (Time.time > WaterHoseParticles.lastSoundTime + 0.2f)
				{
					WaterHoseParticles.lastSoundTime = Time.time;
				}
				Collider collider = this.m_CollisionEvents[i].collider;
				if (collider.attachedRigidbody != null)
				{
					Vector3 velocity = this.m_CollisionEvents[i].velocity;
					collider.attachedRigidbody.AddForce(velocity * this.force, ForceMode.Impulse);
				}
				other.BroadcastMessage("Extinguish", SendMessageOptions.DontRequireReceiver);
			}
		}
	}
}
