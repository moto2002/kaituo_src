using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Tools.NGUI.Component
{
	public class UICenterOnChildV2 : UICenterOnChild
	{
		public delegate Transform OnDragFinishedCenter();

		public UICenterOnChildV2.OnDragFinishedCenter onDragFinishedCenter;

		protected override void Start()
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

		protected override void OnEnable()
		{
			if (this.mScrollView)
			{
				this.mScrollView.centerOnChild = this;
				if (!this.ignoreEnableRecenter)
				{
					this.Recenter();
				}
			}
		}

		protected override void OnDisable()
		{
			if (this.mScrollView)
			{
				this.mScrollView.centerOnChild = null;
			}
		}

		protected override void OnDragFinished()
		{
			if (base.enabled)
			{
				this.Recenter();
			}
		}

		protected override void OnValidate()
		{
			this.nextPageThreshold = Mathf.Abs(this.nextPageThreshold);
		}

		[ContextMenu("Execute")]
		public override void Recenter()
		{
			if (this.mScrollView == null)
			{
				this.mScrollView = NGUITools.FindInParents<UIScrollView>(base.gameObject);
				if (this.mScrollView == null)
				{
					Debug.LogWarning(string.Concat(new object[]
					{
						base.GetType(),
						" requires ",
						typeof(UIScrollView),
						" on a parent object in order to work"
					}), this);
					base.enabled = false;
					return;
				}
				if (this.mScrollView)
				{
					this.mScrollView.centerOnChild = this;
					UIScrollView expr_94 = this.mScrollView;
					expr_94.onDragFinished = (UIScrollView.OnDragNotification)Delegate.Combine(expr_94.onDragFinished, new UIScrollView.OnDragNotification(this.OnDragFinished));
				}
				if (this.mScrollView.horizontalScrollBar != null)
				{
					UIProgressBar expr_D7 = this.mScrollView.horizontalScrollBar;
					expr_D7.onDragFinished = (UIProgressBar.OnDragFinished)Delegate.Combine(expr_D7.onDragFinished, new UIProgressBar.OnDragFinished(this.OnDragFinished));
				}
				if (this.mScrollView.verticalScrollBar != null)
				{
					UIProgressBar expr_11A = this.mScrollView.verticalScrollBar;
					expr_11A.onDragFinished = (UIProgressBar.OnDragFinished)Delegate.Combine(expr_11A.onDragFinished, new UIProgressBar.OnDragFinished(this.OnDragFinished));
				}
			}
			if (this.mScrollView.panel == null)
			{
				return;
			}
			Transform transform = base.transform;
			if (transform.childCount == 0)
			{
				return;
			}
			if (this.onDragFinishedCenter != null)
			{
				Transform exists = this.onDragFinishedCenter();
				if (exists)
				{
				}
			}
			Vector3[] worldCorners = this.mScrollView.panel.worldCorners;
			Vector3 vector = (worldCorners[2] + worldCorners[0]) * 0.5f;
			Vector3 vector2 = this.mScrollView.currentMomentum * this.mScrollView.momentumAmount;
			Vector3 a = NGUIMath.SpringDampen(ref vector2, 9f, 2f);
			Vector3 b = vector - a * 0.01f;
			float num = 3.40282347E+38f;
			Transform target = null;
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
					Transform transform2 = list[i];
					if (transform2.gameObject.activeInHierarchy)
					{
						float num4 = Vector3.SqrMagnitude(transform2.position - b);
						if (num4 < num)
						{
							num = num4;
							target = transform2;
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
				int num5 = 0;
				while (j < childCount)
				{
					Transform child = transform.GetChild(j);
					if (child.gameObject.activeInHierarchy)
					{
						float num6 = Vector3.SqrMagnitude(child.position - b);
						if (num6 < num)
						{
							num = num6;
							target = child;
							index = j;
							num2 = num5;
						}
						num5++;
					}
					j++;
				}
			}
			if (this.nextPageThreshold > 0f && UICamera.currentTouch != null && this.mCenteredObject != null && this.mCenteredObject.transform == ((list == null) ? transform.GetChild(index) : list[index]))
			{
				Vector3 point = UICamera.currentTouch.totalDelta;
				point = base.transform.rotation * point;
				UIScrollView.Movement movement = this.mScrollView.movement;
				float num7;
				if (movement != UIScrollView.Movement.Horizontal)
				{
					if (movement != UIScrollView.Movement.Vertical)
					{
						num7 = point.magnitude;
					}
					else
					{
						num7 = point.y;
					}
				}
				else
				{
					num7 = point.x;
				}
				if (Mathf.Abs(num7) > this.nextPageThreshold)
				{
					if (num7 > this.nextPageThreshold)
					{
						if (list != null)
						{
							if (num2 > 0)
							{
								target = list[num2 - 1];
							}
							else
							{
								target = ((!(base.GetComponent<UIWrapContent>() == null)) ? list[list.Count - 1] : list[0]);
							}
						}
						else if (num2 > 0)
						{
							target = transform.GetChild(num2 - 1);
						}
						else
						{
							target = ((!(base.GetComponent<UIWrapContent>() == null)) ? transform.GetChild(transform.childCount - 1) : transform.GetChild(0));
						}
					}
					else if (num7 < -this.nextPageThreshold)
					{
						if (list != null)
						{
							if (num2 < list.Count - 1)
							{
								target = list[num2 + 1];
							}
							else
							{
								target = ((!(base.GetComponent<UIWrapContent>() == null)) ? list[0] : list[list.Count - 1]);
							}
						}
						else if (num2 < transform.childCount - 1)
						{
							target = transform.GetChild(num2 + 1);
						}
						else
						{
							target = ((!(base.GetComponent<UIWrapContent>() == null)) ? transform.GetChild(0) : transform.GetChild(transform.childCount - 1));
						}
					}
				}
			}
			this.CenterOn(target, vector, false);
		}

		protected override void CenterOn(Transform target, Vector3 panelCenter, bool immediately = false)
		{
			if (target != null && this.mScrollView != null && this.mScrollView.panel != null)
			{
				Transform cachedTransform = this.mScrollView.panel.cachedTransform;
				this.mCenteredObject = target.gameObject;
				Vector3 a = cachedTransform.InverseTransformPoint(target.position);
				Vector3 b = cachedTransform.InverseTransformPoint(panelCenter);
				Vector3 b2 = a - b;
				if (!this.mScrollView.canMoveHorizontally)
				{
					b2.x = 0f;
				}
				if (!this.mScrollView.canMoveVertically)
				{
					b2.y = 0f;
				}
				b2.z = 0f;
				if (immediately)
				{
					SpringPanel springPanel = SpringPanel.Begin(this.mScrollView.panel.cachedGameObject, cachedTransform.localPosition - b2, this.springStrength);
					springPanel.onFinished = this.onFinished;
					springPanel.AdvanceTowardsPosition(1E+09f);
				}
				else
				{
					SpringPanel.Begin(this.mScrollView.panel.cachedGameObject, cachedTransform.localPosition - b2, this.springStrength).onFinished = this.onFinished;
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

		public override void CenterOn(Transform target, bool immediately = false)
		{
			if (this.mScrollView != null && this.mScrollView.panel != null)
			{
				Vector3[] worldCorners = this.mScrollView.panel.worldCorners;
				Vector3 panelCenter = (worldCorners[2] + worldCorners[0]) * 0.5f;
				this.CenterOn(target, panelCenter, immediately);
			}
		}
	}
}
