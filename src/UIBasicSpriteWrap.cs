using LuaInterface;
using System;
using UnityEngine;

public class UIBasicSpriteWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UIBasicSprite), typeof(UIWidget), null);
		L.RegFunction("__eq", new LuaCSFunction(UIBasicSpriteWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("centerType", new LuaCSFunction(UIBasicSpriteWrap.get_centerType), new LuaCSFunction(UIBasicSpriteWrap.set_centerType));
		L.RegVar("leftType", new LuaCSFunction(UIBasicSpriteWrap.get_leftType), new LuaCSFunction(UIBasicSpriteWrap.set_leftType));
		L.RegVar("rightType", new LuaCSFunction(UIBasicSpriteWrap.get_rightType), new LuaCSFunction(UIBasicSpriteWrap.set_rightType));
		L.RegVar("bottomType", new LuaCSFunction(UIBasicSpriteWrap.get_bottomType), new LuaCSFunction(UIBasicSpriteWrap.set_bottomType));
		L.RegVar("topType", new LuaCSFunction(UIBasicSpriteWrap.get_topType), new LuaCSFunction(UIBasicSpriteWrap.set_topType));
		L.RegVar("innerUV", null, new LuaCSFunction(UIBasicSpriteWrap.set_innerUV));
		L.RegVar("outerUV", null, new LuaCSFunction(UIBasicSpriteWrap.set_outerUV));
		L.RegVar("type", new LuaCSFunction(UIBasicSpriteWrap.get_type), new LuaCSFunction(UIBasicSpriteWrap.set_type));
		L.RegVar("flip", new LuaCSFunction(UIBasicSpriteWrap.get_flip), new LuaCSFunction(UIBasicSpriteWrap.set_flip));
		L.RegVar("fillDirection", new LuaCSFunction(UIBasicSpriteWrap.get_fillDirection), new LuaCSFunction(UIBasicSpriteWrap.set_fillDirection));
		L.RegVar("fillAmount", new LuaCSFunction(UIBasicSpriteWrap.get_fillAmount), new LuaCSFunction(UIBasicSpriteWrap.set_fillAmount));
		L.RegVar("minWidth", new LuaCSFunction(UIBasicSpriteWrap.get_minWidth), null);
		L.RegVar("minHeight", new LuaCSFunction(UIBasicSpriteWrap.get_minHeight), null);
		L.RegVar("invert", new LuaCSFunction(UIBasicSpriteWrap.get_invert), new LuaCSFunction(UIBasicSpriteWrap.set_invert));
		L.RegVar("hasBorder", new LuaCSFunction(UIBasicSpriteWrap.get_hasBorder), null);
		L.RegVar("premultipliedAlpha", new LuaCSFunction(UIBasicSpriteWrap.get_premultipliedAlpha), null);
		L.RegVar("pixelSize", new LuaCSFunction(UIBasicSpriteWrap.get_pixelSize), null);
		L.RegVar("drawingUVs", new LuaCSFunction(UIBasicSpriteWrap.get_drawingUVs), null);
		L.EndClass();
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
	private static int get_centerType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIBasicSprite uIBasicSprite = (UIBasicSprite)obj;
			UIBasicSprite.AdvancedType centerType = uIBasicSprite.centerType;
			ToLua.Push(L, centerType);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index centerType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_leftType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIBasicSprite uIBasicSprite = (UIBasicSprite)obj;
			UIBasicSprite.AdvancedType leftType = uIBasicSprite.leftType;
			ToLua.Push(L, leftType);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index leftType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_rightType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIBasicSprite uIBasicSprite = (UIBasicSprite)obj;
			UIBasicSprite.AdvancedType rightType = uIBasicSprite.rightType;
			ToLua.Push(L, rightType);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index rightType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_bottomType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIBasicSprite uIBasicSprite = (UIBasicSprite)obj;
			UIBasicSprite.AdvancedType bottomType = uIBasicSprite.bottomType;
			ToLua.Push(L, bottomType);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index bottomType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_topType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIBasicSprite uIBasicSprite = (UIBasicSprite)obj;
			UIBasicSprite.AdvancedType topType = uIBasicSprite.topType;
			ToLua.Push(L, topType);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index topType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_type(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIBasicSprite uIBasicSprite = (UIBasicSprite)obj;
			UIBasicSprite.Type type = uIBasicSprite.type;
			ToLua.Push(L, type);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index type on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_flip(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIBasicSprite uIBasicSprite = (UIBasicSprite)obj;
			UIBasicSprite.Flip flip = uIBasicSprite.flip;
			ToLua.Push(L, flip);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index flip on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_fillDirection(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIBasicSprite uIBasicSprite = (UIBasicSprite)obj;
			UIBasicSprite.FillDirection fillDirection = uIBasicSprite.fillDirection;
			ToLua.Push(L, fillDirection);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index fillDirection on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_fillAmount(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIBasicSprite uIBasicSprite = (UIBasicSprite)obj;
			float fillAmount = uIBasicSprite.fillAmount;
			LuaDLL.lua_pushnumber(L, (double)fillAmount);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index fillAmount on a nil value");
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
			UIBasicSprite uIBasicSprite = (UIBasicSprite)obj;
			int minWidth = uIBasicSprite.minWidth;
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
			UIBasicSprite uIBasicSprite = (UIBasicSprite)obj;
			int minHeight = uIBasicSprite.minHeight;
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
	private static int get_invert(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIBasicSprite uIBasicSprite = (UIBasicSprite)obj;
			bool invert = uIBasicSprite.invert;
			LuaDLL.lua_pushboolean(L, invert);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index invert on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_hasBorder(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIBasicSprite uIBasicSprite = (UIBasicSprite)obj;
			bool hasBorder = uIBasicSprite.hasBorder;
			LuaDLL.lua_pushboolean(L, hasBorder);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index hasBorder on a nil value");
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
			UIBasicSprite uIBasicSprite = (UIBasicSprite)obj;
			bool premultipliedAlpha = uIBasicSprite.premultipliedAlpha;
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
	private static int get_pixelSize(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIBasicSprite uIBasicSprite = (UIBasicSprite)obj;
			float pixelSize = uIBasicSprite.pixelSize;
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
	private static int get_drawingUVs(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIBasicSprite uIBasicSprite = (UIBasicSprite)obj;
			Vector4 drawingUVs = uIBasicSprite.drawingUVs;
			ToLua.Push(L, drawingUVs);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index drawingUVs on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_centerType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIBasicSprite uIBasicSprite = (UIBasicSprite)obj;
			UIBasicSprite.AdvancedType centerType = (UIBasicSprite.AdvancedType)LuaDLL.luaL_checknumber(L, 2);
			uIBasicSprite.centerType = centerType;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index centerType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_leftType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIBasicSprite uIBasicSprite = (UIBasicSprite)obj;
			UIBasicSprite.AdvancedType leftType = (UIBasicSprite.AdvancedType)LuaDLL.luaL_checknumber(L, 2);
			uIBasicSprite.leftType = leftType;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index leftType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_rightType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIBasicSprite uIBasicSprite = (UIBasicSprite)obj;
			UIBasicSprite.AdvancedType rightType = (UIBasicSprite.AdvancedType)LuaDLL.luaL_checknumber(L, 2);
			uIBasicSprite.rightType = rightType;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index rightType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_bottomType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIBasicSprite uIBasicSprite = (UIBasicSprite)obj;
			UIBasicSprite.AdvancedType bottomType = (UIBasicSprite.AdvancedType)LuaDLL.luaL_checknumber(L, 2);
			uIBasicSprite.bottomType = bottomType;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index bottomType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_topType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIBasicSprite uIBasicSprite = (UIBasicSprite)obj;
			UIBasicSprite.AdvancedType topType = (UIBasicSprite.AdvancedType)LuaDLL.luaL_checknumber(L, 2);
			uIBasicSprite.topType = topType;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index topType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_innerUV(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIBasicSprite uIBasicSprite = (UIBasicSprite)obj;
			Rect innerUV = (Rect)ToLua.CheckObject(L, 2, typeof(Rect));
			uIBasicSprite.innerUV = innerUV;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index innerUV on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_outerUV(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIBasicSprite uIBasicSprite = (UIBasicSprite)obj;
			Rect outerUV = (Rect)ToLua.CheckObject(L, 2, typeof(Rect));
			uIBasicSprite.outerUV = outerUV;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index outerUV on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_type(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIBasicSprite uIBasicSprite = (UIBasicSprite)obj;
			UIBasicSprite.Type type = (UIBasicSprite.Type)LuaDLL.luaL_checknumber(L, 2);
			uIBasicSprite.type = type;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index type on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_flip(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIBasicSprite uIBasicSprite = (UIBasicSprite)obj;
			UIBasicSprite.Flip flip = (UIBasicSprite.Flip)((int)ToLua.CheckObject(L, 2, typeof(UIBasicSprite.Flip)));
			uIBasicSprite.flip = flip;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index flip on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_fillDirection(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIBasicSprite uIBasicSprite = (UIBasicSprite)obj;
			UIBasicSprite.FillDirection fillDirection = (UIBasicSprite.FillDirection)LuaDLL.luaL_checknumber(L, 2);
			uIBasicSprite.fillDirection = fillDirection;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index fillDirection on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_fillAmount(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIBasicSprite uIBasicSprite = (UIBasicSprite)obj;
			float fillAmount = (float)LuaDLL.luaL_checknumber(L, 2);
			uIBasicSprite.fillAmount = fillAmount;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index fillAmount on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_invert(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIBasicSprite uIBasicSprite = (UIBasicSprite)obj;
			bool invert = LuaDLL.luaL_checkboolean(L, 2);
			uIBasicSprite.invert = invert;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index invert on a nil value");
		}
		return result;
	}
}
