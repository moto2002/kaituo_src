using LuaInterface;
using NodeCanvas;
using NodeCanvas.BehaviourTrees;
using NodeCanvas.Framework;
using System;
using UnityEngine;

public class NodeCanvas_BehaviourTrees_BehaviourTreeOwnerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(BehaviourTreeOwner), typeof(GraphOwner<BehaviourTree>), null);
		L.RegFunction("Tick", new LuaCSFunction(NodeCanvas_BehaviourTrees_BehaviourTreeOwnerWrap.Tick));
		L.RegFunction("__eq", new LuaCSFunction(NodeCanvas_BehaviourTrees_BehaviourTreeOwnerWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("repeat", new LuaCSFunction(NodeCanvas_BehaviourTrees_BehaviourTreeOwnerWrap.get_repeat), new LuaCSFunction(NodeCanvas_BehaviourTrees_BehaviourTreeOwnerWrap.set_repeat));
		L.RegVar("updateInterval", new LuaCSFunction(NodeCanvas_BehaviourTrees_BehaviourTreeOwnerWrap.get_updateInterval), new LuaCSFunction(NodeCanvas_BehaviourTrees_BehaviourTreeOwnerWrap.set_updateInterval));
		L.RegVar("rootStatus", new LuaCSFunction(NodeCanvas_BehaviourTrees_BehaviourTreeOwnerWrap.get_rootStatus), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Tick(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			BehaviourTreeOwner behaviourTreeOwner = (BehaviourTreeOwner)ToLua.CheckObject(L, 1, typeof(BehaviourTreeOwner));
			Status status = behaviourTreeOwner.Tick();
			ToLua.Push(L, status);
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
	private static int get_repeat(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			BehaviourTreeOwner behaviourTreeOwner = (BehaviourTreeOwner)obj;
			bool repeat = behaviourTreeOwner.repeat;
			LuaDLL.lua_pushboolean(L, repeat);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index repeat on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_updateInterval(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			BehaviourTreeOwner behaviourTreeOwner = (BehaviourTreeOwner)obj;
			float updateInterval = behaviourTreeOwner.updateInterval;
			LuaDLL.lua_pushnumber(L, (double)updateInterval);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index updateInterval on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_rootStatus(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			BehaviourTreeOwner behaviourTreeOwner = (BehaviourTreeOwner)obj;
			Status rootStatus = behaviourTreeOwner.rootStatus;
			ToLua.Push(L, rootStatus);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index rootStatus on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_repeat(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			BehaviourTreeOwner behaviourTreeOwner = (BehaviourTreeOwner)obj;
			bool repeat = LuaDLL.luaL_checkboolean(L, 2);
			behaviourTreeOwner.repeat = repeat;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index repeat on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_updateInterval(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			BehaviourTreeOwner behaviourTreeOwner = (BehaviourTreeOwner)obj;
			float updateInterval = (float)LuaDLL.luaL_checknumber(L, 2);
			behaviourTreeOwner.updateInterval = updateInterval;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index updateInterval on a nil value");
		}
		return result;
	}
}
