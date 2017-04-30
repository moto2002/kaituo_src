using System;
using UnityEngine;

namespace UnityStandardAssets.Effects
{
	public class ExtinguishableParticleSystem : MonoBehaviour
	{
		public float multiplier = 1f;

		private ParticleSystem[] m_Systems;

		private void Start()
		{
			this.m_Systems = base.GetComponentsInChildren<ParticleSystem>();
		}

		public void Extinguish()
		{
			ParticleSystem[] systems = this.m_Systems;
			for (int i = 0; i < systems.Length; i++)
			{
				ParticleSystem particleSystem = systems[i];
				particleSystem.enableEmission = false;
			}
		}
	}
}
