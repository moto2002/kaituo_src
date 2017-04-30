using Assets.Scripts.Game;
using LuaInterface;
using System;
using UnityEngine;

public class Assets_Scripts_Game_HexTileSpriteWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(HexTileSprite), typeof(UIWidget), null);
		L.RegFunction("Begin", new LuaCSFunction(Assets_Scripts_Game_HexTileSpriteWrap.Begin));
		L.RegFunction("DrawHex", new LuaCSFunction(Assets_Scripts_Game_HexTileSpriteWrap.DrawHex));
		L.RegFunction("End", new LuaCSFunction(Assets_Scripts_Game_HexTileSpriteWrap.End));
		L.RegFunction("Reset", new LuaCSFunction(Assets_Scripts_Game_HexTileSpriteWrap.Reset));
		L.RegFunction("OnFill", new LuaCSFunction(Assets_Scripts_Game_HexTileSpriteWrap.OnFill));
		L.RegFunction("__eq", new LuaCSFunction(Assets_Scripts_Game_HexTileSpriteWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("Radius", new LuaCSFunction(Assets_Scripts_Game_HexTileSpriteWrap.get_Radius), new LuaCSFunction(Assets_Scripts_Game_HexTileSpriteWrap.set_Radius));
		L.RegVar("Gap", new LuaCSFunction(Assets_Scripts_Game_HexTileSpriteWrap.get_Gap), new LuaCSFunction(Assets_Scripts_Game_HexTileSpriteWrap.set_Gap));
		L.RegVar("IsMirror", new LuaCSFunction(Assets_Scripts_Game_HexTileSpriteWrap.get_IsMirror), new LuaCSFunction(Assets_Scripts_Game_HexTileSpriteWrap.set_IsMirror));
		L.RegVar("material", new LuaCSFunction(Assets_Scripts_Game_HexTileSpriteWrap.get_material), new LuaCSFunction(Assets_Scripts_Game_HexTileSpriteWrap.set_material));
		L.RegVar("mainTexture", new LuaCSFunction(Assets_Scripts_Game_HexTileSpriteWrap.get_mainTexture), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Begin(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			HexTileSprite hexTileSprite = (HexTileSprite)ToLua.CheckObject(L, 1, typeof(HexTileSprite));
			float radius = (float)LuaDLL.luaL_checknumber(L, 2);
			float gap = (float)LuaDLL.luaL_checknumber(L, 3);
			bool isMirror = LuaDLL.luaL_checkboolean(L, 4);
			hexTileSprite.Begin(radius, gap, isMirror);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DrawHex(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			HexTileSprite hexTileSprite = (HexTileSprite)ToLua.CheckObject(L, 1, typeof(HexTileSprite));
			Vector3 hex = ToLua.ToVector3(L, 2);
			Color color = ToLua.ToColor(L, 3);
			hexTileSprite.DrawHex(hex, color);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int End(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			HexTileSprite hexTileSprite = (HexTileSprite)ToLua.CheckObject(L, 1, typeof(HexTileSprite));
			hexTileSprite.End();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Reset(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			HexTileSprite hexTileSprite = (HexTileSprite)ToLua.CheckObject(L, 1, typeof(HexTileSprite));
			hexTileSprite.Reset();
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
			HexTileSprite hexTileSprite = (HexTileSprite)ToLua.CheckObject(L, 1, typeof(HexTileSprite));
			BetterList<Vector3> verts = (BetterList<Vector3>)ToLua.CheckObject(L, 2, typeof(BetterList<Vector3>));
			BetterList<Vector2> uvs = (BetterList<Vector2>)ToLua.CheckObject(L, 3, typeof(BetterList<Vector2>));
			BetterList<Color> cols = (BetterList<Color>)ToLua.CheckObject(L, 4, typeof(BetterList<Color>));
			hexTileSprite.OnFill(verts, uvs, cols);
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
	private static int get_Radius(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			HexTileSprite hexTileSprite = (HexTileSprite)obj;
			float radius = hexTileSprite.Radius;
			LuaDLL.lua_pushnumber(L, (double)radius);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Radius on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Gap(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			HexTileSprite hexTileSprite = (HexTileSprite)obj;
			float gap = hexTileSprite.Gap;
			LuaDLL.lua_pushnumber(L, (double)gap);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Gap on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_IsMirror(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			HexTileSprite hexTileSprite = (HexTileSprite)obj;
			bool isMirror = hexTileSprite.IsMirror;
			LuaDLL.lua_pushboolean(L, isMirror);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index IsMirror on a nil value");
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
			HexTileSprite hexTileSprite = (HexTileSprite)obj;
			Material material = hexTileSprite.material;
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
	private static int get_mainTexture(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			HexTileSprite hexTileSprite = (HexTileSprite)obj;
			Texture mainTexture = hexTileSprite.mainTexture;
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
	private static int set_Radius(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			HexTileSprite hexTileSprite = (HexTileSprite)obj;
			float radius = (float)LuaDLL.luaL_checknumber(L, 2);
			hexTileSprite.Radius = radius;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Radius on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Gap(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			HexTileSprite hexTileSprite = (HexTileSprite)obj;
			float gap = (float)LuaDLL.luaL_checknumber(L, 2);
			hexTileSprite.Gap = gap;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Gap on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_IsMirror(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			HexTileSprite hexTileSprite = (HexTileSprite)obj;
			bool isMirror = LuaDLL.luaL_checkboolean(L, 2);
			hexTileSprite.IsMirror = isMirror;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index IsMirror on a nil value");
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
			HexTileSprite hexTileSprite = (HexTileSprite)obj;
			Material material = (Material)ToLua.CheckUnityObject(L, 2, typeof(Material));
			hexTileSprite.material = material;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index material on a nil value");
		}
		return result;
	}
}
