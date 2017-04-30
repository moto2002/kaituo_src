using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityStandardAssets.Utility;

namespace UnityStandardAssets.Effects
{
	public class Explosive : MonoBehaviour
	{
		public Transform explosionPrefab;

		public float detonationImpactVelocity = 10f;

		public float sizeMultiplier = 1f;

		public bool reset = true;

		public float resetTimeDelay = 10f;

		private bool m_Exploded;

		private ObjectResetter m_ObjectResetter;

		private void Start()
		{
			this.m_ObjectResetter = base.GetComponent<ObjectResetter>();
		}

		[DebuggerHidden]
		private IEnumerator OnCollisionEnter(Collision col)
		{
			Explosive.<OnCollisionEnter>c__Iterator2 <OnCollisionEnter>c__Iterator = new Explosive.<OnCollisionEnter>c__Iterator2();
			<OnCollisionEnter>c__Iterator.col = col;
			<OnCollisionEnter>c__Iterator.<$>col = col;
			<OnCollisionEnter>c__Iterator.<>f__this = this;
			return <OnCollisionEnter>c__Iterator;
		}

		public void Reset()
		{
			this.m_Exploded = false;
		}
	}
}
