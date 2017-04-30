using Assets.Scripts.Game;
using LuaInterface;
using System;
using UnityEngine;

public class Assets_Scripts_Game_GlobalClickEffectWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(GlobalClickEffect), typeof(MonoBehaviour), null);
		L.RegFunction("SetPrefab", new LuaCSFunction(Assets_Scripts_Game_GlobalClickEffectWrap.SetPrefab));
		L.RegFunction("Update", new LuaCSFunction(Assets_Scripts_Game_GlobalClickEffectWrap.Update));
		L.RegFunction("__eq", new LuaCSFunction(Assets_Scripts_Game_GlobalClickEffectWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("Instance", new LuaCSFunction(Assets_Scripts_Game_GlobalClickEffectWrap.get_Instance), new LuaCSFunction(Assets_Scripts_Game_GlobalClickEffectWrap.set_Instance));
		L.RegVar("Prefab", new LuaCSFunction(Assets_Scripts_Game_GlobalClickEffectWrap.get_Prefab), new LuaCSFunction(Assets_Scripts_Game_GlobalClickEffectWrap.set_Prefab));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetPrefab(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			GlobalClickEffect globalClickEffect = (GlobalClickEffect)ToLua.CheckObject(L, 1, typeof(GlobalClickEffect));
			GameObject prefab = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			globalClickEffect.SetPrefab(prefab);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Update(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GlobalClickEffect globalClickEffect = (GlobalClickEffect)ToLua.CheckObject(L, 1, typeof(GlobalClickEffect));
			globalClickEffect.Update();
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
	private static int get_Instance(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, GlobalClickEffect.Instance);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Prefab(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GlobalClickEffect globalClickEffect = (GlobalClickEffect)obj;
			GameObject prefab = globalClickEffect.Prefab;
			ToLua.Push(L, prefab);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Prefab on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Instance(IntPtr L)
	{
		int result;
		try
		{
			GlobalClickEffect instance = (GlobalClickEffect)ToLua.CheckUnityObject(L, 2, typeof(GlobalClickEffect));
			GlobalClickEffect.Instance = instance;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Prefab(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GlobalClickEffect globalClickEffect = (GlobalClickEffect)obj;
			GameObject prefab = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			globalClickEffect.Prefab = prefab;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Prefab on a nil value");
		}
		return result;
	}
}
