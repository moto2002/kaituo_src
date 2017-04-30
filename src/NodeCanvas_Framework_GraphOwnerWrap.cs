using LuaInterface;
using NodeCanvas.Framework;
using ParadoxNotion;
using System;
using UnityEngine;

public class NodeCanvas_Framework_GraphOwnerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(GraphOwner), typeof(MonoBehaviour), null);
		L.RegFunction("StartBehaviour", new LuaCSFunction(NodeCanvas_Framework_GraphOwnerWrap.StartBehaviour));
		L.RegFunction("PauseBehaviour", new LuaCSFunction(NodeCanvas_Framework_GraphOwnerWrap.PauseBehaviour));
		L.RegFunction("StopBehaviour", new LuaCSFunction(NodeCanvas_Framework_GraphOwnerWrap.StopBehaviour));
		L.RegFunction("SendEvent", new LuaCSFunction(NodeCanvas_Framework_GraphOwnerWrap.SendEvent));
		L.RegFunction("SendGlobalEvent", new LuaCSFunction(NodeCanvas_Framework_GraphOwnerWrap.SendGlobalEvent));
		L.RegFunction("SendTaskMessage", new LuaCSFunction(NodeCanvas_Framework_GraphOwnerWrap.SendTaskMessage));
		L.RegFunction("__eq", new LuaCSFunction(NodeCanvas_Framework_GraphOwnerWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("enableAction", new LuaCSFunction(NodeCanvas_Framework_GraphOwnerWrap.get_enableAction), new LuaCSFunction(NodeCanvas_Framework_GraphOwnerWrap.set_enableAction));
		L.RegVar("disableAction", new LuaCSFunction(NodeCanvas_Framework_GraphOwnerWrap.get_disableAction), new LuaCSFunction(NodeCanvas_Framework_GraphOwnerWrap.set_disableAction));
		L.RegVar("graph", new LuaCSFunction(NodeCanvas_Framework_GraphOwnerWrap.get_graph), new LuaCSFunction(NodeCanvas_Framework_GraphOwnerWrap.set_graph));
		L.RegVar("blackboard", new LuaCSFunction(NodeCanvas_Framework_GraphOwnerWrap.get_blackboard), new LuaCSFunction(NodeCanvas_Framework_GraphOwnerWrap.set_blackboard));
		L.RegVar("graphType", new LuaCSFunction(NodeCanvas_Framework_GraphOwnerWrap.get_graphType), null);
		L.RegVar("graphIsLocal", new LuaCSFunction(NodeCanvas_Framework_GraphOwnerWrap.get_graphIsLocal), null);
		L.RegVar("isRunning", new LuaCSFunction(NodeCanvas_Framework_GraphOwnerWrap.get_isRunning), null);
		L.RegVar("isPaused", new LuaCSFunction(NodeCanvas_Framework_GraphOwnerWrap.get_isPaused), null);
		L.RegVar("elapsedTime", new LuaCSFunction(NodeCanvas_Framework_GraphOwnerWrap.get_elapsedTime), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int StartBehaviour(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(GraphOwner)))
			{
				GraphOwner graphOwner = (GraphOwner)ToLua.ToObject(L, 1);
				graphOwner.StartBehaviour();
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(GraphOwner), typeof(Action)))
			{
				GraphOwner graphOwner2 = (GraphOwner)ToLua.ToObject(L, 1);
				LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
				Action callback;
				if (luaTypes != LuaTypes.LUA_TFUNCTION)
				{
					callback = (Action)ToLua.ToObject(L, 2);
				}
				else
				{
					LuaFunction func = ToLua.ToLuaFunction(L, 2);
					callback = (DelegateFactory.CreateDelegate(typeof(Action), func) as Action);
				}
				graphOwner2.StartBehaviour(callback);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: NodeCanvas.Framework.GraphOwner.StartBehaviour");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PauseBehaviour(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GraphOwner graphOwner = (GraphOwner)ToLua.CheckObject(L, 1, typeof(GraphOwner));
			graphOwner.PauseBehaviour();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int StopBehaviour(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GraphOwner graphOwner = (GraphOwner)ToLua.CheckObject(L, 1, typeof(GraphOwner));
			graphOwner.StopBehaviour();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SendEvent(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(GraphOwner), typeof(EventData)))
			{
				GraphOwner graphOwner = (GraphOwner)ToLua.ToObject(L, 1);
				EventData eventData = (EventData)ToLua.ToObject(L, 2);
				graphOwner.SendEvent(eventData);
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(GraphOwner), typeof(string)))
			{
				GraphOwner graphOwner2 = (GraphOwner)ToLua.ToObject(L, 1);
				string eventName = ToLua.ToString(L, 2);
				graphOwner2.SendEvent(eventName);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: NodeCanvas.Framework.GraphOwner.SendEvent");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SendGlobalEvent(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			EventData eventData = (EventData)ToLua.CheckObject(L, 1, typeof(EventData));
			GraphOwner.SendGlobalEvent(eventData);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SendTaskMessage(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(GraphOwner), typeof(string)))
			{
				GraphOwner graphOwner = (GraphOwner)ToLua.ToObject(L, 1);
				string name = ToLua.ToString(L, 2);
				graphOwner.SendTaskMessage(name);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(GraphOwner), typeof(string), typeof(object)))
			{
				GraphOwner graphOwner2 = (GraphOwner)ToLua.ToObject(L, 1);
				string name2 = ToLua.ToString(L, 2);
				object arg = ToLua.ToVarObject(L, 3);
				graphOwner2.SendTaskMessage(name2, arg);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: NodeCanvas.Framework.GraphOwner.SendTaskMessage");
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
	private static int get_enableAction(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GraphOwner graphOwner = (GraphOwner)obj;
			GraphOwner.EnableAction enableAction = graphOwner.enableAction;
			ToLua.Push(L, enableAction);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index enableAction on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_disableAction(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GraphOwner graphOwner = (GraphOwner)obj;
			GraphOwner.DisableAction disableAction = graphOwner.disableAction;
			ToLua.Push(L, disableAction);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index disableAction on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_graph(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GraphOwner graphOwner = (GraphOwner)obj;
			Graph graph = graphOwner.graph;
			ToLua.Push(L, graph);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index graph on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_blackboard(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GraphOwner graphOwner = (GraphOwner)obj;
			IBlackboard blackboard = graphOwner.blackboard;
			ToLua.PushObject(L, blackboard);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index blackboard on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_graphType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GraphOwner graphOwner = (GraphOwner)obj;
			Type graphType = graphOwner.graphType;
			ToLua.Push(L, graphType);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index graphType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_graphIsLocal(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GraphOwner graphOwner = (GraphOwner)obj;
			bool graphIsLocal = graphOwner.graphIsLocal;
			LuaDLL.lua_pushboolean(L, graphIsLocal);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index graphIsLocal on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isRunning(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GraphOwner graphOwner = (GraphOwner)obj;
			bool isRunning = graphOwner.isRunning;
			LuaDLL.lua_pushboolean(L, isRunning);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isRunning on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isPaused(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GraphOwner graphOwner = (GraphOwner)obj;
			bool isPaused = graphOwner.isPaused;
			LuaDLL.lua_pushboolean(L, isPaused);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isPaused on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_elapsedTime(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GraphOwner graphOwner = (GraphOwner)obj;
			float elapsedTime = graphOwner.elapsedTime;
			LuaDLL.lua_pushnumber(L, (double)elapsedTime);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index elapsedTime on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_enableAction(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GraphOwner graphOwner = (GraphOwner)obj;
			GraphOwner.EnableAction enableAction = (GraphOwner.EnableAction)LuaDLL.luaL_checknumber(L, 2);
			graphOwner.enableAction = enableAction;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index enableAction on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_disableAction(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GraphOwner graphOwner = (GraphOwner)obj;
			GraphOwner.DisableAction disableAction = (GraphOwner.DisableAction)LuaDLL.luaL_checknumber(L, 2);
			graphOwner.disableAction = disableAction;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index disableAction on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_graph(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GraphOwner graphOwner = (GraphOwner)obj;
			Graph graph = (Graph)ToLua.CheckUnityObject(L, 2, typeof(Graph));
			graphOwner.graph = graph;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index graph on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_blackboard(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GraphOwner graphOwner = (GraphOwner)obj;
			IBlackboard blackboard = (IBlackboard)ToLua.CheckObject(L, 2, typeof(IBlackboard));
			graphOwner.blackboard = blackboard;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index blackboard on a nil value");
		}
		return result;
	}
}
