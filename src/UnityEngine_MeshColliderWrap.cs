using LuaInterface;
using System;
using UnityEngine;

public class UnityEngine_MeshColliderWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(MeshCollider), typeof(Collider), null);
		L.RegFunction("New", new LuaCSFunction(UnityEngine_MeshColliderWrap._CreateUnityEngine_MeshCollider));
		L.RegFunction("__eq", new LuaCSFunction(UnityEngine_MeshColliderWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("sharedMesh", new LuaCSFunction(UnityEngine_MeshColliderWrap.get_sharedMesh), new LuaCSFunction(UnityEngine_MeshColliderWrap.set_sharedMesh));
		L.RegVar("convex", new LuaCSFunction(UnityEngine_MeshColliderWrap.get_convex), new LuaCSFunction(UnityEngine_MeshColliderWrap.set_convex));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateUnityEngine_MeshCollider(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				MeshCollider obj = new MeshCollider();
				ToLua.Push(L, obj);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: UnityEngine.MeshCollider.New");
			}
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
	private static int get_sharedMesh(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			MeshCollider meshCollider = (MeshCollider)obj;
			Mesh sharedMesh = meshCollider.sharedMesh;
			ToLua.Push(L, sharedMesh);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index sharedMesh on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_convex(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			MeshCollider meshCollider = (MeshCollider)obj;
			bool convex = meshCollider.convex;
			LuaDLL.lua_pushboolean(L, convex);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index convex on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_sharedMesh(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			MeshCollider meshCollider = (MeshCollider)obj;
			Mesh sharedMesh = (Mesh)ToLua.CheckUnityObject(L, 2, typeof(Mesh));
			meshCollider.sharedMesh = sharedMesh;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index sharedMesh on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_convex(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			MeshCollider meshCollider = (MeshCollider)obj;
			bool convex = LuaDLL.luaL_checkboolean(L, 2);
			meshCollider.convex = convex;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index convex on a nil value");
		}
		return result;
	}
}
