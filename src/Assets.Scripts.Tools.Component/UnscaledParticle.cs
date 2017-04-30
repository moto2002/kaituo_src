using Assets.Tools.Script.Helper;
using System;
using UnityEngine;

namespace Assets.Scripts.Tools.Component
{
	public class UnscaledParticle : MonoBehaviour
	{
		[Header("获取父节点下的所有特效")]
		public bool parentNode;

		public ParticleSystem[] ParticleSystems;

		private void Start()
		{
			if (this.parentNode)
			{
				ParticleSystem[] componentsInChildren = base.GetComponentsInChildren<ParticleSystem>();
				this.ParticleSystems = this.ParticleSystems.Add(componentsInChildren);
			}
		}

		public void Update()
		{
			ParticleSystem[] particleSystems = this.ParticleSystems;
			for (int i = 0; i < particleSystems.Length; i++)
			{
				ParticleSystem particleSystem = particleSystems[i];
				particleSystem.Simulate(Time.unscaledDeltaTime, true, false);
			}
		}
	}
}
