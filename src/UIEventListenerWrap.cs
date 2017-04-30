using LuaInterface;
using System;
using UnityEngine;

public class UIEventListenerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UIEventListener), typeof(MonoBehaviour), null);
		L.RegFunction("Get", new LuaCSFunction(UIEventListenerWrap.Get));
		L.RegFunction("__eq", new LuaCSFunction(UIEventListenerWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("parameter", new LuaCSFunction(UIEventListenerWrap.get_parameter), new LuaCSFunction(UIEventListenerWrap.set_parameter));
		L.RegVar("onSubmit", new LuaCSFunction(UIEventListenerWrap.get_onSubmit), new LuaCSFunction(UIEventListenerWrap.set_onSubmit));
		L.RegVar("onClick", new LuaCSFunction(UIEventListenerWrap.get_onClick), new LuaCSFunction(UIEventListenerWrap.set_onClick));
		L.RegVar("onDoubleClick", new LuaCSFunction(UIEventListenerWrap.get_onDoubleClick), new LuaCSFunction(UIEventListenerWrap.set_onDoubleClick));
		L.RegVar("onHover", new LuaCSFunction(UIEventListenerWrap.get_onHover), new LuaCSFunction(UIEventListenerWrap.set_onHover));
		L.RegVar("onPress", new LuaCSFunction(UIEventListenerWrap.get_onPress), new LuaCSFunction(UIEventListenerWrap.set_onPress));
		L.RegVar("onSelect", new LuaCSFunction(UIEventListenerWrap.get_onSelect), new LuaCSFunction(UIEventListenerWrap.set_onSelect));
		L.RegVar("onScroll", new LuaCSFunction(UIEventListenerWrap.get_onScroll), new LuaCSFunction(UIEventListenerWrap.set_onScroll));
		L.RegVar("onDragStart", new LuaCSFunction(UIEventListenerWrap.get_onDragStart), new LuaCSFunction(UIEventListenerWrap.set_onDragStart));
		L.RegVar("onDrag", new LuaCSFunction(UIEventListenerWrap.get_onDrag), new LuaCSFunction(UIEventListenerWrap.set_onDrag));
		L.RegVar("onDragOver", new LuaCSFunction(UIEventListenerWrap.get_onDragOver), new LuaCSFunction(UIEventListenerWrap.set_onDragOver));
		L.RegVar("onDragOut", new LuaCSFunction(UIEventListenerWrap.get_onDragOut), new LuaCSFunction(UIEventListenerWrap.set_onDragOut));
		L.RegVar("onDragEnd", new LuaCSFunction(UIEventListenerWrap.get_onDragEnd), new LuaCSFunction(UIEventListenerWrap.set_onDragEnd));
		L.RegVar("onDrop", new LuaCSFunction(UIEventListenerWrap.get_onDrop), new LuaCSFunction(UIEventListenerWrap.set_onDrop));
		L.RegVar("onKey", new LuaCSFunction(UIEventListenerWrap.get_onKey), new LuaCSFunction(UIEventListenerWrap.set_onKey));
		L.RegVar("onTooltip", new LuaCSFunction(UIEventListenerWrap.get_onTooltip), new LuaCSFunction(UIEventListenerWrap.set_onTooltip));
		L.RegFunction("BoolDelegate", new LuaCSFunction(UIEventListenerWrap.UIEventListener_BoolDelegate));
		L.RegFunction("KeyCodeDelegate", new LuaCSFunction(UIEventListenerWrap.UIEventListener_KeyCodeDelegate));
		L.RegFunction("ObjectDelegate", new LuaCSFunction(UIEventListenerWrap.UIEventListener_ObjectDelegate));
		L.RegFunction("VoidDelegate", new LuaCSFunction(UIEventListenerWrap.UIEventListener_VoidDelegate));
		L.RegFunction("VectorDelegate", new LuaCSFunction(UIEventListenerWrap.UIEventListener_VectorDelegate));
		L.RegFunction("FloatDelegate", new LuaCSFunction(UIEventListenerWrap.UIEventListener_FloatDelegate));
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
			UIEventListener obj = UIEventListener.Get(go);
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
	private static int get_parameter(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIEventListener uIEventListener = (UIEventListener)obj;
			object parameter = uIEventListener.parameter;
			ToLua.Push(L, parameter);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index parameter on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onSubmit(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIEventListener uIEventListener = (UIEventListener)obj;
			UIEventListener.VoidDelegate onSubmit = uIEventListener.onSubmit;
			ToLua.Push(L, onSubmit);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onSubmit on a nil value");
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
			UIEventListener uIEventListener = (UIEventListener)obj;
			UIEventListener.VoidDelegate onClick = uIEventListener.onClick;
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
	private static int get_onDoubleClick(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIEventListener uIEventListener = (UIEventListener)obj;
			UIEventListener.VoidDelegate onDoubleClick = uIEventListener.onDoubleClick;
			ToLua.Push(L, onDoubleClick);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onDoubleClick on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onHover(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIEventListener uIEventListener = (UIEventListener)obj;
			UIEventListener.BoolDelegate onHover = uIEventListener.onHover;
			ToLua.Push(L, onHover);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onHover on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onPress(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIEventListener uIEventListener = (UIEventListener)obj;
			UIEventListener.BoolDelegate onPress = uIEventListener.onPress;
			ToLua.Push(L, onPress);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onPress on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onSelect(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIEventListener uIEventListener = (UIEventListener)obj;
			UIEventListener.BoolDelegate onSelect = uIEventListener.onSelect;
			ToLua.Push(L, onSelect);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onSelect on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onScroll(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIEventListener uIEventListener = (UIEventListener)obj;
			UIEventListener.FloatDelegate onScroll = uIEventListener.onScroll;
			ToLua.Push(L, onScroll);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onScroll on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onDragStart(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIEventListener uIEventListener = (UIEventListener)obj;
			UIEventListener.VoidDelegate onDragStart = uIEventListener.onDragStart;
			ToLua.Push(L, onDragStart);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onDragStart on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onDrag(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIEventListener uIEventListener = (UIEventListener)obj;
			UIEventListener.VectorDelegate onDrag = uIEventListener.onDrag;
			ToLua.Push(L, onDrag);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onDrag on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onDragOver(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIEventListener uIEventListener = (UIEventListener)obj;
			UIEventListener.VoidDelegate onDragOver = uIEventListener.onDragOver;
			ToLua.Push(L, onDragOver);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onDragOver on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onDragOut(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIEventListener uIEventListener = (UIEventListener)obj;
			UIEventListener.VoidDelegate onDragOut = uIEventListener.onDragOut;
			ToLua.Push(L, onDragOut);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onDragOut on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onDragEnd(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIEventListener uIEventListener = (UIEventListener)obj;
			UIEventListener.VoidDelegate onDragEnd = uIEventListener.onDragEnd;
			ToLua.Push(L, onDragEnd);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onDragEnd on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onDrop(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIEventListener uIEventListener = (UIEventListener)obj;
			UIEventListener.ObjectDelegate onDrop = uIEventListener.onDrop;
			ToLua.Push(L, onDrop);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onDrop on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onKey(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIEventListener uIEventListener = (UIEventListener)obj;
			UIEventListener.KeyCodeDelegate onKey = uIEventListener.onKey;
			ToLua.Push(L, onKey);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onKey on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onTooltip(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIEventListener uIEventListener = (UIEventListener)obj;
			UIEventListener.BoolDelegate onTooltip = uIEventListener.onTooltip;
			ToLua.Push(L, onTooltip);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onTooltip on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_parameter(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIEventListener uIEventListener = (UIEventListener)obj;
			object parameter = ToLua.ToVarObject(L, 2);
			uIEventListener.parameter = parameter;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index parameter on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onSubmit(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIEventListener uIEventListener = (UIEventListener)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UIEventListener.VoidDelegate onSubmit;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onSubmit = (UIEventListener.VoidDelegate)ToLua.CheckObject(L, 2, typeof(UIEventListener.VoidDelegate));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onSubmit = (DelegateFactory.CreateDelegate(typeof(UIEventListener.VoidDelegate), func) as UIEventListener.VoidDelegate);
			}
			uIEventListener.onSubmit = onSubmit;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onSubmit on a nil value");
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
			UIEventListener uIEventListener = (UIEventListener)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UIEventListener.VoidDelegate onClick;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onClick = (UIEventListener.VoidDelegate)ToLua.CheckObject(L, 2, typeof(UIEventListener.VoidDelegate));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onClick = (DelegateFactory.CreateDelegate(typeof(UIEventListener.VoidDelegate), func) as UIEventListener.VoidDelegate);
			}
			uIEventListener.onClick = onClick;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onClick on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onDoubleClick(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIEventListener uIEventListener = (UIEventListener)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UIEventListener.VoidDelegate onDoubleClick;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onDoubleClick = (UIEventListener.VoidDelegate)ToLua.CheckObject(L, 2, typeof(UIEventListener.VoidDelegate));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onDoubleClick = (DelegateFactory.CreateDelegate(typeof(UIEventListener.VoidDelegate), func) as UIEventListener.VoidDelegate);
			}
			uIEventListener.onDoubleClick = onDoubleClick;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onDoubleClick on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onHover(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIEventListener uIEventListener = (UIEventListener)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UIEventListener.BoolDelegate onHover;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onHover = (UIEventListener.BoolDelegate)ToLua.CheckObject(L, 2, typeof(UIEventListener.BoolDelegate));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onHover = (DelegateFactory.CreateDelegate(typeof(UIEventListener.BoolDelegate), func) as UIEventListener.BoolDelegate);
			}
			uIEventListener.onHover = onHover;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onHover on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onPress(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIEventListener uIEventListener = (UIEventListener)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UIEventListener.BoolDelegate onPress;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onPress = (UIEventListener.BoolDelegate)ToLua.CheckObject(L, 2, typeof(UIEventListener.BoolDelegate));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onPress = (DelegateFactory.CreateDelegate(typeof(UIEventListener.BoolDelegate), func) as UIEventListener.BoolDelegate);
			}
			uIEventListener.onPress = onPress;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onPress on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onSelect(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIEventListener uIEventListener = (UIEventListener)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UIEventListener.BoolDelegate onSelect;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onSelect = (UIEventListener.BoolDelegate)ToLua.CheckObject(L, 2, typeof(UIEventListener.BoolDelegate));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onSelect = (DelegateFactory.CreateDelegate(typeof(UIEventListener.BoolDelegate), func) as UIEventListener.BoolDelegate);
			}
			uIEventListener.onSelect = onSelect;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onSelect on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onScroll(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIEventListener uIEventListener = (UIEventListener)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UIEventListener.FloatDelegate onScroll;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onScroll = (UIEventListener.FloatDelegate)ToLua.CheckObject(L, 2, typeof(UIEventListener.FloatDelegate));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onScroll = (DelegateFactory.CreateDelegate(typeof(UIEventListener.FloatDelegate), func) as UIEventListener.FloatDelegate);
			}
			uIEventListener.onScroll = onScroll;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onScroll on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onDragStart(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIEventListener uIEventListener = (UIEventListener)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UIEventListener.VoidDelegate onDragStart;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onDragStart = (UIEventListener.VoidDelegate)ToLua.CheckObject(L, 2, typeof(UIEventListener.VoidDelegate));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onDragStart = (DelegateFactory.CreateDelegate(typeof(UIEventListener.VoidDelegate), func) as UIEventListener.VoidDelegate);
			}
			uIEventListener.onDragStart = onDragStart;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onDragStart on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onDrag(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIEventListener uIEventListener = (UIEventListener)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UIEventListener.VectorDelegate onDrag;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onDrag = (UIEventListener.VectorDelegate)ToLua.CheckObject(L, 2, typeof(UIEventListener.VectorDelegate));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onDrag = (DelegateFactory.CreateDelegate(typeof(UIEventListener.VectorDelegate), func) as UIEventListener.VectorDelegate);
			}
			uIEventListener.onDrag = onDrag;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onDrag on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onDragOver(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIEventListener uIEventListener = (UIEventListener)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UIEventListener.VoidDelegate onDragOver;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onDragOver = (UIEventListener.VoidDelegate)ToLua.CheckObject(L, 2, typeof(UIEventListener.VoidDelegate));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onDragOver = (DelegateFactory.CreateDelegate(typeof(UIEventListener.VoidDelegate), func) as UIEventListener.VoidDelegate);
			}
			uIEventListener.onDragOver = onDragOver;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onDragOver on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onDragOut(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIEventListener uIEventListener = (UIEventListener)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UIEventListener.VoidDelegate onDragOut;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onDragOut = (UIEventListener.VoidDelegate)ToLua.CheckObject(L, 2, typeof(UIEventListener.VoidDelegate));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onDragOut = (DelegateFactory.CreateDelegate(typeof(UIEventListener.VoidDelegate), func) as UIEventListener.VoidDelegate);
			}
			uIEventListener.onDragOut = onDragOut;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onDragOut on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onDragEnd(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIEventListener uIEventListener = (UIEventListener)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UIEventListener.VoidDelegate onDragEnd;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onDragEnd = (UIEventListener.VoidDelegate)ToLua.CheckObject(L, 2, typeof(UIEventListener.VoidDelegate));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onDragEnd = (DelegateFactory.CreateDelegate(typeof(UIEventListener.VoidDelegate), func) as UIEventListener.VoidDelegate);
			}
			uIEventListener.onDragEnd = onDragEnd;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onDragEnd on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onDrop(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIEventListener uIEventListener = (UIEventListener)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UIEventListener.ObjectDelegate onDrop;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onDrop = (UIEventListener.ObjectDelegate)ToLua.CheckObject(L, 2, typeof(UIEventListener.ObjectDelegate));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onDrop = (DelegateFactory.CreateDelegate(typeof(UIEventListener.ObjectDelegate), func) as UIEventListener.ObjectDelegate);
			}
			uIEventListener.onDrop = onDrop;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onDrop on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onKey(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIEventListener uIEventListener = (UIEventListener)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UIEventListener.KeyCodeDelegate onKey;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onKey = (UIEventListener.KeyCodeDelegate)ToLua.CheckObject(L, 2, typeof(UIEventListener.KeyCodeDelegate));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onKey = (DelegateFactory.CreateDelegate(typeof(UIEventListener.KeyCodeDelegate), func) as UIEventListener.KeyCodeDelegate);
			}
			uIEventListener.onKey = onKey;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onKey on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onTooltip(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIEventListener uIEventListener = (UIEventListener)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UIEventListener.BoolDelegate onTooltip;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onTooltip = (UIEventListener.BoolDelegate)ToLua.CheckObject(L, 2, typeof(UIEventListener.BoolDelegate));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onTooltip = (DelegateFactory.CreateDelegate(typeof(UIEventListener.BoolDelegate), func) as UIEventListener.BoolDelegate);
			}
			uIEventListener.onTooltip = onTooltip;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onTooltip on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UIEventListener_BoolDelegate(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UIEventListener.BoolDelegate), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UIEventListener.BoolDelegate), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UIEventListener_KeyCodeDelegate(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UIEventListener.KeyCodeDelegate), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UIEventListener.KeyCodeDelegate), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UIEventListener_ObjectDelegate(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UIEventListener.ObjectDelegate), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UIEventListener.ObjectDelegate), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UIEventListener_VoidDelegate(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UIEventListener.VoidDelegate), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UIEventListener.VoidDelegate), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UIEventListener_VectorDelegate(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UIEventListener.VectorDelegate), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UIEventListener.VectorDelegate), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UIEventListener_FloatDelegate(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UIEventListener.FloatDelegate), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UIEventListener.FloatDelegate), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
