using LuaInterface;
using System;
using UnityEngine;

public class UnityEngine_FontStyleWrap
{
	public static void Register(LuaState L)
	{
		L.BeginEnum(typeof(FontStyle));
		L.RegVar("Normal", new LuaCSFunction(UnityEngine_FontStyleWrap.get_Normal), null);
		L.RegVar("Bold", new LuaCSFunction(UnityEngine_FontStyleWrap.get_Bold), null);
		L.RegVar("Italic", new LuaCSFunction(UnityEngine_FontStyleWrap.get_Italic), null);
		L.RegVar("BoldAndItalic", new LuaCSFunction(UnityEngine_FontStyleWrap.get_BoldAndItalic), null);
		L.RegFunction("IntToEnum", new LuaCSFunction(UnityEngine_FontStyleWrap.IntToEnum));
		L.EndEnum();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Normal(IntPtr L)
	{
		ToLua.Push(L, FontStyle.Normal);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Bold(IntPtr L)
	{
		ToLua.Push(L, FontStyle.Bold);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Italic(IntPtr L)
	{
		ToLua.Push(L, FontStyle.Italic);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_BoldAndItalic(IntPtr L)
	{
		ToLua.Push(L, FontStyle.BoldAndItalic);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IntToEnum(IntPtr L)
	{
		int num = (int)LuaDLL.lua_tonumber(L, 1);
		FontStyle fontStyle = (FontStyle)num;
		ToLua.Push(L, fontStyle);
		return 1;
	}
}
