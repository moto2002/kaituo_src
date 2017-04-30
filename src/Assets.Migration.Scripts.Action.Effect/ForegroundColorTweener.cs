using Assets.Tools.Script.Caller;
using System;
using UnityEngine;

namespace Assets.Migration.Scripts.Action.Effect
{
	public class ForegroundColorTweener : MonoBehaviour
	{
		public Color ToColor;

		public Color FromColor;

		public float Duration;

		private float startTime;

		private Func<float, float, float, float> func;

		private Action onEnd;

		public void Play(float time, Color from, Color to, Action onTweenEnd)
		{
			this.onEnd = onTweenEnd;
			this.func = iTween.GetEaseFunction(iTween.EaseType.linear);
			this.FromColor = from;
			this.ToColor = to;
			this.startTime = Time.time;
			this.Duration = time;
			ForegroundBehavior.Instance.SetBackgroundColor(from);
			FrameCall.Call(new Func<bool>(this.OnUpdate));
		}

		protected bool OnUpdate()
		{
			float num = Time.time - this.startTime;
			if (num < this.Duration)
			{
				Color backgroundColor = default(Color);
				float arg = num / this.Duration;
				backgroundColor.r = this.func(this.FromColor.r, this.ToColor.r, arg);
				backgroundColor.g = this.func(this.FromColor.g, this.ToColor.g, arg);
				backgroundColor.b = this.func(this.FromColor.b, this.ToColor.b, arg);
				backgroundColor.a = this.func(this.FromColor.a, this.ToColor.a, arg);
				ForegroundBehavior.Instance.SetBackgroundColor(backgroundColor);
				return true;
			}
			ForegroundBehavior.Instance.SetBackgroundColor(this.ToColor);
			if (this.onEnd != null)
			{
				this.onEnd();
			}
			return false;
		}
	}
}
