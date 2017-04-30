using LuaInterface;
using System;
using UnityEngine;

public class UIDrawCallWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UIDrawCall), typeof(MonoBehaviour), null);
		L.RegFunction("UpdateGeometry", new LuaCSFunction(UIDrawCallWrap.UpdateGeometry));
		L.RegFunction("Create", new LuaCSFunction(UIDrawCallWrap.Create));
		L.RegFunction("ClearAll", new LuaCSFunction(UIDrawCallWrap.ClearAll));
		L.RegFunction("ReleaseAll", new LuaCSFunction(UIDrawCallWrap.ReleaseAll));
		L.RegFunction("ReleaseInactive", new LuaCSFunction(UIDrawCallWrap.ReleaseInactive));
		L.RegFunction("Count", new LuaCSFunction(UIDrawCallWrap.Count));
		L.RegFunction("Destroy", new LuaCSFunction(UIDrawCallWrap.Destroy));
		L.RegFunction("__eq", new LuaCSFunction(UIDrawCallWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("widgetCount", new LuaCSFunction(UIDrawCallWrap.get_widgetCount), new LuaCSFunction(UIDrawCallWrap.set_widgetCount));
		L.RegVar("depthStart", new LuaCSFunction(UIDrawCallWrap.get_depthStart), new LuaCSFunction(UIDrawCallWrap.set_depthStart));
		L.RegVar("depthEnd", new LuaCSFunction(UIDrawCallWrap.get_depthEnd), new LuaCSFunction(UIDrawCallWrap.set_depthEnd));
		L.RegVar("manager", new LuaCSFunction(UIDrawCallWrap.get_manager), new LuaCSFunction(UIDrawCallWrap.set_manager));
		L.RegVar("panel", new LuaCSFunction(UIDrawCallWrap.get_panel), new LuaCSFunction(UIDrawCallWrap.set_panel));
		L.RegVar("clipTexture", new LuaCSFunction(UIDrawCallWrap.get_clipTexture), new LuaCSFunction(UIDrawCallWrap.set_clipTexture));
		L.RegVar("alwaysOnScreen", new LuaCSFunction(UIDrawCallWrap.get_alwaysOnScreen), new LuaCSFunction(UIDrawCallWrap.set_alwaysOnScreen));
		L.RegVar("verts", new LuaCSFunction(UIDrawCallWrap.get_verts), new LuaCSFunction(UIDrawCallWrap.set_verts));
		L.RegVar("norms", new LuaCSFunction(UIDrawCallWrap.get_norms), new LuaCSFunction(UIDrawCallWrap.set_norms));
		L.RegVar("tans", new LuaCSFunction(UIDrawCallWrap.get_tans), new LuaCSFunction(UIDrawCallWrap.set_tans));
		L.RegVar("uvs", new LuaCSFunction(UIDrawCallWrap.get_uvs), new LuaCSFunction(UIDrawCallWrap.set_uvs));
		L.RegVar("cols", new LuaCSFunction(UIDrawCallWrap.get_cols), new LuaCSFunction(UIDrawCallWrap.set_cols));
		L.RegVar("isDirty", new LuaCSFunction(UIDrawCallWrap.get_isDirty), new LuaCSFunction(UIDrawCallWrap.set_isDirty));
		L.RegVar("onRenderQueueChange", new LuaCSFunction(UIDrawCallWrap.get_onRenderQueueChange), new LuaCSFunction(UIDrawCallWrap.set_onRenderQueueChange));
		L.RegVar("onRender", new LuaCSFunction(UIDrawCallWrap.get_onRender), new LuaCSFunction(UIDrawCallWrap.set_onRender));
		L.RegVar("activeList", new LuaCSFunction(UIDrawCallWrap.get_activeList), null);
		L.RegVar("inactiveList", new LuaCSFunction(UIDrawCallWrap.get_inactiveList), null);
		L.RegVar("renderQueue", new LuaCSFunction(UIDrawCallWrap.get_renderQueue), new LuaCSFunction(UIDrawCallWrap.set_renderQueue));
		L.RegVar("sortingOrder", new LuaCSFunction(UIDrawCallWrap.get_sortingOrder), new LuaCSFunction(UIDrawCallWrap.set_sortingOrder));
		L.RegVar("sortingLayerName", new LuaCSFunction(UIDrawCallWrap.get_sortingLayerName), new LuaCSFunction(UIDrawCallWrap.set_sortingLayerName));
		L.RegVar("finalRenderQueue", new LuaCSFunction(UIDrawCallWrap.get_finalRenderQueue), null);
		L.RegVar("cachedTransform", new LuaCSFunction(UIDrawCallWrap.get_cachedTransform), null);
		L.RegVar("baseMaterial", new LuaCSFunction(UIDrawCallWrap.get_baseMaterial), new LuaCSFunction(UIDrawCallWrap.set_baseMaterial));
		L.RegVar("dynamicMaterial", new LuaCSFunction(UIDrawCallWrap.get_dynamicMaterial), null);
		L.RegVar("mainTexture", new LuaCSFunction(UIDrawCallWrap.get_mainTexture), new LuaCSFunction(UIDrawCallWrap.set_mainTexture));
		L.RegVar("shader", new LuaCSFunction(UIDrawCallWrap.get_shader), new LuaCSFunction(UIDrawCallWrap.set_shader));
		L.RegVar("triangles", new LuaCSFunction(UIDrawCallWrap.get_triangles), null);
		L.RegVar("isClipped", new LuaCSFunction(UIDrawCallWrap.get_isClipped), null);
		L.RegFunction("OnRenderCallback", new LuaCSFunction(UIDrawCallWrap.UIDrawCall_OnRenderCallback));
		L.RegFunction("OnRenderQueueChange", new LuaCSFunction(UIDrawCallWrap.UIDrawCall_OnRenderQueueChange));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UpdateGeometry(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UIDrawCall uIDrawCall = (UIDrawCall)ToLua.CheckObject(L, 1, typeof(UIDrawCall));
			int widgetCount = (int)LuaDLL.luaL_checknumber(L, 2);
			uIDrawCall.UpdateGeometry(widgetCount);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Create(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			UIPanel panel = (UIPanel)ToLua.CheckUnityObject(L, 1, typeof(UIPanel));
			Material mat = (Material)ToLua.CheckUnityObject(L, 2, typeof(Material));
			Texture tex = (Texture)ToLua.CheckUnityObject(L, 3, typeof(Texture));
			Shader shader = (Shader)ToLua.CheckUnityObject(L, 4, typeof(Shader));
			UIDrawCall obj = UIDrawCall.Create(panel, mat, tex, shader);
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
	private static int ClearAll(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			UIDrawCall.ClearAll();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ReleaseAll(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			UIDrawCall.ReleaseAll();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ReleaseInactive(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			UIDrawCall.ReleaseInactive();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Count(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIPanel panel = (UIPanel)ToLua.CheckUnityObject(L, 1, typeof(UIPanel));
			int n = UIDrawCall.Count(panel);
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
	private static int Destroy(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIDrawCall dc = (UIDrawCall)ToLua.CheckUnityObject(L, 1, typeof(UIDrawCall));
			UIDrawCall.Destroy(dc);
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
	private static int get_widgetCount(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDrawCall uIDrawCall = (UIDrawCall)obj;
			int widgetCount = uIDrawCall.widgetCount;
			LuaDLL.lua_pushinteger(L, widgetCount);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index widgetCount on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_depthStart(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDrawCall uIDrawCall = (UIDrawCall)obj;
			int depthStart = uIDrawCall.depthStart;
			LuaDLL.lua_pushinteger(L, depthStart);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index depthStart on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_depthEnd(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDrawCall uIDrawCall = (UIDrawCall)obj;
			int depthEnd = uIDrawCall.depthEnd;
			LuaDLL.lua_pushinteger(L, depthEnd);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index depthEnd on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_manager(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDrawCall uIDrawCall = (UIDrawCall)obj;
			UIPanel manager = uIDrawCall.manager;
			ToLua.Push(L, manager);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index manager on a nil value");
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
			UIDrawCall uIDrawCall = (UIDrawCall)obj;
			UIPanel panel = uIDrawCall.panel;
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
	private static int get_clipTexture(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDrawCall uIDrawCall = (UIDrawCall)obj;
			Texture2D clipTexture = uIDrawCall.clipTexture;
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
	private static int get_alwaysOnScreen(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDrawCall uIDrawCall = (UIDrawCall)obj;
			bool alwaysOnScreen = uIDrawCall.alwaysOnScreen;
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
	private static int get_verts(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDrawCall uIDrawCall = (UIDrawCall)obj;
			BetterList<Vector3> verts = uIDrawCall.verts;
			ToLua.PushObject(L, verts);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index verts on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_norms(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDrawCall uIDrawCall = (UIDrawCall)obj;
			BetterList<Vector3> norms = uIDrawCall.norms;
			ToLua.PushObject(L, norms);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index norms on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_tans(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDrawCall uIDrawCall = (UIDrawCall)obj;
			BetterList<Vector4> tans = uIDrawCall.tans;
			ToLua.PushObject(L, tans);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index tans on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_uvs(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDrawCall uIDrawCall = (UIDrawCall)obj;
			BetterList<Vector2> uvs = uIDrawCall.uvs;
			ToLua.PushObject(L, uvs);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index uvs on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_cols(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDrawCall uIDrawCall = (UIDrawCall)obj;
			BetterList<Color> cols = uIDrawCall.cols;
			ToLua.PushObject(L, cols);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cols on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isDirty(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDrawCall uIDrawCall = (UIDrawCall)obj;
			bool isDirty = uIDrawCall.isDirty;
			LuaDLL.lua_pushboolean(L, isDirty);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isDirty on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onRenderQueueChange(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDrawCall uIDrawCall = (UIDrawCall)obj;
			UIDrawCall.OnRenderQueueChange onRenderQueueChange = uIDrawCall.onRenderQueueChange;
			ToLua.Push(L, onRenderQueueChange);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onRenderQueueChange on a nil value");
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
			UIDrawCall uIDrawCall = (UIDrawCall)obj;
			UIDrawCall.OnRenderCallback onRender = uIDrawCall.onRender;
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
	private static int get_activeList(IntPtr L)
	{
		int result;
		try
		{
			ToLua.PushObject(L, UIDrawCall.activeList);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_inactiveList(IntPtr L)
	{
		int result;
		try
		{
			ToLua.PushObject(L, UIDrawCall.inactiveList);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
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
			UIDrawCall uIDrawCall = (UIDrawCall)obj;
			int renderQueue = uIDrawCall.renderQueue;
			LuaDLL.lua_pushinteger(L, renderQueue);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index renderQueue on a nil value");
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
			UIDrawCall uIDrawCall = (UIDrawCall)obj;
			int sortingOrder = uIDrawCall.sortingOrder;
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
	private static int get_sortingLayerName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDrawCall uIDrawCall = (UIDrawCall)obj;
			string sortingLayerName = uIDrawCall.sortingLayerName;
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
	private static int get_finalRenderQueue(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDrawCall uIDrawCall = (UIDrawCall)obj;
			int finalRenderQueue = uIDrawCall.finalRenderQueue;
			LuaDLL.lua_pushinteger(L, finalRenderQueue);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index finalRenderQueue on a nil value");
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
			UIDrawCall uIDrawCall = (UIDrawCall)obj;
			Transform cachedTransform = uIDrawCall.cachedTransform;
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
	private static int get_baseMaterial(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDrawCall uIDrawCall = (UIDrawCall)obj;
			Material baseMaterial = uIDrawCall.baseMaterial;
			ToLua.Push(L, baseMaterial);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index baseMaterial on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_dynamicMaterial(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDrawCall uIDrawCall = (UIDrawCall)obj;
			Material dynamicMaterial = uIDrawCall.dynamicMaterial;
			ToLua.Push(L, dynamicMaterial);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index dynamicMaterial on a nil value");
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
			UIDrawCall uIDrawCall = (UIDrawCall)obj;
			Texture mainTexture = uIDrawCall.mainTexture;
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
			UIDrawCall uIDrawCall = (UIDrawCall)obj;
			Shader shader = uIDrawCall.shader;
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
	private static int get_triangles(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDrawCall uIDrawCall = (UIDrawCall)obj;
			int triangles = uIDrawCall.triangles;
			LuaDLL.lua_pushinteger(L, triangles);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index triangles on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isClipped(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDrawCall uIDrawCall = (UIDrawCall)obj;
			bool isClipped = uIDrawCall.isClipped;
			LuaDLL.lua_pushboolean(L, isClipped);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isClipped on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_widgetCount(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDrawCall uIDrawCall = (UIDrawCall)obj;
			int widgetCount = (int)LuaDLL.luaL_checknumber(L, 2);
			uIDrawCall.widgetCount = widgetCount;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index widgetCount on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_depthStart(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDrawCall uIDrawCall = (UIDrawCall)obj;
			int depthStart = (int)LuaDLL.luaL_checknumber(L, 2);
			uIDrawCall.depthStart = depthStart;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index depthStart on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_depthEnd(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDrawCall uIDrawCall = (UIDrawCall)obj;
			int depthEnd = (int)LuaDLL.luaL_checknumber(L, 2);
			uIDrawCall.depthEnd = depthEnd;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index depthEnd on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_manager(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDrawCall uIDrawCall = (UIDrawCall)obj;
			UIPanel manager = (UIPanel)ToLua.CheckUnityObject(L, 2, typeof(UIPanel));
			uIDrawCall.manager = manager;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index manager on a nil value");
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
			UIDrawCall uIDrawCall = (UIDrawCall)obj;
			UIPanel panel = (UIPanel)ToLua.CheckUnityObject(L, 2, typeof(UIPanel));
			uIDrawCall.panel = panel;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index panel on a nil value");
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
			UIDrawCall uIDrawCall = (UIDrawCall)obj;
			Texture2D clipTexture = (Texture2D)ToLua.CheckUnityObject(L, 2, typeof(Texture2D));
			uIDrawCall.clipTexture = clipTexture;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index clipTexture on a nil value");
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
			UIDrawCall uIDrawCall = (UIDrawCall)obj;
			bool alwaysOnScreen = LuaDLL.luaL_checkboolean(L, 2);
			uIDrawCall.alwaysOnScreen = alwaysOnScreen;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index alwaysOnScreen on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_verts(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDrawCall uIDrawCall = (UIDrawCall)obj;
			BetterList<Vector3> verts = (BetterList<Vector3>)ToLua.CheckObject(L, 2, typeof(BetterList<Vector3>));
			uIDrawCall.verts = verts;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index verts on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_norms(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDrawCall uIDrawCall = (UIDrawCall)obj;
			BetterList<Vector3> norms = (BetterList<Vector3>)ToLua.CheckObject(L, 2, typeof(BetterList<Vector3>));
			uIDrawCall.norms = norms;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index norms on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_tans(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDrawCall uIDrawCall = (UIDrawCall)obj;
			BetterList<Vector4> tans = (BetterList<Vector4>)ToLua.CheckObject(L, 2, typeof(BetterList<Vector4>));
			uIDrawCall.tans = tans;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index tans on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_uvs(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDrawCall uIDrawCall = (UIDrawCall)obj;
			BetterList<Vector2> uvs = (BetterList<Vector2>)ToLua.CheckObject(L, 2, typeof(BetterList<Vector2>));
			uIDrawCall.uvs = uvs;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index uvs on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_cols(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDrawCall uIDrawCall = (UIDrawCall)obj;
			BetterList<Color> cols = (BetterList<Color>)ToLua.CheckObject(L, 2, typeof(BetterList<Color>));
			uIDrawCall.cols = cols;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cols on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_isDirty(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDrawCall uIDrawCall = (UIDrawCall)obj;
			bool isDirty = LuaDLL.luaL_checkboolean(L, 2);
			uIDrawCall.isDirty = isDirty;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isDirty on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onRenderQueueChange(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDrawCall uIDrawCall = (UIDrawCall)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UIDrawCall.OnRenderQueueChange onRenderQueueChange;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onRenderQueueChange = (UIDrawCall.OnRenderQueueChange)ToLua.CheckObject(L, 2, typeof(UIDrawCall.OnRenderQueueChange));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onRenderQueueChange = (DelegateFactory.CreateDelegate(typeof(UIDrawCall.OnRenderQueueChange), func) as UIDrawCall.OnRenderQueueChange);
			}
			uIDrawCall.onRenderQueueChange = onRenderQueueChange;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onRenderQueueChange on a nil value");
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
			UIDrawCall uIDrawCall = (UIDrawCall)obj;
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
			uIDrawCall.onRender = onRender;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onRender on a nil value");
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
			UIDrawCall uIDrawCall = (UIDrawCall)obj;
			int renderQueue = (int)LuaDLL.luaL_checknumber(L, 2);
			uIDrawCall.renderQueue = renderQueue;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index renderQueue on a nil value");
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
			UIDrawCall uIDrawCall = (UIDrawCall)obj;
			int sortingOrder = (int)LuaDLL.luaL_checknumber(L, 2);
			uIDrawCall.sortingOrder = sortingOrder;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index sortingOrder on a nil value");
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
			UIDrawCall uIDrawCall = (UIDrawCall)obj;
			string sortingLayerName = ToLua.CheckString(L, 2);
			uIDrawCall.sortingLayerName = sortingLayerName;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index sortingLayerName on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_baseMaterial(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIDrawCall uIDrawCall = (UIDrawCall)obj;
			Material baseMaterial = (Material)ToLua.CheckUnityObject(L, 2, typeof(Material));
			uIDrawCall.baseMaterial = baseMaterial;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index baseMaterial on a nil value");
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
			UIDrawCall uIDrawCall = (UIDrawCall)obj;
			Texture mainTexture = (Texture)ToLua.CheckUnityObject(L, 2, typeof(Texture));
			uIDrawCall.mainTexture = mainTexture;
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
			UIDrawCall uIDrawCall = (UIDrawCall)obj;
			Shader shader = (Shader)ToLua.CheckUnityObject(L, 2, typeof(Shader));
			uIDrawCall.shader = shader;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index shader on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UIDrawCall_OnRenderCallback(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UIDrawCall.OnRenderCallback), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UIDrawCall.OnRenderCallback), func, self);
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
	private static int UIDrawCall_OnRenderQueueChange(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UIDrawCall.OnRenderQueueChange), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UIDrawCall.OnRenderQueueChange), func, self);
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
