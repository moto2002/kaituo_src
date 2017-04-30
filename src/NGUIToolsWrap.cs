using LuaInterface;
using System;
using UnityEngine;

public class NGUIToolsWrap
{
	public static void Register(LuaState L)
	{
		L.BeginStaticLibs("NGUITools");
		L.RegFunction("PlaySound", new LuaCSFunction(NGUIToolsWrap.PlaySound));
		L.RegFunction("RandomRange", new LuaCSFunction(NGUIToolsWrap.RandomRange));
		L.RegFunction("GetHierarchy", new LuaCSFunction(NGUIToolsWrap.GetHierarchy));
		L.RegFunction("FindCameraForLayer", new LuaCSFunction(NGUIToolsWrap.FindCameraForLayer));
		L.RegFunction("AddWidgetCollider", new LuaCSFunction(NGUIToolsWrap.AddWidgetCollider));
		L.RegFunction("UpdateWidgetCollider", new LuaCSFunction(NGUIToolsWrap.UpdateWidgetCollider));
		L.RegFunction("GetTypeName", new LuaCSFunction(NGUIToolsWrap.GetTypeName));
		L.RegFunction("RegisterUndo", new LuaCSFunction(NGUIToolsWrap.RegisterUndo));
		L.RegFunction("SetDirty", new LuaCSFunction(NGUIToolsWrap.SetDirty));
		L.RegFunction("AddChild", new LuaCSFunction(NGUIToolsWrap.AddChild));
		L.RegFunction("CalculateRaycastDepth", new LuaCSFunction(NGUIToolsWrap.CalculateRaycastDepth));
		L.RegFunction("CalculateNextDepth", new LuaCSFunction(NGUIToolsWrap.CalculateNextDepth));
		L.RegFunction("AdjustDepth", new LuaCSFunction(NGUIToolsWrap.AdjustDepth));
		L.RegFunction("BringForward", new LuaCSFunction(NGUIToolsWrap.BringForward));
		L.RegFunction("PushBack", new LuaCSFunction(NGUIToolsWrap.PushBack));
		L.RegFunction("NormalizeDepths", new LuaCSFunction(NGUIToolsWrap.NormalizeDepths));
		L.RegFunction("NormalizeWidgetDepths", new LuaCSFunction(NGUIToolsWrap.NormalizeWidgetDepths));
		L.RegFunction("NormalizePanelDepths", new LuaCSFunction(NGUIToolsWrap.NormalizePanelDepths));
		L.RegFunction("CreateUI", new LuaCSFunction(NGUIToolsWrap.CreateUI));
		L.RegFunction("SetChildLayer", new LuaCSFunction(NGUIToolsWrap.SetChildLayer));
		L.RegFunction("AddSprite", new LuaCSFunction(NGUIToolsWrap.AddSprite));
		L.RegFunction("GetRoot", new LuaCSFunction(NGUIToolsWrap.GetRoot));
		L.RegFunction("Destroy", new LuaCSFunction(NGUIToolsWrap.Destroy));
		L.RegFunction("DestroyChildren", new LuaCSFunction(NGUIToolsWrap.DestroyChildren));
		L.RegFunction("DestroyImmediate", new LuaCSFunction(NGUIToolsWrap.DestroyImmediate));
		L.RegFunction("Broadcast", new LuaCSFunction(NGUIToolsWrap.Broadcast));
		L.RegFunction("IsChild", new LuaCSFunction(NGUIToolsWrap.IsChild));
		L.RegFunction("SetActive", new LuaCSFunction(NGUIToolsWrap.SetActive));
		L.RegFunction("SetActiveChildren", new LuaCSFunction(NGUIToolsWrap.SetActiveChildren));
		L.RegFunction("GetActive", new LuaCSFunction(NGUIToolsWrap.GetActive));
		L.RegFunction("SetActiveSelf", new LuaCSFunction(NGUIToolsWrap.SetActiveSelf));
		L.RegFunction("SetLayer", new LuaCSFunction(NGUIToolsWrap.SetLayer));
		L.RegFunction("Round", new LuaCSFunction(NGUIToolsWrap.Round));
		L.RegFunction("MakePixelPerfect", new LuaCSFunction(NGUIToolsWrap.MakePixelPerfect));
		L.RegFunction("FitOnScreen", new LuaCSFunction(NGUIToolsWrap.FitOnScreen));
		L.RegFunction("Save", new LuaCSFunction(NGUIToolsWrap.Save));
		L.RegFunction("Load", new LuaCSFunction(NGUIToolsWrap.Load));
		L.RegFunction("ApplyPMA", new LuaCSFunction(NGUIToolsWrap.ApplyPMA));
		L.RegFunction("MarkParentAsChanged", new LuaCSFunction(NGUIToolsWrap.MarkParentAsChanged));
		L.RegFunction("GetSides", new LuaCSFunction(NGUIToolsWrap.GetSides));
		L.RegFunction("GetWorldCorners", new LuaCSFunction(NGUIToolsWrap.GetWorldCorners));
		L.RegFunction("GetFuncName", new LuaCSFunction(NGUIToolsWrap.GetFuncName));
		L.RegFunction("ImmediatelyCreateDrawCalls", new LuaCSFunction(NGUIToolsWrap.ImmediatelyCreateDrawCalls));
		L.RegFunction("KeyToCaption", new LuaCSFunction(NGUIToolsWrap.KeyToCaption));
		L.RegFunction("GammaToLinearSpace", new LuaCSFunction(NGUIToolsWrap.GammaToLinearSpace));
		L.RegVar("keys", new LuaCSFunction(NGUIToolsWrap.get_keys), new LuaCSFunction(NGUIToolsWrap.set_keys));
		L.RegVar("soundVolume", new LuaCSFunction(NGUIToolsWrap.get_soundVolume), new LuaCSFunction(NGUIToolsWrap.set_soundVolume));
		L.RegVar("fileAccess", new LuaCSFunction(NGUIToolsWrap.get_fileAccess), null);
		L.RegVar("clipboard", new LuaCSFunction(NGUIToolsWrap.get_clipboard), new LuaCSFunction(NGUIToolsWrap.set_clipboard));
		L.RegVar("screenSize", new LuaCSFunction(NGUIToolsWrap.get_screenSize), null);
		L.EndStaticLibs();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PlaySound(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(AudioClip)))
			{
				AudioClip clip = (AudioClip)ToLua.ToObject(L, 1);
				AudioSource obj = NGUITools.PlaySound(clip);
				ToLua.Push(L, obj);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(AudioClip), typeof(float)))
			{
				AudioClip clip2 = (AudioClip)ToLua.ToObject(L, 1);
				float volume = (float)LuaDLL.lua_tonumber(L, 2);
				AudioSource obj2 = NGUITools.PlaySound(clip2, volume);
				ToLua.Push(L, obj2);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(AudioClip), typeof(float), typeof(float)))
			{
				AudioClip clip3 = (AudioClip)ToLua.ToObject(L, 1);
				float volume2 = (float)LuaDLL.lua_tonumber(L, 2);
				float pitch = (float)LuaDLL.lua_tonumber(L, 3);
				AudioSource obj3 = NGUITools.PlaySound(clip3, volume2, pitch);
				ToLua.Push(L, obj3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: NGUITools.PlaySound");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RandomRange(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			int min = (int)LuaDLL.luaL_checknumber(L, 1);
			int max = (int)LuaDLL.luaL_checknumber(L, 2);
			int n = NGUITools.RandomRange(min, max);
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
	private static int GetHierarchy(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GameObject obj = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			string hierarchy = NGUITools.GetHierarchy(obj);
			LuaDLL.lua_pushstring(L, hierarchy);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int FindCameraForLayer(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			int layer = (int)LuaDLL.luaL_checknumber(L, 1);
			Camera obj = NGUITools.FindCameraForLayer(layer);
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
	private static int AddWidgetCollider(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(GameObject)))
			{
				GameObject go = (GameObject)ToLua.ToObject(L, 1);
				NGUITools.AddWidgetCollider(go);
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(GameObject), typeof(bool)))
			{
				GameObject go2 = (GameObject)ToLua.ToObject(L, 1);
				bool considerInactive = LuaDLL.lua_toboolean(L, 2);
				NGUITools.AddWidgetCollider(go2, considerInactive);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: NGUITools.AddWidgetCollider");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UpdateWidgetCollider(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(GameObject)))
			{
				GameObject go = (GameObject)ToLua.ToObject(L, 1);
				NGUITools.UpdateWidgetCollider(go);
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(BoxCollider2D), typeof(bool)))
			{
				BoxCollider2D box = (BoxCollider2D)ToLua.ToObject(L, 1);
				bool considerInactive = LuaDLL.lua_toboolean(L, 2);
				NGUITools.UpdateWidgetCollider(box, considerInactive);
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(BoxCollider), typeof(bool)))
			{
				BoxCollider box2 = (BoxCollider)ToLua.ToObject(L, 1);
				bool considerInactive2 = LuaDLL.lua_toboolean(L, 2);
				NGUITools.UpdateWidgetCollider(box2, considerInactive2);
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(GameObject), typeof(bool)))
			{
				GameObject go2 = (GameObject)ToLua.ToObject(L, 1);
				bool considerInactive3 = LuaDLL.lua_toboolean(L, 2);
				NGUITools.UpdateWidgetCollider(go2, considerInactive3);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: NGUITools.UpdateWidgetCollider");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetTypeName(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.Object obj = ToLua.CheckUnityObject(L, 1, typeof(UnityEngine.Object));
			string typeName = NGUITools.GetTypeName(obj);
			LuaDLL.lua_pushstring(L, typeName);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RegisterUndo(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Object obj = ToLua.CheckUnityObject(L, 1, typeof(UnityEngine.Object));
			string name = ToLua.CheckString(L, 2);
			NGUITools.RegisterUndo(obj, name);
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
			UnityEngine.Object dirty = ToLua.CheckUnityObject(L, 1, typeof(UnityEngine.Object));
			NGUITools.SetDirty(dirty);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddChild(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(GameObject)))
			{
				GameObject parent = (GameObject)ToLua.ToObject(L, 1);
				GameObject obj = parent.AddChild();
				ToLua.Push(L, obj);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(GameObject), typeof(GameObject)))
			{
				GameObject parent2 = (GameObject)ToLua.ToObject(L, 1);
				GameObject prefab = (GameObject)ToLua.ToObject(L, 2);
				GameObject obj2 = parent2.AddChild(prefab);
				ToLua.Push(L, obj2);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(GameObject), typeof(bool)))
			{
				GameObject parent3 = (GameObject)ToLua.ToObject(L, 1);
				bool undo = LuaDLL.lua_toboolean(L, 2);
				GameObject obj3 = parent3.AddChild(undo);
				ToLua.Push(L, obj3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: NGUITools.AddChild");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CalculateRaycastDepth(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			int n = NGUITools.CalculateRaycastDepth(go);
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
	private static int CalculateNextDepth(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(GameObject)))
			{
				GameObject go = (GameObject)ToLua.ToObject(L, 1);
				int n = NGUITools.CalculateNextDepth(go);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(GameObject), typeof(bool)))
			{
				GameObject go2 = (GameObject)ToLua.ToObject(L, 1);
				bool ignoreChildrenWithColliders = LuaDLL.lua_toboolean(L, 2);
				int n2 = NGUITools.CalculateNextDepth(go2, ignoreChildrenWithColliders);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: NGUITools.CalculateNextDepth");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AdjustDepth(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			int adjustment = (int)LuaDLL.luaL_checknumber(L, 2);
			int n = NGUITools.AdjustDepth(go, adjustment);
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
	private static int BringForward(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			NGUITools.BringForward(go);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PushBack(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			NGUITools.PushBack(go);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int NormalizeDepths(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			NGUITools.NormalizeDepths();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int NormalizeWidgetDepths(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 0)
			{
				NGUITools.NormalizeWidgetDepths();
				result = 0;
			}
			else if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(UIWidget[])))
			{
				UIWidget[] list = ToLua.CheckObjectArray<UIWidget>(L, 1);
				NGUITools.NormalizeWidgetDepths(list);
				result = 0;
			}
			else if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(GameObject)))
			{
				GameObject go = (GameObject)ToLua.ToObject(L, 1);
				NGUITools.NormalizeWidgetDepths(go);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: NGUITools.NormalizeWidgetDepths");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int NormalizePanelDepths(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			NGUITools.NormalizePanelDepths();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CreateUI(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(bool)))
			{
				bool advanced3D = LuaDLL.lua_toboolean(L, 1);
				UIPanel obj = NGUITools.CreateUI(advanced3D);
				ToLua.Push(L, obj);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(bool), typeof(int)))
			{
				bool advanced3D2 = LuaDLL.lua_toboolean(L, 1);
				int layer = (int)LuaDLL.lua_tonumber(L, 2);
				UIPanel obj2 = NGUITools.CreateUI(advanced3D2, layer);
				ToLua.Push(L, obj2);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Transform), typeof(bool), typeof(int)))
			{
				Transform trans = (Transform)ToLua.ToObject(L, 1);
				bool advanced3D3 = LuaDLL.lua_toboolean(L, 2);
				int layer2 = (int)LuaDLL.lua_tonumber(L, 3);
				UIPanel obj3 = NGUITools.CreateUI(trans, advanced3D3, layer2);
				ToLua.Push(L, obj3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: NGUITools.CreateUI");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetChildLayer(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Transform t = (Transform)ToLua.CheckUnityObject(L, 1, typeof(Transform));
			int layer = (int)LuaDLL.luaL_checknumber(L, 2);
			t.SetChildLayer(layer);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddSprite(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			UIAtlas atlas = (UIAtlas)ToLua.CheckUnityObject(L, 2, typeof(UIAtlas));
			string spriteName = ToLua.CheckString(L, 3);
			int depth = (int)LuaDLL.luaL_checknumber(L, 4);
			UISprite obj = go.AddSprite(atlas, spriteName, depth);
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
	private static int GetRoot(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			GameObject root = NGUITools.GetRoot(go);
			ToLua.Push(L, root);
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
			UnityEngine.Object obj = ToLua.CheckUnityObject(L, 1, typeof(UnityEngine.Object));
			NGUITools.Destroy(obj);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DestroyChildren(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Transform t = (Transform)ToLua.CheckUnityObject(L, 1, typeof(Transform));
			t.DestroyChildren();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DestroyImmediate(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.Object obj = ToLua.CheckUnityObject(L, 1, typeof(UnityEngine.Object));
			NGUITools.DestroyImmediate(obj);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Broadcast(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(string)))
			{
				string funcName = ToLua.ToString(L, 1);
				NGUITools.Broadcast(funcName);
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(object)))
			{
				string funcName2 = ToLua.ToString(L, 1);
				object param = ToLua.ToVarObject(L, 2);
				NGUITools.Broadcast(funcName2, param);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: NGUITools.Broadcast");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsChild(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Transform parent = (Transform)ToLua.CheckUnityObject(L, 1, typeof(Transform));
			Transform child = (Transform)ToLua.CheckUnityObject(L, 2, typeof(Transform));
			bool value = NGUITools.IsChild(parent, child);
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
	private static int SetActive(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(GameObject), typeof(bool)))
			{
				GameObject go = (GameObject)ToLua.ToObject(L, 1);
				bool state = LuaDLL.lua_toboolean(L, 2);
				NGUITools.SetActive(go, state);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(GameObject), typeof(bool), typeof(bool)))
			{
				GameObject go2 = (GameObject)ToLua.ToObject(L, 1);
				bool state2 = LuaDLL.lua_toboolean(L, 2);
				bool compatibilityMode = LuaDLL.lua_toboolean(L, 3);
				NGUITools.SetActive(go2, state2, compatibilityMode);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: NGUITools.SetActive");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetActiveChildren(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			bool state = LuaDLL.luaL_checkboolean(L, 2);
			NGUITools.SetActiveChildren(go, state);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetActive(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(GameObject)))
			{
				GameObject go = (GameObject)ToLua.ToObject(L, 1);
				bool active = NGUITools.GetActive(go);
				LuaDLL.lua_pushboolean(L, active);
				result = 1;
			}
			else if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(Behaviour)))
			{
				Behaviour mb = (Behaviour)ToLua.ToObject(L, 1);
				bool active2 = NGUITools.GetActive(mb);
				LuaDLL.lua_pushboolean(L, active2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: NGUITools.GetActive");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetActiveSelf(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			bool state = LuaDLL.luaL_checkboolean(L, 2);
			NGUITools.SetActiveSelf(go, state);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetLayer(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			int layer = (int)LuaDLL.luaL_checknumber(L, 2);
			NGUITools.SetLayer(go, layer);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Round(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Vector3 v = ToLua.ToVector3(L, 1);
			Vector3 v2 = NGUITools.Round(v);
			ToLua.Push(L, v2);
			result = 1;
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
			Transform t = (Transform)ToLua.CheckUnityObject(L, 1, typeof(Transform));
			NGUITools.MakePixelPerfect(t);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int FitOnScreen(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Camera), typeof(Transform), typeof(Vector3)))
			{
				Camera cam = (Camera)ToLua.ToObject(L, 1);
				Transform transform = (Transform)ToLua.ToObject(L, 2);
				Vector3 pos = ToLua.ToVector3(L, 3);
				cam.FitOnScreen(transform, pos);
				result = 0;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Camera), typeof(Transform), typeof(Transform), typeof(Vector3)))
			{
				Camera cam2 = (Camera)ToLua.ToObject(L, 1);
				Transform transform2 = (Transform)ToLua.ToObject(L, 2);
				Transform content = (Transform)ToLua.ToObject(L, 3);
				Vector3 pos2 = ToLua.ToVector3(L, 4);
				cam2.FitOnScreen(transform2, content, pos2);
				result = 0;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Camera), typeof(Transform), typeof(Transform), typeof(Vector3), typeof(LuaOut<Bounds>)))
			{
				Camera cam3 = (Camera)ToLua.ToObject(L, 1);
				Transform transform3 = (Transform)ToLua.ToObject(L, 2);
				Transform content2 = (Transform)ToLua.ToObject(L, 3);
				Vector3 pos3 = ToLua.ToVector3(L, 4);
				Bounds bound;
				cam3.FitOnScreen(transform3, content2, pos3, out bound);
				ToLua.Push(L, bound);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: NGUITools.FitOnScreen");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Save(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			string fileName = ToLua.CheckString(L, 1);
			byte[] bytes = ToLua.CheckByteBuffer(L, 2);
			bool value = NGUITools.Save(fileName, bytes);
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
	private static int Load(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string fileName = ToLua.CheckString(L, 1);
			byte[] array = NGUITools.Load(fileName);
			ToLua.Push(L, array);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ApplyPMA(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Color c = ToLua.ToColor(L, 1);
			Color clr = NGUITools.ApplyPMA(c);
			ToLua.Push(L, clr);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int MarkParentAsChanged(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			NGUITools.MarkParentAsChanged(go);
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
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(Camera)))
			{
				Camera cam = (Camera)ToLua.ToObject(L, 1);
				Vector3[] sides = cam.GetSides();
				ToLua.Push(L, sides);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Camera), typeof(Transform)))
			{
				Camera cam2 = (Camera)ToLua.ToObject(L, 1);
				Transform relativeTo = (Transform)ToLua.ToObject(L, 2);
				Vector3[] sides2 = cam2.GetSides(relativeTo);
				ToLua.Push(L, sides2);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Camera), typeof(float)))
			{
				Camera cam3 = (Camera)ToLua.ToObject(L, 1);
				float depth = (float)LuaDLL.lua_tonumber(L, 2);
				Vector3[] sides3 = cam3.GetSides(depth);
				ToLua.Push(L, sides3);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Camera), typeof(float), typeof(Transform)))
			{
				Camera cam4 = (Camera)ToLua.ToObject(L, 1);
				float depth2 = (float)LuaDLL.lua_tonumber(L, 2);
				Transform relativeTo2 = (Transform)ToLua.ToObject(L, 3);
				Vector3[] sides4 = cam4.GetSides(depth2, relativeTo2);
				ToLua.Push(L, sides4);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: NGUITools.GetSides");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetWorldCorners(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(Camera)))
			{
				Camera cam = (Camera)ToLua.ToObject(L, 1);
				Vector3[] worldCorners = cam.GetWorldCorners();
				ToLua.Push(L, worldCorners);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Camera), typeof(Transform)))
			{
				Camera cam2 = (Camera)ToLua.ToObject(L, 1);
				Transform relativeTo = (Transform)ToLua.ToObject(L, 2);
				Vector3[] worldCorners2 = cam2.GetWorldCorners(relativeTo);
				ToLua.Push(L, worldCorners2);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Camera), typeof(float)))
			{
				Camera cam3 = (Camera)ToLua.ToObject(L, 1);
				float depth = (float)LuaDLL.lua_tonumber(L, 2);
				Vector3[] worldCorners3 = cam3.GetWorldCorners(depth);
				ToLua.Push(L, worldCorners3);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Camera), typeof(float), typeof(Transform)))
			{
				Camera cam4 = (Camera)ToLua.ToObject(L, 1);
				float depth2 = (float)LuaDLL.lua_tonumber(L, 2);
				Transform relativeTo2 = (Transform)ToLua.ToObject(L, 3);
				Vector3[] worldCorners4 = cam4.GetWorldCorners(depth2, relativeTo2);
				ToLua.Push(L, worldCorners4);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: NGUITools.GetWorldCorners");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetFuncName(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			object obj = ToLua.ToVarObject(L, 1);
			string method = ToLua.CheckString(L, 2);
			string funcName = NGUITools.GetFuncName(obj, method);
			LuaDLL.lua_pushstring(L, funcName);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ImmediatelyCreateDrawCalls(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GameObject root = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			NGUITools.ImmediatelyCreateDrawCalls(root);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int KeyToCaption(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			KeyCode key = (KeyCode)LuaDLL.luaL_checknumber(L, 1);
			string str = NGUITools.KeyToCaption(key);
			LuaDLL.lua_pushstring(L, str);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GammaToLinearSpace(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(Vector4)))
			{
				Vector4 v = ToLua.ToVector4(L, 1);
				Color clr = v.GammaToLinearSpace();
				ToLua.Push(L, clr);
				result = 1;
			}
			else if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(Color)))
			{
				Color c = ToLua.ToColor(L, 1);
				Color clr2 = c.GammaToLinearSpace();
				ToLua.Push(L, clr2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: NGUITools.GammaToLinearSpace");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_keys(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, NGUITools.keys);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_soundVolume(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushnumber(L, (double)NGUITools.soundVolume);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_fileAccess(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushboolean(L, NGUITools.fileAccess);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_clipboard(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushstring(L, NGUITools.clipboard);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_screenSize(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, NGUITools.screenSize);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_keys(IntPtr L)
	{
		int result;
		try
		{
			KeyCode[] keys = ToLua.CheckObjectArray<KeyCode>(L, 2);
			NGUITools.keys = keys;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_soundVolume(IntPtr L)
	{
		int result;
		try
		{
			float soundVolume = (float)LuaDLL.luaL_checknumber(L, 2);
			NGUITools.soundVolume = soundVolume;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_clipboard(IntPtr L)
	{
		int result;
		try
		{
			string clipboard = ToLua.CheckString(L, 2);
			NGUITools.clipboard = clipboard;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
