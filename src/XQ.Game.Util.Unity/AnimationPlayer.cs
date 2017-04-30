using Assets.Extends.EXNGUI.Compoment;
using Assets.Script.Mvc.Pool;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace XQ.Game.Util.Unity
{
	public class AnimationPlayer : MonoBehaviour
	{
		private static Pool<AnimationPlayerEndCallBack> callBackPool = new Pool<AnimationPlayerEndCallBack>();

		private static Dictionary<AnimationPlayer, bool> allAnimationPlayers = new Dictionary<AnimationPlayer, bool>();

		[HideInInspector]
		public bool ShowChildrenLabel;

		[HideInInspector]
		public Animation Animation;

		[HideInInspector]
		public UIPlayTweenGroup TweenGroup;

		[HideInInspector]
		public List<AnimationPlayerGroupName> TweenGroupNames;

		private Dictionary<string, int> tweenGroupMap;

		private List<AnimationPlayerEndCallBack> delayCalls = new List<AnimationPlayerEndCallBack>(2);

		public static void StopAllAnimationPlayer()
		{
			foreach (AnimationPlayer current in AnimationPlayer.allAnimationPlayers.Keys)
			{
				current.Stop();
			}
		}

		private void Awake()
		{
			this.tweenGroupMap = new Dictionary<string, int>(this.TweenGroupNames.Count);
			for (int i = this.TweenGroupNames.Count - 1; i >= 0; i--)
			{
				AnimationPlayerGroupName animationPlayerGroupName = this.TweenGroupNames[i];
				this.tweenGroupMap.Add(animationPlayerGroupName.Name, animationPlayerGroupName.Group);
			}
			AnimationPlayer.allAnimationPlayers.Add(this, true);
		}

		private void OnDestroy()
		{
			AnimationPlayer.allAnimationPlayers.Remove(this);
		}

		public void PlayWithEnd(string animName, Action onEnd)
		{
			if (this.Animation != null)
			{
				this.PlayWithEndAnim(animName, onEnd);
			}
			else
			{
				this.PlayWithEndTween(animName, onEnd);
			}
		}

		public void Play(string animName)
		{
			if (this.Animation != null)
			{
				this.PlayAnim(animName);
			}
			else
			{
				this.PlayTween(animName, null);
			}
		}

		public void Stop()
		{
			if (this.Animation != null)
			{
				if (this.Animation.clip != null)
				{
					this.Animation.Stop(this.Animation.clip.name);
				}
			}
			else if (this.TweenGroup != null)
			{
				this.TweenGroup.Stop();
			}
			for (int i = this.delayCalls.Count - 1; i >= 0; i--)
			{
				AnimationPlayerEndCallBack animationPlayerEndCallBack = this.delayCalls[i];
				animationPlayerEndCallBack.Clear(false);
			}
		}

		public void Stop(string animName)
		{
			if (this.Animation != null)
			{
				if (this.Animation.clip != null)
				{
					this.Animation.Stop(animName);
				}
			}
			else if (this.TweenGroup != null)
			{
				int group;
				bool flag = this.tweenGroupMap.TryGetValue(animName, out group);
				if (flag)
				{
					this.TweenGroup.Stop(group);
				}
			}
			for (int i = this.delayCalls.Count - 1; i >= 0; i--)
			{
				AnimationPlayerEndCallBack animationPlayerEndCallBack = this.delayCalls[i];
				if (animationPlayerEndCallBack.Name == animName)
				{
					animationPlayerEndCallBack.Clear(false);
				}
			}
		}

		public bool Has(string animName)
		{
			if (this.Animation != null)
			{
				return this.Animation.GetClip(animName) != null;
			}
			return this.tweenGroupMap.ContainsKey(animName);
		}

		private void PlayWithEndAnim(string animName, Action onEnd)
		{
			float delay = this.PlayAnim(animName);
			this.DelayEnd(animName, delay, onEnd);
		}

		private float PlayAnim(string animName)
		{
			this.Animation.Stop();
			AnimationClip clip = this.Animation.GetClip(animName);
			if (clip == null)
			{
				return 0f;
			}
			float result = 0f;
			if (clip.wrapMode != WrapMode.Loop)
			{
				result = clip.length;
			}
			this.Animation.clip = clip;
			this.Animation.Play();
			return result;
		}

		private void PlayWithEndTween(string animName, Action onEnd)
		{
			this.PlayTween(animName, onEnd);
		}

		private void PlayTween(string animName, Action onEnd)
		{
			int group;
			bool flag = this.tweenGroupMap.TryGetValue(animName, out group);
			if (flag)
			{
				if (this.TweenGroup == null)
				{
					this.TweenGroup = base.gameObject.AddComponent<UIPlayTweenGroup>();
					this.TweenGroup.IncludeChildren = true;
					this.TweenGroup.RefreshTweener();
				}
				this.TweenGroup.PlayWithEnd(group, onEnd);
			}
		}

		private void DelayEnd(string animName, float delay, Action onEnd)
		{
			AnimationPlayerEndCallBack instance = AnimationPlayer.callBackPool.GetInstance();
			instance.DelayEnd(animName, delay, onEnd, this.delayCalls, AnimationPlayer.callBackPool);
		}
	}
}
