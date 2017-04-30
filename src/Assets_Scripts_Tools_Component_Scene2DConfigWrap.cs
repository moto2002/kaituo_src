using Assets.Scripts.Tools.Component;
using LuaInterface;
using System;
using UnityEngine;

public class Assets_Scripts_Tools_Component_Scene2DConfigWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Scene2DConfig), typeof(MonoBehaviour), null);
		L.RegFunction("__eq", new LuaCSFunction(Assets_Scripts_Tools_Component_Scene2DConfigWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("Instance", new LuaCSFunction(Assets_Scripts_Tools_Component_Scene2DConfigWrap.get_Instance), new LuaCSFunction(Assets_Scripts_Tools_Component_Scene2DConfigWrap.set_Instance));
		L.RegVar("FloorAlpha", new LuaCSFunction(Assets_Scripts_Tools_Component_Scene2DConfigWrap.get_FloorAlpha), new LuaCSFunction(Assets_Scripts_Tools_Component_Scene2DConfigWrap.set_FloorAlpha));
		L.EndClass();
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
			ToLua.Push(L, Scene2DConfig.Instance);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_FloorAlpha(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Scene2DConfig scene2DConfig = (Scene2DConfig)obj;
			float floorAlpha = scene2DConfig.FloorAlpha;
			LuaDLL.lua_pushnumber(L, (double)floorAlpha);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index FloorAlpha on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Instance(IntPtr L)
	{
		int result;
		try
		{
			Scene2DConfig instance = (Scene2DConfig)ToLua.CheckUnityObject(L, 2, typeof(Scene2DConfig));
			Scene2DConfig.Instance = instance;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_FloorAlpha(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Scene2DConfig scene2DConfig = (Scene2DConfig)obj;
			float floorAlpha = (float)LuaDLL.luaL_checknumber(L, 2);
			scene2DConfig.FloorAlpha = floorAlpha;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index FloorAlpha on a nil value");
		}
		return result;
	}
}
