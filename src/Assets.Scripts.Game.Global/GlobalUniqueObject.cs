using Assets.Tools.Script.Go;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game.Global
{
	public class GlobalUniqueObject : MonoBehaviour
	{
		public static GlobalUniqueObject Instance;

		private static Dictionary<string, object> GlobalVariables = new Dictionary<string, object>();

		public static void Init()
		{
			if (GlobalUniqueObject.Instance == null)
			{
				GameObject original = Resources.Load<GameObject>("GlobalObject");
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(original);
				gameObject.transform.parent = ParasiticComponent.parasiteHost.transform;
				UnityEngine.Object.DontDestroyOnLoad(gameObject);
				GlobalUniqueObject.Instance = gameObject.GetComponent<GlobalUniqueObject>();
			}
		}

		public static void AddVariable(string variableName, object value)
		{
			GlobalUniqueObject.GlobalVariables[variableName] = value;
		}

		public static int GetIntValue(string variableName)
		{
			return GlobalUniqueObject.GetValue<int>(variableName);
		}

		public static float GetFloatValue(string variableName)
		{
			return GlobalUniqueObject.GetValue<float>(variableName);
		}

		public static string GetStringValue(string variableName)
		{
			return GlobalUniqueObject.GetValue<string>(variableName);
		}

		public static T GetValue<T>(string variableName)
		{
			object obj;
			bool flag = GlobalUniqueObject.GlobalVariables.TryGetValue(variableName, out obj);
			if (flag)
			{
				return (T)((object)obj);
			}
			return default(T);
		}

		private void Start()
		{
			Screen.sleepTimeout = -1;
			GlobalUniqueObject.Init();
		}
	}
}
