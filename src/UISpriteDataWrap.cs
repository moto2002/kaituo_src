using LuaInterface;
using System;

public class UISpriteDataWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UISpriteData), typeof(object), null);
		L.RegFunction("SetRect", new LuaCSFunction(UISpriteDataWrap.SetRect));
		L.RegFunction("SetPadding", new LuaCSFunction(UISpriteDataWrap.SetPadding));
		L.RegFunction("SetBorder", new LuaCSFunction(UISpriteDataWrap.SetBorder));
		L.RegFunction("CopyFrom", new LuaCSFunction(UISpriteDataWrap.CopyFrom));
		L.RegFunction("CopyBorderFrom", new LuaCSFunction(UISpriteDataWrap.CopyBorderFrom));
		L.RegFunction("New", new LuaCSFunction(UISpriteDataWrap._CreateUISpriteData));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("name", new LuaCSFunction(UISpriteDataWrap.get_name), new LuaCSFunction(UISpriteDataWrap.set_name));
		L.RegVar("x", new LuaCSFunction(UISpriteDataWrap.get_x), new LuaCSFunction(UISpriteDataWrap.set_x));
		L.RegVar("y", new LuaCSFunction(UISpriteDataWrap.get_y), new LuaCSFunction(UISpriteDataWrap.set_y));
		L.RegVar("width", new LuaCSFunction(UISpriteDataWrap.get_width), new LuaCSFunction(UISpriteDataWrap.set_width));
		L.RegVar("height", new LuaCSFunction(UISpriteDataWrap.get_height), new LuaCSFunction(UISpriteDataWrap.set_height));
		L.RegVar("borderLeft", new LuaCSFunction(UISpriteDataWrap.get_borderLeft), new LuaCSFunction(UISpriteDataWrap.set_borderLeft));
		L.RegVar("borderRight", new LuaCSFunction(UISpriteDataWrap.get_borderRight), new LuaCSFunction(UISpriteDataWrap.set_borderRight));
		L.RegVar("borderTop", new LuaCSFunction(UISpriteDataWrap.get_borderTop), new LuaCSFunction(UISpriteDataWrap.set_borderTop));
		L.RegVar("borderBottom", new LuaCSFunction(UISpriteDataWrap.get_borderBottom), new LuaCSFunction(UISpriteDataWrap.set_borderBottom));
		L.RegVar("paddingLeft", new LuaCSFunction(UISpriteDataWrap.get_paddingLeft), new LuaCSFunction(UISpriteDataWrap.set_paddingLeft));
		L.RegVar("paddingRight", new LuaCSFunction(UISpriteDataWrap.get_paddingRight), new LuaCSFunction(UISpriteDataWrap.set_paddingRight));
		L.RegVar("paddingTop", new LuaCSFunction(UISpriteDataWrap.get_paddingTop), new LuaCSFunction(UISpriteDataWrap.set_paddingTop));
		L.RegVar("paddingBottom", new LuaCSFunction(UISpriteDataWrap.get_paddingBottom), new LuaCSFunction(UISpriteDataWrap.set_paddingBottom));
		L.RegVar("hasBorder", new LuaCSFunction(UISpriteDataWrap.get_hasBorder), null);
		L.RegVar("hasPadding", new LuaCSFunction(UISpriteDataWrap.get_hasPadding), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateUISpriteData(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				UISpriteData o = new UISpriteData();
				ToLua.PushObject(L, o);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: UISpriteData.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetRect(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 5);
			UISpriteData uISpriteData = (UISpriteData)ToLua.CheckObject(L, 1, typeof(UISpriteData));
			int x = (int)LuaDLL.luaL_checknumber(L, 2);
			int y = (int)LuaDLL.luaL_checknumber(L, 3);
			int width = (int)LuaDLL.luaL_checknumber(L, 4);
			int height = (int)LuaDLL.luaL_checknumber(L, 5);
			uISpriteData.SetRect(x, y, width, height);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetPadding(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 5);
			UISpriteData uISpriteData = (UISpriteData)ToLua.CheckObject(L, 1, typeof(UISpriteData));
			int left = (int)LuaDLL.luaL_checknumber(L, 2);
			int bottom = (int)LuaDLL.luaL_checknumber(L, 3);
			int right = (int)LuaDLL.luaL_checknumber(L, 4);
			int top = (int)LuaDLL.luaL_checknumber(L, 5);
			uISpriteData.SetPadding(left, bottom, right, top);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetBorder(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 5);
			UISpriteData uISpriteData = (UISpriteData)ToLua.CheckObject(L, 1, typeof(UISpriteData));
			int left = (int)LuaDLL.luaL_checknumber(L, 2);
			int bottom = (int)LuaDLL.luaL_checknumber(L, 3);
			int right = (int)LuaDLL.luaL_checknumber(L, 4);
			int top = (int)LuaDLL.luaL_checknumber(L, 5);
			uISpriteData.SetBorder(left, bottom, right, top);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CopyFrom(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UISpriteData uISpriteData = (UISpriteData)ToLua.CheckObject(L, 1, typeof(UISpriteData));
			UISpriteData sd = (UISpriteData)ToLua.CheckObject(L, 2, typeof(UISpriteData));
			uISpriteData.CopyFrom(sd);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CopyBorderFrom(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UISpriteData uISpriteData = (UISpriteData)ToLua.CheckObject(L, 1, typeof(UISpriteData));
			UISpriteData sd = (UISpriteData)ToLua.CheckObject(L, 2, typeof(UISpriteData));
			uISpriteData.CopyBorderFrom(sd);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_name(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISpriteData uISpriteData = (UISpriteData)obj;
			string name = uISpriteData.name;
			LuaDLL.lua_pushstring(L, name);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index name on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_x(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISpriteData uISpriteData = (UISpriteData)obj;
			int x = uISpriteData.x;
			LuaDLL.lua_pushinteger(L, x);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index x on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_y(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISpriteData uISpriteData = (UISpriteData)obj;
			int y = uISpriteData.y;
			LuaDLL.lua_pushinteger(L, y);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index y on a nil value");
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
			UISpriteData uISpriteData = (UISpriteData)obj;
			int width = uISpriteData.width;
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
			UISpriteData uISpriteData = (UISpriteData)obj;
			int height = uISpriteData.height;
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
	private static int get_borderLeft(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISpriteData uISpriteData = (UISpriteData)obj;
			int borderLeft = uISpriteData.borderLeft;
			LuaDLL.lua_pushinteger(L, borderLeft);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index borderLeft on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_borderRight(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISpriteData uISpriteData = (UISpriteData)obj;
			int borderRight = uISpriteData.borderRight;
			LuaDLL.lua_pushinteger(L, borderRight);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index borderRight on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_borderTop(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISpriteData uISpriteData = (UISpriteData)obj;
			int borderTop = uISpriteData.borderTop;
			LuaDLL.lua_pushinteger(L, borderTop);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index borderTop on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_borderBottom(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISpriteData uISpriteData = (UISpriteData)obj;
			int borderBottom = uISpriteData.borderBottom;
			LuaDLL.lua_pushinteger(L, borderBottom);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index borderBottom on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_paddingLeft(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISpriteData uISpriteData = (UISpriteData)obj;
			int paddingLeft = uISpriteData.paddingLeft;
			LuaDLL.lua_pushinteger(L, paddingLeft);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index paddingLeft on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_paddingRight(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISpriteData uISpriteData = (UISpriteData)obj;
			int paddingRight = uISpriteData.paddingRight;
			LuaDLL.lua_pushinteger(L, paddingRight);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index paddingRight on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_paddingTop(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISpriteData uISpriteData = (UISpriteData)obj;
			int paddingTop = uISpriteData.paddingTop;
			LuaDLL.lua_pushinteger(L, paddingTop);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index paddingTop on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_paddingBottom(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISpriteData uISpriteData = (UISpriteData)obj;
			int paddingBottom = uISpriteData.paddingBottom;
			LuaDLL.lua_pushinteger(L, paddingBottom);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index paddingBottom on a nil value");
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
			UISpriteData uISpriteData = (UISpriteData)obj;
			bool hasBorder = uISpriteData.hasBorder;
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
	private static int get_hasPadding(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISpriteData uISpriteData = (UISpriteData)obj;
			bool hasPadding = uISpriteData.hasPadding;
			LuaDLL.lua_pushboolean(L, hasPadding);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index hasPadding on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_name(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISpriteData uISpriteData = (UISpriteData)obj;
			string name = ToLua.CheckString(L, 2);
			uISpriteData.name = name;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index name on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_x(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISpriteData uISpriteData = (UISpriteData)obj;
			int x = (int)LuaDLL.luaL_checknumber(L, 2);
			uISpriteData.x = x;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index x on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_y(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISpriteData uISpriteData = (UISpriteData)obj;
			int y = (int)LuaDLL.luaL_checknumber(L, 2);
			uISpriteData.y = y;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index y on a nil value");
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
			UISpriteData uISpriteData = (UISpriteData)obj;
			int width = (int)LuaDLL.luaL_checknumber(L, 2);
			uISpriteData.width = width;
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
			UISpriteData uISpriteData = (UISpriteData)obj;
			int height = (int)LuaDLL.luaL_checknumber(L, 2);
			uISpriteData.height = height;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index height on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_borderLeft(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISpriteData uISpriteData = (UISpriteData)obj;
			int borderLeft = (int)LuaDLL.luaL_checknumber(L, 2);
			uISpriteData.borderLeft = borderLeft;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index borderLeft on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_borderRight(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISpriteData uISpriteData = (UISpriteData)obj;
			int borderRight = (int)LuaDLL.luaL_checknumber(L, 2);
			uISpriteData.borderRight = borderRight;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index borderRight on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_borderTop(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISpriteData uISpriteData = (UISpriteData)obj;
			int borderTop = (int)LuaDLL.luaL_checknumber(L, 2);
			uISpriteData.borderTop = borderTop;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index borderTop on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_borderBottom(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISpriteData uISpriteData = (UISpriteData)obj;
			int borderBottom = (int)LuaDLL.luaL_checknumber(L, 2);
			uISpriteData.borderBottom = borderBottom;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index borderBottom on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_paddingLeft(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISpriteData uISpriteData = (UISpriteData)obj;
			int paddingLeft = (int)LuaDLL.luaL_checknumber(L, 2);
			uISpriteData.paddingLeft = paddingLeft;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index paddingLeft on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_paddingRight(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISpriteData uISpriteData = (UISpriteData)obj;
			int paddingRight = (int)LuaDLL.luaL_checknumber(L, 2);
			uISpriteData.paddingRight = paddingRight;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index paddingRight on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_paddingTop(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISpriteData uISpriteData = (UISpriteData)obj;
			int paddingTop = (int)LuaDLL.luaL_checknumber(L, 2);
			uISpriteData.paddingTop = paddingTop;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index paddingTop on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_paddingBottom(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISpriteData uISpriteData = (UISpriteData)obj;
			int paddingBottom = (int)LuaDLL.luaL_checknumber(L, 2);
			uISpriteData.paddingBottom = paddingBottom;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index paddingBottom on a nil value");
		}
		return result;
	}
}
