using System;
using UnityEngine;

namespace XQ.Framework.Network.Skynet
{
	public class SocketDriverMono : MonoBehaviour
	{
		public static SocketDriverMono Instance;

		protected void Awake()
		{
			if (SocketDriverMono.Instance != null && SocketDriverMono.Instance != this && SocketDriverMono.Instance.gameObject != null)
			{
				UnityEngine.Object.DestroyImmediate(SocketDriverMono.Instance.gameObject);
			}
			SocketDriverMono.Instance = this;
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}

		protected void OnApplicationQuit()
		{
			SocketDriver.Stop();
		}

		protected void OnApplicationPause(bool pause)
		{
		}

		protected void OnDestroy()
		{
		}

		protected void Update()
		{
		}

		protected void OnLevelWasLoaded(int level)
		{
		}
	}
}
