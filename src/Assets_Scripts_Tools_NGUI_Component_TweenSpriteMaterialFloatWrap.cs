using Assets.Scripts.Tools.NGUI.Component;
using LuaInterface;
using System;
using UnityEngine;

public class Assets_Scripts_Tools_NGUI_Component_TweenSpriteMaterialFloatWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(TweenSpriteMaterialFloat), typeof(UITweener), null);
		L.RegFunction("PlayFromCurrTo", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_TweenSpriteMaterialFloatWrap.PlayFromCurrTo));
		L.RegFunction("__eq", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_TweenSpriteMaterialFloatWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("from", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_TweenSpriteMaterialFloatWrap.get_from), new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_TweenSpriteMaterialFloatWrap.set_from));
		L.RegVar("to", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_TweenSpriteMaterialFloatWrap.get_to), new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_TweenSpriteMaterialFloatWrap.set_to));
		L.RegVar("propertyName", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_TweenSpriteMaterialFloatWrap.get_propertyName), new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_TweenSpriteMaterialFloatWrap.set_propertyName));
		L.RegVar("value", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_TweenSpriteMaterialFloatWrap.get_value), new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_TweenSpriteMaterialFloatWrap.set_value));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PlayFromCurrTo(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			TweenSpriteMaterialFloat tweenSpriteMaterialFloat = (TweenSpriteMaterialFloat)ToLua.CheckObject(L, 1, typeof(TweenSpriteMaterialFloat));
			float to = (float)LuaDLL.luaL_checknumber(L, 2);
			tweenSpriteMaterialFloat.PlayFromCurrTo(to);
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
	private static int get_from(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TweenSpriteMaterialFloat tweenSpriteMaterialFloat = (TweenSpriteMaterialFloat)obj;
			float from = tweenSpriteMaterialFloat.from;
			LuaDLL.lua_pushnumber(L, (double)from);
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
			TweenSpriteMaterialFloat tweenSpriteMaterialFloat = (TweenSpriteMaterialFloat)obj;
			float to = tweenSpriteMaterialFloat.to;
			LuaDLL.lua_pushnumber(L, (double)to);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index to on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_propertyName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TweenSpriteMaterialFloat tweenSpriteMaterialFloat = (TweenSpriteMaterialFloat)obj;
			string propertyName = tweenSpriteMaterialFloat.propertyName;
			LuaDLL.lua_pushstring(L, propertyName);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index propertyName on a nil value");
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
			TweenSpriteMaterialFloat tweenSpriteMaterialFloat = (TweenSpriteMaterialFloat)obj;
			float value = tweenSpriteMaterialFloat.value;
			LuaDLL.lua_pushnumber(L, (double)value);
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
			TweenSpriteMaterialFloat tweenSpriteMaterialFloat = (TweenSpriteMaterialFloat)obj;
			float from = (float)LuaDLL.luaL_checknumber(L, 2);
			tweenSpriteMaterialFloat.from = from;
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
			TweenSpriteMaterialFloat tweenSpriteMaterialFloat = (TweenSpriteMaterialFloat)obj;
			float to = (float)LuaDLL.luaL_checknumber(L, 2);
			tweenSpriteMaterialFloat.to = to;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index to on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_propertyName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TweenSpriteMaterialFloat tweenSpriteMaterialFloat = (TweenSpriteMaterialFloat)obj;
			string propertyName = ToLua.CheckString(L, 2);
			tweenSpriteMaterialFloat.propertyName = propertyName;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index propertyName on a nil value");
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
			TweenSpriteMaterialFloat tweenSpriteMaterialFloat = (TweenSpriteMaterialFloat)obj;
			float value = (float)LuaDLL.luaL_checknumber(L, 2);
			tweenSpriteMaterialFloat.value = value;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index value on a nil value");
		}
		return result;
	}
}
