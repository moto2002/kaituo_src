using LuaInterface;
using System;
using UnityEngine;
using XQ.Framework.Lua.Utility;

public class XQ_Framework_Lua_Utility_NGUIToolWrap
{
	public static void Register(LuaState L)
	{
		L.BeginStaticLibs("NGUITool");
		L.RegFunction("StopAllTweener", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIToolWrap.StopAllTweener));
		L.RegFunction("LockPanelRoll", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIToolWrap.LockPanelRoll));
		L.RegFunction("UnlockPanelRoll", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIToolWrap.UnlockPanelRoll));
		L.RegFunction("ClearTweenerEvent", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIToolWrap.ClearTweenerEvent));
		L.RegFunction("StopAndClearTweenerEvent", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIToolWrap.StopAndClearTweenerEvent));
		L.RegFunction("CancelSpringPosition", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIToolWrap.CancelSpringPosition));
		L.RegFunction("ChangAllChildColor", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIToolWrap.ChangAllChildColor));
		L.RegFunction("SetColliderEnable", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIToolWrap.SetColliderEnable));
		L.RegFunction("GetCurrTouchObject", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIToolWrap.GetCurrTouchObject));
		L.RegFunction("GetCurrOffsetTouchObject", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIToolWrap.GetCurrOffsetTouchObject));
		L.RegFunction("RaycastCurrTouchObject", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIToolWrap.RaycastCurrTouchObject));
		L.RegFunction("GetTopUICamera", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIToolWrap.GetTopUICamera));
		L.RegFunction("GetTopUIRoot", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIToolWrap.GetTopUIRoot));
		L.RegFunction("GetTweenerCurve", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIToolWrap.GetTweenerCurve));
		L.RegFunction("CopyTweener", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIToolWrap.CopyTweener));
		L.RegFunction("PlayTweenerGroup", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIToolWrap.PlayTweenerGroup));
		L.RegFunction("PlayObjectTweenerGroup", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIToolWrap.PlayObjectTweenerGroup));
		L.RegFunction("SetTextureUV", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIToolWrap.SetTextureUV));
		L.RegFunction("CameraRaycastHit", new LuaCSFunction(XQ_Framework_Lua_Utility_NGUIToolWrap.CameraRaycastHit));
		L.EndStaticLibs();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int StopAllTweener(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			NGUITool.StopAllTweener();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LockPanelRoll(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UIPanel panel = (UIPanel)ToLua.CheckUnityObject(L, 1, typeof(UIPanel));
			GameObject anchor = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			NGUITool.LockPanelRoll(panel, anchor);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UnlockPanelRoll(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIPanel panel = (UIPanel)ToLua.CheckUnityObject(L, 1, typeof(UIPanel));
			NGUITool.UnlockPanelRoll(panel);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ClearTweenerEvent(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GameObject obj = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			NGUITool.ClearTweenerEvent(obj);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int StopAndClearTweenerEvent(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GameObject obj = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			NGUITool.StopAndClearTweenerEvent(obj);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CancelSpringPosition(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GameObject obj = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			NGUITool.CancelSpringPosition(obj);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ChangAllChildColor(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Transform tf = (Transform)ToLua.CheckUnityObject(L, 1, typeof(Transform));
			Color color = ToLua.ToColor(L, 2);
			NGUITool.ChangAllChildColor(tf, color);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetColliderEnable(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(GameObject), typeof(bool)))
			{
				GameObject colliderObj = (GameObject)ToLua.ToObject(L, 1);
				bool enabled = LuaDLL.lua_toboolean(L, 2);
				NGUITool.SetColliderEnable(colliderObj, enabled);
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(BoxCollider), typeof(bool)))
			{
				BoxCollider collider = (BoxCollider)ToLua.ToObject(L, 1);
				bool enabled2 = LuaDLL.lua_toboolean(L, 2);
				NGUITool.SetColliderEnable(collider, enabled2);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: XQ.Framework.Lua.Utility.NGUITool.SetColliderEnable");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetCurrTouchObject(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			GameObject currTouchObject = NGUITool.GetCurrTouchObject();
			ToLua.Push(L, currTouchObject);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetCurrOffsetTouchObject(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Vector2 offset = ToLua.ToVector2(L, 1);
			GameObject currOffsetTouchObject = NGUITool.GetCurrOffsetTouchObject(offset);
			ToLua.Push(L, currOffsetTouchObject);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RaycastCurrTouchObject(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			GameObject obj = NGUITool.RaycastCurrTouchObject();
			ToLua.Push(L, obj);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetTopUICamera(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			UICamera topUICamera = NGUITool.GetTopUICamera();
			ToLua.Push(L, topUICamera);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetTopUIRoot(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			UIRoot topUIRoot = NGUITool.GetTopUIRoot();
			ToLua.Push(L, topUIRoot);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetTweenerCurve(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GameObject from = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			AnimationCurve tweenerCurve = NGUITool.GetTweenerCurve(from);
			ToLua.PushObject(L, tweenerCurve);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CopyTweener(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			GameObject from = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			GameObject to = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			NGUITool.CopyTweener(from, to);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PlayTweenerGroup(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			GameObject obj = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			int group = (int)LuaDLL.luaL_checknumber(L, 2);
			NGUITool.PlayTweenerGroup(obj, group);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PlayObjectTweenerGroup(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			GameObject from = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			GameObject to = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			int group = (int)LuaDLL.luaL_checknumber(L, 3);
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
			NGUITool.PlayObjectTweenerGroup(from, to, group, onEnd);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetTextureUV(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 5);
			UITexture texture = (UITexture)ToLua.CheckUnityObject(L, 1, typeof(UITexture));
			float x = (float)LuaDLL.luaL_checknumber(L, 2);
			float y = (float)LuaDLL.luaL_checknumber(L, 3);
			float w = (float)LuaDLL.luaL_checknumber(L, 4);
			float h = (float)LuaDLL.luaL_checknumber(L, 5);
			NGUITool.SetTextureUV(texture, x, y, w, h);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CameraRaycastHit(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Camera camera = (Camera)ToLua.CheckUnityObject(L, 1, typeof(Camera));
			Vector3 targetPos = ToLua.ToVector3(L, 2);
			RaycastHit hit = NGUITool.CameraRaycastHit(camera, targetPos);
			ToLua.Push(L, hit);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
