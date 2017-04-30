using System;
using UnityEngine;

namespace Assets.Tools.Script.Event
{
	public class NativeEventToSignal : MonoBehaviour
	{
		public SimpleSignal OnNativeEvent = new SimpleSignal();

		public void UnityNativeEvent()
		{
			this.OnNativeEvent.Dispatch();
		}
	}
}
