using System;
using UnityEngine;

namespace Assets.Scripts.Tools.NGUI.Component
{
	public class UITweenTextureUV : UITweener
	{
		public Vector4 from;

		public Vector4 to;

		private UITexture uiTexture;

		public Rect value
		{
			set
			{
				if (this.uiTexture == null)
				{
					this.uiTexture = base.GetComponent<UITexture>();
				}
				this.uiTexture.uvRect = value;
			}
		}

		protected override void OnUpdate(float factor, bool isFinished)
		{
			Vector4 vector = this.from * (1f - factor) + this.to * factor;
			this.value = new Rect(vector.x, vector.y, vector.z, vector.w);
		}
	}
}
