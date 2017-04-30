using LuaInterface;
using System;
using UnityEngine;

public class UIScrollBarWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UIScrollBar), typeof(UISlider), null);
		L.RegFunction("ForceUpdate", new LuaCSFunction(UIScrollBarWrap.ForceUpdate));
		L.RegFunction("__eq", new LuaCSFunction(UIScrollBarWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("barSize", new LuaCSFunction(UIScrollBarWrap.get_barSize), new LuaCSFunction(UIScrollBarWrap.set_barSize));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ForceUpdate(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIScrollBar uIScrollBar = (UIScrollBar)ToLua.CheckObject(L, 1, typeof(UIScrollBar));
			uIScrollBar.ForceUpdate();
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
	private static int get_barSize(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollBar uIScrollBar = (UIScrollBar)obj;
			float barSize = uIScrollBar.barSize;
			LuaDLL.lua_pushnumber(L, (double)barSize);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index barSize on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_barSize(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollBar uIScrollBar = (UIScrollBar)obj;
			float barSize = (float)LuaDLL.luaL_checknumber(L, 2);
			uIScrollBar.barSize = barSize;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index barSize on a nil value");
		}
		return result;
	}
}
