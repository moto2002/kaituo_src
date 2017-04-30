using Assets.Scripts;
using Assets.Tools.Script.Event;
using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Assets_Scripts_RpgCharacterWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(RpgCharacter), typeof(MonoBehaviour), null);
		L.RegFunction("GetAminationNameList", new LuaCSFunction(Assets_Scripts_RpgCharacterWrap.GetAminationNameList));
		L.RegFunction("MoveTo", new LuaCSFunction(Assets_Scripts_RpgCharacterWrap.MoveTo));
		L.RegFunction("TurnToLook", new LuaCSFunction(Assets_Scripts_RpgCharacterWrap.TurnToLook));
		L.RegFunction("GetAnchorPoint", new LuaCSFunction(Assets_Scripts_RpgCharacterWrap.GetAnchorPoint));
		L.RegFunction("__eq", new LuaCSFunction(Assets_Scripts_RpgCharacterWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("CharacterName", new LuaCSFunction(Assets_Scripts_RpgCharacterWrap.get_CharacterName), new LuaCSFunction(Assets_Scripts_RpgCharacterWrap.set_CharacterName));
		L.RegVar("InstanceId", new LuaCSFunction(Assets_Scripts_RpgCharacterWrap.get_InstanceId), new LuaCSFunction(Assets_Scripts_RpgCharacterWrap.set_InstanceId));
		L.RegVar("Animator", new LuaCSFunction(Assets_Scripts_RpgCharacterWrap.get_Animator), new LuaCSFunction(Assets_Scripts_RpgCharacterWrap.set_Animator));
		L.RegVar("AnchorPoints", new LuaCSFunction(Assets_Scripts_RpgCharacterWrap.get_AnchorPoints), new LuaCSFunction(Assets_Scripts_RpgCharacterWrap.set_AnchorPoints));
		L.RegVar("OnAnimEndSignal", new LuaCSFunction(Assets_Scripts_RpgCharacterWrap.get_OnAnimEndSignal), null);
		L.RegVar("OnAttackSignal", new LuaCSFunction(Assets_Scripts_RpgCharacterWrap.get_OnAttackSignal), null);
		L.RegVar("OnMoveEndSignal", new LuaCSFunction(Assets_Scripts_RpgCharacterWrap.get_OnMoveEndSignal), null);
		L.RegVar("View", new LuaCSFunction(Assets_Scripts_RpgCharacterWrap.get_View), new LuaCSFunction(Assets_Scripts_RpgCharacterWrap.set_View));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetAminationNameList(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			RpgCharacter rpgCharacter = (RpgCharacter)ToLua.CheckObject(L, 1, typeof(RpgCharacter));
			List<string> aminationNameList = rpgCharacter.GetAminationNameList();
			ToLua.PushObject(L, aminationNameList);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int MoveTo(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			RpgCharacter rpgCharacter = (RpgCharacter)ToLua.CheckObject(L, 1, typeof(RpgCharacter));
			Vector3 position = ToLua.ToVector3(L, 2);
			float time = (float)LuaDLL.luaL_checknumber(L, 3);
			string animationName = ToLua.CheckString(L, 4);
			rpgCharacter.MoveTo(position, time, animationName);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int TurnToLook(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			RpgCharacter rpgCharacter = (RpgCharacter)ToLua.CheckObject(L, 1, typeof(RpgCharacter));
			Vector3 target = ToLua.ToVector3(L, 2);
			float time = (float)LuaDLL.luaL_checknumber(L, 3);
			rpgCharacter.TurnToLook(target, time);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetAnchorPoint(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			RpgCharacter rpgCharacter = (RpgCharacter)ToLua.CheckObject(L, 1, typeof(RpgCharacter));
			string pointName = ToLua.CheckString(L, 2);
			GameObject anchorPoint = rpgCharacter.GetAnchorPoint(pointName);
			ToLua.Push(L, anchorPoint);
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
	private static int get_CharacterName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RpgCharacter rpgCharacter = (RpgCharacter)obj;
			string characterName = rpgCharacter.CharacterName;
			LuaDLL.lua_pushstring(L, characterName);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index CharacterName on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_InstanceId(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RpgCharacter rpgCharacter = (RpgCharacter)obj;
			int instanceId = rpgCharacter.InstanceId;
			LuaDLL.lua_pushinteger(L, instanceId);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index InstanceId on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Animator(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RpgCharacter rpgCharacter = (RpgCharacter)obj;
			CharacterAnimator animator = rpgCharacter.Animator;
			ToLua.Push(L, animator);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Animator on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_AnchorPoints(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RpgCharacter rpgCharacter = (RpgCharacter)obj;
			GameObject[] anchorPoints = rpgCharacter.AnchorPoints;
			ToLua.Push(L, anchorPoints);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index AnchorPoints on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_OnAnimEndSignal(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RpgCharacter rpgCharacter = (RpgCharacter)obj;
			Signal<CharacterAnimator> onAnimEndSignal = rpgCharacter.OnAnimEndSignal;
			ToLua.PushObject(L, onAnimEndSignal);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index OnAnimEndSignal on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_OnAttackSignal(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RpgCharacter rpgCharacter = (RpgCharacter)obj;
			Signal<RpgCharacter> onAttackSignal = rpgCharacter.OnAttackSignal;
			ToLua.PushObject(L, onAttackSignal);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index OnAttackSignal on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_OnMoveEndSignal(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RpgCharacter rpgCharacter = (RpgCharacter)obj;
			Signal<RpgCharacter> onMoveEndSignal = rpgCharacter.OnMoveEndSignal;
			ToLua.PushObject(L, onMoveEndSignal);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index OnMoveEndSignal on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_View(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RpgCharacter rpgCharacter = (RpgCharacter)obj;
			Transform view = rpgCharacter.View;
			ToLua.Push(L, view);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index View on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_CharacterName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RpgCharacter rpgCharacter = (RpgCharacter)obj;
			string characterName = ToLua.CheckString(L, 2);
			rpgCharacter.CharacterName = characterName;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index CharacterName on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_InstanceId(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RpgCharacter rpgCharacter = (RpgCharacter)obj;
			int instanceId = (int)LuaDLL.luaL_checknumber(L, 2);
			rpgCharacter.InstanceId = instanceId;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index InstanceId on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Animator(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RpgCharacter rpgCharacter = (RpgCharacter)obj;
			CharacterAnimator animator = (CharacterAnimator)ToLua.CheckUnityObject(L, 2, typeof(CharacterAnimator));
			rpgCharacter.Animator = animator;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Animator on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_AnchorPoints(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RpgCharacter rpgCharacter = (RpgCharacter)obj;
			GameObject[] anchorPoints = ToLua.CheckObjectArray<GameObject>(L, 2);
			rpgCharacter.AnchorPoints = anchorPoints;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index AnchorPoints on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_View(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RpgCharacter rpgCharacter = (RpgCharacter)obj;
			Transform view = (Transform)ToLua.CheckUnityObject(L, 2, typeof(Transform));
			rpgCharacter.View = view;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index View on a nil value");
		}
		return result;
	}
}
