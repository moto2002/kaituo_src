using Assets.Tools.Script.Sound;
using System;
using UnityEngine;

namespace Assets.Scripts.Tools.Sound
{
	public class GameVolume : MonoBehaviour, IGameVolume
	{
		public float BackgroundSound;

		public float EffectSound;

		public float backgroundSound
		{
			get
			{
				return this.BackgroundSound;
			}
			set
			{
				this.BackgroundSound = value;
			}
		}

		public float effectSound
		{
			get
			{
				return this.EffectSound;
			}
			set
			{
				this.EffectSound = value;
			}
		}

		private void Awake()
		{
			SoundUtilities.volumeCentre = this;
		}
	}
}
