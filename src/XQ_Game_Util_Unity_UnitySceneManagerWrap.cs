using LuaInterface;
using System;
using XQ.Game.Util.Unity;

public class XQ_Game_Util_Unity_UnitySceneManagerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnitySceneManager), typeof(object), null);
		L.RegFunction("GetCurrSceneName", new LuaCSFunction(XQ_Game_Util_Unity_UnitySceneManagerWrap.GetCurrSceneName));
		L.RegFunction("LoadScene", new LuaCSFunction(XQ_Game_Util_Unity_UnitySceneManagerWrap.LoadScene));
		L.RegFunction("LoadSceneAdd", new LuaCSFunction(XQ_Game_Util_Unity_UnitySceneManagerWrap.LoadSceneAdd));
		L.RegFunction("LoadSceneAsync", new LuaCSFunction(XQ_Game_Util_Unity_UnitySceneManagerWrap.LoadSceneAsync));
		L.RegFunction("LoadSceneAsyncAdd", new LuaCSFunction(XQ_Game_Util_Unity_UnitySceneManagerWrap.LoadSceneAsyncAdd));
		L.RegFunction("SetActiveScene", new LuaCSFunction(XQ_Game_Util_Unity_UnitySceneManagerWrap.SetActiveScene));
		L.RegFunction("SetActiveSceneDelayFrame", new LuaCSFunction(XQ_Game_Util_Unity_UnitySceneManagerWrap.SetActiveSceneDelayFrame));
		L.RegFunction("UnloadScene", new LuaCSFunction(XQ_Game_Util_Unity_UnitySceneManagerWrap.UnloadScene));
		L.RegFunction("GC", new LuaCSFunction(XQ_Game_Util_Unity_UnitySceneManagerWrap.GC));
		L.RegFunction("New", new LuaCSFunction(XQ_Game_Util_Unity_UnitySceneManagerWrap._CreateXQ_Game_Util_Unity_UnitySceneManager));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("LoadingProgress", new LuaCSFunction(XQ_Game_Util_Unity_UnitySceneManagerWrap.get_LoadingProgress), new LuaCSFunction(XQ_Game_Util_Unity_UnitySceneManagerWrap.set_LoadingProgress));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateXQ_Game_Util_Unity_UnitySceneManager(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				UnitySceneManager o = new UnitySceneManager();
				ToLua.PushObject(L, o);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: XQ.Game.Util.Unity.UnitySceneManager.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetCurrSceneName(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			string currSceneName = UnitySceneManager.GetCurrSceneName();
			LuaDLL.lua_pushstring(L, currSceneName);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LoadScene(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string sceneName = ToLua.CheckString(L, 1);
			UnitySceneManager.LoadScene(sceneName);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LoadSceneAdd(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string sceneName = ToLua.CheckString(L, 1);
			UnitySceneManager.LoadSceneAdd(sceneName);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LoadSceneAsync(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string sceneName = ToLua.CheckString(L, 1);
			UnitySceneManager.LoadSceneAsync(sceneName);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LoadSceneAsyncAdd(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string sceneName = ToLua.CheckString(L, 1);
			UnitySceneManager.LoadSceneAsyncAdd(sceneName);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetActiveScene(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string activeScene = ToLua.CheckString(L, 1);
			UnitySceneManager.SetActiveScene(activeScene);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetActiveSceneDelayFrame(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string activeSceneDelayFrame = ToLua.CheckString(L, 1);
			UnitySceneManager.SetActiveSceneDelayFrame(activeSceneDelayFrame);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UnloadScene(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string sceneName = ToLua.CheckString(L, 1);
			UnitySceneManager.UnloadScene(sceneName);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GC(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			UnitySceneManager.GC();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_LoadingProgress(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushnumber(L, (double)UnitySceneManager.LoadingProgress);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_LoadingProgress(IntPtr L)
	{
		int result;
		try
		{
			float loadingProgress = (float)LuaDLL.luaL_checknumber(L, 2);
			UnitySceneManager.LoadingProgress = loadingProgress;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
