using Assets.Scripts.Tools.Component;
using LuaInterface;
using System;
using UnityEngine;

public class Assets_Scripts_Tools_Component_CameraShakerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(CameraShaker), typeof(MonoBehaviour), null);
		L.RegFunction("FindShaker", new LuaCSFunction(Assets_Scripts_Tools_Component_CameraShakerWrap.FindShaker));
		L.RegFunction("CopyShaker", new LuaCSFunction(Assets_Scripts_Tools_Component_CameraShakerWrap.CopyShaker));
		L.RegFunction("Play", new LuaCSFunction(Assets_Scripts_Tools_Component_CameraShakerWrap.Play));
		L.RegFunction("__eq", new LuaCSFunction(Assets_Scripts_Tools_Component_CameraShakerWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("CurveX", new LuaCSFunction(Assets_Scripts_Tools_Component_CameraShakerWrap.get_CurveX), new LuaCSFunction(Assets_Scripts_Tools_Component_CameraShakerWrap.set_CurveX));
		L.RegVar("CurveY", new LuaCSFunction(Assets_Scripts_Tools_Component_CameraShakerWrap.get_CurveY), new LuaCSFunction(Assets_Scripts_Tools_Component_CameraShakerWrap.set_CurveY));
		L.RegVar("CameraTransform", new LuaCSFunction(Assets_Scripts_Tools_Component_CameraShakerWrap.get_CameraTransform), new LuaCSFunction(Assets_Scripts_Tools_Component_CameraShakerWrap.set_CameraTransform));
		L.RegVar("Swing", new LuaCSFunction(Assets_Scripts_Tools_Component_CameraShakerWrap.get_Swing), new LuaCSFunction(Assets_Scripts_Tools_Component_CameraShakerWrap.set_Swing));
		L.RegVar("ShakerName", new LuaCSFunction(Assets_Scripts_Tools_Component_CameraShakerWrap.get_ShakerName), new LuaCSFunction(Assets_Scripts_Tools_Component_CameraShakerWrap.set_ShakerName));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int FindShaker(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			GameObject obj = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			string shakerName = ToLua.CheckString(L, 2);
			CameraShaker obj2 = CameraShaker.FindShaker(obj, shakerName);
			ToLua.Push(L, obj2);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CopyShaker(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			GameObject from = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			GameObject to = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			CameraShaker.CopyShaker(from, to);
			result = 0;
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
			ToLua.CheckArgsCount(L, 3);
			CameraShaker cameraShaker = (CameraShaker)ToLua.CheckObject(L, 1, typeof(CameraShaker));
			float swing = (float)LuaDLL.luaL_checknumber(L, 2);
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
			cameraShaker.Play(swing, onEnd);
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
	private static int get_CurveX(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CameraShaker cameraShaker = (CameraShaker)obj;
			AnimationCurve curveX = cameraShaker.CurveX;
			ToLua.PushObject(L, curveX);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index CurveX on a nil value");
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
			CameraShaker cameraShaker = (CameraShaker)obj;
			AnimationCurve curveY = cameraShaker.CurveY;
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
	private static int get_CameraTransform(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CameraShaker cameraShaker = (CameraShaker)obj;
			Transform cameraTransform = cameraShaker.CameraTransform;
			ToLua.Push(L, cameraTransform);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index CameraTransform on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Swing(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CameraShaker cameraShaker = (CameraShaker)obj;
			float swing = cameraShaker.Swing;
			LuaDLL.lua_pushnumber(L, (double)swing);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Swing on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_ShakerName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CameraShaker cameraShaker = (CameraShaker)obj;
			string shakerName = cameraShaker.ShakerName;
			LuaDLL.lua_pushstring(L, shakerName);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ShakerName on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_CurveX(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CameraShaker cameraShaker = (CameraShaker)obj;
			AnimationCurve curveX = (AnimationCurve)ToLua.CheckObject(L, 2, typeof(AnimationCurve));
			cameraShaker.CurveX = curveX;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index CurveX on a nil value");
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
			CameraShaker cameraShaker = (CameraShaker)obj;
			AnimationCurve curveY = (AnimationCurve)ToLua.CheckObject(L, 2, typeof(AnimationCurve));
			cameraShaker.CurveY = curveY;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index CurveY on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_CameraTransform(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CameraShaker cameraShaker = (CameraShaker)obj;
			Transform cameraTransform = (Transform)ToLua.CheckUnityObject(L, 2, typeof(Transform));
			cameraShaker.CameraTransform = cameraTransform;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index CameraTransform on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Swing(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CameraShaker cameraShaker = (CameraShaker)obj;
			float swing = (float)LuaDLL.luaL_checknumber(L, 2);
			cameraShaker.Swing = swing;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Swing on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_ShakerName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CameraShaker cameraShaker = (CameraShaker)obj;
			string shakerName = ToLua.CheckString(L, 2);
			cameraShaker.ShakerName = shakerName;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ShakerName on a nil value");
		}
		return result;
	}
}
