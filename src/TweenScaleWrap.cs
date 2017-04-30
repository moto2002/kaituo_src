using LuaInterface;
using System;
using UnityEngine;

public class TweenScaleWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(TweenScale), typeof(UITweener), null);
		L.RegFunction("Begin", new LuaCSFunction(TweenScaleWrap.Begin));
		L.RegFunction("SetStartToCurrentValue", new LuaCSFunction(TweenScaleWrap.SetStartToCurrentValue));
		L.RegFunction("SetEndToCurrentValue", new LuaCSFunction(TweenScaleWrap.SetEndToCurrentValue));
		L.RegFunction("CopyTo", new LuaCSFunction(TweenScaleWrap.CopyTo));
		L.RegFunction("__eq", new LuaCSFunction(TweenScaleWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("from", new LuaCSFunction(TweenScaleWrap.get_from), new LuaCSFunction(TweenScaleWrap.set_from));
		L.RegVar("to", new LuaCSFunction(TweenScaleWrap.get_to), new LuaCSFunction(TweenScaleWrap.set_to));
		L.RegVar("updateTable", new LuaCSFunction(TweenScaleWrap.get_updateTable), new LuaCSFunction(TweenScaleWrap.set_updateTable));
		L.RegVar("cachedTransform", new LuaCSFunction(TweenScaleWrap.get_cachedTransform), null);
		L.RegVar("value", new LuaCSFunction(TweenScaleWrap.get_value), new LuaCSFunction(TweenScaleWrap.set_value));
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
			Vector3 scale = ToLua.ToVector3(L, 3);
			TweenScale obj = TweenScale.Begin(go, duration, scale);
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
			TweenScale tweenScale = (TweenScale)ToLua.CheckObject(L, 1, typeof(TweenScale));
			tweenScale.SetStartToCurrentValue();
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
			TweenScale tweenScale = (TweenScale)ToLua.CheckObject(L, 1, typeof(TweenScale));
			tweenScale.SetEndToCurrentValue();
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
			TweenScale tweenScale = (TweenScale)ToLua.CheckObject(L, 1, typeof(TweenScale));
			UITweener to = (UITweener)ToLua.CheckUnityObject(L, 2, typeof(UITweener));
			tweenScale.CopyTo(to);
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
			TweenScale tweenScale = (TweenScale)obj;
			Vector3 from = tweenScale.from;
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
			TweenScale tweenScale = (TweenScale)obj;
			Vector3 to = tweenScale.to;
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
	private static int get_updateTable(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TweenScale tweenScale = (TweenScale)obj;
			bool updateTable = tweenScale.updateTable;
			LuaDLL.lua_pushboolean(L, updateTable);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index updateTable on a nil value");
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
			TweenScale tweenScale = (TweenScale)obj;
			Transform cachedTransform = tweenScale.cachedTransform;
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
			TweenScale tweenScale = (TweenScale)obj;
			Vector3 value = tweenScale.value;
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
			TweenScale tweenScale = (TweenScale)obj;
			Vector3 from = ToLua.ToVector3(L, 2);
			tweenScale.from = from;
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
			TweenScale tweenScale = (TweenScale)obj;
			Vector3 to = ToLua.ToVector3(L, 2);
			tweenScale.to = to;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index to on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_updateTable(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TweenScale tweenScale = (TweenScale)obj;
			bool updateTable = LuaDLL.luaL_checkboolean(L, 2);
			tweenScale.updateTable = updateTable;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index updateTable on a nil value");
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
			TweenScale tweenScale = (TweenScale)obj;
			Vector3 value = ToLua.ToVector3(L, 2);
			tweenScale.value = value;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index value on a nil value");
		}
		return result;
	}
}
