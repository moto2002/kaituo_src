using Assets.Migration.Scripts.Action.Effect;
using Assets.Scripts.Tools.Component;
using LuaInterface;
using System;
using UnityEngine;
using XQ.Game.Util.Unity;

public class Assets_Scripts_Tools_Component_Main3DCameraWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Main3DCamera), typeof(MonoBehaviour), null);
		L.RegFunction("Start", new LuaCSFunction(Assets_Scripts_Tools_Component_Main3DCameraWrap.Start));
		L.RegFunction("GetCamera", new LuaCSFunction(Assets_Scripts_Tools_Component_Main3DCameraWrap.GetCamera));
		L.RegFunction("PlayEntryAnim", new LuaCSFunction(Assets_Scripts_Tools_Component_Main3DCameraWrap.PlayEntryAnim));
		L.RegFunction("PlayDefaultAnim", new LuaCSFunction(Assets_Scripts_Tools_Component_Main3DCameraWrap.PlayDefaultAnim));
		L.RegFunction("StopAnim", new LuaCSFunction(Assets_Scripts_Tools_Component_Main3DCameraWrap.StopAnim));
		L.RegFunction("Restore", new LuaCSFunction(Assets_Scripts_Tools_Component_Main3DCameraWrap.Restore));
		L.RegFunction("SetPostEffectActive", new LuaCSFunction(Assets_Scripts_Tools_Component_Main3DCameraWrap.SetPostEffectActive));
		L.RegFunction("SetForegroundCameraActive", new LuaCSFunction(Assets_Scripts_Tools_Component_Main3DCameraWrap.SetForegroundCameraActive));
		L.RegFunction("SetLookAtAgent", new LuaCSFunction(Assets_Scripts_Tools_Component_Main3DCameraWrap.SetLookAtAgent));
		L.RegFunction("LookAt", new LuaCSFunction(Assets_Scripts_Tools_Component_Main3DCameraWrap.LookAt));
		L.RegFunction("__eq", new LuaCSFunction(Assets_Scripts_Tools_Component_Main3DCameraWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("Instance", new LuaCSFunction(Assets_Scripts_Tools_Component_Main3DCameraWrap.get_Instance), new LuaCSFunction(Assets_Scripts_Tools_Component_Main3DCameraWrap.set_Instance));
		L.RegVar("Level1", new LuaCSFunction(Assets_Scripts_Tools_Component_Main3DCameraWrap.get_Level1), new LuaCSFunction(Assets_Scripts_Tools_Component_Main3DCameraWrap.set_Level1));
		L.RegVar("Level2", new LuaCSFunction(Assets_Scripts_Tools_Component_Main3DCameraWrap.get_Level2), new LuaCSFunction(Assets_Scripts_Tools_Component_Main3DCameraWrap.set_Level2));
		L.RegVar("Level3", new LuaCSFunction(Assets_Scripts_Tools_Component_Main3DCameraWrap.get_Level3), new LuaCSFunction(Assets_Scripts_Tools_Component_Main3DCameraWrap.set_Level3));
		L.RegVar("ForegroundBehavior", new LuaCSFunction(Assets_Scripts_Tools_Component_Main3DCameraWrap.get_ForegroundBehavior), new LuaCSFunction(Assets_Scripts_Tools_Component_Main3DCameraWrap.set_ForegroundBehavior));
		L.RegVar("Animation", new LuaCSFunction(Assets_Scripts_Tools_Component_Main3DCameraWrap.get_Animation), new LuaCSFunction(Assets_Scripts_Tools_Component_Main3DCameraWrap.set_Animation));
		L.RegVar("Camera", new LuaCSFunction(Assets_Scripts_Tools_Component_Main3DCameraWrap.get_Camera), new LuaCSFunction(Assets_Scripts_Tools_Component_Main3DCameraWrap.set_Camera));
		L.RegVar("LookAtAgent", new LuaCSFunction(Assets_Scripts_Tools_Component_Main3DCameraWrap.get_LookAtAgent), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Start(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Main3DCamera main3DCamera = (Main3DCamera)ToLua.CheckObject(L, 1, typeof(Main3DCamera));
			main3DCamera.Start();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetCamera(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Main3DCamera main3DCamera = (Main3DCamera)ToLua.CheckObject(L, 1, typeof(Main3DCamera));
			string cameraName = ToLua.CheckString(L, 2);
			Camera camera = main3DCamera.GetCamera(cameraName);
			ToLua.Push(L, camera);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PlayEntryAnim(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Main3DCamera main3DCamera = (Main3DCamera)ToLua.CheckObject(L, 1, typeof(Main3DCamera));
			main3DCamera.PlayEntryAnim();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PlayDefaultAnim(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Main3DCamera main3DCamera = (Main3DCamera)ToLua.CheckObject(L, 1, typeof(Main3DCamera));
			main3DCamera.PlayDefaultAnim();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int StopAnim(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Main3DCamera main3DCamera = (Main3DCamera)ToLua.CheckObject(L, 1, typeof(Main3DCamera));
			main3DCamera.StopAnim();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Restore(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Main3DCamera main3DCamera = (Main3DCamera)ToLua.CheckObject(L, 1, typeof(Main3DCamera));
			main3DCamera.Restore();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetPostEffectActive(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Main3DCamera main3DCamera = (Main3DCamera)ToLua.CheckObject(L, 1, typeof(Main3DCamera));
			bool postEffectActive = LuaDLL.luaL_checkboolean(L, 2);
			main3DCamera.SetPostEffectActive(postEffectActive);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetForegroundCameraActive(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Main3DCamera main3DCamera = (Main3DCamera)ToLua.CheckObject(L, 1, typeof(Main3DCamera));
			bool foregroundCameraActive = LuaDLL.luaL_checkboolean(L, 2);
			main3DCamera.SetForegroundCameraActive(foregroundCameraActive);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetLookAtAgent(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Main3DCamera main3DCamera = (Main3DCamera)ToLua.CheckObject(L, 1, typeof(Main3DCamera));
			Transform target = (Transform)ToLua.CheckUnityObject(L, 2, typeof(Transform));
			Vector3 offset = ToLua.ToVector3(L, 3);
			main3DCamera.SetLookAtAgent(target, offset);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LookAt(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Main3DCamera main3DCamera = (Main3DCamera)ToLua.CheckObject(L, 1, typeof(Main3DCamera));
			Transform target = (Transform)ToLua.CheckUnityObject(L, 2, typeof(Transform));
			Vector3 offset = ToLua.ToVector3(L, 3);
			main3DCamera.LookAt(target, offset);
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
	private static int get_Instance(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, Main3DCamera.Instance);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Level1(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Main3DCamera main3DCamera = (Main3DCamera)obj;
			Transform level = main3DCamera.Level1;
			ToLua.Push(L, level);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Level1 on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Level2(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Main3DCamera main3DCamera = (Main3DCamera)obj;
			Transform level = main3DCamera.Level2;
			ToLua.Push(L, level);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Level2 on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Level3(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Main3DCamera main3DCamera = (Main3DCamera)obj;
			Transform level = main3DCamera.Level3;
			ToLua.Push(L, level);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Level3 on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_ForegroundBehavior(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Main3DCamera main3DCamera = (Main3DCamera)obj;
			ForegroundBehavior foregroundBehavior = main3DCamera.ForegroundBehavior;
			ToLua.Push(L, foregroundBehavior);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ForegroundBehavior on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Animation(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Main3DCamera main3DCamera = (Main3DCamera)obj;
			AnimationPlayer animation = main3DCamera.Animation;
			ToLua.Push(L, animation);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Animation on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Camera(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Main3DCamera main3DCamera = (Main3DCamera)obj;
			Camera camera = main3DCamera.Camera;
			ToLua.Push(L, camera);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Camera on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_LookAtAgent(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Main3DCamera main3DCamera = (Main3DCamera)obj;
			Transform lookAtAgent = main3DCamera.LookAtAgent;
			ToLua.Push(L, lookAtAgent);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index LookAtAgent on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Instance(IntPtr L)
	{
		int result;
		try
		{
			Main3DCamera instance = (Main3DCamera)ToLua.CheckUnityObject(L, 2, typeof(Main3DCamera));
			Main3DCamera.Instance = instance;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Level1(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Main3DCamera main3DCamera = (Main3DCamera)obj;
			Transform level = (Transform)ToLua.CheckUnityObject(L, 2, typeof(Transform));
			main3DCamera.Level1 = level;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Level1 on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Level2(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Main3DCamera main3DCamera = (Main3DCamera)obj;
			Transform level = (Transform)ToLua.CheckUnityObject(L, 2, typeof(Transform));
			main3DCamera.Level2 = level;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Level2 on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Level3(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Main3DCamera main3DCamera = (Main3DCamera)obj;
			Transform level = (Transform)ToLua.CheckUnityObject(L, 2, typeof(Transform));
			main3DCamera.Level3 = level;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Level3 on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_ForegroundBehavior(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Main3DCamera main3DCamera = (Main3DCamera)obj;
			ForegroundBehavior foregroundBehavior = (ForegroundBehavior)ToLua.CheckUnityObject(L, 2, typeof(ForegroundBehavior));
			main3DCamera.ForegroundBehavior = foregroundBehavior;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ForegroundBehavior on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Animation(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Main3DCamera main3DCamera = (Main3DCamera)obj;
			AnimationPlayer animation = (AnimationPlayer)ToLua.CheckUnityObject(L, 2, typeof(AnimationPlayer));
			main3DCamera.Animation = animation;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Animation on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Camera(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Main3DCamera main3DCamera = (Main3DCamera)obj;
			Camera camera = (Camera)ToLua.CheckUnityObject(L, 2, typeof(Camera));
			main3DCamera.Camera = camera;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Camera on a nil value");
		}
		return result;
	}
}
