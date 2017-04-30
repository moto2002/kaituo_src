using Assets.Scripts.Performance;
using LuaInterface;
using System;
using UnityEngine;

public class Assets_Scripts_Performance_NodeCanvas3DTestWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(NodeCanvas3DTest), typeof(MonoBehaviour), null);
		L.RegFunction("GetData", new LuaCSFunction(Assets_Scripts_Performance_NodeCanvas3DTestWrap.GetData));
		L.RegFunction("__eq", new LuaCSFunction(Assets_Scripts_Performance_NodeCanvas3DTestWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("Data", new LuaCSFunction(Assets_Scripts_Performance_NodeCanvas3DTestWrap.get_Data), new LuaCSFunction(Assets_Scripts_Performance_NodeCanvas3DTestWrap.set_Data));
		L.RegVar("SceneName", new LuaCSFunction(Assets_Scripts_Performance_NodeCanvas3DTestWrap.get_SceneName), new LuaCSFunction(Assets_Scripts_Performance_NodeCanvas3DTestWrap.set_SceneName));
		L.RegVar("BattleUnitInfoBarLeftObject", new LuaCSFunction(Assets_Scripts_Performance_NodeCanvas3DTestWrap.get_BattleUnitInfoBarLeftObject), new LuaCSFunction(Assets_Scripts_Performance_NodeCanvas3DTestWrap.set_BattleUnitInfoBarLeftObject));
		L.RegVar("BattleUnitInfoBarRightObject", new LuaCSFunction(Assets_Scripts_Performance_NodeCanvas3DTestWrap.get_BattleUnitInfoBarRightObject), new LuaCSFunction(Assets_Scripts_Performance_NodeCanvas3DTestWrap.set_BattleUnitInfoBarRightObject));
		L.RegVar("BattleUnitInfoPopLabelLeftObject", new LuaCSFunction(Assets_Scripts_Performance_NodeCanvas3DTestWrap.get_BattleUnitInfoPopLabelLeftObject), new LuaCSFunction(Assets_Scripts_Performance_NodeCanvas3DTestWrap.set_BattleUnitInfoPopLabelLeftObject));
		L.RegVar("BattleUnitInfoPopLabelRightObject", new LuaCSFunction(Assets_Scripts_Performance_NodeCanvas3DTestWrap.get_BattleUnitInfoPopLabelRightObject), new LuaCSFunction(Assets_Scripts_Performance_NodeCanvas3DTestWrap.set_BattleUnitInfoPopLabelRightObject));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetData(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			NodeCanvas3DTest nodeCanvas3DTest = (NodeCanvas3DTest)ToLua.CheckObject(L, 1, typeof(NodeCanvas3DTest));
			string data = nodeCanvas3DTest.GetData();
			LuaDLL.lua_pushstring(L, data);
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
	private static int get_Data(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			NodeCanvas3DTest nodeCanvas3DTest = (NodeCanvas3DTest)obj;
			NodeCanvas3DTestSkillNodeData data = nodeCanvas3DTest.Data;
			ToLua.PushObject(L, data);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Data on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_SceneName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			NodeCanvas3DTest nodeCanvas3DTest = (NodeCanvas3DTest)obj;
			string sceneName = nodeCanvas3DTest.SceneName;
			LuaDLL.lua_pushstring(L, sceneName);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index SceneName on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_BattleUnitInfoBarLeftObject(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			NodeCanvas3DTest nodeCanvas3DTest = (NodeCanvas3DTest)obj;
			GameObject battleUnitInfoBarLeftObject = nodeCanvas3DTest.BattleUnitInfoBarLeftObject;
			ToLua.Push(L, battleUnitInfoBarLeftObject);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index BattleUnitInfoBarLeftObject on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_BattleUnitInfoBarRightObject(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			NodeCanvas3DTest nodeCanvas3DTest = (NodeCanvas3DTest)obj;
			GameObject battleUnitInfoBarRightObject = nodeCanvas3DTest.BattleUnitInfoBarRightObject;
			ToLua.Push(L, battleUnitInfoBarRightObject);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index BattleUnitInfoBarRightObject on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_BattleUnitInfoPopLabelLeftObject(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			NodeCanvas3DTest nodeCanvas3DTest = (NodeCanvas3DTest)obj;
			GameObject battleUnitInfoPopLabelLeftObject = nodeCanvas3DTest.BattleUnitInfoPopLabelLeftObject;
			ToLua.Push(L, battleUnitInfoPopLabelLeftObject);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index BattleUnitInfoPopLabelLeftObject on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_BattleUnitInfoPopLabelRightObject(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			NodeCanvas3DTest nodeCanvas3DTest = (NodeCanvas3DTest)obj;
			GameObject battleUnitInfoPopLabelRightObject = nodeCanvas3DTest.BattleUnitInfoPopLabelRightObject;
			ToLua.Push(L, battleUnitInfoPopLabelRightObject);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index BattleUnitInfoPopLabelRightObject on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Data(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			NodeCanvas3DTest nodeCanvas3DTest = (NodeCanvas3DTest)obj;
			NodeCanvas3DTestSkillNodeData data = (NodeCanvas3DTestSkillNodeData)ToLua.CheckObject(L, 2, typeof(NodeCanvas3DTestSkillNodeData));
			nodeCanvas3DTest.Data = data;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Data on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_SceneName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			NodeCanvas3DTest nodeCanvas3DTest = (NodeCanvas3DTest)obj;
			string sceneName = ToLua.CheckString(L, 2);
			nodeCanvas3DTest.SceneName = sceneName;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index SceneName on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_BattleUnitInfoBarLeftObject(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			NodeCanvas3DTest nodeCanvas3DTest = (NodeCanvas3DTest)obj;
			GameObject battleUnitInfoBarLeftObject = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			nodeCanvas3DTest.BattleUnitInfoBarLeftObject = battleUnitInfoBarLeftObject;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index BattleUnitInfoBarLeftObject on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_BattleUnitInfoBarRightObject(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			NodeCanvas3DTest nodeCanvas3DTest = (NodeCanvas3DTest)obj;
			GameObject battleUnitInfoBarRightObject = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			nodeCanvas3DTest.BattleUnitInfoBarRightObject = battleUnitInfoBarRightObject;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index BattleUnitInfoBarRightObject on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_BattleUnitInfoPopLabelLeftObject(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			NodeCanvas3DTest nodeCanvas3DTest = (NodeCanvas3DTest)obj;
			GameObject battleUnitInfoPopLabelLeftObject = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			nodeCanvas3DTest.BattleUnitInfoPopLabelLeftObject = battleUnitInfoPopLabelLeftObject;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index BattleUnitInfoPopLabelLeftObject on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_BattleUnitInfoPopLabelRightObject(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			NodeCanvas3DTest nodeCanvas3DTest = (NodeCanvas3DTest)obj;
			GameObject battleUnitInfoPopLabelRightObject = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			nodeCanvas3DTest.BattleUnitInfoPopLabelRightObject = battleUnitInfoPopLabelRightObject;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index BattleUnitInfoPopLabelRightObject on a nil value");
		}
		return result;
	}
}
