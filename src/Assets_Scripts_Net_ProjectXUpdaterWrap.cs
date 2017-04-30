using Assets.Scripts.Game;
using Assets.Scripts.Net;
using LuaInterface;
using System;
using UnityEngine;
using XQ.Framework.Lua.Utility;

public class Assets_Scripts_Net_ProjectXUpdaterWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(ProjectXUpdater), typeof(MonoBehaviour), null);
		L.RegFunction("Start", new LuaCSFunction(Assets_Scripts_Net_ProjectXUpdaterWrap.Start));
		L.RegFunction("StartUpdate", new LuaCSFunction(Assets_Scripts_Net_ProjectXUpdaterWrap.StartUpdate));
		L.RegFunction("StartTask", new LuaCSFunction(Assets_Scripts_Net_ProjectXUpdaterWrap.StartTask));
		L.RegFunction("__eq", new LuaCSFunction(Assets_Scripts_Net_ProjectXUpdaterWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("VerInfo", new LuaCSFunction(Assets_Scripts_Net_ProjectXUpdaterWrap.get_VerInfo), new LuaCSFunction(Assets_Scripts_Net_ProjectXUpdaterWrap.set_VerInfo));
		L.RegVar("Priority", new LuaCSFunction(Assets_Scripts_Net_ProjectXUpdaterWrap.get_Priority), null);
		L.RegVar("Weight", new LuaCSFunction(Assets_Scripts_Net_ProjectXUpdaterWrap.get_Weight), null);
		L.RegVar("SetTaskProgress", new LuaCSFunction(Assets_Scripts_Net_ProjectXUpdaterWrap.get_SetTaskProgress), new LuaCSFunction(Assets_Scripts_Net_ProjectXUpdaterWrap.set_SetTaskProgress));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Start(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			ProjectXUpdater projectXUpdater = (ProjectXUpdater)ToLua.CheckObject(L, 1, typeof(ProjectXUpdater));
			projectXUpdater.Start();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int StartUpdate(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			ProjectXUpdater projectXUpdater = (ProjectXUpdater)ToLua.CheckObject(L, 1, typeof(ProjectXUpdater));
			string verUrl = ToLua.CheckString(L, 2);
			projectXUpdater.StartUpdate(verUrl);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int StartTask(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			ProjectXUpdater projectXUpdater = (ProjectXUpdater)ToLua.CheckObject(L, 1, typeof(ProjectXUpdater));
			projectXUpdater.StartTask();
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
	private static int get_VerInfo(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ProjectXUpdater projectXUpdater = (ProjectXUpdater)obj;
			VerInfoStruct verInfo = projectXUpdater.VerInfo;
			ToLua.PushObject(L, verInfo);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index VerInfo on a nil value");
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
			ProjectXUpdater projectXUpdater = (ProjectXUpdater)obj;
			int priority = projectXUpdater.Priority;
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
			ProjectXUpdater projectXUpdater = (ProjectXUpdater)obj;
			int weight = projectXUpdater.Weight;
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
			ProjectXUpdater projectXUpdater = (ProjectXUpdater)obj;
			Action<IGameEntryTask, float, string> setTaskProgress = projectXUpdater.SetTaskProgress;
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
	private static int set_VerInfo(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ProjectXUpdater projectXUpdater = (ProjectXUpdater)obj;
			VerInfoStruct verInfo = (VerInfoStruct)ToLua.CheckObject(L, 2, typeof(VerInfoStruct));
			projectXUpdater.VerInfo = verInfo;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index VerInfo on a nil value");
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
			ProjectXUpdater projectXUpdater = (ProjectXUpdater)obj;
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
			projectXUpdater.SetTaskProgress = setTaskProgress;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index SetTaskProgress on a nil value");
		}
		return result;
	}
}
