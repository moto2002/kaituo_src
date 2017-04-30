using Assets.Scripts.Tools.Event;
using LuaInterface;
using System;
using UnityEngine;

public class Assets_Scripts_Tools_Event_LuaEventAdapterWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(LuaEventAdapter), typeof(MonoBehaviour), null);
		L.RegFunction("AddListener", new LuaCSFunction(Assets_Scripts_Tools_Event_LuaEventAdapterWrap.AddListener));
		L.RegFunction("RemoveListener", new LuaCSFunction(Assets_Scripts_Tools_Event_LuaEventAdapterWrap.RemoveListener));
		L.RegFunction("Listener0", new LuaCSFunction(Assets_Scripts_Tools_Event_LuaEventAdapterWrap.Listener0));
		L.RegFunction("__eq", new LuaCSFunction(Assets_Scripts_Tools_Event_LuaEventAdapterWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddListener(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			LuaEventAdapter luaEventAdapter = (LuaEventAdapter)ToLua.CheckObject(L, 1, typeof(LuaEventAdapter));
			LuaFunction callback = ToLua.CheckLuaFunction(L, 2);
			luaEventAdapter.AddListener(callback);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RemoveListener(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			LuaEventAdapter luaEventAdapter = (LuaEventAdapter)ToLua.CheckObject(L, 1, typeof(LuaEventAdapter));
			luaEventAdapter.RemoveListener();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Listener0(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			LuaEventAdapter luaEventAdapter = (LuaEventAdapter)ToLua.CheckObject(L, 1, typeof(LuaEventAdapter));
			luaEventAdapter.Listener0();
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
}
