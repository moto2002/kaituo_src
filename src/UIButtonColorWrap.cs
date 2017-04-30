using LuaInterface;
using System;
using UnityEngine;

public class UIButtonColorWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UIButtonColor), typeof(UIWidgetContainer), null);
		L.RegFunction("ResetDefaultColor", new LuaCSFunction(UIButtonColorWrap.ResetDefaultColor));
		L.RegFunction("CacheDefaultColor", new LuaCSFunction(UIButtonColorWrap.CacheDefaultColor));
		L.RegFunction("SetState", new LuaCSFunction(UIButtonColorWrap.SetState));
		L.RegFunction("UpdateColor", new LuaCSFunction(UIButtonColorWrap.UpdateColor));
		L.RegFunction("__eq", new LuaCSFunction(UIButtonColorWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("tweenTarget", new LuaCSFunction(UIButtonColorWrap.get_tweenTarget), new LuaCSFunction(UIButtonColorWrap.set_tweenTarget));
		L.RegVar("hover", new LuaCSFunction(UIButtonColorWrap.get_hover), new LuaCSFunction(UIButtonColorWrap.set_hover));
		L.RegVar("pressed", new LuaCSFunction(UIButtonColorWrap.get_pressed), new LuaCSFunction(UIButtonColorWrap.set_pressed));
		L.RegVar("disabledColor", new LuaCSFunction(UIButtonColorWrap.get_disabledColor), new LuaCSFunction(UIButtonColorWrap.set_disabledColor));
		L.RegVar("duration", new LuaCSFunction(UIButtonColorWrap.get_duration), new LuaCSFunction(UIButtonColorWrap.set_duration));
		L.RegVar("state", new LuaCSFunction(UIButtonColorWrap.get_state), new LuaCSFunction(UIButtonColorWrap.set_state));
		L.RegVar("defaultColor", new LuaCSFunction(UIButtonColorWrap.get_defaultColor), new LuaCSFunction(UIButtonColorWrap.set_defaultColor));
		L.RegVar("isEnabled", new LuaCSFunction(UIButtonColorWrap.get_isEnabled), new LuaCSFunction(UIButtonColorWrap.set_isEnabled));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ResetDefaultColor(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIButtonColor uIButtonColor = (UIButtonColor)ToLua.CheckObject(L, 1, typeof(UIButtonColor));
			uIButtonColor.ResetDefaultColor();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CacheDefaultColor(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIButtonColor uIButtonColor = (UIButtonColor)ToLua.CheckObject(L, 1, typeof(UIButtonColor));
			uIButtonColor.CacheDefaultColor();
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
			UIButtonColor uIButtonColor = (UIButtonColor)ToLua.CheckObject(L, 1, typeof(UIButtonColor));
			UIButtonColor.State state = (UIButtonColor.State)LuaDLL.luaL_checknumber(L, 2);
			bool instant = LuaDLL.luaL_checkboolean(L, 3);
			uIButtonColor.SetState(state, instant);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UpdateColor(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UIButtonColor uIButtonColor = (UIButtonColor)ToLua.CheckObject(L, 1, typeof(UIButtonColor));
			bool instant = LuaDLL.luaL_checkboolean(L, 2);
			uIButtonColor.UpdateColor(instant);
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
	private static int get_tweenTarget(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIButtonColor uIButtonColor = (UIButtonColor)obj;
			GameObject tweenTarget = uIButtonColor.tweenTarget;
			ToLua.Push(L, tweenTarget);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index tweenTarget on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_hover(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIButtonColor uIButtonColor = (UIButtonColor)obj;
			Color hover = uIButtonColor.hover;
			ToLua.Push(L, hover);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index hover on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_pressed(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIButtonColor uIButtonColor = (UIButtonColor)obj;
			Color pressed = uIButtonColor.pressed;
			ToLua.Push(L, pressed);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pressed on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_disabledColor(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIButtonColor uIButtonColor = (UIButtonColor)obj;
			Color disabledColor = uIButtonColor.disabledColor;
			ToLua.Push(L, disabledColor);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index disabledColor on a nil value");
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
			UIButtonColor uIButtonColor = (UIButtonColor)obj;
			float duration = uIButtonColor.duration;
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
	private static int get_state(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIButtonColor uIButtonColor = (UIButtonColor)obj;
			UIButtonColor.State state = uIButtonColor.state;
			ToLua.Push(L, state);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index state on a nil value");
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
			UIButtonColor uIButtonColor = (UIButtonColor)obj;
			Color defaultColor = uIButtonColor.defaultColor;
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
	private static int get_isEnabled(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIButtonColor uIButtonColor = (UIButtonColor)obj;
			bool isEnabled = uIButtonColor.isEnabled;
			LuaDLL.lua_pushboolean(L, isEnabled);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isEnabled on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_tweenTarget(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIButtonColor uIButtonColor = (UIButtonColor)obj;
			GameObject tweenTarget = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			uIButtonColor.tweenTarget = tweenTarget;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index tweenTarget on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_hover(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIButtonColor uIButtonColor = (UIButtonColor)obj;
			Color hover = ToLua.ToColor(L, 2);
			uIButtonColor.hover = hover;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index hover on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_pressed(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIButtonColor uIButtonColor = (UIButtonColor)obj;
			Color pressed = ToLua.ToColor(L, 2);
			uIButtonColor.pressed = pressed;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pressed on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_disabledColor(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIButtonColor uIButtonColor = (UIButtonColor)obj;
			Color disabledColor = ToLua.ToColor(L, 2);
			uIButtonColor.disabledColor = disabledColor;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index disabledColor on a nil value");
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
			UIButtonColor uIButtonColor = (UIButtonColor)obj;
			float duration = (float)LuaDLL.luaL_checknumber(L, 2);
			uIButtonColor.duration = duration;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index duration on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_state(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIButtonColor uIButtonColor = (UIButtonColor)obj;
			UIButtonColor.State state = (UIButtonColor.State)LuaDLL.luaL_checknumber(L, 2);
			uIButtonColor.state = state;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index state on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_defaultColor(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIButtonColor uIButtonColor = (UIButtonColor)obj;
			Color defaultColor = ToLua.ToColor(L, 2);
			uIButtonColor.defaultColor = defaultColor;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index defaultColor on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_isEnabled(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIButtonColor uIButtonColor = (UIButtonColor)obj;
			bool isEnabled = LuaDLL.luaL_checkboolean(L, 2);
			uIButtonColor.isEnabled = isEnabled;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isEnabled on a nil value");
		}
		return result;
	}
}
