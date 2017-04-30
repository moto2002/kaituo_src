using LuaInterface;
using System;
using UnityEngine;

public class TweenPositionWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(TweenPosition), typeof(UITweener), null);
		L.RegFunction("Awake", new LuaCSFunction(TweenPositionWrap.Awake));
		L.RegFunction("PlayFromCurrTo", new LuaCSFunction(TweenPositionWrap.PlayFromCurrTo));
		L.RegFunction("PlayFromCurrToX", new LuaCSFunction(TweenPositionWrap.PlayFromCurrToX));
		L.RegFunction("Stop", new LuaCSFunction(TweenPositionWrap.Stop));
		L.RegFunction("Begin", new LuaCSFunction(TweenPositionWrap.Begin));
		L.RegFunction("SetStartToCurrentValue", new LuaCSFunction(TweenPositionWrap.SetStartToCurrentValue));
		L.RegFunction("SetEndToCurrentValue", new LuaCSFunction(TweenPositionWrap.SetEndToCurrentValue));
		L.RegFunction("CopyTo", new LuaCSFunction(TweenPositionWrap.CopyTo));
		L.RegFunction("__eq", new LuaCSFunction(TweenPositionWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("from", new LuaCSFunction(TweenPositionWrap.get_from), new LuaCSFunction(TweenPositionWrap.set_from));
		L.RegVar("to", new LuaCSFunction(TweenPositionWrap.get_to), new LuaCSFunction(TweenPositionWrap.set_to));
		L.RegVar("worldSpace", new LuaCSFunction(TweenPositionWrap.get_worldSpace), new LuaCSFunction(TweenPositionWrap.set_worldSpace));
		L.RegVar("cachedTransform", new LuaCSFunction(TweenPositionWrap.get_cachedTransform), null);
		L.RegVar("value", new LuaCSFunction(TweenPositionWrap.get_value), new LuaCSFunction(TweenPositionWrap.set_value));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Awake(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			TweenPosition tweenPosition = (TweenPosition)ToLua.CheckObject(L, 1, typeof(TweenPosition));
			tweenPosition.Awake();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PlayFromCurrTo(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			TweenPosition tweenPosition = (TweenPosition)ToLua.CheckObject(L, 1, typeof(TweenPosition));
			Vector3 to = ToLua.ToVector3(L, 2);
			tweenPosition.PlayFromCurrTo(to);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PlayFromCurrToX(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			TweenPosition tweenPosition = (TweenPosition)ToLua.CheckObject(L, 1, typeof(TweenPosition));
			float to = (float)LuaDLL.luaL_checknumber(L, 2);
			tweenPosition.PlayFromCurrToX(to);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Stop(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			TweenPosition.Stop(go);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Begin(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(GameObject), typeof(float), typeof(Vector3)))
			{
				GameObject go = (GameObject)ToLua.ToObject(L, 1);
				float duration = (float)LuaDLL.lua_tonumber(L, 2);
				Vector3 pos = ToLua.ToVector3(L, 3);
				TweenPosition obj = TweenPosition.Begin(go, duration, pos);
				ToLua.Push(L, obj);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(GameObject), typeof(float), typeof(Vector3), typeof(bool)))
			{
				GameObject go2 = (GameObject)ToLua.ToObject(L, 1);
				float duration2 = (float)LuaDLL.lua_tonumber(L, 2);
				Vector3 pos2 = ToLua.ToVector3(L, 3);
				bool worldSpace = LuaDLL.lua_toboolean(L, 4);
				TweenPosition obj2 = TweenPosition.Begin(go2, duration2, pos2, worldSpace);
				ToLua.Push(L, obj2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: TweenPosition.Begin");
			}
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
			TweenPosition tweenPosition = (TweenPosition)ToLua.CheckObject(L, 1, typeof(TweenPosition));
			tweenPosition.SetStartToCurrentValue();
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
			TweenPosition tweenPosition = (TweenPosition)ToLua.CheckObject(L, 1, typeof(TweenPosition));
			tweenPosition.SetEndToCurrentValue();
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
			TweenPosition tweenPosition = (TweenPosition)ToLua.CheckObject(L, 1, typeof(TweenPosition));
			UITweener to = (UITweener)ToLua.CheckUnityObject(L, 2, typeof(UITweener));
			tweenPosition.CopyTo(to);
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
			TweenPosition tweenPosition = (TweenPosition)obj;
			Vector3 from = tweenPosition.from;
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
			TweenPosition tweenPosition = (TweenPosition)obj;
			Vector3 to = tweenPosition.to;
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
	private static int get_worldSpace(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TweenPosition tweenPosition = (TweenPosition)obj;
			bool worldSpace = tweenPosition.worldSpace;
			LuaDLL.lua_pushboolean(L, worldSpace);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index worldSpace on a nil value");
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
			TweenPosition tweenPosition = (TweenPosition)obj;
			Transform cachedTransform = tweenPosition.cachedTransform;
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
			TweenPosition tweenPosition = (TweenPosition)obj;
			Vector3 value = tweenPosition.value;
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
			TweenPosition tweenPosition = (TweenPosition)obj;
			Vector3 from = ToLua.ToVector3(L, 2);
			tweenPosition.from = from;
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
			TweenPosition tweenPosition = (TweenPosition)obj;
			Vector3 to = ToLua.ToVector3(L, 2);
			tweenPosition.to = to;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index to on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_worldSpace(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TweenPosition tweenPosition = (TweenPosition)obj;
			bool worldSpace = LuaDLL.luaL_checkboolean(L, 2);
			tweenPosition.worldSpace = worldSpace;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index worldSpace on a nil value");
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
			TweenPosition tweenPosition = (TweenPosition)obj;
			Vector3 value = ToLua.ToVector3(L, 2);
			tweenPosition.value = value;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index value on a nil value");
		}
		return result;
	}
}
