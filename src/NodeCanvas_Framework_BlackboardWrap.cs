using LuaInterface;
using NodeCanvas.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class NodeCanvas_Framework_BlackboardWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Blackboard), typeof(MonoBehaviour), null);
		L.RegFunction("OnBeforeSerialize", new LuaCSFunction(NodeCanvas_Framework_BlackboardWrap.OnBeforeSerialize));
		L.RegFunction("OnAfterDeserialize", new LuaCSFunction(NodeCanvas_Framework_BlackboardWrap.OnAfterDeserialize));
		L.RegFunction("get_Item", new LuaCSFunction(NodeCanvas_Framework_BlackboardWrap.get_Item));
		L.RegFunction("set_Item", new LuaCSFunction(NodeCanvas_Framework_BlackboardWrap.set_Item));
		L.RegFunction("AddVariable", new LuaCSFunction(NodeCanvas_Framework_BlackboardWrap.AddVariable));
		L.RegFunction("GetVariable", new LuaCSFunction(NodeCanvas_Framework_BlackboardWrap.GetVariable));
		L.RegFunction("SetValue", new LuaCSFunction(NodeCanvas_Framework_BlackboardWrap.SetValue));
		L.RegFunction("GetVariableNames", new LuaCSFunction(NodeCanvas_Framework_BlackboardWrap.GetVariableNames));
		L.RegFunction("Save", new LuaCSFunction(NodeCanvas_Framework_BlackboardWrap.Save));
		L.RegFunction("Load", new LuaCSFunction(NodeCanvas_Framework_BlackboardWrap.Load));
		L.RegVar("this", new LuaCSFunction(NodeCanvas_Framework_BlackboardWrap._this), null);
		L.RegFunction("__eq", new LuaCSFunction(NodeCanvas_Framework_BlackboardWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("name", new LuaCSFunction(NodeCanvas_Framework_BlackboardWrap.get_name), new LuaCSFunction(NodeCanvas_Framework_BlackboardWrap.set_name));
		L.RegVar("variables", new LuaCSFunction(NodeCanvas_Framework_BlackboardWrap.get_variables), new LuaCSFunction(NodeCanvas_Framework_BlackboardWrap.set_variables));
		L.RegVar("propertiesBindTarget", new LuaCSFunction(NodeCanvas_Framework_BlackboardWrap.get_propertiesBindTarget), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _get_this(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Blackboard blackboard = (Blackboard)ToLua.CheckObject(L, 1, typeof(Blackboard));
			string varName = ToLua.CheckString(L, 2);
			object obj = blackboard[varName];
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
	private static int _set_this(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Blackboard blackboard = (Blackboard)ToLua.CheckObject(L, 1, typeof(Blackboard));
			string varName = ToLua.CheckString(L, 2);
			object value = ToLua.ToVarObject(L, 3);
			blackboard[varName] = value;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _this(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushvalue(L, 1);
			LuaDLL.tolua_bindthis(L, new LuaCSFunction(NodeCanvas_Framework_BlackboardWrap._get_this), new LuaCSFunction(NodeCanvas_Framework_BlackboardWrap._set_this));
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnBeforeSerialize(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Blackboard blackboard = (Blackboard)ToLua.CheckObject(L, 1, typeof(Blackboard));
			blackboard.OnBeforeSerialize();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnAfterDeserialize(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Blackboard blackboard = (Blackboard)ToLua.CheckObject(L, 1, typeof(Blackboard));
			blackboard.OnAfterDeserialize();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Item(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Blackboard blackboard = (Blackboard)ToLua.CheckObject(L, 1, typeof(Blackboard));
			string varName = ToLua.CheckString(L, 2);
			object obj = blackboard[varName];
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
	private static int set_Item(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Blackboard blackboard = (Blackboard)ToLua.CheckObject(L, 1, typeof(Blackboard));
			string varName = ToLua.CheckString(L, 2);
			object value = ToLua.ToVarObject(L, 3);
			blackboard[varName] = value;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddVariable(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Blackboard blackboard = (Blackboard)ToLua.CheckObject(L, 1, typeof(Blackboard));
			string name = ToLua.CheckString(L, 2);
			Type type = (Type)ToLua.CheckObject(L, 3, typeof(Type));
			Variable o = blackboard.AddVariable(name, type);
			ToLua.PushObject(L, o);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetVariable(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Blackboard blackboard = (Blackboard)ToLua.CheckObject(L, 1, typeof(Blackboard));
			string name = ToLua.CheckString(L, 2);
			Type ofType = (Type)ToLua.CheckObject(L, 3, typeof(Type));
			Variable variable = blackboard.GetVariable(name, ofType);
			ToLua.PushObject(L, variable);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetValue(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Blackboard blackboard = (Blackboard)ToLua.CheckObject(L, 1, typeof(Blackboard));
			string name = ToLua.CheckString(L, 2);
			object value = ToLua.ToVarObject(L, 3);
			Variable o = blackboard.SetValue(name, value);
			ToLua.PushObject(L, o);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetVariableNames(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(Blackboard)))
			{
				Blackboard blackboard = (Blackboard)ToLua.ToObject(L, 1);
				string[] variableNames = blackboard.GetVariableNames();
				ToLua.Push(L, variableNames);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Blackboard), typeof(Type)))
			{
				Blackboard blackboard2 = (Blackboard)ToLua.ToObject(L, 1);
				Type ofType = (Type)ToLua.ToObject(L, 2);
				string[] variableNames2 = blackboard2.GetVariableNames(ofType);
				ToLua.Push(L, variableNames2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: NodeCanvas.Framework.Blackboard.GetVariableNames");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Save(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(Blackboard)))
			{
				Blackboard blackboard = (Blackboard)ToLua.ToObject(L, 1);
				string str = blackboard.Save();
				LuaDLL.lua_pushstring(L, str);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Blackboard), typeof(string)))
			{
				Blackboard blackboard2 = (Blackboard)ToLua.ToObject(L, 1);
				string saveKey = ToLua.ToString(L, 2);
				string str2 = blackboard2.Save(saveKey);
				LuaDLL.lua_pushstring(L, str2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: NodeCanvas.Framework.Blackboard.Save");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Load(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(Blackboard)))
			{
				Blackboard blackboard = (Blackboard)ToLua.ToObject(L, 1);
				bool value = blackboard.Load();
				LuaDLL.lua_pushboolean(L, value);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Blackboard), typeof(string)))
			{
				Blackboard blackboard2 = (Blackboard)ToLua.ToObject(L, 1);
				string saveKey = ToLua.ToString(L, 2);
				bool value2 = blackboard2.Load(saveKey);
				LuaDLL.lua_pushboolean(L, value2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: NodeCanvas.Framework.Blackboard.Load");
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
	private static int get_name(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Blackboard blackboard = (Blackboard)obj;
			string name = blackboard.name;
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
	private static int get_variables(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Blackboard blackboard = (Blackboard)obj;
			Dictionary<string, Variable> variables = blackboard.variables;
			ToLua.PushObject(L, variables);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index variables on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_propertiesBindTarget(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Blackboard blackboard = (Blackboard)obj;
			GameObject propertiesBindTarget = blackboard.propertiesBindTarget;
			ToLua.Push(L, propertiesBindTarget);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index propertiesBindTarget on a nil value");
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
			Blackboard blackboard = (Blackboard)obj;
			string name = ToLua.CheckString(L, 2);
			blackboard.name = name;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index name on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_variables(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Blackboard blackboard = (Blackboard)obj;
			Dictionary<string, Variable> variables = (Dictionary<string, Variable>)ToLua.CheckObject(L, 2, typeof(Dictionary<string, Variable>));
			blackboard.variables = variables;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index variables on a nil value");
		}
		return result;
	}
}
