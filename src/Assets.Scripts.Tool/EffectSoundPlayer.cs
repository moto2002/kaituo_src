using System;
using UnityEngine;

namespace Assets.Scripts.Tool
{
	public class EffectSoundPlayer : MonoBehaviour
	{
		public AudioClip Clip;

		public void Start()
		{
			AudioSource audioSource = NGUITools.PlaySound(this.Clip);
		}
	}
}
