using Assets.Scripts.Tools.NGUI.Component;
using LuaInterface;
using System;
using UnityEngine;

public class Assets_Scripts_Tools_NGUI_Component_UIDoubleOutLineLabelWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UIDoubleOutLineLabel), typeof(UILabel), null);
		L.RegFunction("OnFill", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIDoubleOutLineLabelWrap.OnFill));
		L.RegFunction("ApplyShadow", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIDoubleOutLineLabelWrap.ApplyShadow));
		L.RegFunction("__eq", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIDoubleOutLineLabelWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("DoubleOutLine", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIDoubleOutLineLabelWrap.get_DoubleOutLine), new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIDoubleOutLineLabelWrap.set_DoubleOutLine));
		L.RegVar("DoubleOutLineDistance", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIDoubleOutLineLabelWrap.get_DoubleOutLineDistance), new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIDoubleOutLineLabelWrap.set_DoubleOutLineDistance));
		L.RegVar("DoubleOutLineColor", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIDoubleOutLineLabelWrap.get_DoubleOutLineColor), new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIDoubleOutLineLabelWrap.set_DoubleOutLineColor));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnFill(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			UIDoubleOutLineLabel uIDoubleOutLineLabel = (UIDoubleOutLineLabel)ToLua.CheckObject(L, 1, typeof(UIDoubleOutLineLabel));
			BetterList<Vector3> verts = (BetterList<Vector3>)ToLua.CheckObject(L, 2, typeof(BetterList<Vector3>));
			BetterList<Vector2> uvs = (BetterList<Vector2>)ToLua.CheckObject(L, 3, typeof(BetterList<Vector2>));
			BetterList<Color> cols = (BetterList<Color>)ToLua.CheckObject(L, 4, typeof(BetterList<Color>));
			uIDoubleOutLineLabel.OnFill(verts, uvs, cols);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ApplyShadow(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 8 && TypeChecker.CheckTypes(L, 1, typeof(UIDoubleOutLineLabel), typeof(BetterList<Vector3>), typeof(BetterList<Vector2>), typeof(BetterList<Color>), typeof(int), typeof(int), typeof(float), typeof(float)))
			{
				UIDoubleOutLineLabel uIDoubleOutLineLabel = (UIDoubleOutLineLabel)ToLua.ToObject(L, 1);
				BetterList<Vector3> verts = (BetterList<Vector3>)ToLua.ToObject(L, 2);
				BetterList<Vector2> uvs = (BetterList<Vector2>)ToLua.ToObject(L, 3);
				BetterList<Color> cols = (BetterList<Color>)ToLua.ToObject(L, 4);
				int start = (int)LuaDLL.lua_tonumber(L, 5);
				int end = (int)LuaDLL.lua_tonumber(L, 6);
				float x = (float)LuaDLL.lua_tonumber(L, 7);
				float y = (float)LuaDLL.lua_tonumber(L, 8);
				uIDoubleOutLineLabel.ApplyShadow(verts, uvs, cols, start, end, x, y);
				result = 0;
			}
			else if (num == 9 && TypeChecker.CheckTypes(L, 1, typeof(UIDoubleOutLineLabel), typeof(BetterList<Vector3>), typeof(BetterList<Vector2>), typeof(BetterList<Color>), typeof(int), typeof(int), typeof(float), typeof(float), typeof(Color)))
			{
				UIDoubleOutLineLabel uIDoubleOutLineLabel2 = (UIDoubleOutLineLabel)ToLua.ToObject(L, 1);
				BetterList<Vector3> verts2 = (BetterList<Vector3>)ToLua.ToObject(L, 2);
				BetterList<Vector2> uvs2 = (BetterList<Vector2>)ToLua.ToObject(L, 3);
				BetterList<Color> cols2 = (BetterList<Color>)ToLua.ToObject(L, 4);
				int start2 = (int)LuaDLL.lua_tonumber(L, 5);
				int end2 = (int)LuaDLL.lua_tonumber(L, 6);
				float x2 = (float)LuaDLL.lua_tonumber(L, 7);
				float y2 = (float)LuaDLL.lua_tonumber(L, 8);
				Color c = ToLua.ToColor(L, 9);
				uIDoubleOutLineLabel2.ApplyShadow(verts2, uvs2, cols2, start2, end2, x2, y2, c);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: Assets.Scripts.Tools.NGUI.Component.UIDoubleOutLineLabel.ApplyShadow");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int op_Equality(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Object x = (UnityEngine.Object)ToLua.ToObject(L, 1);
			UnityEngine.Object y = (UnityEngine.Object)ToLua.ToObject(L, 2);
			bool value = x == y;
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
	private static int get_DoubleOutLine(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDoubleOutLineLabel uIDoubleOutLineLabel = (UIDoubleOutLineLabel)obj;
			bool doubleOutLine = uIDoubleOutLineLabel.DoubleOutLine;
			LuaDLL.lua_pushboolean(L, doubleOutLine);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index DoubleOutLine on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_DoubleOutLineDistance(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDoubleOutLineLabel uIDoubleOutLineLabel = (UIDoubleOutLineLabel)obj;
			Vector2 doubleOutLineDistance = uIDoubleOutLineLabel.DoubleOutLineDistance;
			ToLua.Push(L, doubleOutLineDistance);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index DoubleOutLineDistance on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_DoubleOutLineColor(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDoubleOutLineLabel uIDoubleOutLineLabel = (UIDoubleOutLineLabel)obj;
			Color doubleOutLineColor = uIDoubleOutLineLabel.DoubleOutLineColor;
			ToLua.Push(L, doubleOutLineColor);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index DoubleOutLineColor on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_DoubleOutLine(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDoubleOutLineLabel uIDoubleOutLineLabel = (UIDoubleOutLineLabel)obj;
			bool doubleOutLine = LuaDLL.luaL_checkboolean(L, 2);
			uIDoubleOutLineLabel.DoubleOutLine = doubleOutLine;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index DoubleOutLine on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_DoubleOutLineDistance(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDoubleOutLineLabel uIDoubleOutLineLabel = (UIDoubleOutLineLabel)obj;
			Vector2 doubleOutLineDistance = ToLua.ToVector2(L, 2);
			uIDoubleOutLineLabel.DoubleOutLineDistance = doubleOutLineDistance;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index DoubleOutLineDistance on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_DoubleOutLineColor(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDoubleOutLineLabel uIDoubleOutLineLabel = (UIDoubleOutLineLabel)obj;
			Color doubleOutLineColor = ToLua.ToColor(L, 2);
			uIDoubleOutLineLabel.DoubleOutLineColor = doubleOutLineColor;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index DoubleOutLineColor on a nil value");
		}
		return result;
	}
}
