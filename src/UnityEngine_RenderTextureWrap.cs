using LuaInterface;
using System;
using UnityEngine;

public class UnityEngine_RenderTextureWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(RenderTexture), typeof(Texture), null);
		L.RegFunction("GetTemporary", new LuaCSFunction(UnityEngine_RenderTextureWrap.GetTemporary));
		L.RegFunction("ReleaseTemporary", new LuaCSFunction(UnityEngine_RenderTextureWrap.ReleaseTemporary));
		L.RegFunction("Create", new LuaCSFunction(UnityEngine_RenderTextureWrap.Create));
		L.RegFunction("Release", new LuaCSFunction(UnityEngine_RenderTextureWrap.Release));
		L.RegFunction("IsCreated", new LuaCSFunction(UnityEngine_RenderTextureWrap.IsCreated));
		L.RegFunction("DiscardContents", new LuaCSFunction(UnityEngine_RenderTextureWrap.DiscardContents));
		L.RegFunction("MarkRestoreExpected", new LuaCSFunction(UnityEngine_RenderTextureWrap.MarkRestoreExpected));
		L.RegFunction("SetGlobalShaderProperty", new LuaCSFunction(UnityEngine_RenderTextureWrap.SetGlobalShaderProperty));
		L.RegFunction("GetTexelOffset", new LuaCSFunction(UnityEngine_RenderTextureWrap.GetTexelOffset));
		L.RegFunction("SupportsStencil", new LuaCSFunction(UnityEngine_RenderTextureWrap.SupportsStencil));
		L.RegFunction("New", new LuaCSFunction(UnityEngine_RenderTextureWrap._CreateUnityEngine_RenderTexture));
		L.RegFunction("__eq", new LuaCSFunction(UnityEngine_RenderTextureWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("width", new LuaCSFunction(UnityEngine_RenderTextureWrap.get_width), new LuaCSFunction(UnityEngine_RenderTextureWrap.set_width));
		L.RegVar("height", new LuaCSFunction(UnityEngine_RenderTextureWrap.get_height), new LuaCSFunction(UnityEngine_RenderTextureWrap.set_height));
		L.RegVar("depth", new LuaCSFunction(UnityEngine_RenderTextureWrap.get_depth), new LuaCSFunction(UnityEngine_RenderTextureWrap.set_depth));
		L.RegVar("isPowerOfTwo", new LuaCSFunction(UnityEngine_RenderTextureWrap.get_isPowerOfTwo), new LuaCSFunction(UnityEngine_RenderTextureWrap.set_isPowerOfTwo));
		L.RegVar("sRGB", new LuaCSFunction(UnityEngine_RenderTextureWrap.get_sRGB), null);
		L.RegVar("format", new LuaCSFunction(UnityEngine_RenderTextureWrap.get_format), new LuaCSFunction(UnityEngine_RenderTextureWrap.set_format));
		L.RegVar("useMipMap", new LuaCSFunction(UnityEngine_RenderTextureWrap.get_useMipMap), new LuaCSFunction(UnityEngine_RenderTextureWrap.set_useMipMap));
		L.RegVar("generateMips", new LuaCSFunction(UnityEngine_RenderTextureWrap.get_generateMips), new LuaCSFunction(UnityEngine_RenderTextureWrap.set_generateMips));
		L.RegVar("isCubemap", new LuaCSFunction(UnityEngine_RenderTextureWrap.get_isCubemap), new LuaCSFunction(UnityEngine_RenderTextureWrap.set_isCubemap));
		L.RegVar("isVolume", new LuaCSFunction(UnityEngine_RenderTextureWrap.get_isVolume), new LuaCSFunction(UnityEngine_RenderTextureWrap.set_isVolume));
		L.RegVar("volumeDepth", new LuaCSFunction(UnityEngine_RenderTextureWrap.get_volumeDepth), new LuaCSFunction(UnityEngine_RenderTextureWrap.set_volumeDepth));
		L.RegVar("antiAliasing", new LuaCSFunction(UnityEngine_RenderTextureWrap.get_antiAliasing), new LuaCSFunction(UnityEngine_RenderTextureWrap.set_antiAliasing));
		L.RegVar("enableRandomWrite", new LuaCSFunction(UnityEngine_RenderTextureWrap.get_enableRandomWrite), new LuaCSFunction(UnityEngine_RenderTextureWrap.set_enableRandomWrite));
		L.RegVar("colorBuffer", new LuaCSFunction(UnityEngine_RenderTextureWrap.get_colorBuffer), null);
		L.RegVar("depthBuffer", new LuaCSFunction(UnityEngine_RenderTextureWrap.get_depthBuffer), null);
		L.RegVar("active", new LuaCSFunction(UnityEngine_RenderTextureWrap.get_active), new LuaCSFunction(UnityEngine_RenderTextureWrap.set_active));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateUnityEngine_RenderTexture(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 3)
			{
				int width = (int)LuaDLL.luaL_checknumber(L, 1);
				int height = (int)LuaDLL.luaL_checknumber(L, 2);
				int depth = (int)LuaDLL.luaL_checknumber(L, 3);
				RenderTexture obj = new RenderTexture(width, height, depth);
				ToLua.Push(L, obj);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(int), typeof(int), typeof(int), typeof(uint)))
			{
				int width2 = (int)LuaDLL.luaL_checknumber(L, 1);
				int height2 = (int)LuaDLL.luaL_checknumber(L, 2);
				int depth2 = (int)LuaDLL.luaL_checknumber(L, 3);
				RenderTextureFormat format = (RenderTextureFormat)LuaDLL.luaL_checknumber(L, 4);
				RenderTexture obj2 = new RenderTexture(width2, height2, depth2, format);
				ToLua.Push(L, obj2);
				result = 1;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(int), typeof(int), typeof(int), typeof(uint), typeof(uint)))
			{
				int width3 = (int)LuaDLL.luaL_checknumber(L, 1);
				int height3 = (int)LuaDLL.luaL_checknumber(L, 2);
				int depth3 = (int)LuaDLL.luaL_checknumber(L, 3);
				RenderTextureFormat format2 = (RenderTextureFormat)LuaDLL.luaL_checknumber(L, 4);
				RenderTextureReadWrite readWrite = (RenderTextureReadWrite)LuaDLL.luaL_checknumber(L, 5);
				RenderTexture obj3 = new RenderTexture(width3, height3, depth3, format2, readWrite);
				ToLua.Push(L, obj3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: UnityEngine.RenderTexture.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetTemporary(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(int), typeof(int)))
			{
				int width = (int)LuaDLL.lua_tonumber(L, 1);
				int height = (int)LuaDLL.lua_tonumber(L, 2);
				RenderTexture temporary = RenderTexture.GetTemporary(width, height);
				ToLua.Push(L, temporary);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(int), typeof(int), typeof(int)))
			{
				int width2 = (int)LuaDLL.lua_tonumber(L, 1);
				int height2 = (int)LuaDLL.lua_tonumber(L, 2);
				int depthBuffer = (int)LuaDLL.lua_tonumber(L, 3);
				RenderTexture temporary2 = RenderTexture.GetTemporary(width2, height2, depthBuffer);
				ToLua.Push(L, temporary2);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(int), typeof(int), typeof(int), typeof(uint)))
			{
				int width3 = (int)LuaDLL.lua_tonumber(L, 1);
				int height3 = (int)LuaDLL.lua_tonumber(L, 2);
				int depthBuffer2 = (int)LuaDLL.lua_tonumber(L, 3);
				RenderTextureFormat format = (RenderTextureFormat)LuaDLL.lua_tonumber(L, 4);
				RenderTexture temporary3 = RenderTexture.GetTemporary(width3, height3, depthBuffer2, format);
				ToLua.Push(L, temporary3);
				result = 1;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(int), typeof(int), typeof(int), typeof(uint), typeof(uint)))
			{
				int width4 = (int)LuaDLL.lua_tonumber(L, 1);
				int height4 = (int)LuaDLL.lua_tonumber(L, 2);
				int depthBuffer3 = (int)LuaDLL.lua_tonumber(L, 3);
				RenderTextureFormat format2 = (RenderTextureFormat)LuaDLL.lua_tonumber(L, 4);
				RenderTextureReadWrite readWrite = (RenderTextureReadWrite)LuaDLL.lua_tonumber(L, 5);
				RenderTexture temporary4 = RenderTexture.GetTemporary(width4, height4, depthBuffer3, format2, readWrite);
				ToLua.Push(L, temporary4);
				result = 1;
			}
			else if (num == 6 && TypeChecker.CheckTypes(L, 1, typeof(int), typeof(int), typeof(int), typeof(uint), typeof(uint), typeof(int)))
			{
				int width5 = (int)LuaDLL.lua_tonumber(L, 1);
				int height5 = (int)LuaDLL.lua_tonumber(L, 2);
				int depthBuffer4 = (int)LuaDLL.lua_tonumber(L, 3);
				RenderTextureFormat format3 = (RenderTextureFormat)LuaDLL.lua_tonumber(L, 4);
				RenderTextureReadWrite readWrite2 = (RenderTextureReadWrite)LuaDLL.lua_tonumber(L, 5);
				int antiAliasing = (int)LuaDLL.lua_tonumber(L, 6);
				RenderTexture temporary5 = RenderTexture.GetTemporary(width5, height5, depthBuffer4, format3, readWrite2, antiAliasing);
				ToLua.Push(L, temporary5);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.RenderTexture.GetTemporary");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ReleaseTemporary(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			RenderTexture temp = (RenderTexture)ToLua.CheckUnityObject(L, 1, typeof(RenderTexture));
			RenderTexture.ReleaseTemporary(temp);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Create(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			RenderTexture renderTexture = (RenderTexture)ToLua.CheckObject(L, 1, typeof(RenderTexture));
			bool value = renderTexture.Create();
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
	private static int Release(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			RenderTexture renderTexture = (RenderTexture)ToLua.CheckObject(L, 1, typeof(RenderTexture));
			renderTexture.Release();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsCreated(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			RenderTexture renderTexture = (RenderTexture)ToLua.CheckObject(L, 1, typeof(RenderTexture));
			bool value = renderTexture.IsCreated();
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
	private static int DiscardContents(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(RenderTexture)))
			{
				RenderTexture renderTexture = (RenderTexture)ToLua.ToObject(L, 1);
				renderTexture.DiscardContents();
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(RenderTexture), typeof(bool), typeof(bool)))
			{
				RenderTexture renderTexture2 = (RenderTexture)ToLua.ToObject(L, 1);
				bool discardColor = LuaDLL.lua_toboolean(L, 2);
				bool discardDepth = LuaDLL.lua_toboolean(L, 3);
				renderTexture2.DiscardContents(discardColor, discardDepth);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.RenderTexture.DiscardContents");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int MarkRestoreExpected(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			RenderTexture renderTexture = (RenderTexture)ToLua.CheckObject(L, 1, typeof(RenderTexture));
			renderTexture.MarkRestoreExpected();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetGlobalShaderProperty(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			RenderTexture renderTexture = (RenderTexture)ToLua.CheckObject(L, 1, typeof(RenderTexture));
			string globalShaderProperty = ToLua.CheckString(L, 2);
			renderTexture.SetGlobalShaderProperty(globalShaderProperty);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetTexelOffset(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			RenderTexture renderTexture = (RenderTexture)ToLua.CheckObject(L, 1, typeof(RenderTexture));
			Vector2 texelOffset = renderTexture.GetTexelOffset();
			ToLua.Push(L, texelOffset);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SupportsStencil(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			RenderTexture rt = (RenderTexture)ToLua.CheckUnityObject(L, 1, typeof(RenderTexture));
			bool value = RenderTexture.SupportsStencil(rt);
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

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_width(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RenderTexture renderTexture = (RenderTexture)obj;
			int width = renderTexture.width;
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
			RenderTexture renderTexture = (RenderTexture)obj;
			int height = renderTexture.height;
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
	private static int get_depth(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RenderTexture renderTexture = (RenderTexture)obj;
			int depth = renderTexture.depth;
			LuaDLL.lua_pushinteger(L, depth);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index depth on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isPowerOfTwo(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RenderTexture renderTexture = (RenderTexture)obj;
			bool isPowerOfTwo = renderTexture.isPowerOfTwo;
			LuaDLL.lua_pushboolean(L, isPowerOfTwo);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isPowerOfTwo on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_sRGB(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RenderTexture renderTexture = (RenderTexture)obj;
			bool sRGB = renderTexture.sRGB;
			LuaDLL.lua_pushboolean(L, sRGB);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index sRGB on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_format(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RenderTexture renderTexture = (RenderTexture)obj;
			RenderTextureFormat format = renderTexture.format;
			ToLua.Push(L, format);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index format on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_useMipMap(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RenderTexture renderTexture = (RenderTexture)obj;
			bool useMipMap = renderTexture.useMipMap;
			LuaDLL.lua_pushboolean(L, useMipMap);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index useMipMap on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_generateMips(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RenderTexture renderTexture = (RenderTexture)obj;
			bool generateMips = renderTexture.generateMips;
			LuaDLL.lua_pushboolean(L, generateMips);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index generateMips on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isCubemap(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RenderTexture renderTexture = (RenderTexture)obj;
			bool isCubemap = renderTexture.isCubemap;
			LuaDLL.lua_pushboolean(L, isCubemap);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isCubemap on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isVolume(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RenderTexture renderTexture = (RenderTexture)obj;
			bool isVolume = renderTexture.isVolume;
			LuaDLL.lua_pushboolean(L, isVolume);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isVolume on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_volumeDepth(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RenderTexture renderTexture = (RenderTexture)obj;
			int volumeDepth = renderTexture.volumeDepth;
			LuaDLL.lua_pushinteger(L, volumeDepth);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index volumeDepth on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_antiAliasing(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RenderTexture renderTexture = (RenderTexture)obj;
			int antiAliasing = renderTexture.antiAliasing;
			LuaDLL.lua_pushinteger(L, antiAliasing);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index antiAliasing on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_enableRandomWrite(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RenderTexture renderTexture = (RenderTexture)obj;
			bool enableRandomWrite = renderTexture.enableRandomWrite;
			LuaDLL.lua_pushboolean(L, enableRandomWrite);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index enableRandomWrite on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_colorBuffer(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RenderTexture renderTexture = (RenderTexture)obj;
			RenderBuffer colorBuffer = renderTexture.colorBuffer;
			ToLua.PushValue(L, colorBuffer);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index colorBuffer on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_depthBuffer(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RenderTexture renderTexture = (RenderTexture)obj;
			RenderBuffer depthBuffer = renderTexture.depthBuffer;
			ToLua.PushValue(L, depthBuffer);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index depthBuffer on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_active(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, RenderTexture.active);
			result = 1;
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
			RenderTexture renderTexture = (RenderTexture)obj;
			int width = (int)LuaDLL.luaL_checknumber(L, 2);
			renderTexture.width = width;
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
			RenderTexture renderTexture = (RenderTexture)obj;
			int height = (int)LuaDLL.luaL_checknumber(L, 2);
			renderTexture.height = height;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index height on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_depth(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RenderTexture renderTexture = (RenderTexture)obj;
			int depth = (int)LuaDLL.luaL_checknumber(L, 2);
			renderTexture.depth = depth;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index depth on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_isPowerOfTwo(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RenderTexture renderTexture = (RenderTexture)obj;
			bool isPowerOfTwo = LuaDLL.luaL_checkboolean(L, 2);
			renderTexture.isPowerOfTwo = isPowerOfTwo;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isPowerOfTwo on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_format(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RenderTexture renderTexture = (RenderTexture)obj;
			RenderTextureFormat format = (RenderTextureFormat)LuaDLL.luaL_checknumber(L, 2);
			renderTexture.format = format;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index format on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_useMipMap(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RenderTexture renderTexture = (RenderTexture)obj;
			bool useMipMap = LuaDLL.luaL_checkboolean(L, 2);
			renderTexture.useMipMap = useMipMap;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index useMipMap on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_generateMips(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RenderTexture renderTexture = (RenderTexture)obj;
			bool generateMips = LuaDLL.luaL_checkboolean(L, 2);
			renderTexture.generateMips = generateMips;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index generateMips on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_isCubemap(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RenderTexture renderTexture = (RenderTexture)obj;
			bool isCubemap = LuaDLL.luaL_checkboolean(L, 2);
			renderTexture.isCubemap = isCubemap;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isCubemap on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_isVolume(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RenderTexture renderTexture = (RenderTexture)obj;
			bool isVolume = LuaDLL.luaL_checkboolean(L, 2);
			renderTexture.isVolume = isVolume;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isVolume on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_volumeDepth(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RenderTexture renderTexture = (RenderTexture)obj;
			int volumeDepth = (int)LuaDLL.luaL_checknumber(L, 2);
			renderTexture.volumeDepth = volumeDepth;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index volumeDepth on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_antiAliasing(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RenderTexture renderTexture = (RenderTexture)obj;
			int antiAliasing = (int)LuaDLL.luaL_checknumber(L, 2);
			renderTexture.antiAliasing = antiAliasing;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index antiAliasing on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_enableRandomWrite(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RenderTexture renderTexture = (RenderTexture)obj;
			bool enableRandomWrite = LuaDLL.luaL_checkboolean(L, 2);
			renderTexture.enableRandomWrite = enableRandomWrite;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index enableRandomWrite on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_active(IntPtr L)
	{
		int result;
		try
		{
			RenderTexture active = (RenderTexture)ToLua.CheckUnityObject(L, 2, typeof(RenderTexture));
			RenderTexture.active = active;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
