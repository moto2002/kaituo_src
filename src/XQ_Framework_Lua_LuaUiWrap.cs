using LuaInterface;
using NodeCanvas.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using XQ.Framework.Lua;

public class XQ_Framework_Lua_LuaUiWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(LuaUi), typeof(MonoBehaviour), null);
		L.RegFunction("Initialize", new LuaCSFunction(XQ_Framework_Lua_LuaUiWrap.Initialize));
		L.RegFunction("GetField", new LuaCSFunction(XQ_Framework_Lua_LuaUiWrap.GetField));
		L.RegFunction("GetFields", new LuaCSFunction(XQ_Framework_Lua_LuaUiWrap.GetFields));
		L.RegFunction("ManulAddEvent", new LuaCSFunction(XQ_Framework_Lua_LuaUiWrap.ManulAddEvent));
		L.RegFunction("InitLife", new LuaCSFunction(XQ_Framework_Lua_LuaUiWrap.InitLife));
		L.RegFunction("__eq", new LuaCSFunction(XQ_Framework_Lua_LuaUiWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("FileName", new LuaCSFunction(XQ_Framework_Lua_LuaUiWrap.get_FileName), new LuaCSFunction(XQ_Framework_Lua_LuaUiWrap.set_FileName));
		L.RegVar("Fields", new LuaCSFunction(XQ_Framework_Lua_LuaUiWrap.get_Fields), new LuaCSFunction(XQ_Framework_Lua_LuaUiWrap.set_Fields));
		L.RegVar("Events", new LuaCSFunction(XQ_Framework_Lua_LuaUiWrap.get_Events), new LuaCSFunction(XQ_Framework_Lua_LuaUiWrap.set_Events));
		L.RegVar("Blackboard", new LuaCSFunction(XQ_Framework_Lua_LuaUiWrap.get_Blackboard), new LuaCSFunction(XQ_Framework_Lua_LuaUiWrap.set_Blackboard));
		L.RegVar("Life", new LuaCSFunction(XQ_Framework_Lua_LuaUiWrap.get_Life), new LuaCSFunction(XQ_Framework_Lua_LuaUiWrap.set_Life));
		L.RegVar("BindingTable", new LuaCSFunction(XQ_Framework_Lua_LuaUiWrap.get_BindingTable), new LuaCSFunction(XQ_Framework_Lua_LuaUiWrap.set_BindingTable));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Initialize(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			LuaUi luaUi = (LuaUi)ToLua.CheckObject(L, 1, typeof(LuaUi));
			LuaTable outputFields = ToLua.CheckLuaTable(L, 2);
			LuaTable bindingTable = ToLua.CheckLuaTable(L, 3);
			luaUi.Initialize(outputFields, bindingTable);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetField(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			LuaUi luaUi = (LuaUi)ToLua.CheckObject(L, 1, typeof(LuaUi));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.Object field = luaUi.GetField(index);
			ToLua.Push(L, field);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetFields(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			LuaUi luaUi = (LuaUi)ToLua.CheckObject(L, 1, typeof(LuaUi));
			LuaTable outputFields = ToLua.CheckLuaTable(L, 2);
			luaUi.GetFields(outputFields);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ManulAddEvent(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			LuaUi luaUi = (LuaUi)ToLua.CheckObject(L, 1, typeof(LuaUi));
			LuaTable bindingTable = ToLua.CheckLuaTable(L, 2);
			luaUi.ManulAddEvent(bindingTable);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int InitLife(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			LuaUi luaUi = (LuaUi)ToLua.CheckObject(L, 1, typeof(LuaUi));
			LuaTable boundTable = ToLua.CheckLuaTable(L, 2);
			luaUi.InitLife(boundTable);
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
	private static int get_FileName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LuaUi luaUi = (LuaUi)obj;
			string fileName = luaUi.FileName;
			LuaDLL.lua_pushstring(L, fileName);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index FileName on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Fields(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LuaUi luaUi = (LuaUi)obj;
			List<LuaUi.LuaUiField> fields = luaUi.Fields;
			ToLua.PushObject(L, fields);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Fields on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Events(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LuaUi luaUi = (LuaUi)obj;
			List<LuaUi.LuaUiEvent> events = luaUi.Events;
			ToLua.PushObject(L, events);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Events on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Blackboard(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LuaUi luaUi = (LuaUi)obj;
			Blackboard blackboard = luaUi.Blackboard;
			ToLua.Push(L, blackboard);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Blackboard on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Life(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LuaUi luaUi = (LuaUi)obj;
			LuaUi.LuaUiLife life = luaUi.Life;
			ToLua.PushObject(L, life);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Life on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_BindingTable(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LuaUi luaUi = (LuaUi)obj;
			LuaTable bindingTable = luaUi.BindingTable;
			ToLua.Push(L, bindingTable);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index BindingTable on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_FileName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LuaUi luaUi = (LuaUi)obj;
			string fileName = ToLua.CheckString(L, 2);
			luaUi.FileName = fileName;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index FileName on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Fields(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LuaUi luaUi = (LuaUi)obj;
			List<LuaUi.LuaUiField> fields = (List<LuaUi.LuaUiField>)ToLua.CheckObject(L, 2, typeof(List<LuaUi.LuaUiField>));
			luaUi.Fields = fields;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Fields on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Events(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LuaUi luaUi = (LuaUi)obj;
			List<LuaUi.LuaUiEvent> events = (List<LuaUi.LuaUiEvent>)ToLua.CheckObject(L, 2, typeof(List<LuaUi.LuaUiEvent>));
			luaUi.Events = events;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Events on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Blackboard(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LuaUi luaUi = (LuaUi)obj;
			Blackboard blackboard = (Blackboard)ToLua.CheckUnityObject(L, 2, typeof(Blackboard));
			luaUi.Blackboard = blackboard;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Blackboard on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Life(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LuaUi luaUi = (LuaUi)obj;
			LuaUi.LuaUiLife life = (LuaUi.LuaUiLife)ToLua.CheckObject(L, 2, typeof(LuaUi.LuaUiLife));
			luaUi.Life = life;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Life on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_BindingTable(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LuaUi luaUi = (LuaUi)obj;
			LuaTable bindingTable = ToLua.CheckLuaTable(L, 2);
			luaUi.BindingTable = bindingTable;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index BindingTable on a nil value");
		}
		return result;
	}
}
