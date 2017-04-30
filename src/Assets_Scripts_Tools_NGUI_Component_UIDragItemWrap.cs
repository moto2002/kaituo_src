using Assets.Scripts.Tools.NGUI.Component;
using LuaInterface;
using System;
using UnityEngine;

public class Assets_Scripts_Tools_NGUI_Component_UIDragItemWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UIDragItem), typeof(UIDragDropItem), null);
		L.RegFunction("StartDragging", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIDragItemWrap.StartDragging));
		L.RegFunction("__eq", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIDragItemWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("RestrictionSensitivity", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIDragItemWrap.get_RestrictionSensitivity), new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIDragItemWrap.set_RestrictionSensitivity));
		L.RegVar("OnStartDragItem", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIDragItemWrap.get_OnStartDragItem), new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIDragItemWrap.set_OnStartDragItem));
		L.RegVar("OnCloneItem", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIDragItemWrap.get_OnCloneItem), new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIDragItemWrap.set_OnCloneItem));
		L.RegVar("OnDropItem", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIDragItemWrap.get_OnDropItem), new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIDragItemWrap.set_OnDropItem));
		L.RegVar("OnDragingItem", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIDragItemWrap.get_OnDragingItem), new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIDragItemWrap.set_OnDragingItem));
		L.RegVar("CloneHook", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIDragItemWrap.get_CloneHook), new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIDragItemWrap.set_CloneHook));
		L.RegVar("DestroyCloneHook", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIDragItemWrap.get_DestroyCloneHook), new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIDragItemWrap.set_DestroyCloneHook));
		L.RegVar("CanDragHook", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIDragItemWrap.get_CanDragHook), new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIDragItemWrap.set_CanDragHook));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int StartDragging(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIDragItem uIDragItem = (UIDragItem)ToLua.CheckObject(L, 1, typeof(UIDragItem));
			uIDragItem.StartDragging();
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
	private static int get_RestrictionSensitivity(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDragItem uIDragItem = (UIDragItem)obj;
			float restrictionSensitivity = uIDragItem.RestrictionSensitivity;
			LuaDLL.lua_pushnumber(L, (double)restrictionSensitivity);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index RestrictionSensitivity on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_OnStartDragItem(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDragItem uIDragItem = (UIDragItem)obj;
			Action<GameObject> onStartDragItem = uIDragItem.OnStartDragItem;
			ToLua.Push(L, onStartDragItem);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index OnStartDragItem on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_OnCloneItem(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDragItem uIDragItem = (UIDragItem)obj;
			Action<GameObject, GameObject> onCloneItem = uIDragItem.OnCloneItem;
			ToLua.Push(L, onCloneItem);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index OnCloneItem on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_OnDropItem(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDragItem uIDragItem = (UIDragItem)obj;
			Action<GameObject, GameObject, GameObject> onDropItem = uIDragItem.OnDropItem;
			ToLua.Push(L, onDropItem);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index OnDropItem on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_OnDragingItem(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDragItem uIDragItem = (UIDragItem)obj;
			Action<GameObject, GameObject> onDragingItem = uIDragItem.OnDragingItem;
			ToLua.Push(L, onDragingItem);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index OnDragingItem on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_CloneHook(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDragItem uIDragItem = (UIDragItem)obj;
			Func<GameObject, GameObject> cloneHook = uIDragItem.CloneHook;
			ToLua.Push(L, cloneHook);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index CloneHook on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_DestroyCloneHook(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDragItem uIDragItem = (UIDragItem)obj;
			Action<GameObject> destroyCloneHook = uIDragItem.DestroyCloneHook;
			ToLua.Push(L, destroyCloneHook);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index DestroyCloneHook on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_CanDragHook(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDragItem uIDragItem = (UIDragItem)obj;
			Func<GameObject, bool> canDragHook = uIDragItem.CanDragHook;
			ToLua.Push(L, canDragHook);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index CanDragHook on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_RestrictionSensitivity(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDragItem uIDragItem = (UIDragItem)obj;
			float restrictionSensitivity = (float)LuaDLL.luaL_checknumber(L, 2);
			uIDragItem.RestrictionSensitivity = restrictionSensitivity;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index RestrictionSensitivity on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_OnStartDragItem(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDragItem uIDragItem = (UIDragItem)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Action<GameObject> onStartDragItem;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onStartDragItem = (Action<GameObject>)ToLua.CheckObject(L, 2, typeof(Action<GameObject>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onStartDragItem = (DelegateFactory.CreateDelegate(typeof(Action<GameObject>), func) as Action<GameObject>);
			}
			uIDragItem.OnStartDragItem = onStartDragItem;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index OnStartDragItem on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_OnCloneItem(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDragItem uIDragItem = (UIDragItem)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Action<GameObject, GameObject> onCloneItem;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onCloneItem = (Action<GameObject, GameObject>)ToLua.CheckObject(L, 2, typeof(Action<GameObject, GameObject>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onCloneItem = (DelegateFactory.CreateDelegate(typeof(Action<GameObject, GameObject>), func) as Action<GameObject, GameObject>);
			}
			uIDragItem.OnCloneItem = onCloneItem;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index OnCloneItem on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_OnDropItem(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDragItem uIDragItem = (UIDragItem)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Action<GameObject, GameObject, GameObject> onDropItem;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onDropItem = (Action<GameObject, GameObject, GameObject>)ToLua.CheckObject(L, 2, typeof(Action<GameObject, GameObject, GameObject>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onDropItem = (DelegateFactory.CreateDelegate(typeof(Action<GameObject, GameObject, GameObject>), func) as Action<GameObject, GameObject, GameObject>);
			}
			uIDragItem.OnDropItem = onDropItem;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index OnDropItem on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_OnDragingItem(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDragItem uIDragItem = (UIDragItem)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Action<GameObject, GameObject> onDragingItem;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onDragingItem = (Action<GameObject, GameObject>)ToLua.CheckObject(L, 2, typeof(Action<GameObject, GameObject>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onDragingItem = (DelegateFactory.CreateDelegate(typeof(Action<GameObject, GameObject>), func) as Action<GameObject, GameObject>);
			}
			uIDragItem.OnDragingItem = onDragingItem;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index OnDragingItem on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_CloneHook(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDragItem uIDragItem = (UIDragItem)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Func<GameObject, GameObject> cloneHook;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				cloneHook = (Func<GameObject, GameObject>)ToLua.CheckObject(L, 2, typeof(Func<GameObject, GameObject>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				cloneHook = (DelegateFactory.CreateDelegate(typeof(Func<GameObject, GameObject>), func) as Func<GameObject, GameObject>);
			}
			uIDragItem.CloneHook = cloneHook;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index CloneHook on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_DestroyCloneHook(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDragItem uIDragItem = (UIDragItem)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Action<GameObject> destroyCloneHook;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				destroyCloneHook = (Action<GameObject>)ToLua.CheckObject(L, 2, typeof(Action<GameObject>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				destroyCloneHook = (DelegateFactory.CreateDelegate(typeof(Action<GameObject>), func) as Action<GameObject>);
			}
			uIDragItem.DestroyCloneHook = destroyCloneHook;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index DestroyCloneHook on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_CanDragHook(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDragItem uIDragItem = (UIDragItem)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Func<GameObject, bool> canDragHook;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				canDragHook = (Func<GameObject, bool>)ToLua.CheckObject(L, 2, typeof(Func<GameObject, bool>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				canDragHook = (DelegateFactory.CreateDelegate(typeof(Func<GameObject, bool>), func) as Func<GameObject, bool>);
			}
			uIDragItem.CanDragHook = canDragHook;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index CanDragHook on a nil value");
		}
		return result;
	}
}
