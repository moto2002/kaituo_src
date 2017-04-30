using Assets.Scripts.Game.SDK;
using LuaInterface;
using System;
using UnityEngine;

public class Assets_Scripts_Game_SDK_SMSManagerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(SMSManager), typeof(MonoBehaviour), null);
		L.RegFunction("GetCode", new LuaCSFunction(Assets_Scripts_Game_SDK_SMSManagerWrap.GetCode));
		L.RegFunction("CommitCode", new LuaCSFunction(Assets_Scripts_Game_SDK_SMSManagerWrap.CommitCode));
		L.RegFunction("onComplete", new LuaCSFunction(Assets_Scripts_Game_SDK_SMSManagerWrap.onComplete));
		L.RegFunction("IsPhoneNumber", new LuaCSFunction(Assets_Scripts_Game_SDK_SMSManagerWrap.IsPhoneNumber));
		L.RegFunction("onError", new LuaCSFunction(Assets_Scripts_Game_SDK_SMSManagerWrap.onError));
		L.RegFunction("__eq", new LuaCSFunction(Assets_Scripts_Game_SDK_SMSManagerWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("Instance", new LuaCSFunction(Assets_Scripts_Game_SDK_SMSManagerWrap.get_Instance), new LuaCSFunction(Assets_Scripts_Game_SDK_SMSManagerWrap.set_Instance));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetCode(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			SMSManager sMSManager = (SMSManager)ToLua.CheckObject(L, 1, typeof(SMSManager));
			string phoneNumber = ToLua.CheckString(L, 2);
			string zone = ToLua.CheckString(L, 3);
			LuaTypes luaTypes = LuaDLL.lua_type(L, 4);
			Action<string> callback;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				callback = (Action<string>)ToLua.CheckObject(L, 4, typeof(Action<string>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 4);
				callback = (DelegateFactory.CreateDelegate(typeof(Action<string>), func) as Action<string>);
			}
			sMSManager.GetCode(phoneNumber, zone, callback);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CommitCode(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 5);
			SMSManager sMSManager = (SMSManager)ToLua.CheckObject(L, 1, typeof(SMSManager));
			string phoneNumber = ToLua.CheckString(L, 2);
			string zone = ToLua.CheckString(L, 3);
			string verificationCode = ToLua.CheckString(L, 4);
			LuaTypes luaTypes = LuaDLL.lua_type(L, 5);
			Action<string> callback;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				callback = (Action<string>)ToLua.CheckObject(L, 5, typeof(Action<string>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 5);
				callback = (DelegateFactory.CreateDelegate(typeof(Action<string>), func) as Action<string>);
			}
			sMSManager.CommitCode(phoneNumber, zone, verificationCode, callback);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int onComplete(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			SMSManager sMSManager = (SMSManager)ToLua.CheckObject(L, 1, typeof(SMSManager));
			int action = (int)LuaDLL.luaL_checknumber(L, 2);
			object resp = ToLua.ToVarObject(L, 3);
			sMSManager.onComplete(action, resp);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsPhoneNumber(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			SMSManager sMSManager = (SMSManager)ToLua.CheckObject(L, 1, typeof(SMSManager));
			string value = ToLua.CheckString(L, 2);
			bool value2 = sMSManager.IsPhoneNumber(value);
			LuaDLL.lua_pushboolean(L, value2);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int onError(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			SMSManager sMSManager = (SMSManager)ToLua.CheckObject(L, 1, typeof(SMSManager));
			int action = (int)LuaDLL.luaL_checknumber(L, 2);
			object resp = ToLua.ToVarObject(L, 3);
			sMSManager.onError(action, resp);
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
			ToLua.Push(L, SMSManager.Instance);
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
			SMSManager instance = (SMSManager)ToLua.CheckUnityObject(L, 2, typeof(SMSManager));
			SMSManager.Instance = instance;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
