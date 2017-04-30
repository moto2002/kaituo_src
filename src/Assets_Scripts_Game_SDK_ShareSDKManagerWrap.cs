using Assets.Scripts.Game.SDK;
using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Assets_Scripts_Game_SDK_ShareSDKManagerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(ShareSDKManager), typeof(MonoBehaviour), null);
		L.RegFunction("Login", new LuaCSFunction(Assets_Scripts_Game_SDK_ShareSDKManagerWrap.Login));
		L.RegFunction("Logout", new LuaCSFunction(Assets_Scripts_Game_SDK_ShareSDKManagerWrap.Logout));
		L.RegFunction("GetUserInfo", new LuaCSFunction(Assets_Scripts_Game_SDK_ShareSDKManagerWrap.GetUserInfo));
		L.RegFunction("BeginShareArg", new LuaCSFunction(Assets_Scripts_Game_SDK_ShareSDKManagerWrap.BeginShareArg));
		L.RegFunction("AppendShareStringArg", new LuaCSFunction(Assets_Scripts_Game_SDK_ShareSDKManagerWrap.AppendShareStringArg));
		L.RegFunction("AppendShareIntArg", new LuaCSFunction(Assets_Scripts_Game_SDK_ShareSDKManagerWrap.AppendShareIntArg));
		L.RegFunction("AppendShareFloatArg", new LuaCSFunction(Assets_Scripts_Game_SDK_ShareSDKManagerWrap.AppendShareFloatArg));
		L.RegFunction("EndShareArg", new LuaCSFunction(Assets_Scripts_Game_SDK_ShareSDKManagerWrap.EndShareArg));
		L.RegFunction("Share", new LuaCSFunction(Assets_Scripts_Game_SDK_ShareSDKManagerWrap.Share));
		L.RegFunction("Copy2SDpath", new LuaCSFunction(Assets_Scripts_Game_SDK_ShareSDKManagerWrap.Copy2SDpath));
		L.RegFunction("__eq", new LuaCSFunction(Assets_Scripts_Game_SDK_ShareSDKManagerWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("Instance", new LuaCSFunction(Assets_Scripts_Game_SDK_ShareSDKManagerWrap.get_Instance), new LuaCSFunction(Assets_Scripts_Game_SDK_ShareSDKManagerWrap.set_Instance));
		L.RegVar("TimeOutPeriod", new LuaCSFunction(Assets_Scripts_Game_SDK_ShareSDKManagerWrap.get_TimeOutPeriod), new LuaCSFunction(Assets_Scripts_Game_SDK_ShareSDKManagerWrap.set_TimeOutPeriod));
		L.RegVar("DisableSDKCallback", new LuaCSFunction(Assets_Scripts_Game_SDK_ShareSDKManagerWrap.get_DisableSDKCallback), new LuaCSFunction(Assets_Scripts_Game_SDK_ShareSDKManagerWrap.set_DisableSDKCallback));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Login(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			ShareSDKManager shareSDKManager = (ShareSDKManager)ToLua.CheckObject(L, 1, typeof(ShareSDKManager));
			int platform = (int)LuaDLL.luaL_checknumber(L, 2);
			LuaTypes luaTypes = LuaDLL.lua_type(L, 3);
			Action<string> callback;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				callback = (Action<string>)ToLua.CheckObject(L, 3, typeof(Action<string>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 3);
				callback = (DelegateFactory.CreateDelegate(typeof(Action<string>), func) as Action<string>);
			}
			shareSDKManager.Login(platform, callback);
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
			ToLua.CheckArgsCount(L, 2);
			ShareSDKManager shareSDKManager = (ShareSDKManager)ToLua.CheckObject(L, 1, typeof(ShareSDKManager));
			int platform = (int)LuaDLL.luaL_checknumber(L, 2);
			shareSDKManager.Logout(platform);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetUserInfo(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			ShareSDKManager shareSDKManager = (ShareSDKManager)ToLua.CheckObject(L, 1, typeof(ShareSDKManager));
			int platform = (int)LuaDLL.luaL_checknumber(L, 2);
			LuaTypes luaTypes = LuaDLL.lua_type(L, 3);
			Action<string> callback;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				callback = (Action<string>)ToLua.CheckObject(L, 3, typeof(Action<string>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 3);
				callback = (DelegateFactory.CreateDelegate(typeof(Action<string>), func) as Action<string>);
			}
			shareSDKManager.GetUserInfo(platform, callback);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int BeginShareArg(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			ShareSDKManager shareSDKManager = (ShareSDKManager)ToLua.CheckObject(L, 1, typeof(ShareSDKManager));
			shareSDKManager.BeginShareArg();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AppendShareStringArg(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			ShareSDKManager shareSDKManager = (ShareSDKManager)ToLua.CheckObject(L, 1, typeof(ShareSDKManager));
			string appendFuncName = ToLua.CheckString(L, 2);
			string arg = ToLua.CheckString(L, 3);
			shareSDKManager.AppendShareStringArg(appendFuncName, arg);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AppendShareIntArg(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			ShareSDKManager shareSDKManager = (ShareSDKManager)ToLua.CheckObject(L, 1, typeof(ShareSDKManager));
			string appendFuncName = ToLua.CheckString(L, 2);
			int arg = (int)LuaDLL.luaL_checknumber(L, 3);
			shareSDKManager.AppendShareIntArg(appendFuncName, arg);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AppendShareFloatArg(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			ShareSDKManager shareSDKManager = (ShareSDKManager)ToLua.CheckObject(L, 1, typeof(ShareSDKManager));
			string appendFuncName = ToLua.CheckString(L, 2);
			float arg = (float)LuaDLL.luaL_checknumber(L, 3);
			shareSDKManager.AppendShareFloatArg(appendFuncName, arg);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int EndShareArg(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			ShareSDKManager shareSDKManager = (ShareSDKManager)ToLua.CheckObject(L, 1, typeof(ShareSDKManager));
			int platform = (int)LuaDLL.luaL_checknumber(L, 2);
			LuaTypes luaTypes = LuaDLL.lua_type(L, 3);
			Action<string> callback;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				callback = (Action<string>)ToLua.CheckObject(L, 3, typeof(Action<string>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 3);
				callback = (DelegateFactory.CreateDelegate(typeof(Action<string>), func) as Action<string>);
			}
			shareSDKManager.EndShareArg(platform, callback);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Share(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			ShareSDKManager shareSDKManager = (ShareSDKManager)ToLua.CheckObject(L, 1, typeof(ShareSDKManager));
			int platform = (int)LuaDLL.luaL_checknumber(L, 2);
			List<object> contents = (List<object>)ToLua.CheckObject(L, 3, typeof(List<object>));
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
			shareSDKManager.Share(platform, contents, callback);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Copy2SDpath(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			ShareSDKManager shareSDKManager = (ShareSDKManager)ToLua.CheckObject(L, 1, typeof(ShareSDKManager));
			Texture2D texture = (Texture2D)ToLua.CheckUnityObject(L, 2, typeof(Texture2D));
			string textureName = ToLua.CheckString(L, 3);
			bool replace = LuaDLL.luaL_checkboolean(L, 4);
			string str = shareSDKManager.Copy2SDpath(texture, textureName, replace);
			LuaDLL.lua_pushstring(L, str);
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
			ToLua.Push(L, ShareSDKManager.Instance);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_TimeOutPeriod(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ShareSDKManager shareSDKManager = (ShareSDKManager)obj;
			float timeOutPeriod = shareSDKManager.TimeOutPeriod;
			LuaDLL.lua_pushnumber(L, (double)timeOutPeriod);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index TimeOutPeriod on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_DisableSDKCallback(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ShareSDKManager shareSDKManager = (ShareSDKManager)obj;
			bool disableSDKCallback = shareSDKManager.DisableSDKCallback;
			LuaDLL.lua_pushboolean(L, disableSDKCallback);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index DisableSDKCallback on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Instance(IntPtr L)
	{
		int result;
		try
		{
			ShareSDKManager instance = (ShareSDKManager)ToLua.CheckUnityObject(L, 2, typeof(ShareSDKManager));
			ShareSDKManager.Instance = instance;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_TimeOutPeriod(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ShareSDKManager shareSDKManager = (ShareSDKManager)obj;
			float timeOutPeriod = (float)LuaDLL.luaL_checknumber(L, 2);
			shareSDKManager.TimeOutPeriod = timeOutPeriod;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index TimeOutPeriod on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_DisableSDKCallback(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ShareSDKManager shareSDKManager = (ShareSDKManager)obj;
			bool disableSDKCallback = LuaDLL.luaL_checkboolean(L, 2);
			shareSDKManager.DisableSDKCallback = disableSDKCallback;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index DisableSDKCallback on a nil value");
		}
		return result;
	}
}
