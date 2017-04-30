using LuaInterface;
using System;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class UnityStandardAssets_ImageEffects_PostEffectsBaseWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(PostEffectsBase), typeof(MonoBehaviour), null);
		L.RegFunction("CheckResources", new LuaCSFunction(UnityStandardAssets_ImageEffects_PostEffectsBaseWrap.CheckResources));
		L.RegFunction("Dx11Support", new LuaCSFunction(UnityStandardAssets_ImageEffects_PostEffectsBaseWrap.Dx11Support));
		L.RegFunction("__eq", new LuaCSFunction(UnityStandardAssets_ImageEffects_PostEffectsBaseWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CheckResources(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			PostEffectsBase postEffectsBase = (PostEffectsBase)ToLua.CheckObject(L, 1, typeof(PostEffectsBase));
			bool value = postEffectsBase.CheckResources();
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
	private static int Dx11Support(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			PostEffectsBase postEffectsBase = (PostEffectsBase)ToLua.CheckObject(L, 1, typeof(PostEffectsBase));
			bool value = postEffectsBase.Dx11Support();
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
}
