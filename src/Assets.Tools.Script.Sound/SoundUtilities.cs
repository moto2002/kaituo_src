using Assets.Tools.Script.File;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Assets.Tools.Script.Sound
{
	public static class SoundUtilities
	{
		public class SyncLoadAsset
		{
			private static string loadPath = string.Empty;

			private static WWW www = null;

			private static int retry = 1;

			public static T StarLoad<T>(string path) where T : UnityEngine.Object
			{
				T result;
				try
				{
					SoundUtilities.SyncLoadAsset.loadPath = path;
					UnityEngine.Object @object = null;
					while (@object == null)
					{
						foreach (UnityEngine.Object current in SoundUtilities.SyncLoadAsset.LoadWWW())
						{
							if (current != null)
							{
								@object = current;
							}
						}
						if (SoundUtilities.SyncLoadAsset.retry <= 0)
						{
							break;
						}
						if (@object != null)
						{
							break;
						}
						SoundUtilities.SyncLoadAsset.retry--;
					}
					SoundUtilities.SyncLoadAsset.Dispose();
					if (@object == null)
					{
						result = (T)((object)null);
					}
					else
					{
						result = (T)((object)@object);
					}
				}
				catch (Exception ex)
				{
					DebugConsole.Log(new object[]
					{
						ex
					});
					result = (T)((object)null);
				}
				return result;
			}

			[DebuggerHidden]
			public static IEnumerable<UnityEngine.Object> LoadWWW()
			{
				SoundUtilities.SyncLoadAsset.<LoadWWW>c__Iterator33 <LoadWWW>c__Iterator = new SoundUtilities.SyncLoadAsset.<LoadWWW>c__Iterator33();
				SoundUtilities.SyncLoadAsset.<LoadWWW>c__Iterator33 expr_07 = <LoadWWW>c__Iterator;
				expr_07.$PC = -2;
				return expr_07;
			}

			private static void Dispose()
			{
				if (SoundUtilities.SyncLoadAsset.www != null)
				{
					SoundUtilities.SyncLoadAsset.www.Dispose();
				}
				SoundUtilities.SyncLoadAsset.www = null;
			}
		}

		public static IGameVolume volumeCentre;

		private static Audio2DManager soundlistener;

		public static Audio2DManager Soundlistener
		{
			get
			{
				if (SoundUtilities.soundlistener == null)
				{
					SoundUtilities.soundlistener = Audio2DManager.Init();
				}
				return SoundUtilities.soundlistener;
			}
		}

		public static AudioSource PlaySound(AudioClip clip, float volume, bool loop, Action onEnd)
		{
			if (clip != null)
			{
				return SoundUtilities.Soundlistener.Play(clip, volume, 1f, loop, true, onEnd);
			}
			return null;
		}

		public static void SetTimeScaleable(AudioSource audioSource, bool ignoreTimeScale)
		{
			for (int i = 0; i < SoundUtilities.Soundlistener.PlayingList.Count; i++)
			{
				Audio2DManager.AduioData aduioData = SoundUtilities.Soundlistener.PlayingList[i];
				if (audioSource == aduioData.Source)
				{
					aduioData.IgnoreTimeScale = ignoreTimeScale;
					break;
				}
			}
		}

		public static void StopSound(AudioSource audioSource)
		{
			if (audioSource != null)
			{
				audioSource.Stop();
			}
		}

		public static void StopSound(string audioName)
		{
			SoundUtilities.StopSound(SoundUtilities.FindSound(audioName));
		}

		public static void PauseSound(AudioSource audioSource)
		{
			if (audioSource != null)
			{
				audioSource.Pause();
			}
		}

		public static void PauseSound(string audioName)
		{
			SoundUtilities.PauseSound(SoundUtilities.FindSound(audioName));
		}

		public static void UnPauseSound(AudioSource audioSource)
		{
			if (audioSource != null)
			{
				audioSource.UnPause();
			}
		}

		public static void UnPauseSound(string audioName)
		{
			SoundUtilities.UnPauseSound(SoundUtilities.FindSound(audioName));
		}

		public static AudioSource FindSound(string audioName)
		{
			if (audioName != null)
			{
				for (int i = 0; i < SoundUtilities.Soundlistener.PlayingList.Count; i++)
				{
					AudioSource source = SoundUtilities.Soundlistener.PlayingList[i].Source;
					if (source.clip != null && source.clip.name == audioName)
					{
						return source;
					}
				}
			}
			return null;
		}

		public static AudioClip LoadFromStreamingAssets(string path)
		{
			path = path.Replace("/", "\\");
			string text = string.Format("{0}{1}.wav", LoadPath.streamingAssetsPath, path);
			text = text.Replace("\\", "/");
			AudioClip audioClip = SoundUtilities.SyncLoadAsset.StarLoad<AudioClip>(text);
			if (audioClip == null || audioClip.length == 0f)
			{
				text = string.Format("{0}{1}.ogg", LoadPath.streamingAssetsPath, path);
				text = text.Replace("\\", "/");
				audioClip = SoundUtilities.SyncLoadAsset.StarLoad<AudioClip>(text);
			}
			if (audioClip == null || audioClip.length == 0f)
			{
				text = string.Format("{0}{1}.mp3", LoadPath.streamingAssetsPath, path);
				text = text.Replace("\\", "/");
				audioClip = SoundUtilities.SyncLoadAsset.StarLoad<AudioClip>(text);
			}
			return audioClip;
		}
	}
}
