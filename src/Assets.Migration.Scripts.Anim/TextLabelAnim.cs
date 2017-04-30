using System;
using System.Collections;
using UnityEngine;

namespace Assets.Migration.Scripts.Anim
{
	public class TextLabelAnim : MonoBehaviour
	{
		public UILabel Label;

		public Animation Animation;

		public void Show(string msg)
		{
			this.Label.text = msg;
			string animation = string.Empty;
			IEnumerator enumerator = this.Animation.GetEnumerator();
			try
			{
				if (enumerator.MoveNext())
				{
					AnimationState animationState = (AnimationState)enumerator.Current;
					animation = animationState.name;
					base.Invoke("OnEnd", animationState.length);
					this.Animation.Play(animation);
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
		}

		private void OnEnd()
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}
}
