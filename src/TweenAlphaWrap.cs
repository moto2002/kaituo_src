using LuaInterface;
using System;
using UnityEngine;

public class TweenAlphaWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(TweenAlpha), typeof(UITweener), null);
		L.RegFunction("Begin", new LuaCSFunction(TweenAlphaWrap.Begin));
		L.RegFunction("SetStartToCurrentValue", new LuaCSFunction(TweenAlphaWrap.SetStartToCurrentValue));
		L.RegFunction("SetEndToCurrentValue", new LuaCSFunction(TweenAlphaWrap.SetEndToCurrentValue));
		L.RegFunction("CopyTo", new LuaCSFunction(TweenAlphaWrap.CopyTo));
		L.RegFunction("__eq", new LuaCSFunction(TweenAlphaWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("from", new LuaCSFunction(TweenAlphaWrap.get_from), new LuaCSFunction(TweenAlphaWrap.set_from));
		L.RegVar("to", new LuaCSFunction(TweenAlphaWrap.get_to), new LuaCSFunction(TweenAlphaWrap.set_to));
		L.RegVar("value", new LuaCSFunction(TweenAlphaWrap.get_value), new LuaCSFunction(TweenAlphaWrap.set_value));
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
			TweenAlpha obj = TweenAlpha.Begin(go, duration, alpha);
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
			TweenAlpha tweenAlpha = (TweenAlpha)ToLua.CheckObject(L, 1, typeof(TweenAlpha));
			tweenAlpha.SetStartToCurrentValue();
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
			TweenAlpha tweenAlpha = (TweenAlpha)ToLua.CheckObject(L, 1, typeof(TweenAlpha));
			tweenAlpha.SetEndToCurrentValue();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CopyTo(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			TweenAlpha tweenAlpha = (TweenAlpha)ToLua.CheckObject(L, 1, typeof(TweenAlpha));
			UITweener to = (UITweener)ToLua.CheckUnityObject(L, 2, typeof(UITweener));
			tweenAlpha.CopyTo(to);
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
			TweenAlpha tweenAlpha = (TweenAlpha)obj;
			float from = tweenAlpha.from;
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
			TweenAlpha tweenAlpha = (TweenAlpha)obj;
			float to = tweenAlpha.to;
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
			TweenAlpha tweenAlpha = (TweenAlpha)obj;
			float value = tweenAlpha.value;
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
			TweenAlpha tweenAlpha = (TweenAlpha)obj;
			float from = (float)LuaDLL.luaL_checknumber(L, 2);
			tweenAlpha.from = from;
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
			TweenAlpha tweenAlpha = (TweenAlpha)obj;
			float to = (float)LuaDLL.luaL_checknumber(L, 2);
			tweenAlpha.to = to;
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
			TweenAlpha tweenAlpha = (TweenAlpha)obj;
			float value = (float)LuaDLL.luaL_checknumber(L, 2);
			tweenAlpha.value = value;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index value on a nil value");
		}
		return result;
	}
}
