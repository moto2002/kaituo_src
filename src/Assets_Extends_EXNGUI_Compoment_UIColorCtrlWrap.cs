using Assets.Extends.EXNGUI.Compoment;
using LuaInterface;
using System;
using UnityEngine;

public class Assets_Extends_EXNGUI_Compoment_UIColorCtrlWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UIColorCtrl), typeof(MonoBehaviour), null);
		L.RegFunction("SetColor", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIColorCtrlWrap.SetColor));
		L.RegFunction("__eq", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIColorCtrlWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("Children", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIColorCtrlWrap.get_Children), new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIColorCtrlWrap.set_Children));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetColor(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(UIColorCtrl), typeof(Color)))
			{
				UIColorCtrl uIColorCtrl = (UIColorCtrl)ToLua.ToObject(L, 1);
				Color color = ToLua.ToColor(L, 2);
				uIColorCtrl.SetColor(color);
				result = 0;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(UIColorCtrl), typeof(float), typeof(float), typeof(float), typeof(float)))
			{
				UIColorCtrl uIColorCtrl2 = (UIColorCtrl)ToLua.ToObject(L, 1);
				float r = (float)LuaDLL.lua_tonumber(L, 2);
				float g = (float)LuaDLL.lua_tonumber(L, 3);
				float b = (float)LuaDLL.lua_tonumber(L, 4);
				float a = (float)LuaDLL.lua_tonumber(L, 5);
				uIColorCtrl2.SetColor(r, g, b, a);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: Assets.Extends.EXNGUI.Compoment.UIColorCtrl.SetColor");
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
	private static int get_Children(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIColorCtrl uIColorCtrl = (UIColorCtrl)obj;
			UIWidget[] children = uIColorCtrl.Children;
			ToLua.Push(L, children);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Children on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Children(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIColorCtrl uIColorCtrl = (UIColorCtrl)obj;
			UIWidget[] children = ToLua.CheckObjectArray<UIWidget>(L, 2);
			uIColorCtrl.Children = children;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Children on a nil value");
		}
		return result;
	}
}
