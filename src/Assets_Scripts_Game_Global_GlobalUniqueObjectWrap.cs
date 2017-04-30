using Assets.Scripts.Game.Global;
using LuaInterface;
using System;
using UnityEngine;

public class Assets_Scripts_Game_Global_GlobalUniqueObjectWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(GlobalUniqueObject), typeof(MonoBehaviour), null);
		L.RegFunction("Init", new LuaCSFunction(Assets_Scripts_Game_Global_GlobalUniqueObjectWrap.Init));
		L.RegFunction("AddVariable", new LuaCSFunction(Assets_Scripts_Game_Global_GlobalUniqueObjectWrap.AddVariable));
		L.RegFunction("GetIntValue", new LuaCSFunction(Assets_Scripts_Game_Global_GlobalUniqueObjectWrap.GetIntValue));
		L.RegFunction("GetFloatValue", new LuaCSFunction(Assets_Scripts_Game_Global_GlobalUniqueObjectWrap.GetFloatValue));
		L.RegFunction("GetStringValue", new LuaCSFunction(Assets_Scripts_Game_Global_GlobalUniqueObjectWrap.GetStringValue));
		L.RegFunction("__eq", new LuaCSFunction(Assets_Scripts_Game_Global_GlobalUniqueObjectWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("Instance", new LuaCSFunction(Assets_Scripts_Game_Global_GlobalUniqueObjectWrap.get_Instance), new LuaCSFunction(Assets_Scripts_Game_Global_GlobalUniqueObjectWrap.set_Instance));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Init(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			GlobalUniqueObject.Init();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddVariable(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			string variableName = ToLua.CheckString(L, 1);
			object value = ToLua.ToVarObject(L, 2);
			GlobalUniqueObject.AddVariable(variableName, value);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetIntValue(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string variableName = ToLua.CheckString(L, 1);
			int intValue = GlobalUniqueObject.GetIntValue(variableName);
			LuaDLL.lua_pushinteger(L, intValue);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetFloatValue(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string variableName = ToLua.CheckString(L, 1);
			float floatValue = GlobalUniqueObject.GetFloatValue(variableName);
			LuaDLL.lua_pushnumber(L, (double)floatValue);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetStringValue(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string variableName = ToLua.CheckString(L, 1);
			string stringValue = GlobalUniqueObject.GetStringValue(variableName);
			LuaDLL.lua_pushstring(L, stringValue);
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
	private static int get_Instance(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, GlobalUniqueObject.Instance);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Instance(IntPtr L)
	{
		int result;
		try
		{
			GlobalUniqueObject instance = (GlobalUniqueObject)ToLua.CheckUnityObject(L, 2, typeof(GlobalUniqueObject));
			GlobalUniqueObject.Instance = instance;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
