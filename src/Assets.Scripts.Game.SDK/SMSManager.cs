using Assets.Tools.Script.Caller;
using System;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Assets.Scripts.Game.SDK
{
	public class SMSManager : MonoBehaviour
	{
		public static SMSManager Instance;

		private void Start()
		{
			SMSManager.Instance = this;
		}

		public void GetCode(string phoneNumber, string zone, Action<string> callback)
		{
			DelayCall.Call(delegate
			{
				if (this.IsPhoneNumber(phoneNumber))
				{
					callback(string.Empty);
				}
				else
				{
					callback("{\"status\":-1,\"detail\":\"请正确输入手机号码\"}");
				}
			}, 1f, false);
		}

		public void CommitCode(string phoneNumber, string zone, string verificationCode, Action<string> callback)
		{
			DelayCall.Call(delegate
			{
				if (verificationCode == "1111")
				{
					callback(string.Empty);
				}
				else
				{
					callback("{\"status\":-1,\"detail\":\"（PC测试）请输入验证码‘1111’\"}");
				}
			}, 1f, false);
		}

		public void onComplete(int action, object resp)
		{
		}

		public void onError(int action, object resp)
		{
		}

		public bool IsPhoneNumber(string value)
		{
			Regex regex = new Regex("^1\\d{10}$");
			return regex.IsMatch(value);
		}
	}
}
