using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("Tween"), Name("Curve Tween")]
	public class CurveTransformTween : ActionTask<Transform>
	{
		public enum TransformMode
		{
			Position,
			Rotation,
			Scale
		}

		public enum TweenMode
		{
			Absolute,
			Additive
		}

		public enum PlayMode
		{
			Normal,
			PingPong
		}

		public CurveTransformTween.TransformMode transformMode;

		public CurveTransformTween.TweenMode mode;

		public CurveTransformTween.PlayMode playMode;

		public BBParameter<Vector3> targetPosition;

		public BBParameter<AnimationCurve> curve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

		public BBParameter<float> time = 0.5f;

		private Vector3 original;

		private Vector3 final;

		private bool ponging;

		protected override void OnExecute()
		{
			if (this.ponging)
			{
				this.final = this.original;
			}
			if (this.transformMode == CurveTransformTween.TransformMode.Position)
			{
				this.original = base.agent.localPosition;
			}
			if (this.transformMode == CurveTransformTween.TransformMode.Rotation)
			{
				this.original = base.agent.localEulerAngles;
			}
			if (this.transformMode == CurveTransformTween.TransformMode.Scale)
			{
				this.original = base.agent.localScale;
			}
			if (!this.ponging)
			{
				this.final = this.targetPosition.value + ((this.mode != CurveTransformTween.TweenMode.Additive) ? Vector3.zero : this.original);
			}
			this.ponging = (this.playMode == CurveTransformTween.PlayMode.PingPong);
			if ((this.original - this.final).magnitude < 0.1f)
			{
				base.EndAction();
			}
		}

		protected override void OnUpdate()
		{
			Vector3 vector = Vector3.Lerp(this.original, this.final, this.curve.value.Evaluate(base.elapsedTime / this.time.value));
			if (this.transformMode == CurveTransformTween.TransformMode.Position)
			{
				base.agent.localPosition = vector;
			}
			if (this.transformMode == CurveTransformTween.TransformMode.Rotation)
			{
				base.agent.localEulerAngles = vector;
			}
			if (this.transformMode == CurveTransformTween.TransformMode.Scale)
			{
				base.agent.localScale = vector;
			}
			if (base.elapsedTime >= this.time.value)
			{
				base.EndAction(new bool?(true));
			}
		}
	}
}
