using LuaInterface;
using System;
using UnityEngine;

namespace LuaFramework
{
	public class LuaManager : MonoBehaviour
	{
		private LuaState lua;

		private LuaLoader loader;

		private LuaLooper loop;

		private LuaFunction levelLoaded;

		public void Awake()
		{
			this.loader = new LuaLoader();
			this.lua = new LuaState();
			SetLuaGlobal.RegGlobal(this.lua);
			this.OpenLibs();
			this.lua.LuaSetTop(0);
			LuaBinder.Bind(this.lua);
			LuaCoroutine.Register(this.lua, this);
			this.Setup();
		}

		private void Setup()
		{
			this.InitLuaPath();
			this.InitLuaBundle();
			this.lua.Start();
		}

		public void StartRun()
		{
			this.StartMain();
			this.StartLooper();
		}

		private void StartLooper()
		{
			this.loop = base.gameObject.AddComponent<LuaLooper>();
			this.loop.luaState = this.lua;
		}

		private void StartMain()
		{
			try
			{
				this.lua.DoFile("main.lua");
				this.levelLoaded = this.lua.GetFunction("OnLevelWasLoaded", true);
				LuaFunction function = this.lua.GetFunction("Main", true);
				function.Call();
				function.Dispose();
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		private void OpenLibs()
		{
			this.lua.OpenLibs(new LuaCSFunction(LuaDLL.luaopen_struct));
			this.lua.OpenLibs(new LuaCSFunction(LuaDLL.luaopen_sproto_core));
			this.lua.OpenLibs(new LuaCSFunction(LuaDLL.luaopen_crypt));
			this.lua.OpenLibs(new LuaCSFunction(LuaDLL.luaopen_lpeg));
			this.lua.OpenLibs(new LuaCSFunction(LuaDLL.luaopen_bit));
			this.lua.OpenLibs(new LuaCSFunction(LuaDLL.luaopen_socket_core));
			this.OpenCJson();
		}

		protected void OpenCJson()
		{
			this.lua.LuaGetField(LuaIndexes.LUA_REGISTRYINDEX, "_LOADED");
			this.lua.OpenLibs(new LuaCSFunction(LuaDLL.luaopen_cjson));
			this.lua.LuaSetField(-2, "cjson");
			this.lua.OpenLibs(new LuaCSFunction(LuaDLL.luaopen_cjson_safe));
			this.lua.LuaSetField(-2, "cjson.safe");
		}

		private void InitLuaPath()
		{
		}

		private void InitLuaBundle()
		{
		}

		private void OnLevelLoaded(int level)
		{
			if (this.levelLoaded != null)
			{
				this.levelLoaded.BeginPCall();
				this.levelLoaded.Push(level);
				this.levelLoaded.PCall();
				this.levelLoaded.EndPCall();
			}
			if (this.lua != null)
			{
				this.lua.RefreshDelegateMap();
			}
		}

		public void ClearOldSceneLuaData()
		{
			this.OnLevelLoaded(0);
		}

		public object[] DoFile(string filename)
		{
			return this.lua.DoFile(filename);
		}

		public object[] CallFunction(string funcName, params object[] args)
		{
			LuaFunction function = this.lua.GetFunction(funcName, true);
			if (function != null)
			{
				return function.Call(args);
			}
			return null;
		}

		public LuaFunction GetFunction(string funcName, bool log = true)
		{
			return this.lua.GetFunction(funcName, log);
		}

		public LuaTable GetTable(string table, bool log = true)
		{
			return this.lua.GetTable(table, log);
		}

		public object[] DoString(string str)
		{
			return this.lua.DoString(str, "LuaState.cs");
		}

		public void LuaGC(bool gc_system = false)
		{
			if (null == this.lua)
			{
				if (gc_system)
				{
					GC.Collect();
				}
				return;
			}
			this.lua.LuaGC(LuaGCOptions.LUA_GCCOLLECT, 0);
			if (gc_system)
			{
				GC.Collect();
			}
		}

		public void Close()
		{
			if (this.levelLoaded != null)
			{
				this.levelLoaded.Dispose();
				this.levelLoaded = null;
			}
			this.loop.Destroy();
			this.loop = null;
			this.lua.Dispose();
			this.lua = null;
			this.loader = null;
		}
	}
}
