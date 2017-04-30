using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Extends.EXNGUI.Render
{
	public abstract class SetRenderQueueOverSprite : MonoBehaviour
	{
		public UIWidget Sprite;

		public bool AffectMaterialSource;

		public bool AutoAdjust = true;

		public int QueueOffset;

		private int _currRenderQ;

		private List<Material> _materials;

		protected abstract void ReplaceMaterialToInstance();

		protected abstract List<Material> GetChangeMaterials();

		public void UpdateRenderQueue()
		{
			if (this.Sprite == null || this.Sprite.drawCall == null)
			{
				return;
			}
			int num = this.Sprite.drawCall.renderQueue + this.QueueOffset;
			if (this._currRenderQ == num)
			{
				return;
			}
			this._currRenderQ = num;
			if (this._materials == null)
			{
				this._materials = this.GetChangeMaterials();
			}
			for (int i = 0; i < this._materials.Count; i++)
			{
				Material material = this._materials[i];
				material.renderQueue = this._currRenderQ;
			}
		}

		protected virtual void Start()
		{
			if (!this.AffectMaterialSource)
			{
				this.ReplaceMaterialToInstance();
			}
			this.UpdateRenderQueue();
		}

		private void Update()
		{
			if (this.AutoAdjust)
			{
				this.UpdateRenderQueue();
			}
		}
	}
}
