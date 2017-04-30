using Assets.Scripts.Platform.Android;
using LuaInterface;
using System;
using UnityEngine;

public static class SdkCallbackManager
{
	private static readonly AndroidJavaClass sdkhelper;

	private static readonly SdkCallbackImpl sdkCallback;

	static SdkCallbackManager()
	{
		SdkCallbackManager.sdkCallback = new SdkCallbackImpl();
		if (Application.isPlaying)
		{
			AndroidJavaClass @class = AndroidBridge.GetClass("xq.game.sdk.SdkProxy");
			@class.CallStatic("init", new object[]
			{
				SdkCallbackManager.sdkCallback
			});
			SdkCallbackManager.sdkhelper = AndroidBridge.GetClass("xq.game.sdk.uc.UCSdk");
		}
	}

	public static void CallSdk(string method, params object[] args)
	{
		if (args.IsNullOrEmpty<object>())
		{
			SdkCallbackManager.sdkhelper.CallStatic(method, new object[0]);
		}
		else
		{
			SdkCallbackManager.sdkhelper.CallStatic(method, args);
		}
	}

	public static void SetSDKCallBackLua(string funcName, LuaFunction function)
	{
		if (SdkCallbackManager.sdkCallback.sdkcallbacksLua.ContainsKey(funcName))
		{
			SdkCallbackManager.sdkCallback.sdkcallbacksLua[funcName] = function;
		}
		else
		{
			SdkCallbackManager.sdkCallback.sdkcallbacksLua.Add(funcName, function);
		}
	}

	[NoToLua]
	public static void SetSDKCallBack(string methodName, SDK_CALLBACK sdkcb)
	{
		if (SdkCallbackManager.sdkCallback.sdkcallbacks.ContainsKey(methodName))
		{
			SdkCallbackManager.sdkCallback.sdkcallbacks[methodName] = sdkcb;
		}
		else
		{
			SdkCallbackManager.sdkCallback.sdkcallbacks.Add(methodName, sdkcb);
		}
	}
}
