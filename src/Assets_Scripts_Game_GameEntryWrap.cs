using Assets.Scripts.Game;
using LuaInterface;
using System;
using UnityEngine;

public class Assets_Scripts_Game_GameEntryWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(GameEntry), typeof(MonoBehaviour), null);
		L.RegFunction("RegisterEntryTask", new LuaCSFunction(Assets_Scripts_Game_GameEntryWrap.RegisterEntryTask));
		L.RegFunction("Start", new LuaCSFunction(Assets_Scripts_Game_GameEntryWrap.Start));
		L.RegFunction("EntryGame", new LuaCSFunction(Assets_Scripts_Game_GameEntryWrap.EntryGame));
		L.RegFunction("__eq", new LuaCSFunction(Assets_Scripts_Game_GameEntryWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("Instance", new LuaCSFunction(Assets_Scripts_Game_GameEntryWrap.get_Instance), new LuaCSFunction(Assets_Scripts_Game_GameEntryWrap.set_Instance));
		L.RegVar("SwitchRoot", new LuaCSFunction(Assets_Scripts_Game_GameEntryWrap.get_SwitchRoot), new LuaCSFunction(Assets_Scripts_Game_GameEntryWrap.set_SwitchRoot));
		L.RegVar("StartButton", new LuaCSFunction(Assets_Scripts_Game_GameEntryWrap.get_StartButton), new LuaCSFunction(Assets_Scripts_Game_GameEntryWrap.set_StartButton));
		L.RegVar("ProgressBar", new LuaCSFunction(Assets_Scripts_Game_GameEntryWrap.get_ProgressBar), new LuaCSFunction(Assets_Scripts_Game_GameEntryWrap.set_ProgressBar));
		L.RegVar("ProgressBarSprite", new LuaCSFunction(Assets_Scripts_Game_GameEntryWrap.get_ProgressBarSprite), new LuaCSFunction(Assets_Scripts_Game_GameEntryWrap.set_ProgressBarSprite));
		L.RegVar("ProgressLabel", new LuaCSFunction(Assets_Scripts_Game_GameEntryWrap.get_ProgressLabel), new LuaCSFunction(Assets_Scripts_Game_GameEntryWrap.set_ProgressLabel));
		L.RegVar("MessageBox", new LuaCSFunction(Assets_Scripts_Game_GameEntryWrap.get_MessageBox), new LuaCSFunction(Assets_Scripts_Game_GameEntryWrap.set_MessageBox));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RegisterEntryTask(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			IGameEntryTask task = (IGameEntryTask)ToLua.CheckObject(L, 1, typeof(IGameEntryTask));
			GameEntry.RegisterEntryTask(task);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Start(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GameEntry gameEntry = (GameEntry)ToLua.CheckObject(L, 1, typeof(GameEntry));
			gameEntry.Start();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int EntryGame(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GameEntry gameEntry = (GameEntry)ToLua.CheckObject(L, 1, typeof(GameEntry));
			gameEntry.EntryGame();
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
	private static int get_Instance(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, GameEntry.Instance);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_SwitchRoot(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameEntry gameEntry = (GameEntry)obj;
			GameObject switchRoot = gameEntry.SwitchRoot;
			ToLua.Push(L, switchRoot);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index SwitchRoot on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_StartButton(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameEntry gameEntry = (GameEntry)obj;
			GameObject startButton = gameEntry.StartButton;
			ToLua.Push(L, startButton);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index StartButton on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_ProgressBar(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameEntry gameEntry = (GameEntry)obj;
			GameObject progressBar = gameEntry.ProgressBar;
			ToLua.Push(L, progressBar);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ProgressBar on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_ProgressBarSprite(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameEntry gameEntry = (GameEntry)obj;
			UISprite progressBarSprite = gameEntry.ProgressBarSprite;
			ToLua.Push(L, progressBarSprite);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ProgressBarSprite on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_ProgressLabel(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameEntry gameEntry = (GameEntry)obj;
			UILabel progressLabel = gameEntry.ProgressLabel;
			ToLua.Push(L, progressLabel);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ProgressLabel on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_MessageBox(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameEntry gameEntry = (GameEntry)obj;
			GameEntryMessageBox messageBox = gameEntry.MessageBox;
			ToLua.Push(L, messageBox);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index MessageBox on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Instance(IntPtr L)
	{
		int result;
		try
		{
			GameEntry instance = (GameEntry)ToLua.CheckUnityObject(L, 2, typeof(GameEntry));
			GameEntry.Instance = instance;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_SwitchRoot(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameEntry gameEntry = (GameEntry)obj;
			GameObject switchRoot = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			gameEntry.SwitchRoot = switchRoot;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index SwitchRoot on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_StartButton(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameEntry gameEntry = (GameEntry)obj;
			GameObject startButton = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			gameEntry.StartButton = startButton;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index StartButton on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_ProgressBar(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameEntry gameEntry = (GameEntry)obj;
			GameObject progressBar = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			gameEntry.ProgressBar = progressBar;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ProgressBar on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_ProgressBarSprite(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameEntry gameEntry = (GameEntry)obj;
			UISprite progressBarSprite = (UISprite)ToLua.CheckUnityObject(L, 2, typeof(UISprite));
			gameEntry.ProgressBarSprite = progressBarSprite;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ProgressBarSprite on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_ProgressLabel(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameEntry gameEntry = (GameEntry)obj;
			UILabel progressLabel = (UILabel)ToLua.CheckUnityObject(L, 2, typeof(UILabel));
			gameEntry.ProgressLabel = progressLabel;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ProgressLabel on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_MessageBox(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameEntry gameEntry = (GameEntry)obj;
			GameEntryMessageBox messageBox = (GameEntryMessageBox)ToLua.CheckUnityObject(L, 2, typeof(GameEntryMessageBox));
			gameEntry.MessageBox = messageBox;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index MessageBox on a nil value");
		}
		return result;
	}
}
