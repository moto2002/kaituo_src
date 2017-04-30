using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

public class UIProgressBarWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UIProgressBar), typeof(UIWidgetContainer), null);
		L.RegFunction("Set", new LuaCSFunction(UIProgressBarWrap.Set));
		L.RegFunction("Start", new LuaCSFunction(UIProgressBarWrap.Start));
		L.RegFunction("ForceUpdate", new LuaCSFunction(UIProgressBarWrap.ForceUpdate));
		L.RegFunction("OnPan", new LuaCSFunction(UIProgressBarWrap.OnPan));
		L.RegFunction("__eq", new LuaCSFunction(UIProgressBarWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("current", new LuaCSFunction(UIProgressBarWrap.get_current), new LuaCSFunction(UIProgressBarWrap.set_current));
		L.RegVar("onDragFinished", new LuaCSFunction(UIProgressBarWrap.get_onDragFinished), new LuaCSFunction(UIProgressBarWrap.set_onDragFinished));
		L.RegVar("thumb", new LuaCSFunction(UIProgressBarWrap.get_thumb), new LuaCSFunction(UIProgressBarWrap.set_thumb));
		L.RegVar("numberOfSteps", new LuaCSFunction(UIProgressBarWrap.get_numberOfSteps), new LuaCSFunction(UIProgressBarWrap.set_numberOfSteps));
		L.RegVar("onChange", new LuaCSFunction(UIProgressBarWrap.get_onChange), new LuaCSFunction(UIProgressBarWrap.set_onChange));
		L.RegVar("cachedTransform", new LuaCSFunction(UIProgressBarWrap.get_cachedTransform), null);
		L.RegVar("cachedCamera", new LuaCSFunction(UIProgressBarWrap.get_cachedCamera), null);
		L.RegVar("foregroundWidget", new LuaCSFunction(UIProgressBarWrap.get_foregroundWidget), new LuaCSFunction(UIProgressBarWrap.set_foregroundWidget));
		L.RegVar("backgroundWidget", new LuaCSFunction(UIProgressBarWrap.get_backgroundWidget), new LuaCSFunction(UIProgressBarWrap.set_backgroundWidget));
		L.RegVar("fillDirection", new LuaCSFunction(UIProgressBarWrap.get_fillDirection), new LuaCSFunction(UIProgressBarWrap.set_fillDirection));
		L.RegVar("value", new LuaCSFunction(UIProgressBarWrap.get_value), new LuaCSFunction(UIProgressBarWrap.set_value));
		L.RegVar("alpha", new LuaCSFunction(UIProgressBarWrap.get_alpha), new LuaCSFunction(UIProgressBarWrap.set_alpha));
		L.RegFunction("OnDragFinished", new LuaCSFunction(UIProgressBarWrap.UIProgressBar_OnDragFinished));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Set(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			UIProgressBar uIProgressBar = (UIProgressBar)ToLua.CheckObject(L, 1, typeof(UIProgressBar));
			float val = (float)LuaDLL.luaL_checknumber(L, 2);
			bool notify = LuaDLL.luaL_checkboolean(L, 3);
			uIProgressBar.Set(val, notify);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Start(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIProgressBar uIProgressBar = (UIProgressBar)ToLua.CheckObject(L, 1, typeof(UIProgressBar));
			uIProgressBar.Start();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ForceUpdate(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIProgressBar uIProgressBar = (UIProgressBar)ToLua.CheckObject(L, 1, typeof(UIProgressBar));
			uIProgressBar.ForceUpdate();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnPan(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UIProgressBar uIProgressBar = (UIProgressBar)ToLua.CheckObject(L, 1, typeof(UIProgressBar));
			Vector2 delta = ToLua.ToVector2(L, 2);
			uIProgressBar.OnPan(delta);
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
			ToLua.Push(L, UIProgressBar.current);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onDragFinished(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIProgressBar uIProgressBar = (UIProgressBar)obj;
			UIProgressBar.OnDragFinished onDragFinished = uIProgressBar.onDragFinished;
			ToLua.Push(L, onDragFinished);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onDragFinished on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_thumb(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIProgressBar uIProgressBar = (UIProgressBar)obj;
			Transform thumb = uIProgressBar.thumb;
			ToLua.Push(L, thumb);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index thumb on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_numberOfSteps(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIProgressBar uIProgressBar = (UIProgressBar)obj;
			int numberOfSteps = uIProgressBar.numberOfSteps;
			LuaDLL.lua_pushinteger(L, numberOfSteps);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index numberOfSteps on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onChange(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIProgressBar uIProgressBar = (UIProgressBar)obj;
			List<EventDelegate> onChange = uIProgressBar.onChange;
			ToLua.PushObject(L, onChange);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onChange on a nil value");
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
			UIProgressBar uIProgressBar = (UIProgressBar)obj;
			Transform cachedTransform = uIProgressBar.cachedTransform;
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
	private static int get_cachedCamera(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIProgressBar uIProgressBar = (UIProgressBar)obj;
			Camera cachedCamera = uIProgressBar.cachedCamera;
			ToLua.Push(L, cachedCamera);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cachedCamera on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_foregroundWidget(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIProgressBar uIProgressBar = (UIProgressBar)obj;
			UIWidget foregroundWidget = uIProgressBar.foregroundWidget;
			ToLua.Push(L, foregroundWidget);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index foregroundWidget on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_backgroundWidget(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIProgressBar uIProgressBar = (UIProgressBar)obj;
			UIWidget backgroundWidget = uIProgressBar.backgroundWidget;
			ToLua.Push(L, backgroundWidget);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index backgroundWidget on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_fillDirection(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIProgressBar uIProgressBar = (UIProgressBar)obj;
			UIProgressBar.FillDirection fillDirection = uIProgressBar.fillDirection;
			ToLua.Push(L, fillDirection);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index fillDirection on a nil value");
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
			UIProgressBar uIProgressBar = (UIProgressBar)obj;
			float value = uIProgressBar.value;
			LuaDLL.lua_pushnumber(L, (double)value);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index value on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_alpha(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIProgressBar uIProgressBar = (UIProgressBar)obj;
			float alpha = uIProgressBar.alpha;
			LuaDLL.lua_pushnumber(L, (double)alpha);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index alpha on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_current(IntPtr L)
	{
		int result;
		try
		{
			UIProgressBar current = (UIProgressBar)ToLua.CheckUnityObject(L, 2, typeof(UIProgressBar));
			UIProgressBar.current = current;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onDragFinished(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIProgressBar uIProgressBar = (UIProgressBar)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UIProgressBar.OnDragFinished onDragFinished;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onDragFinished = (UIProgressBar.OnDragFinished)ToLua.CheckObject(L, 2, typeof(UIProgressBar.OnDragFinished));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onDragFinished = (DelegateFactory.CreateDelegate(typeof(UIProgressBar.OnDragFinished), func) as UIProgressBar.OnDragFinished);
			}
			uIProgressBar.onDragFinished = onDragFinished;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onDragFinished on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_thumb(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIProgressBar uIProgressBar = (UIProgressBar)obj;
			Transform thumb = (Transform)ToLua.CheckUnityObject(L, 2, typeof(Transform));
			uIProgressBar.thumb = thumb;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index thumb on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_numberOfSteps(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIProgressBar uIProgressBar = (UIProgressBar)obj;
			int numberOfSteps = (int)LuaDLL.luaL_checknumber(L, 2);
			uIProgressBar.numberOfSteps = numberOfSteps;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index numberOfSteps on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onChange(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIProgressBar uIProgressBar = (UIProgressBar)obj;
			List<EventDelegate> onChange = (List<EventDelegate>)ToLua.CheckObject(L, 2, typeof(List<EventDelegate>));
			uIProgressBar.onChange = onChange;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onChange on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_foregroundWidget(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIProgressBar uIProgressBar = (UIProgressBar)obj;
			UIWidget foregroundWidget = (UIWidget)ToLua.CheckUnityObject(L, 2, typeof(UIWidget));
			uIProgressBar.foregroundWidget = foregroundWidget;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index foregroundWidget on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_backgroundWidget(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIProgressBar uIProgressBar = (UIProgressBar)obj;
			UIWidget backgroundWidget = (UIWidget)ToLua.CheckUnityObject(L, 2, typeof(UIWidget));
			uIProgressBar.backgroundWidget = backgroundWidget;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index backgroundWidget on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_fillDirection(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIProgressBar uIProgressBar = (UIProgressBar)obj;
			UIProgressBar.FillDirection fillDirection = (UIProgressBar.FillDirection)LuaDLL.luaL_checknumber(L, 2);
			uIProgressBar.fillDirection = fillDirection;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index fillDirection on a nil value");
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
			UIProgressBar uIProgressBar = (UIProgressBar)obj;
			float value = (float)LuaDLL.luaL_checknumber(L, 2);
			uIProgressBar.value = value;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index value on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_alpha(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIProgressBar uIProgressBar = (UIProgressBar)obj;
			float alpha = (float)LuaDLL.luaL_checknumber(L, 2);
			uIProgressBar.alpha = alpha;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index alpha on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UIProgressBar_OnDragFinished(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UIProgressBar.OnDragFinished), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UIProgressBar.OnDragFinished), func, self);
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
