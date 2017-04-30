using Assets.Extends.EXNGUI.Compoment;
using Assets.Tools.Script.Event;
using LuaInterface;
using System;

public class Assets_Tools_Script_Event_Signal_Assets_Extends_EXNGUI_Compoment_UISelectionBtnWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Signal<UISelectionBtn>), typeof(object), "Signal_Assets_Extends_EXNGUI_Compoment_UISelectionBtn");
		L.RegFunction("AddEventListener", new LuaCSFunction(Assets_Tools_Script_Event_Signal_Assets_Extends_EXNGUI_Compoment_UISelectionBtnWrap.AddEventListener));
		L.RegFunction("RemoveEventListener", new LuaCSFunction(Assets_Tools_Script_Event_Signal_Assets_Extends_EXNGUI_Compoment_UISelectionBtnWrap.RemoveEventListener));
		L.RegFunction("Clear", new LuaCSFunction(Assets_Tools_Script_Event_Signal_Assets_Extends_EXNGUI_Compoment_UISelectionBtnWrap.Clear));
		L.RegFunction("Dispatch", new LuaCSFunction(Assets_Tools_Script_Event_Signal_Assets_Extends_EXNGUI_Compoment_UISelectionBtnWrap.Dispatch));
		L.RegFunction("New", new LuaCSFunction(Assets_Tools_Script_Event_Signal_Assets_Extends_EXNGUI_Compoment_UISelectionBtnWrap._CreateAssets_Tools_Script_Event_Signal_Assets_Extends_EXNGUI_Compoment_UISelectionBtn));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateAssets_Tools_Script_Event_Signal_Assets_Extends_EXNGUI_Compoment_UISelectionBtn(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				Signal<UISelectionBtn> o = new Signal<UISelectionBtn>();
				ToLua.PushObject(L, o);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: Assets.Tools.Script.Event.Signal<Assets.Extends.EXNGUI.Compoment.UISelectionBtn>.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddEventListener(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Signal<UISelectionBtn> signal = (Signal<UISelectionBtn>)ToLua.CheckObject(L, 1, typeof(Signal<UISelectionBtn>));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Action<UISelectionBtn> handler;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				handler = (Action<UISelectionBtn>)ToLua.CheckObject(L, 2, typeof(Action<UISelectionBtn>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				handler = (DelegateFactory.CreateDelegate(typeof(Action<UISelectionBtn>), func) as Action<UISelectionBtn>);
			}
			signal.AddEventListener(handler);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RemoveEventListener(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Signal<UISelectionBtn> signal = (Signal<UISelectionBtn>)ToLua.CheckObject(L, 1, typeof(Signal<UISelectionBtn>));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Action<UISelectionBtn> handler;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				handler = (Action<UISelectionBtn>)ToLua.CheckObject(L, 2, typeof(Action<UISelectionBtn>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				handler = (DelegateFactory.CreateDelegate(typeof(Action<UISelectionBtn>), func) as Action<UISelectionBtn>);
			}
			signal.RemoveEventListener(handler);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Clear(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Signal<UISelectionBtn> signal = (Signal<UISelectionBtn>)ToLua.CheckObject(L, 1, typeof(Signal<UISelectionBtn>));
			signal.Clear();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Dispatch(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Signal<UISelectionBtn> signal = (Signal<UISelectionBtn>)ToLua.CheckObject(L, 1, typeof(Signal<UISelectionBtn>));
			UISelectionBtn arg = (UISelectionBtn)ToLua.CheckUnityObject(L, 2, typeof(UISelectionBtn));
			signal.Dispatch(arg);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
