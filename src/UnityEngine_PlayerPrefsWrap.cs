using LuaInterface;
using System;
using UnityEngine;

public class UnityEngine_PlayerPrefsWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(PlayerPrefs), typeof(object), null);
		L.RegFunction("SetInt", new LuaCSFunction(UnityEngine_PlayerPrefsWrap.SetInt));
		L.RegFunction("GetInt", new LuaCSFunction(UnityEngine_PlayerPrefsWrap.GetInt));
		L.RegFunction("SetFloat", new LuaCSFunction(UnityEngine_PlayerPrefsWrap.SetFloat));
		L.RegFunction("GetFloat", new LuaCSFunction(UnityEngine_PlayerPrefsWrap.GetFloat));
		L.RegFunction("SetString", new LuaCSFunction(UnityEngine_PlayerPrefsWrap.SetString));
		L.RegFunction("GetString", new LuaCSFunction(UnityEngine_PlayerPrefsWrap.GetString));
		L.RegFunction("HasKey", new LuaCSFunction(UnityEngine_PlayerPrefsWrap.HasKey));
		L.RegFunction("DeleteKey", new LuaCSFunction(UnityEngine_PlayerPrefsWrap.DeleteKey));
		L.RegFunction("DeleteAll", new LuaCSFunction(UnityEngine_PlayerPrefsWrap.DeleteAll));
		L.RegFunction("Save", new LuaCSFunction(UnityEngine_PlayerPrefsWrap.Save));
		L.RegFunction("New", new LuaCSFunction(UnityEngine_PlayerPrefsWrap._CreateUnityEngine_PlayerPrefs));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateUnityEngine_PlayerPrefs(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				PlayerPrefs o = new PlayerPrefs();
				ToLua.PushObject(L, o);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: UnityEngine.PlayerPrefs.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetInt(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			string key = ToLua.CheckString(L, 1);
			int value = (int)LuaDLL.luaL_checknumber(L, 2);
			PlayerPrefs.SetInt(key, value);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetInt(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(string)))
			{
				string key = ToLua.ToString(L, 1);
				int @int = PlayerPrefs.GetInt(key);
				LuaDLL.lua_pushinteger(L, @int);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(int)))
			{
				string key2 = ToLua.ToString(L, 1);
				int defaultValue = (int)LuaDLL.lua_tonumber(L, 2);
				int int2 = PlayerPrefs.GetInt(key2, defaultValue);
				LuaDLL.lua_pushinteger(L, int2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.PlayerPrefs.GetInt");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetFloat(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			string key = ToLua.CheckString(L, 1);
			float value = (float)LuaDLL.luaL_checknumber(L, 2);
			PlayerPrefs.SetFloat(key, value);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetFloat(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(string)))
			{
				string key = ToLua.ToString(L, 1);
				float @float = PlayerPrefs.GetFloat(key);
				LuaDLL.lua_pushnumber(L, (double)@float);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(float)))
			{
				string key2 = ToLua.ToString(L, 1);
				float defaultValue = (float)LuaDLL.lua_tonumber(L, 2);
				float float2 = PlayerPrefs.GetFloat(key2, defaultValue);
				LuaDLL.lua_pushnumber(L, (double)float2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.PlayerPrefs.GetFloat");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetString(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			string key = ToLua.CheckString(L, 1);
			string value = ToLua.CheckString(L, 2);
			PlayerPrefs.SetString(key, value);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetString(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(string)))
			{
				string key = ToLua.ToString(L, 1);
				string @string = PlayerPrefs.GetString(key);
				LuaDLL.lua_pushstring(L, @string);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(string)))
			{
				string key2 = ToLua.ToString(L, 1);
				string defaultValue = ToLua.ToString(L, 2);
				string string2 = PlayerPrefs.GetString(key2, defaultValue);
				LuaDLL.lua_pushstring(L, string2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.PlayerPrefs.GetString");
			}
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
			ToLua.CheckArgsCount(L, 1);
			string key = ToLua.CheckString(L, 1);
			bool value = PlayerPrefs.HasKey(key);
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
	private static int DeleteKey(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string key = ToLua.CheckString(L, 1);
			PlayerPrefs.DeleteKey(key);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DeleteAll(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			PlayerPrefs.DeleteAll();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Save(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			PlayerPrefs.Save();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
