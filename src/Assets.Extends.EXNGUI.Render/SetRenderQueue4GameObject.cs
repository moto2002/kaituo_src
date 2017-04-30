using System;
using UnityEngine;

namespace Assets.Extends.EXNGUI.Render
{
	public class SetRenderQueue4GameObject : MonoBehaviour
	{
		public int Queue;

		public void Start()
		{
			this.ResetQueue();
		}

		public void ResetQueue()
		{
			Material[] sharedMaterials = base.GetComponent<Renderer>().sharedMaterials;
			for (int i = 0; i < sharedMaterials.Length; i++)
			{
				Material material = sharedMaterials[i];
				material.renderQueue = this.Queue;
			}
		}
	}
}
