using Assets.Tools.Script.Caller;
using System;
using UnityEngine;
using XQ.Framework.Language;
using XQ.Framework.Lua;

namespace Assets.Scripts.Game
{
	public class LuaSetupTask : MonoBehaviour, IGameEntryTask
	{
		private static bool inited;

		public int Priority
		{
			get
			{
				return 15;
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

		private void Awake()
		{
			GameEntry.RegisterEntryTask(this);
		}

		public void StartTask()
		{
			if (!LuaSetupTask.inited)
			{
				LuaSetupTask.inited = true;
				this.SetTaskProgress(this, 0f, LanguageManager.GetLangText("cscode_luasetup_loading"));
				FrameCall.DelayFrame(new Action(GameManager.lua.SetupLua));
				FrameCall.DelayFrame(delegate
				{
					this.SetTaskProgress(this, 1f, LanguageManager.GetLangText("cscode_luasetup_loading"));
				}, 2);
			}
			else
			{
				this.SetTaskProgress(this, 1f, string.Empty);
			}
		}
	}
}
