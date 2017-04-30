using LuaInterface;
using System;
using XQ.Framework.Language;

public class XQ_Framework_Language_LangInfoWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(LangInfo), null, null);
		L.RegFunction("New", new LuaCSFunction(XQ_Framework_Language_LangInfoWrap._CreateXQ_Framework_Language_LangInfo));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("LangKey", new LuaCSFunction(XQ_Framework_Language_LangInfoWrap.get_LangKey), new LuaCSFunction(XQ_Framework_Language_LangInfoWrap.set_LangKey));
		L.RegVar("LangValue", new LuaCSFunction(XQ_Framework_Language_LangInfoWrap.get_LangValue), new LuaCSFunction(XQ_Framework_Language_LangInfoWrap.set_LangValue));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateXQ_Framework_Language_LangInfo(IntPtr L)
	{
		ToLua.PushValue(L, default(LangInfo));
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_LangKey(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			string langKey = ((LangInfo)obj).LangKey;
			LuaDLL.lua_pushstring(L, langKey);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index LangKey on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_LangValue(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			string langValue = ((LangInfo)obj).LangValue;
			LuaDLL.lua_pushstring(L, langValue);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index LangValue on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_LangKey(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LangInfo langInfo = (LangInfo)obj;
			string langKey = ToLua.CheckString(L, 2);
			langInfo.LangKey = langKey;
			ToLua.SetBack(L, 1, langInfo);
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index LangKey on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_LangValue(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LangInfo langInfo = (LangInfo)obj;
			string langValue = ToLua.CheckString(L, 2);
			langInfo.LangValue = langValue;
			ToLua.SetBack(L, 1, langInfo);
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index LangValue on a nil value");
		}
		return result;
	}
}
