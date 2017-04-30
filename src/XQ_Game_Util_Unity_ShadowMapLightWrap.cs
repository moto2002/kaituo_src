using LuaInterface;
using System;
using UnityEngine;
using XQ.Game.Util.Unity;

public class XQ_Game_Util_Unity_ShadowMapLightWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(ShadowMapLight), typeof(MonoBehaviour), null);
		L.RegFunction("__eq", new LuaCSFunction(XQ_Game_Util_Unity_ShadowMapLightWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("Instance", new LuaCSFunction(XQ_Game_Util_Unity_ShadowMapLightWrap.get_Instance), new LuaCSFunction(XQ_Game_Util_Unity_ShadowMapLightWrap.set_Instance));
		L.RegVar("ShadowMapSize", new LuaCSFunction(XQ_Game_Util_Unity_ShadowMapLightWrap.get_ShadowMapSize), new LuaCSFunction(XQ_Game_Util_Unity_ShadowMapLightWrap.set_ShadowMapSize));
		L.RegVar("ShadowCamera", new LuaCSFunction(XQ_Game_Util_Unity_ShadowMapLightWrap.get_ShadowCamera), new LuaCSFunction(XQ_Game_Util_Unity_ShadowMapLightWrap.set_ShadowCamera));
		L.RegVar("ShadowProjector", new LuaCSFunction(XQ_Game_Util_Unity_ShadowMapLightWrap.get_ShadowProjector), new LuaCSFunction(XQ_Game_Util_Unity_ShadowMapLightWrap.set_ShadowProjector));
		L.RegVar("ShadowMap", new LuaCSFunction(XQ_Game_Util_Unity_ShadowMapLightWrap.get_ShadowMap), new LuaCSFunction(XQ_Game_Util_Unity_ShadowMapLightWrap.set_ShadowMap));
		L.RegVar("ShadowMesh", new LuaCSFunction(XQ_Game_Util_Unity_ShadowMapLightWrap.get_ShadowMesh), new LuaCSFunction(XQ_Game_Util_Unity_ShadowMapLightWrap.set_ShadowMesh));
		L.RegVar("Texture", new LuaCSFunction(XQ_Game_Util_Unity_ShadowMapLightWrap.get_Texture), new LuaCSFunction(XQ_Game_Util_Unity_ShadowMapLightWrap.set_Texture));
		L.RegVar("m44", new LuaCSFunction(XQ_Game_Util_Unity_ShadowMapLightWrap.get_m44), new LuaCSFunction(XQ_Game_Util_Unity_ShadowMapLightWrap.set_m44));
		L.RegVar("UpdateAction", new LuaCSFunction(XQ_Game_Util_Unity_ShadowMapLightWrap.get_UpdateAction), new LuaCSFunction(XQ_Game_Util_Unity_ShadowMapLightWrap.set_UpdateAction));
		L.RegVar("ShadowMaterial", new LuaCSFunction(XQ_Game_Util_Unity_ShadowMapLightWrap.get_ShadowMaterial), null);
		L.EndClass();
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
			ToLua.Push(L, ShadowMapLight.Instance);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_ShadowMapSize(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ShadowMapLight shadowMapLight = (ShadowMapLight)obj;
			int shadowMapSize = shadowMapLight.ShadowMapSize;
			LuaDLL.lua_pushinteger(L, shadowMapSize);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ShadowMapSize on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_ShadowCamera(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ShadowMapLight shadowMapLight = (ShadowMapLight)obj;
			Camera shadowCamera = shadowMapLight.ShadowCamera;
			ToLua.Push(L, shadowCamera);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ShadowCamera on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_ShadowProjector(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ShadowMapLight shadowMapLight = (ShadowMapLight)obj;
			Projector shadowProjector = shadowMapLight.ShadowProjector;
			ToLua.Push(L, shadowProjector);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ShadowProjector on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_ShadowMap(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ShadowMapLight shadowMapLight = (ShadowMapLight)obj;
			RenderTexture shadowMap = shadowMapLight.ShadowMap;
			ToLua.Push(L, shadowMap);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ShadowMap on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_ShadowMesh(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ShadowMapLight shadowMapLight = (ShadowMapLight)obj;
			MeshRenderer shadowMesh = shadowMapLight.ShadowMesh;
			ToLua.Push(L, shadowMesh);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ShadowMesh on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Texture(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ShadowMapLight shadowMapLight = (ShadowMapLight)obj;
			RenderTexture texture = shadowMapLight.Texture;
			ToLua.Push(L, texture);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Texture on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_m44(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ShadowMapLight shadowMapLight = (ShadowMapLight)obj;
			Matrix4x4 m = shadowMapLight.m44;
			ToLua.PushValue(L, m);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index m44 on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_UpdateAction(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ShadowMapLight shadowMapLight = (ShadowMapLight)obj;
			Action updateAction = shadowMapLight.UpdateAction;
			ToLua.Push(L, updateAction);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index UpdateAction on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_ShadowMaterial(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ShadowMapLight shadowMapLight = (ShadowMapLight)obj;
			Material shadowMaterial = shadowMapLight.ShadowMaterial;
			ToLua.Push(L, shadowMaterial);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ShadowMaterial on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Instance(IntPtr L)
	{
		int result;
		try
		{
			ShadowMapLight instance = (ShadowMapLight)ToLua.CheckUnityObject(L, 2, typeof(ShadowMapLight));
			ShadowMapLight.Instance = instance;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_ShadowMapSize(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ShadowMapLight shadowMapLight = (ShadowMapLight)obj;
			int shadowMapSize = (int)LuaDLL.luaL_checknumber(L, 2);
			shadowMapLight.ShadowMapSize = shadowMapSize;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ShadowMapSize on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_ShadowCamera(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ShadowMapLight shadowMapLight = (ShadowMapLight)obj;
			Camera shadowCamera = (Camera)ToLua.CheckUnityObject(L, 2, typeof(Camera));
			shadowMapLight.ShadowCamera = shadowCamera;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ShadowCamera on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_ShadowProjector(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ShadowMapLight shadowMapLight = (ShadowMapLight)obj;
			Projector shadowProjector = (Projector)ToLua.CheckUnityObject(L, 2, typeof(Projector));
			shadowMapLight.ShadowProjector = shadowProjector;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ShadowProjector on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_ShadowMap(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ShadowMapLight shadowMapLight = (ShadowMapLight)obj;
			RenderTexture shadowMap = (RenderTexture)ToLua.CheckUnityObject(L, 2, typeof(RenderTexture));
			shadowMapLight.ShadowMap = shadowMap;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ShadowMap on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_ShadowMesh(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ShadowMapLight shadowMapLight = (ShadowMapLight)obj;
			MeshRenderer shadowMesh = (MeshRenderer)ToLua.CheckUnityObject(L, 2, typeof(MeshRenderer));
			shadowMapLight.ShadowMesh = shadowMesh;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ShadowMesh on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Texture(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ShadowMapLight shadowMapLight = (ShadowMapLight)obj;
			RenderTexture texture = (RenderTexture)ToLua.CheckUnityObject(L, 2, typeof(RenderTexture));
			shadowMapLight.Texture = texture;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Texture on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_m44(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ShadowMapLight shadowMapLight = (ShadowMapLight)obj;
			Matrix4x4 m = (Matrix4x4)ToLua.CheckObject(L, 2, typeof(Matrix4x4));
			shadowMapLight.m44 = m;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index m44 on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_UpdateAction(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ShadowMapLight shadowMapLight = (ShadowMapLight)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Action updateAction;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				updateAction = (Action)ToLua.CheckObject(L, 2, typeof(Action));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				updateAction = (DelegateFactory.CreateDelegate(typeof(Action), func) as Action);
			}
			shadowMapLight.UpdateAction = updateAction;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index UpdateAction on a nil value");
		}
		return result;
	}
}
