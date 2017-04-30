using Assets.Tools.Script.Helper;
using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Assets_Tools_Script_Helper_GameObjectUtilitiesWrap
{
	public static void Register(LuaState L)
	{
		L.BeginStaticLibs("GameObjectUtilities");
		L.RegFunction("GetBoundsWithChildren", new LuaCSFunction(Assets_Tools_Script_Helper_GameObjectUtilitiesWrap.GetBoundsWithChildren));
		L.RegFunction("IsActive", new LuaCSFunction(Assets_Tools_Script_Helper_GameObjectUtilitiesWrap.IsActive));
		L.RegFunction("Parent", new LuaCSFunction(Assets_Tools_Script_Helper_GameObjectUtilitiesWrap.Parent));
		L.RegFunction("ClearChildrenImmediate", new LuaCSFunction(Assets_Tools_Script_Helper_GameObjectUtilitiesWrap.ClearChildrenImmediate));
		L.RegFunction("ClearChildren", new LuaCSFunction(Assets_Tools_Script_Helper_GameObjectUtilitiesWrap.ClearChildren));
		L.RegFunction("AddEmptyGameObject", new LuaCSFunction(Assets_Tools_Script_Helper_GameObjectUtilitiesWrap.AddEmptyGameObject));
		L.RegFunction("AddInstantiate", new LuaCSFunction(Assets_Tools_Script_Helper_GameObjectUtilitiesWrap.AddInstantiate));
		L.RegFunction("GetChildren", new LuaCSFunction(Assets_Tools_Script_Helper_GameObjectUtilitiesWrap.GetChildren));
		L.RegFunction("GetChildByName", new LuaCSFunction(Assets_Tools_Script_Helper_GameObjectUtilitiesWrap.GetChildByName));
		L.RegFunction("GetParentByName", new LuaCSFunction(Assets_Tools_Script_Helper_GameObjectUtilitiesWrap.GetParentByName));
		L.RegFunction("IsChildBy", new LuaCSFunction(Assets_Tools_Script_Helper_GameObjectUtilitiesWrap.IsChildBy));
		L.RegFunction("GetChildByNameRecursion", new LuaCSFunction(Assets_Tools_Script_Helper_GameObjectUtilitiesWrap.GetChildByNameRecursion));
		L.RegFunction("SetLayerWidthChildren", new LuaCSFunction(Assets_Tools_Script_Helper_GameObjectUtilitiesWrap.SetLayerWidthChildren));
		L.RegFunction("SetLayerToCameraCullingMask", new LuaCSFunction(Assets_Tools_Script_Helper_GameObjectUtilitiesWrap.SetLayerToCameraCullingMask));
		L.RegFunction("ForEachAllChildren", new LuaCSFunction(Assets_Tools_Script_Helper_GameObjectUtilitiesWrap.ForEachAllChildren));
		L.RegFunction("NormalizationGameObject", new LuaCSFunction(Assets_Tools_Script_Helper_GameObjectUtilitiesWrap.NormalizationGameObject));
		L.RegFunction("NormalizationTransform", new LuaCSFunction(Assets_Tools_Script_Helper_GameObjectUtilitiesWrap.NormalizationTransform));
		L.RegFunction("SetTransformParentAndNormalization", new LuaCSFunction(Assets_Tools_Script_Helper_GameObjectUtilitiesWrap.SetTransformParentAndNormalization));
		L.RegFunction("SetGameObjectParentAndNormalization", new LuaCSFunction(Assets_Tools_Script_Helper_GameObjectUtilitiesWrap.SetGameObjectParentAndNormalization));
		L.RegFunction("SetTransformProperty", new LuaCSFunction(Assets_Tools_Script_Helper_GameObjectUtilitiesWrap.SetTransformProperty));
		L.EndStaticLibs();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetBoundsWithChildren(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GameObject obj = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			Bounds boundsWithChildren = obj.GetBoundsWithChildren();
			ToLua.Push(L, boundsWithChildren);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsActive(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GameObject obj = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			bool value = obj.IsActive();
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
	private static int Parent(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GameObject obj = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			GameObject obj2 = obj.Parent();
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
	private static int ClearChildrenImmediate(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GameObject parent = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			parent.ClearChildrenImmediate();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ClearChildren(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GameObject parent = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			parent.ClearChildren();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddEmptyGameObject(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GameObject parent = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			GameObject obj = parent.AddEmptyGameObject();
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
	private static int AddInstantiate(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(GameObject), typeof(GameObject)))
			{
				GameObject parent = (GameObject)ToLua.ToObject(L, 1);
				GameObject src = (GameObject)ToLua.ToObject(L, 2);
				GameObject obj = parent.AddInstantiate(src);
				ToLua.Push(L, obj);
				result = 1;
			}
			else if (num == 6 && TypeChecker.CheckTypes(L, 1, typeof(GameObject), typeof(GameObject), typeof(Vector3), typeof(Vector3), typeof(Quaternion), typeof(bool)))
			{
				GameObject parent2 = (GameObject)ToLua.ToObject(L, 1);
				GameObject src2 = (GameObject)ToLua.ToObject(L, 2);
				Vector3 position = ToLua.ToVector3(L, 3);
				Vector3 scale = ToLua.ToVector3(L, 4);
				Quaternion quaternion = ToLua.ToQuaternion(L, 5);
				bool withParentLayer = LuaDLL.lua_toboolean(L, 6);
				GameObject obj2 = parent2.AddInstantiate(src2, position, scale, quaternion, withParentLayer);
				ToLua.Push(L, obj2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: Assets.Tools.Script.Helper.GameObjectUtilities.AddInstantiate");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetChildren(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GameObject parent = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			List<GameObject> children = parent.GetChildren();
			ToLua.PushObject(L, children);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetChildByName(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			GameObject parent = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			string name = ToLua.CheckString(L, 2);
			GameObject childByName = parent.GetChildByName(name);
			ToLua.Push(L, childByName);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetParentByName(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			GameObject child = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			string name = ToLua.CheckString(L, 2);
			GameObject parentByName = child.GetParentByName(name);
			ToLua.Push(L, parentByName);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsChildBy(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			GameObject child = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			GameObject parent = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			bool value = child.IsChildBy(parent);
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
	private static int GetChildByNameRecursion(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Transform parent = (Transform)ToLua.CheckUnityObject(L, 1, typeof(Transform));
			string name = ToLua.CheckString(L, 2);
			Transform childByNameRecursion = parent.GetChildByNameRecursion(name);
			ToLua.Push(L, childByNameRecursion);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetLayerWidthChildren(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			GameObject parent = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			int layer = (int)LuaDLL.luaL_checknumber(L, 2);
			parent.SetLayerWidthChildren(layer);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetLayerToCameraCullingMask(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			GameObject obj = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			Camera camera = (Camera)ToLua.CheckUnityObject(L, 2, typeof(Camera));
			obj.SetLayerToCameraCullingMask(camera);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ForEachAllChildren(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Transform obj = (Transform)ToLua.CheckUnityObject(L, 1, typeof(Transform));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Func<Transform, bool> doFunc;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				doFunc = (Func<Transform, bool>)ToLua.CheckObject(L, 2, typeof(Func<Transform, bool>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				doFunc = (DelegateFactory.CreateDelegate(typeof(Func<Transform, bool>), func) as Func<Transform, bool>);
			}
			obj.ForEachAllChildren(doFunc);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int NormalizationGameObject(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GameObject obj = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			GameObjectUtilities.NormalizationGameObject(obj);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int NormalizationTransform(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Transform transform = (Transform)ToLua.CheckUnityObject(L, 1, typeof(Transform));
			GameObjectUtilities.NormalizationTransform(transform);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetTransformParentAndNormalization(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Transform transform = (Transform)ToLua.CheckUnityObject(L, 1, typeof(Transform));
			Transform parent = (Transform)ToLua.CheckUnityObject(L, 2, typeof(Transform));
			GameObjectUtilities.SetTransformParentAndNormalization(transform, parent);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetGameObjectParentAndNormalization(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			GameObject obj = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			Transform parent = (Transform)ToLua.CheckUnityObject(L, 2, typeof(Transform));
			GameObjectUtilities.SetGameObjectParentAndNormalization(obj, parent);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetTransformProperty(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 9);
			Transform transform = (Transform)ToLua.CheckUnityObject(L, 1, typeof(Transform));
			string name = ToLua.CheckString(L, 2);
			Transform parent = (Transform)ToLua.CheckUnityObject(L, 3, typeof(Transform));
			float localPositionX = (float)LuaDLL.luaL_checknumber(L, 4);
			float localPositionY = (float)LuaDLL.luaL_checknumber(L, 5);
			float localPositionZ = (float)LuaDLL.luaL_checknumber(L, 6);
			float localScaleX = (float)LuaDLL.luaL_checknumber(L, 7);
			float localScaleY = (float)LuaDLL.luaL_checknumber(L, 8);
			float localScaleZ = (float)LuaDLL.luaL_checknumber(L, 9);
			GameObjectUtilities.SetTransformProperty(transform, name, parent, localPositionX, localPositionY, localPositionZ, localScaleX, localScaleY, localScaleZ);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
