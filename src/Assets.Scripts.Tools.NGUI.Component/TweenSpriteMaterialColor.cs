using System;
using UnityEngine;

namespace Assets.Scripts.Tools.NGUI.Component
{
	public class TweenSpriteMaterialColor : UITweener
	{
		public Color from = Color.white;

		public Color to = Color.white;

		private UISprite sprite;

		private Color color;

		public Color value
		{
			get
			{
				return this.color;
			}
			set
			{
				if (this.sprite == null)
				{
					this.sprite = base.GetComponent<UISprite>();
				}
				this.color = value;
				if (this.sprite != null)
				{
					if (this.sprite.drawCall != null)
					{
						this.sprite.drawCall.dynamicMaterial.SetColor("_Color", this.color);
					}
					if (this.sprite.material != null)
					{
						this.sprite.material.SetColor("_Color", this.color);
					}
				}
			}
		}

		protected override void OnUpdate(float factor, bool isFinished)
		{
			this.value = Color.Lerp(this.from, this.to, factor);
		}
	}
}
