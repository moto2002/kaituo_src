using System;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("NGUI/Interaction/Center Scroll View on Child")]
public class UICenterOnChild : MonoBehaviour
{
	public delegate void OnCenterCallback(GameObject centeredObject);

	public bool ignoreEnableRecenter;

	public float springStrength = 8f;

	public float nextPageThreshold;

	public SpringPanel.OnFinished onFinished;

	public UICenterOnChild.OnCenterCallback onCenter;

	public EventDelegate.Callback onEventChange;

	protected UIScrollView mScrollView;

	protected UIScrollCenterView mScrollCenterView;

	protected GameObject mCenteredObject;

	public GameObject centeredObject
	{
		get
		{
			return this.mCenteredObject;
		}
	}

	public void AddOnEventChange(EventDelegate.Callback del)
	{
		this.onEventChange = del;
	}

	protected virtual void Start()
	{
		this.Recenter();
		this.onFinished = delegate
		{
			if (this.onEventChange != null)
			{
				this.onEventChange();
			}
		};
	}

	protected virtual void OnEnable()
	{
		if (this.mScrollView)
		{
			this.mScrollView.centerOnChild = this;
			if (!this.ignoreEnableRecenter)
			{
				this.Recenter();
			}
		}
		if (this.mScrollCenterView)
		{
			this.mScrollCenterView.centerOnChild = this;
			if (!this.ignoreEnableRecenter)
			{
				this.Recenter();
			}
		}
	}

	protected virtual void OnDisable()
	{
		if (this.mScrollView)
		{
			this.mScrollView.centerOnChild = null;
		}
		if (this.mScrollCenterView)
		{
			this.mScrollCenterView.centerOnChild = null;
		}
	}

	protected virtual void OnDragFinished()
	{
		if (base.enabled)
		{
			this.Recenter();
		}
	}

	protected virtual void OnValidate()
	{
		this.nextPageThreshold = Mathf.Abs(this.nextPageThreshold);
	}

	protected virtual void initScrollView()
	{
		if (this.mScrollView || this.mScrollCenterView)
		{
			return;
		}
		UIPanel uIPanel = NGUITools.FindInParents<UIPanel>(base.gameObject);
		this.mScrollCenterView = uIPanel.GetComponent<UIScrollCenterView>();
		if (null == this.mScrollCenterView)
		{
			this.mScrollView = uIPanel.GetComponent<UIScrollView>();
			if (this.mScrollView != null)
			{
				this.mScrollView.centerOnChild = this;
				UIScrollView expr_79 = this.mScrollView;
				expr_79.onDragFinished = (UIScrollView.OnDragNotification)Delegate.Combine(expr_79.onDragFinished, new UIScrollView.OnDragNotification(this.OnDragFinished));
				if (this.mScrollView.horizontalScrollBar != null)
				{
					UIProgressBar expr_BC = this.mScrollView.horizontalScrollBar;
					expr_BC.onDragFinished = (UIProgressBar.OnDragFinished)Delegate.Combine(expr_BC.onDragFinished, new UIProgressBar.OnDragFinished(this.OnDragFinished));
				}
				if (this.mScrollView.verticalScrollBar != null)
				{
					UIProgressBar expr_FF = this.mScrollView.verticalScrollBar;
					expr_FF.onDragFinished = (UIProgressBar.OnDragFinished)Delegate.Combine(expr_FF.onDragFinished, new UIProgressBar.OnDragFinished(this.OnDragFinished));
				}
			}
		}
		else
		{
			this.mScrollCenterView.centerOnChild = this;
		}
		if (!this.mScrollCenterView && !this.mScrollView)
		{
			Debug.LogWarning(string.Concat(new object[]
			{
				base.GetType(),
				" requires ",
				typeof(UIScrollView),
				" or ",
				typeof(UIScrollCenterView),
				" on a parent object in order to work"
			}), this);
			base.enabled = false;
		}
	}

	[ContextMenu("Execute")]
	public virtual void Recenter()
	{
		this.initScrollView();
		Transform transform = base.transform;
		if (transform.childCount == 0)
		{
			return;
		}
		Vector3[] array = (!this.mScrollView) ? this.mScrollCenterView.panel.worldCorners : this.mScrollView.panel.worldCorners;
		Vector3 vector = (array[2] + array[0]) * 0.5f;
		float num = 3.40282347E+38f;
		Transform transform2 = null;
		int index = 0;
		int num2 = 0;
		UIGrid component = base.GetComponent<UIGrid>();
		List<Transform> list = null;
		if (component != null)
		{
			list = component.GetChildList();
			int i = 0;
			int count = list.Count;
			int num3 = 0;
			while (i < count)
			{
				Transform transform3 = list[i];
				if (transform3.gameObject.activeInHierarchy)
				{
					float sqrMagnitude = (transform3.position - vector).sqrMagnitude;
					if (sqrMagnitude < num)
					{
						num = sqrMagnitude;
						transform2 = transform3;
						index = i;
						num2 = num3;
					}
					num3++;
				}
				i++;
			}
		}
		else
		{
			int j = 0;
			int childCount = transform.childCount;
			int num4 = 0;
			while (j < childCount)
			{
				Transform child = transform.GetChild(j);
				if (child.gameObject.activeInHierarchy)
				{
					float sqrMagnitude2 = (child.position - vector).sqrMagnitude;
					if (sqrMagnitude2 < num)
					{
						num = sqrMagnitude2;
						transform2 = child;
						index = j;
						num2 = num4;
					}
					num4++;
				}
				j++;
			}
		}
		if (this.nextPageThreshold > 0f && UICamera.currentTouch != null && this.mCenteredObject != null && this.mCenteredObject.transform == ((list == null) ? transform.GetChild(index) : list[index]))
		{
			Vector3 point = UICamera.currentTouch.totalDelta;
			point = base.transform.rotation * point;
			UIScrollView.Movement movement = (!this.mScrollView) ? this.mScrollCenterView.movement : this.mScrollView.movement;
			float num5;
			if (movement != UIScrollView.Movement.Horizontal)
			{
				if (movement != UIScrollView.Movement.Vertical)
				{
					num5 = point.magnitude;
				}
				else
				{
					num5 = point.y;
				}
			}
			else
			{
				num5 = point.x;
			}
			if (Mathf.Abs(num5) > this.nextPageThreshold)
			{
				if (num5 > this.nextPageThreshold)
				{
					if (list != null)
					{
						if (num2 > 0)
						{
							transform2 = list[num2 - 1];
						}
						else
						{
							transform2 = ((!(base.GetComponent<UIWrapContent>() == null)) ? list[list.Count - 1] : list[0]);
						}
					}
					else if (num2 > 0)
					{
						transform2 = transform.GetChild(num2 - 1);
					}
					else
					{
						transform2 = ((!(base.GetComponent<UIWrapContent>() == null)) ? transform.GetChild(transform.childCount - 1) : transform.GetChild(0));
					}
				}
				else if (num5 < -this.nextPageThreshold)
				{
					if (list != null)
					{
						if (num2 < list.Count - 1)
						{
							transform2 = list[num2 + 1];
						}
						else
						{
							transform2 = ((!(base.GetComponent<UIWrapContent>() == null)) ? list[0] : list[list.Count - 1]);
						}
					}
					else if (num2 < transform.childCount - 1)
					{
						transform2 = transform.GetChild(num2 + 1);
					}
					else
					{
						transform2 = ((!(base.GetComponent<UIWrapContent>() == null)) ? transform.GetChild(0) : transform.GetChild(transform.childCount - 1));
					}
				}
			}
		}
		if (this.mScrollCenterView)
		{
			if (this.onCenter != null && transform2)
			{
				this.onCenter(transform2.gameObject);
			}
		}
		else
		{
			this.CenterOn(transform2, vector, false);
		}
	}

	protected virtual void CenterOn(Transform target, Vector3 panelCenter, bool immediately = false)
	{
		if (target != null)
		{
			UIPanel uIPanel = (!this.mScrollView) ? this.mScrollCenterView.panel : this.mScrollView.panel;
			Transform cachedTransform = uIPanel.cachedTransform;
			this.mCenteredObject = target.gameObject;
			Vector3 a = cachedTransform.InverseTransformPoint(target.position);
			Vector3 b = cachedTransform.InverseTransformPoint(panelCenter);
			Vector3 b2 = a - b;
			if (!((!this.mScrollView) ? this.mScrollCenterView.canMoveHorizontally : this.mScrollView.canMoveHorizontally))
			{
				b2.x = 0f;
			}
			if (!((!this.mScrollView) ? this.mScrollCenterView.canMoveVertically : this.mScrollView.canMoveVertically))
			{
				b2.y = 0f;
			}
			b2.z = 0f;
			if (immediately)
			{
				SpringPanel springPanel = SpringPanel.Begin(uIPanel.cachedGameObject, cachedTransform.localPosition - b2, this.springStrength);
				springPanel.onFinished = this.onFinished;
				springPanel.AdvanceTowardsPosition(1E+09f);
			}
			else
			{
				SpringPanel.Begin(uIPanel.cachedGameObject, cachedTransform.localPosition - b2, this.springStrength);
			}
		}
		else
		{
			this.mCenteredObject = null;
		}
		if (this.onCenter != null)
		{
			this.onCenter(this.mCenteredObject);
		}
	}

	public virtual void CenterOn(Transform target, bool immediately = false)
	{
		if (this.mScrollView || this.mScrollCenterView)
		{
			Vector3[] array = (!this.mScrollView) ? this.mScrollCenterView.panel.worldCorners : this.mScrollView.panel.worldCorners;
			Vector3 panelCenter = (array[2] + array[0]) * 0.5f;
			this.CenterOn(target, panelCenter, immediately);
		}
	}
}
