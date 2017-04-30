using Assets.Tools.Script.Go;
using LuaInterface;
using System;
using UnityEngine;

public class Assets_Tools_Script_Go_ParasiticComponentWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(ParasiticComponent), typeof(MonoBehaviour), null);
		L.RegFunction("GetSecondaryHost", new LuaCSFunction(Assets_Tools_Script_Go_ParasiticComponentWrap.GetSecondaryHost));
		L.RegFunction("__eq", new LuaCSFunction(Assets_Tools_Script_Go_ParasiticComponentWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("parasiteHost", new LuaCSFunction(Assets_Tools_Script_Go_ParasiticComponentWrap.get_parasiteHost), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetSecondaryHost(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string name = ToLua.CheckString(L, 1);
			GameObject secondaryHost = ParasiticComponent.GetSecondaryHost(name);
			ToLua.Push(L, secondaryHost);
			result = 1;
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
	private static int get_parasiteHost(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, ParasiticComponent.parasiteHost);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
