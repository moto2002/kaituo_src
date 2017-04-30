using System;
using UnityEngine;

namespace XQ.Framework.Lua
{
	public class GCPrefabScript : MonoBehaviour
	{
		public Transform TransCache;

		public void Awake()
		{
			this.TransCache = base.transform;
		}

		public void OnDestroy()
		{
			GameManager.ResManager.StartGCPrefabRes(this);
		}
	}
}
