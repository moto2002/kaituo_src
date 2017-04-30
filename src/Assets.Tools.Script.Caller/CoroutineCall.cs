using Assets.Script.Mvc.Pool;
using Assets.Tools.Script.Go;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

namespace Assets.Tools.Script.Caller
{
	public class CoroutineCall : MonoBehaviour
	{
		private class CoroutineCallPool : Pool<CoroutineCall>
		{
			public CoroutineCallPool()
			{
				this.MaxCount = 10;
			}

			protected override object CreateObject()
			{
				return ParasiticComponent.parasiteHost.AddComponent<CoroutineCall>();
			}
		}

		private static CoroutineCall.CoroutineCallPool pool = new CoroutineCall.CoroutineCallPool();

		private Func<IEnumerator> a;

		public static void Call(Func<IEnumerator> a)
		{
			CoroutineCall instance = CoroutineCall.pool.GetInstance();
			instance.enabled = true;
			instance.a = a;
			instance.StartCoroutine(instance.CallCoroutine());
		}

		[DebuggerHidden]
		private IEnumerator CallCoroutine()
		{
			CoroutineCall.<CallCoroutine>c__Iterator32 <CallCoroutine>c__Iterator = new CoroutineCall.<CallCoroutine>c__Iterator32();
			<CallCoroutine>c__Iterator.<>f__this = this;
			return <CallCoroutine>c__Iterator;
		}
	}
}
