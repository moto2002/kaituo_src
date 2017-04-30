using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

public class TypewriterEffectWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(TypewriterEffect), typeof(MonoBehaviour), null);
		L.RegFunction("ResetToBeginning", new LuaCSFunction(TypewriterEffectWrap.ResetToBeginning));
		L.RegFunction("Finish", new LuaCSFunction(TypewriterEffectWrap.Finish));
		L.RegFunction("__eq", new LuaCSFunction(TypewriterEffectWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("current", new LuaCSFunction(TypewriterEffectWrap.get_current), new LuaCSFunction(TypewriterEffectWrap.set_current));
		L.RegVar("charsPerSecond", new LuaCSFunction(TypewriterEffectWrap.get_charsPerSecond), new LuaCSFunction(TypewriterEffectWrap.set_charsPerSecond));
		L.RegVar("fadeInTime", new LuaCSFunction(TypewriterEffectWrap.get_fadeInTime), new LuaCSFunction(TypewriterEffectWrap.set_fadeInTime));
		L.RegVar("delayOnPeriod", new LuaCSFunction(TypewriterEffectWrap.get_delayOnPeriod), new LuaCSFunction(TypewriterEffectWrap.set_delayOnPeriod));
		L.RegVar("delayOnNewLine", new LuaCSFunction(TypewriterEffectWrap.get_delayOnNewLine), new LuaCSFunction(TypewriterEffectWrap.set_delayOnNewLine));
		L.RegVar("scrollView", new LuaCSFunction(TypewriterEffectWrap.get_scrollView), new LuaCSFunction(TypewriterEffectWrap.set_scrollView));
		L.RegVar("keepFullDimensions", new LuaCSFunction(TypewriterEffectWrap.get_keepFullDimensions), new LuaCSFunction(TypewriterEffectWrap.set_keepFullDimensions));
		L.RegVar("onFinished", new LuaCSFunction(TypewriterEffectWrap.get_onFinished), new LuaCSFunction(TypewriterEffectWrap.set_onFinished));
		L.RegVar("isActive", new LuaCSFunction(TypewriterEffectWrap.get_isActive), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ResetToBeginning(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			TypewriterEffect typewriterEffect = (TypewriterEffect)ToLua.CheckObject(L, 1, typeof(TypewriterEffect));
			typewriterEffect.ResetToBeginning();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Finish(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			TypewriterEffect typewriterEffect = (TypewriterEffect)ToLua.CheckObject(L, 1, typeof(TypewriterEffect));
			typewriterEffect.Finish();
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
	private static int get_current(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, TypewriterEffect.current);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_charsPerSecond(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TypewriterEffect typewriterEffect = (TypewriterEffect)obj;
			int charsPerSecond = typewriterEffect.charsPerSecond;
			LuaDLL.lua_pushinteger(L, charsPerSecond);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index charsPerSecond on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_fadeInTime(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TypewriterEffect typewriterEffect = (TypewriterEffect)obj;
			float fadeInTime = typewriterEffect.fadeInTime;
			LuaDLL.lua_pushnumber(L, (double)fadeInTime);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index fadeInTime on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_delayOnPeriod(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TypewriterEffect typewriterEffect = (TypewriterEffect)obj;
			float delayOnPeriod = typewriterEffect.delayOnPeriod;
			LuaDLL.lua_pushnumber(L, (double)delayOnPeriod);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index delayOnPeriod on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_delayOnNewLine(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TypewriterEffect typewriterEffect = (TypewriterEffect)obj;
			float delayOnNewLine = typewriterEffect.delayOnNewLine;
			LuaDLL.lua_pushnumber(L, (double)delayOnNewLine);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index delayOnNewLine on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_scrollView(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TypewriterEffect typewriterEffect = (TypewriterEffect)obj;
			UIScrollView scrollView = typewriterEffect.scrollView;
			ToLua.Push(L, scrollView);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index scrollView on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_keepFullDimensions(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TypewriterEffect typewriterEffect = (TypewriterEffect)obj;
			bool keepFullDimensions = typewriterEffect.keepFullDimensions;
			LuaDLL.lua_pushboolean(L, keepFullDimensions);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index keepFullDimensions on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onFinished(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TypewriterEffect typewriterEffect = (TypewriterEffect)obj;
			List<EventDelegate> onFinished = typewriterEffect.onFinished;
			ToLua.PushObject(L, onFinished);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onFinished on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isActive(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TypewriterEffect typewriterEffect = (TypewriterEffect)obj;
			bool isActive = typewriterEffect.isActive;
			LuaDLL.lua_pushboolean(L, isActive);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isActive on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_current(IntPtr L)
	{
		int result;
		try
		{
			TypewriterEffect current = (TypewriterEffect)ToLua.CheckUnityObject(L, 2, typeof(TypewriterEffect));
			TypewriterEffect.current = current;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_charsPerSecond(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TypewriterEffect typewriterEffect = (TypewriterEffect)obj;
			int charsPerSecond = (int)LuaDLL.luaL_checknumber(L, 2);
			typewriterEffect.charsPerSecond = charsPerSecond;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index charsPerSecond on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_fadeInTime(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TypewriterEffect typewriterEffect = (TypewriterEffect)obj;
			float fadeInTime = (float)LuaDLL.luaL_checknumber(L, 2);
			typewriterEffect.fadeInTime = fadeInTime;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index fadeInTime on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_delayOnPeriod(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TypewriterEffect typewriterEffect = (TypewriterEffect)obj;
			float delayOnPeriod = (float)LuaDLL.luaL_checknumber(L, 2);
			typewriterEffect.delayOnPeriod = delayOnPeriod;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index delayOnPeriod on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_delayOnNewLine(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TypewriterEffect typewriterEffect = (TypewriterEffect)obj;
			float delayOnNewLine = (float)LuaDLL.luaL_checknumber(L, 2);
			typewriterEffect.delayOnNewLine = delayOnNewLine;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index delayOnNewLine on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_scrollView(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TypewriterEffect typewriterEffect = (TypewriterEffect)obj;
			UIScrollView scrollView = (UIScrollView)ToLua.CheckUnityObject(L, 2, typeof(UIScrollView));
			typewriterEffect.scrollView = scrollView;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index scrollView on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_keepFullDimensions(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TypewriterEffect typewriterEffect = (TypewriterEffect)obj;
			bool keepFullDimensions = LuaDLL.luaL_checkboolean(L, 2);
			typewriterEffect.keepFullDimensions = keepFullDimensions;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index keepFullDimensions on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onFinished(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TypewriterEffect typewriterEffect = (TypewriterEffect)obj;
			List<EventDelegate> onFinished = (List<EventDelegate>)ToLua.CheckObject(L, 2, typeof(List<EventDelegate>));
			typewriterEffect.onFinished = onFinished;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onFinished on a nil value");
		}
		return result;
	}
}
