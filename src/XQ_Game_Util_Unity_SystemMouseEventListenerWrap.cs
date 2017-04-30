using LuaInterface;
using System;
using UnityEngine;
using XQ.Game.Util.Unity;

public class XQ_Game_Util_Unity_SystemMouseEventListenerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(SystemMouseEventListener), typeof(MonoBehaviour), null);
		L.RegFunction("StartListener", new LuaCSFunction(XQ_Game_Util_Unity_SystemMouseEventListenerWrap.StartListener));
		L.RegFunction("CloseListener", new LuaCSFunction(XQ_Game_Util_Unity_SystemMouseEventListenerWrap.CloseListener));
		L.RegFunction("Update", new LuaCSFunction(XQ_Game_Util_Unity_SystemMouseEventListenerWrap.Update));
		L.RegFunction("OnDestroy", new LuaCSFunction(XQ_Game_Util_Unity_SystemMouseEventListenerWrap.OnDestroy));
		L.RegFunction("__eq", new LuaCSFunction(XQ_Game_Util_Unity_SystemMouseEventListenerWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("Instance", new LuaCSFunction(XQ_Game_Util_Unity_SystemMouseEventListenerWrap.get_Instance), new LuaCSFunction(XQ_Game_Util_Unity_SystemMouseEventListenerWrap.set_Instance));
		L.RegVar("OnMouseButtonDown0", new LuaCSFunction(XQ_Game_Util_Unity_SystemMouseEventListenerWrap.get_OnMouseButtonDown0), new LuaCSFunction(XQ_Game_Util_Unity_SystemMouseEventListenerWrap.set_OnMouseButtonDown0));
		L.RegVar("OnMouseButtonUp0", new LuaCSFunction(XQ_Game_Util_Unity_SystemMouseEventListenerWrap.get_OnMouseButtonUp0), new LuaCSFunction(XQ_Game_Util_Unity_SystemMouseEventListenerWrap.set_OnMouseButtonUp0));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int StartListener(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			SystemMouseEventListener obj = SystemMouseEventListener.StartListener();
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
	private static int CloseListener(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			SystemMouseEventListener.CloseListener();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Update(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			SystemMouseEventListener systemMouseEventListener = (SystemMouseEventListener)ToLua.CheckObject(L, 1, typeof(SystemMouseEventListener));
			systemMouseEventListener.Update();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnDestroy(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			SystemMouseEventListener systemMouseEventListener = (SystemMouseEventListener)ToLua.CheckObject(L, 1, typeof(SystemMouseEventListener));
			systemMouseEventListener.OnDestroy();
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
			ToLua.Push(L, SystemMouseEventListener.Instance);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_OnMouseButtonDown0(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SystemMouseEventListener systemMouseEventListener = (SystemMouseEventListener)obj;
			Action<GameObject> onMouseButtonDown = systemMouseEventListener.OnMouseButtonDown0;
			ToLua.Push(L, onMouseButtonDown);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index OnMouseButtonDown0 on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_OnMouseButtonUp0(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SystemMouseEventListener systemMouseEventListener = (SystemMouseEventListener)obj;
			Action<GameObject> onMouseButtonUp = systemMouseEventListener.OnMouseButtonUp0;
			ToLua.Push(L, onMouseButtonUp);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index OnMouseButtonUp0 on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Instance(IntPtr L)
	{
		int result;
		try
		{
			SystemMouseEventListener instance = (SystemMouseEventListener)ToLua.CheckUnityObject(L, 2, typeof(SystemMouseEventListener));
			SystemMouseEventListener.Instance = instance;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_OnMouseButtonDown0(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SystemMouseEventListener systemMouseEventListener = (SystemMouseEventListener)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Action<GameObject> onMouseButtonDown;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onMouseButtonDown = (Action<GameObject>)ToLua.CheckObject(L, 2, typeof(Action<GameObject>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onMouseButtonDown = (DelegateFactory.CreateDelegate(typeof(Action<GameObject>), func) as Action<GameObject>);
			}
			systemMouseEventListener.OnMouseButtonDown0 = onMouseButtonDown;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index OnMouseButtonDown0 on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_OnMouseButtonUp0(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SystemMouseEventListener systemMouseEventListener = (SystemMouseEventListener)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Action<GameObject> onMouseButtonUp;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onMouseButtonUp = (Action<GameObject>)ToLua.CheckObject(L, 2, typeof(Action<GameObject>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onMouseButtonUp = (DelegateFactory.CreateDelegate(typeof(Action<GameObject>), func) as Action<GameObject>);
			}
			systemMouseEventListener.OnMouseButtonUp0 = onMouseButtonUp;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index OnMouseButtonUp0 on a nil value");
		}
		return result;
	}
}
