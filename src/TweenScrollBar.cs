using System;
using UnityEngine;

public class TweenScrollBar : UITweener
{
	[Range(0f, 1f)]
	public float from = 1f;

	[Range(0f, 1f)]
	public float to = 1f;

	private bool mCached;

	private UIScrollBar scrollBar;

	[Obsolete("Use 'value' instead")]
	public float alpha
	{
		get
		{
			return this.value;
		}
		set
		{
			this.value = value;
		}
	}

	public float value
	{
		get
		{
			if (!this.mCached)
			{
				this.Cache();
			}
			return this.scrollBar.value;
		}
		set
		{
			if (!this.mCached)
			{
				this.Cache();
			}
			this.scrollBar.value = value;
		}
	}

	private void Cache()
	{
		this.mCached = true;
		this.scrollBar = base.GetComponent<UIScrollBar>();
		if (this.scrollBar == null)
		{
			this.scrollBar = base.GetComponentInChildren<UIScrollBar>();
		}
	}

	protected override void OnUpdate(float factor, bool isFinished)
	{
		this.value = Mathf.Lerp(this.from, this.to, factor);
	}

	public static TweenScrollBar Begin(GameObject go, float duration, float alpha)
	{
		TweenScrollBar tweenScrollBar = UITweener.Begin<TweenScrollBar>(go, duration);
		tweenScrollBar.from = tweenScrollBar.value;
		tweenScrollBar.to = alpha;
		if (duration <= 0f)
		{
			tweenScrollBar.Sample(1f, true);
			tweenScrollBar.enabled = false;
		}
		return tweenScrollBar;
	}

	public override void SetStartToCurrentValue()
	{
		this.from = this.value;
	}

	public override void SetEndToCurrentValue()
	{
		this.to = this.value;
	}
}
