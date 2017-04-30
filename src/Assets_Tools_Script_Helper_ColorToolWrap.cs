using Assets.Tools.Script.Helper;
using LuaInterface;
using System;
using UnityEngine;

public class Assets_Tools_Script_Helper_ColorToolWrap
{
	public static void Register(LuaState L)
	{
		L.BeginStaticLibs("ColorTool");
		L.RegFunction("SetBBCodeColor", new LuaCSFunction(Assets_Tools_Script_Helper_ColorToolWrap.SetBBCodeColor));
		L.RegFunction("GetRGBHexadecimal", new LuaCSFunction(Assets_Tools_Script_Helper_ColorToolWrap.GetRGBHexadecimal));
		L.RegFunction("GetColorFromRGBHexadecimal", new LuaCSFunction(Assets_Tools_Script_Helper_ColorToolWrap.GetColorFromRGBHexadecimal));
		L.RegVar("Golden", new LuaCSFunction(Assets_Tools_Script_Helper_ColorToolWrap.get_Golden), null);
		L.RegVar("GoldenStr", new LuaCSFunction(Assets_Tools_Script_Helper_ColorToolWrap.get_GoldenStr), null);
		L.EndStaticLibs();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetBBCodeColor(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(Color)))
			{
				string src = ToLua.ToString(L, 1);
				Color color = ToLua.ToColor(L, 2);
				string str = ColorTool.SetBBCodeColor(src, color);
				LuaDLL.lua_pushstring(L, str);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(string)))
			{
				string src2 = ToLua.ToString(L, 1);
				string color2 = ToLua.ToString(L, 2);
				string str2 = ColorTool.SetBBCodeColor(src2, color2);
				LuaDLL.lua_pushstring(L, str2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: Assets.Tools.Script.Helper.ColorTool.SetBBCodeColor");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetRGBHexadecimal(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(Color)))
			{
				Color color = ToLua.ToColor(L, 1);
				string rGBHexadecimal = color.GetRGBHexadecimal();
				LuaDLL.lua_pushstring(L, rGBHexadecimal);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(float), typeof(float), typeof(float), typeof(float)))
			{
				float r = (float)LuaDLL.lua_tonumber(L, 1);
				float g = (float)LuaDLL.lua_tonumber(L, 2);
				float b = (float)LuaDLL.lua_tonumber(L, 3);
				float a = (float)LuaDLL.lua_tonumber(L, 4);
				string rGBHexadecimal2 = ColorTool.GetRGBHexadecimal(r, g, b, a);
				LuaDLL.lua_pushstring(L, rGBHexadecimal2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: Assets.Tools.Script.Helper.ColorTool.GetRGBHexadecimal");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetColorFromRGBHexadecimal(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string colorStr = ToLua.CheckString(L, 1);
			Color colorFromRGBHexadecimal = ColorTool.GetColorFromRGBHexadecimal(colorStr);
			ToLua.Push(L, colorFromRGBHexadecimal);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Golden(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, ColorTool.Golden);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_GoldenStr(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushstring(L, ColorTool.GoldenStr);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
