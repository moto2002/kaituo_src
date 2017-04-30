using LuaInterface;
using System;

public class UIBasicSprite_FlipWrap
{
	public static void Register(LuaState L)
	{
		L.BeginEnum(typeof(UIBasicSprite.Flip));
		L.RegVar("Nothing", new LuaCSFunction(UIBasicSprite_FlipWrap.get_Nothing), null);
		L.RegVar("Horizontally", new LuaCSFunction(UIBasicSprite_FlipWrap.get_Horizontally), null);
		L.RegVar("Vertically", new LuaCSFunction(UIBasicSprite_FlipWrap.get_Vertically), null);
		L.RegVar("Both", new LuaCSFunction(UIBasicSprite_FlipWrap.get_Both), null);
		L.RegFunction("IntToEnum", new LuaCSFunction(UIBasicSprite_FlipWrap.IntToEnum));
		L.EndEnum();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Nothing(IntPtr L)
	{
		ToLua.Push(L, UIBasicSprite.Flip.Nothing);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Horizontally(IntPtr L)
	{
		ToLua.Push(L, UIBasicSprite.Flip.Horizontally);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Vertically(IntPtr L)
	{
		ToLua.Push(L, UIBasicSprite.Flip.Vertically);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Both(IntPtr L)
	{
		ToLua.Push(L, UIBasicSprite.Flip.Both);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IntToEnum(IntPtr L)
	{
		int num = (int)LuaDLL.lua_tonumber(L, 1);
		UIBasicSprite.Flip flip = (UIBasicSprite.Flip)num;
		ToLua.Push(L, flip);
		return 1;
	}
}
