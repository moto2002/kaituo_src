using LuaInterface;
using System;
using UnityEngine;

public class UICenterOnChildWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UICenterOnChild), typeof(MonoBehaviour), null);
		L.RegFunction("AddOnEventChange", new LuaCSFunction(UICenterOnChildWrap.AddOnEventChange));
		L.RegFunction("Recenter", new LuaCSFunction(UICenterOnChildWrap.Recenter));
		L.RegFunction("CenterOn", new LuaCSFunction(UICenterOnChildWrap.CenterOn));
		L.RegFunction("__eq", new LuaCSFunction(UICenterOnChildWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("ignoreEnableRecenter", new LuaCSFunction(UICenterOnChildWrap.get_ignoreEnableRecenter), new LuaCSFunction(UICenterOnChildWrap.set_ignoreEnableRecenter));
		L.RegVar("springStrength", new LuaCSFunction(UICenterOnChildWrap.get_springStrength), new LuaCSFunction(UICenterOnChildWrap.set_springStrength));
		L.RegVar("nextPageThreshold", new LuaCSFunction(UICenterOnChildWrap.get_nextPageThreshold), new LuaCSFunction(UICenterOnChildWrap.set_nextPageThreshold));
		L.RegVar("onFinished", new LuaCSFunction(UICenterOnChildWrap.get_onFinished), new LuaCSFunction(UICenterOnChildWrap.set_onFinished));
		L.RegVar("onCenter", new LuaCSFunction(UICenterOnChildWrap.get_onCenter), new LuaCSFunction(UICenterOnChildWrap.set_onCenter));
		L.RegVar("onEventChange", new LuaCSFunction(UICenterOnChildWrap.get_onEventChange), new LuaCSFunction(UICenterOnChildWrap.set_onEventChange));
		L.RegVar("centeredObject", new LuaCSFunction(UICenterOnChildWrap.get_centeredObject), null);
		L.RegFunction("OnCenterCallback", new LuaCSFunction(UICenterOnChildWrap.UICenterOnChild_OnCenterCallback));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddOnEventChange(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UICenterOnChild uICenterOnChild = (UICenterOnChild)ToLua.CheckObject(L, 1, typeof(UICenterOnChild));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			EventDelegate.Callback del;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				del = (EventDelegate.Callback)ToLua.CheckObject(L, 2, typeof(EventDelegate.Callback));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				del = (DelegateFactory.CreateDelegate(typeof(EventDelegate.Callback), func) as EventDelegate.Callback);
			}
			uICenterOnChild.AddOnEventChange(del);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Recenter(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UICenterOnChild uICenterOnChild = (UICenterOnChild)ToLua.CheckObject(L, 1, typeof(UICenterOnChild));
			uICenterOnChild.Recenter();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CenterOn(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			UICenterOnChild uICenterOnChild = (UICenterOnChild)ToLua.CheckObject(L, 1, typeof(UICenterOnChild));
			Transform target = (Transform)ToLua.CheckUnityObject(L, 2, typeof(Transform));
			bool immediately = LuaDLL.luaL_checkboolean(L, 3);
			uICenterOnChild.CenterOn(target, immediately);
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
	private static int get_ignoreEnableRecenter(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICenterOnChild uICenterOnChild = (UICenterOnChild)obj;
			bool ignoreEnableRecenter = uICenterOnChild.ignoreEnableRecenter;
			LuaDLL.lua_pushboolean(L, ignoreEnableRecenter);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ignoreEnableRecenter on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_springStrength(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICenterOnChild uICenterOnChild = (UICenterOnChild)obj;
			float springStrength = uICenterOnChild.springStrength;
			LuaDLL.lua_pushnumber(L, (double)springStrength);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index springStrength on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_nextPageThreshold(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICenterOnChild uICenterOnChild = (UICenterOnChild)obj;
			float nextPageThreshold = uICenterOnChild.nextPageThreshold;
			LuaDLL.lua_pushnumber(L, (double)nextPageThreshold);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index nextPageThreshold on a nil value");
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
			UICenterOnChild uICenterOnChild = (UICenterOnChild)obj;
			SpringPanel.OnFinished onFinished = uICenterOnChild.onFinished;
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
	private static int get_onCenter(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICenterOnChild uICenterOnChild = (UICenterOnChild)obj;
			UICenterOnChild.OnCenterCallback onCenter = uICenterOnChild.onCenter;
			ToLua.Push(L, onCenter);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onCenter on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onEventChange(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICenterOnChild uICenterOnChild = (UICenterOnChild)obj;
			EventDelegate.Callback onEventChange = uICenterOnChild.onEventChange;
			ToLua.Push(L, onEventChange);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onEventChange on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_centeredObject(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICenterOnChild uICenterOnChild = (UICenterOnChild)obj;
			GameObject centeredObject = uICenterOnChild.centeredObject;
			ToLua.Push(L, centeredObject);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index centeredObject on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_ignoreEnableRecenter(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICenterOnChild uICenterOnChild = (UICenterOnChild)obj;
			bool ignoreEnableRecenter = LuaDLL.luaL_checkboolean(L, 2);
			uICenterOnChild.ignoreEnableRecenter = ignoreEnableRecenter;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ignoreEnableRecenter on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_springStrength(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICenterOnChild uICenterOnChild = (UICenterOnChild)obj;
			float springStrength = (float)LuaDLL.luaL_checknumber(L, 2);
			uICenterOnChild.springStrength = springStrength;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index springStrength on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_nextPageThreshold(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICenterOnChild uICenterOnChild = (UICenterOnChild)obj;
			float nextPageThreshold = (float)LuaDLL.luaL_checknumber(L, 2);
			uICenterOnChild.nextPageThreshold = nextPageThreshold;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index nextPageThreshold on a nil value");
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
			UICenterOnChild uICenterOnChild = (UICenterOnChild)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			SpringPanel.OnFinished onFinished;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onFinished = (SpringPanel.OnFinished)ToLua.CheckObject(L, 2, typeof(SpringPanel.OnFinished));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onFinished = (DelegateFactory.CreateDelegate(typeof(SpringPanel.OnFinished), func) as SpringPanel.OnFinished);
			}
			uICenterOnChild.onFinished = onFinished;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onFinished on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onCenter(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICenterOnChild uICenterOnChild = (UICenterOnChild)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UICenterOnChild.OnCenterCallback onCenter;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onCenter = (UICenterOnChild.OnCenterCallback)ToLua.CheckObject(L, 2, typeof(UICenterOnChild.OnCenterCallback));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onCenter = (DelegateFactory.CreateDelegate(typeof(UICenterOnChild.OnCenterCallback), func) as UICenterOnChild.OnCenterCallback);
			}
			uICenterOnChild.onCenter = onCenter;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onCenter on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onEventChange(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICenterOnChild uICenterOnChild = (UICenterOnChild)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			EventDelegate.Callback onEventChange;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onEventChange = (EventDelegate.Callback)ToLua.CheckObject(L, 2, typeof(EventDelegate.Callback));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onEventChange = (DelegateFactory.CreateDelegate(typeof(EventDelegate.Callback), func) as EventDelegate.Callback);
			}
			uICenterOnChild.onEventChange = onEventChange;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onEventChange on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UICenterOnChild_OnCenterCallback(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UICenterOnChild.OnCenterCallback), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UICenterOnChild.OnCenterCallback), func, self);
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
