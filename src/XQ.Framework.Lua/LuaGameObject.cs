using LuaFramework;
using System;
using UnityEngine;
using XQ.Framework.Network.Skynet;

namespace XQ.Framework.Lua
{
	public class LuaGameObject : MonoBehaviour
	{
		protected void Awake()
		{
			base.gameObject.AddComponent<MainThreadExec>();
			GameManager.ResManager = base.gameObject.AddComponent<ResourceManager>();
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}

		protected void OnDestroy()
		{
			GameManager.ExitGame = true;
			if (GameManager.LuaManager)
			{
				GameManager.LuaManager.Close();
			}
			SocketDriver.Stop();
		}

		public void InitLuaSystemFile()
		{
			if (GameManager.LuaManager == null)
			{
				this.SetupLua();
			}
			GameManager.LuaManager.StartRun();
			GameManager.SceneManager = base.gameObject.AddComponent<SceneManager>();
		}

		public void SetupLua()
		{
			GameManager.LuaManager = base.gameObject.AddComponent<LuaManager>();
		}
	}
}
