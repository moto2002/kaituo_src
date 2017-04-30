using Assets.Tools.Script.Event;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

namespace Assets.Tools.Script.Animation.Curve
{
	public abstract class CurveAnimation : MonoBehaviour
	{
		public AnimationCurve curve;

		private bool _isForward;

		private bool _playing;

		public readonly Signal<CurveAnimation> onFinishSignal = new Signal<CurveAnimation>();

		private float _preFrameTime;

		private float _passTime;

		protected float endPassTime;

		protected WrapMode postWrapMode;

		protected float startPassTime;

		protected WrapMode preWrapMode;

		protected float cycleTime;

		public bool isForward
		{
			get
			{
				return this._isForward;
			}
		}

		public bool started
		{
			get
			{
				return this._playing || this.paused;
			}
		}

		public bool playing
		{
			get
			{
				return this._playing;
			}
		}

		public bool paused
		{
			get;
			private set;
		}

		public void Reset()
		{
			this.paused = false;
			this._playing = false;
			this._passTime = 0f;
		}

		public void Pause()
		{
			if (!this._playing)
			{
				return;
			}
			this.paused = true;
			this._playing = false;
			base.StopCoroutine("UpdateAnimation");
		}

		public void Finish()
		{
			if (!this._playing)
			{
				return;
			}
			this.paused = false;
			this._playing = false;
			base.StopCoroutine("UpdateAnimation");
			this.OnFinish();
			this.onFinishSignal.Dispatch(this);
		}

		public void Play(bool forward)
		{
			this._isForward = forward;
			if (this._playing)
			{
				return;
			}
			if (!this.paused)
			{
				this.endPassTime = this.curve.keys[this.curve.length - 1].time;
				this.postWrapMode = this.curve.postWrapMode;
				this.startPassTime = this.curve.keys[0].time;
				this.preWrapMode = this.curve.preWrapMode;
				this.cycleTime = this.endPassTime - this.startPassTime;
				this._passTime = 0f;
			}
			this._preFrameTime = Time.time;
			this.paused = false;
			this._playing = true;
			base.StartCoroutine("UpdateAnimation");
		}

		[ContextMenu("PlayForward")]
		public void PlayForward()
		{
			this.Play(true);
		}

		[ContextMenu("PlayReverse")]
		public void PlayReverse()
		{
			this.Play(false);
		}

		protected virtual void OnFinish()
		{
		}

		protected abstract void OnPlay(float time, float value);

		[DebuggerHidden]
		private IEnumerator UpdateAnimation()
		{
			CurveAnimation.<UpdateAnimation>c__IteratorF <UpdateAnimation>c__IteratorF = new CurveAnimation.<UpdateAnimation>c__IteratorF();
			<UpdateAnimation>c__IteratorF.<>f__this = this;
			return <UpdateAnimation>c__IteratorF;
		}
	}
}
