using LuaInterface;
using System;
using UnityEngine;

public class UnityEngine_TextureWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Texture), typeof(UnityEngine.Object), null);
		L.RegFunction("SetGlobalAnisotropicFilteringLimits", new LuaCSFunction(UnityEngine_TextureWrap.SetGlobalAnisotropicFilteringLimits));
		L.RegFunction("GetNativeTexturePtr", new LuaCSFunction(UnityEngine_TextureWrap.GetNativeTexturePtr));
		L.RegFunction("New", new LuaCSFunction(UnityEngine_TextureWrap._CreateUnityEngine_Texture));
		L.RegFunction("__eq", new LuaCSFunction(UnityEngine_TextureWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("masterTextureLimit", new LuaCSFunction(UnityEngine_TextureWrap.get_masterTextureLimit), new LuaCSFunction(UnityEngine_TextureWrap.set_masterTextureLimit));
		L.RegVar("anisotropicFiltering", new LuaCSFunction(UnityEngine_TextureWrap.get_anisotropicFiltering), new LuaCSFunction(UnityEngine_TextureWrap.set_anisotropicFiltering));
		L.RegVar("width", new LuaCSFunction(UnityEngine_TextureWrap.get_width), new LuaCSFunction(UnityEngine_TextureWrap.set_width));
		L.RegVar("height", new LuaCSFunction(UnityEngine_TextureWrap.get_height), new LuaCSFunction(UnityEngine_TextureWrap.set_height));
		L.RegVar("filterMode", new LuaCSFunction(UnityEngine_TextureWrap.get_filterMode), new LuaCSFunction(UnityEngine_TextureWrap.set_filterMode));
		L.RegVar("anisoLevel", new LuaCSFunction(UnityEngine_TextureWrap.get_anisoLevel), new LuaCSFunction(UnityEngine_TextureWrap.set_anisoLevel));
		L.RegVar("wrapMode", new LuaCSFunction(UnityEngine_TextureWrap.get_wrapMode), new LuaCSFunction(UnityEngine_TextureWrap.set_wrapMode));
		L.RegVar("mipMapBias", new LuaCSFunction(UnityEngine_TextureWrap.get_mipMapBias), new LuaCSFunction(UnityEngine_TextureWrap.set_mipMapBias));
		L.RegVar("texelSize", new LuaCSFunction(UnityEngine_TextureWrap.get_texelSize), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateUnityEngine_Texture(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				Texture obj = new Texture();
				ToLua.Push(L, obj);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: UnityEngine.Texture.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetGlobalAnisotropicFilteringLimits(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			int forcedMin = (int)LuaDLL.luaL_checknumber(L, 1);
			int globalMax = (int)LuaDLL.luaL_checknumber(L, 2);
			Texture.SetGlobalAnisotropicFilteringLimits(forcedMin, globalMax);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetNativeTexturePtr(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Texture texture = (Texture)ToLua.CheckObject(L, 1, typeof(Texture));
			IntPtr nativeTexturePtr = texture.GetNativeTexturePtr();
			LuaDLL.lua_pushlightuserdata(L, nativeTexturePtr);
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

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_masterTextureLimit(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, Texture.masterTextureLimit);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_anisotropicFiltering(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, Texture.anisotropicFiltering);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_width(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Texture texture = (Texture)obj;
			int width = texture.width;
			LuaDLL.lua_pushinteger(L, width);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index width on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_height(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Texture texture = (Texture)obj;
			int height = texture.height;
			LuaDLL.lua_pushinteger(L, height);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index height on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_filterMode(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Texture texture = (Texture)obj;
			FilterMode filterMode = texture.filterMode;
			ToLua.Push(L, filterMode);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index filterMode on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_anisoLevel(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Texture texture = (Texture)obj;
			int anisoLevel = texture.anisoLevel;
			LuaDLL.lua_pushinteger(L, anisoLevel);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index anisoLevel on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_wrapMode(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Texture texture = (Texture)obj;
			TextureWrapMode wrapMode = texture.wrapMode;
			ToLua.Push(L, wrapMode);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index wrapMode on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_mipMapBias(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Texture texture = (Texture)obj;
			float mipMapBias = texture.mipMapBias;
			LuaDLL.lua_pushnumber(L, (double)mipMapBias);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index mipMapBias on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_texelSize(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Texture texture = (Texture)obj;
			Vector2 texelSize = texture.texelSize;
			ToLua.Push(L, texelSize);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index texelSize on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_masterTextureLimit(IntPtr L)
	{
		int result;
		try
		{
			int masterTextureLimit = (int)LuaDLL.luaL_checknumber(L, 2);
			Texture.masterTextureLimit = masterTextureLimit;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_anisotropicFiltering(IntPtr L)
	{
		int result;
		try
		{
			AnisotropicFiltering anisotropicFiltering = (AnisotropicFiltering)LuaDLL.luaL_checknumber(L, 2);
			Texture.anisotropicFiltering = anisotropicFiltering;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_width(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Texture texture = (Texture)obj;
			int width = (int)LuaDLL.luaL_checknumber(L, 2);
			texture.width = width;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index width on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_height(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Texture texture = (Texture)obj;
			int height = (int)LuaDLL.luaL_checknumber(L, 2);
			texture.height = height;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index height on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_filterMode(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Texture texture = (Texture)obj;
			FilterMode filterMode = (FilterMode)LuaDLL.luaL_checknumber(L, 2);
			texture.filterMode = filterMode;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index filterMode on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_anisoLevel(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Texture texture = (Texture)obj;
			int anisoLevel = (int)LuaDLL.luaL_checknumber(L, 2);
			texture.anisoLevel = anisoLevel;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index anisoLevel on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_wrapMode(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Texture texture = (Texture)obj;
			TextureWrapMode wrapMode = (TextureWrapMode)LuaDLL.luaL_checknumber(L, 2);
			texture.wrapMode = wrapMode;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index wrapMode on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_mipMapBias(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Texture texture = (Texture)obj;
			float mipMapBias = (float)LuaDLL.luaL_checknumber(L, 2);
			texture.mipMapBias = mipMapBias;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index mipMapBias on a nil value");
		}
		return result;
	}
}
