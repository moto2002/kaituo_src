using Assets.Scripts.Game.SDK;
using LuaInterface;
using System;
using UnityEngine;

public class Assets_Scripts_Game_SDK_WXManagerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(WXManager), typeof(MonoBehaviour), null);
		L.RegFunction("Login", new LuaCSFunction(Assets_Scripts_Game_SDK_WXManagerWrap.Login));
		L.RegFunction("Logout", new LuaCSFunction(Assets_Scripts_Game_SDK_WXManagerWrap.Logout));
		L.RegFunction("HasLoginRecord", new LuaCSFunction(Assets_Scripts_Game_SDK_WXManagerWrap.HasLoginRecord));
		L.RegFunction("IsLoginRecordValid", new LuaCSFunction(Assets_Scripts_Game_SDK_WXManagerWrap.IsLoginRecordValid));
		L.RegFunction("IsWXAppInstalled", new LuaCSFunction(Assets_Scripts_Game_SDK_WXManagerWrap.IsWXAppInstalled));
		L.RegFunction("__eq", new LuaCSFunction(Assets_Scripts_Game_SDK_WXManagerWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("Instance", new LuaCSFunction(Assets_Scripts_Game_SDK_WXManagerWrap.get_Instance), new LuaCSFunction(Assets_Scripts_Game_SDK_WXManagerWrap.set_Instance));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Login(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			WXManager wXManager = (WXManager)ToLua.CheckObject(L, 1, typeof(WXManager));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Action<string> onEnd;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onEnd = (Action<string>)ToLua.CheckObject(L, 2, typeof(Action<string>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onEnd = (DelegateFactory.CreateDelegate(typeof(Action<string>), func) as Action<string>);
			}
			wXManager.Login(onEnd);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Logout(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			WXManager wXManager = (WXManager)ToLua.CheckObject(L, 1, typeof(WXManager));
			wXManager.Logout();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int HasLoginRecord(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			WXManager wXManager = (WXManager)ToLua.CheckObject(L, 1, typeof(WXManager));
			bool value = wXManager.HasLoginRecord();
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
	private static int IsLoginRecordValid(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			WXManager wXManager = (WXManager)ToLua.CheckObject(L, 1, typeof(WXManager));
			bool value = wXManager.IsLoginRecordValid();
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
	private static int IsWXAppInstalled(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			WXManager wXManager = (WXManager)ToLua.CheckObject(L, 1, typeof(WXManager));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Action<bool> callback;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				callback = (Action<bool>)ToLua.CheckObject(L, 2, typeof(Action<bool>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				callback = (DelegateFactory.CreateDelegate(typeof(Action<bool>), func) as Action<bool>);
			}
			wXManager.IsWXAppInstalled(callback);
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
			ToLua.Push(L, WXManager.Instance);
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
			WXManager instance = (WXManager)ToLua.CheckUnityObject(L, 2, typeof(WXManager));
			WXManager.Instance = instance;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
