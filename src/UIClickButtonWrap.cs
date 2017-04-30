using LuaInterface;
using System;
using UnityEngine;

public class UIClickButtonWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UIClickButton), typeof(UIButton), null);
		L.RegFunction("DelegateActive", new LuaCSFunction(UIClickButtonWrap.DelegateActive));
		L.RegFunction("SetState", new LuaCSFunction(UIClickButtonWrap.SetState));
		L.RegFunction("SetNormal", new LuaCSFunction(UIClickButtonWrap.SetNormal));
		L.RegFunction("SetActive", new LuaCSFunction(UIClickButtonWrap.SetActive));
		L.RegFunction("SetDisable", new LuaCSFunction(UIClickButtonWrap.SetDisable));
		L.RegFunction("SetClick", new LuaCSFunction(UIClickButtonWrap.SetClick));
		L.RegFunction("__eq", new LuaCSFunction(UIClickButtonWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("tweenLabel", new LuaCSFunction(UIClickButtonWrap.get_tweenLabel), new LuaCSFunction(UIClickButtonWrap.set_tweenLabel));
		L.RegVar("pressedFont", new LuaCSFunction(UIClickButtonWrap.get_pressedFont), new LuaCSFunction(UIClickButtonWrap.set_pressedFont));
		L.RegVar("disabledFont", new LuaCSFunction(UIClickButtonWrap.get_disabledFont), new LuaCSFunction(UIClickButtonWrap.set_disabledFont));
		L.RegVar("defaultClick", new LuaCSFunction(UIClickButtonWrap.get_defaultClick), new LuaCSFunction(UIClickButtonWrap.set_defaultClick));
		L.RegVar("defaultColor", new LuaCSFunction(UIClickButtonWrap.get_defaultColor), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DelegateActive(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIClickButton uIClickButton = (UIClickButton)ToLua.CheckObject(L, 1, typeof(UIClickButton));
			uIClickButton.DelegateActive();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetState(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			UIClickButton uIClickButton = (UIClickButton)ToLua.CheckObject(L, 1, typeof(UIClickButton));
			UIButtonColor.State state = (UIButtonColor.State)LuaDLL.luaL_checknumber(L, 2);
			bool immediate = LuaDLL.luaL_checkboolean(L, 3);
			uIClickButton.SetState(state, immediate);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetNormal(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIClickButton uIClickButton = (UIClickButton)ToLua.CheckObject(L, 1, typeof(UIClickButton));
			uIClickButton.SetNormal();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetActive(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIClickButton uIClickButton = (UIClickButton)ToLua.CheckObject(L, 1, typeof(UIClickButton));
			uIClickButton.SetActive();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetDisable(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIClickButton uIClickButton = (UIClickButton)ToLua.CheckObject(L, 1, typeof(UIClickButton));
			uIClickButton.SetDisable();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetClick(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIClickButton uIClickButton = (UIClickButton)ToLua.CheckObject(L, 1, typeof(UIClickButton));
			uIClickButton.SetClick();
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
	private static int get_tweenLabel(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIClickButton uIClickButton = (UIClickButton)obj;
			UILabel tweenLabel = uIClickButton.tweenLabel;
			ToLua.Push(L, tweenLabel);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index tweenLabel on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_pressedFont(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIClickButton uIClickButton = (UIClickButton)obj;
			Color pressedFont = uIClickButton.pressedFont;
			ToLua.Push(L, pressedFont);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pressedFont on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_disabledFont(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIClickButton uIClickButton = (UIClickButton)obj;
			Color disabledFont = uIClickButton.disabledFont;
			ToLua.Push(L, disabledFont);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index disabledFont on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_defaultClick(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIClickButton uIClickButton = (UIClickButton)obj;
			bool defaultClick = uIClickButton.defaultClick;
			LuaDLL.lua_pushboolean(L, defaultClick);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index defaultClick on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_defaultColor(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIClickButton uIClickButton = (UIClickButton)obj;
			Color defaultColor = uIClickButton.defaultColor;
			ToLua.Push(L, defaultColor);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index defaultColor on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_tweenLabel(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIClickButton uIClickButton = (UIClickButton)obj;
			UILabel tweenLabel = (UILabel)ToLua.CheckUnityObject(L, 2, typeof(UILabel));
			uIClickButton.tweenLabel = tweenLabel;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index tweenLabel on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_pressedFont(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIClickButton uIClickButton = (UIClickButton)obj;
			Color pressedFont = ToLua.ToColor(L, 2);
			uIClickButton.pressedFont = pressedFont;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pressedFont on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_disabledFont(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIClickButton uIClickButton = (UIClickButton)obj;
			Color disabledFont = ToLua.ToColor(L, 2);
			uIClickButton.disabledFont = disabledFont;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index disabledFont on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_defaultClick(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIClickButton uIClickButton = (UIClickButton)obj;
			bool defaultClick = LuaDLL.luaL_checkboolean(L, 2);
			uIClickButton.defaultClick = defaultClick;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index defaultClick on a nil value");
		}
		return result;
	}
}
