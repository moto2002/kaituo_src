using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Tools.NGUI.Component
{
	public class GlobalGameObject : MonoBehaviour
	{
		public static Dictionary<string, GameObject> GlobalObjects = new Dictionary<string, GameObject>();

		public void Start()
		{
			GlobalGameObject.GlobalObjects.Add(base.gameObject.name, base.gameObject);
		}

		public void OnDestroy()
		{
			GlobalGameObject.GlobalObjects.Remove(base.gameObject.name);
		}
	}
}
