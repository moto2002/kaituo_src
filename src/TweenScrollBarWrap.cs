using LuaInterface;
using System;
using UnityEngine;

public class TweenScrollBarWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(TweenScrollBar), typeof(UITweener), null);
		L.RegFunction("Begin", new LuaCSFunction(TweenScrollBarWrap.Begin));
		L.RegFunction("SetStartToCurrentValue", new LuaCSFunction(TweenScrollBarWrap.SetStartToCurrentValue));
		L.RegFunction("SetEndToCurrentValue", new LuaCSFunction(TweenScrollBarWrap.SetEndToCurrentValue));
		L.RegFunction("__eq", new LuaCSFunction(TweenScrollBarWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("from", new LuaCSFunction(TweenScrollBarWrap.get_from), new LuaCSFunction(TweenScrollBarWrap.set_from));
		L.RegVar("to", new LuaCSFunction(TweenScrollBarWrap.get_to), new LuaCSFunction(TweenScrollBarWrap.set_to));
		L.RegVar("value", new LuaCSFunction(TweenScrollBarWrap.get_value), new LuaCSFunction(TweenScrollBarWrap.set_value));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Begin(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			float duration = (float)LuaDLL.luaL_checknumber(L, 2);
			float alpha = (float)LuaDLL.luaL_checknumber(L, 3);
			TweenScrollBar obj = TweenScrollBar.Begin(go, duration, alpha);
			ToLua.Push(L, obj);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetStartToCurrentValue(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			TweenScrollBar tweenScrollBar = (TweenScrollBar)ToLua.CheckObject(L, 1, typeof(TweenScrollBar));
			tweenScrollBar.SetStartToCurrentValue();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetEndToCurrentValue(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			TweenScrollBar tweenScrollBar = (TweenScrollBar)ToLua.CheckObject(L, 1, typeof(TweenScrollBar));
			tweenScrollBar.SetEndToCurrentValue();
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
			TweenScrollBar tweenScrollBar = (TweenScrollBar)obj;
			float from = tweenScrollBar.from;
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
			TweenScrollBar tweenScrollBar = (TweenScrollBar)obj;
			float to = tweenScrollBar.to;
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
	private static int get_value(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TweenScrollBar tweenScrollBar = (TweenScrollBar)obj;
			float value = tweenScrollBar.value;
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
			TweenScrollBar tweenScrollBar = (TweenScrollBar)obj;
			float from = (float)LuaDLL.luaL_checknumber(L, 2);
			tweenScrollBar.from = from;
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
			TweenScrollBar tweenScrollBar = (TweenScrollBar)obj;
			float to = (float)LuaDLL.luaL_checknumber(L, 2);
			tweenScrollBar.to = to;
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
			TweenScrollBar tweenScrollBar = (TweenScrollBar)obj;
			float value = (float)LuaDLL.luaL_checknumber(L, 2);
			tweenScrollBar.value = value;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index value on a nil value");
		}
		return result;
	}
}
