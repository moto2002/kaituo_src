using Assets.Scripts.Tools.NGUI.Component;
using LuaInterface;
using System;
using UnityEngine;

public class Assets_Scripts_Tools_NGUI_Component_UIGridOptimizeSpringWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UIGridOptimizeSpring), typeof(UIGrid), null);
		L.RegFunction("__eq", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIGridOptimizeSpringWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
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
}
