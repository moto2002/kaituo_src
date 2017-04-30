using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Tools.NGUI.Camera
{
	public class SimpleCameraFade : MonoBehaviour
	{
		public UIPanel Panel;

		public TweenAlpha TweenIn;

		public TweenAlpha TweenOut;

		public UnityEvent OnFadeInEndEvent;

		private List<UICamera> cameras = new List<UICamera>();

		public void Awake()
		{
			this.TweenOut.onFinished.Add(new EventDelegate(new EventDelegate.Callback(this.OnFadeOutEnd)));
			this.TweenIn.onFinished.Add(new EventDelegate(new EventDelegate.Callback(this.OnFadeInEnd)));
		}

		public void FadeIn(float time)
		{
			if (UICamera.list != null)
			{
				foreach (UICamera current in UICamera.list)
				{
					current.enabled = false;
					this.cameras.Add(current);
				}
			}
			this.Panel.alpha = 0f;
			this.TweenIn.enabled = true;
			this.TweenIn.ResetToBeginning();
			this.TweenIn.from = 0f;
			this.TweenIn.to = 1f;
			this.TweenIn.duration = time;
			this.TweenIn.PlayForward();
		}

		public void FadeOut(float time)
		{
			this.Panel.alpha = 1f;
			this.TweenOut.enabled = true;
			this.TweenOut.ResetToBeginning();
			this.TweenOut.from = 1f;
			this.TweenOut.to = 0f;
			this.TweenOut.duration = time;
			this.TweenOut.PlayForward();
		}

		private void OnFadeInEnd()
		{
			this.Panel.alpha = 1f;
			this.OnFadeInEndEvent.Invoke();
		}

		private void OnFadeOutEnd()
		{
			foreach (UICamera current in this.cameras)
			{
				current.enabled = true;
			}
			this.cameras.Clear();
			base.gameObject.SetActive(false);
		}
	}
}
