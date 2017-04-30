using Assets.Scripts.Tools.Component;
using LuaInterface;
using System;
using UnityEngine;

public class Assets_Scripts_Tools_Component_NcSoloistWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(NcSoloist), typeof(MonoBehaviour), null);
		L.RegFunction("__eq", new LuaCSFunction(Assets_Scripts_Tools_Component_NcSoloistWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("SoloTime", new LuaCSFunction(Assets_Scripts_Tools_Component_NcSoloistWrap.get_SoloTime), new LuaCSFunction(Assets_Scripts_Tools_Component_NcSoloistWrap.set_SoloTime));
		L.RegVar("IsFinish", new LuaCSFunction(Assets_Scripts_Tools_Component_NcSoloistWrap.get_IsFinish), new LuaCSFunction(Assets_Scripts_Tools_Component_NcSoloistWrap.set_IsFinish));
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
	private static int get_SoloTime(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			NcSoloist ncSoloist = (NcSoloist)obj;
			float soloTime = ncSoloist.SoloTime;
			LuaDLL.lua_pushnumber(L, (double)soloTime);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index SoloTime on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_IsFinish(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			NcSoloist ncSoloist = (NcSoloist)obj;
			bool isFinish = ncSoloist.IsFinish;
			LuaDLL.lua_pushboolean(L, isFinish);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index IsFinish on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_SoloTime(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			NcSoloist ncSoloist = (NcSoloist)obj;
			float soloTime = (float)LuaDLL.luaL_checknumber(L, 2);
			ncSoloist.SoloTime = soloTime;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index SoloTime on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_IsFinish(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			NcSoloist ncSoloist = (NcSoloist)obj;
			bool isFinish = LuaDLL.luaL_checkboolean(L, 2);
			ncSoloist.IsFinish = isFinish;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index IsFinish on a nil value");
		}
		return result;
	}
}
