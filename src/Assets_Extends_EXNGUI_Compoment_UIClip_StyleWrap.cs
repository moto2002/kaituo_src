using Assets.Extends.EXNGUI.Compoment;
using LuaInterface;
using System;

public class Assets_Extends_EXNGUI_Compoment_UIClip_StyleWrap
{
	public static void Register(LuaState L)
	{
		L.BeginEnum(typeof(UIClip.Style));
		L.RegVar("Once", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIClip_StyleWrap.get_Once), null);
		L.RegVar("Loop", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIClip_StyleWrap.get_Loop), null);
		L.RegVar("PingPong", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIClip_StyleWrap.get_PingPong), null);
		L.RegFunction("IntToEnum", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIClip_StyleWrap.IntToEnum));
		L.EndEnum();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Once(IntPtr L)
	{
		ToLua.Push(L, UIClip.Style.Once);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Loop(IntPtr L)
	{
		ToLua.Push(L, UIClip.Style.Loop);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_PingPong(IntPtr L)
	{
		ToLua.Push(L, UIClip.Style.PingPong);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IntToEnum(IntPtr L)
	{
		int num = (int)LuaDLL.lua_tonumber(L, 1);
		UIClip.Style style = (UIClip.Style)num;
		ToLua.Push(L, style);
		return 1;
	}
}
