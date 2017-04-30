using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

public class UIPanelWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UIPanel), typeof(UIRect), null);
		L.RegFunction("CompareFunc", new LuaCSFunction(UIPanelWrap.CompareFunc));
		L.RegFunction("GetSides", new LuaCSFunction(UIPanelWrap.GetSides));
		L.RegFunction("Invalidate", new LuaCSFunction(UIPanelWrap.Invalidate));
		L.RegFunction("CalculateFinalAlpha", new LuaCSFunction(UIPanelWrap.CalculateFinalAlpha));
		L.RegFunction("SetRect", new LuaCSFunction(UIPanelWrap.SetRect));
		L.RegFunction("IsVisible", new LuaCSFunction(UIPanelWrap.IsVisible));
		L.RegFunction("Affects", new LuaCSFunction(UIPanelWrap.Affects));
		L.RegFunction("RebuildAllDrawCalls", new LuaCSFunction(UIPanelWrap.RebuildAllDrawCalls));
		L.RegFunction("SetDirty", new LuaCSFunction(UIPanelWrap.SetDirty));
		L.RegFunction("ParentHasChanged", new LuaCSFunction(UIPanelWrap.ParentHasChanged));
		L.RegFunction("SortWidgets", new LuaCSFunction(UIPanelWrap.SortWidgets));
		L.RegFunction("FillDrawCall", new LuaCSFunction(UIPanelWrap.FillDrawCall));
		L.RegFunction("FindDrawCall", new LuaCSFunction(UIPanelWrap.FindDrawCall));
		L.RegFunction("AddWidget", new LuaCSFunction(UIPanelWrap.AddWidget));
		L.RegFunction("RemoveWidget", new LuaCSFunction(UIPanelWrap.RemoveWidget));
		L.RegFunction("Refresh", new LuaCSFunction(UIPanelWrap.Refresh));
		L.RegFunction("CalculateConstrainOffset", new LuaCSFunction(UIPanelWrap.CalculateConstrainOffset));
		L.RegFunction("ConstrainTargetToBounds", new LuaCSFunction(UIPanelWrap.ConstrainTargetToBounds));
		L.RegFunction("Find", new LuaCSFunction(UIPanelWrap.Find));
		L.RegFunction("GetWindowSize", new LuaCSFunction(UIPanelWrap.GetWindowSize));
		L.RegFunction("GetViewSize", new LuaCSFunction(UIPanelWrap.GetViewSize));
		L.RegFunction("__eq", new LuaCSFunction(UIPanelWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("list", new LuaCSFunction(UIPanelWrap.get_list), new LuaCSFunction(UIPanelWrap.set_list));
		L.RegVar("onGeometryUpdated", new LuaCSFunction(UIPanelWrap.get_onGeometryUpdated), new LuaCSFunction(UIPanelWrap.set_onGeometryUpdated));
		L.RegVar("showInPanelTool", new LuaCSFunction(UIPanelWrap.get_showInPanelTool), new LuaCSFunction(UIPanelWrap.set_showInPanelTool));
		L.RegVar("generateNormals", new LuaCSFunction(UIPanelWrap.get_generateNormals), new LuaCSFunction(UIPanelWrap.set_generateNormals));
		L.RegVar("widgetsAreStatic", new LuaCSFunction(UIPanelWrap.get_widgetsAreStatic), new LuaCSFunction(UIPanelWrap.set_widgetsAreStatic));
		L.RegVar("cullWhileDragging", new LuaCSFunction(UIPanelWrap.get_cullWhileDragging), new LuaCSFunction(UIPanelWrap.set_cullWhileDragging));
		L.RegVar("alwaysOnScreen", new LuaCSFunction(UIPanelWrap.get_alwaysOnScreen), new LuaCSFunction(UIPanelWrap.set_alwaysOnScreen));
		L.RegVar("anchorOffset", new LuaCSFunction(UIPanelWrap.get_anchorOffset), new LuaCSFunction(UIPanelWrap.set_anchorOffset));
		L.RegVar("softBorderPadding", new LuaCSFunction(UIPanelWrap.get_softBorderPadding), new LuaCSFunction(UIPanelWrap.set_softBorderPadding));
		L.RegVar("renderQueue", new LuaCSFunction(UIPanelWrap.get_renderQueue), new LuaCSFunction(UIPanelWrap.set_renderQueue));
		L.RegVar("startingRenderQueue", new LuaCSFunction(UIPanelWrap.get_startingRenderQueue), new LuaCSFunction(UIPanelWrap.set_startingRenderQueue));
		L.RegVar("widgets", new LuaCSFunction(UIPanelWrap.get_widgets), new LuaCSFunction(UIPanelWrap.set_widgets));
		L.RegVar("drawCalls", new LuaCSFunction(UIPanelWrap.get_drawCalls), new LuaCSFunction(UIPanelWrap.set_drawCalls));
		L.RegVar("worldToLocal", new LuaCSFunction(UIPanelWrap.get_worldToLocal), new LuaCSFunction(UIPanelWrap.set_worldToLocal));
		L.RegVar("drawCallClipRange", new LuaCSFunction(UIPanelWrap.get_drawCallClipRange), new LuaCSFunction(UIPanelWrap.set_drawCallClipRange));
		L.RegVar("onClipMove", new LuaCSFunction(UIPanelWrap.get_onClipMove), new LuaCSFunction(UIPanelWrap.set_onClipMove));
		L.RegVar("sortingLayerName", new LuaCSFunction(UIPanelWrap.get_sortingLayerName), new LuaCSFunction(UIPanelWrap.set_sortingLayerName));
		L.RegVar("nextUnusedDepth", new LuaCSFunction(UIPanelWrap.get_nextUnusedDepth), null);
		L.RegVar("canBeAnchored", new LuaCSFunction(UIPanelWrap.get_canBeAnchored), null);
		L.RegVar("alpha", new LuaCSFunction(UIPanelWrap.get_alpha), new LuaCSFunction(UIPanelWrap.set_alpha));
		L.RegVar("depth", new LuaCSFunction(UIPanelWrap.get_depth), new LuaCSFunction(UIPanelWrap.set_depth));
		L.RegVar("sortingOrder", new LuaCSFunction(UIPanelWrap.get_sortingOrder), new LuaCSFunction(UIPanelWrap.set_sortingOrder));
		L.RegVar("width", new LuaCSFunction(UIPanelWrap.get_width), null);
		L.RegVar("height", new LuaCSFunction(UIPanelWrap.get_height), null);
		L.RegVar("halfPixelOffset", new LuaCSFunction(UIPanelWrap.get_halfPixelOffset), null);
		L.RegVar("usedForUI", new LuaCSFunction(UIPanelWrap.get_usedForUI), null);
		L.RegVar("drawCallOffset", new LuaCSFunction(UIPanelWrap.get_drawCallOffset), null);
		L.RegVar("clipping", new LuaCSFunction(UIPanelWrap.get_clipping), new LuaCSFunction(UIPanelWrap.set_clipping));
		L.RegVar("parentPanel", new LuaCSFunction(UIPanelWrap.get_parentPanel), null);
		L.RegVar("clipCount", new LuaCSFunction(UIPanelWrap.get_clipCount), null);
		L.RegVar("hasClipping", new LuaCSFunction(UIPanelWrap.get_hasClipping), null);
		L.RegVar("hasCumulativeClipping", new LuaCSFunction(UIPanelWrap.get_hasCumulativeClipping), null);
		L.RegVar("clipOffset", new LuaCSFunction(UIPanelWrap.get_clipOffset), new LuaCSFunction(UIPanelWrap.set_clipOffset));
		L.RegVar("clipTexture", new LuaCSFunction(UIPanelWrap.get_clipTexture), new LuaCSFunction(UIPanelWrap.set_clipTexture));
		L.RegVar("baseClipRegion", new LuaCSFunction(UIPanelWrap.get_baseClipRegion), new LuaCSFunction(UIPanelWrap.set_baseClipRegion));
		L.RegVar("finalClipRegion", new LuaCSFunction(UIPanelWrap.get_finalClipRegion), null);
		L.RegVar("clipSoftness", new LuaCSFunction(UIPanelWrap.get_clipSoftness), new LuaCSFunction(UIPanelWrap.set_clipSoftness));
		L.RegVar("localCorners", new LuaCSFunction(UIPanelWrap.get_localCorners), null);
		L.RegVar("worldCorners", new LuaCSFunction(UIPanelWrap.get_worldCorners), null);
		L.RegFunction("OnClippingMoved", new LuaCSFunction(UIPanelWrap.UIPanel_OnClippingMoved));
		L.RegFunction("OnGeometryUpdated", new LuaCSFunction(UIPanelWrap.UIPanel_OnGeometryUpdated));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CompareFunc(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UIPanel a = (UIPanel)ToLua.CheckUnityObject(L, 1, typeof(UIPanel));
			UIPanel b = (UIPanel)ToLua.CheckUnityObject(L, 2, typeof(UIPanel));
			int n = UIPanel.CompareFunc(a, b);
			LuaDLL.lua_pushinteger(L, n);
			result = 1;
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
			UIPanel uIPanel = (UIPanel)ToLua.CheckObject(L, 1, typeof(UIPanel));
			Transform relativeTo = (Transform)ToLua.CheckUnityObject(L, 2, typeof(Transform));
			Vector3[] sides = uIPanel.GetSides(relativeTo);
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
	private static int Invalidate(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UIPanel uIPanel = (UIPanel)ToLua.CheckObject(L, 1, typeof(UIPanel));
			bool includeChildren = LuaDLL.luaL_checkboolean(L, 2);
			uIPanel.Invalidate(includeChildren);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CalculateFinalAlpha(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UIPanel uIPanel = (UIPanel)ToLua.CheckObject(L, 1, typeof(UIPanel));
			int frameID = (int)LuaDLL.luaL_checknumber(L, 2);
			float num = uIPanel.CalculateFinalAlpha(frameID);
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
	private static int SetRect(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 5);
			UIPanel uIPanel = (UIPanel)ToLua.CheckObject(L, 1, typeof(UIPanel));
			float x = (float)LuaDLL.luaL_checknumber(L, 2);
			float y = (float)LuaDLL.luaL_checknumber(L, 3);
			float width = (float)LuaDLL.luaL_checknumber(L, 4);
			float height = (float)LuaDLL.luaL_checknumber(L, 5);
			uIPanel.SetRect(x, y, width, height);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsVisible(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(UIPanel), typeof(UIWidget)))
			{
				UIPanel uIPanel = (UIPanel)ToLua.ToObject(L, 1);
				UIWidget w = (UIWidget)ToLua.ToObject(L, 2);
				bool value = uIPanel.IsVisible(w);
				LuaDLL.lua_pushboolean(L, value);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(UIPanel), typeof(Vector3)))
			{
				UIPanel uIPanel2 = (UIPanel)ToLua.ToObject(L, 1);
				Vector3 worldPos = ToLua.ToVector3(L, 2);
				bool value2 = uIPanel2.IsVisible(worldPos);
				LuaDLL.lua_pushboolean(L, value2);
				result = 1;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(UIPanel), typeof(Vector3), typeof(Vector3), typeof(Vector3), typeof(Vector3)))
			{
				UIPanel uIPanel3 = (UIPanel)ToLua.ToObject(L, 1);
				Vector3 a = ToLua.ToVector3(L, 2);
				Vector3 b = ToLua.ToVector3(L, 3);
				Vector3 c = ToLua.ToVector3(L, 4);
				Vector3 d = ToLua.ToVector3(L, 5);
				bool value3 = uIPanel3.IsVisible(a, b, c, d);
				LuaDLL.lua_pushboolean(L, value3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UIPanel.IsVisible");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Affects(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UIPanel uIPanel = (UIPanel)ToLua.CheckObject(L, 1, typeof(UIPanel));
			UIWidget w = (UIWidget)ToLua.CheckUnityObject(L, 2, typeof(UIWidget));
			bool value = uIPanel.Affects(w);
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
	private static int RebuildAllDrawCalls(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIPanel uIPanel = (UIPanel)ToLua.CheckObject(L, 1, typeof(UIPanel));
			uIPanel.RebuildAllDrawCalls();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetDirty(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIPanel uIPanel = (UIPanel)ToLua.CheckObject(L, 1, typeof(UIPanel));
			uIPanel.SetDirty();
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
			UIPanel uIPanel = (UIPanel)ToLua.CheckObject(L, 1, typeof(UIPanel));
			uIPanel.ParentHasChanged();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SortWidgets(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIPanel uIPanel = (UIPanel)ToLua.CheckObject(L, 1, typeof(UIPanel));
			uIPanel.SortWidgets();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int FillDrawCall(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UIPanel uIPanel = (UIPanel)ToLua.CheckObject(L, 1, typeof(UIPanel));
			UIDrawCall dc = (UIDrawCall)ToLua.CheckUnityObject(L, 2, typeof(UIDrawCall));
			bool value = uIPanel.FillDrawCall(dc);
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
	private static int FindDrawCall(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UIPanel uIPanel = (UIPanel)ToLua.CheckObject(L, 1, typeof(UIPanel));
			UIWidget w = (UIWidget)ToLua.CheckUnityObject(L, 2, typeof(UIWidget));
			UIDrawCall obj = uIPanel.FindDrawCall(w);
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
	private static int AddWidget(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UIPanel uIPanel = (UIPanel)ToLua.CheckObject(L, 1, typeof(UIPanel));
			UIWidget w = (UIWidget)ToLua.CheckUnityObject(L, 2, typeof(UIWidget));
			uIPanel.AddWidget(w);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RemoveWidget(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UIPanel uIPanel = (UIPanel)ToLua.CheckObject(L, 1, typeof(UIPanel));
			UIWidget w = (UIWidget)ToLua.CheckUnityObject(L, 2, typeof(UIWidget));
			uIPanel.RemoveWidget(w);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Refresh(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIPanel uIPanel = (UIPanel)ToLua.CheckObject(L, 1, typeof(UIPanel));
			uIPanel.Refresh();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CalculateConstrainOffset(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			UIPanel uIPanel = (UIPanel)ToLua.CheckObject(L, 1, typeof(UIPanel));
			Vector2 min = ToLua.ToVector2(L, 2);
			Vector2 max = ToLua.ToVector2(L, 3);
			Vector3 v = uIPanel.CalculateConstrainOffset(min, max);
			ToLua.Push(L, v);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ConstrainTargetToBounds(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(UIPanel), typeof(Transform), typeof(bool)))
			{
				UIPanel uIPanel = (UIPanel)ToLua.ToObject(L, 1);
				Transform target = (Transform)ToLua.ToObject(L, 2);
				bool immediate = LuaDLL.lua_toboolean(L, 3);
				bool value = uIPanel.ConstrainTargetToBounds(target, immediate);
				LuaDLL.lua_pushboolean(L, value);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(UIPanel), typeof(Transform), typeof(Bounds), typeof(bool)))
			{
				UIPanel uIPanel2 = (UIPanel)ToLua.ToObject(L, 1);
				Transform target2 = (Transform)ToLua.ToObject(L, 2);
				Bounds bound = ToLua.ToBounds(L, 3);
				bool immediate2 = LuaDLL.lua_toboolean(L, 4);
				bool value2 = uIPanel2.ConstrainTargetToBounds(target2, ref bound, immediate2);
				LuaDLL.lua_pushboolean(L, value2);
				ToLua.Push(L, bound);
				result = 2;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UIPanel.ConstrainTargetToBounds");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Find(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(Transform)))
			{
				Transform trans = (Transform)ToLua.ToObject(L, 1);
				UIPanel obj = UIPanel.Find(trans);
				ToLua.Push(L, obj);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Transform), typeof(bool)))
			{
				Transform trans2 = (Transform)ToLua.ToObject(L, 1);
				bool createIfMissing = LuaDLL.lua_toboolean(L, 2);
				UIPanel obj2 = UIPanel.Find(trans2, createIfMissing);
				ToLua.Push(L, obj2);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Transform), typeof(bool), typeof(int)))
			{
				Transform trans3 = (Transform)ToLua.ToObject(L, 1);
				bool createIfMissing2 = LuaDLL.lua_toboolean(L, 2);
				int layer = (int)LuaDLL.lua_tonumber(L, 3);
				UIPanel obj3 = UIPanel.Find(trans3, createIfMissing2, layer);
				ToLua.Push(L, obj3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UIPanel.Find");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetWindowSize(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIPanel uIPanel = (UIPanel)ToLua.CheckObject(L, 1, typeof(UIPanel));
			Vector2 windowSize = uIPanel.GetWindowSize();
			ToLua.Push(L, windowSize);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetViewSize(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIPanel uIPanel = (UIPanel)ToLua.CheckObject(L, 1, typeof(UIPanel));
			Vector2 viewSize = uIPanel.GetViewSize();
			ToLua.Push(L, viewSize);
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
	private static int get_list(IntPtr L)
	{
		int result;
		try
		{
			ToLua.PushObject(L, UIPanel.list);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onGeometryUpdated(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			UIPanel.OnGeometryUpdated onGeometryUpdated = uIPanel.onGeometryUpdated;
			ToLua.Push(L, onGeometryUpdated);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onGeometryUpdated on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_showInPanelTool(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			bool showInPanelTool = uIPanel.showInPanelTool;
			LuaDLL.lua_pushboolean(L, showInPanelTool);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index showInPanelTool on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_generateNormals(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			bool generateNormals = uIPanel.generateNormals;
			LuaDLL.lua_pushboolean(L, generateNormals);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index generateNormals on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_widgetsAreStatic(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			bool widgetsAreStatic = uIPanel.widgetsAreStatic;
			LuaDLL.lua_pushboolean(L, widgetsAreStatic);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index widgetsAreStatic on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_cullWhileDragging(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			bool cullWhileDragging = uIPanel.cullWhileDragging;
			LuaDLL.lua_pushboolean(L, cullWhileDragging);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cullWhileDragging on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_alwaysOnScreen(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			bool alwaysOnScreen = uIPanel.alwaysOnScreen;
			LuaDLL.lua_pushboolean(L, alwaysOnScreen);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index alwaysOnScreen on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_anchorOffset(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			bool anchorOffset = uIPanel.anchorOffset;
			LuaDLL.lua_pushboolean(L, anchorOffset);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index anchorOffset on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_softBorderPadding(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			bool softBorderPadding = uIPanel.softBorderPadding;
			LuaDLL.lua_pushboolean(L, softBorderPadding);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index softBorderPadding on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_renderQueue(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			UIPanel.RenderQueue renderQueue = uIPanel.renderQueue;
			ToLua.Push(L, renderQueue);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index renderQueue on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_startingRenderQueue(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			int startingRenderQueue = uIPanel.startingRenderQueue;
			LuaDLL.lua_pushinteger(L, startingRenderQueue);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index startingRenderQueue on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_widgets(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			List<UIWidget> widgets = uIPanel.widgets;
			ToLua.PushObject(L, widgets);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index widgets on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_drawCalls(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			List<UIDrawCall> drawCalls = uIPanel.drawCalls;
			ToLua.PushObject(L, drawCalls);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index drawCalls on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_worldToLocal(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			Matrix4x4 worldToLocal = uIPanel.worldToLocal;
			ToLua.PushValue(L, worldToLocal);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index worldToLocal on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_drawCallClipRange(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			Vector4 drawCallClipRange = uIPanel.drawCallClipRange;
			ToLua.Push(L, drawCallClipRange);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index drawCallClipRange on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onClipMove(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			UIPanel.OnClippingMoved onClipMove = uIPanel.onClipMove;
			ToLua.Push(L, onClipMove);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onClipMove on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_sortingLayerName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			string sortingLayerName = uIPanel.sortingLayerName;
			LuaDLL.lua_pushstring(L, sortingLayerName);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index sortingLayerName on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_nextUnusedDepth(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, UIPanel.nextUnusedDepth);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
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
			UIPanel uIPanel = (UIPanel)obj;
			bool canBeAnchored = uIPanel.canBeAnchored;
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
	private static int get_alpha(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			float alpha = uIPanel.alpha;
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
	private static int get_depth(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			int depth = uIPanel.depth;
			LuaDLL.lua_pushinteger(L, depth);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index depth on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_sortingOrder(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			int sortingOrder = uIPanel.sortingOrder;
			LuaDLL.lua_pushinteger(L, sortingOrder);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index sortingOrder on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_width(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			float width = uIPanel.width;
			LuaDLL.lua_pushnumber(L, (double)width);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index width on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_height(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			float height = uIPanel.height;
			LuaDLL.lua_pushnumber(L, (double)height);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index height on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_halfPixelOffset(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			bool halfPixelOffset = uIPanel.halfPixelOffset;
			LuaDLL.lua_pushboolean(L, halfPixelOffset);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index halfPixelOffset on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_usedForUI(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			bool usedForUI = uIPanel.usedForUI;
			LuaDLL.lua_pushboolean(L, usedForUI);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index usedForUI on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_drawCallOffset(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			Vector3 drawCallOffset = uIPanel.drawCallOffset;
			ToLua.Push(L, drawCallOffset);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index drawCallOffset on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_clipping(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			UIDrawCall.Clipping clipping = uIPanel.clipping;
			ToLua.Push(L, clipping);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index clipping on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_parentPanel(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			UIPanel parentPanel = uIPanel.parentPanel;
			ToLua.Push(L, parentPanel);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index parentPanel on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_clipCount(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			int clipCount = uIPanel.clipCount;
			LuaDLL.lua_pushinteger(L, clipCount);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index clipCount on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_hasClipping(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			bool hasClipping = uIPanel.hasClipping;
			LuaDLL.lua_pushboolean(L, hasClipping);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index hasClipping on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_hasCumulativeClipping(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			bool hasCumulativeClipping = uIPanel.hasCumulativeClipping;
			LuaDLL.lua_pushboolean(L, hasCumulativeClipping);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index hasCumulativeClipping on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_clipOffset(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			Vector2 clipOffset = uIPanel.clipOffset;
			ToLua.Push(L, clipOffset);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index clipOffset on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_clipTexture(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			Texture2D clipTexture = uIPanel.clipTexture;
			ToLua.Push(L, clipTexture);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index clipTexture on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_baseClipRegion(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			Vector4 baseClipRegion = uIPanel.baseClipRegion;
			ToLua.Push(L, baseClipRegion);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index baseClipRegion on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_finalClipRegion(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			Vector4 finalClipRegion = uIPanel.finalClipRegion;
			ToLua.Push(L, finalClipRegion);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index finalClipRegion on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_clipSoftness(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			Vector2 clipSoftness = uIPanel.clipSoftness;
			ToLua.Push(L, clipSoftness);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index clipSoftness on a nil value");
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
			UIPanel uIPanel = (UIPanel)obj;
			Vector3[] localCorners = uIPanel.localCorners;
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
			UIPanel uIPanel = (UIPanel)obj;
			Vector3[] worldCorners = uIPanel.worldCorners;
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
	private static int set_list(IntPtr L)
	{
		int result;
		try
		{
			List<UIPanel> list = (List<UIPanel>)ToLua.CheckObject(L, 2, typeof(List<UIPanel>));
			UIPanel.list = list;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onGeometryUpdated(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UIPanel.OnGeometryUpdated onGeometryUpdated;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onGeometryUpdated = (UIPanel.OnGeometryUpdated)ToLua.CheckObject(L, 2, typeof(UIPanel.OnGeometryUpdated));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onGeometryUpdated = (DelegateFactory.CreateDelegate(typeof(UIPanel.OnGeometryUpdated), func) as UIPanel.OnGeometryUpdated);
			}
			uIPanel.onGeometryUpdated = onGeometryUpdated;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onGeometryUpdated on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_showInPanelTool(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			bool showInPanelTool = LuaDLL.luaL_checkboolean(L, 2);
			uIPanel.showInPanelTool = showInPanelTool;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index showInPanelTool on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_generateNormals(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			bool generateNormals = LuaDLL.luaL_checkboolean(L, 2);
			uIPanel.generateNormals = generateNormals;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index generateNormals on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_widgetsAreStatic(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			bool widgetsAreStatic = LuaDLL.luaL_checkboolean(L, 2);
			uIPanel.widgetsAreStatic = widgetsAreStatic;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index widgetsAreStatic on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_cullWhileDragging(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			bool cullWhileDragging = LuaDLL.luaL_checkboolean(L, 2);
			uIPanel.cullWhileDragging = cullWhileDragging;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cullWhileDragging on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_alwaysOnScreen(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			bool alwaysOnScreen = LuaDLL.luaL_checkboolean(L, 2);
			uIPanel.alwaysOnScreen = alwaysOnScreen;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index alwaysOnScreen on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_anchorOffset(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			bool anchorOffset = LuaDLL.luaL_checkboolean(L, 2);
			uIPanel.anchorOffset = anchorOffset;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index anchorOffset on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_softBorderPadding(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			bool softBorderPadding = LuaDLL.luaL_checkboolean(L, 2);
			uIPanel.softBorderPadding = softBorderPadding;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index softBorderPadding on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_renderQueue(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			UIPanel.RenderQueue renderQueue = (UIPanel.RenderQueue)LuaDLL.luaL_checknumber(L, 2);
			uIPanel.renderQueue = renderQueue;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index renderQueue on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_startingRenderQueue(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			int startingRenderQueue = (int)LuaDLL.luaL_checknumber(L, 2);
			uIPanel.startingRenderQueue = startingRenderQueue;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index startingRenderQueue on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_widgets(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			List<UIWidget> widgets = (List<UIWidget>)ToLua.CheckObject(L, 2, typeof(List<UIWidget>));
			uIPanel.widgets = widgets;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index widgets on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_drawCalls(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			List<UIDrawCall> drawCalls = (List<UIDrawCall>)ToLua.CheckObject(L, 2, typeof(List<UIDrawCall>));
			uIPanel.drawCalls = drawCalls;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index drawCalls on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_worldToLocal(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			Matrix4x4 worldToLocal = (Matrix4x4)ToLua.CheckObject(L, 2, typeof(Matrix4x4));
			uIPanel.worldToLocal = worldToLocal;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index worldToLocal on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_drawCallClipRange(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			Vector4 drawCallClipRange = ToLua.ToVector4(L, 2);
			uIPanel.drawCallClipRange = drawCallClipRange;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index drawCallClipRange on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onClipMove(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UIPanel.OnClippingMoved onClipMove;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onClipMove = (UIPanel.OnClippingMoved)ToLua.CheckObject(L, 2, typeof(UIPanel.OnClippingMoved));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onClipMove = (DelegateFactory.CreateDelegate(typeof(UIPanel.OnClippingMoved), func) as UIPanel.OnClippingMoved);
			}
			uIPanel.onClipMove = onClipMove;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onClipMove on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_sortingLayerName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			string sortingLayerName = ToLua.CheckString(L, 2);
			uIPanel.sortingLayerName = sortingLayerName;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index sortingLayerName on a nil value");
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
			UIPanel uIPanel = (UIPanel)obj;
			float alpha = (float)LuaDLL.luaL_checknumber(L, 2);
			uIPanel.alpha = alpha;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index alpha on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_depth(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			int depth = (int)LuaDLL.luaL_checknumber(L, 2);
			uIPanel.depth = depth;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index depth on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_sortingOrder(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			int sortingOrder = (int)LuaDLL.luaL_checknumber(L, 2);
			uIPanel.sortingOrder = sortingOrder;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index sortingOrder on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_clipping(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			UIDrawCall.Clipping clipping = (UIDrawCall.Clipping)LuaDLL.luaL_checknumber(L, 2);
			uIPanel.clipping = clipping;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index clipping on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_clipOffset(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			Vector2 clipOffset = ToLua.ToVector2(L, 2);
			uIPanel.clipOffset = clipOffset;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index clipOffset on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_clipTexture(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			Texture2D clipTexture = (Texture2D)ToLua.CheckUnityObject(L, 2, typeof(Texture2D));
			uIPanel.clipTexture = clipTexture;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index clipTexture on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_baseClipRegion(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			Vector4 baseClipRegion = ToLua.ToVector4(L, 2);
			uIPanel.baseClipRegion = baseClipRegion;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index baseClipRegion on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_clipSoftness(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPanel uIPanel = (UIPanel)obj;
			Vector2 clipSoftness = ToLua.ToVector2(L, 2);
			uIPanel.clipSoftness = clipSoftness;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index clipSoftness on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UIPanel_OnClippingMoved(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UIPanel.OnClippingMoved), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UIPanel.OnClippingMoved), func, self);
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

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UIPanel_OnGeometryUpdated(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UIPanel.OnGeometryUpdated), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UIPanel.OnGeometryUpdated), func, self);
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
