using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UIButton), typeof(UIButtonColor), null);
		L.RegFunction("SetState", new LuaCSFunction(UIButtonWrap.SetState));
		L.RegFunction("__eq", new LuaCSFunction(UIButtonWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("current", new LuaCSFunction(UIButtonWrap.get_current), new LuaCSFunction(UIButtonWrap.set_current));
		L.RegVar("dragHighlight", new LuaCSFunction(UIButtonWrap.get_dragHighlight), new LuaCSFunction(UIButtonWrap.set_dragHighlight));
		L.RegVar("hoverSprite", new LuaCSFunction(UIButtonWrap.get_hoverSprite), new LuaCSFunction(UIButtonWrap.set_hoverSprite));
		L.RegVar("pressedSprite", new LuaCSFunction(UIButtonWrap.get_pressedSprite), new LuaCSFunction(UIButtonWrap.set_pressedSprite));
		L.RegVar("disabledSprite", new LuaCSFunction(UIButtonWrap.get_disabledSprite), new LuaCSFunction(UIButtonWrap.set_disabledSprite));
		L.RegVar("hoverSprite2D", new LuaCSFunction(UIButtonWrap.get_hoverSprite2D), new LuaCSFunction(UIButtonWrap.set_hoverSprite2D));
		L.RegVar("pressedSprite2D", new LuaCSFunction(UIButtonWrap.get_pressedSprite2D), new LuaCSFunction(UIButtonWrap.set_pressedSprite2D));
		L.RegVar("disabledSprite2D", new LuaCSFunction(UIButtonWrap.get_disabledSprite2D), new LuaCSFunction(UIButtonWrap.set_disabledSprite2D));
		L.RegVar("pixelSnap", new LuaCSFunction(UIButtonWrap.get_pixelSnap), new LuaCSFunction(UIButtonWrap.set_pixelSnap));
		L.RegVar("onClick", new LuaCSFunction(UIButtonWrap.get_onClick), new LuaCSFunction(UIButtonWrap.set_onClick));
		L.RegVar("isEnabled", new LuaCSFunction(UIButtonWrap.get_isEnabled), new LuaCSFunction(UIButtonWrap.set_isEnabled));
		L.RegVar("normalSprite", new LuaCSFunction(UIButtonWrap.get_normalSprite), new LuaCSFunction(UIButtonWrap.set_normalSprite));
		L.RegVar("normalSprite2D", new LuaCSFunction(UIButtonWrap.get_normalSprite2D), new LuaCSFunction(UIButtonWrap.set_normalSprite2D));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetState(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			UIButton uIButton = (UIButton)ToLua.CheckObject(L, 1, typeof(UIButton));
			UIButtonColor.State state = (UIButtonColor.State)LuaDLL.luaL_checknumber(L, 2);
			bool immediate = LuaDLL.luaL_checkboolean(L, 3);
			uIButton.SetState(state, immediate);
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
	private static int get_current(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UIButton.current);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_dragHighlight(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIButton uIButton = (UIButton)obj;
			bool dragHighlight = uIButton.dragHighlight;
			LuaDLL.lua_pushboolean(L, dragHighlight);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index dragHighlight on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_hoverSprite(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIButton uIButton = (UIButton)obj;
			string hoverSprite = uIButton.hoverSprite;
			LuaDLL.lua_pushstring(L, hoverSprite);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index hoverSprite on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_pressedSprite(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIButton uIButton = (UIButton)obj;
			string pressedSprite = uIButton.pressedSprite;
			LuaDLL.lua_pushstring(L, pressedSprite);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pressedSprite on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_disabledSprite(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIButton uIButton = (UIButton)obj;
			string disabledSprite = uIButton.disabledSprite;
			LuaDLL.lua_pushstring(L, disabledSprite);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index disabledSprite on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_hoverSprite2D(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIButton uIButton = (UIButton)obj;
			Sprite hoverSprite2D = uIButton.hoverSprite2D;
			ToLua.Push(L, hoverSprite2D);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index hoverSprite2D on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_pressedSprite2D(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIButton uIButton = (UIButton)obj;
			Sprite pressedSprite2D = uIButton.pressedSprite2D;
			ToLua.Push(L, pressedSprite2D);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pressedSprite2D on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_disabledSprite2D(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIButton uIButton = (UIButton)obj;
			Sprite disabledSprite2D = uIButton.disabledSprite2D;
			ToLua.Push(L, disabledSprite2D);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index disabledSprite2D on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_pixelSnap(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIButton uIButton = (UIButton)obj;
			bool pixelSnap = uIButton.pixelSnap;
			LuaDLL.lua_pushboolean(L, pixelSnap);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pixelSnap on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onClick(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIButton uIButton = (UIButton)obj;
			List<EventDelegate> onClick = uIButton.onClick;
			ToLua.PushObject(L, onClick);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onClick on a nil value");
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
			UIButton uIButton = (UIButton)obj;
			bool isEnabled = uIButton.isEnabled;
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
	private static int get_normalSprite(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIButton uIButton = (UIButton)obj;
			string normalSprite = uIButton.normalSprite;
			LuaDLL.lua_pushstring(L, normalSprite);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index normalSprite on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_normalSprite2D(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIButton uIButton = (UIButton)obj;
			Sprite normalSprite2D = uIButton.normalSprite2D;
			ToLua.Push(L, normalSprite2D);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index normalSprite2D on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_current(IntPtr L)
	{
		int result;
		try
		{
			UIButton current = (UIButton)ToLua.CheckUnityObject(L, 2, typeof(UIButton));
			UIButton.current = current;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_dragHighlight(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIButton uIButton = (UIButton)obj;
			bool dragHighlight = LuaDLL.luaL_checkboolean(L, 2);
			uIButton.dragHighlight = dragHighlight;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index dragHighlight on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_hoverSprite(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIButton uIButton = (UIButton)obj;
			string hoverSprite = ToLua.CheckString(L, 2);
			uIButton.hoverSprite = hoverSprite;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index hoverSprite on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_pressedSprite(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIButton uIButton = (UIButton)obj;
			string pressedSprite = ToLua.CheckString(L, 2);
			uIButton.pressedSprite = pressedSprite;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pressedSprite on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_disabledSprite(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIButton uIButton = (UIButton)obj;
			string disabledSprite = ToLua.CheckString(L, 2);
			uIButton.disabledSprite = disabledSprite;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index disabledSprite on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_hoverSprite2D(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIButton uIButton = (UIButton)obj;
			Sprite hoverSprite2D = (Sprite)ToLua.CheckUnityObject(L, 2, typeof(Sprite));
			uIButton.hoverSprite2D = hoverSprite2D;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index hoverSprite2D on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_pressedSprite2D(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIButton uIButton = (UIButton)obj;
			Sprite pressedSprite2D = (Sprite)ToLua.CheckUnityObject(L, 2, typeof(Sprite));
			uIButton.pressedSprite2D = pressedSprite2D;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pressedSprite2D on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_disabledSprite2D(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIButton uIButton = (UIButton)obj;
			Sprite disabledSprite2D = (Sprite)ToLua.CheckUnityObject(L, 2, typeof(Sprite));
			uIButton.disabledSprite2D = disabledSprite2D;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index disabledSprite2D on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_pixelSnap(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIButton uIButton = (UIButton)obj;
			bool pixelSnap = LuaDLL.luaL_checkboolean(L, 2);
			uIButton.pixelSnap = pixelSnap;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pixelSnap on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onClick(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIButton uIButton = (UIButton)obj;
			List<EventDelegate> onClick = (List<EventDelegate>)ToLua.CheckObject(L, 2, typeof(List<EventDelegate>));
			uIButton.onClick = onClick;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onClick on a nil value");
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
			UIButton uIButton = (UIButton)obj;
			bool isEnabled = LuaDLL.luaL_checkboolean(L, 2);
			uIButton.isEnabled = isEnabled;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isEnabled on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_normalSprite(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIButton uIButton = (UIButton)obj;
			string normalSprite = ToLua.CheckString(L, 2);
			uIButton.normalSprite = normalSprite;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index normalSprite on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_normalSprite2D(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIButton uIButton = (UIButton)obj;
			Sprite normalSprite2D = (Sprite)ToLua.CheckUnityObject(L, 2, typeof(Sprite));
			uIButton.normalSprite2D = normalSprite2D;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index normalSprite2D on a nil value");
		}
		return result;
	}
}
