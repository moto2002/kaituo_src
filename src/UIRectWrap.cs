using LuaInterface;
using System;
using UnityEngine;

public class UIRectWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UIRect), typeof(MultiResourceManager), null);
		L.RegFunction("CalculateFinalAlpha", new LuaCSFunction(UIRectWrap.CalculateFinalAlpha));
		L.RegFunction("Invalidate", new LuaCSFunction(UIRectWrap.Invalidate));
		L.RegFunction("GetSides", new LuaCSFunction(UIRectWrap.GetSides));
		L.RegFunction("Update", new LuaCSFunction(UIRectWrap.Update));
		L.RegFunction("UpdateAnchors", new LuaCSFunction(UIRectWrap.UpdateAnchors));
		L.RegFunction("SetAnchor", new LuaCSFunction(UIRectWrap.SetAnchor));
		L.RegFunction("SetScreenRect", new LuaCSFunction(UIRectWrap.SetScreenRect));
		L.RegFunction("ResetAnchors", new LuaCSFunction(UIRectWrap.ResetAnchors));
		L.RegFunction("ResetAndUpdateAnchors", new LuaCSFunction(UIRectWrap.ResetAndUpdateAnchors));
		L.RegFunction("SetRect", new LuaCSFunction(UIRectWrap.SetRect));
		L.RegFunction("ParentHasChanged", new LuaCSFunction(UIRectWrap.ParentHasChanged));
		L.RegFunction("__eq", new LuaCSFunction(UIRectWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("leftAnchor", new LuaCSFunction(UIRectWrap.get_leftAnchor), new LuaCSFunction(UIRectWrap.set_leftAnchor));
		L.RegVar("rightAnchor", new LuaCSFunction(UIRectWrap.get_rightAnchor), new LuaCSFunction(UIRectWrap.set_rightAnchor));
		L.RegVar("bottomAnchor", new LuaCSFunction(UIRectWrap.get_bottomAnchor), new LuaCSFunction(UIRectWrap.set_bottomAnchor));
		L.RegVar("topAnchor", new LuaCSFunction(UIRectWrap.get_topAnchor), new LuaCSFunction(UIRectWrap.set_topAnchor));
		L.RegVar("updateAnchors", new LuaCSFunction(UIRectWrap.get_updateAnchors), new LuaCSFunction(UIRectWrap.set_updateAnchors));
		L.RegVar("finalAlpha", new LuaCSFunction(UIRectWrap.get_finalAlpha), new LuaCSFunction(UIRectWrap.set_finalAlpha));
		L.RegVar("cachedGameObject", new LuaCSFunction(UIRectWrap.get_cachedGameObject), null);
		L.RegVar("cachedTransform", new LuaCSFunction(UIRectWrap.get_cachedTransform), null);
		L.RegVar("anchorCamera", new LuaCSFunction(UIRectWrap.get_anchorCamera), null);
		L.RegVar("isFullyAnchored", new LuaCSFunction(UIRectWrap.get_isFullyAnchored), null);
		L.RegVar("isAnchoredHorizontally", new LuaCSFunction(UIRectWrap.get_isAnchoredHorizontally), null);
		L.RegVar("isAnchoredVertically", new LuaCSFunction(UIRectWrap.get_isAnchoredVertically), null);
		L.RegVar("canBeAnchored", new LuaCSFunction(UIRectWrap.get_canBeAnchored), null);
		L.RegVar("parent", new LuaCSFunction(UIRectWrap.get_parent), null);
		L.RegVar("root", new LuaCSFunction(UIRectWrap.get_root), null);
		L.RegVar("isAnchored", new LuaCSFunction(UIRectWrap.get_isAnchored), null);
		L.RegVar("alpha", new LuaCSFunction(UIRectWrap.get_alpha), new LuaCSFunction(UIRectWrap.set_alpha));
		L.RegVar("localCorners", new LuaCSFunction(UIRectWrap.get_localCorners), null);
		L.RegVar("worldCorners", new LuaCSFunction(UIRectWrap.get_worldCorners), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CalculateFinalAlpha(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UIRect uIRect = (UIRect)ToLua.CheckObject(L, 1, typeof(UIRect));
			int frameID = (int)LuaDLL.luaL_checknumber(L, 2);
			float num = uIRect.CalculateFinalAlpha(frameID);
			LuaDLL.lua_pushnumber(L, (double)num);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Invalidate(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UIRect uIRect = (UIRect)ToLua.CheckObject(L, 1, typeof(UIRect));
			bool includeChildren = LuaDLL.luaL_checkboolean(L, 2);
			uIRect.Invalidate(includeChildren);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetSides(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UIRect uIRect = (UIRect)ToLua.CheckObject(L, 1, typeof(UIRect));
			Transform relativeTo = (Transform)ToLua.CheckUnityObject(L, 2, typeof(Transform));
			Vector3[] sides = uIRect.GetSides(relativeTo);
			ToLua.Push(L, sides);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Update(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIRect uIRect = (UIRect)ToLua.CheckObject(L, 1, typeof(UIRect));
			uIRect.Update();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UpdateAnchors(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIRect uIRect = (UIRect)ToLua.CheckObject(L, 1, typeof(UIRect));
			uIRect.UpdateAnchors();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetAnchor(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(UIRect), typeof(GameObject)))
			{
				UIRect uIRect = (UIRect)ToLua.ToObject(L, 1);
				GameObject anchor = (GameObject)ToLua.ToObject(L, 2);
				uIRect.SetAnchor(anchor);
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(UIRect), typeof(Transform)))
			{
				UIRect uIRect2 = (UIRect)ToLua.ToObject(L, 1);
				Transform anchor2 = (Transform)ToLua.ToObject(L, 2);
				uIRect2.SetAnchor(anchor2);
				result = 0;
			}
			else if (num == 6 && TypeChecker.CheckTypes(L, 1, typeof(UIRect), typeof(GameObject), typeof(float), typeof(float), typeof(float), typeof(float)))
			{
				UIRect uIRect3 = (UIRect)ToLua.ToObject(L, 1);
				GameObject go = (GameObject)ToLua.ToObject(L, 2);
				float left = (float)LuaDLL.lua_tonumber(L, 3);
				float bottom = (float)LuaDLL.lua_tonumber(L, 4);
				float right = (float)LuaDLL.lua_tonumber(L, 5);
				float top = (float)LuaDLL.lua_tonumber(L, 6);
				uIRect3.SetAnchor(go, left, bottom, right, top);
				result = 0;
			}
			else if (num == 6 && TypeChecker.CheckTypes(L, 1, typeof(UIRect), typeof(GameObject), typeof(int), typeof(int), typeof(int), typeof(int)))
			{
				UIRect uIRect4 = (UIRect)ToLua.ToObject(L, 1);
				GameObject go2 = (GameObject)ToLua.ToObject(L, 2);
				int left2 = (int)LuaDLL.lua_tonumber(L, 3);
				int bottom2 = (int)LuaDLL.lua_tonumber(L, 4);
				int right2 = (int)LuaDLL.lua_tonumber(L, 5);
				int top2 = (int)LuaDLL.lua_tonumber(L, 6);
				uIRect4.SetAnchor(go2, left2, bottom2, right2, top2);
				result = 0;
			}
			else if (num == 9 && TypeChecker.CheckTypes(L, 1, typeof(UIRect), typeof(float), typeof(int), typeof(float), typeof(int), typeof(float), typeof(int), typeof(float), typeof(int)))
			{
				UIRect uIRect5 = (UIRect)ToLua.ToObject(L, 1);
				float left3 = (float)LuaDLL.lua_tonumber(L, 2);
				int leftOffset = (int)LuaDLL.lua_tonumber(L, 3);
				float bottom3 = (float)LuaDLL.lua_tonumber(L, 4);
				int bottomOffset = (int)LuaDLL.lua_tonumber(L, 5);
				float right3 = (float)LuaDLL.lua_tonumber(L, 6);
				int rightOffset = (int)LuaDLL.lua_tonumber(L, 7);
				float top3 = (float)LuaDLL.lua_tonumber(L, 8);
				int topOffset = (int)LuaDLL.lua_tonumber(L, 9);
				uIRect5.SetAnchor(left3, leftOffset, bottom3, bottomOffset, right3, rightOffset, top3, topOffset);
				result = 0;
			}
			else if (num == 10 && TypeChecker.CheckTypes(L, 1, typeof(UIRect), typeof(GameObject), typeof(float), typeof(int), typeof(float), typeof(int), typeof(float), typeof(int), typeof(float), typeof(int)))
			{
				UIRect uIRect6 = (UIRect)ToLua.ToObject(L, 1);
				GameObject go3 = (GameObject)ToLua.ToObject(L, 2);
				float left4 = (float)LuaDLL.lua_tonumber(L, 3);
				int leftOffset2 = (int)LuaDLL.lua_tonumber(L, 4);
				float bottom4 = (float)LuaDLL.lua_tonumber(L, 5);
				int bottomOffset2 = (int)LuaDLL.lua_tonumber(L, 6);
				float right4 = (float)LuaDLL.lua_tonumber(L, 7);
				int rightOffset2 = (int)LuaDLL.lua_tonumber(L, 8);
				float top4 = (float)LuaDLL.lua_tonumber(L, 9);
				int topOffset2 = (int)LuaDLL.lua_tonumber(L, 10);
				uIRect6.SetAnchor(go3, left4, leftOffset2, bottom4, bottomOffset2, right4, rightOffset2, top4, topOffset2);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UIRect.SetAnchor");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetScreenRect(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 5);
			UIRect uIRect = (UIRect)ToLua.CheckObject(L, 1, typeof(UIRect));
			int left = (int)LuaDLL.luaL_checknumber(L, 2);
			int top = (int)LuaDLL.luaL_checknumber(L, 3);
			int width = (int)LuaDLL.luaL_checknumber(L, 4);
			int height = (int)LuaDLL.luaL_checknumber(L, 5);
			uIRect.SetScreenRect(left, top, width, height);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ResetAnchors(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIRect uIRect = (UIRect)ToLua.CheckObject(L, 1, typeof(UIRect));
			uIRect.ResetAnchors();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ResetAndUpdateAnchors(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIRect uIRect = (UIRect)ToLua.CheckObject(L, 1, typeof(UIRect));
			uIRect.ResetAndUpdateAnchors();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetRect(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 5);
			UIRect uIRect = (UIRect)ToLua.CheckObject(L, 1, typeof(UIRect));
			float x = (float)LuaDLL.luaL_checknumber(L, 2);
			float y = (float)LuaDLL.luaL_checknumber(L, 3);
			float width = (float)LuaDLL.luaL_checknumber(L, 4);
			float height = (float)LuaDLL.luaL_checknumber(L, 5);
			uIRect.SetRect(x, y, width, height);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ParentHasChanged(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIRect uIRect = (UIRect)ToLua.CheckObject(L, 1, typeof(UIRect));
			uIRect.ParentHasChanged();
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
	private static int get_leftAnchor(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRect uIRect = (UIRect)obj;
			UIRect.AnchorPoint leftAnchor = uIRect.leftAnchor;
			ToLua.PushObject(L, leftAnchor);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index leftAnchor on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_rightAnchor(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRect uIRect = (UIRect)obj;
			UIRect.AnchorPoint rightAnchor = uIRect.rightAnchor;
			ToLua.PushObject(L, rightAnchor);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index rightAnchor on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_bottomAnchor(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRect uIRect = (UIRect)obj;
			UIRect.AnchorPoint bottomAnchor = uIRect.bottomAnchor;
			ToLua.PushObject(L, bottomAnchor);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index bottomAnchor on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_topAnchor(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRect uIRect = (UIRect)obj;
			UIRect.AnchorPoint topAnchor = uIRect.topAnchor;
			ToLua.PushObject(L, topAnchor);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index topAnchor on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_updateAnchors(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRect uIRect = (UIRect)obj;
			UIRect.AnchorUpdate updateAnchors = uIRect.updateAnchors;
			ToLua.Push(L, updateAnchors);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index updateAnchors on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_finalAlpha(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRect uIRect = (UIRect)obj;
			float finalAlpha = uIRect.finalAlpha;
			LuaDLL.lua_pushnumber(L, (double)finalAlpha);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index finalAlpha on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_cachedGameObject(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRect uIRect = (UIRect)obj;
			GameObject cachedGameObject = uIRect.cachedGameObject;
			ToLua.Push(L, cachedGameObject);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cachedGameObject on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_cachedTransform(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRect uIRect = (UIRect)obj;
			Transform cachedTransform = uIRect.cachedTransform;
			ToLua.Push(L, cachedTransform);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cachedTransform on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_anchorCamera(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRect uIRect = (UIRect)obj;
			Camera anchorCamera = uIRect.anchorCamera;
			ToLua.Push(L, anchorCamera);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index anchorCamera on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isFullyAnchored(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRect uIRect = (UIRect)obj;
			bool isFullyAnchored = uIRect.isFullyAnchored;
			LuaDLL.lua_pushboolean(L, isFullyAnchored);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isFullyAnchored on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isAnchoredHorizontally(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRect uIRect = (UIRect)obj;
			bool isAnchoredHorizontally = uIRect.isAnchoredHorizontally;
			LuaDLL.lua_pushboolean(L, isAnchoredHorizontally);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isAnchoredHorizontally on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isAnchoredVertically(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRect uIRect = (UIRect)obj;
			bool isAnchoredVertically = uIRect.isAnchoredVertically;
			LuaDLL.lua_pushboolean(L, isAnchoredVertically);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isAnchoredVertically on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_canBeAnchored(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRect uIRect = (UIRect)obj;
			bool canBeAnchored = uIRect.canBeAnchored;
			LuaDLL.lua_pushboolean(L, canBeAnchored);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index canBeAnchored on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_parent(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRect uIRect = (UIRect)obj;
			UIRect parent = uIRect.parent;
			ToLua.Push(L, parent);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index parent on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_root(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRect uIRect = (UIRect)obj;
			UIRoot root = uIRect.root;
			ToLua.Push(L, root);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index root on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isAnchored(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRect uIRect = (UIRect)obj;
			bool isAnchored = uIRect.isAnchored;
			LuaDLL.lua_pushboolean(L, isAnchored);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isAnchored on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_alpha(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRect uIRect = (UIRect)obj;
			float alpha = uIRect.alpha;
			LuaDLL.lua_pushnumber(L, (double)alpha);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index alpha on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_localCorners(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRect uIRect = (UIRect)obj;
			Vector3[] localCorners = uIRect.localCorners;
			ToLua.Push(L, localCorners);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index localCorners on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_worldCorners(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRect uIRect = (UIRect)obj;
			Vector3[] worldCorners = uIRect.worldCorners;
			ToLua.Push(L, worldCorners);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index worldCorners on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_leftAnchor(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRect uIRect = (UIRect)obj;
			UIRect.AnchorPoint leftAnchor = (UIRect.AnchorPoint)ToLua.CheckObject(L, 2, typeof(UIRect.AnchorPoint));
			uIRect.leftAnchor = leftAnchor;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index leftAnchor on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_rightAnchor(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRect uIRect = (UIRect)obj;
			UIRect.AnchorPoint rightAnchor = (UIRect.AnchorPoint)ToLua.CheckObject(L, 2, typeof(UIRect.AnchorPoint));
			uIRect.rightAnchor = rightAnchor;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index rightAnchor on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_bottomAnchor(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRect uIRect = (UIRect)obj;
			UIRect.AnchorPoint bottomAnchor = (UIRect.AnchorPoint)ToLua.CheckObject(L, 2, typeof(UIRect.AnchorPoint));
			uIRect.bottomAnchor = bottomAnchor;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index bottomAnchor on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_topAnchor(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRect uIRect = (UIRect)obj;
			UIRect.AnchorPoint topAnchor = (UIRect.AnchorPoint)ToLua.CheckObject(L, 2, typeof(UIRect.AnchorPoint));
			uIRect.topAnchor = topAnchor;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index topAnchor on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_updateAnchors(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRect uIRect = (UIRect)obj;
			UIRect.AnchorUpdate updateAnchors = (UIRect.AnchorUpdate)LuaDLL.luaL_checknumber(L, 2);
			uIRect.updateAnchors = updateAnchors;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index updateAnchors on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_finalAlpha(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRect uIRect = (UIRect)obj;
			float finalAlpha = (float)LuaDLL.luaL_checknumber(L, 2);
			uIRect.finalAlpha = finalAlpha;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index finalAlpha on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_alpha(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIRect uIRect = (UIRect)obj;
			float alpha = (float)LuaDLL.luaL_checknumber(L, 2);
			uIRect.alpha = alpha;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index alpha on a nil value");
		}
		return result;
	}
}
