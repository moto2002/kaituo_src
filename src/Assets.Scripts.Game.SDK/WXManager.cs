using Assets.Scripts.Platform.IOS;
using Assets.Tools.Script.Caller;
using ParadoxNotion.Serialization;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

namespace Assets.Scripts.Game.SDK
{
	public class WXManager : MonoBehaviour
	{
		private class WXSDKLoginResponse
		{
			public int ErrCode;

			public string code;

			public string state;
		}

		private class WXLoginResponse
		{
			public int errcode;

			public string errmsg = string.Empty;

			public string access_token = string.Empty;

			public string expires_in = string.Empty;

			public string refresh_token = string.Empty;

			public string openid = string.Empty;

			public string scope = string.Empty;

			public string unionid = string.Empty;

			public long refresh_token_life;
		}

		private const string LoginCacheKey = "LAST_WX_LOGIN";

		public static WXManager Instance;

		private static TimeSpan RefreshTokenLife = new TimeSpan(29, 0, 0, 0);

		private Action<string> loginEndCallback;

		private Action<bool> installedCallback;

		private string logincode;

		private int sdkTimeoutTimes;

		private void Start()
		{
			WXManager.Instance = this;
			FrameCall.DelayFrame(delegate
			{
			});
		}

		public void Login(Action<string> onEnd)
		{
			this.loginEndCallback = onEnd;
		}

		public void Logout()
		{
			PlayerPrefs.DeleteKey("LAST_WX_LOGIN");
			PlayerPrefs.Save();
		}

		public bool HasLoginRecord()
		{
			return PlayerPrefs.HasKey("LAST_WX_LOGIN");
		}

		public bool IsLoginRecordValid()
		{
			string @string = PlayerPrefs.GetString("LAST_WX_LOGIN", string.Empty);
			if (string.IsNullOrEmpty(@string))
			{
				return false;
			}
			WXManager.WXLoginResponse wXLoginResponse = JSON.Deserialize<WXManager.WXLoginResponse>(@string, null);
			return wXLoginResponse.refresh_token_life > DateTime.Now.ToFileTimeUtc();
		}

		public void IsWXAppInstalled(Action<bool> callback)
		{
			this.installedCallback = callback;
			IOSBridge.IsWXAppInstalled();
		}

		private void LoginCallback(WXManager.WXLoginResponse response)
		{
			this.LoginCallback(JSON.Serialize<WXManager.WXLoginResponse>(response, false, null));
		}

		private void LoginCallback(string response)
		{
			if (this.loginEndCallback != null)
			{
				Action<string> action = this.loginEndCallback;
				this.loginEndCallback = null;
				action(response);
			}
		}

		[DebuggerHidden]
		private IEnumerator GetAccessToken()
		{
			WXManager.<GetAccessToken>c__IteratorB <GetAccessToken>c__IteratorB = new WXManager.<GetAccessToken>c__IteratorB();
			<GetAccessToken>c__IteratorB.<>f__this = this;
			return <GetAccessToken>c__IteratorB;
		}

		[DebuggerHidden]
		private IEnumerator RefreshAccessToken()
		{
			WXManager.<RefreshAccessToken>c__IteratorC <RefreshAccessToken>c__IteratorC = new WXManager.<RefreshAccessToken>c__IteratorC();
			<RefreshAccessToken>c__IteratorC.<>f__this = this;
			return <RefreshAccessToken>c__IteratorC;
		}

		private void IOSStart()
		{
			DebugConsole.Log("WX manager ios started");
			this.sdkTimeoutTimes = 0;
			IOSBridge.AddEventListener("OnWXLogined", new Action<string>(this.OnWXLogined));
			IOSBridge.AddEventListener("OnWXAppInstalledMsg", new Action<string>(this.OnWXAppInstalledMsg));
		}

		private void OnWXAppInstalledMsg(string obj)
		{
			if (this.installedCallback != null)
			{
				Action<bool> action = this.installedCallback;
				this.installedCallback = null;
				action(obj == "true" || obj == "True");
			}
		}

		private void IOSLogin()
		{
			if (this.IsLoginRecordValid())
			{
				base.StartCoroutine("RefreshAccessToken");
			}
			else
			{
				base.CancelInvoke("SDKTimeoutCheck");
				base.InvokeRepeating("SDKTimeoutCheck", 0.3f, 0.3f);
				IOSBridge.WXLogin();
			}
		}

		private void OnWXLogined(string loginCode)
		{
			base.CancelInvoke("SDKTimeoutCheck");
			WXManager.WXSDKLoginResponse wXSDKLoginResponse = JSON.Deserialize<WXManager.WXSDKLoginResponse>(loginCode, null);
			int errCode = wXSDKLoginResponse.ErrCode;
			switch (errCode + 4)
			{
			case 0:
				this.LoginCallback(new WXManager.WXLoginResponse
				{
					errcode = -4,
					errmsg = "用户拒绝授权"
				});
				return;
			case 2:
				this.LoginCallback(new WXManager.WXLoginResponse
				{
					errcode = -2,
					errmsg = "用户取消"
				});
				return;
			case 4:
				this.logincode = wXSDKLoginResponse.code;
				base.StartCoroutine("GetAccessToken");
				return;
			}
			this.LoginCallback(new WXManager.WXLoginResponse
			{
				errcode = wXSDKLoginResponse.ErrCode,
				errmsg = string.Empty
			});
		}

		private void SDKTimeoutCheck()
		{
			this.sdkTimeoutTimes++;
			if (this.sdkTimeoutTimes >= 9)
			{
				this.OnWXLogined(JSON.Serialize<WXManager.WXSDKLoginResponse>(new WXManager.WXSDKLoginResponse
				{
					ErrCode = -2
				}, false, null));
			}
		}
	}
}
