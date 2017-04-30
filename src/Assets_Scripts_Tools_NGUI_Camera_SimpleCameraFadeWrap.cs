using Assets.Scripts.Tools.NGUI.Camera;
using LuaInterface;
using System;
using UnityEngine;
using UnityEngine.Events;

public class Assets_Scripts_Tools_NGUI_Camera_SimpleCameraFadeWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(SimpleCameraFade), typeof(MonoBehaviour), null);
		L.RegFunction("Awake", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Camera_SimpleCameraFadeWrap.Awake));
		L.RegFunction("FadeIn", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Camera_SimpleCameraFadeWrap.FadeIn));
		L.RegFunction("FadeOut", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Camera_SimpleCameraFadeWrap.FadeOut));
		L.RegFunction("__eq", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Camera_SimpleCameraFadeWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("Panel", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Camera_SimpleCameraFadeWrap.get_Panel), new LuaCSFunction(Assets_Scripts_Tools_NGUI_Camera_SimpleCameraFadeWrap.set_Panel));
		L.RegVar("TweenIn", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Camera_SimpleCameraFadeWrap.get_TweenIn), new LuaCSFunction(Assets_Scripts_Tools_NGUI_Camera_SimpleCameraFadeWrap.set_TweenIn));
		L.RegVar("TweenOut", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Camera_SimpleCameraFadeWrap.get_TweenOut), new LuaCSFunction(Assets_Scripts_Tools_NGUI_Camera_SimpleCameraFadeWrap.set_TweenOut));
		L.RegVar("OnFadeInEndEvent", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Camera_SimpleCameraFadeWrap.get_OnFadeInEndEvent), new LuaCSFunction(Assets_Scripts_Tools_NGUI_Camera_SimpleCameraFadeWrap.set_OnFadeInEndEvent));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Awake(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			SimpleCameraFade simpleCameraFade = (SimpleCameraFade)ToLua.CheckObject(L, 1, typeof(SimpleCameraFade));
			simpleCameraFade.Awake();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int FadeIn(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			SimpleCameraFade simpleCameraFade = (SimpleCameraFade)ToLua.CheckObject(L, 1, typeof(SimpleCameraFade));
			float time = (float)LuaDLL.luaL_checknumber(L, 2);
			simpleCameraFade.FadeIn(time);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int FadeOut(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			SimpleCameraFade simpleCameraFade = (SimpleCameraFade)ToLua.CheckObject(L, 1, typeof(SimpleCameraFade));
			float time = (float)LuaDLL.luaL_checknumber(L, 2);
			simpleCameraFade.FadeOut(time);
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
	private static int get_Panel(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SimpleCameraFade simpleCameraFade = (SimpleCameraFade)obj;
			UIPanel panel = simpleCameraFade.Panel;
			ToLua.Push(L, panel);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Panel on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_TweenIn(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SimpleCameraFade simpleCameraFade = (SimpleCameraFade)obj;
			TweenAlpha tweenIn = simpleCameraFade.TweenIn;
			ToLua.Push(L, tweenIn);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index TweenIn on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_TweenOut(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SimpleCameraFade simpleCameraFade = (SimpleCameraFade)obj;
			TweenAlpha tweenOut = simpleCameraFade.TweenOut;
			ToLua.Push(L, tweenOut);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index TweenOut on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_OnFadeInEndEvent(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SimpleCameraFade simpleCameraFade = (SimpleCameraFade)obj;
			UnityEvent onFadeInEndEvent = simpleCameraFade.OnFadeInEndEvent;
			ToLua.PushObject(L, onFadeInEndEvent);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index OnFadeInEndEvent on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Panel(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SimpleCameraFade simpleCameraFade = (SimpleCameraFade)obj;
			UIPanel panel = (UIPanel)ToLua.CheckUnityObject(L, 2, typeof(UIPanel));
			simpleCameraFade.Panel = panel;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Panel on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_TweenIn(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SimpleCameraFade simpleCameraFade = (SimpleCameraFade)obj;
			TweenAlpha tweenIn = (TweenAlpha)ToLua.CheckUnityObject(L, 2, typeof(TweenAlpha));
			simpleCameraFade.TweenIn = tweenIn;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index TweenIn on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_TweenOut(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SimpleCameraFade simpleCameraFade = (SimpleCameraFade)obj;
			TweenAlpha tweenOut = (TweenAlpha)ToLua.CheckUnityObject(L, 2, typeof(TweenAlpha));
			simpleCameraFade.TweenOut = tweenOut;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index TweenOut on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_OnFadeInEndEvent(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SimpleCameraFade simpleCameraFade = (SimpleCameraFade)obj;
			UnityEvent onFadeInEndEvent = (UnityEvent)ToLua.CheckObject(L, 2, typeof(UnityEvent));
			simpleCameraFade.OnFadeInEndEvent = onFadeInEndEvent;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index OnFadeInEndEvent on a nil value");
		}
		return result;
	}
}
