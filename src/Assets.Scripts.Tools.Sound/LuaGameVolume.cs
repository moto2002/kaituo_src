using Assets.Tools.Script.Sound;
using System;

namespace Assets.Scripts.Tools.Sound
{
	public class LuaGameVolume : IGameVolume
	{
		private float backgroundVolume;

		private float effectVolume;

		public float backgroundSound
		{
			get
			{
				return this.backgroundVolume;
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public float effectSound
		{
			get
			{
				return this.effectVolume;
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public void UpdateVolume(float bgmVolume, float esVolume)
		{
			this.effectVolume = bgmVolume;
			this.backgroundVolume = esVolume;
		}
	}
}
