using LuaInterface;
using System;
using UnityEngine;

public class UnityEngine_AndroidJavaObjectWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(AndroidJavaObject), typeof(object), null);
		L.RegFunction("Dispose", new LuaCSFunction(UnityEngine_AndroidJavaObjectWrap.Dispose));
		L.RegFunction("Call", new LuaCSFunction(UnityEngine_AndroidJavaObjectWrap.Call));
		L.RegFunction("CallStatic", new LuaCSFunction(UnityEngine_AndroidJavaObjectWrap.CallStatic));
		L.RegFunction("GetRawObject", new LuaCSFunction(UnityEngine_AndroidJavaObjectWrap.GetRawObject));
		L.RegFunction("GetRawClass", new LuaCSFunction(UnityEngine_AndroidJavaObjectWrap.GetRawClass));
		L.RegFunction("New", new LuaCSFunction(UnityEngine_AndroidJavaObjectWrap._CreateUnityEngine_AndroidJavaObject));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateUnityEngine_AndroidJavaObject(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (TypeChecker.CheckTypes(L, 1, typeof(string)) && TypeChecker.CheckParamsType(L, typeof(object), 2, num - 1))
			{
				string className = ToLua.CheckString(L, 1);
				object[] args = ToLua.ToParamsObject(L, 2, num - 1);
				AndroidJavaObject o = new AndroidJavaObject(className, args);
				ToLua.PushObject(L, o);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: UnityEngine.AndroidJavaObject.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Dispose(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			AndroidJavaObject androidJavaObject = (AndroidJavaObject)ToLua.CheckObject(L, 1, typeof(AndroidJavaObject));
			androidJavaObject.Dispose();
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
			int num = LuaDLL.lua_gettop(L);
			AndroidJavaObject androidJavaObject = (AndroidJavaObject)ToLua.CheckObject(L, 1, typeof(AndroidJavaObject));
			string methodName = ToLua.CheckString(L, 2);
			object[] args = ToLua.ToParamsObject(L, 3, num - 2);
			androidJavaObject.Call(methodName, args);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CallStatic(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			AndroidJavaObject androidJavaObject = (AndroidJavaObject)ToLua.CheckObject(L, 1, typeof(AndroidJavaObject));
			string methodName = ToLua.CheckString(L, 2);
			object[] args = ToLua.ToParamsObject(L, 3, num - 2);
			androidJavaObject.CallStatic(methodName, args);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetRawObject(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			AndroidJavaObject androidJavaObject = (AndroidJavaObject)ToLua.CheckObject(L, 1, typeof(AndroidJavaObject));
			IntPtr rawObject = androidJavaObject.GetRawObject();
			LuaDLL.lua_pushlightuserdata(L, rawObject);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetRawClass(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			AndroidJavaObject androidJavaObject = (AndroidJavaObject)ToLua.CheckObject(L, 1, typeof(AndroidJavaObject));
			IntPtr rawClass = androidJavaObject.GetRawClass();
			LuaDLL.lua_pushlightuserdata(L, rawClass);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
