using LuaInterface;
using System;
using XQ.Game.Util.Unity;

public class XQ_Game_Util_Unity_WordFilterWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(WordFilter), typeof(object), null);
		L.RegFunction("Init", new LuaCSFunction(XQ_Game_Util_Unity_WordFilterWrap.Init));
		L.RegFunction("HandleKeyWords", new LuaCSFunction(XQ_Game_Util_Unity_WordFilterWrap.HandleKeyWords));
		L.RegFunction("Filter", new LuaCSFunction(XQ_Game_Util_Unity_WordFilterWrap.Filter));
		L.RegFunction("Verify", new LuaCSFunction(XQ_Game_Util_Unity_WordFilterWrap.Verify));
		L.RegFunction("AccountPunctuationVerify", new LuaCSFunction(XQ_Game_Util_Unity_WordFilterWrap.AccountPunctuationVerify));
		L.RegFunction("RegexVerify", new LuaCSFunction(XQ_Game_Util_Unity_WordFilterWrap.RegexVerify));
		L.RegFunction("New", new LuaCSFunction(XQ_Game_Util_Unity_WordFilterWrap._CreateXQ_Game_Util_Unity_WordFilter));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateXQ_Game_Util_Unity_WordFilter(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				WordFilter o = new WordFilter();
				ToLua.PushObject(L, o);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: XQ.Game.Util.Unity.WordFilter.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Init(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			WordFilter.Init();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int HandleKeyWords(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			string text = ToLua.CheckString(L, 1);
			char separator = (char)LuaDLL.luaL_checknumber(L, 2);
			WordFilter.HandleKeyWords(text, separator);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Filter(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string str = ToLua.CheckString(L, 1);
			string str2 = WordFilter.Filter(str);
			LuaDLL.lua_pushstring(L, str2);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Verify(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string str = ToLua.CheckString(L, 1);
			bool value = WordFilter.Verify(str);
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
	private static int AccountPunctuationVerify(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string str = ToLua.CheckString(L, 1);
			bool value = WordFilter.AccountPunctuationVerify(str);
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
	private static int RegexVerify(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			string str = ToLua.CheckString(L, 1);
			string pattern = ToLua.CheckString(L, 2);
			bool value = WordFilter.RegexVerify(str, pattern);
			LuaDLL.lua_pushboolean(L, value);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
