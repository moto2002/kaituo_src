using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Platform.Android
{
	public class AndroidBridge : MonoBehaviour
	{
		public static AndroidBridge Instance;

		private static readonly Dictionary<string, AndroidJavaClass> javaClasses = new Dictionary<string, AndroidJavaClass>();

		private static readonly Dictionary<string, GameObject> wrapListeners = new Dictionary<string, GameObject>();

		private static readonly AndroidJavaClass U3D_CLASS = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

		[NoToLua]
		public static AndroidJavaClass InitU3DActivityToStatic(string clz, string method)
		{
			AndroidJavaObject @static = AndroidBridge.U3D_CLASS.GetStatic<AndroidJavaObject>("currentActivity");
			AndroidJavaClass @class = AndroidBridge.GetClass(clz);
			@class.CallStatic(method, new object[]
			{
				@static
			});
			return @class;
		}

		public static void CallStatic(string className, string methodName, string arg)
		{
			AndroidJavaClass @class = AndroidBridge.GetClass(className);
			@class.CallStatic(methodName, new object[]
			{
				arg
			});
		}

		public static void Call(AndroidJavaObject javaObject, string methodName, string arg)
		{
			javaObject.Call(methodName, new object[]
			{
				arg
			});
		}

		public static AndroidJavaObject GetStatic(string className, string fieldName)
		{
			AndroidJavaClass @class = AndroidBridge.GetClass(className);
			return @class.GetStatic<AndroidJavaObject>(fieldName);
		}

		public static AndroidJavaClass GetClass(string className)
		{
			AndroidJavaClass androidJavaClass;
			if (!AndroidBridge.javaClasses.TryGetValue(className, out androidJavaClass))
			{
				androidJavaClass = new AndroidJavaClass(className);
				AndroidBridge.javaClasses.Add(className, androidJavaClass);
			}
			return androidJavaClass;
		}

		public static void AddEventListener(string eventName, Action<string> handler)
		{
			if (!AndroidBridge.wrapListeners.ContainsKey(eventName))
			{
				GameObject gameObject = new GameObject(string.Format("{0}_{1}", AndroidBridge.Instance.name, eventName));
				NativeOSEventListener nativeOSEventListener = gameObject.AddComponent<NativeOSEventListener>();
				nativeOSEventListener.Handler = handler;
				gameObject.transform.parent = AndroidBridge.Instance.transform;
				AndroidBridge.wrapListeners.Add(eventName, gameObject);
			}
		}

		public static void RemoveEventListener(string eventName)
		{
			GameObject obj;
			bool flag = AndroidBridge.wrapListeners.TryGetValue(eventName, out obj);
			if (flag)
			{
				UnityEngine.Object.Destroy(obj);
				AndroidBridge.wrapListeners.Remove(eventName);
			}
		}

		private void Start()
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}

		public void AndroidBridgeLog(string msg)
		{
			DebugConsole.Log(msg);
		}
	}
}
