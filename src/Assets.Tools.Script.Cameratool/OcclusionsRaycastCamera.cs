using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Tools.Script.Cameratool
{
	public class OcclusionsRaycastCamera : MonoBehaviour
	{
		public GameObject target;

		public List<int> layers;

		private int _layer;

		private Dictionary<Collider, OcclusionsRaycastHandle> _intoLinecastTestHandles = new Dictionary<Collider, OcclusionsRaycastHandle>();

		private Dictionary<Collider, OcclusionsRaycastHandle> _curRaycastHits = new Dictionary<Collider, OcclusionsRaycastHandle>();

		private List<Collider> _clearLis = new List<Collider>();

		private void Awake()
		{
			this._layer = 0;
			if (this.layers == null)
			{
				this.layers = new List<int>();
			}
			foreach (int current in this.layers)
			{
				this._layer += 1 << current;
			}
			DebugConsole.Log(new object[]
			{
				"Layers->",
				this._layer
			});
		}

		private void Update()
		{
			RaycastHit[] array;
			if (this.layers.Count <= 0)
			{
				array = Physics.RaycastAll(this.target.transform.position, base.transform.position, float.PositiveInfinity);
			}
			else
			{
				array = Physics.RaycastAll(this.target.transform.position, base.transform.position, float.PositiveInfinity, this._layer);
			}
			this._curRaycastHits.Clear();
			this._clearLis.Clear();
			RaycastHit[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				RaycastHit raycastHit = array2[i];
				OcclusionsRaycastHandle component = raycastHit.collider.GetComponent<OcclusionsRaycastHandle>();
				if (component != null)
				{
					this._curRaycastHits.Add(raycastHit.collider, component);
				}
			}
			foreach (Collider current in this._intoLinecastTestHandles.Keys)
			{
				if (!this._curRaycastHits.ContainsKey(current))
				{
					this._clearLis.Add(current);
				}
			}
			foreach (Collider current2 in this._curRaycastHits.Keys)
			{
				if (!this._intoLinecastTestHandles.ContainsKey(current2))
				{
					this._curRaycastHits[current2].IntoLinecast();
					this._intoLinecastTestHandles.Add(current2, this._curRaycastHits[current2]);
				}
			}
			foreach (Collider current3 in this._clearLis)
			{
				if (!(this._intoLinecastTestHandles[current3] == null))
				{
					this._intoLinecastTestHandles[current3].OutLinecast();
					this._intoLinecastTestHandles.Remove(current3);
				}
			}
		}
	}
}
