using Assets.Scripts.Tools.Component;
using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Assets_Scripts_Tools_Component_SceneBakeDataWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(SceneBakeData), typeof(MonoBehaviour), null);
		L.RegFunction("Save", new LuaCSFunction(Assets_Scripts_Tools_Component_SceneBakeDataWrap.Save));
		L.RegFunction("Restore", new LuaCSFunction(Assets_Scripts_Tools_Component_SceneBakeDataWrap.Restore));
		L.RegFunction("__eq", new LuaCSFunction(Assets_Scripts_Tools_Component_SceneBakeDataWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("RendererInfos", new LuaCSFunction(Assets_Scripts_Tools_Component_SceneBakeDataWrap.get_RendererInfos), new LuaCSFunction(Assets_Scripts_Tools_Component_SceneBakeDataWrap.set_RendererInfos));
		L.RegVar("SceneInfo", new LuaCSFunction(Assets_Scripts_Tools_Component_SceneBakeDataWrap.get_SceneInfo), new LuaCSFunction(Assets_Scripts_Tools_Component_SceneBakeDataWrap.set_SceneInfo));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Save(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			SceneBakeData sceneBakeData = (SceneBakeData)ToLua.CheckObject(L, 1, typeof(SceneBakeData));
			sceneBakeData.Save();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Restore(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			SceneBakeData sceneBakeData = (SceneBakeData)ToLua.CheckObject(L, 1, typeof(SceneBakeData));
			sceneBakeData.Restore();
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
	private static int get_RendererInfos(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneBakeData sceneBakeData = (SceneBakeData)obj;
			List<SceneBakeData.RendererLightmapInfo> rendererInfos = sceneBakeData.RendererInfos;
			ToLua.PushObject(L, rendererInfos);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index RendererInfos on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_SceneInfo(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneBakeData sceneBakeData = (SceneBakeData)obj;
			SceneBakeData.SceneLightmapInfo sceneInfo = sceneBakeData.SceneInfo;
			ToLua.PushObject(L, sceneInfo);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index SceneInfo on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_RendererInfos(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneBakeData sceneBakeData = (SceneBakeData)obj;
			List<SceneBakeData.RendererLightmapInfo> rendererInfos = (List<SceneBakeData.RendererLightmapInfo>)ToLua.CheckObject(L, 2, typeof(List<SceneBakeData.RendererLightmapInfo>));
			sceneBakeData.RendererInfos = rendererInfos;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index RendererInfos on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_SceneInfo(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneBakeData sceneBakeData = (SceneBakeData)obj;
			SceneBakeData.SceneLightmapInfo sceneInfo = (SceneBakeData.SceneLightmapInfo)ToLua.CheckObject(L, 2, typeof(SceneBakeData.SceneLightmapInfo));
			sceneBakeData.SceneInfo = sceneInfo;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index SceneInfo on a nil value");
		}
		return result;
	}
}
