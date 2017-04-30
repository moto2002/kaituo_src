using Assets.Tools.Script.Serialized.LocalCache;
using LuaInterface;
using System;
using System.Collections.Generic;

public class Assets_Tools_Script_Serialized_LocalCache_PlayerPrefsCacheWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(PlayerPrefsCache), typeof(object), null);
		L.RegFunction("SetString", new LuaCSFunction(Assets_Tools_Script_Serialized_LocalCache_PlayerPrefsCacheWrap.SetString));
		L.RegFunction("GetString", new LuaCSFunction(Assets_Tools_Script_Serialized_LocalCache_PlayerPrefsCacheWrap.GetString));
		L.RegFunction("DeleteKey", new LuaCSFunction(Assets_Tools_Script_Serialized_LocalCache_PlayerPrefsCacheWrap.DeleteKey));
		L.RegFunction("GetAllString", new LuaCSFunction(Assets_Tools_Script_Serialized_LocalCache_PlayerPrefsCacheWrap.GetAllString));
		L.RegFunction("GetAllKV", new LuaCSFunction(Assets_Tools_Script_Serialized_LocalCache_PlayerPrefsCacheWrap.GetAllKV));
		L.RegFunction("GetAllKVToLuaTable", new LuaCSFunction(Assets_Tools_Script_Serialized_LocalCache_PlayerPrefsCacheWrap.GetAllKVToLuaTable));
		L.RegFunction("Clear", new LuaCSFunction(Assets_Tools_Script_Serialized_LocalCache_PlayerPrefsCacheWrap.Clear));
		L.RegFunction("Save", new LuaCSFunction(Assets_Tools_Script_Serialized_LocalCache_PlayerPrefsCacheWrap.Save));
		L.RegFunction("DefragSave", new LuaCSFunction(Assets_Tools_Script_Serialized_LocalCache_PlayerPrefsCacheWrap.DefragSave));
		L.RegFunction("Reload", new LuaCSFunction(Assets_Tools_Script_Serialized_LocalCache_PlayerPrefsCacheWrap.Reload));
		L.RegFunction("New", new LuaCSFunction(Assets_Tools_Script_Serialized_LocalCache_PlayerPrefsCacheWrap._CreateAssets_Tools_Script_Serialized_LocalCache_PlayerPrefsCache));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("MaxFragmentLength", new LuaCSFunction(Assets_Tools_Script_Serialized_LocalCache_PlayerPrefsCacheWrap.get_MaxFragmentLength), new LuaCSFunction(Assets_Tools_Script_Serialized_LocalCache_PlayerPrefsCacheWrap.set_MaxFragmentLength));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateAssets_Tools_Script_Serialized_LocalCache_PlayerPrefsCache(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1)
			{
				string name = ToLua.CheckString(L, 1);
				PlayerPrefsCache o = new PlayerPrefsCache(name);
				ToLua.PushObject(L, o);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(int), typeof(bool)))
			{
				string name2 = ToLua.CheckString(L, 1);
				int maxFragmentLength = (int)LuaDLL.luaL_checknumber(L, 2);
				bool holdStreamWriter = LuaDLL.luaL_checkboolean(L, 3);
				PlayerPrefsCache o2 = new PlayerPrefsCache(name2, maxFragmentLength, holdStreamWriter);
				ToLua.PushObject(L, o2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: Assets.Tools.Script.Serialized.LocalCache.PlayerPrefsCache.New");
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
			ToLua.CheckArgsCount(L, 3);
			PlayerPrefsCache playerPrefsCache = (PlayerPrefsCache)ToLua.CheckObject(L, 1, typeof(PlayerPrefsCache));
			string key = ToLua.CheckString(L, 2);
			string value = ToLua.CheckString(L, 3);
			playerPrefsCache.SetString(key, value);
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
			ToLua.CheckArgsCount(L, 2);
			PlayerPrefsCache playerPrefsCache = (PlayerPrefsCache)ToLua.CheckObject(L, 1, typeof(PlayerPrefsCache));
			string key = ToLua.CheckString(L, 2);
			string @string = playerPrefsCache.GetString(key);
			LuaDLL.lua_pushstring(L, @string);
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
			ToLua.CheckArgsCount(L, 2);
			PlayerPrefsCache playerPrefsCache = (PlayerPrefsCache)ToLua.CheckObject(L, 1, typeof(PlayerPrefsCache));
			string key = ToLua.CheckString(L, 2);
			playerPrefsCache.DeleteKey(key);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetAllString(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			PlayerPrefsCache playerPrefsCache = (PlayerPrefsCache)ToLua.CheckObject(L, 1, typeof(PlayerPrefsCache));
			List<string> allString = playerPrefsCache.GetAllString();
			ToLua.PushObject(L, allString);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetAllKV(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			PlayerPrefsCache playerPrefsCache = (PlayerPrefsCache)ToLua.CheckObject(L, 1, typeof(PlayerPrefsCache));
			Dictionary<string, string> allKV = playerPrefsCache.GetAllKV();
			ToLua.PushObject(L, allKV);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetAllKVToLuaTable(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			PlayerPrefsCache playerPrefsCache = (PlayerPrefsCache)ToLua.CheckObject(L, 1, typeof(PlayerPrefsCache));
			LuaTable table = ToLua.CheckLuaTable(L, 2);
			playerPrefsCache.GetAllKVToLuaTable(table);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Clear(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			PlayerPrefsCache playerPrefsCache = (PlayerPrefsCache)ToLua.CheckObject(L, 1, typeof(PlayerPrefsCache));
			playerPrefsCache.Clear();
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
			ToLua.CheckArgsCount(L, 1);
			PlayerPrefsCache playerPrefsCache = (PlayerPrefsCache)ToLua.CheckObject(L, 1, typeof(PlayerPrefsCache));
			playerPrefsCache.Save();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DefragSave(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			PlayerPrefsCache playerPrefsCache = (PlayerPrefsCache)ToLua.CheckObject(L, 1, typeof(PlayerPrefsCache));
			playerPrefsCache.DefragSave();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Reload(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			PlayerPrefsCache playerPrefsCache = (PlayerPrefsCache)ToLua.CheckObject(L, 1, typeof(PlayerPrefsCache));
			playerPrefsCache.Reload();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_MaxFragmentLength(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			PlayerPrefsCache playerPrefsCache = (PlayerPrefsCache)obj;
			int maxFragmentLength = playerPrefsCache.MaxFragmentLength;
			LuaDLL.lua_pushinteger(L, maxFragmentLength);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index MaxFragmentLength on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_MaxFragmentLength(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			PlayerPrefsCache playerPrefsCache = (PlayerPrefsCache)obj;
			int maxFragmentLength = (int)LuaDLL.luaL_checknumber(L, 2);
			playerPrefsCache.MaxFragmentLength = maxFragmentLength;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index MaxFragmentLength on a nil value");
		}
		return result;
	}
}
