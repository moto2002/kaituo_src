using Assets.Scripts.Tools.NGUI.Component;
using LuaInterface;
using System;
using UnityEngine;

public class Assets_Scripts_Tools_NGUI_Component_UICenterOnChildV2Wrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UICenterOnChildV2), typeof(UICenterOnChild), null);
		L.RegFunction("Recenter", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UICenterOnChildV2Wrap.Recenter));
		L.RegFunction("CenterOn", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UICenterOnChildV2Wrap.CenterOn));
		L.RegFunction("__eq", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UICenterOnChildV2Wrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("onDragFinishedCenter", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UICenterOnChildV2Wrap.get_onDragFinishedCenter), new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UICenterOnChildV2Wrap.set_onDragFinishedCenter));
		L.RegFunction("OnDragFinishedCenter", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UICenterOnChildV2Wrap.Assets_Scripts_Tools_NGUI_Component_UICenterOnChildV2_OnDragFinishedCenter));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Recenter(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UICenterOnChildV2 uICenterOnChildV = (UICenterOnChildV2)ToLua.CheckObject(L, 1, typeof(UICenterOnChildV2));
			uICenterOnChildV.Recenter();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CenterOn(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			UICenterOnChildV2 uICenterOnChildV = (UICenterOnChildV2)ToLua.CheckObject(L, 1, typeof(UICenterOnChildV2));
			Transform target = (Transform)ToLua.CheckUnityObject(L, 2, typeof(Transform));
			bool immediately = LuaDLL.luaL_checkboolean(L, 3);
			uICenterOnChildV.CenterOn(target, immediately);
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
	private static int get_onDragFinishedCenter(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICenterOnChildV2 uICenterOnChildV = (UICenterOnChildV2)obj;
			UICenterOnChildV2.OnDragFinishedCenter onDragFinishedCenter = uICenterOnChildV.onDragFinishedCenter;
			ToLua.Push(L, onDragFinishedCenter);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onDragFinishedCenter on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onDragFinishedCenter(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICenterOnChildV2 uICenterOnChildV = (UICenterOnChildV2)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UICenterOnChildV2.OnDragFinishedCenter onDragFinishedCenter;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onDragFinishedCenter = (UICenterOnChildV2.OnDragFinishedCenter)ToLua.CheckObject(L, 2, typeof(UICenterOnChildV2.OnDragFinishedCenter));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onDragFinishedCenter = (DelegateFactory.CreateDelegate(typeof(UICenterOnChildV2.OnDragFinishedCenter), func) as UICenterOnChildV2.OnDragFinishedCenter);
			}
			uICenterOnChildV.onDragFinishedCenter = onDragFinishedCenter;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onDragFinishedCenter on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Assets_Scripts_Tools_NGUI_Component_UICenterOnChildV2_OnDragFinishedCenter(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UICenterOnChildV2.OnDragFinishedCenter), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UICenterOnChildV2.OnDragFinishedCenter), func, self);
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
