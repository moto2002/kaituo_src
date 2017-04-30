using LuaInterface;
using System;
using UnityEngine;

public class TweenRotationWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(TweenRotation), typeof(UITweener), null);
		L.RegFunction("Begin", new LuaCSFunction(TweenRotationWrap.Begin));
		L.RegFunction("SetStartToCurrentValue", new LuaCSFunction(TweenRotationWrap.SetStartToCurrentValue));
		L.RegFunction("SetEndToCurrentValue", new LuaCSFunction(TweenRotationWrap.SetEndToCurrentValue));
		L.RegFunction("__eq", new LuaCSFunction(TweenRotationWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("from", new LuaCSFunction(TweenRotationWrap.get_from), new LuaCSFunction(TweenRotationWrap.set_from));
		L.RegVar("to", new LuaCSFunction(TweenRotationWrap.get_to), new LuaCSFunction(TweenRotationWrap.set_to));
		L.RegVar("quaternionLerp", new LuaCSFunction(TweenRotationWrap.get_quaternionLerp), new LuaCSFunction(TweenRotationWrap.set_quaternionLerp));
		L.RegVar("cachedTransform", new LuaCSFunction(TweenRotationWrap.get_cachedTransform), null);
		L.RegVar("value", new LuaCSFunction(TweenRotationWrap.get_value), new LuaCSFunction(TweenRotationWrap.set_value));
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
			Quaternion rot = ToLua.ToQuaternion(L, 3);
			TweenRotation obj = TweenRotation.Begin(go, duration, rot);
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
			TweenRotation tweenRotation = (TweenRotation)ToLua.CheckObject(L, 1, typeof(TweenRotation));
			tweenRotation.SetStartToCurrentValue();
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
			TweenRotation tweenRotation = (TweenRotation)ToLua.CheckObject(L, 1, typeof(TweenRotation));
			tweenRotation.SetEndToCurrentValue();
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
			TweenRotation tweenRotation = (TweenRotation)obj;
			Vector3 from = tweenRotation.from;
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
			TweenRotation tweenRotation = (TweenRotation)obj;
			Vector3 to = tweenRotation.to;
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
	private static int get_quaternionLerp(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TweenRotation tweenRotation = (TweenRotation)obj;
			bool quaternionLerp = tweenRotation.quaternionLerp;
			LuaDLL.lua_pushboolean(L, quaternionLerp);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index quaternionLerp on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_cachedTransform(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TweenRotation tweenRotation = (TweenRotation)obj;
			Transform cachedTransform = tweenRotation.cachedTransform;
			ToLua.Push(L, cachedTransform);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cachedTransform on a nil value");
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
			TweenRotation tweenRotation = (TweenRotation)obj;
			Quaternion value = tweenRotation.value;
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
			TweenRotation tweenRotation = (TweenRotation)obj;
			Vector3 from = ToLua.ToVector3(L, 2);
			tweenRotation.from = from;
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
			TweenRotation tweenRotation = (TweenRotation)obj;
			Vector3 to = ToLua.ToVector3(L, 2);
			tweenRotation.to = to;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index to on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_quaternionLerp(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TweenRotation tweenRotation = (TweenRotation)obj;
			bool quaternionLerp = LuaDLL.luaL_checkboolean(L, 2);
			tweenRotation.quaternionLerp = quaternionLerp;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index quaternionLerp on a nil value");
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
			TweenRotation tweenRotation = (TweenRotation)obj;
			Quaternion value = ToLua.ToQuaternion(L, 2);
			tweenRotation.value = value;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index value on a nil value");
		}
		return result;
	}
}
