using System;
using UnityEngine;

namespace Assets.Tools.Script.Event
{
	public class ApplicationEvent : MonoBehaviour
	{
		public static Action OnAwake;

		public static Action OnRestore;

		public static Action OnPause;

		public static Action OnQuit;

		public static Action OnEsc;

		private void Awake()
		{
			if (ApplicationEvent.OnAwake != null)
			{
				ApplicationEvent.OnAwake();
			}
		}

		private void OnApplicationQuit()
		{
			if (ApplicationEvent.OnQuit != null)
			{
				ApplicationEvent.OnQuit();
			}
		}

		private void OnApplicationPause(bool pause)
		{
			if (pause)
			{
				if (ApplicationEvent.OnPause != null)
				{
					ApplicationEvent.OnPause();
				}
			}
			else if (ApplicationEvent.OnRestore != null)
			{
				ApplicationEvent.OnRestore();
			}
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Escape) && ApplicationEvent.OnEsc != null)
			{
				ApplicationEvent.OnEsc();
			}
		}
	}
}
