using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

namespace UnityStandardAssets.Utility
{
	public class ParticleSystemDestroyer : MonoBehaviour
	{
		public float minDuration = 8f;

		public float maxDuration = 10f;

		private float m_MaxLifetime;

		private bool m_EarlyStop;

		[DebuggerHidden]
		private IEnumerator Start()
		{
			ParticleSystemDestroyer.<Start>c__Iterator8 <Start>c__Iterator = new ParticleSystemDestroyer.<Start>c__Iterator8();
			<Start>c__Iterator.<>f__this = this;
			return <Start>c__Iterator;
		}

		public void Stop()
		{
			this.m_EarlyStop = true;
		}
	}
}
