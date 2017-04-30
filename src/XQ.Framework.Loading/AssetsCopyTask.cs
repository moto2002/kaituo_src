using Assets.Scripts.Game;
using System;
using UnityEngine;
using XQ.Framework.Language;
using XQ.Framework.Lua;
using XQ.Framework.Lua.Utility;

namespace XQ.Framework.Loading
{
	public class AssetsCopyTask : MonoBehaviour, IGameEntryTask
	{
		private Action action;

		public int Priority
		{
			get
			{
				return 500;
			}
		}

		public int Weight
		{
			get
			{
				return 80;
			}
		}

		public Action<IGameEntryTask, float, string> SetTaskProgress
		{
			get;
			set;
		}

		public void StartTask()
		{
			this.action = GameManager.InitFileCopy(new Action<int, float, string>(this.CopyProgress));
			base.enabled = true;
		}

		private void Awake()
		{
			ProgressCallbackImpl progressCallbackImpl = new ProgressCallbackImpl();
			UtilHelper.helper.CallStatic("setCopyAssetsCallback", new object[]
			{
				progressCallbackImpl
			});
			progressCallbackImpl.progressCB = new Action<int, float, string>(this.CopyProgress);
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

		public void CopyProgress(int len, float progress, string err)
		{
			if (err != null && err == "FULL")
			{
				MessageTip.Tip(LanguageManager.GetLangText("DiskSpace_Full"));
				return;
			}
			GameManager.Progress = new GameManager.ProgressInfo
			{
				progress = progress / (float)len,
				tip = string.Format(LanguageManager.GetLangText("Loading_Copy") + "({0}/{1})", progress, len)
			};
			if ((float)len == progress || err == "_FINISH_")
			{
				if (this.action != null)
				{
					this.action();
				}
				else
				{
					GameManager.Progress = new GameManager.ProgressInfo
					{
						progress = 1f
					};
				}
			}
		}
	}
}
