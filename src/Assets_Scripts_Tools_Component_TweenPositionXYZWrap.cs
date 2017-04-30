using Assets.Scripts.Tools.Component;
using Assets.Tools.Script.Animation.Curve;
using LuaInterface;
using System;
using UnityEngine;

public class Assets_Scripts_Tools_Component_TweenPositionXYZWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(TweenPositionXYZ), typeof(CurveAnimation), null);
		L.RegFunction("PlayWithEnd", new LuaCSFunction(Assets_Scripts_Tools_Component_TweenPositionXYZWrap.PlayWithEnd));
		L.RegFunction("__eq", new LuaCSFunction(Assets_Scripts_Tools_Component_TweenPositionXYZWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("CurveY", new LuaCSFunction(Assets_Scripts_Tools_Component_TweenPositionXYZWrap.get_CurveY), new LuaCSFunction(Assets_Scripts_Tools_Component_TweenPositionXYZWrap.set_CurveY));
		L.RegVar("CurveZ", new LuaCSFunction(Assets_Scripts_Tools_Component_TweenPositionXYZWrap.get_CurveZ), new LuaCSFunction(Assets_Scripts_Tools_Component_TweenPositionXYZWrap.set_CurveZ));
		L.RegVar("Target", new LuaCSFunction(Assets_Scripts_Tools_Component_TweenPositionXYZWrap.get_Target), new LuaCSFunction(Assets_Scripts_Tools_Component_TweenPositionXYZWrap.set_Target));
		L.RegVar("From", new LuaCSFunction(Assets_Scripts_Tools_Component_TweenPositionXYZWrap.get_From), new LuaCSFunction(Assets_Scripts_Tools_Component_TweenPositionXYZWrap.set_From));
		L.RegVar("To", new LuaCSFunction(Assets_Scripts_Tools_Component_TweenPositionXYZWrap.get_To), new LuaCSFunction(Assets_Scripts_Tools_Component_TweenPositionXYZWrap.set_To));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PlayWithEnd(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			TweenPositionXYZ tweenPositionXYZ = (TweenPositionXYZ)ToLua.CheckObject(L, 1, typeof(TweenPositionXYZ));
			Vector3 from = ToLua.ToVector3(L, 2);
			Vector3 to = ToLua.ToVector3(L, 3);
			LuaTypes luaTypes = LuaDLL.lua_type(L, 4);
			Action onEnd;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onEnd = (Action)ToLua.CheckObject(L, 4, typeof(Action));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 4);
				onEnd = (DelegateFactory.CreateDelegate(typeof(Action), func) as Action);
			}
			tweenPositionXYZ.PlayWithEnd(from, to, onEnd);
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
	private static int get_CurveY(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TweenPositionXYZ tweenPositionXYZ = (TweenPositionXYZ)obj;
			AnimationCurve curveY = tweenPositionXYZ.CurveY;
			ToLua.PushObject(L, curveY);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index CurveY on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_CurveZ(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TweenPositionXYZ tweenPositionXYZ = (TweenPositionXYZ)obj;
			AnimationCurve curveZ = tweenPositionXYZ.CurveZ;
			ToLua.PushObject(L, curveZ);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index CurveZ on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Target(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TweenPositionXYZ tweenPositionXYZ = (TweenPositionXYZ)obj;
			Transform target = tweenPositionXYZ.Target;
			ToLua.Push(L, target);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Target on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_From(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TweenPositionXYZ tweenPositionXYZ = (TweenPositionXYZ)obj;
			Vector3 from = tweenPositionXYZ.From;
			ToLua.Push(L, from);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index From on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_To(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TweenPositionXYZ tweenPositionXYZ = (TweenPositionXYZ)obj;
			Vector3 to = tweenPositionXYZ.To;
			ToLua.Push(L, to);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index To on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_CurveY(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TweenPositionXYZ tweenPositionXYZ = (TweenPositionXYZ)obj;
			AnimationCurve curveY = (AnimationCurve)ToLua.CheckObject(L, 2, typeof(AnimationCurve));
			tweenPositionXYZ.CurveY = curveY;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index CurveY on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_CurveZ(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TweenPositionXYZ tweenPositionXYZ = (TweenPositionXYZ)obj;
			AnimationCurve curveZ = (AnimationCurve)ToLua.CheckObject(L, 2, typeof(AnimationCurve));
			tweenPositionXYZ.CurveZ = curveZ;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index CurveZ on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Target(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TweenPositionXYZ tweenPositionXYZ = (TweenPositionXYZ)obj;
			Transform target = (Transform)ToLua.CheckUnityObject(L, 2, typeof(Transform));
			tweenPositionXYZ.Target = target;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Target on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_From(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TweenPositionXYZ tweenPositionXYZ = (TweenPositionXYZ)obj;
			Vector3 from = ToLua.ToVector3(L, 2);
			tweenPositionXYZ.From = from;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index From on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_To(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TweenPositionXYZ tweenPositionXYZ = (TweenPositionXYZ)obj;
			Vector3 to = ToLua.ToVector3(L, 2);
			tweenPositionXYZ.To = to;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index To on a nil value");
		}
		return result;
	}
}
