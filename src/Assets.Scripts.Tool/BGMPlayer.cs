using System;
using UnityEngine;

namespace Assets.Scripts.Tool
{
	public class BGMPlayer : MonoBehaviour
	{
		public AudioClip Clip;

		private AudioSource source;

		public void Start()
		{
			this.source = NGUITools.PlaySound(this.Clip);
		}

		private void Update()
		{
			if (this.source != null && !this.source.isPlaying)
			{
				this.source = NGUITools.PlaySound(this.Clip);
			}
		}
	}
}
