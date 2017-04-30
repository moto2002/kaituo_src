using Assets.Tools.Script.Event;
using LuaInterface;
using System;
using UnityEngine;

public class Assets_Tools_Script_Event_ApplicationEventWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(ApplicationEvent), typeof(MonoBehaviour), null);
		L.RegFunction("__eq", new LuaCSFunction(Assets_Tools_Script_Event_ApplicationEventWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("OnAwake", new LuaCSFunction(Assets_Tools_Script_Event_ApplicationEventWrap.get_OnAwake), new LuaCSFunction(Assets_Tools_Script_Event_ApplicationEventWrap.set_OnAwake));
		L.RegVar("OnRestore", new LuaCSFunction(Assets_Tools_Script_Event_ApplicationEventWrap.get_OnRestore), new LuaCSFunction(Assets_Tools_Script_Event_ApplicationEventWrap.set_OnRestore));
		L.RegVar("OnPause", new LuaCSFunction(Assets_Tools_Script_Event_ApplicationEventWrap.get_OnPause), new LuaCSFunction(Assets_Tools_Script_Event_ApplicationEventWrap.set_OnPause));
		L.RegVar("OnQuit", new LuaCSFunction(Assets_Tools_Script_Event_ApplicationEventWrap.get_OnQuit), new LuaCSFunction(Assets_Tools_Script_Event_ApplicationEventWrap.set_OnQuit));
		L.RegVar("OnEsc", new LuaCSFunction(Assets_Tools_Script_Event_ApplicationEventWrap.get_OnEsc), new LuaCSFunction(Assets_Tools_Script_Event_ApplicationEventWrap.set_OnEsc));
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
	private static int get_OnAwake(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, ApplicationEvent.OnAwake);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_OnRestore(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, ApplicationEvent.OnRestore);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_OnPause(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, ApplicationEvent.OnPause);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_OnQuit(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, ApplicationEvent.OnQuit);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_OnEsc(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, ApplicationEvent.OnEsc);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_OnAwake(IntPtr L)
	{
		int result;
		try
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Action onAwake;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onAwake = (Action)ToLua.CheckObject(L, 2, typeof(Action));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onAwake = (DelegateFactory.CreateDelegate(typeof(Action), func) as Action);
			}
			ApplicationEvent.OnAwake = onAwake;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_OnRestore(IntPtr L)
	{
		int result;
		try
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Action onRestore;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onRestore = (Action)ToLua.CheckObject(L, 2, typeof(Action));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onRestore = (DelegateFactory.CreateDelegate(typeof(Action), func) as Action);
			}
			ApplicationEvent.OnRestore = onRestore;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_OnPause(IntPtr L)
	{
		int result;
		try
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Action onPause;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onPause = (Action)ToLua.CheckObject(L, 2, typeof(Action));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onPause = (DelegateFactory.CreateDelegate(typeof(Action), func) as Action);
			}
			ApplicationEvent.OnPause = onPause;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_OnQuit(IntPtr L)
	{
		int result;
		try
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Action onQuit;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onQuit = (Action)ToLua.CheckObject(L, 2, typeof(Action));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onQuit = (DelegateFactory.CreateDelegate(typeof(Action), func) as Action);
			}
			ApplicationEvent.OnQuit = onQuit;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_OnEsc(IntPtr L)
	{
		int result;
		try
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Action onEsc;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onEsc = (Action)ToLua.CheckObject(L, 2, typeof(Action));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onEsc = (DelegateFactory.CreateDelegate(typeof(Action), func) as Action);
			}
			ApplicationEvent.OnEsc = onEsc;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
