using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

public class UIToggleWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UIToggle), typeof(UIWidgetContainer), null);
		L.RegFunction("GetActiveToggle", new LuaCSFunction(UIToggleWrap.GetActiveToggle));
		L.RegFunction("Start", new LuaCSFunction(UIToggleWrap.Start));
		L.RegFunction("Set", new LuaCSFunction(UIToggleWrap.Set));
		L.RegFunction("__eq", new LuaCSFunction(UIToggleWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("list", new LuaCSFunction(UIToggleWrap.get_list), new LuaCSFunction(UIToggleWrap.set_list));
		L.RegVar("current", new LuaCSFunction(UIToggleWrap.get_current), new LuaCSFunction(UIToggleWrap.set_current));
		L.RegVar("group", new LuaCSFunction(UIToggleWrap.get_group), new LuaCSFunction(UIToggleWrap.set_group));
		L.RegVar("activeSprite", new LuaCSFunction(UIToggleWrap.get_activeSprite), new LuaCSFunction(UIToggleWrap.set_activeSprite));
		L.RegVar("invertSpriteState", new LuaCSFunction(UIToggleWrap.get_invertSpriteState), new LuaCSFunction(UIToggleWrap.set_invertSpriteState));
		L.RegVar("activeAnimation", new LuaCSFunction(UIToggleWrap.get_activeAnimation), new LuaCSFunction(UIToggleWrap.set_activeAnimation));
		L.RegVar("animator", new LuaCSFunction(UIToggleWrap.get_animator), new LuaCSFunction(UIToggleWrap.set_animator));
		L.RegVar("tween", new LuaCSFunction(UIToggleWrap.get_tween), new LuaCSFunction(UIToggleWrap.set_tween));
		L.RegVar("startsActive", new LuaCSFunction(UIToggleWrap.get_startsActive), new LuaCSFunction(UIToggleWrap.set_startsActive));
		L.RegVar("instantTween", new LuaCSFunction(UIToggleWrap.get_instantTween), new LuaCSFunction(UIToggleWrap.set_instantTween));
		L.RegVar("optionCanBeNone", new LuaCSFunction(UIToggleWrap.get_optionCanBeNone), new LuaCSFunction(UIToggleWrap.set_optionCanBeNone));
		L.RegVar("onChange", new LuaCSFunction(UIToggleWrap.get_onChange), new LuaCSFunction(UIToggleWrap.set_onChange));
		L.RegVar("validator", new LuaCSFunction(UIToggleWrap.get_validator), new LuaCSFunction(UIToggleWrap.set_validator));
		L.RegVar("value", new LuaCSFunction(UIToggleWrap.get_value), new LuaCSFunction(UIToggleWrap.set_value));
		L.RegVar("isColliderEnabled", new LuaCSFunction(UIToggleWrap.get_isColliderEnabled), null);
		L.RegFunction("Validate", new LuaCSFunction(UIToggleWrap.UIToggle_Validate));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetActiveToggle(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			int group = (int)LuaDLL.luaL_checknumber(L, 1);
			UIToggle activeToggle = UIToggle.GetActiveToggle(group);
			ToLua.Push(L, activeToggle);
			result = 1;
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
			UIToggle uIToggle = (UIToggle)ToLua.CheckObject(L, 1, typeof(UIToggle));
			uIToggle.Start();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Set(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			UIToggle uIToggle = (UIToggle)ToLua.CheckObject(L, 1, typeof(UIToggle));
			bool state = LuaDLL.luaL_checkboolean(L, 2);
			bool notify = LuaDLL.luaL_checkboolean(L, 3);
			uIToggle.Set(state, notify);
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
	private static int get_list(IntPtr L)
	{
		int result;
		try
		{
			ToLua.PushObject(L, UIToggle.list);
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
			ToLua.Push(L, UIToggle.current);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_group(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIToggle uIToggle = (UIToggle)obj;
			int group = uIToggle.group;
			LuaDLL.lua_pushinteger(L, group);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index group on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_activeSprite(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIToggle uIToggle = (UIToggle)obj;
			UIWidget activeSprite = uIToggle.activeSprite;
			ToLua.Push(L, activeSprite);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index activeSprite on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_invertSpriteState(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIToggle uIToggle = (UIToggle)obj;
			bool invertSpriteState = uIToggle.invertSpriteState;
			LuaDLL.lua_pushboolean(L, invertSpriteState);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index invertSpriteState on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_activeAnimation(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIToggle uIToggle = (UIToggle)obj;
			Animation activeAnimation = uIToggle.activeAnimation;
			ToLua.Push(L, activeAnimation);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index activeAnimation on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_animator(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIToggle uIToggle = (UIToggle)obj;
			Animator animator = uIToggle.animator;
			ToLua.Push(L, animator);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index animator on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_tween(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIToggle uIToggle = (UIToggle)obj;
			UITweener tween = uIToggle.tween;
			ToLua.Push(L, tween);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index tween on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_startsActive(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIToggle uIToggle = (UIToggle)obj;
			bool startsActive = uIToggle.startsActive;
			LuaDLL.lua_pushboolean(L, startsActive);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index startsActive on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_instantTween(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIToggle uIToggle = (UIToggle)obj;
			bool instantTween = uIToggle.instantTween;
			LuaDLL.lua_pushboolean(L, instantTween);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index instantTween on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_optionCanBeNone(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIToggle uIToggle = (UIToggle)obj;
			bool optionCanBeNone = uIToggle.optionCanBeNone;
			LuaDLL.lua_pushboolean(L, optionCanBeNone);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index optionCanBeNone on a nil value");
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
			UIToggle uIToggle = (UIToggle)obj;
			List<EventDelegate> onChange = uIToggle.onChange;
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
	private static int get_validator(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIToggle uIToggle = (UIToggle)obj;
			UIToggle.Validate validator = uIToggle.validator;
			ToLua.Push(L, validator);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index validator on a nil value");
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
			UIToggle uIToggle = (UIToggle)obj;
			bool value = uIToggle.value;
			LuaDLL.lua_pushboolean(L, value);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index value on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isColliderEnabled(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIToggle uIToggle = (UIToggle)obj;
			bool isColliderEnabled = uIToggle.isColliderEnabled;
			LuaDLL.lua_pushboolean(L, isColliderEnabled);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isColliderEnabled on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_list(IntPtr L)
	{
		int result;
		try
		{
			BetterList<UIToggle> list = (BetterList<UIToggle>)ToLua.CheckObject(L, 2, typeof(BetterList<UIToggle>));
			UIToggle.list = list;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_current(IntPtr L)
	{
		int result;
		try
		{
			UIToggle current = (UIToggle)ToLua.CheckUnityObject(L, 2, typeof(UIToggle));
			UIToggle.current = current;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_group(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIToggle uIToggle = (UIToggle)obj;
			int group = (int)LuaDLL.luaL_checknumber(L, 2);
			uIToggle.group = group;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index group on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_activeSprite(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIToggle uIToggle = (UIToggle)obj;
			UIWidget activeSprite = (UIWidget)ToLua.CheckUnityObject(L, 2, typeof(UIWidget));
			uIToggle.activeSprite = activeSprite;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index activeSprite on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_invertSpriteState(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIToggle uIToggle = (UIToggle)obj;
			bool invertSpriteState = LuaDLL.luaL_checkboolean(L, 2);
			uIToggle.invertSpriteState = invertSpriteState;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index invertSpriteState on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_activeAnimation(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIToggle uIToggle = (UIToggle)obj;
			Animation activeAnimation = (Animation)ToLua.CheckUnityObject(L, 2, typeof(Animation));
			uIToggle.activeAnimation = activeAnimation;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index activeAnimation on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_animator(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIToggle uIToggle = (UIToggle)obj;
			Animator animator = (Animator)ToLua.CheckUnityObject(L, 2, typeof(Animator));
			uIToggle.animator = animator;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index animator on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_tween(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIToggle uIToggle = (UIToggle)obj;
			UITweener tween = (UITweener)ToLua.CheckUnityObject(L, 2, typeof(UITweener));
			uIToggle.tween = tween;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index tween on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_startsActive(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIToggle uIToggle = (UIToggle)obj;
			bool startsActive = LuaDLL.luaL_checkboolean(L, 2);
			uIToggle.startsActive = startsActive;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index startsActive on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_instantTween(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIToggle uIToggle = (UIToggle)obj;
			bool instantTween = LuaDLL.luaL_checkboolean(L, 2);
			uIToggle.instantTween = instantTween;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index instantTween on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_optionCanBeNone(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIToggle uIToggle = (UIToggle)obj;
			bool optionCanBeNone = LuaDLL.luaL_checkboolean(L, 2);
			uIToggle.optionCanBeNone = optionCanBeNone;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index optionCanBeNone on a nil value");
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
			UIToggle uIToggle = (UIToggle)obj;
			List<EventDelegate> onChange = (List<EventDelegate>)ToLua.CheckObject(L, 2, typeof(List<EventDelegate>));
			uIToggle.onChange = onChange;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onChange on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_validator(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIToggle uIToggle = (UIToggle)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UIToggle.Validate validator;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				validator = (UIToggle.Validate)ToLua.CheckObject(L, 2, typeof(UIToggle.Validate));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				validator = (DelegateFactory.CreateDelegate(typeof(UIToggle.Validate), func) as UIToggle.Validate);
			}
			uIToggle.validator = validator;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index validator on a nil value");
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
			UIToggle uIToggle = (UIToggle)obj;
			bool value = LuaDLL.luaL_checkboolean(L, 2);
			uIToggle.value = value;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index value on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UIToggle_Validate(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UIToggle.Validate), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UIToggle.Validate), func, self);
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
