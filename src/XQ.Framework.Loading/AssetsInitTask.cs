using Assets.Scripts.Game;
using System;
using UnityEngine;
using XQ.Framework.Lua;

namespace XQ.Framework.Loading
{
	public class AssetsInitTask : MonoBehaviour, IGameEntryTask
	{
		private Action action;

		public int Priority
		{
			get
			{
				return 480;
			}
		}

		public int Weight
		{
			get
			{
				return 50;
			}
		}

		public Action<IGameEntryTask, float, string> SetTaskProgress
		{
			get;
			set;
		}

		public void StartTask()
		{
			this.action = GameManager.InitAssets(new Action(this.CallBack));
			base.enabled = true;
		}

		private void Awake()
		{
			GameEntry.RegisterEntryTask(this);
			base.enabled = false;
		}

		private void Update()
		{
			GameManager.ProgressInfo progress = GameManager.Progress;
			this.SetTaskProgress(this, progress.progress, (progress.progress != 1f) ? progress.tip : string.Empty);
			if (progress.progress == 1f)
			{
				base.enabled = false;
			}
		}

		private void CallBack()
		{
			this.action();
		}
	}
}
