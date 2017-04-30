using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;
using XQ.Framework.Data;

namespace XQ.Framework.Lua
{
	public class Scenes : MonoBehaviour
	{
		private string sceneName;

		private bool isSceneControlLogic;

		private readonly List<string> refLuaTable = new List<string>();

		private void OnDestroy()
		{
			SceneManager.manager.sceneRef.Remove(this.sceneName);
			this.refLuaTable.ForEach(delegate(string r)
			{
				ResourceRef resRef = GameManager.GetResRef(r, null, true);
				if (this.isSceneControlLogic)
				{
					LuaTableInfo luaTableInfo = resRef.GetLuaTableInfo(this.sceneName);
					if (null != luaTableInfo.Table)
					{
						LuaFunction luaFunction = luaTableInfo.Table.RawGetLuaFunction("Dispose");
						if (null != luaFunction)
						{
							luaFunction.Call();
							luaFunction.Dispose();
							ResourceManager.Dispose(r, r);
						}
					}
					else
					{
						ResourceManager.Dispose(r, r);
					}
				}
				else
				{
					LuaTableInfo luaTableInfo2 = resRef.GetLuaTableInfo(r);
					if (null != luaTableInfo2.Table)
					{
						LuaFunction luaFunction2 = luaTableInfo2.Table.RawGetLuaFunction("Dispose");
						if (null != luaFunction2)
						{
							luaFunction2.Call();
							luaFunction2.Dispose();
							ResourceManager.Dispose(r, r);
						}
					}
					else
					{
						ResourceManager.Dispose(r, r);
					}
				}
			});
			this.refLuaTable.Clear();
		}

		public void Init(string scene, LuaFunction callback, params object[] args)
		{
			this.sceneName = scene;
			callback.CallNoRet(args);
			callback.Dispose();
		}

		public void Init(string scene, string controlName, params object[] args)
		{
			this.sceneName = scene;
			ResourceManager.CallFunction(controlName, controlName, "Init", args);
			this.refLuaTable.Add(controlName);
		}

		public void Init(string scene, params object[] args)
		{
			this.sceneName = scene;
			this.isSceneControlLogic = true;
			List<string> sceneRefLogicFiles = GameManager.GetSceneRefLogicFiles(this.sceneName);
			if (sceneRefLogicFiles == null)
			{
				return;
			}
			Dictionary<string, object> argDic = null;
			if (args != null)
			{
				argDic = new Dictionary<string, object>();
				for (int i = 0; i < args.Length; i++)
				{
					object obj = args[i];
					if (obj is string)
					{
						argDic.Add(obj.ToString(), args[++i]);
					}
				}
			}
			sceneRefLogicFiles.ForEach(delegate(string r)
			{
				if (argDic != null && argDic.ContainsKey(r))
				{
					ResourceManager.CallFunction(scene, r, "Init", new object[]
					{
						argDic[r]
					});
				}
				else
				{
					ResourceManager.CallFunction(scene, r, "Init", new object[0]);
				}
				this.refLuaTable.Add(r);
			});
		}
	}
}
