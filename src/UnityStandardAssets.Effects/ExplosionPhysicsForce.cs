using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

namespace UnityStandardAssets.Effects
{
	public class ExplosionPhysicsForce : MonoBehaviour
	{
		public float explosionForce = 4f;

		[DebuggerHidden]
		private IEnumerator Start()
		{
			ExplosionPhysicsForce.<Start>c__Iterator1 <Start>c__Iterator = new ExplosionPhysicsForce.<Start>c__Iterator1();
			<Start>c__Iterator.<>f__this = this;
			return <Start>c__Iterator;
		}
	}
}
