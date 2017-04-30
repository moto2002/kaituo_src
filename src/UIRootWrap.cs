using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

public class UIRootWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UIRoot), typeof(MonoBehaviour), null);
		L.RegFunction("GetPixelSizeAdjustment", new LuaCSFunction(UIRootWrap.GetPixelSizeAdjustment));
		L.RegFunction("UpdateScale", new LuaCSFunction(UIRootWrap.UpdateScale));
		L.RegFunction("Broadcast", new LuaCSFunction(UIRootWrap.Broadcast));
		L.RegFunction("__eq", new LuaCSFunction(UIRootWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("list", new LuaCSFunction(UIRootWrap.get_list), new LuaCSFunction(UIRootWrap.set_list));
		L.RegVar("scalingStyle", new LuaCSFunction(UIRootWrap.get_scalingStyle), new LuaCSFunction(UIRootWrap.set_scalingStyle));
		L.RegVar("manualWidth", new LuaCSFunction(UIRootWrap.get_manualWidth), new LuaCSFunction(UIRootWrap.set_manualWidth));
		L.RegVar("manualHeight", new LuaCSFunction(UIRootWrap.get_manualHeight), new LuaCSFunction(UIRootWrap.set_manualHeight));
		L.RegVar("minimumHeight", new LuaCSFunction(UIRootWrap.get_minimumHeight), new LuaCSFunction(UIRootWrap.set_minimumHeight));
		L.RegVar("maximumHeight", new LuaCSFunction(UIRootWrap.get_maximumHeight), new LuaCSFunction(UIRootWrap.set_maximumHeight));
		L.RegVar("fitWidth", new LuaCSFunction(UIRootWrap.get_fitWidth), new LuaCSFunction(UIRootWrap.set_fitWidth));
		L.RegVar("fitHeight", new LuaCSFunction(UIRootWrap.get_fitHeight), new LuaCSFunction(UIRootWrap.set_fitHeight));
		L.RegVar("adjustByDPI", new LuaCSFunction(UIRootWrap.get_adjustByDPI), new LuaCSFunction(UIRootWrap.set_adjustByDPI));
		L.RegVar("shrinkPortraitUI", new LuaCSFunction(UIRootWrap.get_shrinkPortraitUI), new LuaCSFunction(UIRootWrap.set_shrinkPortraitUI));
		L.RegVar("constraint", new LuaCSFunction(UIRootWrap.get_constraint), null);
		L.RegVar("activeScaling", new LuaCSFunction(UIRootWrap.get_activeScaling), null);
		L.RegVar("activeHeight", new LuaCSFunction(UIRootWrap.get_activeHeight), null);
		L.RegVar("pixelSizeAdjustment", new LuaCSFunction(UIRootWrap.get_pixelSizeAdjustment), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetPixelSizeAdjustment(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(GameObject)))
			{
				GameObject go = (GameObject)ToLua.ToObject(L, 1);
				float pixelSizeAdjustment = UIRoot.GetPixelSizeAdjustment(go);
				LuaDLL.lua_pushnumber(L, (double)pixelSizeAdjustment);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(UIRoot), typeof(int)))
			{
				UIRoot uIRoot = (UIRoot)ToLua.ToObject(L, 1);
				int height = (int)LuaDLL.lua_tonumber(L, 2);
				float pixelSizeAdjustment2 = uIRoot.GetPixelSizeAdjustment(height);
				LuaDLL.lua_pushnumber(L, (double)pixelSizeAdjustment2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UIRoot.GetPixelSizeAdjustment");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UpdateScale(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UIRoot uIRoot = (UIRoot)ToLua.CheckObject(L, 1, typeof(UIRoot));
			bool updateAnchors = LuaDLL.luaL_checkboolean(L, 2);
			uIRoot.UpdateScale(updateAnchors);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Broadcast(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(string)))
			{
				string funcName = ToLua.ToString(L, 1);
				UIRoot.Broadcast(funcName);
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(object)))
			{
				string funcName2 = ToLua.ToString(L, 1);
				object param = ToLua.ToVarObject(L, 2);
				UIRoot.Broadcast(funcName2, param);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UIRoot.Broadcast");
			}
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
			ToLua.PushObject(L, UIRoot.list);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_scalingStyle(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRoot uIRoot = (UIRoot)obj;
			UIRoot.Scaling scalingStyle = uIRoot.scalingStyle;
			ToLua.Push(L, scalingStyle);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index scalingStyle on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_manualWidth(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRoot uIRoot = (UIRoot)obj;
			int manualWidth = uIRoot.manualWidth;
			LuaDLL.lua_pushinteger(L, manualWidth);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index manualWidth on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_manualHeight(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRoot uIRoot = (UIRoot)obj;
			int manualHeight = uIRoot.manualHeight;
			LuaDLL.lua_pushinteger(L, manualHeight);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index manualHeight on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_minimumHeight(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRoot uIRoot = (UIRoot)obj;
			int minimumHeight = uIRoot.minimumHeight;
			LuaDLL.lua_pushinteger(L, minimumHeight);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index minimumHeight on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_maximumHeight(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRoot uIRoot = (UIRoot)obj;
			int maximumHeight = uIRoot.maximumHeight;
			LuaDLL.lua_pushinteger(L, maximumHeight);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index maximumHeight on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_fitWidth(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRoot uIRoot = (UIRoot)obj;
			bool fitWidth = uIRoot.fitWidth;
			LuaDLL.lua_pushboolean(L, fitWidth);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index fitWidth on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_fitHeight(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRoot uIRoot = (UIRoot)obj;
			bool fitHeight = uIRoot.fitHeight;
			LuaDLL.lua_pushboolean(L, fitHeight);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index fitHeight on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_adjustByDPI(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRoot uIRoot = (UIRoot)obj;
			bool adjustByDPI = uIRoot.adjustByDPI;
			LuaDLL.lua_pushboolean(L, adjustByDPI);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index adjustByDPI on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_shrinkPortraitUI(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRoot uIRoot = (UIRoot)obj;
			bool shrinkPortraitUI = uIRoot.shrinkPortraitUI;
			LuaDLL.lua_pushboolean(L, shrinkPortraitUI);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index shrinkPortraitUI on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_constraint(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRoot uIRoot = (UIRoot)obj;
			UIRoot.Constraint constraint = uIRoot.constraint;
			ToLua.Push(L, constraint);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index constraint on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_activeScaling(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRoot uIRoot = (UIRoot)obj;
			UIRoot.Scaling activeScaling = uIRoot.activeScaling;
			ToLua.Push(L, activeScaling);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index activeScaling on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_activeHeight(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRoot uIRoot = (UIRoot)obj;
			int activeHeight = uIRoot.activeHeight;
			LuaDLL.lua_pushinteger(L, activeHeight);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index activeHeight on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_pixelSizeAdjustment(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRoot uIRoot = (UIRoot)obj;
			float pixelSizeAdjustment = uIRoot.pixelSizeAdjustment;
			LuaDLL.lua_pushnumber(L, (double)pixelSizeAdjustment);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pixelSizeAdjustment on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_list(IntPtr L)
	{
		int result;
		try
		{
			List<UIRoot> list = (List<UIRoot>)ToLua.CheckObject(L, 2, typeof(List<UIRoot>));
			UIRoot.list = list;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_scalingStyle(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRoot uIRoot = (UIRoot)obj;
			UIRoot.Scaling scalingStyle = (UIRoot.Scaling)LuaDLL.luaL_checknumber(L, 2);
			uIRoot.scalingStyle = scalingStyle;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index scalingStyle on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_manualWidth(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRoot uIRoot = (UIRoot)obj;
			int manualWidth = (int)LuaDLL.luaL_checknumber(L, 2);
			uIRoot.manualWidth = manualWidth;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index manualWidth on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_manualHeight(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRoot uIRoot = (UIRoot)obj;
			int manualHeight = (int)LuaDLL.luaL_checknumber(L, 2);
			uIRoot.manualHeight = manualHeight;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index manualHeight on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_minimumHeight(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRoot uIRoot = (UIRoot)obj;
			int minimumHeight = (int)LuaDLL.luaL_checknumber(L, 2);
			uIRoot.minimumHeight = minimumHeight;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index minimumHeight on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_maximumHeight(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRoot uIRoot = (UIRoot)obj;
			int maximumHeight = (int)LuaDLL.luaL_checknumber(L, 2);
			uIRoot.maximumHeight = maximumHeight;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index maximumHeight on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_fitWidth(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRoot uIRoot = (UIRoot)obj;
			bool fitWidth = LuaDLL.luaL_checkboolean(L, 2);
			uIRoot.fitWidth = fitWidth;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index fitWidth on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_fitHeight(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRoot uIRoot = (UIRoot)obj;
			bool fitHeight = LuaDLL.luaL_checkboolean(L, 2);
			uIRoot.fitHeight = fitHeight;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index fitHeight on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_adjustByDPI(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRoot uIRoot = (UIRoot)obj;
			bool adjustByDPI = LuaDLL.luaL_checkboolean(L, 2);
			uIRoot.adjustByDPI = adjustByDPI;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index adjustByDPI on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_shrinkPortraitUI(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRoot uIRoot = (UIRoot)obj;
			bool shrinkPortraitUI = LuaDLL.luaL_checkboolean(L, 2);
			uIRoot.shrinkPortraitUI = shrinkPortraitUI;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index shrinkPortraitUI on a nil value");
		}
		return result;
	}
}
