using LuaInterface;
using System;
using UnityEngine;

namespace XQ.Framework.Pay
{
	public class AndroidPayCallBackImpl : AndroidJavaProxy
	{
		private LuaFunction luaFunc;

		public AndroidPayCallBackImpl() : base("cn.xqapp.kt.pay.IPayCallback")
		{
		}

		private void PayFinished(string orderId, string retCode, string retDesc)
		{
			this.luaFunc.CallNoRet(new object[]
			{
				orderId,
				retCode,
				retDesc
			});
		}

		public void SetLuaCallbackFunc(LuaFunction func)
		{
			this.luaFunc = func;
		}
	}
}
