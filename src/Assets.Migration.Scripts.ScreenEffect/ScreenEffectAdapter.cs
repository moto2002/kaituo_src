using System;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

namespace Assets.Migration.Scripts.ScreenEffect
{
	public class ScreenEffectAdapter : MonoBehaviour
	{
		public bool AdaptBlur;

		public float BlurDownsample;

		public float BlurBlurIterations;

		public bool AdaptBloom;

		public float BloomBlurIterations;

		private BlurOptimized blurEffect;

		private BloomOptimized bloomEffect;

		private void Awake()
		{
			if (this.AdaptBlur)
			{
				this.blurEffect = base.GetComponent<BlurOptimized>();
				if (this.blurEffect != null)
				{
					this.BlurDownsample = (float)this.blurEffect.downsample;
					this.BlurBlurIterations = (float)this.blurEffect.blurIterations;
				}
			}
			if (this.AdaptBloom)
			{
				this.bloomEffect = base.GetComponent<BloomOptimized>();
				if (this.bloomEffect != null)
				{
					this.BloomBlurIterations = (float)this.bloomEffect.blurIterations;
				}
			}
		}

		private void Update()
		{
			if (this.AdaptBlur && this.blurEffect != null)
			{
				this.blurEffect.downsample = ScreenEffectAdapter.Clamp((int)this.BlurDownsample, 0, 2);
				this.blurEffect.blurIterations = ScreenEffectAdapter.Clamp((int)this.BlurBlurIterations, 1, 4);
			}
			if (this.AdaptBloom && this.bloomEffect != null)
			{
				this.bloomEffect.blurIterations = ScreenEffectAdapter.Clamp((int)this.BloomBlurIterations, 1, 4);
			}
		}

		private static int Clamp(int value, int min, int max)
		{
			return (value >= min) ? ((value <= max) ? value : max) : min;
		}
	}
}
