using Assets.Scripts.Tools.NGUI.Component;
using LuaInterface;
using System;
using UnityEngine;

public class Assets_Scripts_Tools_NGUI_Component_UITrimGridWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UITrimGrid), typeof(UIGrid), null);
		L.RegFunction("__eq", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UITrimGridWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("ResetPositionHook", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UITrimGridWrap.get_ResetPositionHook), new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UITrimGridWrap.set_ResetPositionHook));
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
	private static int get_ResetPositionHook(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITrimGrid uITrimGrid = (UITrimGrid)obj;
			Func<Transform, int, Vector3, Vector3> resetPositionHook = uITrimGrid.ResetPositionHook;
			ToLua.Push(L, resetPositionHook);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ResetPositionHook on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_ResetPositionHook(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITrimGrid uITrimGrid = (UITrimGrid)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Func<Transform, int, Vector3, Vector3> resetPositionHook;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				resetPositionHook = (Func<Transform, int, Vector3, Vector3>)ToLua.CheckObject(L, 2, typeof(Func<Transform, int, Vector3, Vector3>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				resetPositionHook = (DelegateFactory.CreateDelegate(typeof(Func<Transform, int, Vector3, Vector3>), func) as Func<Transform, int, Vector3, Vector3>);
			}
			uITrimGrid.ResetPositionHook = resetPositionHook;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ResetPositionHook on a nil value");
		}
		return result;
	}
}
