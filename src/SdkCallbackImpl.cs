using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

public class SdkCallbackImpl : AndroidJavaProxy
{
	public Dictionary<string, LuaFunction> sdkcallbacksLua = new Dictionary<string, LuaFunction>();

	public Dictionary<string, SDK_CALLBACK> sdkcallbacks = new Dictionary<string, SDK_CALLBACK>();

	public SdkCallbackImpl() : base("xq.game.sdk.ISDKCallback")
	{
	}

	private void onInitSucc()
	{
		this.sdkcallbacks["SDK_INIT"](new object[]
		{
			true
		});
	}

	private void onInitFailed()
	{
		this.sdkcallbacks["SDK_INIT"](new object[]
		{
			false
		});
	}

	private void onLoginSucc(string sid)
	{
		if (this.sdkcallbacksLua.ContainsKey("SDK_LOGIN_SUCC"))
		{
			this.sdkcallbacksLua["SDK_LOGIN_SUCC"].CallNoRet(new object[]
			{
				sid
			});
		}
	}

	private void onLoginFailed()
	{
		if (this.sdkcallbacksLua.ContainsKey("SDK_LOGIN_CANCEL"))
		{
			this.sdkcallbacksLua["SDK_LOGIN_CANCEL"].Call();
		}
	}

	private void onLogoutSucc()
	{
		if (this.sdkcallbacksLua.ContainsKey("SDK_LOGOUT_SUCC"))
		{
			this.sdkcallbacksLua["SDK_LOGOUT_SUCC"].Call();
		}
	}

	private void onLogoutFailed()
	{
		if (this.sdkcallbacksLua.ContainsKey("SDK_LOGOUT_FAILED"))
		{
			this.sdkcallbacksLua["SDK_LOGOUT_FAILED"].Call();
		}
	}

	private void onExitSucc()
	{
		Application.Quit();
	}
}
