using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Extends.EXNGUI.Animation
{
	public class TweenFadeInOut : MonoBehaviour
	{
		public List<UITweener> fadeInTweeners;

		public List<UITweener> fadeOutTweeners;

		private void Awake()
		{
			foreach (UITweener current in this.fadeInTweeners)
			{
				current.enabled = false;
			}
			foreach (UITweener current2 in this.fadeOutTweeners)
			{
				current2.enabled = false;
			}
		}

		public void FadeIn()
		{
			foreach (UITweener current in this.fadeInTweeners)
			{
				current.enabled = true;
				current.ResetToBeginning();
				current.PlayForward();
			}
		}

		public void FadeOut()
		{
			foreach (UITweener current in this.fadeOutTweeners)
			{
				current.enabled = true;
				current.ResetToBeginning();
				current.PlayForward();
			}
		}
	}
}
