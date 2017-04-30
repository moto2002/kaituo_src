using Assets.Scripts.Game;
using LuaInterface;
using System;
using System.Collections.Generic;

public class Assets_Scripts_Game_ClientConfigWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(ClientConfig), typeof(object), null);
		L.RegFunction("GetField", new LuaCSFunction(Assets_Scripts_Game_ClientConfigWrap.GetField));
		L.RegFunction("AddField", new LuaCSFunction(Assets_Scripts_Game_ClientConfigWrap.AddField));
		L.RegFunction("Save", new LuaCSFunction(Assets_Scripts_Game_ClientConfigWrap.Save));
		L.RegFunction("GetVerStr", new LuaCSFunction(Assets_Scripts_Game_ClientConfigWrap.GetVerStr));
		L.RegFunction("New", new LuaCSFunction(Assets_Scripts_Game_ClientConfigWrap._CreateAssets_Scripts_Game_ClientConfig));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("Version", new LuaCSFunction(Assets_Scripts_Game_ClientConfigWrap.get_Version), new LuaCSFunction(Assets_Scripts_Game_ClientConfigWrap.set_Version));
		L.RegVar("Platform", new LuaCSFunction(Assets_Scripts_Game_ClientConfigWrap.get_Platform), new LuaCSFunction(Assets_Scripts_Game_ClientConfigWrap.set_Platform));
		L.RegVar("GameServerHost", new LuaCSFunction(Assets_Scripts_Game_ClientConfigWrap.get_GameServerHost), new LuaCSFunction(Assets_Scripts_Game_ClientConfigWrap.set_GameServerHost));
		L.RegVar("GameServerPort", new LuaCSFunction(Assets_Scripts_Game_ClientConfigWrap.get_GameServerPort), new LuaCSFunction(Assets_Scripts_Game_ClientConfigWrap.set_GameServerPort));
		L.RegVar("ResourcesUrl", new LuaCSFunction(Assets_Scripts_Game_ClientConfigWrap.get_ResourcesUrl), new LuaCSFunction(Assets_Scripts_Game_ClientConfigWrap.set_ResourcesUrl));
		L.RegVar("FieldNames", new LuaCSFunction(Assets_Scripts_Game_ClientConfigWrap.get_FieldNames), new LuaCSFunction(Assets_Scripts_Game_ClientConfigWrap.set_FieldNames));
		L.RegVar("FieldValues", new LuaCSFunction(Assets_Scripts_Game_ClientConfigWrap.get_FieldValues), new LuaCSFunction(Assets_Scripts_Game_ClientConfigWrap.set_FieldValues));
		L.RegVar("Instance", new LuaCSFunction(Assets_Scripts_Game_ClientConfigWrap.get_Instance), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateAssets_Scripts_Game_ClientConfig(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				ClientConfig o = new ClientConfig();
				ToLua.PushObject(L, o);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: Assets.Scripts.Game.ClientConfig.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetField(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			ClientConfig clientConfig = (ClientConfig)ToLua.CheckObject(L, 1, typeof(ClientConfig));
			string fieldName = ToLua.CheckString(L, 2);
			string field = clientConfig.GetField(fieldName);
			LuaDLL.lua_pushstring(L, field);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddField(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			ClientConfig clientConfig = (ClientConfig)ToLua.CheckObject(L, 1, typeof(ClientConfig));
			string fieldName = ToLua.CheckString(L, 2);
			string value = ToLua.CheckString(L, 3);
			clientConfig.AddField(fieldName, value);
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
			ClientConfig clientConfig = (ClientConfig)ToLua.CheckObject(L, 1, typeof(ClientConfig));
			clientConfig.Save();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetVerStr(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			int ver = (int)LuaDLL.luaL_checknumber(L, 1);
			string verStr = ClientConfig.GetVerStr(ver);
			LuaDLL.lua_pushstring(L, verStr);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Version(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ClientConfig clientConfig = (ClientConfig)obj;
			int version = clientConfig.Version;
			LuaDLL.lua_pushinteger(L, version);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Version on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Platform(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ClientConfig clientConfig = (ClientConfig)obj;
			int platform = clientConfig.Platform;
			LuaDLL.lua_pushinteger(L, platform);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Platform on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_GameServerHost(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ClientConfig clientConfig = (ClientConfig)obj;
			List<string> gameServerHost = clientConfig.GameServerHost;
			ToLua.PushObject(L, gameServerHost);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index GameServerHost on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_GameServerPort(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ClientConfig clientConfig = (ClientConfig)obj;
			List<string> gameServerPort = clientConfig.GameServerPort;
			ToLua.PushObject(L, gameServerPort);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index GameServerPort on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_ResourcesUrl(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ClientConfig clientConfig = (ClientConfig)obj;
			string resourcesUrl = clientConfig.ResourcesUrl;
			LuaDLL.lua_pushstring(L, resourcesUrl);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ResourcesUrl on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_FieldNames(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ClientConfig clientConfig = (ClientConfig)obj;
			List<string> fieldNames = clientConfig.FieldNames;
			ToLua.PushObject(L, fieldNames);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index FieldNames on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_FieldValues(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ClientConfig clientConfig = (ClientConfig)obj;
			List<string> fieldValues = clientConfig.FieldValues;
			ToLua.PushObject(L, fieldValues);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index FieldValues on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Instance(IntPtr L)
	{
		int result;
		try
		{
			ToLua.PushObject(L, ClientConfig.Instance);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Version(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ClientConfig clientConfig = (ClientConfig)obj;
			int version = (int)LuaDLL.luaL_checknumber(L, 2);
			clientConfig.Version = version;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Version on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Platform(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ClientConfig clientConfig = (ClientConfig)obj;
			int platform = (int)LuaDLL.luaL_checknumber(L, 2);
			clientConfig.Platform = platform;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Platform on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_GameServerHost(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ClientConfig clientConfig = (ClientConfig)obj;
			List<string> gameServerHost = (List<string>)ToLua.CheckObject(L, 2, typeof(List<string>));
			clientConfig.GameServerHost = gameServerHost;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index GameServerHost on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_GameServerPort(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ClientConfig clientConfig = (ClientConfig)obj;
			List<string> gameServerPort = (List<string>)ToLua.CheckObject(L, 2, typeof(List<string>));
			clientConfig.GameServerPort = gameServerPort;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index GameServerPort on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_ResourcesUrl(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ClientConfig clientConfig = (ClientConfig)obj;
			string resourcesUrl = ToLua.CheckString(L, 2);
			clientConfig.ResourcesUrl = resourcesUrl;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ResourcesUrl on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_FieldNames(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ClientConfig clientConfig = (ClientConfig)obj;
			List<string> fieldNames = (List<string>)ToLua.CheckObject(L, 2, typeof(List<string>));
			clientConfig.FieldNames = fieldNames;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index FieldNames on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_FieldValues(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ClientConfig clientConfig = (ClientConfig)obj;
			List<string> fieldValues = (List<string>)ToLua.CheckObject(L, 2, typeof(List<string>));
			clientConfig.FieldValues = fieldValues;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index FieldValues on a nil value");
		}
		return result;
	}
}
