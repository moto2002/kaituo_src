using LuaInterface;
using System;
using UnityEngine;

public class UnityEngine_Texture2DWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Texture2D), typeof(Texture), null);
		L.RegFunction("CreateExternalTexture", new LuaCSFunction(UnityEngine_Texture2DWrap.CreateExternalTexture));
		L.RegFunction("UpdateExternalTexture", new LuaCSFunction(UnityEngine_Texture2DWrap.UpdateExternalTexture));
		L.RegFunction("SetPixel", new LuaCSFunction(UnityEngine_Texture2DWrap.SetPixel));
		L.RegFunction("GetPixel", new LuaCSFunction(UnityEngine_Texture2DWrap.GetPixel));
		L.RegFunction("GetPixelBilinear", new LuaCSFunction(UnityEngine_Texture2DWrap.GetPixelBilinear));
		L.RegFunction("SetPixels", new LuaCSFunction(UnityEngine_Texture2DWrap.SetPixels));
		L.RegFunction("SetPixels32", new LuaCSFunction(UnityEngine_Texture2DWrap.SetPixels32));
		L.RegFunction("LoadImage", new LuaCSFunction(UnityEngine_Texture2DWrap.LoadImage));
		L.RegFunction("LoadRawTextureData", new LuaCSFunction(UnityEngine_Texture2DWrap.LoadRawTextureData));
		L.RegFunction("GetRawTextureData", new LuaCSFunction(UnityEngine_Texture2DWrap.GetRawTextureData));
		L.RegFunction("GetPixels", new LuaCSFunction(UnityEngine_Texture2DWrap.GetPixels));
		L.RegFunction("GetPixels32", new LuaCSFunction(UnityEngine_Texture2DWrap.GetPixels32));
		L.RegFunction("Apply", new LuaCSFunction(UnityEngine_Texture2DWrap.Apply));
		L.RegFunction("Resize", new LuaCSFunction(UnityEngine_Texture2DWrap.Resize));
		L.RegFunction("Compress", new LuaCSFunction(UnityEngine_Texture2DWrap.Compress));
		L.RegFunction("PackTextures", new LuaCSFunction(UnityEngine_Texture2DWrap.PackTextures));
		L.RegFunction("ReadPixels", new LuaCSFunction(UnityEngine_Texture2DWrap.ReadPixels));
		L.RegFunction("EncodeToPNG", new LuaCSFunction(UnityEngine_Texture2DWrap.EncodeToPNG));
		L.RegFunction("EncodeToJPG", new LuaCSFunction(UnityEngine_Texture2DWrap.EncodeToJPG));
		L.RegFunction("New", new LuaCSFunction(UnityEngine_Texture2DWrap._CreateUnityEngine_Texture2D));
		L.RegFunction("__eq", new LuaCSFunction(UnityEngine_Texture2DWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("mipmapCount", new LuaCSFunction(UnityEngine_Texture2DWrap.get_mipmapCount), null);
		L.RegVar("format", new LuaCSFunction(UnityEngine_Texture2DWrap.get_format), null);
		L.RegVar("whiteTexture", new LuaCSFunction(UnityEngine_Texture2DWrap.get_whiteTexture), null);
		L.RegVar("blackTexture", new LuaCSFunction(UnityEngine_Texture2DWrap.get_blackTexture), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateUnityEngine_Texture2D(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2)
			{
				int width = (int)LuaDLL.luaL_checknumber(L, 1);
				int height = (int)LuaDLL.luaL_checknumber(L, 2);
				Texture2D obj = new Texture2D(width, height);
				ToLua.Push(L, obj);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(int), typeof(int), typeof(uint), typeof(bool)))
			{
				int width2 = (int)LuaDLL.luaL_checknumber(L, 1);
				int height2 = (int)LuaDLL.luaL_checknumber(L, 2);
				TextureFormat format = (TextureFormat)LuaDLL.luaL_checknumber(L, 3);
				bool mipmap = LuaDLL.luaL_checkboolean(L, 4);
				Texture2D obj2 = new Texture2D(width2, height2, format, mipmap);
				ToLua.Push(L, obj2);
				result = 1;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(int), typeof(int), typeof(uint), typeof(bool), typeof(bool)))
			{
				int width3 = (int)LuaDLL.luaL_checknumber(L, 1);
				int height3 = (int)LuaDLL.luaL_checknumber(L, 2);
				TextureFormat format2 = (TextureFormat)LuaDLL.luaL_checknumber(L, 3);
				bool mipmap2 = LuaDLL.luaL_checkboolean(L, 4);
				bool linear = LuaDLL.luaL_checkboolean(L, 5);
				Texture2D obj3 = new Texture2D(width3, height3, format2, mipmap2, linear);
				ToLua.Push(L, obj3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: UnityEngine.Texture2D.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CreateExternalTexture(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 6);
			int width = (int)LuaDLL.luaL_checknumber(L, 1);
			int height = (int)LuaDLL.luaL_checknumber(L, 2);
			TextureFormat format = (TextureFormat)LuaDLL.luaL_checknumber(L, 3);
			bool mipmap = LuaDLL.luaL_checkboolean(L, 4);
			bool linear = LuaDLL.luaL_checkboolean(L, 5);
			IntPtr nativeTex = LuaDLL.lua_touserdata(L, 6);
			Texture2D obj = Texture2D.CreateExternalTexture(width, height, format, mipmap, linear, nativeTex);
			ToLua.Push(L, obj);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UpdateExternalTexture(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Texture2D texture2D = (Texture2D)ToLua.CheckObject(L, 1, typeof(Texture2D));
			IntPtr nativeTex = LuaDLL.lua_touserdata(L, 2);
			texture2D.UpdateExternalTexture(nativeTex);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetPixel(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			Texture2D texture2D = (Texture2D)ToLua.CheckObject(L, 1, typeof(Texture2D));
			int x = (int)LuaDLL.luaL_checknumber(L, 2);
			int y = (int)LuaDLL.luaL_checknumber(L, 3);
			Color color = ToLua.ToColor(L, 4);
			texture2D.SetPixel(x, y, color);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetPixel(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Texture2D texture2D = (Texture2D)ToLua.CheckObject(L, 1, typeof(Texture2D));
			int x = (int)LuaDLL.luaL_checknumber(L, 2);
			int y = (int)LuaDLL.luaL_checknumber(L, 3);
			Color pixel = texture2D.GetPixel(x, y);
			ToLua.Push(L, pixel);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetPixelBilinear(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Texture2D texture2D = (Texture2D)ToLua.CheckObject(L, 1, typeof(Texture2D));
			float u = (float)LuaDLL.luaL_checknumber(L, 2);
			float v = (float)LuaDLL.luaL_checknumber(L, 3);
			Color pixelBilinear = texture2D.GetPixelBilinear(u, v);
			ToLua.Push(L, pixelBilinear);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetPixels(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Texture2D), typeof(Color[])))
			{
				Texture2D texture2D = (Texture2D)ToLua.ToObject(L, 1);
				Color[] pixels = ToLua.CheckObjectArray<Color>(L, 2);
				texture2D.SetPixels(pixels);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Texture2D), typeof(Color[]), typeof(int)))
			{
				Texture2D texture2D2 = (Texture2D)ToLua.ToObject(L, 1);
				Color[] colors = ToLua.CheckObjectArray<Color>(L, 2);
				int miplevel = (int)LuaDLL.lua_tonumber(L, 3);
				texture2D2.SetPixels(colors, miplevel);
				result = 0;
			}
			else if (num == 6 && TypeChecker.CheckTypes(L, 1, typeof(Texture2D), typeof(int), typeof(int), typeof(int), typeof(int), typeof(Color[])))
			{
				Texture2D texture2D3 = (Texture2D)ToLua.ToObject(L, 1);
				int x = (int)LuaDLL.lua_tonumber(L, 2);
				int y = (int)LuaDLL.lua_tonumber(L, 3);
				int blockWidth = (int)LuaDLL.lua_tonumber(L, 4);
				int blockHeight = (int)LuaDLL.lua_tonumber(L, 5);
				Color[] colors2 = ToLua.CheckObjectArray<Color>(L, 6);
				texture2D3.SetPixels(x, y, blockWidth, blockHeight, colors2);
				result = 0;
			}
			else if (num == 7 && TypeChecker.CheckTypes(L, 1, typeof(Texture2D), typeof(int), typeof(int), typeof(int), typeof(int), typeof(Color[]), typeof(int)))
			{
				Texture2D texture2D4 = (Texture2D)ToLua.ToObject(L, 1);
				int x2 = (int)LuaDLL.lua_tonumber(L, 2);
				int y2 = (int)LuaDLL.lua_tonumber(L, 3);
				int blockWidth2 = (int)LuaDLL.lua_tonumber(L, 4);
				int blockHeight2 = (int)LuaDLL.lua_tonumber(L, 5);
				Color[] colors3 = ToLua.CheckObjectArray<Color>(L, 6);
				int miplevel2 = (int)LuaDLL.lua_tonumber(L, 7);
				texture2D4.SetPixels(x2, y2, blockWidth2, blockHeight2, colors3, miplevel2);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Texture2D.SetPixels");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetPixels32(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Texture2D), typeof(Color32[])))
			{
				Texture2D texture2D = (Texture2D)ToLua.ToObject(L, 1);
				Color32[] pixels = ToLua.CheckObjectArray<Color32>(L, 2);
				texture2D.SetPixels32(pixels);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Texture2D), typeof(Color32[]), typeof(int)))
			{
				Texture2D texture2D2 = (Texture2D)ToLua.ToObject(L, 1);
				Color32[] colors = ToLua.CheckObjectArray<Color32>(L, 2);
				int miplevel = (int)LuaDLL.lua_tonumber(L, 3);
				texture2D2.SetPixels32(colors, miplevel);
				result = 0;
			}
			else if (num == 6 && TypeChecker.CheckTypes(L, 1, typeof(Texture2D), typeof(int), typeof(int), typeof(int), typeof(int), typeof(Color32[])))
			{
				Texture2D texture2D3 = (Texture2D)ToLua.ToObject(L, 1);
				int x = (int)LuaDLL.lua_tonumber(L, 2);
				int y = (int)LuaDLL.lua_tonumber(L, 3);
				int blockWidth = (int)LuaDLL.lua_tonumber(L, 4);
				int blockHeight = (int)LuaDLL.lua_tonumber(L, 5);
				Color32[] colors2 = ToLua.CheckObjectArray<Color32>(L, 6);
				texture2D3.SetPixels32(x, y, blockWidth, blockHeight, colors2);
				result = 0;
			}
			else if (num == 7 && TypeChecker.CheckTypes(L, 1, typeof(Texture2D), typeof(int), typeof(int), typeof(int), typeof(int), typeof(Color32[]), typeof(int)))
			{
				Texture2D texture2D4 = (Texture2D)ToLua.ToObject(L, 1);
				int x2 = (int)LuaDLL.lua_tonumber(L, 2);
				int y2 = (int)LuaDLL.lua_tonumber(L, 3);
				int blockWidth2 = (int)LuaDLL.lua_tonumber(L, 4);
				int blockHeight2 = (int)LuaDLL.lua_tonumber(L, 5);
				Color32[] colors3 = ToLua.CheckObjectArray<Color32>(L, 6);
				int miplevel2 = (int)LuaDLL.lua_tonumber(L, 7);
				texture2D4.SetPixels32(x2, y2, blockWidth2, blockHeight2, colors3, miplevel2);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Texture2D.SetPixels32");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LoadImage(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Texture2D), typeof(byte[])))
			{
				Texture2D texture2D = (Texture2D)ToLua.ToObject(L, 1);
				byte[] data = ToLua.CheckByteBuffer(L, 2);
				bool value = texture2D.LoadImage(data);
				LuaDLL.lua_pushboolean(L, value);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Texture2D), typeof(byte[]), typeof(bool)))
			{
				Texture2D texture2D2 = (Texture2D)ToLua.ToObject(L, 1);
				byte[] data2 = ToLua.CheckByteBuffer(L, 2);
				bool markNonReadable = LuaDLL.lua_toboolean(L, 3);
				bool value2 = texture2D2.LoadImage(data2, markNonReadable);
				LuaDLL.lua_pushboolean(L, value2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Texture2D.LoadImage");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LoadRawTextureData(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Texture2D), typeof(byte[])))
			{
				Texture2D texture2D = (Texture2D)ToLua.ToObject(L, 1);
				byte[] data = ToLua.CheckByteBuffer(L, 2);
				texture2D.LoadRawTextureData(data);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Texture2D), typeof(IntPtr), typeof(int)))
			{
				Texture2D texture2D2 = (Texture2D)ToLua.ToObject(L, 1);
				IntPtr data2 = LuaDLL.lua_touserdata(L, 2);
				int size = (int)LuaDLL.lua_tonumber(L, 3);
				texture2D2.LoadRawTextureData(data2, size);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Texture2D.LoadRawTextureData");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetRawTextureData(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Texture2D texture2D = (Texture2D)ToLua.CheckObject(L, 1, typeof(Texture2D));
			byte[] rawTextureData = texture2D.GetRawTextureData();
			ToLua.Push(L, rawTextureData);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetPixels(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(Texture2D)))
			{
				Texture2D texture2D = (Texture2D)ToLua.ToObject(L, 1);
				Color[] pixels = texture2D.GetPixels();
				ToLua.Push(L, pixels);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Texture2D), typeof(int)))
			{
				Texture2D texture2D2 = (Texture2D)ToLua.ToObject(L, 1);
				int miplevel = (int)LuaDLL.lua_tonumber(L, 2);
				Color[] pixels2 = texture2D2.GetPixels(miplevel);
				ToLua.Push(L, pixels2);
				result = 1;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Texture2D), typeof(int), typeof(int), typeof(int), typeof(int)))
			{
				Texture2D texture2D3 = (Texture2D)ToLua.ToObject(L, 1);
				int x = (int)LuaDLL.lua_tonumber(L, 2);
				int y = (int)LuaDLL.lua_tonumber(L, 3);
				int blockWidth = (int)LuaDLL.lua_tonumber(L, 4);
				int blockHeight = (int)LuaDLL.lua_tonumber(L, 5);
				Color[] pixels3 = texture2D3.GetPixels(x, y, blockWidth, blockHeight);
				ToLua.Push(L, pixels3);
				result = 1;
			}
			else if (num == 6 && TypeChecker.CheckTypes(L, 1, typeof(Texture2D), typeof(int), typeof(int), typeof(int), typeof(int), typeof(int)))
			{
				Texture2D texture2D4 = (Texture2D)ToLua.ToObject(L, 1);
				int x2 = (int)LuaDLL.lua_tonumber(L, 2);
				int y2 = (int)LuaDLL.lua_tonumber(L, 3);
				int blockWidth2 = (int)LuaDLL.lua_tonumber(L, 4);
				int blockHeight2 = (int)LuaDLL.lua_tonumber(L, 5);
				int miplevel2 = (int)LuaDLL.lua_tonumber(L, 6);
				Color[] pixels4 = texture2D4.GetPixels(x2, y2, blockWidth2, blockHeight2, miplevel2);
				ToLua.Push(L, pixels4);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Texture2D.GetPixels");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetPixels32(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(Texture2D)))
			{
				Texture2D texture2D = (Texture2D)ToLua.ToObject(L, 1);
				Color32[] pixels = texture2D.GetPixels32();
				ToLua.Push(L, pixels);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Texture2D), typeof(int)))
			{
				Texture2D texture2D2 = (Texture2D)ToLua.ToObject(L, 1);
				int miplevel = (int)LuaDLL.lua_tonumber(L, 2);
				Color32[] pixels2 = texture2D2.GetPixels32(miplevel);
				ToLua.Push(L, pixels2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Texture2D.GetPixels32");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Apply(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(Texture2D)))
			{
				Texture2D texture2D = (Texture2D)ToLua.ToObject(L, 1);
				texture2D.Apply();
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Texture2D), typeof(bool)))
			{
				Texture2D texture2D2 = (Texture2D)ToLua.ToObject(L, 1);
				bool updateMipmaps = LuaDLL.lua_toboolean(L, 2);
				texture2D2.Apply(updateMipmaps);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Texture2D), typeof(bool), typeof(bool)))
			{
				Texture2D texture2D3 = (Texture2D)ToLua.ToObject(L, 1);
				bool updateMipmaps2 = LuaDLL.lua_toboolean(L, 2);
				bool makeNoLongerReadable = LuaDLL.lua_toboolean(L, 3);
				texture2D3.Apply(updateMipmaps2, makeNoLongerReadable);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Texture2D.Apply");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Resize(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Texture2D), typeof(int), typeof(int)))
			{
				Texture2D texture2D = (Texture2D)ToLua.ToObject(L, 1);
				int width = (int)LuaDLL.lua_tonumber(L, 2);
				int height = (int)LuaDLL.lua_tonumber(L, 3);
				bool value = texture2D.Resize(width, height);
				LuaDLL.lua_pushboolean(L, value);
				result = 1;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Texture2D), typeof(int), typeof(int), typeof(uint), typeof(bool)))
			{
				Texture2D texture2D2 = (Texture2D)ToLua.ToObject(L, 1);
				int width2 = (int)LuaDLL.lua_tonumber(L, 2);
				int height2 = (int)LuaDLL.lua_tonumber(L, 3);
				TextureFormat format = (TextureFormat)LuaDLL.lua_tonumber(L, 4);
				bool hasMipMap = LuaDLL.lua_toboolean(L, 5);
				bool value2 = texture2D2.Resize(width2, height2, format, hasMipMap);
				LuaDLL.lua_pushboolean(L, value2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Texture2D.Resize");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Compress(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Texture2D texture2D = (Texture2D)ToLua.CheckObject(L, 1, typeof(Texture2D));
			bool highQuality = LuaDLL.luaL_checkboolean(L, 2);
			texture2D.Compress(highQuality);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PackTextures(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Texture2D), typeof(Texture2D[]), typeof(int)))
			{
				Texture2D texture2D = (Texture2D)ToLua.ToObject(L, 1);
				Texture2D[] textures = ToLua.CheckObjectArray<Texture2D>(L, 2);
				int padding = (int)LuaDLL.lua_tonumber(L, 3);
				Rect[] array = texture2D.PackTextures(textures, padding);
				ToLua.Push(L, array);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Texture2D), typeof(Texture2D[]), typeof(int), typeof(int)))
			{
				Texture2D texture2D2 = (Texture2D)ToLua.ToObject(L, 1);
				Texture2D[] textures2 = ToLua.CheckObjectArray<Texture2D>(L, 2);
				int padding2 = (int)LuaDLL.lua_tonumber(L, 3);
				int maximumAtlasSize = (int)LuaDLL.lua_tonumber(L, 4);
				Rect[] array2 = texture2D2.PackTextures(textures2, padding2, maximumAtlasSize);
				ToLua.Push(L, array2);
				result = 1;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Texture2D), typeof(Texture2D[]), typeof(int), typeof(int), typeof(bool)))
			{
				Texture2D texture2D3 = (Texture2D)ToLua.ToObject(L, 1);
				Texture2D[] textures3 = ToLua.CheckObjectArray<Texture2D>(L, 2);
				int padding3 = (int)LuaDLL.lua_tonumber(L, 3);
				int maximumAtlasSize2 = (int)LuaDLL.lua_tonumber(L, 4);
				bool makeNoLongerReadable = LuaDLL.lua_toboolean(L, 5);
				Rect[] array3 = texture2D3.PackTextures(textures3, padding3, maximumAtlasSize2, makeNoLongerReadable);
				ToLua.Push(L, array3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Texture2D.PackTextures");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ReadPixels(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Texture2D), typeof(Rect), typeof(int), typeof(int)))
			{
				Texture2D texture2D = (Texture2D)ToLua.ToObject(L, 1);
				Rect source = (Rect)ToLua.ToObject(L, 2);
				int destX = (int)LuaDLL.lua_tonumber(L, 3);
				int destY = (int)LuaDLL.lua_tonumber(L, 4);
				texture2D.ReadPixels(source, destX, destY);
				result = 0;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Texture2D), typeof(Rect), typeof(int), typeof(int), typeof(bool)))
			{
				Texture2D texture2D2 = (Texture2D)ToLua.ToObject(L, 1);
				Rect source2 = (Rect)ToLua.ToObject(L, 2);
				int destX2 = (int)LuaDLL.lua_tonumber(L, 3);
				int destY2 = (int)LuaDLL.lua_tonumber(L, 4);
				bool recalculateMipMaps = LuaDLL.lua_toboolean(L, 5);
				texture2D2.ReadPixels(source2, destX2, destY2, recalculateMipMaps);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Texture2D.ReadPixels");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int EncodeToPNG(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Texture2D texture2D = (Texture2D)ToLua.CheckObject(L, 1, typeof(Texture2D));
			byte[] array = texture2D.EncodeToPNG();
			ToLua.Push(L, array);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int EncodeToJPG(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(Texture2D)))
			{
				Texture2D texture2D = (Texture2D)ToLua.ToObject(L, 1);
				byte[] array = texture2D.EncodeToJPG();
				ToLua.Push(L, array);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Texture2D), typeof(int)))
			{
				Texture2D texture2D2 = (Texture2D)ToLua.ToObject(L, 1);
				int quality = (int)LuaDLL.lua_tonumber(L, 2);
				byte[] array2 = texture2D2.EncodeToJPG(quality);
				ToLua.Push(L, array2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Texture2D.EncodeToJPG");
			}
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
	private static int get_mipmapCount(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Texture2D texture2D = (Texture2D)obj;
			int mipmapCount = texture2D.mipmapCount;
			LuaDLL.lua_pushinteger(L, mipmapCount);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index mipmapCount on a nil value");
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
			Texture2D texture2D = (Texture2D)obj;
			TextureFormat format = texture2D.format;
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
	private static int get_whiteTexture(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, Texture2D.whiteTexture);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_blackTexture(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, Texture2D.blackTexture);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
