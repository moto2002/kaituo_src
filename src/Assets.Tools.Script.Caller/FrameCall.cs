using Assets.Script.Mvc.Pool;
using Assets.Tools.Script.Go;
using System;
using UnityEngine;

namespace Assets.Tools.Script.Caller
{
	public class FrameCall : MonoBehaviour
	{
		private class FrameCallPool : Pool<FrameCall>
		{
			public FrameCallPool()
			{
				this.MaxCount = 10;
			}

			protected override object CreateObject()
			{
				return ParasiticComponent.parasiteHost.AddComponent<FrameCall>();
			}
		}

		private static FrameCall.FrameCallPool pool = new FrameCall.FrameCallPool();

		private Func<bool> _delayCall;

		private bool isCreateInstance;

		public static void DelayFrame(Action a, int delayFrame)
		{
			int currFrame = 0;
			FrameCall instance = FrameCall.pool.GetInstance();
			instance.enabled = true;
			instance.CallAction(delegate
			{
				bool flag = ++currFrame < delayFrame;
				if (!flag)
				{
					a();
				}
				return flag;
			});
		}

		public static void DelayFrame(Action a)
		{
			FrameCall instance = FrameCall.pool.GetInstance();
			instance.enabled = true;
			instance.CallAction(delegate
			{
				try
				{
					a();
				}
				catch (Exception ex)
				{
					DebugConsole.Log(new object[]
					{
						ex
					});
				}
				return false;
			});
		}

		public static void Call(Func<bool> a)
		{
			FrameCall instance = FrameCall.pool.GetInstance();
			instance.enabled = true;
			instance.CallAction(a);
		}

		public static FrameCall CreateCall(Func<bool> a)
		{
			FrameCall frameCall = ParasiticComponent.parasiteHost.AddComponent<FrameCall>();
			frameCall.isCreateInstance = true;
			frameCall.CallAction(a);
			return frameCall;
		}

		private void CallAction(Func<bool> a)
		{
			this._delayCall = a;
		}

		public void Run()
		{
			this.Update();
		}

		private void Update()
		{
			if (this._delayCall != null && !this._delayCall())
			{
				this.Dispose();
			}
		}

		private void Dispose()
		{
			if (this.isCreateInstance)
			{
				UnityEngine.Object.Destroy(this);
			}
			else
			{
				base.enabled = false;
				this._delayCall = null;
				if (!FrameCall.pool.ReturnInstance(this))
				{
					UnityEngine.Object.Destroy(this);
				}
			}
		}
	}
}
