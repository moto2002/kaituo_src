using LuaInterface;
using NodeCanvas.BehaviourTrees;
using NodeCanvas.Framework;
using System;
using UnityEngine;

public class NodeCanvas_Framework_GraphOwner_NodeCanvas_BehaviourTrees_BehaviourTreeWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(GraphOwner<BehaviourTree>), typeof(GraphOwner), "GraphOwner_NodeCanvas_BehaviourTrees_BehaviourTree");
		L.RegFunction("StartBehaviour", new LuaCSFunction(NodeCanvas_Framework_GraphOwner_NodeCanvas_BehaviourTrees_BehaviourTreeWrap.StartBehaviour));
		L.RegFunction("PauseBehaviour", new LuaCSFunction(NodeCanvas_Framework_GraphOwner_NodeCanvas_BehaviourTrees_BehaviourTreeWrap.PauseBehaviour));
		L.RegFunction("StopBehaviour", new LuaCSFunction(NodeCanvas_Framework_GraphOwner_NodeCanvas_BehaviourTrees_BehaviourTreeWrap.StopBehaviour));
		L.RegFunction("SwitchBehaviour", new LuaCSFunction(NodeCanvas_Framework_GraphOwner_NodeCanvas_BehaviourTrees_BehaviourTreeWrap.SwitchBehaviour));
		L.RegFunction("__eq", new LuaCSFunction(NodeCanvas_Framework_GraphOwner_NodeCanvas_BehaviourTrees_BehaviourTreeWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("graph", new LuaCSFunction(NodeCanvas_Framework_GraphOwner_NodeCanvas_BehaviourTrees_BehaviourTreeWrap.get_graph), new LuaCSFunction(NodeCanvas_Framework_GraphOwner_NodeCanvas_BehaviourTrees_BehaviourTreeWrap.set_graph));
		L.RegVar("blackboard", new LuaCSFunction(NodeCanvas_Framework_GraphOwner_NodeCanvas_BehaviourTrees_BehaviourTreeWrap.get_blackboard), new LuaCSFunction(NodeCanvas_Framework_GraphOwner_NodeCanvas_BehaviourTrees_BehaviourTreeWrap.set_blackboard));
		L.RegVar("graphType", new LuaCSFunction(NodeCanvas_Framework_GraphOwner_NodeCanvas_BehaviourTrees_BehaviourTreeWrap.get_graphType), null);
		L.RegVar("behaviour", new LuaCSFunction(NodeCanvas_Framework_GraphOwner_NodeCanvas_BehaviourTrees_BehaviourTreeWrap.get_behaviour), new LuaCSFunction(NodeCanvas_Framework_GraphOwner_NodeCanvas_BehaviourTrees_BehaviourTreeWrap.set_behaviour));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int StartBehaviour(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(GraphOwner<BehaviourTree>)))
			{
				GraphOwner<BehaviourTree> graphOwner = (GraphOwner<BehaviourTree>)ToLua.ToObject(L, 1);
				graphOwner.StartBehaviour();
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(GraphOwner<BehaviourTree>), typeof(BehaviourTree)))
			{
				GraphOwner<BehaviourTree> graphOwner2 = (GraphOwner<BehaviourTree>)ToLua.ToObject(L, 1);
				BehaviourTree newGraph = (BehaviourTree)ToLua.ToObject(L, 2);
				graphOwner2.StartBehaviour(newGraph);
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(GraphOwner<BehaviourTree>), typeof(Action)))
			{
				GraphOwner<BehaviourTree> graphOwner3 = (GraphOwner<BehaviourTree>)ToLua.ToObject(L, 1);
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
				graphOwner3.StartBehaviour(callback);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(GraphOwner<BehaviourTree>), typeof(BehaviourTree), typeof(Action)))
			{
				GraphOwner<BehaviourTree> graphOwner4 = (GraphOwner<BehaviourTree>)ToLua.ToObject(L, 1);
				BehaviourTree newGraph2 = (BehaviourTree)ToLua.ToObject(L, 2);
				LuaTypes luaTypes2 = LuaDLL.lua_type(L, 3);
				Action callback2;
				if (luaTypes2 != LuaTypes.LUA_TFUNCTION)
				{
					callback2 = (Action)ToLua.ToObject(L, 3);
				}
				else
				{
					LuaFunction func2 = ToLua.ToLuaFunction(L, 3);
					callback2 = (DelegateFactory.CreateDelegate(typeof(Action), func2) as Action);
				}
				graphOwner4.StartBehaviour(newGraph2, callback2);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: NodeCanvas.Framework.GraphOwner<NodeCanvas.BehaviourTrees.BehaviourTree>.StartBehaviour");
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
			GraphOwner<BehaviourTree> graphOwner = (GraphOwner<BehaviourTree>)ToLua.CheckObject(L, 1, typeof(GraphOwner<BehaviourTree>));
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
			GraphOwner<BehaviourTree> graphOwner = (GraphOwner<BehaviourTree>)ToLua.CheckObject(L, 1, typeof(GraphOwner<BehaviourTree>));
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
	private static int SwitchBehaviour(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(GraphOwner<BehaviourTree>), typeof(BehaviourTree)))
			{
				GraphOwner<BehaviourTree> graphOwner = (GraphOwner<BehaviourTree>)ToLua.ToObject(L, 1);
				BehaviourTree newGraph = (BehaviourTree)ToLua.ToObject(L, 2);
				graphOwner.SwitchBehaviour(newGraph);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(GraphOwner<BehaviourTree>), typeof(BehaviourTree), typeof(Action)))
			{
				GraphOwner<BehaviourTree> graphOwner2 = (GraphOwner<BehaviourTree>)ToLua.ToObject(L, 1);
				BehaviourTree newGraph2 = (BehaviourTree)ToLua.ToObject(L, 2);
				LuaTypes luaTypes = LuaDLL.lua_type(L, 3);
				Action callback;
				if (luaTypes != LuaTypes.LUA_TFUNCTION)
				{
					callback = (Action)ToLua.ToObject(L, 3);
				}
				else
				{
					LuaFunction func = ToLua.ToLuaFunction(L, 3);
					callback = (DelegateFactory.CreateDelegate(typeof(Action), func) as Action);
				}
				graphOwner2.SwitchBehaviour(newGraph2, callback);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: NodeCanvas.Framework.GraphOwner<NodeCanvas.BehaviourTrees.BehaviourTree>.SwitchBehaviour");
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
	private static int get_graph(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GraphOwner<BehaviourTree> graphOwner = (GraphOwner<BehaviourTree>)obj;
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
			GraphOwner<BehaviourTree> graphOwner = (GraphOwner<BehaviourTree>)obj;
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
			GraphOwner<BehaviourTree> graphOwner = (GraphOwner<BehaviourTree>)obj;
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
	private static int get_behaviour(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GraphOwner<BehaviourTree> graphOwner = (GraphOwner<BehaviourTree>)obj;
			BehaviourTree behaviour = graphOwner.behaviour;
			ToLua.Push(L, behaviour);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index behaviour on a nil value");
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
			GraphOwner<BehaviourTree> graphOwner = (GraphOwner<BehaviourTree>)obj;
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
			GraphOwner<BehaviourTree> graphOwner = (GraphOwner<BehaviourTree>)obj;
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

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_behaviour(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GraphOwner<BehaviourTree> graphOwner = (GraphOwner<BehaviourTree>)obj;
			BehaviourTree behaviour = (BehaviourTree)ToLua.CheckUnityObject(L, 2, typeof(BehaviourTree));
			graphOwner.behaviour = behaviour;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index behaviour on a nil value");
		}
		return result;
	}
}
