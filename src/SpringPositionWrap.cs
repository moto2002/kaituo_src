using LuaInterface;
using System;
using UnityEngine;

public class SpringPositionWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(SpringPosition), typeof(MonoBehaviour), null);
		L.RegFunction("Begin", new LuaCSFunction(SpringPositionWrap.Begin));
		L.RegFunction("__eq", new LuaCSFunction(SpringPositionWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("current", new LuaCSFunction(SpringPositionWrap.get_current), new LuaCSFunction(SpringPositionWrap.set_current));
		L.RegVar("target", new LuaCSFunction(SpringPositionWrap.get_target), new LuaCSFunction(SpringPositionWrap.set_target));
		L.RegVar("strength", new LuaCSFunction(SpringPositionWrap.get_strength), new LuaCSFunction(SpringPositionWrap.set_strength));
		L.RegVar("worldSpace", new LuaCSFunction(SpringPositionWrap.get_worldSpace), new LuaCSFunction(SpringPositionWrap.set_worldSpace));
		L.RegVar("ignoreTimeScale", new LuaCSFunction(SpringPositionWrap.get_ignoreTimeScale), new LuaCSFunction(SpringPositionWrap.set_ignoreTimeScale));
		L.RegVar("updateScrollView", new LuaCSFunction(SpringPositionWrap.get_updateScrollView), new LuaCSFunction(SpringPositionWrap.set_updateScrollView));
		L.RegVar("onFinished", new LuaCSFunction(SpringPositionWrap.get_onFinished), new LuaCSFunction(SpringPositionWrap.set_onFinished));
		L.RegVar("callWhenFinished", new LuaCSFunction(SpringPositionWrap.get_callWhenFinished), new LuaCSFunction(SpringPositionWrap.set_callWhenFinished));
		L.RegFunction("OnFinished", new LuaCSFunction(SpringPositionWrap.SpringPosition_OnFinished));
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
			Vector3 pos = ToLua.ToVector3(L, 2);
			float strength = (float)LuaDLL.luaL_checknumber(L, 3);
			SpringPosition obj = SpringPosition.Begin(go, pos, strength);
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
			ToLua.Push(L, SpringPosition.current);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_target(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SpringPosition springPosition = (SpringPosition)obj;
			Vector3 target = springPosition.target;
			ToLua.Push(L, target);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index target on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_strength(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SpringPosition springPosition = (SpringPosition)obj;
			float strength = springPosition.strength;
			LuaDLL.lua_pushnumber(L, (double)strength);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index strength on a nil value");
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
			SpringPosition springPosition = (SpringPosition)obj;
			bool worldSpace = springPosition.worldSpace;
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
	private static int get_ignoreTimeScale(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SpringPosition springPosition = (SpringPosition)obj;
			bool ignoreTimeScale = springPosition.ignoreTimeScale;
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
	private static int get_updateScrollView(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SpringPosition springPosition = (SpringPosition)obj;
			bool updateScrollView = springPosition.updateScrollView;
			LuaDLL.lua_pushboolean(L, updateScrollView);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index updateScrollView on a nil value");
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
			SpringPosition springPosition = (SpringPosition)obj;
			SpringPosition.OnFinished onFinished = springPosition.onFinished;
			ToLua.Push(L, onFinished);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onFinished on a nil value");
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
			SpringPosition springPosition = (SpringPosition)obj;
			string callWhenFinished = springPosition.callWhenFinished;
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
	private static int set_current(IntPtr L)
	{
		int result;
		try
		{
			SpringPosition current = (SpringPosition)ToLua.CheckUnityObject(L, 2, typeof(SpringPosition));
			SpringPosition.current = current;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_target(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SpringPosition springPosition = (SpringPosition)obj;
			Vector3 target = ToLua.ToVector3(L, 2);
			springPosition.target = target;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index target on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_strength(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SpringPosition springPosition = (SpringPosition)obj;
			float strength = (float)LuaDLL.luaL_checknumber(L, 2);
			springPosition.strength = strength;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index strength on a nil value");
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
			SpringPosition springPosition = (SpringPosition)obj;
			bool worldSpace = LuaDLL.luaL_checkboolean(L, 2);
			springPosition.worldSpace = worldSpace;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index worldSpace on a nil value");
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
			SpringPosition springPosition = (SpringPosition)obj;
			bool ignoreTimeScale = LuaDLL.luaL_checkboolean(L, 2);
			springPosition.ignoreTimeScale = ignoreTimeScale;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ignoreTimeScale on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_updateScrollView(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SpringPosition springPosition = (SpringPosition)obj;
			bool updateScrollView = LuaDLL.luaL_checkboolean(L, 2);
			springPosition.updateScrollView = updateScrollView;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index updateScrollView on a nil value");
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
			SpringPosition springPosition = (SpringPosition)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			SpringPosition.OnFinished onFinished;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onFinished = (SpringPosition.OnFinished)ToLua.CheckObject(L, 2, typeof(SpringPosition.OnFinished));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onFinished = (DelegateFactory.CreateDelegate(typeof(SpringPosition.OnFinished), func) as SpringPosition.OnFinished);
			}
			springPosition.onFinished = onFinished;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onFinished on a nil value");
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
			SpringPosition springPosition = (SpringPosition)obj;
			string callWhenFinished = ToLua.CheckString(L, 2);
			springPosition.callWhenFinished = callWhenFinished;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index callWhenFinished on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SpringPosition_OnFinished(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(SpringPosition.OnFinished), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(SpringPosition.OnFinished), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
