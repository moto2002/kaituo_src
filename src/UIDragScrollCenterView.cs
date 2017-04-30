using System;
using UnityEngine;

public class UIDragScrollCenterView : MonoBehaviour
{
	public UIScrollCenterView scrollView;

	[HideInInspector, SerializeField]
	private UIScrollCenterView draggablePanel;

	private Transform mTrans;

	private UIScrollCenterView mScroll;

	private bool mAutoFind;

	private bool mStarted;

	[NonSerialized]
	private bool mPressed;

	private void OnEnable()
	{
		this.mTrans = base.transform;
		if (this.scrollView == null && this.draggablePanel != null)
		{
			this.scrollView = this.draggablePanel;
			this.draggablePanel = null;
		}
		if (this.mStarted && (this.mAutoFind || this.mScroll == null))
		{
			this.FindScrollView();
		}
	}

	private void Start()
	{
		this.mStarted = true;
		this.FindScrollView();
	}

	private void FindScrollView()
	{
		UIScrollCenterView uIScrollCenterView = NGUITools.FindInParents<UIScrollCenterView>(this.mTrans);
		if (this.scrollView == null || (this.mAutoFind && uIScrollCenterView != this.scrollView))
		{
			this.scrollView = uIScrollCenterView;
			this.mAutoFind = true;
		}
		else if (this.scrollView == uIScrollCenterView)
		{
			this.mAutoFind = true;
		}
		this.mScroll = this.scrollView;
	}

	private void OnDisable()
	{
		if (this.mPressed && this.mScroll != null && this.mScroll.GetComponentInChildren<UIWrapContent>() == null)
		{
			this.mScroll.Press(false);
			this.mScroll = null;
		}
	}

	public void OnPress(bool pressed)
	{
		this.mPressed = pressed;
		if (this.mAutoFind && this.mScroll != this.scrollView)
		{
			this.mScroll = this.scrollView;
			this.mAutoFind = false;
		}
		if (this.scrollView && base.enabled && NGUITools.GetActive(base.gameObject))
		{
			this.scrollView.Press(pressed);
			if (!pressed && this.mAutoFind)
			{
				this.scrollView = NGUITools.FindInParents<UIScrollCenterView>(this.mTrans);
				this.mScroll = this.scrollView;
			}
		}
	}

	private void OnDrag(Vector2 delta)
	{
		if (this.scrollView && NGUITools.GetActive(this))
		{
			this.scrollView.Drag();
		}
	}
}
