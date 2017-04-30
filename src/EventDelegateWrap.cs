using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

public class EventDelegateWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(EventDelegate), typeof(object), null);
		L.RegFunction("Equals", new LuaCSFunction(EventDelegateWrap.Equals));
		L.RegFunction("GetHashCode", new LuaCSFunction(EventDelegateWrap.GetHashCode));
		L.RegFunction("Set", new LuaCSFunction(EventDelegateWrap.Set));
		L.RegFunction("Execute", new LuaCSFunction(EventDelegateWrap.Execute));
		L.RegFunction("Clear", new LuaCSFunction(EventDelegateWrap.Clear));
		L.RegFunction("ToString", new LuaCSFunction(EventDelegateWrap.ToString));
		L.RegFunction("IsValid", new LuaCSFunction(EventDelegateWrap.IsValid));
		L.RegFunction("Add", new LuaCSFunction(EventDelegateWrap.Add));
		L.RegFunction("Remove", new LuaCSFunction(EventDelegateWrap.Remove));
		L.RegFunction("New", new LuaCSFunction(EventDelegateWrap._CreateEventDelegate));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("oneShot", new LuaCSFunction(EventDelegateWrap.get_oneShot), new LuaCSFunction(EventDelegateWrap.set_oneShot));
		L.RegVar("target", new LuaCSFunction(EventDelegateWrap.get_target), new LuaCSFunction(EventDelegateWrap.set_target));
		L.RegVar("methodName", new LuaCSFunction(EventDelegateWrap.get_methodName), new LuaCSFunction(EventDelegateWrap.set_methodName));
		L.RegVar("parameters", new LuaCSFunction(EventDelegateWrap.get_parameters), null);
		L.RegVar("isValid", new LuaCSFunction(EventDelegateWrap.get_isValid), null);
		L.RegVar("isEnabled", new LuaCSFunction(EventDelegateWrap.get_isEnabled), null);
		L.RegFunction("Callback", new LuaCSFunction(EventDelegateWrap.EventDelegate_Callback));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateEventDelegate(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 0)
			{
				EventDelegate o = new EventDelegate();
				ToLua.PushObject(L, o);
				result = 1;
			}
			else if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(EventDelegate.Callback)))
			{
				LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
				EventDelegate.Callback call;
				if (luaTypes != LuaTypes.LUA_TFUNCTION)
				{
					call = (EventDelegate.Callback)ToLua.CheckObject(L, 1, typeof(EventDelegate.Callback));
				}
				else
				{
					LuaFunction func = ToLua.ToLuaFunction(L, 1);
					call = (DelegateFactory.CreateDelegate(typeof(EventDelegate.Callback), func) as EventDelegate.Callback);
				}
				EventDelegate o2 = new EventDelegate(call);
				ToLua.PushObject(L, o2);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(MonoBehaviour), typeof(string)))
			{
				MonoBehaviour target = (MonoBehaviour)ToLua.CheckUnityObject(L, 1, typeof(MonoBehaviour));
				string methodName = ToLua.CheckString(L, 2);
				EventDelegate o3 = new EventDelegate(target, methodName);
				ToLua.PushObject(L, o3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: EventDelegate.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Equals(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			EventDelegate eventDelegate = (EventDelegate)ToLua.CheckObject(L, 1, typeof(EventDelegate));
			object obj = ToLua.ToVarObject(L, 2);
			bool value = (eventDelegate == null) ? (obj == null) : eventDelegate.Equals(obj);
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
	private static int GetHashCode(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			EventDelegate eventDelegate = (EventDelegate)ToLua.CheckObject(L, 1, typeof(EventDelegate));
			int hashCode = eventDelegate.GetHashCode();
			LuaDLL.lua_pushinteger(L, hashCode);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Set(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<EventDelegate>), typeof(EventDelegate)))
			{
				List<EventDelegate> list = (List<EventDelegate>)ToLua.ToObject(L, 1);
				EventDelegate del = (EventDelegate)ToLua.ToObject(L, 2);
				EventDelegate.Set(list, del);
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<EventDelegate>), typeof(EventDelegate.Callback)))
			{
				List<EventDelegate> list2 = (List<EventDelegate>)ToLua.ToObject(L, 1);
				LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
				EventDelegate.Callback callback;
				if (luaTypes != LuaTypes.LUA_TFUNCTION)
				{
					callback = (EventDelegate.Callback)ToLua.ToObject(L, 2);
				}
				else
				{
					LuaFunction func = ToLua.ToLuaFunction(L, 2);
					callback = (DelegateFactory.CreateDelegate(typeof(EventDelegate.Callback), func) as EventDelegate.Callback);
				}
				EventDelegate o = EventDelegate.Set(list2, callback);
				ToLua.PushObject(L, o);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(EventDelegate), typeof(MonoBehaviour), typeof(string)))
			{
				EventDelegate eventDelegate = (EventDelegate)ToLua.ToObject(L, 1);
				MonoBehaviour target = (MonoBehaviour)ToLua.ToObject(L, 2);
				string methodName = ToLua.ToString(L, 3);
				eventDelegate.Set(target, methodName);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: EventDelegate.Set");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Execute(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(List<EventDelegate>)))
			{
				List<EventDelegate> list = (List<EventDelegate>)ToLua.ToObject(L, 1);
				EventDelegate.Execute(list);
				result = 0;
			}
			else if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(EventDelegate)))
			{
				EventDelegate eventDelegate = (EventDelegate)ToLua.ToObject(L, 1);
				bool value = eventDelegate.Execute();
				LuaDLL.lua_pushboolean(L, value);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: EventDelegate.Execute");
			}
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
			EventDelegate eventDelegate = (EventDelegate)ToLua.CheckObject(L, 1, typeof(EventDelegate));
			eventDelegate.Clear();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ToString(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			EventDelegate eventDelegate = (EventDelegate)ToLua.CheckObject(L, 1, typeof(EventDelegate));
			string str = eventDelegate.ToString();
			LuaDLL.lua_pushstring(L, str);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsValid(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			List<EventDelegate> list = (List<EventDelegate>)ToLua.CheckObject(L, 1, typeof(List<EventDelegate>));
			bool value = EventDelegate.IsValid(list);
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
	private static int Add(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<EventDelegate>), typeof(EventDelegate)))
			{
				List<EventDelegate> list = (List<EventDelegate>)ToLua.ToObject(L, 1);
				EventDelegate ev = (EventDelegate)ToLua.ToObject(L, 2);
				EventDelegate.Add(list, ev);
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<EventDelegate>), typeof(EventDelegate.Callback)))
			{
				List<EventDelegate> list2 = (List<EventDelegate>)ToLua.ToObject(L, 1);
				LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
				EventDelegate.Callback callback;
				if (luaTypes != LuaTypes.LUA_TFUNCTION)
				{
					callback = (EventDelegate.Callback)ToLua.ToObject(L, 2);
				}
				else
				{
					LuaFunction func = ToLua.ToLuaFunction(L, 2);
					callback = (DelegateFactory.CreateDelegate(typeof(EventDelegate.Callback), func) as EventDelegate.Callback);
				}
				EventDelegate o = EventDelegate.Add(list2, callback);
				ToLua.PushObject(L, o);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(List<EventDelegate>), typeof(EventDelegate), typeof(bool)))
			{
				List<EventDelegate> list3 = (List<EventDelegate>)ToLua.ToObject(L, 1);
				EventDelegate ev2 = (EventDelegate)ToLua.ToObject(L, 2);
				bool oneShot = LuaDLL.lua_toboolean(L, 3);
				EventDelegate.Add(list3, ev2, oneShot);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(List<EventDelegate>), typeof(EventDelegate.Callback), typeof(bool)))
			{
				List<EventDelegate> list4 = (List<EventDelegate>)ToLua.ToObject(L, 1);
				LuaTypes luaTypes2 = LuaDLL.lua_type(L, 2);
				EventDelegate.Callback callback2;
				if (luaTypes2 != LuaTypes.LUA_TFUNCTION)
				{
					callback2 = (EventDelegate.Callback)ToLua.ToObject(L, 2);
				}
				else
				{
					LuaFunction func2 = ToLua.ToLuaFunction(L, 2);
					callback2 = (DelegateFactory.CreateDelegate(typeof(EventDelegate.Callback), func2) as EventDelegate.Callback);
				}
				bool oneShot2 = LuaDLL.lua_toboolean(L, 3);
				EventDelegate o2 = EventDelegate.Add(list4, callback2, oneShot2);
				ToLua.PushObject(L, o2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: EventDelegate.Add");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Remove(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<EventDelegate>), typeof(EventDelegate)))
			{
				List<EventDelegate> list = (List<EventDelegate>)ToLua.ToObject(L, 1);
				EventDelegate ev = (EventDelegate)ToLua.ToObject(L, 2);
				bool value = EventDelegate.Remove(list, ev);
				LuaDLL.lua_pushboolean(L, value);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<EventDelegate>), typeof(EventDelegate.Callback)))
			{
				List<EventDelegate> list2 = (List<EventDelegate>)ToLua.ToObject(L, 1);
				LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
				EventDelegate.Callback callback;
				if (luaTypes != LuaTypes.LUA_TFUNCTION)
				{
					callback = (EventDelegate.Callback)ToLua.ToObject(L, 2);
				}
				else
				{
					LuaFunction func = ToLua.ToLuaFunction(L, 2);
					callback = (DelegateFactory.CreateDelegate(typeof(EventDelegate.Callback), func) as EventDelegate.Callback);
				}
				bool value2 = EventDelegate.Remove(list2, callback);
				LuaDLL.lua_pushboolean(L, value2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: EventDelegate.Remove");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_oneShot(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			EventDelegate eventDelegate = (EventDelegate)obj;
			bool oneShot = eventDelegate.oneShot;
			LuaDLL.lua_pushboolean(L, oneShot);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index oneShot on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_target(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			EventDelegate eventDelegate = (EventDelegate)obj;
			MonoBehaviour target = eventDelegate.target;
			ToLua.Push(L, target);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index target on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_methodName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			EventDelegate eventDelegate = (EventDelegate)obj;
			string methodName = eventDelegate.methodName;
			LuaDLL.lua_pushstring(L, methodName);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index methodName on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_parameters(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			EventDelegate eventDelegate = (EventDelegate)obj;
			EventDelegate.Parameter[] parameters = eventDelegate.parameters;
			ToLua.Push(L, parameters);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index parameters on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isValid(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			EventDelegate eventDelegate = (EventDelegate)obj;
			bool isValid = eventDelegate.isValid;
			LuaDLL.lua_pushboolean(L, isValid);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isValid on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isEnabled(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			EventDelegate eventDelegate = (EventDelegate)obj;
			bool isEnabled = eventDelegate.isEnabled;
			LuaDLL.lua_pushboolean(L, isEnabled);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isEnabled on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_oneShot(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			EventDelegate eventDelegate = (EventDelegate)obj;
			bool oneShot = LuaDLL.luaL_checkboolean(L, 2);
			eventDelegate.oneShot = oneShot;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index oneShot on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_target(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			EventDelegate eventDelegate = (EventDelegate)obj;
			MonoBehaviour target = (MonoBehaviour)ToLua.CheckUnityObject(L, 2, typeof(MonoBehaviour));
			eventDelegate.target = target;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index target on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_methodName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			EventDelegate eventDelegate = (EventDelegate)obj;
			string methodName = ToLua.CheckString(L, 2);
			eventDelegate.methodName = methodName;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index methodName on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int EventDelegate_Callback(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(EventDelegate.Callback), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(EventDelegate.Callback), func, self);
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
