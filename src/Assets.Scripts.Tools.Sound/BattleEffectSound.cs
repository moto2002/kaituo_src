using Assets.Tools.Script.Sound;
using LuaInterface;
using System;
using UnityEngine;
using XQ.Framework.Lua;

namespace Assets.Scripts.Tools.Sound
{
	public class BattleEffectSound : MonoBehaviour
	{
		public enum BattleEffectSoundType
		{
			OnEnable,
			OnClick
		}

		private static LuaFunction playGlobalSESound;

		public string EffectSoundName;

		public BattleEffectSound.BattleEffectSoundType PlayType;

		public bool IgnoreTimeScale = true;

		private bool started;

		public static LuaFunction PlayGlobalSESound
		{
			get
			{
				if (BattleEffectSound.playGlobalSESound == null && GameManager.LuaManager != null)
				{
					BattleEffectSound.playGlobalSESound = GameManager.LuaManager.GetFunction("PlayGlobalSESound", true);
				}
				return BattleEffectSound.playGlobalSESound;
			}
		}

		public static void Play(string soundName, bool ignoreTimeScale)
		{
			LuaFunction luaFunction = BattleEffectSound.PlayGlobalSESound;
			if (luaFunction != null)
			{
				if (ignoreTimeScale)
				{
					luaFunction.CallNoRet(new object[]
					{
						soundName
					});
				}
				else
				{
					AudioSource audioSource = luaFunction.Call(new object[]
					{
						soundName
					})[0] as AudioSource;
					SoundUtilities.SetTimeScaleable(audioSource, false);
				}
			}
		}

		public void Start()
		{
			if (this.PlayType == BattleEffectSound.BattleEffectSoundType.OnEnable)
			{
				BattleEffectSound.Play(this.EffectSoundName, this.IgnoreTimeScale);
			}
			this.started = true;
		}

		public void OnEnable()
		{
			if (this.started && this.PlayType == BattleEffectSound.BattleEffectSoundType.OnEnable)
			{
				BattleEffectSound.Play(this.EffectSoundName, this.IgnoreTimeScale);
			}
		}

		private void OnClick()
		{
			if (this.PlayType == BattleEffectSound.BattleEffectSoundType.OnClick)
			{
				BattleEffectSound.Play(this.EffectSoundName, this.IgnoreTimeScale);
			}
		}
	}
}
