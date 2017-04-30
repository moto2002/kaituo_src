using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

public class UIGridWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UIGrid), typeof(UIWidgetContainer), null);
		L.RegFunction("GetChildList", new LuaCSFunction(UIGridWrap.GetChildList));
		L.RegFunction("GetChild", new LuaCSFunction(UIGridWrap.GetChild));
		L.RegFunction("GetIndex", new LuaCSFunction(UIGridWrap.GetIndex));
		L.RegFunction("AddChild", new LuaCSFunction(UIGridWrap.AddChild));
		L.RegFunction("RemoveChild", new LuaCSFunction(UIGridWrap.RemoveChild));
		L.RegFunction("SortByName", new LuaCSFunction(UIGridWrap.SortByName));
		L.RegFunction("SortHorizontal", new LuaCSFunction(UIGridWrap.SortHorizontal));
		L.RegFunction("SortVertical", new LuaCSFunction(UIGridWrap.SortVertical));
		L.RegFunction("Reposition", new LuaCSFunction(UIGridWrap.Reposition));
		L.RegFunction("ConstrainWithinPanel", new LuaCSFunction(UIGridWrap.ConstrainWithinPanel));
		L.RegFunction("__eq", new LuaCSFunction(UIGridWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("arrangement", new LuaCSFunction(UIGridWrap.get_arrangement), new LuaCSFunction(UIGridWrap.set_arrangement));
		L.RegVar("sorting", new LuaCSFunction(UIGridWrap.get_sorting), new LuaCSFunction(UIGridWrap.set_sorting));
		L.RegVar("pivot", new LuaCSFunction(UIGridWrap.get_pivot), new LuaCSFunction(UIGridWrap.set_pivot));
		L.RegVar("maxPerLine", new LuaCSFunction(UIGridWrap.get_maxPerLine), new LuaCSFunction(UIGridWrap.set_maxPerLine));
		L.RegVar("cellWidth", new LuaCSFunction(UIGridWrap.get_cellWidth), new LuaCSFunction(UIGridWrap.set_cellWidth));
		L.RegVar("cellHeight", new LuaCSFunction(UIGridWrap.get_cellHeight), new LuaCSFunction(UIGridWrap.set_cellHeight));
		L.RegVar("animateSmoothly", new LuaCSFunction(UIGridWrap.get_animateSmoothly), new LuaCSFunction(UIGridWrap.set_animateSmoothly));
		L.RegVar("hideInactive", new LuaCSFunction(UIGridWrap.get_hideInactive), new LuaCSFunction(UIGridWrap.set_hideInactive));
		L.RegVar("keepWithinPanel", new LuaCSFunction(UIGridWrap.get_keepWithinPanel), new LuaCSFunction(UIGridWrap.set_keepWithinPanel));
		L.RegVar("onReposition", new LuaCSFunction(UIGridWrap.get_onReposition), new LuaCSFunction(UIGridWrap.set_onReposition));
		L.RegVar("onCustomSort", new LuaCSFunction(UIGridWrap.get_onCustomSort), new LuaCSFunction(UIGridWrap.set_onCustomSort));
		L.RegVar("repositionNow", null, new LuaCSFunction(UIGridWrap.set_repositionNow));
		L.RegFunction("OnReposition", new LuaCSFunction(UIGridWrap.UIGrid_OnReposition));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetChildList(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIGrid uIGrid = (UIGrid)ToLua.CheckObject(L, 1, typeof(UIGrid));
			List<Transform> childList = uIGrid.GetChildList();
			ToLua.PushObject(L, childList);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetChild(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UIGrid uIGrid = (UIGrid)ToLua.CheckObject(L, 1, typeof(UIGrid));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			Transform child = uIGrid.GetChild(index);
			ToLua.Push(L, child);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetIndex(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UIGrid uIGrid = (UIGrid)ToLua.CheckObject(L, 1, typeof(UIGrid));
			Transform trans = (Transform)ToLua.CheckUnityObject(L, 2, typeof(Transform));
			int index = uIGrid.GetIndex(trans);
			LuaDLL.lua_pushinteger(L, index);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddChild(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(UIGrid), typeof(Transform)))
			{
				UIGrid uIGrid = (UIGrid)ToLua.ToObject(L, 1);
				Transform trans = (Transform)ToLua.ToObject(L, 2);
				uIGrid.AddChild(trans);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(UIGrid), typeof(Transform), typeof(bool)))
			{
				UIGrid uIGrid2 = (UIGrid)ToLua.ToObject(L, 1);
				Transform trans2 = (Transform)ToLua.ToObject(L, 2);
				bool sort = LuaDLL.lua_toboolean(L, 3);
				uIGrid2.AddChild(trans2, sort);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UIGrid.AddChild");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RemoveChild(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UIGrid uIGrid = (UIGrid)ToLua.CheckObject(L, 1, typeof(UIGrid));
			Transform t = (Transform)ToLua.CheckUnityObject(L, 2, typeof(Transform));
			bool value = uIGrid.RemoveChild(t);
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
	private static int SortByName(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Transform a = (Transform)ToLua.CheckUnityObject(L, 1, typeof(Transform));
			Transform b = (Transform)ToLua.CheckUnityObject(L, 2, typeof(Transform));
			int n = UIGrid.SortByName(a, b);
			LuaDLL.lua_pushinteger(L, n);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SortHorizontal(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Transform a = (Transform)ToLua.CheckUnityObject(L, 1, typeof(Transform));
			Transform b = (Transform)ToLua.CheckUnityObject(L, 2, typeof(Transform));
			int n = UIGrid.SortHorizontal(a, b);
			LuaDLL.lua_pushinteger(L, n);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SortVertical(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Transform a = (Transform)ToLua.CheckUnityObject(L, 1, typeof(Transform));
			Transform b = (Transform)ToLua.CheckUnityObject(L, 2, typeof(Transform));
			int n = UIGrid.SortVertical(a, b);
			LuaDLL.lua_pushinteger(L, n);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Reposition(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIGrid uIGrid = (UIGrid)ToLua.CheckObject(L, 1, typeof(UIGrid));
			uIGrid.Reposition();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ConstrainWithinPanel(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIGrid uIGrid = (UIGrid)ToLua.CheckObject(L, 1, typeof(UIGrid));
			uIGrid.ConstrainWithinPanel();
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
	private static int get_arrangement(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIGrid uIGrid = (UIGrid)obj;
			UIGrid.Arrangement arrangement = uIGrid.arrangement;
			ToLua.Push(L, arrangement);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index arrangement on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_sorting(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIGrid uIGrid = (UIGrid)obj;
			UIGrid.Sorting sorting = uIGrid.sorting;
			ToLua.Push(L, sorting);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index sorting on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_pivot(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIGrid uIGrid = (UIGrid)obj;
			UIWidget.Pivot pivot = uIGrid.pivot;
			ToLua.Push(L, pivot);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pivot on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_maxPerLine(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIGrid uIGrid = (UIGrid)obj;
			int maxPerLine = uIGrid.maxPerLine;
			LuaDLL.lua_pushinteger(L, maxPerLine);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index maxPerLine on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_cellWidth(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIGrid uIGrid = (UIGrid)obj;
			float cellWidth = uIGrid.cellWidth;
			LuaDLL.lua_pushnumber(L, (double)cellWidth);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cellWidth on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_cellHeight(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIGrid uIGrid = (UIGrid)obj;
			float cellHeight = uIGrid.cellHeight;
			LuaDLL.lua_pushnumber(L, (double)cellHeight);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cellHeight on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_animateSmoothly(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIGrid uIGrid = (UIGrid)obj;
			bool animateSmoothly = uIGrid.animateSmoothly;
			LuaDLL.lua_pushboolean(L, animateSmoothly);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index animateSmoothly on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_hideInactive(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIGrid uIGrid = (UIGrid)obj;
			bool hideInactive = uIGrid.hideInactive;
			LuaDLL.lua_pushboolean(L, hideInactive);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index hideInactive on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_keepWithinPanel(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIGrid uIGrid = (UIGrid)obj;
			bool keepWithinPanel = uIGrid.keepWithinPanel;
			LuaDLL.lua_pushboolean(L, keepWithinPanel);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index keepWithinPanel on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onReposition(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIGrid uIGrid = (UIGrid)obj;
			UIGrid.OnReposition onReposition = uIGrid.onReposition;
			ToLua.Push(L, onReposition);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onReposition on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onCustomSort(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIGrid uIGrid = (UIGrid)obj;
			Comparison<Transform> onCustomSort = uIGrid.onCustomSort;
			ToLua.Push(L, onCustomSort);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onCustomSort on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_arrangement(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIGrid uIGrid = (UIGrid)obj;
			UIGrid.Arrangement arrangement = (UIGrid.Arrangement)LuaDLL.luaL_checknumber(L, 2);
			uIGrid.arrangement = arrangement;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index arrangement on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_sorting(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIGrid uIGrid = (UIGrid)obj;
			UIGrid.Sorting sorting = (UIGrid.Sorting)LuaDLL.luaL_checknumber(L, 2);
			uIGrid.sorting = sorting;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index sorting on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_pivot(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIGrid uIGrid = (UIGrid)obj;
			UIWidget.Pivot pivot = (UIWidget.Pivot)((int)ToLua.CheckObject(L, 2, typeof(UIWidget.Pivot)));
			uIGrid.pivot = pivot;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pivot on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_maxPerLine(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIGrid uIGrid = (UIGrid)obj;
			int maxPerLine = (int)LuaDLL.luaL_checknumber(L, 2);
			uIGrid.maxPerLine = maxPerLine;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index maxPerLine on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_cellWidth(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIGrid uIGrid = (UIGrid)obj;
			float cellWidth = (float)LuaDLL.luaL_checknumber(L, 2);
			uIGrid.cellWidth = cellWidth;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cellWidth on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_cellHeight(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIGrid uIGrid = (UIGrid)obj;
			float cellHeight = (float)LuaDLL.luaL_checknumber(L, 2);
			uIGrid.cellHeight = cellHeight;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cellHeight on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_animateSmoothly(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIGrid uIGrid = (UIGrid)obj;
			bool animateSmoothly = LuaDLL.luaL_checkboolean(L, 2);
			uIGrid.animateSmoothly = animateSmoothly;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index animateSmoothly on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_hideInactive(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIGrid uIGrid = (UIGrid)obj;
			bool hideInactive = LuaDLL.luaL_checkboolean(L, 2);
			uIGrid.hideInactive = hideInactive;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index hideInactive on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_keepWithinPanel(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIGrid uIGrid = (UIGrid)obj;
			bool keepWithinPanel = LuaDLL.luaL_checkboolean(L, 2);
			uIGrid.keepWithinPanel = keepWithinPanel;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index keepWithinPanel on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onReposition(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIGrid uIGrid = (UIGrid)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UIGrid.OnReposition onReposition;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onReposition = (UIGrid.OnReposition)ToLua.CheckObject(L, 2, typeof(UIGrid.OnReposition));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onReposition = (DelegateFactory.CreateDelegate(typeof(UIGrid.OnReposition), func) as UIGrid.OnReposition);
			}
			uIGrid.onReposition = onReposition;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onReposition on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onCustomSort(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIGrid uIGrid = (UIGrid)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Comparison<Transform> onCustomSort;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onCustomSort = (Comparison<Transform>)ToLua.CheckObject(L, 2, typeof(Comparison<Transform>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onCustomSort = (DelegateFactory.CreateDelegate(typeof(Comparison<Transform>), func) as Comparison<Transform>);
			}
			uIGrid.onCustomSort = onCustomSort;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onCustomSort on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_repositionNow(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIGrid uIGrid = (UIGrid)obj;
			bool repositionNow = LuaDLL.luaL_checkboolean(L, 2);
			uIGrid.repositionNow = repositionNow;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index repositionNow on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UIGrid_OnReposition(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UIGrid.OnReposition), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UIGrid.OnReposition), func, self);
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
