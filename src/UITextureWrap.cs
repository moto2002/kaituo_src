using LuaInterface;
using System;
using UnityEngine;

public class UITextureWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UITexture), typeof(UIBasicSprite), null);
		L.RegFunction("MakePixelPerfect", new LuaCSFunction(UITextureWrap.MakePixelPerfect));
		L.RegFunction("OnFill", new LuaCSFunction(UITextureWrap.OnFill));
		L.RegFunction("__eq", new LuaCSFunction(UITextureWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("mainTexture", new LuaCSFunction(UITextureWrap.get_mainTexture), new LuaCSFunction(UITextureWrap.set_mainTexture));
		L.RegVar("material", new LuaCSFunction(UITextureWrap.get_material), new LuaCSFunction(UITextureWrap.set_material));
		L.RegVar("shader", new LuaCSFunction(UITextureWrap.get_shader), new LuaCSFunction(UITextureWrap.set_shader));
		L.RegVar("premultipliedAlpha", new LuaCSFunction(UITextureWrap.get_premultipliedAlpha), null);
		L.RegVar("border", new LuaCSFunction(UITextureWrap.get_border), new LuaCSFunction(UITextureWrap.set_border));
		L.RegVar("uvRect", new LuaCSFunction(UITextureWrap.get_uvRect), new LuaCSFunction(UITextureWrap.set_uvRect));
		L.RegVar("drawingDimensions", new LuaCSFunction(UITextureWrap.get_drawingDimensions), null);
		L.RegVar("fixedAspect", new LuaCSFunction(UITextureWrap.get_fixedAspect), new LuaCSFunction(UITextureWrap.set_fixedAspect));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int MakePixelPerfect(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UITexture uITexture = (UITexture)ToLua.CheckObject(L, 1, typeof(UITexture));
			uITexture.MakePixelPerfect();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnFill(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			UITexture uITexture = (UITexture)ToLua.CheckObject(L, 1, typeof(UITexture));
			BetterList<Vector3> verts = (BetterList<Vector3>)ToLua.CheckObject(L, 2, typeof(BetterList<Vector3>));
			BetterList<Vector2> uvs = (BetterList<Vector2>)ToLua.CheckObject(L, 3, typeof(BetterList<Vector2>));
			BetterList<Color> cols = (BetterList<Color>)ToLua.CheckObject(L, 4, typeof(BetterList<Color>));
			uITexture.OnFill(verts, uvs, cols);
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
	private static int get_mainTexture(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITexture uITexture = (UITexture)obj;
			Texture mainTexture = uITexture.mainTexture;
			ToLua.Push(L, mainTexture);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index mainTexture on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_material(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITexture uITexture = (UITexture)obj;
			Material material = uITexture.material;
			ToLua.Push(L, material);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index material on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_shader(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITexture uITexture = (UITexture)obj;
			Shader shader = uITexture.shader;
			ToLua.Push(L, shader);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index shader on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_premultipliedAlpha(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITexture uITexture = (UITexture)obj;
			bool premultipliedAlpha = uITexture.premultipliedAlpha;
			LuaDLL.lua_pushboolean(L, premultipliedAlpha);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index premultipliedAlpha on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_border(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITexture uITexture = (UITexture)obj;
			Vector4 border = uITexture.border;
			ToLua.Push(L, border);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index border on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_uvRect(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITexture uITexture = (UITexture)obj;
			Rect uvRect = uITexture.uvRect;
			ToLua.PushValue(L, uvRect);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index uvRect on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_drawingDimensions(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITexture uITexture = (UITexture)obj;
			Vector4 drawingDimensions = uITexture.drawingDimensions;
			ToLua.Push(L, drawingDimensions);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index drawingDimensions on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_fixedAspect(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITexture uITexture = (UITexture)obj;
			bool fixedAspect = uITexture.fixedAspect;
			LuaDLL.lua_pushboolean(L, fixedAspect);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index fixedAspect on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_mainTexture(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITexture uITexture = (UITexture)obj;
			Texture mainTexture = (Texture)ToLua.CheckUnityObject(L, 2, typeof(Texture));
			uITexture.mainTexture = mainTexture;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index mainTexture on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_material(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITexture uITexture = (UITexture)obj;
			Material material = (Material)ToLua.CheckUnityObject(L, 2, typeof(Material));
			uITexture.material = material;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index material on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_shader(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITexture uITexture = (UITexture)obj;
			Shader shader = (Shader)ToLua.CheckUnityObject(L, 2, typeof(Shader));
			uITexture.shader = shader;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index shader on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_border(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITexture uITexture = (UITexture)obj;
			Vector4 border = ToLua.ToVector4(L, 2);
			uITexture.border = border;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index border on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_uvRect(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITexture uITexture = (UITexture)obj;
			Rect uvRect = (Rect)ToLua.CheckObject(L, 2, typeof(Rect));
			uITexture.uvRect = uvRect;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index uvRect on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_fixedAspect(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UITexture uITexture = (UITexture)obj;
			bool fixedAspect = LuaDLL.luaL_checkboolean(L, 2);
			uITexture.fixedAspect = fixedAspect;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index fixedAspect on a nil value");
		}
		return result;
	}
}
