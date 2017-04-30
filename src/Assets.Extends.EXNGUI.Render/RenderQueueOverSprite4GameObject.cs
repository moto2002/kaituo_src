using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Extends.EXNGUI.Render
{
	public class RenderQueueOverSprite4GameObject : SetRenderQueueOverSprite
	{
		public GameObject toChangeGameObject;

		private Renderer _toChangeRenderer;

		private Renderer toChangeRenderer
		{
			get
			{
				if (this._toChangeRenderer == null)
				{
					this._toChangeRenderer = this.toChangeGameObject.GetComponent<Renderer>();
				}
				return this._toChangeRenderer;
			}
		}

		protected void Awake()
		{
			if (this.toChangeGameObject == null)
			{
				this.toChangeGameObject = base.gameObject;
			}
		}

		protected override void ReplaceMaterialToInstance()
		{
			Material[] array = new Material[this.toChangeRenderer.sharedMaterials.Length];
			for (int i = 0; i < this.toChangeRenderer.sharedMaterials.Length; i++)
			{
				array[i] = UnityEngine.Object.Instantiate<Material>(this.toChangeRenderer.sharedMaterials[i]);
			}
			this.toChangeRenderer.sharedMaterials = array;
		}

		protected override List<Material> GetChangeMaterials()
		{
			return this.toChangeRenderer.materials.ToList<Material>();
		}
	}
}
