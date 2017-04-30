using Assets.Extends.EXNGUI.Compoment;
using Assets.Tools.Script.Event;
using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Assets_Extends_EXNGUI_Compoment_UISelectionBtnWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UISelectionBtn), typeof(MonoBehaviour), null);
		L.RegFunction("__eq", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UISelectionBtnWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("onBtn", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UISelectionBtnWrap.get_onBtn), new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UISelectionBtnWrap.set_onBtn));
		L.RegVar("offBtn", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UISelectionBtnWrap.get_offBtn), new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UISelectionBtnWrap.set_offBtn));
		L.RegVar("Index", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UISelectionBtnWrap.get_Index), new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UISelectionBtnWrap.set_Index));
		L.RegVar("ButtonName", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UISelectionBtnWrap.get_ButtonName), new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UISelectionBtnWrap.set_ButtonName));
		L.RegVar("onChangeSignal", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UISelectionBtnWrap.get_onChangeSignal), null);
		L.RegVar("onChange", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UISelectionBtnWrap.get_onChange), new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UISelectionBtnWrap.set_onChange));
		L.RegVar("onInvalidClickSignal", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UISelectionBtnWrap.get_onInvalidClickSignal), null);
		L.RegVar("BtnEnabled", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UISelectionBtnWrap.get_BtnEnabled), new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UISelectionBtnWrap.set_BtnEnabled));
		L.RegVar("IsOn", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UISelectionBtnWrap.get_IsOn), new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UISelectionBtnWrap.set_IsOn));
		L.RegVar("Value", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UISelectionBtnWrap.get_Value), new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UISelectionBtnWrap.set_Value));
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
	private static int get_onBtn(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISelectionBtn uISelectionBtn = (UISelectionBtn)obj;
			GameObject onBtn = uISelectionBtn.onBtn;
			ToLua.Push(L, onBtn);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onBtn on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_offBtn(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISelectionBtn uISelectionBtn = (UISelectionBtn)obj;
			GameObject offBtn = uISelectionBtn.offBtn;
			ToLua.Push(L, offBtn);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index offBtn on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Index(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISelectionBtn uISelectionBtn = (UISelectionBtn)obj;
			int index = uISelectionBtn.Index;
			LuaDLL.lua_pushinteger(L, index);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Index on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_ButtonName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISelectionBtn uISelectionBtn = (UISelectionBtn)obj;
			string buttonName = uISelectionBtn.ButtonName;
			LuaDLL.lua_pushstring(L, buttonName);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ButtonName on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onChangeSignal(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISelectionBtn uISelectionBtn = (UISelectionBtn)obj;
			Signal<UISelectionBtn> onChangeSignal = uISelectionBtn.onChangeSignal;
			ToLua.PushObject(L, onChangeSignal);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onChangeSignal on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onChange(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISelectionBtn uISelectionBtn = (UISelectionBtn)obj;
			List<EventDelegate> onChange = uISelectionBtn.onChange;
			ToLua.PushObject(L, onChange);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onChange on a nil value");
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
			UISelectionBtn uISelectionBtn = (UISelectionBtn)obj;
			Signal<UISelectionBtn> onInvalidClickSignal = uISelectionBtn.onInvalidClickSignal;
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
	private static int get_BtnEnabled(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISelectionBtn uISelectionBtn = (UISelectionBtn)obj;
			bool btnEnabled = uISelectionBtn.BtnEnabled;
			LuaDLL.lua_pushboolean(L, btnEnabled);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index BtnEnabled on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_IsOn(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISelectionBtn uISelectionBtn = (UISelectionBtn)obj;
			bool isOn = uISelectionBtn.IsOn;
			LuaDLL.lua_pushboolean(L, isOn);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index IsOn on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Value(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISelectionBtn uISelectionBtn = (UISelectionBtn)obj;
			float value = uISelectionBtn.Value;
			LuaDLL.lua_pushnumber(L, (double)value);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Value on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onBtn(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISelectionBtn uISelectionBtn = (UISelectionBtn)obj;
			GameObject onBtn = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			uISelectionBtn.onBtn = onBtn;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onBtn on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_offBtn(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISelectionBtn uISelectionBtn = (UISelectionBtn)obj;
			GameObject offBtn = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			uISelectionBtn.offBtn = offBtn;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index offBtn on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Index(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISelectionBtn uISelectionBtn = (UISelectionBtn)obj;
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			uISelectionBtn.Index = index;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Index on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_ButtonName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISelectionBtn uISelectionBtn = (UISelectionBtn)obj;
			string buttonName = ToLua.CheckString(L, 2);
			uISelectionBtn.ButtonName = buttonName;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ButtonName on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onChange(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISelectionBtn uISelectionBtn = (UISelectionBtn)obj;
			List<EventDelegate> onChange = (List<EventDelegate>)ToLua.CheckObject(L, 2, typeof(List<EventDelegate>));
			uISelectionBtn.onChange = onChange;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onChange on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_BtnEnabled(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISelectionBtn uISelectionBtn = (UISelectionBtn)obj;
			bool btnEnabled = LuaDLL.luaL_checkboolean(L, 2);
			uISelectionBtn.BtnEnabled = btnEnabled;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index BtnEnabled on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_IsOn(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISelectionBtn uISelectionBtn = (UISelectionBtn)obj;
			bool isOn = LuaDLL.luaL_checkboolean(L, 2);
			uISelectionBtn.IsOn = isOn;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index IsOn on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Value(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISelectionBtn uISelectionBtn = (UISelectionBtn)obj;
			float value = (float)LuaDLL.luaL_checknumber(L, 2);
			uISelectionBtn.Value = value;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Value on a nil value");
		}
		return result;
	}
}
