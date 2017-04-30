using Assets.Tools.Script.Go;
using System;
using UnityEngine;

namespace Assets.Tools.Script.Caller
{
	public class OnceCall : MonoBehaviour
	{
		public float delay = 1f;

		public Action fun;

		private bool _tag;

		public static OnceCall Create(Action a, float delay)
		{
			OnceCall onceCall = ParasiticComponent.parasiteHost.AddComponent<OnceCall>();
			onceCall.fun = a;
			onceCall.delay = delay;
			return onceCall;
		}

		public void Call()
		{
			if (!this._tag)
			{
				this._tag = true;
				if (this.fun != null)
				{
					this.fun();
				}
				base.Invoke("reset", this.delay);
			}
		}

		private void reset()
		{
			this._tag = false;
		}
	}
}
