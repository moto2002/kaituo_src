using Assets.Scripts.Game;
using Assets.Tools.Script.Caller;
using System;
using UnityEngine;
using XQ.Framework.Language;
using XQ.Framework.Lua;

namespace XQ.Framework.Loading
{
	public class SdkInitTask : MonoBehaviour, IGameEntryTask
	{
		private Action action;

		public int Priority
		{
			get
			{
				return 510;
			}
		}

		public int Weight
		{
			get
			{
				return 10;
			}
		}

		public Action<IGameEntryTask, float, string> SetTaskProgress
		{
			get;
			set;
		}

		public void StartTask()
		{
			GameManager.Progress = new GameManager.ProgressInfo
			{
				progress = 0f,
				tip = LanguageManager.GetLangText("Init_SDK")
			};
			FrameCall.DelayFrame(delegate
			{
				SdkCallbackManager.CallSdk("initSDK", new object[0]);
			}, 1);
			this.action = delegate
			{
				GameManager.Progress = new GameManager.ProgressInfo
				{
					progress = 1f,
					tip = LanguageManager.GetLangText("Init_SDK")
				};
			};
			base.enabled = true;
		}

		private void Awake()
		{
			SdkCallbackManager.SetSDKCallBack("SDK_INIT", new SDK_CALLBACK(this.InitSDK));
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

		public void InitSDK(params object[] args)
		{
			bool flag = (bool)args[0];
			if (flag)
			{
				this.action();
			}
			else
			{
				MessageTip.Tip(LanguageManager.GetLangText("Init_SDK_Failed"));
			}
		}
	}
}
