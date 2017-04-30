using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Tools.Script.Go
{
	public class ParasiticComponent : MonoBehaviour
	{
		private static GameObject _parasiteHost = null;

		private static readonly Dictionary<string, GameObject> _secondaryHosts = new Dictionary<string, GameObject>();

		public static GameObject parasiteHost
		{
			get
			{
				if (ParasiticComponent._parasiteHost == null)
				{
					ParasiticComponent._parasiteHost = new GameObject();
					ParasiticComponent._parasiteHost.transform.position = new Vector3(6874f, 9874f, 7514f);
					ParasiticComponent._parasiteHost.name = "Util_ParasiteHost";
					UnityEngine.Object.DontDestroyOnLoad(ParasiticComponent._parasiteHost);
				}
				return ParasiticComponent._parasiteHost;
			}
		}

		public static GameObject GetSecondaryHost(string name)
		{
			if (!ParasiticComponent._secondaryHosts.ContainsKey(name) || ParasiticComponent._secondaryHosts[name] == null)
			{
				GameObject gameObject = new GameObject();
				gameObject.transform.parent = ParasiticComponent.parasiteHost.transform;
				gameObject.transform.localPosition = Vector3.zero;
				gameObject.name = name;
				ParasiticComponent._secondaryHosts[name] = gameObject;
			}
			return ParasiticComponent._secondaryHosts[name];
		}

		public static T GetSecondaryHost<T>(string name) where T : Component
		{
			GameObject secondaryHost = ParasiticComponent.GetSecondaryHost(name);
			T t = secondaryHost.GetComponent<T>();
			if (t == null)
			{
				t = secondaryHost.AddComponent<T>();
			}
			return t;
		}
	}
}
