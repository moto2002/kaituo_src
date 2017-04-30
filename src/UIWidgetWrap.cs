using LuaInterface;
using System;
using UnityEngine;

public class UIWidgetWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UIWidget), typeof(UIRect), null);
		L.RegFunction("SetDimensions", new LuaCSFunction(UIWidgetWrap.SetDimensions));
		L.RegFunction("GetSides", new LuaCSFunction(UIWidgetWrap.GetSides));
		L.RegFunction("CalculateFinalAlpha", new LuaCSFunction(UIWidgetWrap.CalculateFinalAlpha));
		L.RegFunction("Invalidate", new LuaCSFunction(UIWidgetWrap.Invalidate));
		L.RegFunction("CalculateCumulativeAlpha", new LuaCSFunction(UIWidgetWrap.CalculateCumulativeAlpha));
		L.RegFunction("SetRect", new LuaCSFunction(UIWidgetWrap.SetRect));
		L.RegFunction("ResizeCollider", new LuaCSFunction(UIWidgetWrap.ResizeCollider));
		L.RegFunction("FullCompareFunc", new LuaCSFunction(UIWidgetWrap.FullCompareFunc));
		L.RegFunction("PanelCompareFunc", new LuaCSFunction(UIWidgetWrap.PanelCompareFunc));
		L.RegFunction("CalculateBounds", new LuaCSFunction(UIWidgetWrap.CalculateBounds));
		L.RegFunction("SetDirty", new LuaCSFunction(UIWidgetWrap.SetDirty));
		L.RegFunction("RemoveFromPanel", new LuaCSFunction(UIWidgetWrap.RemoveFromPanel));
		L.RegFunction("MarkAsChanged", new LuaCSFunction(UIWidgetWrap.MarkAsChanged));
		L.RegFunction("CreatePanel", new LuaCSFunction(UIWidgetWrap.CreatePanel));
		L.RegFunction("CheckLayer", new LuaCSFunction(UIWidgetWrap.CheckLayer));
		L.RegFunction("ParentHasChanged", new LuaCSFunction(UIWidgetWrap.ParentHasChanged));
		L.RegFunction("UpdateVisibility", new LuaCSFunction(UIWidgetWrap.UpdateVisibility));
		L.RegFunction("UpdateTransform", new LuaCSFunction(UIWidgetWrap.UpdateTransform));
		L.RegFunction("UpdateGeometry", new LuaCSFunction(UIWidgetWrap.UpdateGeometry));
		L.RegFunction("WriteToBuffers", new LuaCSFunction(UIWidgetWrap.WriteToBuffers));
		L.RegFunction("MakePixelPerfect", new LuaCSFunction(UIWidgetWrap.MakePixelPerfect));
		L.RegFunction("OnFill", new LuaCSFunction(UIWidgetWrap.OnFill));
		L.RegFunction("__eq", new LuaCSFunction(UIWidgetWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("onDrawCallChange", new LuaCSFunction(UIWidgetWrap.get_onDrawCallChange), new LuaCSFunction(UIWidgetWrap.set_onDrawCallChange));
		L.RegVar("onChange", new LuaCSFunction(UIWidgetWrap.get_onChange), new LuaCSFunction(UIWidgetWrap.set_onChange));
		L.RegVar("onPostFill", new LuaCSFunction(UIWidgetWrap.get_onPostFill), new LuaCSFunction(UIWidgetWrap.set_onPostFill));
		L.RegVar("mOnRender", new LuaCSFunction(UIWidgetWrap.get_mOnRender), new LuaCSFunction(UIWidgetWrap.set_mOnRender));
		L.RegVar("autoResizeBoxCollider", new LuaCSFunction(UIWidgetWrap.get_autoResizeBoxCollider), new LuaCSFunction(UIWidgetWrap.set_autoResizeBoxCollider));
		L.RegVar("hideIfOffScreen", new LuaCSFunction(UIWidgetWrap.get_hideIfOffScreen), new LuaCSFunction(UIWidgetWrap.set_hideIfOffScreen));
		L.RegVar("keepAspectRatio", new LuaCSFunction(UIWidgetWrap.get_keepAspectRatio), new LuaCSFunction(UIWidgetWrap.set_keepAspectRatio));
		L.RegVar("aspectRatio", new LuaCSFunction(UIWidgetWrap.get_aspectRatio), new LuaCSFunction(UIWidgetWrap.set_aspectRatio));
		L.RegVar("hitCheck", new LuaCSFunction(UIWidgetWrap.get_hitCheck), new LuaCSFunction(UIWidgetWrap.set_hitCheck));
		L.RegVar("panel", new LuaCSFunction(UIWidgetWrap.get_panel), new LuaCSFunction(UIWidgetWrap.set_panel));
		L.RegVar("geometry", new LuaCSFunction(UIWidgetWrap.get_geometry), new LuaCSFunction(UIWidgetWrap.set_geometry));
		L.RegVar("fillGeometry", new LuaCSFunction(UIWidgetWrap.get_fillGeometry), new LuaCSFunction(UIWidgetWrap.set_fillGeometry));
		L.RegVar("onRender", new LuaCSFunction(UIWidgetWrap.get_onRender), new LuaCSFunction(UIWidgetWrap.set_onRender));
		L.RegVar("drawCall", new LuaCSFunction(UIWidgetWrap.get_drawCall), new LuaCSFunction(UIWidgetWrap.set_drawCall));
		L.RegVar("drawRegion", new LuaCSFunction(UIWidgetWrap.get_drawRegion), new LuaCSFunction(UIWidgetWrap.set_drawRegion));
		L.RegVar("pivotOffset", new LuaCSFunction(UIWidgetWrap.get_pivotOffset), null);
		L.RegVar("width", new LuaCSFunction(UIWidgetWrap.get_width), new LuaCSFunction(UIWidgetWrap.set_width));
		L.RegVar("height", new LuaCSFunction(UIWidgetWrap.get_height), new LuaCSFunction(UIWidgetWrap.set_height));
		L.RegVar("color", new LuaCSFunction(UIWidgetWrap.get_color), new LuaCSFunction(UIWidgetWrap.set_color));
		L.RegVar("alpha", new LuaCSFunction(UIWidgetWrap.get_alpha), new LuaCSFunction(UIWidgetWrap.set_alpha));
		L.RegVar("isVisible", new LuaCSFunction(UIWidgetWrap.get_isVisible), null);
		L.RegVar("hasVertices", new LuaCSFunction(UIWidgetWrap.get_hasVertices), null);
		L.RegVar("rawPivot", new LuaCSFunction(UIWidgetWrap.get_rawPivot), new LuaCSFunction(UIWidgetWrap.set_rawPivot));
		L.RegVar("pivot", new LuaCSFunction(UIWidgetWrap.get_pivot), new LuaCSFunction(UIWidgetWrap.set_pivot));
		L.RegVar("depth", new LuaCSFunction(UIWidgetWrap.get_depth), new LuaCSFunction(UIWidgetWrap.set_depth));
		L.RegVar("raycastDepth", new LuaCSFunction(UIWidgetWrap.get_raycastDepth), null);
		L.RegVar("localCorners", new LuaCSFunction(UIWidgetWrap.get_localCorners), null);
		L.RegVar("localSize", new LuaCSFunction(UIWidgetWrap.get_localSize), null);
		L.RegVar("localCenter", new LuaCSFunction(UIWidgetWrap.get_localCenter), null);
		L.RegVar("worldCorners", new LuaCSFunction(UIWidgetWrap.get_worldCorners), null);
		L.RegVar("worldBounds", new LuaCSFunction(UIWidgetWrap.get_worldBounds), null);
		L.RegVar("worldCenter", new LuaCSFunction(UIWidgetWrap.get_worldCenter), null);
		L.RegVar("drawingDimensions", new LuaCSFunction(UIWidgetWrap.get_drawingDimensions), null);
		L.RegVar("material", new LuaCSFunction(UIWidgetWrap.get_material), new LuaCSFunction(UIWidgetWrap.set_material));
		L.RegVar("mainTexture", new LuaCSFunction(UIWidgetWrap.get_mainTexture), new LuaCSFunction(UIWidgetWrap.set_mainTexture));
		L.RegVar("shader", new LuaCSFunction(UIWidgetWrap.get_shader), new LuaCSFunction(UIWidgetWrap.set_shader));
		L.RegVar("hasBoxCollider", new LuaCSFunction(UIWidgetWrap.get_hasBoxCollider), null);
		L.RegVar("minWidth", new LuaCSFunction(UIWidgetWrap.get_minWidth), null);
		L.RegVar("minHeight", new LuaCSFunction(UIWidgetWrap.get_minHeight), null);
		L.RegVar("border", new LuaCSFunction(UIWidgetWrap.get_border), new LuaCSFunction(UIWidgetWrap.set_border));
		L.RegFunction("HitCheck", new LuaCSFunction(UIWidgetWrap.UIWidget_HitCheck));
		L.RegFunction("OnPostFillCallback", new LuaCSFunction(UIWidgetWrap.UIWidget_OnPostFillCallback));
		L.RegFunction("OnDimensionsChanged", new LuaCSFunction(UIWidgetWrap.UIWidget_OnDimensionsChanged));
		L.RegFunction("OnDrawCallChange", new LuaCSFunction(UIWidgetWrap.UIWidget_OnDrawCallChange));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetDimensions(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			UIWidget uIWidget = (UIWidget)ToLua.CheckObject(L, 1, typeof(UIWidget));
			int w = (int)LuaDLL.luaL_checknumber(L, 2);
			int h = (int)LuaDLL.luaL_checknumber(L, 3);
			uIWidget.SetDimensions(w, h);
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
			UIWidget uIWidget = (UIWidget)ToLua.CheckObject(L, 1, typeof(UIWidget));
			Transform relativeTo = (Transform)ToLua.CheckUnityObject(L, 2, typeof(Transform));
			Vector3[] sides = uIWidget.GetSides(relativeTo);
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
	private static int CalculateFinalAlpha(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UIWidget uIWidget = (UIWidget)ToLua.CheckObject(L, 1, typeof(UIWidget));
			int frameID = (int)LuaDLL.luaL_checknumber(L, 2);
			float num = uIWidget.CalculateFinalAlpha(frameID);
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
			UIWidget uIWidget = (UIWidget)ToLua.CheckObject(L, 1, typeof(UIWidget));
			bool includeChildren = LuaDLL.luaL_checkboolean(L, 2);
			uIWidget.Invalidate(includeChildren);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CalculateCumulativeAlpha(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UIWidget uIWidget = (UIWidget)ToLua.CheckObject(L, 1, typeof(UIWidget));
			int frameID = (int)LuaDLL.luaL_checknumber(L, 2);
			float num = uIWidget.CalculateCumulativeAlpha(frameID);
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
			UIWidget uIWidget = (UIWidget)ToLua.CheckObject(L, 1, typeof(UIWidget));
			float x = (float)LuaDLL.luaL_checknumber(L, 2);
			float y = (float)LuaDLL.luaL_checknumber(L, 3);
			float width = (float)LuaDLL.luaL_checknumber(L, 4);
			float height = (float)LuaDLL.luaL_checknumber(L, 5);
			uIWidget.SetRect(x, y, width, height);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ResizeCollider(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIWidget uIWidget = (UIWidget)ToLua.CheckObject(L, 1, typeof(UIWidget));
			uIWidget.ResizeCollider();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int FullCompareFunc(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UIWidget left = (UIWidget)ToLua.CheckUnityObject(L, 1, typeof(UIWidget));
			UIWidget right = (UIWidget)ToLua.CheckUnityObject(L, 2, typeof(UIWidget));
			int n = UIWidget.FullCompareFunc(left, right);
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
	private static int PanelCompareFunc(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UIWidget left = (UIWidget)ToLua.CheckUnityObject(L, 1, typeof(UIWidget));
			UIWidget right = (UIWidget)ToLua.CheckUnityObject(L, 2, typeof(UIWidget));
			int n = UIWidget.PanelCompareFunc(left, right);
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
	private static int CalculateBounds(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(UIWidget)))
			{
				UIWidget uIWidget = (UIWidget)ToLua.ToObject(L, 1);
				Bounds bound = uIWidget.CalculateBounds();
				ToLua.Push(L, bound);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(UIWidget), typeof(Transform)))
			{
				UIWidget uIWidget2 = (UIWidget)ToLua.ToObject(L, 1);
				Transform relativeParent = (Transform)ToLua.ToObject(L, 2);
				Bounds bound2 = uIWidget2.CalculateBounds(relativeParent);
				ToLua.Push(L, bound2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UIWidget.CalculateBounds");
			}
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
			UIWidget uIWidget = (UIWidget)ToLua.CheckObject(L, 1, typeof(UIWidget));
			uIWidget.SetDirty();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RemoveFromPanel(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIWidget uIWidget = (UIWidget)ToLua.CheckObject(L, 1, typeof(UIWidget));
			uIWidget.RemoveFromPanel();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int MarkAsChanged(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIWidget uIWidget = (UIWidget)ToLua.CheckObject(L, 1, typeof(UIWidget));
			uIWidget.MarkAsChanged();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CreatePanel(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIWidget uIWidget = (UIWidget)ToLua.CheckObject(L, 1, typeof(UIWidget));
			UIPanel obj = uIWidget.CreatePanel();
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
	private static int CheckLayer(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIWidget uIWidget = (UIWidget)ToLua.CheckObject(L, 1, typeof(UIWidget));
			uIWidget.CheckLayer();
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
			UIWidget uIWidget = (UIWidget)ToLua.CheckObject(L, 1, typeof(UIWidget));
			uIWidget.ParentHasChanged();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UpdateVisibility(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			UIWidget uIWidget = (UIWidget)ToLua.CheckObject(L, 1, typeof(UIWidget));
			bool visibleByAlpha = LuaDLL.luaL_checkboolean(L, 2);
			bool visibleByPanel = LuaDLL.luaL_checkboolean(L, 3);
			bool value = uIWidget.UpdateVisibility(visibleByAlpha, visibleByPanel);
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
	private static int UpdateTransform(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UIWidget uIWidget = (UIWidget)ToLua.CheckObject(L, 1, typeof(UIWidget));
			int frame = (int)LuaDLL.luaL_checknumber(L, 2);
			bool value = uIWidget.UpdateTransform(frame);
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
	private static int UpdateGeometry(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UIWidget uIWidget = (UIWidget)ToLua.CheckObject(L, 1, typeof(UIWidget));
			int frame = (int)LuaDLL.luaL_checknumber(L, 2);
			bool value = uIWidget.UpdateGeometry(frame);
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
	private static int WriteToBuffers(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 6);
			UIWidget uIWidget = (UIWidget)ToLua.CheckObject(L, 1, typeof(UIWidget));
			BetterList<Vector3> v = (BetterList<Vector3>)ToLua.CheckObject(L, 2, typeof(BetterList<Vector3>));
			BetterList<Vector2> u = (BetterList<Vector2>)ToLua.CheckObject(L, 3, typeof(BetterList<Vector2>));
			BetterList<Color> c = (BetterList<Color>)ToLua.CheckObject(L, 4, typeof(BetterList<Color>));
			BetterList<Vector3> n = (BetterList<Vector3>)ToLua.CheckObject(L, 5, typeof(BetterList<Vector3>));
			BetterList<Vector4> t = (BetterList<Vector4>)ToLua.CheckObject(L, 6, typeof(BetterList<Vector4>));
			uIWidget.WriteToBuffers(v, u, c, n, t);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int MakePixelPerfect(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIWidget uIWidget = (UIWidget)ToLua.CheckObject(L, 1, typeof(UIWidget));
			uIWidget.MakePixelPerfect();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnFill(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			UIWidget uIWidget = (UIWidget)ToLua.CheckObject(L, 1, typeof(UIWidget));
			BetterList<Vector3> verts = (BetterList<Vector3>)ToLua.CheckObject(L, 2, typeof(BetterList<Vector3>));
			BetterList<Vector2> uvs = (BetterList<Vector2>)ToLua.CheckObject(L, 3, typeof(BetterList<Vector2>));
			BetterList<Color> cols = (BetterList<Color>)ToLua.CheckObject(L, 4, typeof(BetterList<Color>));
			uIWidget.OnFill(verts, uvs, cols);
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
	private static int get_onDrawCallChange(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			UIWidget.OnDrawCallChange onDrawCallChange = uIWidget.onDrawCallChange;
			ToLua.Push(L, onDrawCallChange);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onDrawCallChange on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onChange(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			UIWidget.OnDimensionsChanged onChange = uIWidget.onChange;
			ToLua.Push(L, onChange);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onChange on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onPostFill(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			UIWidget.OnPostFillCallback onPostFill = uIWidget.onPostFill;
			ToLua.Push(L, onPostFill);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onPostFill on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_mOnRender(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			UIDrawCall.OnRenderCallback mOnRender = uIWidget.mOnRender;
			ToLua.Push(L, mOnRender);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index mOnRender on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_autoResizeBoxCollider(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			bool autoResizeBoxCollider = uIWidget.autoResizeBoxCollider;
			LuaDLL.lua_pushboolean(L, autoResizeBoxCollider);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index autoResizeBoxCollider on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_hideIfOffScreen(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			bool hideIfOffScreen = uIWidget.hideIfOffScreen;
			LuaDLL.lua_pushboolean(L, hideIfOffScreen);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index hideIfOffScreen on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_keepAspectRatio(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			UIWidget.AspectRatioSource keepAspectRatio = uIWidget.keepAspectRatio;
			ToLua.Push(L, keepAspectRatio);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index keepAspectRatio on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_aspectRatio(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			float aspectRatio = uIWidget.aspectRatio;
			LuaDLL.lua_pushnumber(L, (double)aspectRatio);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index aspectRatio on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_hitCheck(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			UIWidget.HitCheck hitCheck = uIWidget.hitCheck;
			ToLua.Push(L, hitCheck);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index hitCheck on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_panel(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			UIPanel panel = uIWidget.panel;
			ToLua.Push(L, panel);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index panel on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_geometry(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			UIGeometry geometry = uIWidget.geometry;
			ToLua.PushObject(L, geometry);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index geometry on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_fillGeometry(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			bool fillGeometry = uIWidget.fillGeometry;
			LuaDLL.lua_pushboolean(L, fillGeometry);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index fillGeometry on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onRender(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			UIDrawCall.OnRenderCallback onRender = uIWidget.onRender;
			ToLua.Push(L, onRender);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onRender on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_drawCall(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			UIDrawCall drawCall = uIWidget.drawCall;
			ToLua.Push(L, drawCall);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index drawCall on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_drawRegion(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			Vector4 drawRegion = uIWidget.drawRegion;
			ToLua.Push(L, drawRegion);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index drawRegion on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_pivotOffset(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			Vector2 pivotOffset = uIWidget.pivotOffset;
			ToLua.Push(L, pivotOffset);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pivotOffset on a nil value");
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
			UIWidget uIWidget = (UIWidget)obj;
			int width = uIWidget.width;
			LuaDLL.lua_pushinteger(L, width);
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
			UIWidget uIWidget = (UIWidget)obj;
			int height = uIWidget.height;
			LuaDLL.lua_pushinteger(L, height);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index height on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_color(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			Color color = uIWidget.color;
			ToLua.Push(L, color);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index color on a nil value");
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
			UIWidget uIWidget = (UIWidget)obj;
			float alpha = uIWidget.alpha;
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
	private static int get_isVisible(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			bool isVisible = uIWidget.isVisible;
			LuaDLL.lua_pushboolean(L, isVisible);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isVisible on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_hasVertices(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			bool hasVertices = uIWidget.hasVertices;
			LuaDLL.lua_pushboolean(L, hasVertices);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index hasVertices on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_rawPivot(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			UIWidget.Pivot rawPivot = uIWidget.rawPivot;
			ToLua.Push(L, rawPivot);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index rawPivot on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_pivot(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			UIWidget.Pivot pivot = uIWidget.pivot;
			ToLua.Push(L, pivot);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pivot on a nil value");
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
			UIWidget uIWidget = (UIWidget)obj;
			int depth = uIWidget.depth;
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
	private static int get_raycastDepth(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			int raycastDepth = uIWidget.raycastDepth;
			LuaDLL.lua_pushinteger(L, raycastDepth);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index raycastDepth on a nil value");
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
			UIWidget uIWidget = (UIWidget)obj;
			Vector3[] localCorners = uIWidget.localCorners;
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
	private static int get_localSize(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			Vector2 localSize = uIWidget.localSize;
			ToLua.Push(L, localSize);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index localSize on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_localCenter(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			Vector3 localCenter = uIWidget.localCenter;
			ToLua.Push(L, localCenter);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index localCenter on a nil value");
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
			UIWidget uIWidget = (UIWidget)obj;
			Vector3[] worldCorners = uIWidget.worldCorners;
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
	private static int get_worldBounds(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			Vector3[] worldBounds = uIWidget.worldBounds;
			ToLua.Push(L, worldBounds);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index worldBounds on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_worldCenter(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			Vector3 worldCenter = uIWidget.worldCenter;
			ToLua.Push(L, worldCenter);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index worldCenter on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_drawingDimensions(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			Vector4 drawingDimensions = uIWidget.drawingDimensions;
			ToLua.Push(L, drawingDimensions);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index drawingDimensions on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_material(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			Material material = uIWidget.material;
			ToLua.Push(L, material);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index material on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_mainTexture(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			Texture mainTexture = uIWidget.mainTexture;
			ToLua.Push(L, mainTexture);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index mainTexture on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_shader(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			Shader shader = uIWidget.shader;
			ToLua.Push(L, shader);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index shader on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_hasBoxCollider(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			bool hasBoxCollider = uIWidget.hasBoxCollider;
			LuaDLL.lua_pushboolean(L, hasBoxCollider);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index hasBoxCollider on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_minWidth(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			int minWidth = uIWidget.minWidth;
			LuaDLL.lua_pushinteger(L, minWidth);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index minWidth on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_minHeight(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			int minHeight = uIWidget.minHeight;
			LuaDLL.lua_pushinteger(L, minHeight);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index minHeight on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_border(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			Vector4 border = uIWidget.border;
			ToLua.Push(L, border);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index border on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onDrawCallChange(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UIWidget.OnDrawCallChange onDrawCallChange;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onDrawCallChange = (UIWidget.OnDrawCallChange)ToLua.CheckObject(L, 2, typeof(UIWidget.OnDrawCallChange));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onDrawCallChange = (DelegateFactory.CreateDelegate(typeof(UIWidget.OnDrawCallChange), func) as UIWidget.OnDrawCallChange);
			}
			uIWidget.onDrawCallChange = onDrawCallChange;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onDrawCallChange on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onChange(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UIWidget.OnDimensionsChanged onChange;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onChange = (UIWidget.OnDimensionsChanged)ToLua.CheckObject(L, 2, typeof(UIWidget.OnDimensionsChanged));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onChange = (DelegateFactory.CreateDelegate(typeof(UIWidget.OnDimensionsChanged), func) as UIWidget.OnDimensionsChanged);
			}
			uIWidget.onChange = onChange;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onChange on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onPostFill(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UIWidget.OnPostFillCallback onPostFill;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onPostFill = (UIWidget.OnPostFillCallback)ToLua.CheckObject(L, 2, typeof(UIWidget.OnPostFillCallback));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onPostFill = (DelegateFactory.CreateDelegate(typeof(UIWidget.OnPostFillCallback), func) as UIWidget.OnPostFillCallback);
			}
			uIWidget.onPostFill = onPostFill;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onPostFill on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_mOnRender(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UIDrawCall.OnRenderCallback mOnRender;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				mOnRender = (UIDrawCall.OnRenderCallback)ToLua.CheckObject(L, 2, typeof(UIDrawCall.OnRenderCallback));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				mOnRender = (DelegateFactory.CreateDelegate(typeof(UIDrawCall.OnRenderCallback), func) as UIDrawCall.OnRenderCallback);
			}
			uIWidget.mOnRender = mOnRender;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index mOnRender on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_autoResizeBoxCollider(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			bool autoResizeBoxCollider = LuaDLL.luaL_checkboolean(L, 2);
			uIWidget.autoResizeBoxCollider = autoResizeBoxCollider;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index autoResizeBoxCollider on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_hideIfOffScreen(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			bool hideIfOffScreen = LuaDLL.luaL_checkboolean(L, 2);
			uIWidget.hideIfOffScreen = hideIfOffScreen;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index hideIfOffScreen on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_keepAspectRatio(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			UIWidget.AspectRatioSource keepAspectRatio = (UIWidget.AspectRatioSource)LuaDLL.luaL_checknumber(L, 2);
			uIWidget.keepAspectRatio = keepAspectRatio;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index keepAspectRatio on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_aspectRatio(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			float aspectRatio = (float)LuaDLL.luaL_checknumber(L, 2);
			uIWidget.aspectRatio = aspectRatio;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index aspectRatio on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_hitCheck(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UIWidget.HitCheck hitCheck;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				hitCheck = (UIWidget.HitCheck)ToLua.CheckObject(L, 2, typeof(UIWidget.HitCheck));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				hitCheck = (DelegateFactory.CreateDelegate(typeof(UIWidget.HitCheck), func) as UIWidget.HitCheck);
			}
			uIWidget.hitCheck = hitCheck;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index hitCheck on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_panel(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			UIPanel panel = (UIPanel)ToLua.CheckUnityObject(L, 2, typeof(UIPanel));
			uIWidget.panel = panel;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index panel on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_geometry(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			UIGeometry geometry = (UIGeometry)ToLua.CheckObject(L, 2, typeof(UIGeometry));
			uIWidget.geometry = geometry;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index geometry on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_fillGeometry(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			bool fillGeometry = LuaDLL.luaL_checkboolean(L, 2);
			uIWidget.fillGeometry = fillGeometry;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index fillGeometry on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onRender(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UIDrawCall.OnRenderCallback onRender;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onRender = (UIDrawCall.OnRenderCallback)ToLua.CheckObject(L, 2, typeof(UIDrawCall.OnRenderCallback));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onRender = (DelegateFactory.CreateDelegate(typeof(UIDrawCall.OnRenderCallback), func) as UIDrawCall.OnRenderCallback);
			}
			uIWidget.onRender = onRender;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onRender on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_drawCall(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			UIDrawCall drawCall = (UIDrawCall)ToLua.CheckUnityObject(L, 2, typeof(UIDrawCall));
			uIWidget.drawCall = drawCall;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index drawCall on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_drawRegion(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			Vector4 drawRegion = ToLua.ToVector4(L, 2);
			uIWidget.drawRegion = drawRegion;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index drawRegion on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_width(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			int width = (int)LuaDLL.luaL_checknumber(L, 2);
			uIWidget.width = width;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index width on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_height(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			int height = (int)LuaDLL.luaL_checknumber(L, 2);
			uIWidget.height = height;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index height on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_color(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			Color color = ToLua.ToColor(L, 2);
			uIWidget.color = color;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index color on a nil value");
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
			UIWidget uIWidget = (UIWidget)obj;
			float alpha = (float)LuaDLL.luaL_checknumber(L, 2);
			uIWidget.alpha = alpha;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index alpha on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_rawPivot(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			UIWidget.Pivot rawPivot = (UIWidget.Pivot)((int)ToLua.CheckObject(L, 2, typeof(UIWidget.Pivot)));
			uIWidget.rawPivot = rawPivot;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index rawPivot on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_pivot(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			UIWidget.Pivot pivot = (UIWidget.Pivot)((int)ToLua.CheckObject(L, 2, typeof(UIWidget.Pivot)));
			uIWidget.pivot = pivot;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pivot on a nil value");
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
			UIWidget uIWidget = (UIWidget)obj;
			int depth = (int)LuaDLL.luaL_checknumber(L, 2);
			uIWidget.depth = depth;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index depth on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_material(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			Material material = (Material)ToLua.CheckUnityObject(L, 2, typeof(Material));
			uIWidget.material = material;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index material on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_mainTexture(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			Texture mainTexture = (Texture)ToLua.CheckUnityObject(L, 2, typeof(Texture));
			uIWidget.mainTexture = mainTexture;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index mainTexture on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_shader(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			Shader shader = (Shader)ToLua.CheckUnityObject(L, 2, typeof(Shader));
			uIWidget.shader = shader;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index shader on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_border(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWidget uIWidget = (UIWidget)obj;
			Vector4 border = ToLua.ToVector4(L, 2);
			uIWidget.border = border;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index border on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UIWidget_HitCheck(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UIWidget.HitCheck), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UIWidget.HitCheck), func, self);
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
	private static int UIWidget_OnPostFillCallback(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UIWidget.OnPostFillCallback), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UIWidget.OnPostFillCallback), func, self);
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
	private static int UIWidget_OnDimensionsChanged(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UIWidget.OnDimensionsChanged), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UIWidget.OnDimensionsChanged), func, self);
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
	private static int UIWidget_OnDrawCallChange(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UIWidget.OnDrawCallChange), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UIWidget.OnDrawCallChange), func, self);
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
