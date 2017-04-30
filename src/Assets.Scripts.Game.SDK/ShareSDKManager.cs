using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game.SDK
{
	public class ShareSDKManager : MonoBehaviour
	{
		public static ShareSDKManager Instance;

		public float TimeOutPeriod = 10f;

		public bool DisableSDKCallback;

		private void Start()
		{
			ShareSDKManager.Instance = this;
		}

		public void Login(int platform, Action<string> callback)
		{
			callback(null);
		}

		public void Logout(int platform)
		{
		}

		public void GetUserInfo(int platform, Action<string> callback)
		{
			callback(null);
		}

		public void BeginShareArg()
		{
		}

		public void AppendShareStringArg(string appendFuncName, string arg)
		{
		}

		public void AppendShareIntArg(string appendFuncName, int arg)
		{
		}

		public void AppendShareFloatArg(string appendFuncName, float arg)
		{
		}

		public void EndShareArg(int platform, Action<string> callback)
		{
			callback(null);
		}

		public void Share(int platform, List<object> contents, Action<string> callback)
		{
		}

		public string Copy2SDpath(Texture2D texture, string textureName, bool replace)
		{
			return null;
		}
	}
}
