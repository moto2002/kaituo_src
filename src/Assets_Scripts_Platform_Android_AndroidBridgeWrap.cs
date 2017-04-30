using Assets.Scripts.Platform.Android;
using LuaInterface;
using System;
using UnityEngine;

public class Assets_Scripts_Platform_Android_AndroidBridgeWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(AndroidBridge), typeof(MonoBehaviour), null);
		L.RegFunction("CallStatic", new LuaCSFunction(Assets_Scripts_Platform_Android_AndroidBridgeWrap.CallStatic));
		L.RegFunction("Call", new LuaCSFunction(Assets_Scripts_Platform_Android_AndroidBridgeWrap.Call));
		L.RegFunction("GetStatic", new LuaCSFunction(Assets_Scripts_Platform_Android_AndroidBridgeWrap.GetStatic));
		L.RegFunction("GetClass", new LuaCSFunction(Assets_Scripts_Platform_Android_AndroidBridgeWrap.GetClass));
		L.RegFunction("AddEventListener", new LuaCSFunction(Assets_Scripts_Platform_Android_AndroidBridgeWrap.AddEventListener));
		L.RegFunction("RemoveEventListener", new LuaCSFunction(Assets_Scripts_Platform_Android_AndroidBridgeWrap.RemoveEventListener));
		L.RegFunction("AndroidBridgeLog", new LuaCSFunction(Assets_Scripts_Platform_Android_AndroidBridgeWrap.AndroidBridgeLog));
		L.RegFunction("__eq", new LuaCSFunction(Assets_Scripts_Platform_Android_AndroidBridgeWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("Instance", new LuaCSFunction(Assets_Scripts_Platform_Android_AndroidBridgeWrap.get_Instance), new LuaCSFunction(Assets_Scripts_Platform_Android_AndroidBridgeWrap.set_Instance));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CallStatic(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			string className = ToLua.CheckString(L, 1);
			string methodName = ToLua.CheckString(L, 2);
			string arg = ToLua.CheckString(L, 3);
			AndroidBridge.CallStatic(className, methodName, arg);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Call(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			AndroidJavaObject javaObject = (AndroidJavaObject)ToLua.CheckObject(L, 1, typeof(AndroidJavaObject));
			string methodName = ToLua.CheckString(L, 2);
			string arg = ToLua.CheckString(L, 3);
			AndroidBridge.Call(javaObject, methodName, arg);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetStatic(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			string className = ToLua.CheckString(L, 1);
			string fieldName = ToLua.CheckString(L, 2);
			AndroidJavaObject @static = AndroidBridge.GetStatic(className, fieldName);
			ToLua.PushObject(L, @static);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClass(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string className = ToLua.CheckString(L, 1);
			AndroidJavaClass @class = AndroidBridge.GetClass(className);
			ToLua.PushObject(L, @class);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddEventListener(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			string eventName = ToLua.CheckString(L, 1);
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Action<string> handler;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				handler = (Action<string>)ToLua.CheckObject(L, 2, typeof(Action<string>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				handler = (DelegateFactory.CreateDelegate(typeof(Action<string>), func) as Action<string>);
			}
			AndroidBridge.AddEventListener(eventName, handler);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RemoveEventListener(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string eventName = ToLua.CheckString(L, 1);
			AndroidBridge.RemoveEventListener(eventName);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AndroidBridgeLog(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			AndroidBridge androidBridge = (AndroidBridge)ToLua.CheckObject(L, 1, typeof(AndroidBridge));
			string msg = ToLua.CheckString(L, 2);
			androidBridge.AndroidBridgeLog(msg);
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
	private static int get_Instance(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, AndroidBridge.Instance);
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
			AndroidBridge instance = (AndroidBridge)ToLua.CheckUnityObject(L, 2, typeof(AndroidBridge));
			AndroidBridge.Instance = instance;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
