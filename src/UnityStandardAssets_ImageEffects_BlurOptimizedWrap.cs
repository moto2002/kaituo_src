using LuaInterface;
using System;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class UnityStandardAssets_ImageEffects_BlurOptimizedWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(BlurOptimized), typeof(PostEffectsBase), null);
		L.RegFunction("CheckResources", new LuaCSFunction(UnityStandardAssets_ImageEffects_BlurOptimizedWrap.CheckResources));
		L.RegFunction("OnDisable", new LuaCSFunction(UnityStandardAssets_ImageEffects_BlurOptimizedWrap.OnDisable));
		L.RegFunction("OnRenderImage", new LuaCSFunction(UnityStandardAssets_ImageEffects_BlurOptimizedWrap.OnRenderImage));
		L.RegFunction("__eq", new LuaCSFunction(UnityStandardAssets_ImageEffects_BlurOptimizedWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("downsample", new LuaCSFunction(UnityStandardAssets_ImageEffects_BlurOptimizedWrap.get_downsample), new LuaCSFunction(UnityStandardAssets_ImageEffects_BlurOptimizedWrap.set_downsample));
		L.RegVar("blurSize", new LuaCSFunction(UnityStandardAssets_ImageEffects_BlurOptimizedWrap.get_blurSize), new LuaCSFunction(UnityStandardAssets_ImageEffects_BlurOptimizedWrap.set_blurSize));
		L.RegVar("blurIterations", new LuaCSFunction(UnityStandardAssets_ImageEffects_BlurOptimizedWrap.get_blurIterations), new LuaCSFunction(UnityStandardAssets_ImageEffects_BlurOptimizedWrap.set_blurIterations));
		L.RegVar("blurType", new LuaCSFunction(UnityStandardAssets_ImageEffects_BlurOptimizedWrap.get_blurType), new LuaCSFunction(UnityStandardAssets_ImageEffects_BlurOptimizedWrap.set_blurType));
		L.RegVar("blurShader", new LuaCSFunction(UnityStandardAssets_ImageEffects_BlurOptimizedWrap.get_blurShader), new LuaCSFunction(UnityStandardAssets_ImageEffects_BlurOptimizedWrap.set_blurShader));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CheckResources(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			BlurOptimized blurOptimized = (BlurOptimized)ToLua.CheckObject(L, 1, typeof(BlurOptimized));
			bool value = blurOptimized.CheckResources();
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
	private static int OnDisable(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			BlurOptimized blurOptimized = (BlurOptimized)ToLua.CheckObject(L, 1, typeof(BlurOptimized));
			blurOptimized.OnDisable();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnRenderImage(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			BlurOptimized blurOptimized = (BlurOptimized)ToLua.CheckObject(L, 1, typeof(BlurOptimized));
			RenderTexture source = (RenderTexture)ToLua.CheckUnityObject(L, 2, typeof(RenderTexture));
			RenderTexture destination = (RenderTexture)ToLua.CheckUnityObject(L, 3, typeof(RenderTexture));
			blurOptimized.OnRenderImage(source, destination);
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
	private static int get_downsample(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			BlurOptimized blurOptimized = (BlurOptimized)obj;
			int downsample = blurOptimized.downsample;
			LuaDLL.lua_pushinteger(L, downsample);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index downsample on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_blurSize(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			BlurOptimized blurOptimized = (BlurOptimized)obj;
			float blurSize = blurOptimized.blurSize;
			LuaDLL.lua_pushnumber(L, (double)blurSize);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index blurSize on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_blurIterations(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			BlurOptimized blurOptimized = (BlurOptimized)obj;
			int blurIterations = blurOptimized.blurIterations;
			LuaDLL.lua_pushinteger(L, blurIterations);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index blurIterations on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_blurType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			BlurOptimized blurOptimized = (BlurOptimized)obj;
			BlurOptimized.BlurType blurType = blurOptimized.blurType;
			ToLua.Push(L, blurType);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index blurType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_blurShader(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			BlurOptimized blurOptimized = (BlurOptimized)obj;
			Shader blurShader = blurOptimized.blurShader;
			ToLua.Push(L, blurShader);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index blurShader on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_downsample(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			BlurOptimized blurOptimized = (BlurOptimized)obj;
			int downsample = (int)LuaDLL.luaL_checknumber(L, 2);
			blurOptimized.downsample = downsample;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index downsample on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_blurSize(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			BlurOptimized blurOptimized = (BlurOptimized)obj;
			float blurSize = (float)LuaDLL.luaL_checknumber(L, 2);
			blurOptimized.blurSize = blurSize;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index blurSize on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_blurIterations(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			BlurOptimized blurOptimized = (BlurOptimized)obj;
			int blurIterations = (int)LuaDLL.luaL_checknumber(L, 2);
			blurOptimized.blurIterations = blurIterations;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index blurIterations on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_blurType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			BlurOptimized blurOptimized = (BlurOptimized)obj;
			BlurOptimized.BlurType blurType = (BlurOptimized.BlurType)LuaDLL.luaL_checknumber(L, 2);
			blurOptimized.blurType = blurType;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index blurType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_blurShader(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			BlurOptimized blurOptimized = (BlurOptimized)obj;
			Shader blurShader = (Shader)ToLua.CheckUnityObject(L, 2, typeof(Shader));
			blurOptimized.blurShader = blurShader;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index blurShader on a nil value");
		}
		return result;
	}
}
