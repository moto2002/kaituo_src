using LuaInterface;
using System;
using UnityEngine;
using UnityEngine.Rendering;

public class UnityEngine_RenderSettingsWrap
{
	public static void Register(LuaState L)
	{
		L.BeginStaticLibs("RenderSettings");
		L.RegFunction("__eq", new LuaCSFunction(UnityEngine_RenderSettingsWrap.op_Equality));
		L.RegVar("fog", new LuaCSFunction(UnityEngine_RenderSettingsWrap.get_fog), new LuaCSFunction(UnityEngine_RenderSettingsWrap.set_fog));
		L.RegVar("fogMode", new LuaCSFunction(UnityEngine_RenderSettingsWrap.get_fogMode), new LuaCSFunction(UnityEngine_RenderSettingsWrap.set_fogMode));
		L.RegVar("fogColor", new LuaCSFunction(UnityEngine_RenderSettingsWrap.get_fogColor), new LuaCSFunction(UnityEngine_RenderSettingsWrap.set_fogColor));
		L.RegVar("fogDensity", new LuaCSFunction(UnityEngine_RenderSettingsWrap.get_fogDensity), new LuaCSFunction(UnityEngine_RenderSettingsWrap.set_fogDensity));
		L.RegVar("fogStartDistance", new LuaCSFunction(UnityEngine_RenderSettingsWrap.get_fogStartDistance), new LuaCSFunction(UnityEngine_RenderSettingsWrap.set_fogStartDistance));
		L.RegVar("fogEndDistance", new LuaCSFunction(UnityEngine_RenderSettingsWrap.get_fogEndDistance), new LuaCSFunction(UnityEngine_RenderSettingsWrap.set_fogEndDistance));
		L.RegVar("ambientMode", new LuaCSFunction(UnityEngine_RenderSettingsWrap.get_ambientMode), new LuaCSFunction(UnityEngine_RenderSettingsWrap.set_ambientMode));
		L.RegVar("ambientSkyColor", new LuaCSFunction(UnityEngine_RenderSettingsWrap.get_ambientSkyColor), new LuaCSFunction(UnityEngine_RenderSettingsWrap.set_ambientSkyColor));
		L.RegVar("ambientEquatorColor", new LuaCSFunction(UnityEngine_RenderSettingsWrap.get_ambientEquatorColor), new LuaCSFunction(UnityEngine_RenderSettingsWrap.set_ambientEquatorColor));
		L.RegVar("ambientGroundColor", new LuaCSFunction(UnityEngine_RenderSettingsWrap.get_ambientGroundColor), new LuaCSFunction(UnityEngine_RenderSettingsWrap.set_ambientGroundColor));
		L.RegVar("ambientLight", new LuaCSFunction(UnityEngine_RenderSettingsWrap.get_ambientLight), new LuaCSFunction(UnityEngine_RenderSettingsWrap.set_ambientLight));
		L.RegVar("ambientIntensity", new LuaCSFunction(UnityEngine_RenderSettingsWrap.get_ambientIntensity), new LuaCSFunction(UnityEngine_RenderSettingsWrap.set_ambientIntensity));
		L.RegVar("ambientProbe", new LuaCSFunction(UnityEngine_RenderSettingsWrap.get_ambientProbe), new LuaCSFunction(UnityEngine_RenderSettingsWrap.set_ambientProbe));
		L.RegVar("reflectionIntensity", new LuaCSFunction(UnityEngine_RenderSettingsWrap.get_reflectionIntensity), new LuaCSFunction(UnityEngine_RenderSettingsWrap.set_reflectionIntensity));
		L.RegVar("reflectionBounces", new LuaCSFunction(UnityEngine_RenderSettingsWrap.get_reflectionBounces), new LuaCSFunction(UnityEngine_RenderSettingsWrap.set_reflectionBounces));
		L.RegVar("haloStrength", new LuaCSFunction(UnityEngine_RenderSettingsWrap.get_haloStrength), new LuaCSFunction(UnityEngine_RenderSettingsWrap.set_haloStrength));
		L.RegVar("flareStrength", new LuaCSFunction(UnityEngine_RenderSettingsWrap.get_flareStrength), new LuaCSFunction(UnityEngine_RenderSettingsWrap.set_flareStrength));
		L.RegVar("flareFadeSpeed", new LuaCSFunction(UnityEngine_RenderSettingsWrap.get_flareFadeSpeed), new LuaCSFunction(UnityEngine_RenderSettingsWrap.set_flareFadeSpeed));
		L.RegVar("skybox", new LuaCSFunction(UnityEngine_RenderSettingsWrap.get_skybox), new LuaCSFunction(UnityEngine_RenderSettingsWrap.set_skybox));
		L.RegVar("defaultReflectionMode", new LuaCSFunction(UnityEngine_RenderSettingsWrap.get_defaultReflectionMode), new LuaCSFunction(UnityEngine_RenderSettingsWrap.set_defaultReflectionMode));
		L.RegVar("defaultReflectionResolution", new LuaCSFunction(UnityEngine_RenderSettingsWrap.get_defaultReflectionResolution), new LuaCSFunction(UnityEngine_RenderSettingsWrap.set_defaultReflectionResolution));
		L.RegVar("customReflection", new LuaCSFunction(UnityEngine_RenderSettingsWrap.get_customReflection), new LuaCSFunction(UnityEngine_RenderSettingsWrap.set_customReflection));
		L.EndStaticLibs();
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
	private static int get_fog(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushboolean(L, RenderSettings.fog);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_fogMode(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, RenderSettings.fogMode);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_fogColor(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, RenderSettings.fogColor);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_fogDensity(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushnumber(L, (double)RenderSettings.fogDensity);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_fogStartDistance(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushnumber(L, (double)RenderSettings.fogStartDistance);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_fogEndDistance(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushnumber(L, (double)RenderSettings.fogEndDistance);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_ambientMode(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, RenderSettings.ambientMode);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_ambientSkyColor(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, RenderSettings.ambientSkyColor);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_ambientEquatorColor(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, RenderSettings.ambientEquatorColor);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_ambientGroundColor(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, RenderSettings.ambientGroundColor);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_ambientLight(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, RenderSettings.ambientLight);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_ambientIntensity(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushnumber(L, (double)RenderSettings.ambientIntensity);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_ambientProbe(IntPtr L)
	{
		int result;
		try
		{
			ToLua.PushValue(L, RenderSettings.ambientProbe);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_reflectionIntensity(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushnumber(L, (double)RenderSettings.reflectionIntensity);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_reflectionBounces(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, RenderSettings.reflectionBounces);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_haloStrength(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushnumber(L, (double)RenderSettings.haloStrength);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_flareStrength(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushnumber(L, (double)RenderSettings.flareStrength);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_flareFadeSpeed(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushnumber(L, (double)RenderSettings.flareFadeSpeed);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_skybox(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, RenderSettings.skybox);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_defaultReflectionMode(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, RenderSettings.defaultReflectionMode);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_defaultReflectionResolution(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, RenderSettings.defaultReflectionResolution);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_customReflection(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, RenderSettings.customReflection);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_fog(IntPtr L)
	{
		int result;
		try
		{
			bool fog = LuaDLL.luaL_checkboolean(L, 2);
			RenderSettings.fog = fog;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_fogMode(IntPtr L)
	{
		int result;
		try
		{
			FogMode fogMode = (FogMode)LuaDLL.luaL_checknumber(L, 2);
			RenderSettings.fogMode = fogMode;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_fogColor(IntPtr L)
	{
		int result;
		try
		{
			Color fogColor = ToLua.ToColor(L, 2);
			RenderSettings.fogColor = fogColor;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_fogDensity(IntPtr L)
	{
		int result;
		try
		{
			float fogDensity = (float)LuaDLL.luaL_checknumber(L, 2);
			RenderSettings.fogDensity = fogDensity;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_fogStartDistance(IntPtr L)
	{
		int result;
		try
		{
			float fogStartDistance = (float)LuaDLL.luaL_checknumber(L, 2);
			RenderSettings.fogStartDistance = fogStartDistance;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_fogEndDistance(IntPtr L)
	{
		int result;
		try
		{
			float fogEndDistance = (float)LuaDLL.luaL_checknumber(L, 2);
			RenderSettings.fogEndDistance = fogEndDistance;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_ambientMode(IntPtr L)
	{
		int result;
		try
		{
			AmbientMode ambientMode = (AmbientMode)LuaDLL.luaL_checknumber(L, 2);
			RenderSettings.ambientMode = ambientMode;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_ambientSkyColor(IntPtr L)
	{
		int result;
		try
		{
			Color ambientSkyColor = ToLua.ToColor(L, 2);
			RenderSettings.ambientSkyColor = ambientSkyColor;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_ambientEquatorColor(IntPtr L)
	{
		int result;
		try
		{
			Color ambientEquatorColor = ToLua.ToColor(L, 2);
			RenderSettings.ambientEquatorColor = ambientEquatorColor;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_ambientGroundColor(IntPtr L)
	{
		int result;
		try
		{
			Color ambientGroundColor = ToLua.ToColor(L, 2);
			RenderSettings.ambientGroundColor = ambientGroundColor;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_ambientLight(IntPtr L)
	{
		int result;
		try
		{
			Color ambientLight = ToLua.ToColor(L, 2);
			RenderSettings.ambientLight = ambientLight;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_ambientIntensity(IntPtr L)
	{
		int result;
		try
		{
			float ambientIntensity = (float)LuaDLL.luaL_checknumber(L, 2);
			RenderSettings.ambientIntensity = ambientIntensity;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_ambientProbe(IntPtr L)
	{
		int result;
		try
		{
			SphericalHarmonicsL2 ambientProbe = (SphericalHarmonicsL2)ToLua.CheckObject(L, 2, typeof(SphericalHarmonicsL2));
			RenderSettings.ambientProbe = ambientProbe;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_reflectionIntensity(IntPtr L)
	{
		int result;
		try
		{
			float reflectionIntensity = (float)LuaDLL.luaL_checknumber(L, 2);
			RenderSettings.reflectionIntensity = reflectionIntensity;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_reflectionBounces(IntPtr L)
	{
		int result;
		try
		{
			int reflectionBounces = (int)LuaDLL.luaL_checknumber(L, 2);
			RenderSettings.reflectionBounces = reflectionBounces;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_haloStrength(IntPtr L)
	{
		int result;
		try
		{
			float haloStrength = (float)LuaDLL.luaL_checknumber(L, 2);
			RenderSettings.haloStrength = haloStrength;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_flareStrength(IntPtr L)
	{
		int result;
		try
		{
			float flareStrength = (float)LuaDLL.luaL_checknumber(L, 2);
			RenderSettings.flareStrength = flareStrength;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_flareFadeSpeed(IntPtr L)
	{
		int result;
		try
		{
			float flareFadeSpeed = (float)LuaDLL.luaL_checknumber(L, 2);
			RenderSettings.flareFadeSpeed = flareFadeSpeed;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_skybox(IntPtr L)
	{
		int result;
		try
		{
			Material skybox = (Material)ToLua.CheckUnityObject(L, 2, typeof(Material));
			RenderSettings.skybox = skybox;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_defaultReflectionMode(IntPtr L)
	{
		int result;
		try
		{
			DefaultReflectionMode defaultReflectionMode = (DefaultReflectionMode)LuaDLL.luaL_checknumber(L, 2);
			RenderSettings.defaultReflectionMode = defaultReflectionMode;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_defaultReflectionResolution(IntPtr L)
	{
		int result;
		try
		{
			int defaultReflectionResolution = (int)LuaDLL.luaL_checknumber(L, 2);
			RenderSettings.defaultReflectionResolution = defaultReflectionResolution;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_customReflection(IntPtr L)
	{
		int result;
		try
		{
			Cubemap customReflection = (Cubemap)ToLua.CheckUnityObject(L, 2, typeof(Cubemap));
			RenderSettings.customReflection = customReflection;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
