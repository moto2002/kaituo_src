using Assets.Script.Mvc.Pool;
using Assets.Tools.Script.Helper;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Extends.EXNGUI.Compoment
{
	public class UIPlayTweenGroup : MonoBehaviour
	{
		private class TweenGroupWatcher
		{
			public readonly EventDelegate Delegate;

			public Action OnEndCallBack;

			public int PlayingCount;

			public bool IsPlaying;

			public Pool<UIPlayTweenGroup.TweenGroupWatcher> Pool;

			public List<UIPlayTweenGroup.TweenGroupWatcher> PlayingList;

			public int Group = -1;

			public TweenGroupWatcher()
			{
				this.Delegate = new EventDelegate(new EventDelegate.Callback(this.OnOneTweenPlayEnd));
				this.Delegate.oneShot = true;
			}

			public void CheckEnd()
			{
				if (this.PlayingCount == 0 && this.IsPlaying)
				{
					this.OnPlayEnd();
				}
			}

			public void Clear()
			{
				this.OnEndCallBack = null;
			}

			private void OnOneTweenPlayEnd()
			{
				this.PlayingCount--;
				this.CheckEnd();
			}

			private void OnPlayEnd()
			{
				Action onEndCallBack = this.OnEndCallBack;
				if (onEndCallBack != null)
				{
					this.IsPlaying = false;
					this.OnEndCallBack = null;
					onEndCallBack();
				}
				this.PlayingList.Remove(this);
				this.Pool.ReturnInstance(this);
			}
		}

		private static Dictionary<UIPlayTweenGroup, bool> allUIPlayTweenGroup = new Dictionary<UIPlayTweenGroup, bool>();

		public bool IncludeChildren;

		public int Group;

		private List<UITweener> tweeners = new List<UITweener>();

		private List<UIPlayTweenGroup.TweenGroupWatcher> playingList = new List<UIPlayTweenGroup.TweenGroupWatcher>();

		private Pool<UIPlayTweenGroup.TweenGroupWatcher> delegatePool = new Pool<UIPlayTweenGroup.TweenGroupWatcher>();

		public static void StopAllTweenGroup()
		{
			foreach (UIPlayTweenGroup current in UIPlayTweenGroup.allUIPlayTweenGroup.Keys)
			{
				current.Stop();
			}
		}

		private void Awake()
		{
			this.delegatePool.MaxCount = 100;
			UIPlayTweenGroup.allUIPlayTweenGroup.Add(this, true);
			this.RefreshTweener();
		}

		private void OnDestroy()
		{
			UIPlayTweenGroup.allUIPlayTweenGroup.Remove(this);
		}

		public void RefreshTweener()
		{
			this.tweeners.Clear();
			if (this.IncludeChildren)
			{
				base.transform.ForEachAllChildren(delegate(Transform t)
				{
					UITweener[] components = t.GetComponents<UITweener>();
					if (components != null)
					{
						this.tweeners.AddRange(components);
					}
					return true;
				});
			}
			else
			{
				this.tweeners.AddRange(base.GetComponents<UITweener>());
			}
		}

		public bool HasGroup(int group)
		{
			for (int i = 0; i < this.tweeners.Count; i++)
			{
				UITweener uITweener = this.tweeners[i];
				if (uITweener.tweenGroup == group)
				{
					return true;
				}
			}
			return false;
		}

		public void PlayWithEnd(int group, Action onEnd)
		{
			this.Group = group;
			if (onEnd == null)
			{
				this.PlayCurrGroup();
			}
			else
			{
				this.PlayCurrGroup(onEnd);
			}
		}

		public void Play(int group)
		{
			this.Group = group;
			this.PlayCurrGroup();
		}

		public void Stop()
		{
			for (int i = this.tweeners.Count - 1; i >= 0; i--)
			{
				UITweener uITweener = this.tweeners[i];
				if (uITweener.tweenGroup != 0)
				{
					uITweener.onFinished.Clear();
					uITweener.ResetToBeginning();
					uITweener.enabled = false;
				}
			}
			for (int j = this.playingList.Count - 1; j >= 0; j--)
			{
				UIPlayTweenGroup.TweenGroupWatcher tweenGroupWatcher = this.playingList[j];
				if (tweenGroupWatcher.Group != 0)
				{
					tweenGroupWatcher.Clear();
					this.delegatePool.ReturnInstance(tweenGroupWatcher);
					this.playingList.RemoveAt(j);
				}
			}
		}

		public void Stop(int group)
		{
			for (int i = this.tweeners.Count - 1; i >= 0; i--)
			{
				UITweener uITweener = this.tweeners[i];
				if (uITweener.tweenGroup == this.Group)
				{
					uITweener.onFinished.Clear();
					uITweener.ResetToBeginning();
					uITweener.enabled = false;
				}
			}
			for (int j = this.playingList.Count - 1; j >= 0; j--)
			{
				UIPlayTweenGroup.TweenGroupWatcher tweenGroupWatcher = this.playingList[j];
				if (tweenGroupWatcher.Group == group)
				{
					tweenGroupWatcher.Clear();
					this.delegatePool.ReturnInstance(tweenGroupWatcher);
					this.playingList.RemoveAt(j);
				}
			}
		}

		public void Play()
		{
			this.PlayCurrGroup();
		}

		private void PlayCurrGroup(Action onEnd)
		{
			UIPlayTweenGroup.TweenGroupWatcher instance = this.delegatePool.GetInstance();
			instance.IsPlaying = false;
			instance.Pool = this.delegatePool;
			instance.PlayingList = this.playingList;
			instance.Group = this.Group;
			instance.OnEndCallBack = onEnd;
			instance.PlayingCount = 0;
			this.playingList.Add(instance);
			for (int i = this.tweeners.Count - 1; i >= 0; i--)
			{
				UITweener uITweener = this.tweeners[i];
				if (uITweener.tweenGroup == this.Group && uITweener.gameObject.activeInHierarchy)
				{
					instance.PlayingCount++;
					uITweener.AddOnFinished(instance.Delegate);
					uITweener.ResetToBeginning();
					uITweener.enabled = true;
					uITweener.PlayForward();
				}
			}
			instance.IsPlaying = true;
			instance.CheckEnd();
		}

		private void PlayCurrGroup()
		{
			for (int i = this.tweeners.Count - 1; i >= 0; i--)
			{
				UITweener uITweener = this.tweeners[i];
				if (uITweener.tweenGroup == this.Group && uITweener.gameObject.activeInHierarchy)
				{
					uITweener.ResetToBeginning();
					uITweener.enabled = true;
					uITweener.PlayForward();
				}
			}
		}
	}
}
