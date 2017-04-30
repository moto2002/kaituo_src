using Assets.Scripts.Game.Global;
using Assets.Tools.Script.Caller;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using XQ.Framework.Lua.Utility;
using XQ.Framework.Utility.Debug;

namespace XQ.Framework.Lua.Start
{
	public class SceneStart : MonoBehaviour
	{
		public int DelayFrame;

		public bool DebugBattle;

		public bool DebugLoadOldUnit;

		[Header("测试Panel")]
		public string TestOpen;

		protected void Start()
		{
			Application.runInBackground = true;
			GlobalUniqueObject.Init();
			GameManager.ResManager.ClearMemory(false);
			if (this.DelayFrame == 0)
			{
				this.Load();
			}
			else
			{
				FrameCall.DelayFrame(new Action(this.Load), this.DelayFrame);
			}
		}

		protected void Load()
		{
			GameManager.InitEnd(false);
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			LuaUtil.CreatePanelSync(false, string.Format("{0}Panel", UnityEngine.SceneManagement.SceneManager.GetActiveScene().name), new object[0]);
			float realtimeSinceStartup2 = Time.realtimeSinceStartup;
			UDebug.Debug("c# create cost time: " + (realtimeSinceStartup2 - realtimeSinceStartup), new object[0]);
		}

		protected void OnDestroy()
		{
			GameManager.ResManager.ClearMemory(true);
		}
	}
}
