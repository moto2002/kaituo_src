using Assets.Script.Mvc.Pool;
using Assets.Tools.Script.Go;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Tools.Script.Sound
{
	public class Audio2DManager : MonoBehaviour
	{
		public class AduioData
		{
			public AudioSource Source;

			public Action OnEnd;

			public float Pitch;

			public bool IgnoreTimeScale;

			public void Dispose()
			{
				UnityEngine.Object.Destroy(this.Source);
			}

			public Audio2DManager.AduioData Create()
			{
				this.Source = Audio2DManager.Audio2DManagerRoot.AddComponent<AudioSource>();
				return this;
			}
		}

		public class AudioSourcePool : Pool<Audio2DManager.AduioData>
		{
			public AudioSourcePool()
			{
				this.MaxCount = 20;
			}

			protected override object CreateObject()
			{
				return new Audio2DManager.AduioData().Create();
			}
		}

		public static GameObject Audio2DManagerRoot;

		public AudioListener Listener;

		public List<Audio2DManager.AduioData> PlayingList = new List<Audio2DManager.AduioData>();

		private Audio2DManager.AudioSourcePool audioSourcePool = new Audio2DManager.AudioSourcePool();

		public static Audio2DManager Init()
		{
			Audio2DManager secondaryHost = ParasiticComponent.GetSecondaryHost<Audio2DManager>("Audio2DManager");
			Audio2DManager.Audio2DManagerRoot = secondaryHost.gameObject;
			secondaryHost.Listener = Audio2DManager.Audio2DManagerRoot.AddComponent<AudioListener>();
			return secondaryHost;
		}

		private void Awake()
		{
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}

		public AudioSource Play(AudioClip clip, float volume, float pitch, bool loop, bool ignoreTimeScale, Action onEnd)
		{
			Audio2DManager.AduioData instance = this.audioSourcePool.GetInstance();
			instance.IgnoreTimeScale = ignoreTimeScale;
			instance.OnEnd = onEnd;
			instance.Pitch = pitch;
			AudioSource source = instance.Source;
			source.pitch = ((!ignoreTimeScale) ? (pitch * Time.timeScale) : pitch);
			source.clip = clip;
			source.volume = volume;
			source.loop = loop;
			source.Play();
			this.PlayingList.Add(instance);
			return source;
		}

		private void Update()
		{
			for (int i = this.PlayingList.Count - 1; i >= 0; i--)
			{
				Audio2DManager.AduioData aduioData = this.PlayingList[i];
				if (!aduioData.IgnoreTimeScale)
				{
					aduioData.Source.pitch = aduioData.Pitch * Time.timeScale;
				}
				if (!aduioData.Source.isPlaying)
				{
					aduioData.Source.clip = null;
					if (aduioData.OnEnd != null)
					{
						aduioData.OnEnd();
					}
					this.PlayingList.RemoveAt(i);
					if (!this.audioSourcePool.ReturnInstance(aduioData))
					{
						aduioData.Dispose();
					}
				}
			}
		}
	}
}
