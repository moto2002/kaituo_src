using Assets.Tools.Script.Go;
using LuaInterface;
using System;
using UnityEngine;
using XQ.Framework.Lua;

public class Assets_Tools_Script_Go_UnityCompomentLifeWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityCompomentLife), typeof(ILuaScriptBase), null);
		L.RegFunction("OnEnable", new LuaCSFunction(Assets_Tools_Script_Go_UnityCompomentLifeWrap.OnEnable));
		L.RegFunction("OnDisable", new LuaCSFunction(Assets_Tools_Script_Go_UnityCompomentLifeWrap.OnDisable));
		L.RegFunction("OnAwake", new LuaCSFunction(Assets_Tools_Script_Go_UnityCompomentLifeWrap.OnAwake));
		L.RegFunction("OnDestroyNow", new LuaCSFunction(Assets_Tools_Script_Go_UnityCompomentLifeWrap.OnDestroyNow));
		L.RegFunction("__eq", new LuaCSFunction(Assets_Tools_Script_Go_UnityCompomentLifeWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("EnableAction", new LuaCSFunction(Assets_Tools_Script_Go_UnityCompomentLifeWrap.get_EnableAction), new LuaCSFunction(Assets_Tools_Script_Go_UnityCompomentLifeWrap.set_EnableAction));
		L.RegVar("DisableAction", new LuaCSFunction(Assets_Tools_Script_Go_UnityCompomentLifeWrap.get_DisableAction), new LuaCSFunction(Assets_Tools_Script_Go_UnityCompomentLifeWrap.set_DisableAction));
		L.RegVar("DestroyAction", new LuaCSFunction(Assets_Tools_Script_Go_UnityCompomentLifeWrap.get_DestroyAction), new LuaCSFunction(Assets_Tools_Script_Go_UnityCompomentLifeWrap.set_DestroyAction));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnEnable(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityCompomentLife unityCompomentLife = (UnityCompomentLife)ToLua.CheckObject(L, 1, typeof(UnityCompomentLife));
			unityCompomentLife.OnEnable();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnDisable(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityCompomentLife unityCompomentLife = (UnityCompomentLife)ToLua.CheckObject(L, 1, typeof(UnityCompomentLife));
			unityCompomentLife.OnDisable();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnAwake(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityCompomentLife unityCompomentLife = (UnityCompomentLife)ToLua.CheckObject(L, 1, typeof(UnityCompomentLife));
			unityCompomentLife.OnAwake();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnDestroyNow(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityCompomentLife unityCompomentLife = (UnityCompomentLife)ToLua.CheckObject(L, 1, typeof(UnityCompomentLife));
			unityCompomentLife.OnDestroyNow();
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
	private static int get_EnableAction(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UnityCompomentLife unityCompomentLife = (UnityCompomentLife)obj;
			LuaFunction enableAction = unityCompomentLife.EnableAction;
			ToLua.Push(L, enableAction);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index EnableAction on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_DisableAction(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UnityCompomentLife unityCompomentLife = (UnityCompomentLife)obj;
			LuaFunction disableAction = unityCompomentLife.DisableAction;
			ToLua.Push(L, disableAction);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index DisableAction on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_DestroyAction(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UnityCompomentLife unityCompomentLife = (UnityCompomentLife)obj;
			LuaFunction destroyAction = unityCompomentLife.DestroyAction;
			ToLua.Push(L, destroyAction);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index DestroyAction on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_EnableAction(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UnityCompomentLife unityCompomentLife = (UnityCompomentLife)obj;
			LuaFunction enableAction = ToLua.CheckLuaFunction(L, 2);
			unityCompomentLife.EnableAction = enableAction;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index EnableAction on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_DisableAction(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UnityCompomentLife unityCompomentLife = (UnityCompomentLife)obj;
			LuaFunction disableAction = ToLua.CheckLuaFunction(L, 2);
			unityCompomentLife.DisableAction = disableAction;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index DisableAction on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_DestroyAction(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UnityCompomentLife unityCompomentLife = (UnityCompomentLife)obj;
			LuaFunction destroyAction = ToLua.CheckLuaFunction(L, 2);
			unityCompomentLife.DestroyAction = destroyAction;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index DestroyAction on a nil value");
		}
		return result;
	}
}
