using Assets.Scripts.Tools.NGUI.Component;
using LuaInterface;
using System;
using UnityEngine;

public class Assets_Scripts_Tools_NGUI_Component_UIClickListenerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UIClickListener), typeof(MonoBehaviour), null);
		L.RegFunction("Get", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIClickListenerWrap.Get));
		L.RegFunction("__eq", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIClickListenerWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("onClick", new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIClickListenerWrap.get_onClick), new LuaCSFunction(Assets_Scripts_Tools_NGUI_Component_UIClickListenerWrap.set_onClick));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Get(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			UIClickListener obj = UIClickListener.Get(go);
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
	private static int get_onClick(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIClickListener uIClickListener = (UIClickListener)obj;
			Action<GameObject> onClick = uIClickListener.onClick;
			ToLua.Push(L, onClick);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onClick on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onClick(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIClickListener uIClickListener = (UIClickListener)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Action<GameObject> onClick;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onClick = (Action<GameObject>)ToLua.CheckObject(L, 2, typeof(Action<GameObject>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onClick = (DelegateFactory.CreateDelegate(typeof(Action<GameObject>), func) as Action<GameObject>);
			}
			uIClickListener.onClick = onClick;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onClick on a nil value");
		}
		return result;
	}
}
