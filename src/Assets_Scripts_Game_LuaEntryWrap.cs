using Assets.Scripts.Game;
using LuaInterface;
using System;
using UnityEngine;

public class Assets_Scripts_Game_LuaEntryWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(LuaEntry), typeof(MonoBehaviour), null);
		L.RegFunction("StartTask", new LuaCSFunction(Assets_Scripts_Game_LuaEntryWrap.StartTask));
		L.RegFunction("SetProgress", new LuaCSFunction(Assets_Scripts_Game_LuaEntryWrap.SetProgress));
		L.RegFunction("__eq", new LuaCSFunction(Assets_Scripts_Game_LuaEntryWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("Instance", new LuaCSFunction(Assets_Scripts_Game_LuaEntryWrap.get_Instance), new LuaCSFunction(Assets_Scripts_Game_LuaEntryWrap.set_Instance));
		L.RegVar("LuaRoot", new LuaCSFunction(Assets_Scripts_Game_LuaEntryWrap.get_LuaRoot), new LuaCSFunction(Assets_Scripts_Game_LuaEntryWrap.set_LuaRoot));
		L.RegVar("Priority", new LuaCSFunction(Assets_Scripts_Game_LuaEntryWrap.get_Priority), null);
		L.RegVar("Weight", new LuaCSFunction(Assets_Scripts_Game_LuaEntryWrap.get_Weight), null);
		L.RegVar("SetTaskProgress", new LuaCSFunction(Assets_Scripts_Game_LuaEntryWrap.get_SetTaskProgress), new LuaCSFunction(Assets_Scripts_Game_LuaEntryWrap.set_SetTaskProgress));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int StartTask(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			LuaEntry luaEntry = (LuaEntry)ToLua.CheckObject(L, 1, typeof(LuaEntry));
			luaEntry.StartTask();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetProgress(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			LuaEntry luaEntry = (LuaEntry)ToLua.CheckObject(L, 1, typeof(LuaEntry));
			float progress = (float)LuaDLL.luaL_checknumber(L, 2);
			string label = ToLua.CheckString(L, 3);
			luaEntry.SetProgress(progress, label);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int op_Equality(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Object x = (UnityEngine.Object)ToLua.ToObject(L, 1);
			UnityEngine.Object y = (UnityEngine.Object)ToLua.ToObject(L, 2);
			bool value = x == y;
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
	private static int get_Instance(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, LuaEntry.Instance);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_LuaRoot(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LuaEntry luaEntry = (LuaEntry)obj;
			GameObject luaRoot = luaEntry.LuaRoot;
			ToLua.Push(L, luaRoot);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index LuaRoot on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Priority(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LuaEntry luaEntry = (LuaEntry)obj;
			int priority = luaEntry.Priority;
			LuaDLL.lua_pushinteger(L, priority);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Priority on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Weight(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LuaEntry luaEntry = (LuaEntry)obj;
			int weight = luaEntry.Weight;
			LuaDLL.lua_pushinteger(L, weight);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Weight on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_SetTaskProgress(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LuaEntry luaEntry = (LuaEntry)obj;
			Action<IGameEntryTask, float, string> setTaskProgress = luaEntry.SetTaskProgress;
			ToLua.Push(L, setTaskProgress);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index SetTaskProgress on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Instance(IntPtr L)
	{
		int result;
		try
		{
			LuaEntry instance = (LuaEntry)ToLua.CheckUnityObject(L, 2, typeof(LuaEntry));
			LuaEntry.Instance = instance;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_LuaRoot(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LuaEntry luaEntry = (LuaEntry)obj;
			GameObject luaRoot = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			luaEntry.LuaRoot = luaRoot;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index LuaRoot on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_SetTaskProgress(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LuaEntry luaEntry = (LuaEntry)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Action<IGameEntryTask, float, string> setTaskProgress;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				setTaskProgress = (Action<IGameEntryTask, float, string>)ToLua.CheckObject(L, 2, typeof(Action<IGameEntryTask, float, string>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				setTaskProgress = (DelegateFactory.CreateDelegate(typeof(Action<IGameEntryTask, float, string>), func) as Action<IGameEntryTask, float, string>);
			}
			luaEntry.SetTaskProgress = setTaskProgress;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index SetTaskProgress on a nil value");
		}
		return result;
	}
}
