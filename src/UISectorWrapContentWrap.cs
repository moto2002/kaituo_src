using LuaInterface;
using System;
using UnityEngine;

public class UISectorWrapContentWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UISectorWrapContent), typeof(UIWrapContent), null);
		L.RegFunction("SortBasedOnScrollMovement", new LuaCSFunction(UISectorWrapContentWrap.SortBasedOnScrollMovement));
		L.RegFunction("SortAlphabetically", new LuaCSFunction(UISectorWrapContentWrap.SortAlphabetically));
		L.RegFunction("WrapContent", new LuaCSFunction(UISectorWrapContentWrap.WrapContent));
		L.RegFunction("OnCenterPositon", new LuaCSFunction(UISectorWrapContentWrap.OnCenterPositon));
		L.RegFunction("CheckChilds", new LuaCSFunction(UISectorWrapContentWrap.CheckChilds));
		L.RegFunction("ResetPanel", new LuaCSFunction(UISectorWrapContentWrap.ResetPanel));
		L.RegFunction("__eq", new LuaCSFunction(UISectorWrapContentWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("m_count", new LuaCSFunction(UISectorWrapContentWrap.get_m_count), new LuaCSFunction(UISectorWrapContentWrap.set_m_count));
		L.RegVar("m_angle", new LuaCSFunction(UISectorWrapContentWrap.get_m_angle), new LuaCSFunction(UISectorWrapContentWrap.set_m_angle));
		L.RegVar("m_startDepth", new LuaCSFunction(UISectorWrapContentWrap.get_m_startDepth), new LuaCSFunction(UISectorWrapContentWrap.set_m_startDepth));
		L.RegVar("m_wrapsize", new LuaCSFunction(UISectorWrapContentWrap.get_m_wrapsize), new LuaCSFunction(UISectorWrapContentWrap.set_m_wrapsize));
		L.RegVar("onWrapItem", new LuaCSFunction(UISectorWrapContentWrap.get_onWrapItem), new LuaCSFunction(UISectorWrapContentWrap.set_onWrapItem));
		L.RegVar("switchToCenterPanel", new LuaCSFunction(UISectorWrapContentWrap.get_switchToCenterPanel), new LuaCSFunction(UISectorWrapContentWrap.set_switchToCenterPanel));
		L.RegFunction("SwitchToCenterPanel", new LuaCSFunction(UISectorWrapContentWrap.UISectorWrapContent_SwitchToCenterPanel));
		L.RegFunction("OnWrapItem", new LuaCSFunction(UISectorWrapContentWrap.UISectorWrapContent_OnWrapItem));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SortBasedOnScrollMovement(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UISectorWrapContent uISectorWrapContent = (UISectorWrapContent)ToLua.CheckObject(L, 1, typeof(UISectorWrapContent));
			uISectorWrapContent.SortBasedOnScrollMovement();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SortAlphabetically(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UISectorWrapContent uISectorWrapContent = (UISectorWrapContent)ToLua.CheckObject(L, 1, typeof(UISectorWrapContent));
			uISectorWrapContent.SortAlphabetically();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int WrapContent(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UISectorWrapContent uISectorWrapContent = (UISectorWrapContent)ToLua.CheckObject(L, 1, typeof(UISectorWrapContent));
			uISectorWrapContent.WrapContent();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnCenterPositon(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UISectorWrapContent uISectorWrapContent = (UISectorWrapContent)ToLua.CheckObject(L, 1, typeof(UISectorWrapContent));
			float pos = (float)LuaDLL.luaL_checknumber(L, 2);
			uISectorWrapContent.OnCenterPositon(pos);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CheckChilds(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UISectorWrapContent uISectorWrapContent = (UISectorWrapContent)ToLua.CheckObject(L, 1, typeof(UISectorWrapContent));
			uISectorWrapContent.CheckChilds();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ResetPanel(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UISectorWrapContent uISectorWrapContent = (UISectorWrapContent)ToLua.CheckObject(L, 1, typeof(UISectorWrapContent));
			float value = (float)LuaDLL.luaL_checknumber(L, 2);
			uISectorWrapContent.ResetPanel(value);
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
	private static int get_m_count(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISectorWrapContent uISectorWrapContent = (UISectorWrapContent)obj;
			int count = uISectorWrapContent.m_count;
			LuaDLL.lua_pushinteger(L, count);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index m_count on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_m_angle(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISectorWrapContent uISectorWrapContent = (UISectorWrapContent)obj;
			int angle = uISectorWrapContent.m_angle;
			LuaDLL.lua_pushinteger(L, angle);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index m_angle on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_m_startDepth(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISectorWrapContent uISectorWrapContent = (UISectorWrapContent)obj;
			int startDepth = uISectorWrapContent.m_startDepth;
			LuaDLL.lua_pushinteger(L, startDepth);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index m_startDepth on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_m_wrapsize(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISectorWrapContent uISectorWrapContent = (UISectorWrapContent)obj;
			int wrapsize = uISectorWrapContent.m_wrapsize;
			LuaDLL.lua_pushinteger(L, wrapsize);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index m_wrapsize on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onWrapItem(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISectorWrapContent uISectorWrapContent = (UISectorWrapContent)obj;
			UISectorWrapContent.OnWrapItem onWrapItem = uISectorWrapContent.onWrapItem;
			ToLua.Push(L, onWrapItem);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onWrapItem on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_switchToCenterPanel(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISectorWrapContent uISectorWrapContent = (UISectorWrapContent)obj;
			UISectorWrapContent.SwitchToCenterPanel switchToCenterPanel = uISectorWrapContent.switchToCenterPanel;
			ToLua.Push(L, switchToCenterPanel);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index switchToCenterPanel on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_m_count(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISectorWrapContent uISectorWrapContent = (UISectorWrapContent)obj;
			int count = (int)LuaDLL.luaL_checknumber(L, 2);
			uISectorWrapContent.m_count = count;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index m_count on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_m_angle(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISectorWrapContent uISectorWrapContent = (UISectorWrapContent)obj;
			int angle = (int)LuaDLL.luaL_checknumber(L, 2);
			uISectorWrapContent.m_angle = angle;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index m_angle on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_m_startDepth(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISectorWrapContent uISectorWrapContent = (UISectorWrapContent)obj;
			int startDepth = (int)LuaDLL.luaL_checknumber(L, 2);
			uISectorWrapContent.m_startDepth = startDepth;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index m_startDepth on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_m_wrapsize(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISectorWrapContent uISectorWrapContent = (UISectorWrapContent)obj;
			int wrapsize = (int)LuaDLL.luaL_checknumber(L, 2);
			uISectorWrapContent.m_wrapsize = wrapsize;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index m_wrapsize on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onWrapItem(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISectorWrapContent uISectorWrapContent = (UISectorWrapContent)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UISectorWrapContent.OnWrapItem onWrapItem;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onWrapItem = (UISectorWrapContent.OnWrapItem)ToLua.CheckObject(L, 2, typeof(UISectorWrapContent.OnWrapItem));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onWrapItem = (DelegateFactory.CreateDelegate(typeof(UISectorWrapContent.OnWrapItem), func) as UISectorWrapContent.OnWrapItem);
			}
			uISectorWrapContent.onWrapItem = onWrapItem;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onWrapItem on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_switchToCenterPanel(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISectorWrapContent uISectorWrapContent = (UISectorWrapContent)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UISectorWrapContent.SwitchToCenterPanel switchToCenterPanel;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				switchToCenterPanel = (UISectorWrapContent.SwitchToCenterPanel)ToLua.CheckObject(L, 2, typeof(UISectorWrapContent.SwitchToCenterPanel));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				switchToCenterPanel = (DelegateFactory.CreateDelegate(typeof(UISectorWrapContent.SwitchToCenterPanel), func) as UISectorWrapContent.SwitchToCenterPanel);
			}
			uISectorWrapContent.switchToCenterPanel = switchToCenterPanel;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index switchToCenterPanel on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UISectorWrapContent_SwitchToCenterPanel(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UISectorWrapContent.SwitchToCenterPanel), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UISectorWrapContent.SwitchToCenterPanel), func, self);
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

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UISectorWrapContent_OnWrapItem(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UISectorWrapContent.OnWrapItem), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UISectorWrapContent.OnWrapItem), func, self);
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
