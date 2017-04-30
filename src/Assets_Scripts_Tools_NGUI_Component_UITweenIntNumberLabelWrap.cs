using Assets.Scripts.Tools.NGUI.Component;
using LuaInterface;
using System;
using UnityEngine;

public class Assets_Scripts_Tools_NGUI_Component_UITweenIntNumberLabelWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UITweenIntNumberLabel), typeof(UITweener), null);
		L.RegFunction("PlayFromCurrTo", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UITweenIntNumberLabelWrap.PlayFromCurrTo));
		L.RegFunction("__eq", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UITweenIntNumberLabelWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("Bold", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UITweenIntNumberLabelWrap.get_Bold), new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UITweenIntNumberLabelWrap.set_Bold));
		L.RegVar("from", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UITweenIntNumberLabelWrap.get_from), new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UITweenIntNumberLabelWrap.set_from));
		L.RegVar("to", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UITweenIntNumberLabelWrap.get_to), new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UITweenIntNumberLabelWrap.set_to));
		L.RegVar("value", null, new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UITweenIntNumberLabelWrap.set_value));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PlayFromCurrTo(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UITweenIntNumberLabel uITweenIntNumberLabel = (UITweenIntNumberLabel)ToLua.CheckObject(L, 1, typeof(UITweenIntNumberLabel));
			int to = (int)LuaDLL.luaL_checknumber(L, 2);
			uITweenIntNumberLabel.PlayFromCurrTo(to);
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
	private static int get_Bold(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITweenIntNumberLabel uITweenIntNumberLabel = (UITweenIntNumberLabel)obj;
			bool bold = uITweenIntNumberLabel.Bold;
			LuaDLL.lua_pushboolean(L, bold);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Bold on a nil value");
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
			UITweenIntNumberLabel uITweenIntNumberLabel = (UITweenIntNumberLabel)obj;
			int from = uITweenIntNumberLabel.from;
			LuaDLL.lua_pushinteger(L, from);
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
			UITweenIntNumberLabel uITweenIntNumberLabel = (UITweenIntNumberLabel)obj;
			int to = uITweenIntNumberLabel.to;
			LuaDLL.lua_pushinteger(L, to);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index to on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Bold(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITweenIntNumberLabel uITweenIntNumberLabel = (UITweenIntNumberLabel)obj;
			bool bold = LuaDLL.luaL_checkboolean(L, 2);
			uITweenIntNumberLabel.Bold = bold;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Bold on a nil value");
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
			UITweenIntNumberLabel uITweenIntNumberLabel = (UITweenIntNumberLabel)obj;
			int from = (int)LuaDLL.luaL_checknumber(L, 2);
			uITweenIntNumberLabel.from = from;
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
			UITweenIntNumberLabel uITweenIntNumberLabel = (UITweenIntNumberLabel)obj;
			int to = (int)LuaDLL.luaL_checknumber(L, 2);
			uITweenIntNumberLabel.to = to;
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
			UITweenIntNumberLabel uITweenIntNumberLabel = (UITweenIntNumberLabel)obj;
			float value = (float)LuaDLL.luaL_checknumber(L, 2);
			uITweenIntNumberLabel.value = value;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index value on a nil value");
		}
		return result;
	}
}
