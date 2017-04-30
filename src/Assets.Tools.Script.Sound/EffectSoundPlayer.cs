using System;
using UnityEngine;

namespace Assets.Tools.Script.Sound
{
	public class EffectSoundPlayer
	{
		public static AudioSource PlaySound(AudioClip clip)
		{
			return SoundUtilities.PlaySound(clip, SoundUtilities.volumeCentre.effectSound, false, null);
		}

		public static void StopSound(AudioSource audioSource)
		{
			SoundUtilities.StopSound(audioSource);
		}

		public static AudioSource PlaySound(AudioClip clip, float volume)
		{
			return SoundUtilities.PlaySound(clip, SoundUtilities.volumeCentre.effectSound * volume, false, null);
		}
	}
}
