using System;
using UnityEngine;

namespace Assets.Scripts.Tools.NGUI.Component
{
	public class SpringPositionNoScrollBar : MonoBehaviour
	{
		public delegate void OnFinished();

		public static SpringPositionNoScrollBar current;

		public Vector3 target = Vector3.zero;

		public float strength = 10f;

		public bool worldSpace;

		public bool ignoreTimeScale;

		public bool updateScrollView;

		public SpringPositionNoScrollBar.OnFinished onFinished;

		[HideInInspector, SerializeField]
		private GameObject eventReceiver;

		[HideInInspector, SerializeField]
		public string callWhenFinished;

		private Transform mTrans;

		private float mThreshold;

		private void Start()
		{
			this.mTrans = base.transform;
		}

		private void Update()
		{
			float deltaTime = (!this.ignoreTimeScale) ? Time.deltaTime : RealTime.deltaTime;
			if (this.worldSpace)
			{
				if (this.mThreshold == 0f)
				{
					this.mThreshold = (this.target - this.mTrans.position).sqrMagnitude * 0.001f;
				}
				this.mTrans.position = NGUIMath.SpringLerp(this.mTrans.position, this.target, this.strength, deltaTime);
				if (this.mThreshold >= (this.target - this.mTrans.position).sqrMagnitude)
				{
					this.mTrans.position = this.target;
					this.NotifyListeners();
					base.enabled = false;
				}
			}
			else
			{
				if (this.mThreshold == 0f)
				{
					this.mThreshold = (this.target - this.mTrans.localPosition).sqrMagnitude * 1E-05f;
				}
				this.mTrans.localPosition = NGUIMath.SpringLerp(this.mTrans.localPosition, this.target, this.strength, deltaTime);
				if (this.mThreshold >= (this.target - this.mTrans.localPosition).sqrMagnitude)
				{
					this.mTrans.localPosition = this.target;
					this.NotifyListeners();
					base.enabled = false;
				}
			}
		}

		private void NotifyListeners()
		{
			SpringPositionNoScrollBar.current = this;
			if (this.onFinished != null)
			{
				this.onFinished();
			}
			if (this.eventReceiver != null && !string.IsNullOrEmpty(this.callWhenFinished))
			{
				this.eventReceiver.SendMessage(this.callWhenFinished, this, SendMessageOptions.DontRequireReceiver);
			}
			SpringPositionNoScrollBar.current = null;
		}

		public static SpringPositionNoScrollBar Begin(GameObject go, Vector3 pos, float strength)
		{
			SpringPositionNoScrollBar springPositionNoScrollBar = go.GetComponent<SpringPositionNoScrollBar>();
			if (springPositionNoScrollBar == null)
			{
				springPositionNoScrollBar = go.AddComponent<SpringPositionNoScrollBar>();
			}
			springPositionNoScrollBar.target = pos;
			springPositionNoScrollBar.strength = strength;
			springPositionNoScrollBar.onFinished = null;
			if (!springPositionNoScrollBar.enabled)
			{
				springPositionNoScrollBar.mThreshold = 0f;
				springPositionNoScrollBar.enabled = true;
			}
			return springPositionNoScrollBar;
		}
	}
}
