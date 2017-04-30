using Assets.Tools.Script.Caller;
using System;
using UnityEngine;
using XQ.Framework.Language;

namespace Assets.Scripts.Game.Global
{
	public class GlobalObjectTask : MonoBehaviour, IGameEntryTask
	{
		public int Priority
		{
			get
			{
				return 495;
			}
		}

		public int Weight
		{
			get
			{
				return 1;
			}
		}

		public Action<IGameEntryTask, float, string> SetTaskProgress
		{
			get;
			set;
		}

		public void StartTask()
		{
			FrameCall.DelayFrame(delegate
			{
				GlobalUniqueObject.Init();
			});
			FrameCall.DelayFrame(delegate
			{
				this.SetTaskProgress(this, 1f, LanguageManager.GetLangText("cscode_luaentry_systeminit"));
			}, 3);
		}

		private void Awake()
		{
			GameEntry.RegisterEntryTask(this);
		}
	}
}
