using System;
using System.Collections.Generic;
using UnityEngine;

namespace ParadoxNotion.Services
{
	public class MonoManager : MonoBehaviour
	{
		private readonly List<Action> updateMethods = new List<Action>();

		private readonly List<Action> guiMethods = new List<Action>();

		private static bool isQuiting;

		private static MonoManager _current;

		public static MonoManager current
		{
			get
			{
				if (MonoManager._current == null && !MonoManager.isQuiting)
				{
					MonoManager._current = UnityEngine.Object.FindObjectOfType<MonoManager>();
					if (MonoManager._current == null)
					{
						MonoManager._current = new GameObject("_MonoManager").AddComponent<MonoManager>();
					}
				}
				return MonoManager._current;
			}
		}

		public static void Create()
		{
			MonoManager._current = MonoManager.current;
		}

		public static void AddMethod(Action method)
		{
			MonoManager.current.updateMethods.Add(method);
		}

		public static void RemoveMethod(Action method)
		{
			MonoManager.current.updateMethods.Remove(method);
		}

		public static void AddGUIMethod(Action method)
		{
			MonoManager.current.guiMethods.Add(method);
		}

		public static void RemoveGUIMethod(Action method)
		{
			MonoManager.current.guiMethods.Remove(method);
		}

		private void Awake()
		{
			if (MonoManager._current != null && MonoManager._current != this)
			{
				UnityEngine.Object.DestroyImmediate(base.gameObject);
				return;
			}
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			MonoManager._current = this;
		}

		private void Update()
		{
			for (int i = 0; i < this.updateMethods.Count; i++)
			{
				this.updateMethods[i]();
			}
		}

		private void OnGUI()
		{
			for (int i = 0; i < this.guiMethods.Count; i++)
			{
				this.guiMethods[i]();
			}
		}

		private void OnApplicationQuit()
		{
			MonoManager.isQuiting = true;
		}
	}
}
