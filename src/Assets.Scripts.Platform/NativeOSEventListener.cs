using System;
using UnityEngine;

namespace Assets.Scripts.Platform
{
	public class NativeOSEventListener : MonoBehaviour
	{
		public Action<string> Handler;

		public void WrapMessage(string msg)
		{
			this.Handler(msg);
		}

		private void Start()
		{
			DebugConsole.Log(new object[]
			{
				"Listener",
				base.name,
				"started"
			});
		}

		private void OnDestroy()
		{
			DebugConsole.Log(new object[]
			{
				"Listener",
				base.name,
				"removed"
			});
			this.Handler = null;
		}
	}
}
