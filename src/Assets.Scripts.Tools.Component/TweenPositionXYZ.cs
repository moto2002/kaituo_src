using Assets.Tools.Script.Animation.Curve;
using System;
using UnityEngine;

namespace Assets.Scripts.Tools.Component
{
	public class TweenPositionXYZ : CurveAnimation
	{
		public AnimationCurve CurveY;

		public AnimationCurve CurveZ;

		public Transform Target;

		public Vector3 From;

		public Vector3 To;

		private Action onEndCallBack;

		public void PlayWithEnd(Vector3 from, Vector3 to, Action onEnd)
		{
			this.From = from;
			this.To = to;
			this.onEndCallBack = onEnd;
			base.PlayForward();
		}

		protected override void OnFinish()
		{
			if (this.onEndCallBack != null)
			{
				Action action = this.onEndCallBack;
				this.onEndCallBack = null;
				action();
			}
		}

		protected override void OnPlay(float time, float value)
		{
			float num = this.CurveY.Evaluate(time);
			float num2 = this.CurveZ.Evaluate(time);
			float x = this.From.x * (1f - value) + this.To.x * value;
			float y = this.From.y * (1f - num) + this.To.y * num;
			float z = this.From.y * (1f - num2) + this.To.z * num2;
			this.Target.localPosition = new Vector3(x, y, z);
		}
	}
}
