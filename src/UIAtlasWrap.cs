using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

public class UIAtlasWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UIAtlas), typeof(MonoBehaviour), null);
		L.RegFunction("GetSprite", new LuaCSFunction(UIAtlasWrap.GetSprite));
		L.RegFunction("GetRandomSprite", new LuaCSFunction(UIAtlasWrap.GetRandomSprite));
		L.RegFunction("MarkSpriteListAsChanged", new LuaCSFunction(UIAtlasWrap.MarkSpriteListAsChanged));
		L.RegFunction("SortAlphabetically", new LuaCSFunction(UIAtlasWrap.SortAlphabetically));
		L.RegFunction("GetListOfSprites", new LuaCSFunction(UIAtlasWrap.GetListOfSprites));
		L.RegFunction("CheckIfRelated", new LuaCSFunction(UIAtlasWrap.CheckIfRelated));
		L.RegFunction("MarkAsChanged", new LuaCSFunction(UIAtlasWrap.MarkAsChanged));
		L.RegFunction("__eq", new LuaCSFunction(UIAtlasWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("spriteMaterial", new LuaCSFunction(UIAtlasWrap.get_spriteMaterial), new LuaCSFunction(UIAtlasWrap.set_spriteMaterial));
		L.RegVar("premultipliedAlpha", new LuaCSFunction(UIAtlasWrap.get_premultipliedAlpha), null);
		L.RegVar("spriteList", new LuaCSFunction(UIAtlasWrap.get_spriteList), new LuaCSFunction(UIAtlasWrap.set_spriteList));
		L.RegVar("texture", new LuaCSFunction(UIAtlasWrap.get_texture), null);
		L.RegVar("pixelSize", new LuaCSFunction(UIAtlasWrap.get_pixelSize), new LuaCSFunction(UIAtlasWrap.set_pixelSize));
		L.RegVar("replacement", new LuaCSFunction(UIAtlasWrap.get_replacement), new LuaCSFunction(UIAtlasWrap.set_replacement));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetSprite(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UIAtlas uIAtlas = (UIAtlas)ToLua.CheckObject(L, 1, typeof(UIAtlas));
			string name = ToLua.CheckString(L, 2);
			UISpriteData sprite = uIAtlas.GetSprite(name);
			ToLua.PushObject(L, sprite);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetRandomSprite(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UIAtlas uIAtlas = (UIAtlas)ToLua.CheckObject(L, 1, typeof(UIAtlas));
			string startsWith = ToLua.CheckString(L, 2);
			string randomSprite = uIAtlas.GetRandomSprite(startsWith);
			LuaDLL.lua_pushstring(L, randomSprite);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int MarkSpriteListAsChanged(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIAtlas uIAtlas = (UIAtlas)ToLua.CheckObject(L, 1, typeof(UIAtlas));
			uIAtlas.MarkSpriteListAsChanged();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SortAlphabetically(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIAtlas uIAtlas = (UIAtlas)ToLua.CheckObject(L, 1, typeof(UIAtlas));
			uIAtlas.SortAlphabetically();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetListOfSprites(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(UIAtlas)))
			{
				UIAtlas uIAtlas = (UIAtlas)ToLua.ToObject(L, 1);
				BetterList<string> listOfSprites = uIAtlas.GetListOfSprites();
				ToLua.PushObject(L, listOfSprites);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(UIAtlas), typeof(string)))
			{
				UIAtlas uIAtlas2 = (UIAtlas)ToLua.ToObject(L, 1);
				string match = ToLua.ToString(L, 2);
				BetterList<string> listOfSprites2 = uIAtlas2.GetListOfSprites(match);
				ToLua.PushObject(L, listOfSprites2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UIAtlas.GetListOfSprites");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CheckIfRelated(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UIAtlas a = (UIAtlas)ToLua.CheckUnityObject(L, 1, typeof(UIAtlas));
			UIAtlas b = (UIAtlas)ToLua.CheckUnityObject(L, 2, typeof(UIAtlas));
			bool value = UIAtlas.CheckIfRelated(a, b);
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
	private static int MarkAsChanged(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIAtlas uIAtlas = (UIAtlas)ToLua.CheckObject(L, 1, typeof(UIAtlas));
			uIAtlas.MarkAsChanged();
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
	private static int get_spriteMaterial(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIAtlas uIAtlas = (UIAtlas)obj;
			Material spriteMaterial = uIAtlas.spriteMaterial;
			ToLua.Push(L, spriteMaterial);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index spriteMaterial on a nil value");
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
			UIAtlas uIAtlas = (UIAtlas)obj;
			bool premultipliedAlpha = uIAtlas.premultipliedAlpha;
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
	private static int get_spriteList(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIAtlas uIAtlas = (UIAtlas)obj;
			List<UISpriteData> spriteList = uIAtlas.spriteList;
			ToLua.PushObject(L, spriteList);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index spriteList on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_texture(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIAtlas uIAtlas = (UIAtlas)obj;
			Texture texture = uIAtlas.texture;
			ToLua.Push(L, texture);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index texture on a nil value");
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
			UIAtlas uIAtlas = (UIAtlas)obj;
			float pixelSize = uIAtlas.pixelSize;
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
	private static int get_replacement(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIAtlas uIAtlas = (UIAtlas)obj;
			UIAtlas replacement = uIAtlas.replacement;
			ToLua.Push(L, replacement);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index replacement on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_spriteMaterial(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIAtlas uIAtlas = (UIAtlas)obj;
			Material spriteMaterial = (Material)ToLua.CheckUnityObject(L, 2, typeof(Material));
			uIAtlas.spriteMaterial = spriteMaterial;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index spriteMaterial on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_spriteList(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIAtlas uIAtlas = (UIAtlas)obj;
			List<UISpriteData> spriteList = (List<UISpriteData>)ToLua.CheckObject(L, 2, typeof(List<UISpriteData>));
			uIAtlas.spriteList = spriteList;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index spriteList on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_pixelSize(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIAtlas uIAtlas = (UIAtlas)obj;
			float pixelSize = (float)LuaDLL.luaL_checknumber(L, 2);
			uIAtlas.pixelSize = pixelSize;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pixelSize on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_replacement(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIAtlas uIAtlas = (UIAtlas)obj;
			UIAtlas replacement = (UIAtlas)ToLua.CheckUnityObject(L, 2, typeof(UIAtlas));
			uIAtlas.replacement = replacement;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index replacement on a nil value");
		}
		return result;
	}
}
