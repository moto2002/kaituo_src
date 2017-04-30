using System;
using UnityEngine;
using XQ.Framework.Language;

namespace Assets.Scripts.Game
{
	public class LuaEntry : MonoBehaviour, IGameEntryTask
	{
		public static LuaEntry Instance;

		public GameObject LuaRoot;

		public int Priority
		{
			get
			{
				return 10;
			}
		}

		public int Weight
		{
			get
			{
				return 20;
			}
		}

		public Action<IGameEntryTask, float, string> SetTaskProgress
		{
			get;
			set;
		}

		protected void Start()
		{
			LuaEntry.Instance = this;
			GameEntry.RegisterEntryTask(this);
		}

		protected void OnDestroy()
		{
			LuaEntry.Instance = null;
		}

		public void StartTask()
		{
			this.SetTaskProgress(this, 0f, LanguageManager.GetLangText("cscode_luaentry_systeminit"));
			base.Invoke("StartLua", 0.03f);
		}

		public void SetProgress(float progress, string label)
		{
			this.SetTaskProgress(this, progress, label);
		}

		private void StartLua()
		{
			this.SetTaskProgress(this, 0f, LanguageManager.GetLangText("cscode_luaentry_systeminit"));
			this.LuaRoot.gameObject.SetActive(true);
		}
	}
}
