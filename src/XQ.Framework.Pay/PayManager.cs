using Assets.Scripts.Platform.Android;
using LuaInterface;
using System;
using UnityEngine;

namespace XQ.Framework.Pay
{
	public static class PayManager
	{
		private static AndroidPayCallBackImpl androidPayCallback;

		private static readonly AndroidJavaClass payhelper;

		static PayManager()
		{
			PayManager.androidPayCallback = new AndroidPayCallBackImpl();
			if (Application.isPlaying)
			{
				PayManager.payhelper = AndroidBridge.InitU3DActivityToStatic("xq.game.helper.PayHelper", "init");
				PayManager.payhelper.CallStatic("setPayCallBack", new object[]
				{
					PayManager.androidPayCallback
				});
			}
		}

		private static void _pay(string payMethod, string orderInfo, string orderId)
		{
			PayManager.payhelper.CallStatic("pay", new object[]
			{
				payMethod,
				orderInfo,
				orderId
			});
		}

		public static void Pay(string orderId, string orderInfo, string payMethod, LuaFunction luaFunc)
		{
			PayManager.androidPayCallback.SetLuaCallbackFunc(luaFunc);
			PayManager._pay(payMethod, orderInfo, orderId);
		}
	}
}
