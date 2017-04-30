using LuaInterface;
using System;
using UnityEngine;

public class UnityEngine_AnimationCurveWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(AnimationCurve), typeof(object), null);
		L.RegFunction("Evaluate", new LuaCSFunction(UnityEngine_AnimationCurveWrap.Evaluate));
		L.RegFunction("AddKey", new LuaCSFunction(UnityEngine_AnimationCurveWrap.AddKey));
		L.RegFunction("MoveKey", new LuaCSFunction(UnityEngine_AnimationCurveWrap.MoveKey));
		L.RegFunction("RemoveKey", new LuaCSFunction(UnityEngine_AnimationCurveWrap.RemoveKey));
		L.RegFunction(".geti", new LuaCSFunction(UnityEngine_AnimationCurveWrap.get_Item));
		L.RegFunction("get_Item", new LuaCSFunction(UnityEngine_AnimationCurveWrap.get_Item));
		L.RegFunction("SmoothTangents", new LuaCSFunction(UnityEngine_AnimationCurveWrap.SmoothTangents));
		L.RegFunction("Linear", new LuaCSFunction(UnityEngine_AnimationCurveWrap.Linear));
		L.RegFunction("EaseInOut", new LuaCSFunction(UnityEngine_AnimationCurveWrap.EaseInOut));
		L.RegFunction("New", new LuaCSFunction(UnityEngine_AnimationCurveWrap._CreateUnityEngine_AnimationCurve));
		L.RegVar("this", new LuaCSFunction(UnityEngine_AnimationCurveWrap._this), null);
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("keys", new LuaCSFunction(UnityEngine_AnimationCurveWrap.get_keys), new LuaCSFunction(UnityEngine_AnimationCurveWrap.set_keys));
		L.RegVar("length", new LuaCSFunction(UnityEngine_AnimationCurveWrap.get_length), null);
		L.RegVar("preWrapMode", new LuaCSFunction(UnityEngine_AnimationCurveWrap.get_preWrapMode), new LuaCSFunction(UnityEngine_AnimationCurveWrap.set_preWrapMode));
		L.RegVar("postWrapMode", new LuaCSFunction(UnityEngine_AnimationCurveWrap.get_postWrapMode), new LuaCSFunction(UnityEngine_AnimationCurveWrap.set_postWrapMode));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateUnityEngine_AnimationCurve(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 0)
			{
				AnimationCurve o = new AnimationCurve();
				ToLua.PushObject(L, o);
				result = 1;
			}
			else if (TypeChecker.CheckParamsType(L, typeof(Keyframe), 1, num))
			{
				Keyframe[] keys = ToLua.CheckParamsObject<Keyframe>(L, 1, num);
				AnimationCurve o2 = new AnimationCurve(keys);
				ToLua.PushObject(L, o2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: UnityEngine.AnimationCurve.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _get_this(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			AnimationCurve animationCurve = (AnimationCurve)ToLua.CheckObject(L, 1, typeof(AnimationCurve));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			Keyframe keyframe = animationCurve[index];
			ToLua.PushValue(L, keyframe);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _this(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushvalue(L, 1);
			LuaDLL.tolua_bindthis(L, new LuaCSFunction(UnityEngine_AnimationCurveWrap._get_this), null);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Evaluate(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			AnimationCurve animationCurve = (AnimationCurve)ToLua.CheckObject(L, 1, typeof(AnimationCurve));
			float time = (float)LuaDLL.luaL_checknumber(L, 2);
			float num = animationCurve.Evaluate(time);
			LuaDLL.lua_pushnumber(L, (double)num);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddKey(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(AnimationCurve), typeof(Keyframe)))
			{
				AnimationCurve animationCurve = (AnimationCurve)ToLua.ToObject(L, 1);
				Keyframe key = (Keyframe)ToLua.ToObject(L, 2);
				int n = animationCurve.AddKey(key);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(AnimationCurve), typeof(float), typeof(float)))
			{
				AnimationCurve animationCurve2 = (AnimationCurve)ToLua.ToObject(L, 1);
				float time = (float)LuaDLL.lua_tonumber(L, 2);
				float value = (float)LuaDLL.lua_tonumber(L, 3);
				int n2 = animationCurve2.AddKey(time, value);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.AnimationCurve.AddKey");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int MoveKey(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			AnimationCurve animationCurve = (AnimationCurve)ToLua.CheckObject(L, 1, typeof(AnimationCurve));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			Keyframe key = (Keyframe)ToLua.CheckObject(L, 3, typeof(Keyframe));
			int n = animationCurve.MoveKey(index, key);
			LuaDLL.lua_pushinteger(L, n);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RemoveKey(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			AnimationCurve animationCurve = (AnimationCurve)ToLua.CheckObject(L, 1, typeof(AnimationCurve));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			animationCurve.RemoveKey(index);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Item(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			AnimationCurve animationCurve = (AnimationCurve)ToLua.CheckObject(L, 1, typeof(AnimationCurve));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			Keyframe keyframe = animationCurve[index];
			ToLua.PushValue(L, keyframe);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SmoothTangents(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			AnimationCurve animationCurve = (AnimationCurve)ToLua.CheckObject(L, 1, typeof(AnimationCurve));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			float weight = (float)LuaDLL.luaL_checknumber(L, 3);
			animationCurve.SmoothTangents(index, weight);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Linear(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			float timeStart = (float)LuaDLL.luaL_checknumber(L, 1);
			float valueStart = (float)LuaDLL.luaL_checknumber(L, 2);
			float timeEnd = (float)LuaDLL.luaL_checknumber(L, 3);
			float valueEnd = (float)LuaDLL.luaL_checknumber(L, 4);
			AnimationCurve o = AnimationCurve.Linear(timeStart, valueStart, timeEnd, valueEnd);
			ToLua.PushObject(L, o);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int EaseInOut(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			float timeStart = (float)LuaDLL.luaL_checknumber(L, 1);
			float valueStart = (float)LuaDLL.luaL_checknumber(L, 2);
			float timeEnd = (float)LuaDLL.luaL_checknumber(L, 3);
			float valueEnd = (float)LuaDLL.luaL_checknumber(L, 4);
			AnimationCurve o = AnimationCurve.EaseInOut(timeStart, valueStart, timeEnd, valueEnd);
			ToLua.PushObject(L, o);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_keys(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AnimationCurve animationCurve = (AnimationCurve)obj;
			Keyframe[] keys = animationCurve.keys;
			ToLua.Push(L, keys);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index keys on a nil value");
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
			AnimationCurve animationCurve = (AnimationCurve)obj;
			int length = animationCurve.length;
			LuaDLL.lua_pushinteger(L, length);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index length on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_preWrapMode(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AnimationCurve animationCurve = (AnimationCurve)obj;
			WrapMode preWrapMode = animationCurve.preWrapMode;
			ToLua.Push(L, preWrapMode);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index preWrapMode on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_postWrapMode(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AnimationCurve animationCurve = (AnimationCurve)obj;
			WrapMode postWrapMode = animationCurve.postWrapMode;
			ToLua.Push(L, postWrapMode);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index postWrapMode on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_keys(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AnimationCurve animationCurve = (AnimationCurve)obj;
			Keyframe[] keys = ToLua.CheckObjectArray<Keyframe>(L, 2);
			animationCurve.keys = keys;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index keys on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_preWrapMode(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AnimationCurve animationCurve = (AnimationCurve)obj;
			WrapMode preWrapMode = (WrapMode)((int)ToLua.CheckObject(L, 2, typeof(WrapMode)));
			animationCurve.preWrapMode = preWrapMode;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index preWrapMode on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_postWrapMode(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AnimationCurve animationCurve = (AnimationCurve)obj;
			WrapMode postWrapMode = (WrapMode)((int)ToLua.CheckObject(L, 2, typeof(WrapMode)));
			animationCurve.postWrapMode = postWrapMode;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index postWrapMode on a nil value");
		}
		return result;
	}
}
