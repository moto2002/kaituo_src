using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

public class UITableWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UITable), typeof(UIWidgetContainer), null);
		L.RegFunction("GetChildList", new LuaCSFunction(UITableWrap.GetChildList));
		L.RegFunction("Reposition", new LuaCSFunction(UITableWrap.Reposition));
		L.RegFunction("__eq", new LuaCSFunction(UITableWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("columns", new LuaCSFunction(UITableWrap.get_columns), new LuaCSFunction(UITableWrap.set_columns));
		L.RegVar("direction", new LuaCSFunction(UITableWrap.get_direction), new LuaCSFunction(UITableWrap.set_direction));
		L.RegVar("sorting", new LuaCSFunction(UITableWrap.get_sorting), new LuaCSFunction(UITableWrap.set_sorting));
		L.RegVar("pivot", new LuaCSFunction(UITableWrap.get_pivot), new LuaCSFunction(UITableWrap.set_pivot));
		L.RegVar("cellAlignment", new LuaCSFunction(UITableWrap.get_cellAlignment), new LuaCSFunction(UITableWrap.set_cellAlignment));
		L.RegVar("hideInactive", new LuaCSFunction(UITableWrap.get_hideInactive), new LuaCSFunction(UITableWrap.set_hideInactive));
		L.RegVar("keepWithinPanel", new LuaCSFunction(UITableWrap.get_keepWithinPanel), new LuaCSFunction(UITableWrap.set_keepWithinPanel));
		L.RegVar("padding", new LuaCSFunction(UITableWrap.get_padding), new LuaCSFunction(UITableWrap.set_padding));
		L.RegVar("onReposition", new LuaCSFunction(UITableWrap.get_onReposition), new LuaCSFunction(UITableWrap.set_onReposition));
		L.RegVar("onCustomSort", new LuaCSFunction(UITableWrap.get_onCustomSort), new LuaCSFunction(UITableWrap.set_onCustomSort));
		L.RegVar("repositionNow", null, new LuaCSFunction(UITableWrap.set_repositionNow));
		L.RegFunction("OnReposition", new LuaCSFunction(UITableWrap.UITable_OnReposition));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetChildList(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UITable uITable = (UITable)ToLua.CheckObject(L, 1, typeof(UITable));
			List<Transform> childList = uITable.GetChildList();
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
	private static int Reposition(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UITable uITable = (UITable)ToLua.CheckObject(L, 1, typeof(UITable));
			uITable.Reposition();
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
	private static int get_columns(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITable uITable = (UITable)obj;
			int columns = uITable.columns;
			LuaDLL.lua_pushinteger(L, columns);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index columns on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_direction(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITable uITable = (UITable)obj;
			UITable.Direction direction = uITable.direction;
			ToLua.Push(L, direction);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index direction on a nil value");
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
			UITable uITable = (UITable)obj;
			UITable.Sorting sorting = uITable.sorting;
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
			UITable uITable = (UITable)obj;
			UIWidget.Pivot pivot = uITable.pivot;
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
	private static int get_cellAlignment(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITable uITable = (UITable)obj;
			UIWidget.Pivot cellAlignment = uITable.cellAlignment;
			ToLua.Push(L, cellAlignment);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cellAlignment on a nil value");
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
			UITable uITable = (UITable)obj;
			bool hideInactive = uITable.hideInactive;
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
			UITable uITable = (UITable)obj;
			bool keepWithinPanel = uITable.keepWithinPanel;
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
	private static int get_padding(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITable uITable = (UITable)obj;
			Vector2 padding = uITable.padding;
			ToLua.Push(L, padding);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index padding on a nil value");
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
			UITable uITable = (UITable)obj;
			UITable.OnReposition onReposition = uITable.onReposition;
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
			UITable uITable = (UITable)obj;
			Comparison<Transform> onCustomSort = uITable.onCustomSort;
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
	private static int set_columns(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITable uITable = (UITable)obj;
			int columns = (int)LuaDLL.luaL_checknumber(L, 2);
			uITable.columns = columns;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index columns on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_direction(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITable uITable = (UITable)obj;
			UITable.Direction direction = (UITable.Direction)LuaDLL.luaL_checknumber(L, 2);
			uITable.direction = direction;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index direction on a nil value");
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
			UITable uITable = (UITable)obj;
			UITable.Sorting sorting = (UITable.Sorting)LuaDLL.luaL_checknumber(L, 2);
			uITable.sorting = sorting;
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
			UITable uITable = (UITable)obj;
			UIWidget.Pivot pivot = (UIWidget.Pivot)((int)ToLua.CheckObject(L, 2, typeof(UIWidget.Pivot)));
			uITable.pivot = pivot;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pivot on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_cellAlignment(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITable uITable = (UITable)obj;
			UIWidget.Pivot cellAlignment = (UIWidget.Pivot)((int)ToLua.CheckObject(L, 2, typeof(UIWidget.Pivot)));
			uITable.cellAlignment = cellAlignment;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cellAlignment on a nil value");
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
			UITable uITable = (UITable)obj;
			bool hideInactive = LuaDLL.luaL_checkboolean(L, 2);
			uITable.hideInactive = hideInactive;
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
			UITable uITable = (UITable)obj;
			bool keepWithinPanel = LuaDLL.luaL_checkboolean(L, 2);
			uITable.keepWithinPanel = keepWithinPanel;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index keepWithinPanel on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_padding(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITable uITable = (UITable)obj;
			Vector2 padding = ToLua.ToVector2(L, 2);
			uITable.padding = padding;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index padding on a nil value");
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
			UITable uITable = (UITable)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UITable.OnReposition onReposition;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onReposition = (UITable.OnReposition)ToLua.CheckObject(L, 2, typeof(UITable.OnReposition));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onReposition = (DelegateFactory.CreateDelegate(typeof(UITable.OnReposition), func) as UITable.OnReposition);
			}
			uITable.onReposition = onReposition;
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
			UITable uITable = (UITable)obj;
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
			uITable.onCustomSort = onCustomSort;
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
			UITable uITable = (UITable)obj;
			bool repositionNow = LuaDLL.luaL_checkboolean(L, 2);
			uITable.repositionNow = repositionNow;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index repositionNow on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UITable_OnReposition(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UITable.OnReposition), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UITable.OnReposition), func, self);
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
