using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Migration.Scripts.Action.Effect
{
	public class SwitchMaterialBehavior : MonoBehaviour
	{
		public Material ToMaterial;

		public float AutoRestoreSeconds;

		private Dictionary<Renderer, Material[]> originalMatsDict = new Dictionary<Renderer, Material[]>();

		private Material[] toMaterials = new Material[1];

		private LayerMask layerMask;

		private float swithTime;

		public void Switch(Material toMaterial, LayerMask layerMask, float autoRestoreSeconds)
		{
			if (toMaterial != null)
			{
				this.ToMaterial = toMaterial;
			}
			if (this.ToMaterial != null)
			{
				this.toMaterials[0] = toMaterial;
				this.layerMask = layerMask;
				this.AutoRestoreSeconds = autoRestoreSeconds;
				this.swithTime = Time.realtimeSinceStartup;
				Renderer[] componentsInChildren = base.gameObject.GetComponentsInChildren<Renderer>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					Renderer renderer = componentsInChildren[i];
					if (renderer.gameObject.IsInLayerMask(layerMask))
					{
						this.originalMatsDict[renderer] = renderer.sharedMaterials;
						renderer.sharedMaterials = this.toMaterials;
					}
				}
			}
		}

		public void Restore()
		{
			if (this.originalMatsDict.Count > 0)
			{
				Renderer[] componentsInChildren = base.gameObject.GetComponentsInChildren<Renderer>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					Renderer renderer = componentsInChildren[i];
					if (renderer.gameObject.IsInLayerMask(this.layerMask))
					{
						Material[] array = this.originalMatsDict[renderer];
						if (array != null)
						{
							renderer.sharedMaterials = array;
						}
					}
				}
				this.originalMatsDict.Clear();
			}
		}

		private void Update()
		{
			if (this.AutoRestoreSeconds > 0f)
			{
				float num = Time.realtimeSinceStartup - this.swithTime;
				if (num > this.AutoRestoreSeconds)
				{
					this.Restore();
					this.AutoRestoreSeconds = 0f;
				}
			}
		}
	}
}
