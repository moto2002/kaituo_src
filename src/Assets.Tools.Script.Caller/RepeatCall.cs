using Assets.Script.Mvc.Pool;
using Assets.Tools.Script.Go;
using System;
using UnityEngine;

namespace Assets.Tools.Script.Caller
{
	public class RepeatCall : MonoBehaviour
	{
		private class RepeatCallPool : Pool<RepeatCall>
		{
			public RepeatCallPool()
			{
				this.MaxCount = 10;
			}

			protected override object CreateObject()
			{
				return ParasiticComponent.parasiteHost.AddComponent<RepeatCall>();
			}
		}

		private static RepeatCall.RepeatCallPool pool = new RepeatCall.RepeatCallPool();

		private Func<bool> _delayCall;

		private bool isCreateInstance;

		public static void Call(Func<bool> a, float delay, float repateRate)
		{
			RepeatCall instance = RepeatCall.pool.GetInstance();
			instance.enabled = true;
			instance.CallAction(a, delay, repateRate);
		}

		public static RepeatCall CreateCall(Func<bool> a, float delay, float repateRate)
		{
			RepeatCall repeatCall = ParasiticComponent.parasiteHost.AddComponent<RepeatCall>();
			repeatCall.CallAction(a, delay, repateRate);
			repeatCall.isCreateInstance = true;
			return repeatCall;
		}

		private void CallAction(Func<bool> a, float delay, float repateRate)
		{
			this._delayCall = a;
			base.InvokeRepeating("CallBack", delay, repateRate);
		}

		public void Stop()
		{
			this.Dispose();
		}

		private void CallBack()
		{
			if (this._delayCall == null || !this._delayCall())
			{
				this.Dispose();
			}
		}

		private void Dispose()
		{
			base.CancelInvoke("CallBack");
			if (this.isCreateInstance)
			{
				UnityEngine.Object.Destroy(this);
			}
			else
			{
				this._delayCall = null;
				base.enabled = false;
				if (!RepeatCall.pool.ReturnInstance(this))
				{
					UnityEngine.Object.Destroy(this);
				}
			}
		}
	}
}
