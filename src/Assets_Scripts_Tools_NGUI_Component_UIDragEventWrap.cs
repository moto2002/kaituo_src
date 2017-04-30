using Assets.Scripts.Tools.NGUI.Component;
using LuaInterface;
using System;
using UnityEngine;

public class Assets_Scripts_Tools_NGUI_Component_UIDragEventWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UIDragEvent), typeof(MonoBehaviour), null);
		L.RegFunction("__eq", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIDragEventWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("OnDragEnd", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIDragEventWrap.get_OnDragEnd), new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIDragEventWrap.set_OnDragEnd));
		L.EndClass();
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
	private static int get_OnDragEnd(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDragEvent uIDragEvent = (UIDragEvent)obj;
			Action<Vector2> onDragEnd = uIDragEvent.OnDragEnd;
			ToLua.Push(L, onDragEnd);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index OnDragEnd on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_OnDragEnd(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDragEvent uIDragEvent = (UIDragEvent)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Action<Vector2> onDragEnd;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onDragEnd = (Action<Vector2>)ToLua.CheckObject(L, 2, typeof(Action<Vector2>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onDragEnd = (DelegateFactory.CreateDelegate(typeof(Action<Vector2>), func) as Action<Vector2>);
			}
			uIDragEvent.OnDragEnd = onDragEnd;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index OnDragEnd on a nil value");
		}
		return result;
	}
}
