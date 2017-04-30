using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Platform.IOS
{
	public class IOSBridge : MonoBehaviour
	{
		public static IOSBridge Instance;

		private static Dictionary<string, GameObject> wrapListeners = new Dictionary<string, GameObject>();

		private static void _IsWXAppInstalled()
		{
		}

		public static void IsWXAppInstalled()
		{
			IOSBridge._IsWXAppInstalled();
		}

		private static void _WXLogin()
		{
		}

		public static void WXLogin()
		{
			IOSBridge._WXLogin();
		}

		private static void _SetupIOSBridge(string objectName)
		{
		}

		public static void AddEventListener(string eventName, Action<string> handler)
		{
			if (!IOSBridge.wrapListeners.ContainsKey(eventName))
			{
				GameObject gameObject = new GameObject(string.Format("{0}_{1}", IOSBridge.Instance.name, eventName));
				NativeOSEventListener nativeOSEventListener = gameObject.AddComponent<NativeOSEventListener>();
				nativeOSEventListener.Handler = handler;
				gameObject.transform.parent = IOSBridge.Instance.transform;
				IOSBridge.wrapListeners.Add(eventName, gameObject);
			}
		}

		public static void RemoveEventListener(string eventName)
		{
			GameObject obj;
			bool flag = IOSBridge.wrapListeners.TryGetValue(eventName, out obj);
			if (flag)
			{
				UnityEngine.Object.Destroy(obj);
				IOSBridge.wrapListeners.Remove(eventName);
			}
		}

		private void Awake()
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}

		public void IOSBridgeLog(string msg)
		{
			DebugConsole.Log(msg);
		}
	}
}
