using Assets.Scripts.Tools.Component;
using LuaInterface;
using System;
using UnityEngine;

public class Assets_Scripts_Tools_Component_LateUpdaterWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(LateUpdater), typeof(MonoBehaviour), null);
		L.RegFunction("__eq", new LuaCSFunction(Assets_Scripts_Tools_Component_LateUpdaterWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("OnLateUpdate", new LuaCSFunction(Assets_Scripts_Tools_Component_LateUpdaterWrap.get_OnLateUpdate), new LuaCSFunction(Assets_Scripts_Tools_Component_LateUpdaterWrap.set_OnLateUpdate));
		L.EndClass();
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
	private static int get_OnLateUpdate(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LateUpdater lateUpdater = (LateUpdater)obj;
			Action onLateUpdate = lateUpdater.OnLateUpdate;
			ToLua.Push(L, onLateUpdate);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index OnLateUpdate on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_OnLateUpdate(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LateUpdater lateUpdater = (LateUpdater)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Action onLateUpdate;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onLateUpdate = (Action)ToLua.CheckObject(L, 2, typeof(Action));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onLateUpdate = (DelegateFactory.CreateDelegate(typeof(Action), func) as Action);
			}
			lateUpdater.OnLateUpdate = onLateUpdate;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index OnLateUpdate on a nil value");
		}
		return result;
	}
}
