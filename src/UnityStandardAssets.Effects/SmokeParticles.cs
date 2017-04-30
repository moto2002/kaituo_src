using System;
using UnityEngine;

namespace UnityStandardAssets.Effects
{
	public class SmokeParticles : MonoBehaviour
	{
		public AudioClip[] extinguishSounds;

		private void Start()
		{
			base.GetComponent<AudioSource>().clip = this.extinguishSounds[UnityEngine.Random.Range(0, this.extinguishSounds.Length)];
			base.GetComponent<AudioSource>().Play();
		}
	}
}
