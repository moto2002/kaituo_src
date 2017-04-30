using LuaInterface;
using System;
using UnityEngine;
using XQ.Framework.Lua.Utility;

public class XQ_Framework_Lua_Utility_LuaUtilWrap
{
	public static void Register(LuaState L)
	{
		L.BeginStaticLibs("LuaUtil");
		L.RegFunction("GetNetInfo", new LuaCSFunction(XQ_Framework_Lua_Utility_LuaUtilWrap.GetNetInfo));
		L.RegFunction("GetSystemTime", new LuaCSFunction(XQ_Framework_Lua_Utility_LuaUtilWrap.GetSystemTime));
		L.RegFunction("GetAppPath", new LuaCSFunction(XQ_Framework_Lua_Utility_LuaUtilWrap.GetAppPath));
		L.RegFunction("DelFile", new LuaCSFunction(XQ_Framework_Lua_Utility_LuaUtilWrap.DelFile));
		L.RegFunction("LoadScene", new LuaCSFunction(XQ_Framework_Lua_Utility_LuaUtilWrap.LoadScene));
		L.RegFunction("LoadControl", new LuaCSFunction(XQ_Framework_Lua_Utility_LuaUtilWrap.LoadControl));
		L.RegFunction("CreatePanelAsync", new LuaCSFunction(XQ_Framework_Lua_Utility_LuaUtilWrap.CreatePanelAsync));
		L.RegFunction("CreatePanelSync", new LuaCSFunction(XQ_Framework_Lua_Utility_LuaUtilWrap.CreatePanelSync));
		L.RegFunction("LoadResource", new LuaCSFunction(XQ_Framework_Lua_Utility_LuaUtilWrap.LoadResource));
		L.RegFunction("IsDestroy", new LuaCSFunction(XQ_Framework_Lua_Utility_LuaUtilWrap.IsDestroy));
		L.RegFunction("AddEventListener", new LuaCSFunction(XQ_Framework_Lua_Utility_LuaUtilWrap.AddEventListener));
		L.RegFunction("NewLuaTable", new LuaCSFunction(XQ_Framework_Lua_Utility_LuaUtilWrap.NewLuaTable));
		L.RegFunction("GetDataFiles", new LuaCSFunction(XQ_Framework_Lua_Utility_LuaUtilWrap.GetDataFiles));
		L.RegFunction("GetDataMonoFile", new LuaCSFunction(XQ_Framework_Lua_Utility_LuaUtilWrap.GetDataMonoFile));
		L.EndStaticLibs();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetNetInfo(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			bool netInfo = LuaUtil.GetNetInfo();
			LuaDLL.lua_pushboolean(L, netInfo);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetSystemTime(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			double systemTime = LuaUtil.GetSystemTime();
			LuaDLL.lua_pushnumber(L, systemTime);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetAppPath(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string path = ToLua.CheckString(L, 1);
			string appPath = LuaUtil.GetAppPath(path);
			LuaDLL.lua_pushstring(L, appPath);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DelFile(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string path = ToLua.CheckString(L, 1);
			bool value = LuaUtil.DelFile(path);
			LuaDLL.lua_pushboolean(L, value);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LoadScene(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			bool additive = LuaDLL.luaL_checkboolean(L, 1);
			string sceneName = ToLua.CheckString(L, 2);
			LuaFunction callback = ToLua.CheckLuaFunction(L, 3);
			object[] args = ToLua.ToParamsObject(L, 4, num - 3);
			LuaUtil.LoadScene(additive, sceneName, callback, args);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LoadControl(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			string controlName = ToLua.CheckString(L, 1);
			object[] args = ToLua.ToParamsObject(L, 2, num - 1);
			LuaUtil.LoadControl(controlName, args);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CreatePanelAsync(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			bool isGridItem = LuaDLL.luaL_checkboolean(L, 1);
			LuaFunction callback = ToLua.CheckLuaFunction(L, 2);
			string panelName = ToLua.CheckString(L, 3);
			object[] arg = ToLua.ToParamsObject(L, 4, num - 3);
			LuaUtil.CreatePanelAsync(isGridItem, callback, panelName, arg);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CreatePanelSync(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			bool isGridItem = LuaDLL.luaL_checkboolean(L, 1);
			string panelName = ToLua.CheckString(L, 2);
			object[] arg = ToLua.ToParamsObject(L, 3, num - 2);
			LuaTable lbr = LuaUtil.CreatePanelSync(isGridItem, panelName, arg);
			ToLua.Push(L, lbr);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LoadResource(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 5);
			bool instantiate = LuaDLL.luaL_checkboolean(L, 1);
			string name = ToLua.CheckString(L, 2);
			GameObject useObject = (GameObject)ToLua.CheckUnityObject(L, 3, typeof(GameObject));
			LuaFunction callBack = ToLua.CheckLuaFunction(L, 4);
			bool lifeFollowUseObject = LuaDLL.luaL_checkboolean(L, 5);
			UnityEngine.Object obj = LuaUtil.LoadResource(instantiate, name, useObject, callBack, lifeFollowUseObject);
			ToLua.Push(L, obj);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsDestroy(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			object obj = ToLua.ToVarObject(L, 1);
			bool value = LuaUtil.IsDestroy(obj);
			LuaDLL.lua_pushboolean(L, value);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddEventListener(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			LuaTable table = ToLua.CheckLuaTable(L, 1);
			GameObject gameObject = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			string eventSuffix = ToLua.CheckString(L, 3);
			LuaUtil.AddEventListener(table, gameObject, eventSuffix);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int NewLuaTable(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			bool isGrid = LuaDLL.luaL_checkboolean(L, 1);
			string tableName = ToLua.CheckString(L, 2);
			GameObject parent = (GameObject)ToLua.CheckUnityObject(L, 3, typeof(GameObject));
			LuaTable lbr = LuaUtil.NewLuaTable(isGrid, tableName, parent);
			ToLua.Push(L, lbr);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetDataFiles(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			string path = ToLua.CheckString(L, 1);
			string filter = ToLua.CheckString(L, 2);
			bool isLang = LuaDLL.luaL_checkboolean(L, 3);
			string[] dataFiles = LuaUtil.GetDataFiles(path, filter, isLang);
			ToLua.Push(L, dataFiles);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetDataMonoFile(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			string path = ToLua.CheckString(L, 1);
			string name = ToLua.CheckString(L, 2);
			bool isLang = LuaDLL.luaL_checkboolean(L, 3);
			string dataMonoFile = LuaUtil.GetDataMonoFile(path, name, isLang);
			LuaDLL.lua_pushstring(L, dataMonoFile);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
