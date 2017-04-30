using Assets.Scripts.Tools.NGUI.Component;
using LuaInterface;
using System;
using UnityEngine;

public class Assets_Scripts_Tools_NGUI_Component_TweenSpriteMaterialColorWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(TweenSpriteMaterialColor), typeof(UITweener), null);
		L.RegFunction("__eq", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_TweenSpriteMaterialColorWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("from", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_TweenSpriteMaterialColorWrap.get_from), new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_TweenSpriteMaterialColorWrap.set_from));
		L.RegVar("to", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_TweenSpriteMaterialColorWrap.get_to), new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_TweenSpriteMaterialColorWrap.set_to));
		L.RegVar("value", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_TweenSpriteMaterialColorWrap.get_value), new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_TweenSpriteMaterialColorWrap.set_value));
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
	private static int get_from(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TweenSpriteMaterialColor tweenSpriteMaterialColor = (TweenSpriteMaterialColor)obj;
			Color from = tweenSpriteMaterialColor.from;
			ToLua.Push(L, from);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index from on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_to(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TweenSpriteMaterialColor tweenSpriteMaterialColor = (TweenSpriteMaterialColor)obj;
			Color to = tweenSpriteMaterialColor.to;
			ToLua.Push(L, to);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index to on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_value(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TweenSpriteMaterialColor tweenSpriteMaterialColor = (TweenSpriteMaterialColor)obj;
			Color value = tweenSpriteMaterialColor.value;
			ToLua.Push(L, value);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index value on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_from(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TweenSpriteMaterialColor tweenSpriteMaterialColor = (TweenSpriteMaterialColor)obj;
			Color from = ToLua.ToColor(L, 2);
			tweenSpriteMaterialColor.from = from;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index from on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_to(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TweenSpriteMaterialColor tweenSpriteMaterialColor = (TweenSpriteMaterialColor)obj;
			Color to = ToLua.ToColor(L, 2);
			tweenSpriteMaterialColor.to = to;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index to on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_value(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TweenSpriteMaterialColor tweenSpriteMaterialColor = (TweenSpriteMaterialColor)obj;
			Color value = ToLua.ToColor(L, 2);
			tweenSpriteMaterialColor.value = value;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index value on a nil value");
		}
		return result;
	}
}
