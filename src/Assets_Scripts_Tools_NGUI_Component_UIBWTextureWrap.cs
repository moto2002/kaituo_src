using Assets.Scripts.Tools.NGUI.Component;
using LuaInterface;
using System;
using UnityEngine;

public class Assets_Scripts_Tools_NGUI_Component_UIBWTextureWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UIBWTexture), typeof(UITexture), null);
		L.RegFunction("SetBlackAndWhite", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIBWTextureWrap.SetBlackAndWhite));
		L.RegFunction("ChangeBlackAndWhite", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIBWTextureWrap.ChangeBlackAndWhite));
		L.RegFunction("__eq", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIBWTextureWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("IsBlackAndWhite", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIBWTextureWrap.get_IsBlackAndWhite), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetBlackAndWhite(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UIBWTexture uIBWTexture = (UIBWTexture)ToLua.CheckObject(L, 1, typeof(UIBWTexture));
			bool blackAndWhite = LuaDLL.luaL_checkboolean(L, 2);
			uIBWTexture.SetBlackAndWhite(blackAndWhite);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ChangeBlackAndWhite(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIBWTexture uIBWTexture = (UIBWTexture)ToLua.CheckObject(L, 1, typeof(UIBWTexture));
			uIBWTexture.ChangeBlackAndWhite();
			result = 0;
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
	private static int get_IsBlackAndWhite(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIBWTexture uIBWTexture = (UIBWTexture)obj;
			bool isBlackAndWhite = uIBWTexture.IsBlackAndWhite;
			LuaDLL.lua_pushboolean(L, isBlackAndWhite);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index IsBlackAndWhite on a nil value");
		}
		return result;
	}
}
