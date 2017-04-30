using LuaInterface;
using System;

public class UIWidget_PivotWrap
{
	public static void Register(LuaState L)
	{
		L.BeginEnum(typeof(UIWidget.Pivot));
		L.RegVar("TopLeft", new LuaCSFunction(UIWidget_PivotWrap.get_TopLeft), null);
		L.RegVar("Top", new LuaCSFunction(UIWidget_PivotWrap.get_Top), null);
		L.RegVar("TopRight", new LuaCSFunction(UIWidget_PivotWrap.get_TopRight), null);
		L.RegVar("Left", new LuaCSFunction(UIWidget_PivotWrap.get_Left), null);
		L.RegVar("Center", new LuaCSFunction(UIWidget_PivotWrap.get_Center), null);
		L.RegVar("Right", new LuaCSFunction(UIWidget_PivotWrap.get_Right), null);
		L.RegVar("BottomLeft", new LuaCSFunction(UIWidget_PivotWrap.get_BottomLeft), null);
		L.RegVar("Bottom", new LuaCSFunction(UIWidget_PivotWrap.get_Bottom), null);
		L.RegVar("BottomRight", new LuaCSFunction(UIWidget_PivotWrap.get_BottomRight), null);
		L.RegFunction("IntToEnum", new LuaCSFunction(UIWidget_PivotWrap.IntToEnum));
		L.EndEnum();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_TopLeft(IntPtr L)
	{
		ToLua.Push(L, UIWidget.Pivot.TopLeft);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Top(IntPtr L)
	{
		ToLua.Push(L, UIWidget.Pivot.Top);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_TopRight(IntPtr L)
	{
		ToLua.Push(L, UIWidget.Pivot.TopRight);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Left(IntPtr L)
	{
		ToLua.Push(L, UIWidget.Pivot.Left);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Center(IntPtr L)
	{
		ToLua.Push(L, UIWidget.Pivot.Center);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Right(IntPtr L)
	{
		ToLua.Push(L, UIWidget.Pivot.Right);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_BottomLeft(IntPtr L)
	{
		ToLua.Push(L, UIWidget.Pivot.BottomLeft);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Bottom(IntPtr L)
	{
		ToLua.Push(L, UIWidget.Pivot.Bottom);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_BottomRight(IntPtr L)
	{
		ToLua.Push(L, UIWidget.Pivot.BottomRight);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IntToEnum(IntPtr L)
	{
		int num = (int)LuaDLL.lua_tonumber(L, 1);
		UIWidget.Pivot pivot = (UIWidget.Pivot)num;
		ToLua.Push(L, pivot);
		return 1;
	}
}
