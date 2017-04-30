using Assets.Scripts.Performance;
using LuaInterface;
using NodeCanvas.BehaviourTrees;
using NodeCanvas.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Assets_Scripts_Performance_BTProxyWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(BTProxy), typeof(MonoBehaviour), null);
		L.RegFunction("CacheBlackboard", new LuaCSFunction(Assets_Scripts_Performance_BTProxyWrap.CacheBlackboard));
		L.RegFunction("RestoreBlackboard", new LuaCSFunction(Assets_Scripts_Performance_BTProxyWrap.RestoreBlackboard));
		L.RegFunction("SetValue", new LuaCSFunction(Assets_Scripts_Performance_BTProxyWrap.SetValue));
		L.RegFunction("SetJsonValue", new LuaCSFunction(Assets_Scripts_Performance_BTProxyWrap.SetJsonValue));
		L.RegFunction("AddValue", new LuaCSFunction(Assets_Scripts_Performance_BTProxyWrap.AddValue));
		L.RegFunction("GetValue", new LuaCSFunction(Assets_Scripts_Performance_BTProxyWrap.GetValue));
		L.RegFunction("HasKey", new LuaCSFunction(Assets_Scripts_Performance_BTProxyWrap.HasKey));
		L.RegFunction("GetKeys", new LuaCSFunction(Assets_Scripts_Performance_BTProxyWrap.GetKeys));
		L.RegFunction("Play", new LuaCSFunction(Assets_Scripts_Performance_BTProxyWrap.Play));
		L.RegFunction("PlayWithTime", new LuaCSFunction(Assets_Scripts_Performance_BTProxyWrap.PlayWithTime));
		L.RegFunction("Stop", new LuaCSFunction(Assets_Scripts_Performance_BTProxyWrap.Stop));
		L.RegFunction("Clear", new LuaCSFunction(Assets_Scripts_Performance_BTProxyWrap.Clear));
		L.RegFunction("__eq", new LuaCSFunction(Assets_Scripts_Performance_BTProxyWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("OnPlayEnd", new LuaCSFunction(Assets_Scripts_Performance_BTProxyWrap.get_OnPlayEnd), new LuaCSFunction(Assets_Scripts_Performance_BTProxyWrap.set_OnPlayEnd));
		L.RegVar("BehaviourTreeOwner", new LuaCSFunction(Assets_Scripts_Performance_BTProxyWrap.get_BehaviourTreeOwner), new LuaCSFunction(Assets_Scripts_Performance_BTProxyWrap.set_BehaviourTreeOwner));
		L.RegVar("Blackboard", new LuaCSFunction(Assets_Scripts_Performance_BTProxyWrap.get_Blackboard), new LuaCSFunction(Assets_Scripts_Performance_BTProxyWrap.set_Blackboard));
		L.RegVar("RestoreBlackboardOnPlayEnd", new LuaCSFunction(Assets_Scripts_Performance_BTProxyWrap.get_RestoreBlackboardOnPlayEnd), new LuaCSFunction(Assets_Scripts_Performance_BTProxyWrap.set_RestoreBlackboardOnPlayEnd));
		L.RegVar("IsPlaying", new LuaCSFunction(Assets_Scripts_Performance_BTProxyWrap.get_IsPlaying), null);
		L.RegVar("OwnerObject", new LuaCSFunction(Assets_Scripts_Performance_BTProxyWrap.get_OwnerObject), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CacheBlackboard(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			BTProxy bTProxy = (BTProxy)ToLua.CheckObject(L, 1, typeof(BTProxy));
			bTProxy.CacheBlackboard();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RestoreBlackboard(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			BTProxy bTProxy = (BTProxy)ToLua.CheckObject(L, 1, typeof(BTProxy));
			bTProxy.RestoreBlackboard();
			result = 0;
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
			BTProxy bTProxy = (BTProxy)ToLua.CheckObject(L, 1, typeof(BTProxy));
			string key = ToLua.CheckString(L, 2);
			object value = ToLua.ToVarObject(L, 3);
			bTProxy.SetValue(key, value);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetJsonValue(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			BTProxy bTProxy = (BTProxy)ToLua.CheckObject(L, 1, typeof(BTProxy));
			string key = ToLua.CheckString(L, 2);
			string json = ToLua.CheckString(L, 3);
			bTProxy.SetJsonValue(key, json);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddValue(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			BTProxy bTProxy = (BTProxy)ToLua.CheckObject(L, 1, typeof(BTProxy));
			string key = ToLua.CheckString(L, 2);
			object value = ToLua.ToVarObject(L, 3);
			Type type = (Type)ToLua.CheckObject(L, 4, typeof(Type));
			bTProxy.AddValue(key, value, type);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetValue(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			BTProxy bTProxy = (BTProxy)ToLua.CheckObject(L, 1, typeof(BTProxy));
			string key = ToLua.CheckString(L, 2);
			object value = bTProxy.GetValue(key);
			ToLua.Push(L, value);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int HasKey(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			BTProxy bTProxy = (BTProxy)ToLua.CheckObject(L, 1, typeof(BTProxy));
			string key = ToLua.CheckString(L, 2);
			bool value = bTProxy.HasKey(key);
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
	private static int GetKeys(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			BTProxy bTProxy = (BTProxy)ToLua.CheckObject(L, 1, typeof(BTProxy));
			List<string> keys = bTProxy.GetKeys();
			ToLua.PushObject(L, keys);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Play(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			BTProxy bTProxy = (BTProxy)ToLua.CheckObject(L, 1, typeof(BTProxy));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Action onEnd;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onEnd = (Action)ToLua.CheckObject(L, 2, typeof(Action));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onEnd = (DelegateFactory.CreateDelegate(typeof(Action), func) as Action);
			}
			bTProxy.Play(onEnd);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PlayWithTime(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			BTProxy bTProxy = (BTProxy)ToLua.CheckObject(L, 1, typeof(BTProxy));
			float playTime = (float)LuaDLL.luaL_checknumber(L, 2);
			LuaTypes luaTypes = LuaDLL.lua_type(L, 3);
			Action onEnd;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onEnd = (Action)ToLua.CheckObject(L, 3, typeof(Action));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 3);
				onEnd = (DelegateFactory.CreateDelegate(typeof(Action), func) as Action);
			}
			bTProxy.PlayWithTime(playTime, onEnd);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Stop(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			BTProxy bTProxy = (BTProxy)ToLua.CheckObject(L, 1, typeof(BTProxy));
			bTProxy.Stop();
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
			BTProxy bTProxy = (BTProxy)ToLua.CheckObject(L, 1, typeof(BTProxy));
			bTProxy.Clear();
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
	private static int get_OnPlayEnd(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			BTProxy bTProxy = (BTProxy)obj;
			Action onPlayEnd = bTProxy.OnPlayEnd;
			ToLua.Push(L, onPlayEnd);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index OnPlayEnd on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_BehaviourTreeOwner(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			BTProxy bTProxy = (BTProxy)obj;
			BehaviourTreeOwner behaviourTreeOwner = bTProxy.BehaviourTreeOwner;
			ToLua.Push(L, behaviourTreeOwner);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index BehaviourTreeOwner on a nil value");
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
			BTProxy bTProxy = (BTProxy)obj;
			Blackboard blackboard = bTProxy.Blackboard;
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
	private static int get_RestoreBlackboardOnPlayEnd(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			BTProxy bTProxy = (BTProxy)obj;
			bool restoreBlackboardOnPlayEnd = bTProxy.RestoreBlackboardOnPlayEnd;
			LuaDLL.lua_pushboolean(L, restoreBlackboardOnPlayEnd);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index RestoreBlackboardOnPlayEnd on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_IsPlaying(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			BTProxy bTProxy = (BTProxy)obj;
			bool isPlaying = bTProxy.IsPlaying;
			LuaDLL.lua_pushboolean(L, isPlaying);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index IsPlaying on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_OwnerObject(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			BTProxy bTProxy = (BTProxy)obj;
			GameObject ownerObject = bTProxy.OwnerObject;
			ToLua.Push(L, ownerObject);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index OwnerObject on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_OnPlayEnd(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			BTProxy bTProxy = (BTProxy)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Action onPlayEnd;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onPlayEnd = (Action)ToLua.CheckObject(L, 2, typeof(Action));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onPlayEnd = (DelegateFactory.CreateDelegate(typeof(Action), func) as Action);
			}
			bTProxy.OnPlayEnd = onPlayEnd;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index OnPlayEnd on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_BehaviourTreeOwner(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			BTProxy bTProxy = (BTProxy)obj;
			BehaviourTreeOwner behaviourTreeOwner = (BehaviourTreeOwner)ToLua.CheckUnityObject(L, 2, typeof(BehaviourTreeOwner));
			bTProxy.BehaviourTreeOwner = behaviourTreeOwner;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index BehaviourTreeOwner on a nil value");
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
			BTProxy bTProxy = (BTProxy)obj;
			Blackboard blackboard = (Blackboard)ToLua.CheckUnityObject(L, 2, typeof(Blackboard));
			bTProxy.Blackboard = blackboard;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Blackboard on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_RestoreBlackboardOnPlayEnd(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			BTProxy bTProxy = (BTProxy)obj;
			bool restoreBlackboardOnPlayEnd = LuaDLL.luaL_checkboolean(L, 2);
			bTProxy.RestoreBlackboardOnPlayEnd = restoreBlackboardOnPlayEnd;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index RestoreBlackboardOnPlayEnd on a nil value");
		}
		return result;
	}
}
