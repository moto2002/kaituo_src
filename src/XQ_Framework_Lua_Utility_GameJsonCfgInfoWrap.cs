using LuaInterface;
using System;
using XQ.Framework.Lua.Utility;

public class XQ_Framework_Lua_Utility_GameJsonCfgInfoWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(GameJsonCfgInfo), null, null);
		L.RegFunction("New", new LuaCSFunction(XQ_Framework_Lua_Utility_GameJsonCfgInfoWrap._CreateXQ_Framework_Lua_Utility_GameJsonCfgInfo));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("Content", new LuaCSFunction(XQ_Framework_Lua_Utility_GameJsonCfgInfoWrap.get_Content), new LuaCSFunction(XQ_Framework_Lua_Utility_GameJsonCfgInfoWrap.set_Content));
		L.RegVar("LangContent", new LuaCSFunction(XQ_Framework_Lua_Utility_GameJsonCfgInfoWrap.get_LangContent), new LuaCSFunction(XQ_Framework_Lua_Utility_GameJsonCfgInfoWrap.set_LangContent));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateXQ_Framework_Lua_Utility_GameJsonCfgInfo(IntPtr L)
	{
		ToLua.PushValue(L, default(GameJsonCfgInfo));
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Content(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			string content = ((GameJsonCfgInfo)obj).Content;
			LuaDLL.lua_pushstring(L, content);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Content on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_LangContent(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			string langContent = ((GameJsonCfgInfo)obj).LangContent;
			LuaDLL.lua_pushstring(L, langContent);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index LangContent on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Content(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameJsonCfgInfo gameJsonCfgInfo = (GameJsonCfgInfo)obj;
			string content = ToLua.CheckString(L, 2);
			gameJsonCfgInfo.Content = content;
			ToLua.SetBack(L, 1, gameJsonCfgInfo);
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Content on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_LangContent(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameJsonCfgInfo gameJsonCfgInfo = (GameJsonCfgInfo)obj;
			string langContent = ToLua.CheckString(L, 2);
			gameJsonCfgInfo.LangContent = langContent;
			ToLua.SetBack(L, 1, gameJsonCfgInfo);
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index LangContent on a nil value");
		}
		return result;
	}
}
