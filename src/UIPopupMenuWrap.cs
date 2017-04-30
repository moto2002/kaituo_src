using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

public class UIPopupMenuWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UIPopupMenu), typeof(MonoBehaviour), null);
		L.RegFunction("SelectItem", new LuaCSFunction(UIPopupMenuWrap.SelectItem));
		L.RegFunction("__eq", new LuaCSFunction(UIPopupMenuWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("tweenTarget", new LuaCSFunction(UIPopupMenuWrap.get_tweenTarget), new LuaCSFunction(UIPopupMenuWrap.set_tweenTarget));
		L.RegVar("tweenLabel", new LuaCSFunction(UIPopupMenuWrap.get_tweenLabel), new LuaCSFunction(UIPopupMenuWrap.set_tweenLabel));
		L.RegVar("popupTarget", new LuaCSFunction(UIPopupMenuWrap.get_popupTarget), new LuaCSFunction(UIPopupMenuWrap.set_popupTarget));
		L.RegVar("pressedFont", new LuaCSFunction(UIPopupMenuWrap.get_pressedFont), new LuaCSFunction(UIPopupMenuWrap.set_pressedFont));
		L.RegVar("disabledFont", new LuaCSFunction(UIPopupMenuWrap.get_disabledFont), new LuaCSFunction(UIPopupMenuWrap.set_disabledFont));
		L.RegVar("noPopupList", new LuaCSFunction(UIPopupMenuWrap.get_noPopupList), new LuaCSFunction(UIPopupMenuWrap.set_noPopupList));
		L.RegVar("pixelSnap", new LuaCSFunction(UIPopupMenuWrap.get_pixelSnap), new LuaCSFunction(UIPopupMenuWrap.set_pixelSnap));
		L.RegVar("clickSprite", new LuaCSFunction(UIPopupMenuWrap.get_clickSprite), new LuaCSFunction(UIPopupMenuWrap.set_clickSprite));
		L.RegVar("tweener", new LuaCSFunction(UIPopupMenuWrap.get_tweener), new LuaCSFunction(UIPopupMenuWrap.set_tweener));
		L.RegVar("selectTarget", new LuaCSFunction(UIPopupMenuWrap.get_selectTarget), new LuaCSFunction(UIPopupMenuWrap.set_selectTarget));
		L.RegVar("popuplist", new LuaCSFunction(UIPopupMenuWrap.get_popuplist), new LuaCSFunction(UIPopupMenuWrap.set_popuplist));
		L.RegVar("onClick", new LuaCSFunction(UIPopupMenuWrap.get_onClick), new LuaCSFunction(UIPopupMenuWrap.set_onClick));
		L.RegVar("onPopupItemClick", new LuaCSFunction(UIPopupMenuWrap.get_onPopupItemClick), new LuaCSFunction(UIPopupMenuWrap.set_onPopupItemClick));
		L.RegFunction("OnPopupItemClick", new LuaCSFunction(UIPopupMenuWrap.UIPopupMenu_OnPopupItemClick));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SelectItem(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UIPopupMenu uIPopupMenu = (UIPopupMenu)ToLua.CheckObject(L, 1, typeof(UIPopupMenu));
			int idx = (int)LuaDLL.luaL_checknumber(L, 2);
			uIPopupMenu.SelectItem(idx);
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
			UIPopupMenu uIPopupMenu = (UIPopupMenu)obj;
			GameObject tweenTarget = uIPopupMenu.tweenTarget;
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
	private static int get_tweenLabel(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupMenu uIPopupMenu = (UIPopupMenu)obj;
			UILabel tweenLabel = uIPopupMenu.tweenLabel;
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
	private static int get_popupTarget(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupMenu uIPopupMenu = (UIPopupMenu)obj;
			GameObject popupTarget = uIPopupMenu.popupTarget;
			ToLua.Push(L, popupTarget);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index popupTarget on a nil value");
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
			UIPopupMenu uIPopupMenu = (UIPopupMenu)obj;
			Color pressedFont = uIPopupMenu.pressedFont;
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
			UIPopupMenu uIPopupMenu = (UIPopupMenu)obj;
			Color disabledFont = uIPopupMenu.disabledFont;
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
	private static int get_noPopupList(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupMenu uIPopupMenu = (UIPopupMenu)obj;
			bool noPopupList = uIPopupMenu.noPopupList;
			LuaDLL.lua_pushboolean(L, noPopupList);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index noPopupList on a nil value");
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
			UIPopupMenu uIPopupMenu = (UIPopupMenu)obj;
			bool pixelSnap = uIPopupMenu.pixelSnap;
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
	private static int get_clickSprite(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupMenu uIPopupMenu = (UIPopupMenu)obj;
			string clickSprite = uIPopupMenu.clickSprite;
			LuaDLL.lua_pushstring(L, clickSprite);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index clickSprite on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_tweener(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupMenu uIPopupMenu = (UIPopupMenu)obj;
			TweenScale tweener = uIPopupMenu.tweener;
			ToLua.Push(L, tweener);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index tweener on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_selectTarget(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupMenu uIPopupMenu = (UIPopupMenu)obj;
			Transform selectTarget = uIPopupMenu.selectTarget;
			ToLua.Push(L, selectTarget);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index selectTarget on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_popuplist(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupMenu uIPopupMenu = (UIPopupMenu)obj;
			List<Transform> popuplist = uIPopupMenu.popuplist;
			ToLua.PushObject(L, popuplist);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index popuplist on a nil value");
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
			UIPopupMenu uIPopupMenu = (UIPopupMenu)obj;
			List<EventDelegate> onClick = uIPopupMenu.onClick;
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
	private static int get_onPopupItemClick(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupMenu uIPopupMenu = (UIPopupMenu)obj;
			UIPopupMenu.OnPopupItemClick onPopupItemClick = uIPopupMenu.onPopupItemClick;
			ToLua.Push(L, onPopupItemClick);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onPopupItemClick on a nil value");
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
			UIPopupMenu uIPopupMenu = (UIPopupMenu)obj;
			GameObject tweenTarget = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			uIPopupMenu.tweenTarget = tweenTarget;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index tweenTarget on a nil value");
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
			UIPopupMenu uIPopupMenu = (UIPopupMenu)obj;
			UILabel tweenLabel = (UILabel)ToLua.CheckUnityObject(L, 2, typeof(UILabel));
			uIPopupMenu.tweenLabel = tweenLabel;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index tweenLabel on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_popupTarget(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupMenu uIPopupMenu = (UIPopupMenu)obj;
			GameObject popupTarget = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			uIPopupMenu.popupTarget = popupTarget;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index popupTarget on a nil value");
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
			UIPopupMenu uIPopupMenu = (UIPopupMenu)obj;
			Color pressedFont = ToLua.ToColor(L, 2);
			uIPopupMenu.pressedFont = pressedFont;
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
			UIPopupMenu uIPopupMenu = (UIPopupMenu)obj;
			Color disabledFont = ToLua.ToColor(L, 2);
			uIPopupMenu.disabledFont = disabledFont;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index disabledFont on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_noPopupList(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupMenu uIPopupMenu = (UIPopupMenu)obj;
			bool noPopupList = LuaDLL.luaL_checkboolean(L, 2);
			uIPopupMenu.noPopupList = noPopupList;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index noPopupList on a nil value");
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
			UIPopupMenu uIPopupMenu = (UIPopupMenu)obj;
			bool pixelSnap = LuaDLL.luaL_checkboolean(L, 2);
			uIPopupMenu.pixelSnap = pixelSnap;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pixelSnap on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_clickSprite(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupMenu uIPopupMenu = (UIPopupMenu)obj;
			string clickSprite = ToLua.CheckString(L, 2);
			uIPopupMenu.clickSprite = clickSprite;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index clickSprite on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_tweener(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupMenu uIPopupMenu = (UIPopupMenu)obj;
			TweenScale tweener = (TweenScale)ToLua.CheckUnityObject(L, 2, typeof(TweenScale));
			uIPopupMenu.tweener = tweener;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index tweener on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_selectTarget(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupMenu uIPopupMenu = (UIPopupMenu)obj;
			Transform selectTarget = (Transform)ToLua.CheckUnityObject(L, 2, typeof(Transform));
			uIPopupMenu.selectTarget = selectTarget;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index selectTarget on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_popuplist(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupMenu uIPopupMenu = (UIPopupMenu)obj;
			List<Transform> popuplist = (List<Transform>)ToLua.CheckObject(L, 2, typeof(List<Transform>));
			uIPopupMenu.popuplist = popuplist;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index popuplist on a nil value");
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
			UIPopupMenu uIPopupMenu = (UIPopupMenu)obj;
			List<EventDelegate> onClick = (List<EventDelegate>)ToLua.CheckObject(L, 2, typeof(List<EventDelegate>));
			uIPopupMenu.onClick = onClick;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onClick on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onPopupItemClick(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupMenu uIPopupMenu = (UIPopupMenu)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UIPopupMenu.OnPopupItemClick onPopupItemClick;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onPopupItemClick = (UIPopupMenu.OnPopupItemClick)ToLua.CheckObject(L, 2, typeof(UIPopupMenu.OnPopupItemClick));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onPopupItemClick = (DelegateFactory.CreateDelegate(typeof(UIPopupMenu.OnPopupItemClick), func) as UIPopupMenu.OnPopupItemClick);
			}
			uIPopupMenu.onPopupItemClick = onPopupItemClick;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onPopupItemClick on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UIPopupMenu_OnPopupItemClick(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UIPopupMenu.OnPopupItemClick), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UIPopupMenu.OnPopupItemClick), func, self);
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
