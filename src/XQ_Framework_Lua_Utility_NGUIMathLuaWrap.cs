using LuaInterface;
using System;
using UnityEngine;
using XQ.Framework.Lua.Utility;

public class XQ_Framework_Lua_Utility_NGUIMathLuaWrap
{
	public static void Register(LuaState L)
	{
		L.BeginStaticLibs("NGUIMathLua");
		L.RegFunction("Lerp", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIMathLuaWrap.Lerp));
		L.RegFunction("ClampIndex", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIMathLuaWrap.ClampIndex));
		L.RegFunction("RepeatIndex", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIMathLuaWrap.RepeatIndex));
		L.RegFunction("WrapAngle", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIMathLuaWrap.WrapAngle));
		L.RegFunction("Wrap01", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIMathLuaWrap.Wrap01));
		L.RegFunction("HexToDecimal", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIMathLuaWrap.HexToDecimal));
		L.RegFunction("DecimalToHexChar", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIMathLuaWrap.DecimalToHexChar));
		L.RegFunction("DecimalToHex8", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIMathLuaWrap.DecimalToHex8));
		L.RegFunction("DecimalToHex24", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIMathLuaWrap.DecimalToHex24));
		L.RegFunction("DecimalToHex32", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIMathLuaWrap.DecimalToHex32));
		L.RegFunction("ColorToInt", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIMathLuaWrap.ColorToInt));
		L.RegFunction("IntToColor", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIMathLuaWrap.IntToColor));
		L.RegFunction("IntToBinary", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIMathLuaWrap.IntToBinary));
		L.RegFunction("HexToColor", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIMathLuaWrap.HexToColor));
		L.RegFunction("ConvertToTexCoords", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIMathLuaWrap.ConvertToTexCoords));
		L.RegFunction("ConvertToPixels", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIMathLuaWrap.ConvertToPixels));
		L.RegFunction("MakePixelPerfect", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIMathLuaWrap.MakePixelPerfect));
		L.RegFunction("ConstrainRect", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIMathLuaWrap.ConstrainRect));
		L.RegFunction("CalculateAbsoluteWidgetBounds", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIMathLuaWrap.CalculateAbsoluteWidgetBounds));
		L.RegFunction("CalculateRelativeWidgetBounds", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIMathLuaWrap.CalculateRelativeWidgetBounds));
		L.RegFunction("SpringDampen", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIMathLuaWrap.SpringDampen));
		L.RegFunction("SpringLerp", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIMathLuaWrap.SpringLerp));
		L.RegFunction("RotateTowards", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIMathLuaWrap.RotateTowards));
		L.RegFunction("DistanceToRectangle", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIMathLuaWrap.DistanceToRectangle));
		L.RegFunction("GetPivotOffset", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIMathLuaWrap.GetPivotOffset));
		L.RegFunction("GetPivot", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIMathLuaWrap.GetPivot));
		L.RegFunction("MoveWidget", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIMathLuaWrap.MoveWidget));
		L.RegFunction("MoveRect", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIMathLuaWrap.MoveRect));
		L.RegFunction("ResizeWidget", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIMathLuaWrap.ResizeWidget));
		L.RegFunction("AdjustWidget", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIMathLuaWrap.AdjustWidget));
		L.RegFunction("AdjustByDPI", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIMathLuaWrap.AdjustByDPI));
		L.RegFunction("ScreenToPixels", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIMathLuaWrap.ScreenToPixels));
		L.RegFunction("ScreenToParentPixels", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIMathLuaWrap.ScreenToParentPixels));
		L.RegFunction("WorldToLocalPoint", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIMathLuaWrap.WorldToLocalPoint));
		L.RegFunction("OverlayPosition", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIMathLuaWrap.OverlayPosition));
		L.EndStaticLibs();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Lerp(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			float from = (float)LuaDLL.luaL_checknumber(L, 1);
			float to = (float)LuaDLL.luaL_checknumber(L, 2);
			float factor = (float)LuaDLL.luaL_checknumber(L, 3);
			float num = NGUIMathLua.Lerp(from, to, factor);
			LuaDLL.lua_pushnumber(L, (double)num);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ClampIndex(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			int val = (int)LuaDLL.luaL_checknumber(L, 1);
			int max = (int)LuaDLL.luaL_checknumber(L, 2);
			int n = NGUIMathLua.ClampIndex(val, max);
			LuaDLL.lua_pushinteger(L, n);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RepeatIndex(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			int val = (int)LuaDLL.luaL_checknumber(L, 1);
			int max = (int)LuaDLL.luaL_checknumber(L, 2);
			int n = NGUIMathLua.RepeatIndex(val, max);
			LuaDLL.lua_pushinteger(L, n);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int WrapAngle(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			float angle = (float)LuaDLL.luaL_checknumber(L, 1);
			float num = NGUIMathLua.WrapAngle(angle);
			LuaDLL.lua_pushnumber(L, (double)num);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Wrap01(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			float val = (float)LuaDLL.luaL_checknumber(L, 1);
			float num = NGUIMathLua.Wrap01(val);
			LuaDLL.lua_pushnumber(L, (double)num);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int HexToDecimal(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			char ch = (char)LuaDLL.luaL_checknumber(L, 1);
			int n = NGUIMathLua.HexToDecimal(ch);
			LuaDLL.lua_pushinteger(L, n);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DecimalToHexChar(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			int num = (int)LuaDLL.luaL_checknumber(L, 1);
			char c = NGUIMathLua.DecimalToHexChar(num);
			LuaDLL.lua_pushnumber(L, (double)c);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DecimalToHex8(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			int num = (int)LuaDLL.luaL_checknumber(L, 1);
			string str = NGUIMathLua.DecimalToHex8(num);
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
	private static int DecimalToHex24(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			int num = (int)LuaDLL.luaL_checknumber(L, 1);
			string str = NGUIMathLua.DecimalToHex24(num);
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
	private static int DecimalToHex32(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			int num = (int)LuaDLL.luaL_checknumber(L, 1);
			string str = NGUIMathLua.DecimalToHex32(num);
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
	private static int ColorToInt(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Color c = ToLua.ToColor(L, 1);
			int n = NGUIMathLua.ColorToInt(c);
			LuaDLL.lua_pushinteger(L, n);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IntToColor(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			int val = (int)LuaDLL.luaL_checknumber(L, 1);
			Color clr = NGUIMathLua.IntToColor(val);
			ToLua.Push(L, clr);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IntToBinary(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			int val = (int)LuaDLL.luaL_checknumber(L, 1);
			int bits = (int)LuaDLL.luaL_checknumber(L, 2);
			string str = NGUIMathLua.IntToBinary(val, bits);
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
	private static int HexToColor(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			uint val = (uint)LuaDLL.luaL_checknumber(L, 1);
			Color clr = NGUIMathLua.HexToColor(val);
			ToLua.Push(L, clr);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ConvertToTexCoords(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Rect rect = (Rect)ToLua.CheckObject(L, 1, typeof(Rect));
			int width = (int)LuaDLL.luaL_checknumber(L, 2);
			int height = (int)LuaDLL.luaL_checknumber(L, 3);
			Rect rect2 = NGUIMathLua.ConvertToTexCoords(rect, width, height);
			ToLua.PushValue(L, rect2);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ConvertToPixels(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			Rect rect = (Rect)ToLua.CheckObject(L, 1, typeof(Rect));
			int width = (int)LuaDLL.luaL_checknumber(L, 2);
			int height = (int)LuaDLL.luaL_checknumber(L, 3);
			bool round = LuaDLL.luaL_checkboolean(L, 4);
			Rect rect2 = NGUIMathLua.ConvertToPixels(rect, width, height, round);
			ToLua.PushValue(L, rect2);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int MakePixelPerfect(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(Rect)))
			{
				Rect rect = (Rect)ToLua.ToObject(L, 1);
				Rect rect2 = NGUIMathLua.MakePixelPerfect(rect);
				ToLua.PushValue(L, rect2);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Rect), typeof(int), typeof(int)))
			{
				Rect rect3 = (Rect)ToLua.ToObject(L, 1);
				int width = (int)LuaDLL.lua_tonumber(L, 2);
				int height = (int)LuaDLL.lua_tonumber(L, 3);
				Rect rect4 = NGUIMathLua.MakePixelPerfect(rect3, width, height);
				ToLua.PushValue(L, rect4);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: XQ.Framework.Lua.Utility.NGUIMathLua.MakePixelPerfect");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ConstrainRect(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			Vector2 minRect = ToLua.ToVector2(L, 1);
			Vector2 maxRect = ToLua.ToVector2(L, 2);
			Vector2 minArea = ToLua.ToVector2(L, 3);
			Vector2 maxArea = ToLua.ToVector2(L, 4);
			Vector2 v = NGUIMathLua.ConstrainRect(minRect, maxRect, minArea, maxArea);
			ToLua.Push(L, v);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CalculateAbsoluteWidgetBounds(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Transform trans = (Transform)ToLua.CheckUnityObject(L, 1, typeof(Transform));
			Bounds bound = NGUIMathLua.CalculateAbsoluteWidgetBounds(trans);
			ToLua.Push(L, bound);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CalculateRelativeWidgetBounds(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(Transform)))
			{
				Transform trans = (Transform)ToLua.ToObject(L, 1);
				Bounds bound = NGUIMathLua.CalculateRelativeWidgetBounds(trans);
				ToLua.Push(L, bound);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Transform), typeof(Transform)))
			{
				Transform relativeTo = (Transform)ToLua.ToObject(L, 1);
				Transform content = (Transform)ToLua.ToObject(L, 2);
				Bounds bound2 = NGUIMathLua.CalculateRelativeWidgetBounds(relativeTo, content);
				ToLua.Push(L, bound2);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Transform), typeof(bool)))
			{
				Transform trans2 = (Transform)ToLua.ToObject(L, 1);
				bool considerInactive = LuaDLL.lua_toboolean(L, 2);
				Bounds bound3 = NGUIMathLua.CalculateRelativeWidgetBounds(trans2, considerInactive);
				ToLua.Push(L, bound3);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Transform), typeof(Transform), typeof(bool), typeof(bool)))
			{
				Transform relativeTo2 = (Transform)ToLua.ToObject(L, 1);
				Transform content2 = (Transform)ToLua.ToObject(L, 2);
				bool considerInactive2 = LuaDLL.lua_toboolean(L, 3);
				bool considerChildren = LuaDLL.lua_toboolean(L, 4);
				Bounds bound4 = NGUIMathLua.CalculateRelativeWidgetBounds(relativeTo2, content2, considerInactive2, considerChildren);
				ToLua.Push(L, bound4);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: XQ.Framework.Lua.Utility.NGUIMathLua.CalculateRelativeWidgetBounds");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SpringDampen(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Vector2), typeof(float), typeof(float)))
			{
				Vector2 v = ToLua.ToVector2(L, 1);
				float strength = (float)LuaDLL.lua_tonumber(L, 2);
				float deltaTime = (float)LuaDLL.lua_tonumber(L, 3);
				Vector2 v2 = NGUIMathLua.SpringDampen(ref v, strength, deltaTime);
				ToLua.Push(L, v2);
				ToLua.Push(L, v);
				result = 2;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(float), typeof(float)))
			{
				Vector3 v3 = ToLua.ToVector3(L, 1);
				float strength2 = (float)LuaDLL.lua_tonumber(L, 2);
				float deltaTime2 = (float)LuaDLL.lua_tonumber(L, 3);
				Vector3 v4 = NGUIMathLua.SpringDampen(ref v3, strength2, deltaTime2);
				ToLua.Push(L, v4);
				ToLua.Push(L, v3);
				result = 2;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: XQ.Framework.Lua.Utility.NGUIMathLua.SpringDampen");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SpringLerp(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(float), typeof(float)))
			{
				float strength = (float)LuaDLL.lua_tonumber(L, 1);
				float deltaTime = (float)LuaDLL.lua_tonumber(L, 2);
				float num2 = NGUIMathLua.SpringLerp(strength, deltaTime);
				LuaDLL.lua_pushnumber(L, (double)num2);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(float), typeof(float)))
			{
				Vector3 from = ToLua.ToVector3(L, 1);
				Vector3 to = ToLua.ToVector3(L, 2);
				float strength2 = (float)LuaDLL.lua_tonumber(L, 3);
				float deltaTime2 = (float)LuaDLL.lua_tonumber(L, 4);
				Vector3 v = NGUIMathLua.SpringLerp(from, to, strength2, deltaTime2);
				ToLua.Push(L, v);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Quaternion), typeof(Quaternion), typeof(float), typeof(float)))
			{
				Quaternion from2 = ToLua.ToQuaternion(L, 1);
				Quaternion to2 = ToLua.ToQuaternion(L, 2);
				float strength3 = (float)LuaDLL.lua_tonumber(L, 3);
				float deltaTime3 = (float)LuaDLL.lua_tonumber(L, 4);
				Quaternion q = NGUIMathLua.SpringLerp(from2, to2, strength3, deltaTime3);
				ToLua.Push(L, q);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(float), typeof(float), typeof(float), typeof(float)))
			{
				float from3 = (float)LuaDLL.lua_tonumber(L, 1);
				float to3 = (float)LuaDLL.lua_tonumber(L, 2);
				float strength4 = (float)LuaDLL.lua_tonumber(L, 3);
				float deltaTime4 = (float)LuaDLL.lua_tonumber(L, 4);
				float num3 = NGUIMathLua.SpringLerp(from3, to3, strength4, deltaTime4);
				LuaDLL.lua_pushnumber(L, (double)num3);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Vector2), typeof(Vector2), typeof(float), typeof(float)))
			{
				Vector2 from4 = ToLua.ToVector2(L, 1);
				Vector2 to4 = ToLua.ToVector2(L, 2);
				float strength5 = (float)LuaDLL.lua_tonumber(L, 3);
				float deltaTime5 = (float)LuaDLL.lua_tonumber(L, 4);
				Vector2 v2 = NGUIMathLua.SpringLerp(from4, to4, strength5, deltaTime5);
				ToLua.Push(L, v2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: XQ.Framework.Lua.Utility.NGUIMathLua.SpringLerp");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RotateTowards(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			float from = (float)LuaDLL.luaL_checknumber(L, 1);
			float to = (float)LuaDLL.luaL_checknumber(L, 2);
			float maxAngle = (float)LuaDLL.luaL_checknumber(L, 3);
			float num = NGUIMathLua.RotateTowards(from, to, maxAngle);
			LuaDLL.lua_pushnumber(L, (double)num);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DistanceToRectangle(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Vector2[]), typeof(Vector2)))
			{
				Vector2[] screenPoints = ToLua.CheckObjectArray<Vector2>(L, 1);
				Vector2 mousePos = ToLua.ToVector2(L, 2);
				float num2 = NGUIMathLua.DistanceToRectangle(screenPoints, mousePos);
				LuaDLL.lua_pushnumber(L, (double)num2);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Vector3[]), typeof(Vector2), typeof(Camera)))
			{
				Vector3[] worldPoints = ToLua.CheckObjectArray<Vector3>(L, 1);
				Vector2 mousePos2 = ToLua.ToVector2(L, 2);
				Camera cam = (Camera)ToLua.ToObject(L, 3);
				float num3 = NGUIMathLua.DistanceToRectangle(worldPoints, mousePos2, cam);
				LuaDLL.lua_pushnumber(L, (double)num3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: XQ.Framework.Lua.Utility.NGUIMathLua.DistanceToRectangle");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetPivotOffset(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIWidget.Pivot pv = (UIWidget.Pivot)((int)ToLua.CheckObject(L, 1, typeof(UIWidget.Pivot)));
			Vector2 pivotOffset = NGUIMathLua.GetPivotOffset(pv);
			ToLua.Push(L, pivotOffset);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetPivot(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Vector2 offset = ToLua.ToVector2(L, 1);
			UIWidget.Pivot pivot = NGUIMathLua.GetPivot(offset);
			ToLua.Push(L, pivot);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int MoveWidget(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			UIRect w = (UIRect)ToLua.CheckUnityObject(L, 1, typeof(UIRect));
			float x = (float)LuaDLL.luaL_checknumber(L, 2);
			float y = (float)LuaDLL.luaL_checknumber(L, 3);
			NGUIMathLua.MoveWidget(w, x, y);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int MoveRect(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			UIRect rect = (UIRect)ToLua.CheckUnityObject(L, 1, typeof(UIRect));
			float x = (float)LuaDLL.luaL_checknumber(L, 2);
			float y = (float)LuaDLL.luaL_checknumber(L, 3);
			NGUIMathLua.MoveRect(rect, x, y);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ResizeWidget(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 6 && TypeChecker.CheckTypes(L, 1, typeof(UIWidget), typeof(UIWidget.Pivot), typeof(float), typeof(float), typeof(int), typeof(int)))
			{
				UIWidget w = (UIWidget)ToLua.ToObject(L, 1);
				UIWidget.Pivot pivot = (UIWidget.Pivot)((int)ToLua.ToObject(L, 2));
				float x = (float)LuaDLL.lua_tonumber(L, 3);
				float y = (float)LuaDLL.lua_tonumber(L, 4);
				int minWidth = (int)LuaDLL.lua_tonumber(L, 5);
				int minHeight = (int)LuaDLL.lua_tonumber(L, 6);
				NGUIMathLua.ResizeWidget(w, pivot, x, y, minWidth, minHeight);
				result = 0;
			}
			else if (num == 8 && TypeChecker.CheckTypes(L, 1, typeof(UIWidget), typeof(UIWidget.Pivot), typeof(float), typeof(float), typeof(int), typeof(int), typeof(int), typeof(int)))
			{
				UIWidget w2 = (UIWidget)ToLua.ToObject(L, 1);
				UIWidget.Pivot pivot2 = (UIWidget.Pivot)((int)ToLua.ToObject(L, 2));
				float x2 = (float)LuaDLL.lua_tonumber(L, 3);
				float y2 = (float)LuaDLL.lua_tonumber(L, 4);
				int minWidth2 = (int)LuaDLL.lua_tonumber(L, 5);
				int minHeight2 = (int)LuaDLL.lua_tonumber(L, 6);
				int maxWidth = (int)LuaDLL.lua_tonumber(L, 7);
				int maxHeight = (int)LuaDLL.lua_tonumber(L, 8);
				NGUIMathLua.ResizeWidget(w2, pivot2, x2, y2, minWidth2, minHeight2, maxWidth, maxHeight);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: XQ.Framework.Lua.Utility.NGUIMathLua.ResizeWidget");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AdjustWidget(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(UIWidget), typeof(float), typeof(float), typeof(float), typeof(float)))
			{
				UIWidget w = (UIWidget)ToLua.ToObject(L, 1);
				float left = (float)LuaDLL.lua_tonumber(L, 2);
				float bottom = (float)LuaDLL.lua_tonumber(L, 3);
				float right = (float)LuaDLL.lua_tonumber(L, 4);
				float top = (float)LuaDLL.lua_tonumber(L, 5);
				NGUIMathLua.AdjustWidget(w, left, bottom, right, top);
				result = 0;
			}
			else if (num == 7 && TypeChecker.CheckTypes(L, 1, typeof(UIWidget), typeof(float), typeof(float), typeof(float), typeof(float), typeof(int), typeof(int)))
			{
				UIWidget w2 = (UIWidget)ToLua.ToObject(L, 1);
				float left2 = (float)LuaDLL.lua_tonumber(L, 2);
				float bottom2 = (float)LuaDLL.lua_tonumber(L, 3);
				float right2 = (float)LuaDLL.lua_tonumber(L, 4);
				float top2 = (float)LuaDLL.lua_tonumber(L, 5);
				int minWidth = (int)LuaDLL.lua_tonumber(L, 6);
				int minHeight = (int)LuaDLL.lua_tonumber(L, 7);
				NGUIMathLua.AdjustWidget(w2, left2, bottom2, right2, top2, minWidth, minHeight);
				result = 0;
			}
			else if (num == 9 && TypeChecker.CheckTypes(L, 1, typeof(UIWidget), typeof(float), typeof(float), typeof(float), typeof(float), typeof(int), typeof(int), typeof(int), typeof(int)))
			{
				UIWidget w3 = (UIWidget)ToLua.ToObject(L, 1);
				float left3 = (float)LuaDLL.lua_tonumber(L, 2);
				float bottom3 = (float)LuaDLL.lua_tonumber(L, 3);
				float right3 = (float)LuaDLL.lua_tonumber(L, 4);
				float top3 = (float)LuaDLL.lua_tonumber(L, 5);
				int minWidth2 = (int)LuaDLL.lua_tonumber(L, 6);
				int minHeight2 = (int)LuaDLL.lua_tonumber(L, 7);
				int maxWidth = (int)LuaDLL.lua_tonumber(L, 8);
				int maxHeight = (int)LuaDLL.lua_tonumber(L, 9);
				NGUIMathLua.AdjustWidget(w3, left3, bottom3, right3, top3, minWidth2, minHeight2, maxWidth, maxHeight);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: XQ.Framework.Lua.Utility.NGUIMathLua.AdjustWidget");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AdjustByDPI(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			float height = (float)LuaDLL.luaL_checknumber(L, 1);
			int n = NGUIMathLua.AdjustByDPI(height);
			LuaDLL.lua_pushinteger(L, n);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ScreenToPixels(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Vector2 pos = ToLua.ToVector2(L, 1);
			Transform relativeTo = (Transform)ToLua.CheckUnityObject(L, 2, typeof(Transform));
			Vector2 v = NGUIMathLua.ScreenToPixels(pos, relativeTo);
			ToLua.Push(L, v);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ScreenToParentPixels(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Vector2 pos = ToLua.ToVector2(L, 1);
			Transform relativeTo = (Transform)ToLua.CheckUnityObject(L, 2, typeof(Transform));
			Vector2 v = NGUIMathLua.ScreenToParentPixels(pos, relativeTo);
			ToLua.Push(L, v);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int WorldToLocalPoint(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			Vector3 worldPos = ToLua.ToVector3(L, 1);
			Camera worldCam = (Camera)ToLua.CheckUnityObject(L, 2, typeof(Camera));
			Camera uiCam = (Camera)ToLua.CheckUnityObject(L, 3, typeof(Camera));
			Transform relativeTo = (Transform)ToLua.CheckUnityObject(L, 4, typeof(Transform));
			Vector3 v = NGUIMathLua.WorldToLocalPoint(worldPos, worldCam, uiCam, relativeTo);
			ToLua.Push(L, v);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OverlayPosition(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Transform), typeof(Transform)))
			{
				Transform trans = (Transform)ToLua.ToObject(L, 1);
				Transform target = (Transform)ToLua.ToObject(L, 2);
				trans.OverlayPosition(target);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Transform), typeof(Vector3), typeof(Camera)))
			{
				Transform trans2 = (Transform)ToLua.ToObject(L, 1);
				Vector3 worldPos = ToLua.ToVector3(L, 2);
				Camera worldCam = (Camera)ToLua.ToObject(L, 3);
				trans2.OverlayPosition(worldPos, worldCam);
				result = 0;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Transform), typeof(Vector3), typeof(Camera), typeof(Camera)))
			{
				Transform trans3 = (Transform)ToLua.ToObject(L, 1);
				Vector3 worldPos2 = ToLua.ToVector3(L, 2);
				Camera worldCam2 = (Camera)ToLua.ToObject(L, 3);
				Camera myCam = (Camera)ToLua.ToObject(L, 4);
				trans3.OverlayPosition(worldPos2, worldCam2, myCam);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: XQ.Framework.Lua.Utility.NGUIMathLua.OverlayPosition");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
