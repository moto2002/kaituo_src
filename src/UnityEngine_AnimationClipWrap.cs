using LuaInterface;
using System;
using UnityEngine;

public class UnityEngine_AnimationClipWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(AnimationClip), typeof(UnityEngine.Object), null);
		L.RegFunction("SampleAnimation", new LuaCSFunction(UnityEngine_AnimationClipWrap.SampleAnimation));
		L.RegFunction("SetCurve", new LuaCSFunction(UnityEngine_AnimationClipWrap.SetCurve));
		L.RegFunction("EnsureQuaternionContinuity", new LuaCSFunction(UnityEngine_AnimationClipWrap.EnsureQuaternionContinuity));
		L.RegFunction("ClearCurves", new LuaCSFunction(UnityEngine_AnimationClipWrap.ClearCurves));
		L.RegFunction("AddEvent", new LuaCSFunction(UnityEngine_AnimationClipWrap.AddEvent));
		L.RegFunction("New", new LuaCSFunction(UnityEngine_AnimationClipWrap._CreateUnityEngine_AnimationClip));
		L.RegFunction("__eq", new LuaCSFunction(UnityEngine_AnimationClipWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("length", new LuaCSFunction(UnityEngine_AnimationClipWrap.get_length), null);
		L.RegVar("frameRate", new LuaCSFunction(UnityEngine_AnimationClipWrap.get_frameRate), new LuaCSFunction(UnityEngine_AnimationClipWrap.set_frameRate));
		L.RegVar("wrapMode", new LuaCSFunction(UnityEngine_AnimationClipWrap.get_wrapMode), new LuaCSFunction(UnityEngine_AnimationClipWrap.set_wrapMode));
		L.RegVar("localBounds", new LuaCSFunction(UnityEngine_AnimationClipWrap.get_localBounds), new LuaCSFunction(UnityEngine_AnimationClipWrap.set_localBounds));
		L.RegVar("legacy", new LuaCSFunction(UnityEngine_AnimationClipWrap.get_legacy), new LuaCSFunction(UnityEngine_AnimationClipWrap.set_legacy));
		L.RegVar("humanMotion", new LuaCSFunction(UnityEngine_AnimationClipWrap.get_humanMotion), null);
		L.RegVar("events", new LuaCSFunction(UnityEngine_AnimationClipWrap.get_events), new LuaCSFunction(UnityEngine_AnimationClipWrap.set_events));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateUnityEngine_AnimationClip(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				AnimationClip obj = new AnimationClip();
				ToLua.Push(L, obj);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: UnityEngine.AnimationClip.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SampleAnimation(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			AnimationClip animationClip = (AnimationClip)ToLua.CheckObject(L, 1, typeof(AnimationClip));
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			float time = (float)LuaDLL.luaL_checknumber(L, 3);
			animationClip.SampleAnimation(go, time);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetCurve(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 5);
			AnimationClip animationClip = (AnimationClip)ToLua.CheckObject(L, 1, typeof(AnimationClip));
			string relativePath = ToLua.CheckString(L, 2);
			Type type = (Type)ToLua.CheckObject(L, 3, typeof(Type));
			string propertyName = ToLua.CheckString(L, 4);
			AnimationCurve curve = (AnimationCurve)ToLua.CheckObject(L, 5, typeof(AnimationCurve));
			animationClip.SetCurve(relativePath, type, propertyName, curve);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int EnsureQuaternionContinuity(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			AnimationClip animationClip = (AnimationClip)ToLua.CheckObject(L, 1, typeof(AnimationClip));
			animationClip.EnsureQuaternionContinuity();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ClearCurves(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			AnimationClip animationClip = (AnimationClip)ToLua.CheckObject(L, 1, typeof(AnimationClip));
			animationClip.ClearCurves();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddEvent(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			AnimationClip animationClip = (AnimationClip)ToLua.CheckObject(L, 1, typeof(AnimationClip));
			AnimationEvent evt = (AnimationEvent)ToLua.CheckObject(L, 2, typeof(AnimationEvent));
			animationClip.AddEvent(evt);
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
	private static int get_length(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AnimationClip animationClip = (AnimationClip)obj;
			float length = animationClip.length;
			LuaDLL.lua_pushnumber(L, (double)length);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index length on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_frameRate(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AnimationClip animationClip = (AnimationClip)obj;
			float frameRate = animationClip.frameRate;
			LuaDLL.lua_pushnumber(L, (double)frameRate);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index frameRate on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_wrapMode(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AnimationClip animationClip = (AnimationClip)obj;
			WrapMode wrapMode = animationClip.wrapMode;
			ToLua.Push(L, wrapMode);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index wrapMode on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_localBounds(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AnimationClip animationClip = (AnimationClip)obj;
			Bounds localBounds = animationClip.localBounds;
			ToLua.Push(L, localBounds);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index localBounds on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_legacy(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AnimationClip animationClip = (AnimationClip)obj;
			bool legacy = animationClip.legacy;
			LuaDLL.lua_pushboolean(L, legacy);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index legacy on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_humanMotion(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AnimationClip animationClip = (AnimationClip)obj;
			bool humanMotion = animationClip.humanMotion;
			LuaDLL.lua_pushboolean(L, humanMotion);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index humanMotion on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_events(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AnimationClip animationClip = (AnimationClip)obj;
			AnimationEvent[] events = animationClip.events;
			ToLua.Push(L, events);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index events on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_frameRate(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AnimationClip animationClip = (AnimationClip)obj;
			float frameRate = (float)LuaDLL.luaL_checknumber(L, 2);
			animationClip.frameRate = frameRate;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index frameRate on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_wrapMode(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AnimationClip animationClip = (AnimationClip)obj;
			WrapMode wrapMode = (WrapMode)((int)ToLua.CheckObject(L, 2, typeof(WrapMode)));
			animationClip.wrapMode = wrapMode;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index wrapMode on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_localBounds(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AnimationClip animationClip = (AnimationClip)obj;
			Bounds localBounds = ToLua.ToBounds(L, 2);
			animationClip.localBounds = localBounds;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index localBounds on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_legacy(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AnimationClip animationClip = (AnimationClip)obj;
			bool legacy = LuaDLL.luaL_checkboolean(L, 2);
			animationClip.legacy = legacy;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index legacy on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_events(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AnimationClip animationClip = (AnimationClip)obj;
			AnimationEvent[] events = ToLua.CheckObjectArray<AnimationEvent>(L, 2);
			animationClip.events = events;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index events on a nil value");
		}
		return result;
	}
}
