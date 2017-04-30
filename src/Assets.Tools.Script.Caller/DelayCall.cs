using Assets.Script.Mvc.Pool;
using Assets.Tools.Script.Go;
using System;
using UnityEngine;

namespace Assets.Tools.Script.Caller
{
	public class DelayCall : MonoBehaviour
	{
		private class DelayCallPool : Pool<DelayCall>
		{
			protected override object CreateObject()
			{
				return ParasiticComponent.parasiteHost.AddComponent<DelayCall>();
			}
		}

		private static DelayCall.DelayCallPool pool;

		public float delay = 1f;

		public Action fun;

		public bool ignoreTimeScale;

		private DateTime startTime;

		private bool isCreateInstance;

		static DelayCall()
		{
			DelayCall.pool = new DelayCall.DelayCallPool();
			DelayCall.pool.MaxCount = 10;
		}

		public static DelayCall Call(Action a, float delay = 1f, bool ignoreTimeScale = false)
		{
			DelayCall instance = DelayCall.pool.GetInstance();
			instance.delay = delay;
			instance.fun = a;
			instance.ignoreTimeScale = ignoreTimeScale;
			instance.enabled = true;
			instance.StartDelayCall();
			return instance;
		}

		public static DelayCall CreateCall(Action a, float delay = 1f, bool ignoreTimeScale = false)
		{
			DelayCall delayCall = ParasiticComponent.parasiteHost.AddComponent<DelayCall>();
			delayCall.delay = delay;
			delayCall.fun = a;
			delayCall.ignoreTimeScale = ignoreTimeScale;
			delayCall.StartDelayCall();
			delayCall.isCreateInstance = true;
			return delayCall;
		}

		public void Stop()
		{
			this.Dispose();
		}

		private void StartDelayCall()
		{
			if (!this.ignoreTimeScale)
			{
				base.Invoke("CallBack", this.delay);
			}
			else
			{
				this.startTime = DateTime.Now;
			}
		}

		private void CallBack()
		{
			if (this.fun != null)
			{
				Action action = this.fun;
				this.fun = null;
				action();
			}
			this.Dispose();
		}

		private void Dispose()
		{
			base.enabled = false;
			if (!this.ignoreTimeScale)
			{
				base.CancelInvoke("CallBack");
			}
			this.delay = 0f;
			this.fun = null;
			this.ignoreTimeScale = false;
			if (this.isCreateInstance)
			{
				UnityEngine.Object.Destroy(this);
			}
			else if (!DelayCall.pool.ReturnInstance(this))
			{
				UnityEngine.Object.Destroy(this);
			}
		}

		private void Update()
		{
			if (this.ignoreTimeScale && (DateTime.Now - this.startTime).TotalSeconds >= (double)this.delay)
			{
				this.CallBack();
			}
		}
	}
}
