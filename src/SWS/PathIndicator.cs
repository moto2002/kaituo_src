using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

namespace SWS
{
	public class PathIndicator : MonoBehaviour
	{
		public float modRotation;

		private ParticleSystem pSys;

		private void Start()
		{
			this.pSys = base.GetComponentInChildren<ParticleSystem>();
			base.StartCoroutine("EmitParticles");
		}

		[DebuggerHidden]
		private IEnumerator EmitParticles()
		{
			PathIndicator.<EmitParticles>c__Iterator25 <EmitParticles>c__Iterator = new PathIndicator.<EmitParticles>c__Iterator25();
			<EmitParticles>c__Iterator.<>f__this = this;
			return <EmitParticles>c__Iterator;
		}
	}
}
