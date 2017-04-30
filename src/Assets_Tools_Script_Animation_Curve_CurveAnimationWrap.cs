using Assets.Tools.Script.Animation.Curve;
using Assets.Tools.Script.Event;
using LuaInterface;
using System;
using UnityEngine;

public class Assets_Tools_Script_Animation_Curve_CurveAnimationWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(CurveAnimation), typeof(MonoBehaviour), null);
		L.RegFunction("Reset", new LuaCSFunction(Assets_Tools_Script_Animation_Curve_CurveAnimationWrap.Reset));
		L.RegFunction("Pause", new LuaCSFunction(Assets_Tools_Script_Animation_Curve_CurveAnimationWrap.Pause));
		L.RegFunction("Finish", new LuaCSFunction(Assets_Tools_Script_Animation_Curve_CurveAnimationWrap.Finish));
		L.RegFunction("Play", new LuaCSFunction(Assets_Tools_Script_Animation_Curve_CurveAnimationWrap.Play));
		L.RegFunction("PlayForward", new LuaCSFunction(Assets_Tools_Script_Animation_Curve_CurveAnimationWrap.PlayForward));
		L.RegFunction("PlayReverse", new LuaCSFunction(Assets_Tools_Script_Animation_Curve_CurveAnimationWrap.PlayReverse));
		L.RegFunction("__eq", new LuaCSFunction(Assets_Tools_Script_Animation_Curve_CurveAnimationWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("curve", new LuaCSFunction(Assets_Tools_Script_Animation_Curve_CurveAnimationWrap.get_curve), new LuaCSFunction(Assets_Tools_Script_Animation_Curve_CurveAnimationWrap.set_curve));
		L.RegVar("onFinishSignal", new LuaCSFunction(Assets_Tools_Script_Animation_Curve_CurveAnimationWrap.get_onFinishSignal), null);
		L.RegVar("isForward", new LuaCSFunction(Assets_Tools_Script_Animation_Curve_CurveAnimationWrap.get_isForward), null);
		L.RegVar("started", new LuaCSFunction(Assets_Tools_Script_Animation_Curve_CurveAnimationWrap.get_started), null);
		L.RegVar("playing", new LuaCSFunction(Assets_Tools_Script_Animation_Curve_CurveAnimationWrap.get_playing), null);
		L.RegVar("paused", new LuaCSFunction(Assets_Tools_Script_Animation_Curve_CurveAnimationWrap.get_paused), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Reset(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			CurveAnimation curveAnimation = (CurveAnimation)ToLua.CheckObject(L, 1, typeof(CurveAnimation));
			curveAnimation.Reset();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Pause(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			CurveAnimation curveAnimation = (CurveAnimation)ToLua.CheckObject(L, 1, typeof(CurveAnimation));
			curveAnimation.Pause();
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
			CurveAnimation curveAnimation = (CurveAnimation)ToLua.CheckObject(L, 1, typeof(CurveAnimation));
			curveAnimation.Finish();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Play(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			CurveAnimation curveAnimation = (CurveAnimation)ToLua.CheckObject(L, 1, typeof(CurveAnimation));
			bool forward = LuaDLL.luaL_checkboolean(L, 2);
			curveAnimation.Play(forward);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PlayForward(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			CurveAnimation curveAnimation = (CurveAnimation)ToLua.CheckObject(L, 1, typeof(CurveAnimation));
			curveAnimation.PlayForward();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PlayReverse(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			CurveAnimation curveAnimation = (CurveAnimation)ToLua.CheckObject(L, 1, typeof(CurveAnimation));
			curveAnimation.PlayReverse();
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
	private static int get_curve(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CurveAnimation curveAnimation = (CurveAnimation)obj;
			AnimationCurve curve = curveAnimation.curve;
			ToLua.PushObject(L, curve);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index curve on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onFinishSignal(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CurveAnimation curveAnimation = (CurveAnimation)obj;
			Signal<CurveAnimation> onFinishSignal = curveAnimation.onFinishSignal;
			ToLua.PushObject(L, onFinishSignal);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onFinishSignal on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isForward(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CurveAnimation curveAnimation = (CurveAnimation)obj;
			bool isForward = curveAnimation.isForward;
			LuaDLL.lua_pushboolean(L, isForward);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isForward on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_started(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CurveAnimation curveAnimation = (CurveAnimation)obj;
			bool started = curveAnimation.started;
			LuaDLL.lua_pushboolean(L, started);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index started on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_playing(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CurveAnimation curveAnimation = (CurveAnimation)obj;
			bool playing = curveAnimation.playing;
			LuaDLL.lua_pushboolean(L, playing);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index playing on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_paused(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CurveAnimation curveAnimation = (CurveAnimation)obj;
			bool paused = curveAnimation.paused;
			LuaDLL.lua_pushboolean(L, paused);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index paused on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_curve(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CurveAnimation curveAnimation = (CurveAnimation)obj;
			AnimationCurve curve = (AnimationCurve)ToLua.CheckObject(L, 2, typeof(AnimationCurve));
			curveAnimation.curve = curve;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index curve on a nil value");
		}
		return result;
	}
}
