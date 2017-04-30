using Assets.Scripts.Map.Tool;
using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Assets_Scripts_Map_Tool_LuaToCToolWrap
{
	public static void Register(LuaState L)
	{
		L.BeginStaticLibs("LuaToCTool");
		L.RegFunction("SetFlip", new LuaCSFunction(Assets_Scripts_Map_Tool_LuaToCToolWrap.SetFlip));
		L.RegFunction("GetChildNode", new LuaCSFunction(Assets_Scripts_Map_Tool_LuaToCToolWrap.GetChildNode));
		L.RegFunction("GetChildPath", new LuaCSFunction(Assets_Scripts_Map_Tool_LuaToCToolWrap.GetChildPath));
		L.RegFunction("GetChildFog", new LuaCSFunction(Assets_Scripts_Map_Tool_LuaToCToolWrap.GetChildFog));
		L.RegFunction("Conversation", new LuaCSFunction(Assets_Scripts_Map_Tool_LuaToCToolWrap.Conversation));
		L.RegFunction("ColorResolve", new LuaCSFunction(Assets_Scripts_Map_Tool_LuaToCToolWrap.ColorResolve));
		L.RegFunction("UITextureColorResolve", new LuaCSFunction(Assets_Scripts_Map_Tool_LuaToCToolWrap.UITextureColorResolve));
		L.RegFunction("ScreenJitter", new LuaCSFunction(Assets_Scripts_Map_Tool_LuaToCToolWrap.ScreenJitter));
		L.EndStaticLibs();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetFlip(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UIBasicSprite basicSprite = (UIBasicSprite)ToLua.CheckUnityObject(L, 1, typeof(UIBasicSprite));
			int to = (int)LuaDLL.luaL_checknumber(L, 2);
			LuaToCTool.SetFlip(basicSprite, to);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetChildNode(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GameObject obj = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			List<GameObject> childNode = LuaToCTool.GetChildNode(obj);
			ToLua.PushObject(L, childNode);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetChildPath(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GameObject obj = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			List<GameObject> childPath = LuaToCTool.GetChildPath(obj);
			ToLua.PushObject(L, childPath);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetChildFog(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GameObject obj = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			List<GameObject> childFog = LuaToCTool.GetChildFog(obj);
			ToLua.PushObject(L, childFog);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Conversation(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string data = ToLua.CheckString(L, 1);
			object obj = LuaToCTool.Conversation(data);
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
	private static int ColorResolve(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UISprite s = (UISprite)ToLua.CheckUnityObject(L, 1, typeof(UISprite));
			string data = ToLua.CheckString(L, 2);
			LuaToCTool.ColorResolve(s, data);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UITextureColorResolve(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UITexture s = (UITexture)ToLua.CheckUnityObject(L, 1, typeof(UITexture));
			string data = ToLua.CheckString(L, 2);
			LuaToCTool.UITextureColorResolve(s, data);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ScreenJitter(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			LuaToCTool.ScreenJitter();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
