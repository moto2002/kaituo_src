using Assets.Scripts.Tools.Component;
using LuaInterface;
using System;
using UnityEngine;

public class Assets_Scripts_Tools_Component_NcAnimationRootWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(NcAnimationRoot), typeof(MonoBehaviour), null);
		L.RegFunction("HasPath", new LuaCSFunction(Assets_Scripts_Tools_Component_NcAnimationRootWrap.HasPath));
		L.RegFunction("SetRangeScale", new LuaCSFunction(Assets_Scripts_Tools_Component_NcAnimationRootWrap.SetRangeScale));
		L.RegFunction("GetRotateType", new LuaCSFunction(Assets_Scripts_Tools_Component_NcAnimationRootWrap.GetRotateType));
		L.RegFunction("__eq", new LuaCSFunction(Assets_Scripts_Tools_Component_NcAnimationRootWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("ReplayOnEnable", new LuaCSFunction(Assets_Scripts_Tools_Component_NcAnimationRootWrap.get_ReplayOnEnable), new LuaCSFunction(Assets_Scripts_Tools_Component_NcAnimationRootWrap.set_ReplayOnEnable));
		L.RegVar("Offset", new LuaCSFunction(Assets_Scripts_Tools_Component_NcAnimationRootWrap.get_Offset), new LuaCSFunction(Assets_Scripts_Tools_Component_NcAnimationRootWrap.set_Offset));
		L.RegVar("AutoDisable", new LuaCSFunction(Assets_Scripts_Tools_Component_NcAnimationRootWrap.get_AutoDisable), new LuaCSFunction(Assets_Scripts_Tools_Component_NcAnimationRootWrap.set_AutoDisable));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int HasPath(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			NcAnimationRoot ncAnimationRoot = (NcAnimationRoot)ToLua.CheckObject(L, 1, typeof(NcAnimationRoot));
			bool value = ncAnimationRoot.HasPath();
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
	private static int SetRangeScale(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			NcAnimationRoot ncAnimationRoot = (NcAnimationRoot)ToLua.CheckObject(L, 1, typeof(NcAnimationRoot));
			float rangeScale = (float)LuaDLL.luaL_checknumber(L, 2);
			ncAnimationRoot.SetRangeScale(rangeScale);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetRotateType(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			NcAnimationRoot ncAnimationRoot = (NcAnimationRoot)ToLua.CheckObject(L, 1, typeof(NcAnimationRoot));
			int rotateType = ncAnimationRoot.GetRotateType();
			LuaDLL.lua_pushinteger(L, rotateType);
			result = 1;
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
	private static int get_ReplayOnEnable(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			NcAnimationRoot ncAnimationRoot = (NcAnimationRoot)obj;
			bool replayOnEnable = ncAnimationRoot.ReplayOnEnable;
			LuaDLL.lua_pushboolean(L, replayOnEnable);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ReplayOnEnable on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Offset(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			NcAnimationRoot ncAnimationRoot = (NcAnimationRoot)obj;
			Vector3 offset = ncAnimationRoot.Offset;
			ToLua.Push(L, offset);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Offset on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_AutoDisable(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			NcAnimationRoot ncAnimationRoot = (NcAnimationRoot)obj;
			float autoDisable = ncAnimationRoot.AutoDisable;
			LuaDLL.lua_pushnumber(L, (double)autoDisable);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index AutoDisable on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_ReplayOnEnable(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			NcAnimationRoot ncAnimationRoot = (NcAnimationRoot)obj;
			bool replayOnEnable = LuaDLL.luaL_checkboolean(L, 2);
			ncAnimationRoot.ReplayOnEnable = replayOnEnable;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ReplayOnEnable on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Offset(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			NcAnimationRoot ncAnimationRoot = (NcAnimationRoot)obj;
			Vector3 offset = ToLua.ToVector3(L, 2);
			ncAnimationRoot.Offset = offset;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Offset on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_AutoDisable(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			NcAnimationRoot ncAnimationRoot = (NcAnimationRoot)obj;
			float autoDisable = (float)LuaDLL.luaL_checknumber(L, 2);
			ncAnimationRoot.AutoDisable = autoDisable;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index AutoDisable on a nil value");
		}
		return result;
	}
}
