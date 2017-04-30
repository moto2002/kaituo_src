using LuaInterface;
using System;
using UnityEngine;
using XQ.Framework.Utility;

public class XQ_Framework_Utility_ShaderHelperWrap
{
	public static void Register(LuaState L)
	{
		L.BeginStaticLibs("ShaderHelper");
		L.RegFunction("SetShader", new LuaCSFunction(XQ_Framework_Utility_ShaderHelperWrap.SetShader));
		L.RegFunction("Find", new LuaCSFunction(XQ_Framework_Utility_ShaderHelperWrap.Find));
		L.EndStaticLibs();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetShader(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Shader shader = (Shader)ToLua.CheckUnityObject(L, 1, typeof(Shader));
			ShaderHelper.SetShader(shader);
			result = 0;
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
			ToLua.CheckArgsCount(L, 1);
			string shadername = ToLua.CheckString(L, 1);
			Shader obj = ShaderHelper.Find(shadername);
			ToLua.Push(L, obj);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
