using Assets.Extends.EXNGUI.Compoment;
using Assets.Tools.Script.Event;
using LuaInterface;
using System;
using UnityEngine;

public class Assets_Extends_EXNGUI_Compoment_UIRadioBtnGroupWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UIRadioBtnGroup), typeof(MonoBehaviour), null);
		L.RegFunction("Init", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIRadioBtnGroupWrap.Init));
		L.RegFunction("Reset", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIRadioBtnGroupWrap.Reset));
		L.RegFunction("__eq", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIRadioBtnGroupWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("uiSelectionBtns", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIRadioBtnGroupWrap.get_uiSelectionBtns), new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIRadioBtnGroupWrap.set_uiSelectionBtns));
		L.RegVar("defaultBtn", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIRadioBtnGroupWrap.get_defaultBtn), new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIRadioBtnGroupWrap.set_defaultBtn));
		L.RegVar("onSelecedChangeSignal", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIRadioBtnGroupWrap.get_onSelecedChangeSignal), null);
		L.RegVar("onSelecedAgainSignal", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIRadioBtnGroupWrap.get_onSelecedAgainSignal), null);
		L.RegVar("onInvalidClickSignal", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIRadioBtnGroupWrap.get_onInvalidClickSignal), null);
		L.RegVar("currSelectedBtn", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIRadioBtnGroupWrap.get_currSelectedBtn), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Init(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIRadioBtnGroup uIRadioBtnGroup = (UIRadioBtnGroup)ToLua.CheckObject(L, 1, typeof(UIRadioBtnGroup));
			uIRadioBtnGroup.Init();
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
			UIRadioBtnGroup uIRadioBtnGroup = (UIRadioBtnGroup)ToLua.CheckObject(L, 1, typeof(UIRadioBtnGroup));
			uIRadioBtnGroup.Reset();
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
	private static int get_uiSelectionBtns(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRadioBtnGroup uIRadioBtnGroup = (UIRadioBtnGroup)obj;
			UISelectionBtn[] uiSelectionBtns = uIRadioBtnGroup.uiSelectionBtns;
			ToLua.Push(L, uiSelectionBtns);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index uiSelectionBtns on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_defaultBtn(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRadioBtnGroup uIRadioBtnGroup = (UIRadioBtnGroup)obj;
			UISelectionBtn defaultBtn = uIRadioBtnGroup.defaultBtn;
			ToLua.Push(L, defaultBtn);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index defaultBtn on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onSelecedChangeSignal(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRadioBtnGroup uIRadioBtnGroup = (UIRadioBtnGroup)obj;
			Signal<UISelectionBtn> onSelecedChangeSignal = uIRadioBtnGroup.onSelecedChangeSignal;
			ToLua.PushObject(L, onSelecedChangeSignal);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onSelecedChangeSignal on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onSelecedAgainSignal(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRadioBtnGroup uIRadioBtnGroup = (UIRadioBtnGroup)obj;
			Signal<UISelectionBtn> onSelecedAgainSignal = uIRadioBtnGroup.onSelecedAgainSignal;
			ToLua.PushObject(L, onSelecedAgainSignal);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onSelecedAgainSignal on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onInvalidClickSignal(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRadioBtnGroup uIRadioBtnGroup = (UIRadioBtnGroup)obj;
			Signal<UISelectionBtn> onInvalidClickSignal = uIRadioBtnGroup.onInvalidClickSignal;
			ToLua.PushObject(L, onInvalidClickSignal);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onInvalidClickSignal on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_currSelectedBtn(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRadioBtnGroup uIRadioBtnGroup = (UIRadioBtnGroup)obj;
			UISelectionBtn currSelectedBtn = uIRadioBtnGroup.currSelectedBtn;
			ToLua.Push(L, currSelectedBtn);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index currSelectedBtn on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_uiSelectionBtns(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRadioBtnGroup uIRadioBtnGroup = (UIRadioBtnGroup)obj;
			UISelectionBtn[] uiSelectionBtns = ToLua.CheckObjectArray<UISelectionBtn>(L, 2);
			uIRadioBtnGroup.uiSelectionBtns = uiSelectionBtns;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index uiSelectionBtns on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_defaultBtn(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRadioBtnGroup uIRadioBtnGroup = (UIRadioBtnGroup)obj;
			UISelectionBtn defaultBtn = (UISelectionBtn)ToLua.CheckUnityObject(L, 2, typeof(UISelectionBtn));
			uIRadioBtnGroup.defaultBtn = defaultBtn;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index defaultBtn on a nil value");
		}
		return result;
	}
}
