using Assets.Scripts.Tools.NGUI.Component;
using LuaInterface;
using System;
using UnityEngine;

public class Assets_Scripts_Tools_NGUI_Component_UIOnClickPositionWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UIOnClickPosition), typeof(MonoBehaviour), null);
		L.RegFunction("ResetPosition", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIOnClickPositionWrap.ResetPosition));
		L.RegFunction("__eq", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIOnClickPositionWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("ClickEnable", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIOnClickPositionWrap.get_ClickEnable), new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIOnClickPositionWrap.set_ClickEnable));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ResetPosition(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIOnClickPosition uIOnClickPosition = (UIOnClickPosition)ToLua.CheckObject(L, 1, typeof(UIOnClickPosition));
			uIOnClickPosition.ResetPosition();
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
	private static int get_ClickEnable(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIOnClickPosition uIOnClickPosition = (UIOnClickPosition)obj;
			bool clickEnable = uIOnClickPosition.ClickEnable;
			LuaDLL.lua_pushboolean(L, clickEnable);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ClickEnable on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_ClickEnable(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIOnClickPosition uIOnClickPosition = (UIOnClickPosition)obj;
			bool clickEnable = LuaDLL.luaL_checkboolean(L, 2);
			uIOnClickPosition.ClickEnable = clickEnable;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ClickEnable on a nil value");
		}
		return result;
	}
}
