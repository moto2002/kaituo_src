using System;
using UnityEngine;

namespace Assets.Scripts.Tools.NGUI.Component
{
	public class TweenSpriteMaterialFloat : UITweener
	{
		public float from = 1f;

		public float to = 1f;

		public string propertyName = string.Empty;

		private UISprite sprite;

		private Material spriteMaterial;

		private float floatValue;

		public float value
		{
			get
			{
				return this.floatValue;
			}
			set
			{
				if (this.sprite == null)
				{
					this.sprite = base.GetComponent<UISprite>();
					this.spriteMaterial = this.sprite.material;
				}
				this.floatValue = value;
				if (this.sprite != null)
				{
					if (this.sprite.drawCall != null)
					{
						this.sprite.drawCall.dynamicMaterial.SetFloat(this.propertyName, this.floatValue);
					}
					if (this.sprite.material != null)
					{
						this.sprite.material.SetFloat(this.propertyName, this.floatValue);
					}
				}
			}
		}

		protected override void OnUpdate(float factor, bool isFinished)
		{
			this.value = Mathf.Lerp(this.from, this.to, factor);
		}

		public void PlayFromCurrTo(float to)
		{
			if (this.sprite == null)
			{
				this.sprite = base.GetComponent<UISprite>();
				this.spriteMaterial = this.sprite.material;
			}
			this.to = to;
			this.from = this.spriteMaterial.GetFloat(this.propertyName);
			this.ResetToBeginning();
			base.PlayForward();
		}
	}
}
