using LuaInterface;
using System;
using UnityEngine;
using XQ.Framework.Lua;

public class XQ_Framework_Lua_ILuaScriptBaseWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(ILuaScriptBase), typeof(MonoBehaviour), null);
		L.RegFunction("OnAwake", new LuaCSFunction(XQ_Framework_Lua_ILuaScriptBaseWrap.OnAwake));
		L.RegFunction("OnDestroyNow", new LuaCSFunction(XQ_Framework_Lua_ILuaScriptBaseWrap.OnDestroyNow));
		L.RegFunction("__eq", new LuaCSFunction(XQ_Framework_Lua_ILuaScriptBaseWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnAwake(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			ILuaScriptBase luaScriptBase = (ILuaScriptBase)ToLua.CheckObject(L, 1, typeof(ILuaScriptBase));
			luaScriptBase.OnAwake();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnDestroyNow(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			ILuaScriptBase luaScriptBase = (ILuaScriptBase)ToLua.CheckObject(L, 1, typeof(ILuaScriptBase));
			luaScriptBase.OnDestroyNow();
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
}
