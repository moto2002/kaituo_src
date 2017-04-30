using Assets.Tools.Script.Serialized.LocalCache;
using Assets.Tools.Script.Sound;
using System;
using UnityEngine;

namespace Assets.Scripts.Tools.Sound
{
	public class LoginGameVolume : MonoBehaviour, IGameVolume
	{
		public AudioClip BGM;

		public float DefaultBGMVolume = 1f;

		public float DefaultESVolume = 1f;

		private static AudioSource source;

		public float backgroundSound
		{
			get;
			set;
		}

		public float effectSound
		{
			get;
			set;
		}

		private void Start()
		{
			PlayerPrefsCache playerPrefsCache = new PlayerPrefsCache("Data", 10000, false);
			string @string = playerPrefsCache.GetString("BGMVolume");
			string string2 = playerPrefsCache.GetString("ESVolume");
			this.backgroundSound = ((@string != null) ? Convert.ToSingle(@string) : this.DefaultBGMVolume);
			this.effectSound = ((string2 != null) ? Convert.ToSingle(string2) : this.DefaultESVolume);
			if (SoundUtilities.volumeCentre == null)
			{
				SoundUtilities.volumeCentre = this;
			}
			base.Invoke("PlaySound", 0.03f);
		}

		public void PlaySound()
		{
			SoundUtilities.StopSound(this.BGM.name);
			LoginGameVolume.source = SoundUtilities.PlaySound(this.BGM, this.backgroundSound, true, null);
		}

		public static void StopSound()
		{
			if (LoginGameVolume.source != null)
			{
				SoundUtilities.StopSound(LoginGameVolume.source);
				LoginGameVolume.source = null;
			}
		}
	}
}
