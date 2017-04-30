using LuaInterface;
using System;
using UnityEngine;

public class UIDragScrollViewWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UIDragScrollView), typeof(MonoBehaviour), null);
		L.RegFunction("OnPress", new LuaCSFunction(UIDragScrollViewWrap.OnPress));
		L.RegFunction("OnPan", new LuaCSFunction(UIDragScrollViewWrap.OnPan));
		L.RegFunction("__eq", new LuaCSFunction(UIDragScrollViewWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("scrollView", new LuaCSFunction(UIDragScrollViewWrap.get_scrollView), new LuaCSFunction(UIDragScrollViewWrap.set_scrollView));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnPress(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UIDragScrollView uIDragScrollView = (UIDragScrollView)ToLua.CheckObject(L, 1, typeof(UIDragScrollView));
			bool pressed = LuaDLL.luaL_checkboolean(L, 2);
			uIDragScrollView.OnPress(pressed);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnPan(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UIDragScrollView uIDragScrollView = (UIDragScrollView)ToLua.CheckObject(L, 1, typeof(UIDragScrollView));
			Vector2 delta = ToLua.ToVector2(L, 2);
			uIDragScrollView.OnPan(delta);
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
	private static int get_scrollView(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDragScrollView uIDragScrollView = (UIDragScrollView)obj;
			UIScrollView scrollView = uIDragScrollView.scrollView;
			ToLua.Push(L, scrollView);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index scrollView on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_scrollView(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDragScrollView uIDragScrollView = (UIDragScrollView)obj;
			UIScrollView scrollView = (UIScrollView)ToLua.CheckUnityObject(L, 2, typeof(UIScrollView));
			uIDragScrollView.scrollView = scrollView;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index scrollView on a nil value");
		}
		return result;
	}
}
