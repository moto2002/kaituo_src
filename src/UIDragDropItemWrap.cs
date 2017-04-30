using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

public class UIDragDropItemWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UIDragDropItem), typeof(MonoBehaviour), null);
		L.RegFunction("StartDragging", new LuaCSFunction(UIDragDropItemWrap.StartDragging));
		L.RegFunction("StopDragging", new LuaCSFunction(UIDragDropItemWrap.StopDragging));
		L.RegFunction("__eq", new LuaCSFunction(UIDragDropItemWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("restriction", new LuaCSFunction(UIDragDropItemWrap.get_restriction), new LuaCSFunction(UIDragDropItemWrap.set_restriction));
		L.RegVar("cloneOnDrag", new LuaCSFunction(UIDragDropItemWrap.get_cloneOnDrag), new LuaCSFunction(UIDragDropItemWrap.set_cloneOnDrag));
		L.RegVar("pressAndHoldDelay", new LuaCSFunction(UIDragDropItemWrap.get_pressAndHoldDelay), new LuaCSFunction(UIDragDropItemWrap.set_pressAndHoldDelay));
		L.RegVar("interactable", new LuaCSFunction(UIDragDropItemWrap.get_interactable), new LuaCSFunction(UIDragDropItemWrap.set_interactable));
		L.RegVar("draggedItems", new LuaCSFunction(UIDragDropItemWrap.get_draggedItems), new LuaCSFunction(UIDragDropItemWrap.set_draggedItems));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int StartDragging(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIDragDropItem uIDragDropItem = (UIDragDropItem)ToLua.CheckObject(L, 1, typeof(UIDragDropItem));
			uIDragDropItem.StartDragging();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int StopDragging(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UIDragDropItem uIDragDropItem = (UIDragDropItem)ToLua.CheckObject(L, 1, typeof(UIDragDropItem));
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			uIDragDropItem.StopDragging(go);
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
	private static int get_restriction(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDragDropItem uIDragDropItem = (UIDragDropItem)obj;
			UIDragDropItem.Restriction restriction = uIDragDropItem.restriction;
			ToLua.Push(L, restriction);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index restriction on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_cloneOnDrag(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDragDropItem uIDragDropItem = (UIDragDropItem)obj;
			bool cloneOnDrag = uIDragDropItem.cloneOnDrag;
			LuaDLL.lua_pushboolean(L, cloneOnDrag);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cloneOnDrag on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_pressAndHoldDelay(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDragDropItem uIDragDropItem = (UIDragDropItem)obj;
			float pressAndHoldDelay = uIDragDropItem.pressAndHoldDelay;
			LuaDLL.lua_pushnumber(L, (double)pressAndHoldDelay);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pressAndHoldDelay on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_interactable(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDragDropItem uIDragDropItem = (UIDragDropItem)obj;
			bool interactable = uIDragDropItem.interactable;
			LuaDLL.lua_pushboolean(L, interactable);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index interactable on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_draggedItems(IntPtr L)
	{
		int result;
		try
		{
			ToLua.PushObject(L, UIDragDropItem.draggedItems);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_restriction(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDragDropItem uIDragDropItem = (UIDragDropItem)obj;
			UIDragDropItem.Restriction restriction = (UIDragDropItem.Restriction)LuaDLL.luaL_checknumber(L, 2);
			uIDragDropItem.restriction = restriction;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index restriction on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_cloneOnDrag(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDragDropItem uIDragDropItem = (UIDragDropItem)obj;
			bool cloneOnDrag = LuaDLL.luaL_checkboolean(L, 2);
			uIDragDropItem.cloneOnDrag = cloneOnDrag;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cloneOnDrag on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_pressAndHoldDelay(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDragDropItem uIDragDropItem = (UIDragDropItem)obj;
			float pressAndHoldDelay = (float)LuaDLL.luaL_checknumber(L, 2);
			uIDragDropItem.pressAndHoldDelay = pressAndHoldDelay;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pressAndHoldDelay on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_interactable(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDragDropItem uIDragDropItem = (UIDragDropItem)obj;
			bool interactable = LuaDLL.luaL_checkboolean(L, 2);
			uIDragDropItem.interactable = interactable;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index interactable on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_draggedItems(IntPtr L)
	{
		int result;
		try
		{
			List<UIDragDropItem> draggedItems = (List<UIDragDropItem>)ToLua.CheckObject(L, 2, typeof(List<UIDragDropItem>));
			UIDragDropItem.draggedItems = draggedItems;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
