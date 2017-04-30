using Assets.Scripts.Tools.NGUI.Component;
using LuaInterface;
using System;
using UnityEngine;

public class Assets_Scripts_Tools_NGUI_Component_UIScrollGridWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UIScrollGrid), typeof(MonoBehaviour), null);
		L.RegFunction("Reset", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIScrollGridWrap.Reset));
		L.RegFunction("__eq", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIScrollGridWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("ScrollView", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIScrollGridWrap.get_ScrollView), new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIScrollGridWrap.set_ScrollView));
		L.RegVar("TargetCenter", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIScrollGridWrap.get_TargetCenter), new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIScrollGridWrap.set_TargetCenter));
		L.RegVar("CellWidth", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIScrollGridWrap.get_CellWidth), new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIScrollGridWrap.set_CellWidth));
		L.RegVar("StartPos", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIScrollGridWrap.get_StartPos), new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIScrollGridWrap.set_StartPos));
		L.RegVar("StartRange", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIScrollGridWrap.get_StartRange), new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIScrollGridWrap.set_StartRange));
		L.RegVar("CenterOffset", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIScrollGridWrap.get_CenterOffset), new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIScrollGridWrap.set_CenterOffset));
		L.RegVar("MaxScale", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIScrollGridWrap.get_MaxScale), new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIScrollGridWrap.set_MaxScale));
		L.RegVar("MinScale", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIScrollGridWrap.get_MinScale), new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIScrollGridWrap.set_MinScale));
		L.RegVar("UseLateUpdate", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIScrollGridWrap.get_UseLateUpdate), new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIScrollGridWrap.set_UseLateUpdate));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Reset(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIScrollGrid uIScrollGrid = (UIScrollGrid)ToLua.CheckObject(L, 1, typeof(UIScrollGrid));
			uIScrollGrid.Reset();
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
	private static int get_ScrollView(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollGrid uIScrollGrid = (UIScrollGrid)obj;
			UIScrollView scrollView = uIScrollGrid.ScrollView;
			ToLua.Push(L, scrollView);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ScrollView on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_TargetCenter(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollGrid uIScrollGrid = (UIScrollGrid)obj;
			GameObject targetCenter = uIScrollGrid.TargetCenter;
			ToLua.Push(L, targetCenter);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index TargetCenter on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_CellWidth(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollGrid uIScrollGrid = (UIScrollGrid)obj;
			float cellWidth = uIScrollGrid.CellWidth;
			LuaDLL.lua_pushnumber(L, (double)cellWidth);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index CellWidth on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_StartPos(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollGrid uIScrollGrid = (UIScrollGrid)obj;
			float startPos = uIScrollGrid.StartPos;
			LuaDLL.lua_pushnumber(L, (double)startPos);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index StartPos on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_StartRange(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollGrid uIScrollGrid = (UIScrollGrid)obj;
			float startRange = uIScrollGrid.StartRange;
			LuaDLL.lua_pushnumber(L, (double)startRange);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index StartRange on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_CenterOffset(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollGrid uIScrollGrid = (UIScrollGrid)obj;
			Vector3 centerOffset = uIScrollGrid.CenterOffset;
			ToLua.Push(L, centerOffset);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index CenterOffset on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_MaxScale(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollGrid uIScrollGrid = (UIScrollGrid)obj;
			Vector3 maxScale = uIScrollGrid.MaxScale;
			ToLua.Push(L, maxScale);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index MaxScale on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_MinScale(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollGrid uIScrollGrid = (UIScrollGrid)obj;
			Vector3 minScale = uIScrollGrid.MinScale;
			ToLua.Push(L, minScale);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index MinScale on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_UseLateUpdate(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollGrid uIScrollGrid = (UIScrollGrid)obj;
			bool useLateUpdate = uIScrollGrid.UseLateUpdate;
			LuaDLL.lua_pushboolean(L, useLateUpdate);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index UseLateUpdate on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_ScrollView(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollGrid uIScrollGrid = (UIScrollGrid)obj;
			UIScrollView scrollView = (UIScrollView)ToLua.CheckUnityObject(L, 2, typeof(UIScrollView));
			uIScrollGrid.ScrollView = scrollView;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ScrollView on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_TargetCenter(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollGrid uIScrollGrid = (UIScrollGrid)obj;
			GameObject targetCenter = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			uIScrollGrid.TargetCenter = targetCenter;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index TargetCenter on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_CellWidth(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollGrid uIScrollGrid = (UIScrollGrid)obj;
			float cellWidth = (float)LuaDLL.luaL_checknumber(L, 2);
			uIScrollGrid.CellWidth = cellWidth;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index CellWidth on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_StartPos(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollGrid uIScrollGrid = (UIScrollGrid)obj;
			float startPos = (float)LuaDLL.luaL_checknumber(L, 2);
			uIScrollGrid.StartPos = startPos;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index StartPos on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_StartRange(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollGrid uIScrollGrid = (UIScrollGrid)obj;
			float startRange = (float)LuaDLL.luaL_checknumber(L, 2);
			uIScrollGrid.StartRange = startRange;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index StartRange on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_CenterOffset(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollGrid uIScrollGrid = (UIScrollGrid)obj;
			Vector3 centerOffset = ToLua.ToVector3(L, 2);
			uIScrollGrid.CenterOffset = centerOffset;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index CenterOffset on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_MaxScale(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollGrid uIScrollGrid = (UIScrollGrid)obj;
			Vector3 maxScale = ToLua.ToVector3(L, 2);
			uIScrollGrid.MaxScale = maxScale;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index MaxScale on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_MinScale(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollGrid uIScrollGrid = (UIScrollGrid)obj;
			Vector3 minScale = ToLua.ToVector3(L, 2);
			uIScrollGrid.MinScale = minScale;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index MinScale on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_UseLateUpdate(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollGrid uIScrollGrid = (UIScrollGrid)obj;
			bool useLateUpdate = LuaDLL.luaL_checkboolean(L, 2);
			uIScrollGrid.UseLateUpdate = useLateUpdate;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index UseLateUpdate on a nil value");
		}
		return result;
	}
}
