using Assets.Scripts.Performance;
using LuaInterface;
using NodeCanvas.Framework;
using System;
using UnityEngine;

public class Assets_Scripts_Performance_BBProxyWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(BBProxy), typeof(MonoBehaviour), null);
		L.RegFunction("SetValue", new LuaCSFunction(Assets_Scripts_Performance_BBProxyWrap.SetValue));
		L.RegFunction("GetValue", new LuaCSFunction(Assets_Scripts_Performance_BBProxyWrap.GetValue));
		L.RegFunction("HasKey", new LuaCSFunction(Assets_Scripts_Performance_BBProxyWrap.HasKey));
		L.RegFunction("__eq", new LuaCSFunction(Assets_Scripts_Performance_BBProxyWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("Blackboard", new LuaCSFunction(Assets_Scripts_Performance_BBProxyWrap.get_Blackboard), new LuaCSFunction(Assets_Scripts_Performance_BBProxyWrap.set_Blackboard));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetValue(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			BBProxy bBProxy = (BBProxy)ToLua.CheckObject(L, 1, typeof(BBProxy));
			string key = ToLua.CheckString(L, 2);
			object value = ToLua.ToVarObject(L, 3);
			bBProxy.SetValue(key, value);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetValue(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			BBProxy bBProxy = (BBProxy)ToLua.CheckObject(L, 1, typeof(BBProxy));
			string key = ToLua.CheckString(L, 2);
			object value = bBProxy.GetValue(key);
			ToLua.Push(L, value);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int HasKey(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			BBProxy bBProxy = (BBProxy)ToLua.CheckObject(L, 1, typeof(BBProxy));
			string key = ToLua.CheckString(L, 2);
			bool value = bBProxy.HasKey(key);
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
	private static int get_Blackboard(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			BBProxy bBProxy = (BBProxy)obj;
			Blackboard blackboard = bBProxy.Blackboard;
			ToLua.Push(L, blackboard);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Blackboard on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Blackboard(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			BBProxy bBProxy = (BBProxy)obj;
			Blackboard blackboard = (Blackboard)ToLua.CheckUnityObject(L, 2, typeof(Blackboard));
			bBProxy.Blackboard = blackboard;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Blackboard on a nil value");
		}
		return result;
	}
}
