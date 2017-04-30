using Assets.Scripts.Tools.NGUI.Component;
using LuaInterface;
using System;
using UnityEngine;

public class Assets_Scripts_Tools_NGUI_Component_UIDepthModifierWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UIDepthModifier), typeof(MonoBehaviour), null);
		L.RegFunction("UpdateWidget", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIDepthModifierWrap.UpdateWidget));
		L.RegFunction("__eq", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIDepthModifierWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("Depth", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIDepthModifierWrap.get_Depth), new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIDepthModifierWrap.set_Depth));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UpdateWidget(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIDepthModifier uIDepthModifier = (UIDepthModifier)ToLua.CheckObject(L, 1, typeof(UIDepthModifier));
			uIDepthModifier.UpdateWidget();
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
	private static int get_Depth(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDepthModifier uIDepthModifier = (UIDepthModifier)obj;
			int depth = uIDepthModifier.Depth;
			LuaDLL.lua_pushinteger(L, depth);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Depth on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Depth(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDepthModifier uIDepthModifier = (UIDepthModifier)obj;
			int depth = (int)LuaDLL.luaL_checknumber(L, 2);
			uIDepthModifier.Depth = depth;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Depth on a nil value");
		}
		return result;
	}
}
