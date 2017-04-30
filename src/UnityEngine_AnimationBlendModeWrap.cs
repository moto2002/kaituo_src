using LuaInterface;
using System;
using UnityEngine;

public class UnityEngine_AnimationBlendModeWrap
{
	public static void Register(LuaState L)
	{
		L.BeginEnum(typeof(AnimationBlendMode));
		L.RegVar("Blend", new LuaCSFunction(UnityEngine_AnimationBlendModeWrap.get_Blend), null);
		L.RegVar("Additive", new LuaCSFunction(UnityEngine_AnimationBlendModeWrap.get_Additive), null);
		L.RegFunction("IntToEnum", new LuaCSFunction(UnityEngine_AnimationBlendModeWrap.IntToEnum));
		L.EndEnum();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Blend(IntPtr L)
	{
		ToLua.Push(L, AnimationBlendMode.Blend);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Additive(IntPtr L)
	{
		ToLua.Push(L, AnimationBlendMode.Additive);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IntToEnum(IntPtr L)
	{
		int num = (int)LuaDLL.lua_tonumber(L, 1);
		AnimationBlendMode animationBlendMode = (AnimationBlendMode)num;
		ToLua.Push(L, animationBlendMode);
		return 1;
	}
}
