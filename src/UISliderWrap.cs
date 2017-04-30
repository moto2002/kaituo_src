using LuaInterface;
using System;
using UnityEngine;

public class UISliderWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UISlider), typeof(UIProgressBar), null);
		L.RegFunction("OnPan", new LuaCSFunction(UISliderWrap.OnPan));
		L.RegFunction("__eq", new LuaCSFunction(UISliderWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("isColliderEnabled", new LuaCSFunction(UISliderWrap.get_isColliderEnabled), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnPan(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UISlider uISlider = (UISlider)ToLua.CheckObject(L, 1, typeof(UISlider));
			Vector2 delta = ToLua.ToVector2(L, 2);
			uISlider.OnPan(delta);
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
	private static int get_isColliderEnabled(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISlider uISlider = (UISlider)obj;
			bool isColliderEnabled = uISlider.isColliderEnabled;
			LuaDLL.lua_pushboolean(L, isColliderEnabled);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isColliderEnabled on a nil value");
		}
		return result;
	}
}
