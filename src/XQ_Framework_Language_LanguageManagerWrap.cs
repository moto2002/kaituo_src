using LuaInterface;
using System;
using System.Collections.Generic;
using XQ.Framework.Language;

public class XQ_Framework_Language_LanguageManagerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginStaticLibs("LanguageManager");
		L.RegFunction("IsChsLanguage", new LuaCSFunction(XQ_Framework_Language_LanguageManagerWrap.IsChsLanguage));
		L.RegFunction("SetLangKey", new LuaCSFunction(XQ_Framework_Language_LanguageManagerWrap.SetLangKey));
		L.RegFunction("GetLangKey", new LuaCSFunction(XQ_Framework_Language_LanguageManagerWrap.GetLangKey));
		L.RegFunction("GetLangText", new LuaCSFunction(XQ_Framework_Language_LanguageManagerWrap.GetLangText));
		L.RegVar("LanguageInfo", new LuaCSFunction(XQ_Framework_Language_LanguageManagerWrap.get_LanguageInfo), new LuaCSFunction(XQ_Framework_Language_LanguageManagerWrap.set_LanguageInfo));
		L.EndStaticLibs();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsChsLanguage(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string lang = ToLua.CheckString(L, 1);
			bool value = LanguageManager.IsChsLanguage(lang);
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
	private static int SetLangKey(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string langKey = ToLua.CheckString(L, 1);
			LanguageManager.SetLangKey(langKey);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetLangKey(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			string langKey = LanguageManager.GetLangKey();
			LuaDLL.lua_pushstring(L, langKey);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetLangText(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string textKey = ToLua.CheckString(L, 1);
			string langText = LanguageManager.GetLangText(textKey);
			LuaDLL.lua_pushstring(L, langText);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_LanguageInfo(IntPtr L)
	{
		int result;
		try
		{
			ToLua.PushObject(L, LanguageManager.LanguageInfo);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_LanguageInfo(IntPtr L)
	{
		int result;
		try
		{
			List<LangInfo> languageInfo = (List<LangInfo>)ToLua.CheckObject(L, 2, typeof(List<LangInfo>));
			LanguageManager.LanguageInfo = languageInfo;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
