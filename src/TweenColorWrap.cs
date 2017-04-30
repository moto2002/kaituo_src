using LuaInterface;
using System;
using UnityEngine;

public class TweenColorWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(TweenColor), typeof(UITweener), null);
		L.RegFunction("Begin", new LuaCSFunction(TweenColorWrap.Begin));
		L.RegFunction("SetStartToCurrentValue", new LuaCSFunction(TweenColorWrap.SetStartToCurrentValue));
		L.RegFunction("SetEndToCurrentValue", new LuaCSFunction(TweenColorWrap.SetEndToCurrentValue));
		L.RegFunction("CopyTo", new LuaCSFunction(TweenColorWrap.CopyTo));
		L.RegFunction("__eq", new LuaCSFunction(TweenColorWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("from", new LuaCSFunction(TweenColorWrap.get_from), new LuaCSFunction(TweenColorWrap.set_from));
		L.RegVar("to", new LuaCSFunction(TweenColorWrap.get_to), new LuaCSFunction(TweenColorWrap.set_to));
		L.RegVar("value", new LuaCSFunction(TweenColorWrap.get_value), new LuaCSFunction(TweenColorWrap.set_value));
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
			Color color = ToLua.ToColor(L, 3);
			TweenColor obj = TweenColor.Begin(go, duration, color);
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
			TweenColor tweenColor = (TweenColor)ToLua.CheckObject(L, 1, typeof(TweenColor));
			tweenColor.SetStartToCurrentValue();
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
			TweenColor tweenColor = (TweenColor)ToLua.CheckObject(L, 1, typeof(TweenColor));
			tweenColor.SetEndToCurrentValue();
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
			TweenColor tweenColor = (TweenColor)ToLua.CheckObject(L, 1, typeof(TweenColor));
			UITweener to = (UITweener)ToLua.CheckUnityObject(L, 2, typeof(UITweener));
			tweenColor.CopyTo(to);
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
			TweenColor tweenColor = (TweenColor)obj;
			Color from = tweenColor.from;
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
			TweenColor tweenColor = (TweenColor)obj;
			Color to = tweenColor.to;
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
			TweenColor tweenColor = (TweenColor)obj;
			Color value = tweenColor.value;
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
			TweenColor tweenColor = (TweenColor)obj;
			Color from = ToLua.ToColor(L, 2);
			tweenColor.from = from;
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
			TweenColor tweenColor = (TweenColor)obj;
			Color to = ToLua.ToColor(L, 2);
			tweenColor.to = to;
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
			TweenColor tweenColor = (TweenColor)obj;
			Color value = ToLua.ToColor(L, 2);
			tweenColor.value = value;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index value on a nil value");
		}
		return result;
	}
}
