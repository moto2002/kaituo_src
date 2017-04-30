using AnimationOrTween;
using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

public class UITweenerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UITweener), typeof(MonoBehaviour), null);
		L.RegFunction("OnDestroy", new LuaCSFunction(UITweenerWrap.OnDestroy));
		L.RegFunction("Awake", new LuaCSFunction(UITweenerWrap.Awake));
		L.RegFunction("StopAllTweeners", new LuaCSFunction(UITweenerWrap.StopAllTweeners));
		L.RegFunction("SetOnFinished", new LuaCSFunction(UITweenerWrap.SetOnFinished));
		L.RegFunction("AddOnFinished", new LuaCSFunction(UITweenerWrap.AddOnFinished));
		L.RegFunction("RemoveOnFinished", new LuaCSFunction(UITweenerWrap.RemoveOnFinished));
		L.RegFunction("Sample", new LuaCSFunction(UITweenerWrap.Sample));
		L.RegFunction("PlayForward", new LuaCSFunction(UITweenerWrap.PlayForward));
		L.RegFunction("PlayReverse", new LuaCSFunction(UITweenerWrap.PlayReverse));
		L.RegFunction("Play", new LuaCSFunction(UITweenerWrap.Play));
		L.RegFunction("ResetToBeginning", new LuaCSFunction(UITweenerWrap.ResetToBeginning));
		L.RegFunction("Toggle", new LuaCSFunction(UITweenerWrap.Toggle));
		L.RegFunction("CopyTo", new LuaCSFunction(UITweenerWrap.CopyTo));
		L.RegFunction("SetStartToCurrentValue", new LuaCSFunction(UITweenerWrap.SetStartToCurrentValue));
		L.RegFunction("SetEndToCurrentValue", new LuaCSFunction(UITweenerWrap.SetEndToCurrentValue));
		L.RegFunction("__eq", new LuaCSFunction(UITweenerWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("current", new LuaCSFunction(UITweenerWrap.get_current), new LuaCSFunction(UITweenerWrap.set_current));
		L.RegVar("method", new LuaCSFunction(UITweenerWrap.get_method), new LuaCSFunction(UITweenerWrap.set_method));
		L.RegVar("style", new LuaCSFunction(UITweenerWrap.get_style), new LuaCSFunction(UITweenerWrap.set_style));
		L.RegVar("animationCurve", new LuaCSFunction(UITweenerWrap.get_animationCurve), new LuaCSFunction(UITweenerWrap.set_animationCurve));
		L.RegVar("ignoreTimeScale", new LuaCSFunction(UITweenerWrap.get_ignoreTimeScale), new LuaCSFunction(UITweenerWrap.set_ignoreTimeScale));
		L.RegVar("delay", new LuaCSFunction(UITweenerWrap.get_delay), new LuaCSFunction(UITweenerWrap.set_delay));
		L.RegVar("duration", new LuaCSFunction(UITweenerWrap.get_duration), new LuaCSFunction(UITweenerWrap.set_duration));
		L.RegVar("steeperCurves", new LuaCSFunction(UITweenerWrap.get_steeperCurves), new LuaCSFunction(UITweenerWrap.set_steeperCurves));
		L.RegVar("tweenGroup", new LuaCSFunction(UITweenerWrap.get_tweenGroup), new LuaCSFunction(UITweenerWrap.set_tweenGroup));
		L.RegVar("interval", new LuaCSFunction(UITweenerWrap.get_interval), new LuaCSFunction(UITweenerWrap.set_interval));
		L.RegVar("onFinished", new LuaCSFunction(UITweenerWrap.get_onFinished), new LuaCSFunction(UITweenerWrap.set_onFinished));
		L.RegVar("eventReceiver", new LuaCSFunction(UITweenerWrap.get_eventReceiver), new LuaCSFunction(UITweenerWrap.set_eventReceiver));
		L.RegVar("callWhenFinished", new LuaCSFunction(UITweenerWrap.get_callWhenFinished), new LuaCSFunction(UITweenerWrap.set_callWhenFinished));
		L.RegVar("intervalEndTime", new LuaCSFunction(UITweenerWrap.get_intervalEndTime), new LuaCSFunction(UITweenerWrap.set_intervalEndTime));
		L.RegVar("firstStartIgnoreInterval", new LuaCSFunction(UITweenerWrap.get_firstStartIgnoreInterval), new LuaCSFunction(UITweenerWrap.set_firstStartIgnoreInterval));
		L.RegVar("amountPerDelta", new LuaCSFunction(UITweenerWrap.get_amountPerDelta), null);
		L.RegVar("tweenFactor", new LuaCSFunction(UITweenerWrap.get_tweenFactor), new LuaCSFunction(UITweenerWrap.set_tweenFactor));
		L.RegVar("direction", new LuaCSFunction(UITweenerWrap.get_direction), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnDestroy(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UITweener uITweener = (UITweener)ToLua.CheckObject(L, 1, typeof(UITweener));
			uITweener.OnDestroy();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Awake(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UITweener uITweener = (UITweener)ToLua.CheckObject(L, 1, typeof(UITweener));
			uITweener.Awake();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int StopAllTweeners(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			UITweener.StopAllTweeners();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetOnFinished(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(UITweener), typeof(EventDelegate)))
			{
				UITweener uITweener = (UITweener)ToLua.ToObject(L, 1);
				EventDelegate onFinished = (EventDelegate)ToLua.ToObject(L, 2);
				uITweener.SetOnFinished(onFinished);
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(UITweener), typeof(EventDelegate.Callback)))
			{
				UITweener uITweener2 = (UITweener)ToLua.ToObject(L, 1);
				LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
				EventDelegate.Callback onFinished2;
				if (luaTypes != LuaTypes.LUA_TFUNCTION)
				{
					onFinished2 = (EventDelegate.Callback)ToLua.ToObject(L, 2);
				}
				else
				{
					LuaFunction func = ToLua.ToLuaFunction(L, 2);
					onFinished2 = (DelegateFactory.CreateDelegate(typeof(EventDelegate.Callback), func) as EventDelegate.Callback);
				}
				uITweener2.SetOnFinished(onFinished2);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UITweener.SetOnFinished");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddOnFinished(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(UITweener), typeof(EventDelegate)))
			{
				UITweener uITweener = (UITweener)ToLua.ToObject(L, 1);
				EventDelegate del = (EventDelegate)ToLua.ToObject(L, 2);
				uITweener.AddOnFinished(del);
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(UITweener), typeof(EventDelegate.Callback)))
			{
				UITweener uITweener2 = (UITweener)ToLua.ToObject(L, 1);
				LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
				EventDelegate.Callback del2;
				if (luaTypes != LuaTypes.LUA_TFUNCTION)
				{
					del2 = (EventDelegate.Callback)ToLua.ToObject(L, 2);
				}
				else
				{
					LuaFunction func = ToLua.ToLuaFunction(L, 2);
					del2 = (DelegateFactory.CreateDelegate(typeof(EventDelegate.Callback), func) as EventDelegate.Callback);
				}
				uITweener2.AddOnFinished(del2);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UITweener.AddOnFinished");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RemoveOnFinished(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UITweener uITweener = (UITweener)ToLua.CheckObject(L, 1, typeof(UITweener));
			EventDelegate del = (EventDelegate)ToLua.CheckObject(L, 2, typeof(EventDelegate));
			uITweener.RemoveOnFinished(del);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Sample(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			UITweener uITweener = (UITweener)ToLua.CheckObject(L, 1, typeof(UITweener));
			float factor = (float)LuaDLL.luaL_checknumber(L, 2);
			bool isFinished = LuaDLL.luaL_checkboolean(L, 3);
			uITweener.Sample(factor, isFinished);
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
			UITweener uITweener = (UITweener)ToLua.CheckObject(L, 1, typeof(UITweener));
			uITweener.PlayForward();
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
			UITweener uITweener = (UITweener)ToLua.CheckObject(L, 1, typeof(UITweener));
			uITweener.PlayReverse();
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
			UITweener uITweener = (UITweener)ToLua.CheckObject(L, 1, typeof(UITweener));
			bool forward = LuaDLL.luaL_checkboolean(L, 2);
			uITweener.Play(forward);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ResetToBeginning(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UITweener uITweener = (UITweener)ToLua.CheckObject(L, 1, typeof(UITweener));
			uITweener.ResetToBeginning();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Toggle(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UITweener uITweener = (UITweener)ToLua.CheckObject(L, 1, typeof(UITweener));
			uITweener.Toggle();
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
			UITweener uITweener = (UITweener)ToLua.CheckObject(L, 1, typeof(UITweener));
			UITweener to = (UITweener)ToLua.CheckUnityObject(L, 2, typeof(UITweener));
			uITweener.CopyTo(to);
			result = 0;
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
			UITweener uITweener = (UITweener)ToLua.CheckObject(L, 1, typeof(UITweener));
			uITweener.SetStartToCurrentValue();
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
			UITweener uITweener = (UITweener)ToLua.CheckObject(L, 1, typeof(UITweener));
			uITweener.SetEndToCurrentValue();
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
			ToLua.Push(L, UITweener.current);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_method(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITweener uITweener = (UITweener)obj;
			UITweener.Method method = uITweener.method;
			ToLua.Push(L, method);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index method on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_style(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITweener uITweener = (UITweener)obj;
			UITweener.Style style = uITweener.style;
			ToLua.Push(L, style);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index style on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_animationCurve(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITweener uITweener = (UITweener)obj;
			AnimationCurve animationCurve = uITweener.animationCurve;
			ToLua.PushObject(L, animationCurve);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index animationCurve on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_ignoreTimeScale(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITweener uITweener = (UITweener)obj;
			bool ignoreTimeScale = uITweener.ignoreTimeScale;
			LuaDLL.lua_pushboolean(L, ignoreTimeScale);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ignoreTimeScale on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_delay(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITweener uITweener = (UITweener)obj;
			float delay = uITweener.delay;
			LuaDLL.lua_pushnumber(L, (double)delay);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index delay on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_duration(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITweener uITweener = (UITweener)obj;
			float duration = uITweener.duration;
			LuaDLL.lua_pushnumber(L, (double)duration);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index duration on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_steeperCurves(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITweener uITweener = (UITweener)obj;
			bool steeperCurves = uITweener.steeperCurves;
			LuaDLL.lua_pushboolean(L, steeperCurves);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index steeperCurves on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_tweenGroup(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITweener uITweener = (UITweener)obj;
			int tweenGroup = uITweener.tweenGroup;
			LuaDLL.lua_pushinteger(L, tweenGroup);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index tweenGroup on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_interval(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITweener uITweener = (UITweener)obj;
			float interval = uITweener.interval;
			LuaDLL.lua_pushnumber(L, (double)interval);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index interval on a nil value");
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
			UITweener uITweener = (UITweener)obj;
			List<EventDelegate> onFinished = uITweener.onFinished;
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
	private static int get_eventReceiver(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITweener uITweener = (UITweener)obj;
			GameObject eventReceiver = uITweener.eventReceiver;
			ToLua.Push(L, eventReceiver);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index eventReceiver on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_callWhenFinished(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITweener uITweener = (UITweener)obj;
			string callWhenFinished = uITweener.callWhenFinished;
			LuaDLL.lua_pushstring(L, callWhenFinished);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index callWhenFinished on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_intervalEndTime(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITweener uITweener = (UITweener)obj;
			float intervalEndTime = uITweener.intervalEndTime;
			LuaDLL.lua_pushnumber(L, (double)intervalEndTime);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index intervalEndTime on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_firstStartIgnoreInterval(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITweener uITweener = (UITweener)obj;
			bool firstStartIgnoreInterval = uITweener.firstStartIgnoreInterval;
			LuaDLL.lua_pushboolean(L, firstStartIgnoreInterval);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index firstStartIgnoreInterval on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_amountPerDelta(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITweener uITweener = (UITweener)obj;
			float amountPerDelta = uITweener.amountPerDelta;
			LuaDLL.lua_pushnumber(L, (double)amountPerDelta);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index amountPerDelta on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_tweenFactor(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITweener uITweener = (UITweener)obj;
			float tweenFactor = uITweener.tweenFactor;
			LuaDLL.lua_pushnumber(L, (double)tweenFactor);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index tweenFactor on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_direction(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITweener uITweener = (UITweener)obj;
			Direction direction = uITweener.direction;
			ToLua.Push(L, direction);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index direction on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_current(IntPtr L)
	{
		int result;
		try
		{
			UITweener current = (UITweener)ToLua.CheckUnityObject(L, 2, typeof(UITweener));
			UITweener.current = current;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_method(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITweener uITweener = (UITweener)obj;
			UITweener.Method method = (UITweener.Method)LuaDLL.luaL_checknumber(L, 2);
			uITweener.method = method;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index method on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_style(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITweener uITweener = (UITweener)obj;
			UITweener.Style style = (UITweener.Style)LuaDLL.luaL_checknumber(L, 2);
			uITweener.style = style;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index style on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_animationCurve(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITweener uITweener = (UITweener)obj;
			AnimationCurve animationCurve = (AnimationCurve)ToLua.CheckObject(L, 2, typeof(AnimationCurve));
			uITweener.animationCurve = animationCurve;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index animationCurve on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_ignoreTimeScale(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITweener uITweener = (UITweener)obj;
			bool ignoreTimeScale = LuaDLL.luaL_checkboolean(L, 2);
			uITweener.ignoreTimeScale = ignoreTimeScale;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ignoreTimeScale on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_delay(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITweener uITweener = (UITweener)obj;
			float delay = (float)LuaDLL.luaL_checknumber(L, 2);
			uITweener.delay = delay;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index delay on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_duration(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITweener uITweener = (UITweener)obj;
			float duration = (float)LuaDLL.luaL_checknumber(L, 2);
			uITweener.duration = duration;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index duration on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_steeperCurves(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITweener uITweener = (UITweener)obj;
			bool steeperCurves = LuaDLL.luaL_checkboolean(L, 2);
			uITweener.steeperCurves = steeperCurves;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index steeperCurves on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_tweenGroup(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITweener uITweener = (UITweener)obj;
			int tweenGroup = (int)LuaDLL.luaL_checknumber(L, 2);
			uITweener.tweenGroup = tweenGroup;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index tweenGroup on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_interval(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITweener uITweener = (UITweener)obj;
			float interval = (float)LuaDLL.luaL_checknumber(L, 2);
			uITweener.interval = interval;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index interval on a nil value");
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
			UITweener uITweener = (UITweener)obj;
			List<EventDelegate> onFinished = (List<EventDelegate>)ToLua.CheckObject(L, 2, typeof(List<EventDelegate>));
			uITweener.onFinished = onFinished;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onFinished on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_eventReceiver(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITweener uITweener = (UITweener)obj;
			GameObject eventReceiver = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			uITweener.eventReceiver = eventReceiver;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index eventReceiver on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_callWhenFinished(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITweener uITweener = (UITweener)obj;
			string callWhenFinished = ToLua.CheckString(L, 2);
			uITweener.callWhenFinished = callWhenFinished;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index callWhenFinished on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_intervalEndTime(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITweener uITweener = (UITweener)obj;
			float intervalEndTime = (float)LuaDLL.luaL_checknumber(L, 2);
			uITweener.intervalEndTime = intervalEndTime;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index intervalEndTime on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_firstStartIgnoreInterval(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITweener uITweener = (UITweener)obj;
			bool firstStartIgnoreInterval = LuaDLL.luaL_checkboolean(L, 2);
			uITweener.firstStartIgnoreInterval = firstStartIgnoreInterval;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index firstStartIgnoreInterval on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_tweenFactor(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITweener uITweener = (UITweener)obj;
			float tweenFactor = (float)LuaDLL.luaL_checknumber(L, 2);
			uITweener.tweenFactor = tweenFactor;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index tweenFactor on a nil value");
		}
		return result;
	}
}
