using LuaInterface;
using System;
using UnityEngine;

public class UISpriteWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UISprite), typeof(UIBasicSprite), null);
		L.RegFunction("GetAtlasSprite", new LuaCSFunction(UISpriteWrap.GetAtlasSprite));
		L.RegFunction("MakePixelPerfect", new LuaCSFunction(UISpriteWrap.MakePixelPerfect));
		L.RegFunction("OnFill", new LuaCSFunction(UISpriteWrap.OnFill));
		L.RegFunction("__eq", new LuaCSFunction(UISpriteWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("material", new LuaCSFunction(UISpriteWrap.get_material), null);
		L.RegVar("atlas", new LuaCSFunction(UISpriteWrap.get_atlas), new LuaCSFunction(UISpriteWrap.set_atlas));
		L.RegVar("spriteName", new LuaCSFunction(UISpriteWrap.get_spriteName), new LuaCSFunction(UISpriteWrap.set_spriteName));
		L.RegVar("isValid", new LuaCSFunction(UISpriteWrap.get_isValid), null);
		L.RegVar("applyGradient", new LuaCSFunction(UISpriteWrap.get_applyGradient), new LuaCSFunction(UISpriteWrap.set_applyGradient));
		L.RegVar("gradientTop", new LuaCSFunction(UISpriteWrap.get_gradientTop), new LuaCSFunction(UISpriteWrap.set_gradientTop));
		L.RegVar("gradientBottom", new LuaCSFunction(UISpriteWrap.get_gradientBottom), new LuaCSFunction(UISpriteWrap.set_gradientBottom));
		L.RegVar("border", new LuaCSFunction(UISpriteWrap.get_border), null);
		L.RegVar("pixelSize", new LuaCSFunction(UISpriteWrap.get_pixelSize), null);
		L.RegVar("minWidth", new LuaCSFunction(UISpriteWrap.get_minWidth), null);
		L.RegVar("minHeight", new LuaCSFunction(UISpriteWrap.get_minHeight), null);
		L.RegVar("drawingDimensions", new LuaCSFunction(UISpriteWrap.get_drawingDimensions), null);
		L.RegVar("premultipliedAlpha", new LuaCSFunction(UISpriteWrap.get_premultipliedAlpha), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetAtlasSprite(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UISprite uISprite = (UISprite)ToLua.CheckObject(L, 1, typeof(UISprite));
			UISpriteData atlasSprite = uISprite.GetAtlasSprite();
			ToLua.PushObject(L, atlasSprite);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int MakePixelPerfect(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UISprite uISprite = (UISprite)ToLua.CheckObject(L, 1, typeof(UISprite));
			uISprite.MakePixelPerfect();
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
			UISprite uISprite = (UISprite)ToLua.CheckObject(L, 1, typeof(UISprite));
			BetterList<Vector3> verts = (BetterList<Vector3>)ToLua.CheckObject(L, 2, typeof(BetterList<Vector3>));
			BetterList<Vector2> uvs = (BetterList<Vector2>)ToLua.CheckObject(L, 3, typeof(BetterList<Vector2>));
			BetterList<Color> cols = (BetterList<Color>)ToLua.CheckObject(L, 4, typeof(BetterList<Color>));
			uISprite.OnFill(verts, uvs, cols);
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
	private static int get_material(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISprite uISprite = (UISprite)obj;
			Material material = uISprite.material;
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
	private static int get_atlas(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISprite uISprite = (UISprite)obj;
			UIAtlas atlas = uISprite.atlas;
			ToLua.Push(L, atlas);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index atlas on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_spriteName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISprite uISprite = (UISprite)obj;
			string spriteName = uISprite.spriteName;
			LuaDLL.lua_pushstring(L, spriteName);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index spriteName on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isValid(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISprite uISprite = (UISprite)obj;
			bool isValid = uISprite.isValid;
			LuaDLL.lua_pushboolean(L, isValid);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isValid on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_applyGradient(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISprite uISprite = (UISprite)obj;
			bool applyGradient = uISprite.applyGradient;
			LuaDLL.lua_pushboolean(L, applyGradient);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index applyGradient on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_gradientTop(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISprite uISprite = (UISprite)obj;
			Color gradientTop = uISprite.gradientTop;
			ToLua.Push(L, gradientTop);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index gradientTop on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_gradientBottom(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISprite uISprite = (UISprite)obj;
			Color gradientBottom = uISprite.gradientBottom;
			ToLua.Push(L, gradientBottom);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index gradientBottom on a nil value");
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
			UISprite uISprite = (UISprite)obj;
			Vector4 border = uISprite.border;
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
	private static int get_pixelSize(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISprite uISprite = (UISprite)obj;
			float pixelSize = uISprite.pixelSize;
			LuaDLL.lua_pushnumber(L, (double)pixelSize);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pixelSize on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_minWidth(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISprite uISprite = (UISprite)obj;
			int minWidth = uISprite.minWidth;
			LuaDLL.lua_pushinteger(L, minWidth);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index minWidth on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_minHeight(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISprite uISprite = (UISprite)obj;
			int minHeight = uISprite.minHeight;
			LuaDLL.lua_pushinteger(L, minHeight);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index minHeight on a nil value");
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
			UISprite uISprite = (UISprite)obj;
			Vector4 drawingDimensions = uISprite.drawingDimensions;
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
	private static int get_premultipliedAlpha(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISprite uISprite = (UISprite)obj;
			bool premultipliedAlpha = uISprite.premultipliedAlpha;
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
	private static int set_atlas(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISprite uISprite = (UISprite)obj;
			UIAtlas atlas = (UIAtlas)ToLua.CheckUnityObject(L, 2, typeof(UIAtlas));
			uISprite.atlas = atlas;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index atlas on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_spriteName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISprite uISprite = (UISprite)obj;
			string spriteName = ToLua.CheckString(L, 2);
			uISprite.spriteName = spriteName;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index spriteName on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_applyGradient(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISprite uISprite = (UISprite)obj;
			bool applyGradient = LuaDLL.luaL_checkboolean(L, 2);
			uISprite.applyGradient = applyGradient;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index applyGradient on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_gradientTop(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISprite uISprite = (UISprite)obj;
			Color gradientTop = ToLua.ToColor(L, 2);
			uISprite.gradientTop = gradientTop;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index gradientTop on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_gradientBottom(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISprite uISprite = (UISprite)obj;
			Color gradientBottom = ToLua.ToColor(L, 2);
			uISprite.gradientBottom = gradientBottom;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index gradientBottom on a nil value");
		}
		return result;
	}
}
