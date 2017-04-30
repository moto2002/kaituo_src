using System;
using UnityEngine;

namespace Assets.Scripts.Tools.NGUI.Component
{
	public class UIDragItem : UIDragDropItem
	{
		private static UIDragItem lastDragItem;

		private static GameObject lastSurface;

		public float RestrictionSensitivity = 1f;

		public Action<GameObject> OnStartDragItem;

		public Action<GameObject, GameObject> OnCloneItem;

		public Action<GameObject, GameObject, GameObject> OnDropItem;

		public Action<GameObject, GameObject> OnDragingItem;

		public Func<GameObject, GameObject> CloneHook;

		public Action<GameObject> DestroyCloneHook;

		public Func<GameObject, bool> CanDragHook;

		protected override void OnDragDropRelease(GameObject surface)
		{
			if (!this.cloneOnDrag)
			{
				if (this.mButton != null)
				{
					this.mButton.isEnabled = true;
				}
				else if (this.mCollider != null)
				{
					this.mCollider.enabled = true;
				}
				else if (this.mCollider2D != null)
				{
					this.mCollider2D.enabled = true;
				}
				UIDragDropContainer uIDragDropContainer = (!surface) ? null : NGUITools.FindInParents<UIDragDropContainer>(surface);
				if (uIDragDropContainer != null)
				{
					this.mTrans.parent = ((!(uIDragDropContainer.reparentTarget != null)) ? uIDragDropContainer.transform : uIDragDropContainer.reparentTarget);
					Vector3 localPosition = this.mTrans.localPosition;
					localPosition.z = 0f;
					this.mTrans.localPosition = localPosition;
				}
				else
				{
					this.mTrans.parent = this.mParent;
				}
				this.mParent = this.mTrans.parent;
				this.mGrid = NGUITools.FindInParents<UIGrid>(this.mParent);
				this.mTable = NGUITools.FindInParents<UITable>(this.mParent);
				if (this.mDragScrollView != null)
				{
					base.EnableDragScrollView();
				}
				NGUITools.MarkParentAsChanged(base.gameObject);
				if (this.mTable != null)
				{
					this.mTable.repositionNow = true;
				}
				if (this.mGrid != null)
				{
					this.mGrid.repositionNow = true;
				}
			}
			this.OnDragDropEnd();
			if (this.OnDropItem != null)
			{
				this.OnDropItem(UIDragItem.lastDragItem.gameObject, base.gameObject, surface);
			}
			UIDragItem.lastSurface = null;
			UIDragItem.lastDragItem = null;
			if (this.cloneOnDrag)
			{
				if (this.DestroyCloneHook != null)
				{
					this.DestroyCloneHook(base.gameObject);
				}
				else
				{
					NGUITools.Destroy(base.gameObject);
				}
			}
		}

		protected override void OnDragDropMove(Vector2 delta)
		{
			base.OnDragDropMove(delta);
			GameObject hoveredObject = UICamera.hoveredObject;
			if (hoveredObject != UIDragItem.lastSurface)
			{
				if (this.OnDragingItem != null)
				{
					this.OnDragingItem(base.gameObject, hoveredObject);
				}
				UIDragItem.lastSurface = hoveredObject;
			}
		}

		public override void StartDragging()
		{
			if (!this.interactable)
			{
				return;
			}
			if (this.CanDragHook != null && !this.CanDragHook(base.gameObject))
			{
				return;
			}
			UIDragItem.lastDragItem = this;
			if (this.OnStartDragItem != null)
			{
				this.OnStartDragItem(base.gameObject);
			}
			if (!this.mDragging)
			{
				if (this.cloneOnDrag)
				{
					this.mPressed = false;
					GameObject gameObject;
					if (this.CloneHook != null)
					{
						gameObject = this.CloneHook(base.gameObject);
					}
					else
					{
						gameObject = base.transform.parent.gameObject.AddChild(base.gameObject);
					}
					gameObject.transform.localPosition = base.transform.localPosition;
					gameObject.transform.localRotation = base.transform.localRotation;
					gameObject.transform.localScale = base.transform.localScale;
					UIButtonColor component = gameObject.GetComponent<UIButtonColor>();
					if (component != null)
					{
						component.defaultColor = base.GetComponent<UIButtonColor>().defaultColor;
					}
					if (this.mTouch != null && this.mTouch.pressed == base.gameObject)
					{
						this.mTouch.current = gameObject;
						this.mTouch.pressed = gameObject;
						this.mTouch.dragged = gameObject;
						this.mTouch.last = gameObject;
					}
					UIDragItem component2 = gameObject.GetComponent<UIDragItem>();
					component2.OnDragingItem = this.OnDragingItem;
					component2.OnDropItem = this.OnDropItem;
					component2.DestroyCloneHook = this.DestroyCloneHook;
					component2.mTouch = this.mTouch;
					component2.mPressed = true;
					component2.mDragging = true;
					component2.Start();
					component2.OnClone(base.gameObject);
					if (this.OnCloneItem != null)
					{
						this.OnCloneItem(base.gameObject, component2.gameObject);
					}
					component2.OnDragDropStart();
					if (UICamera.currentTouch == null)
					{
						UICamera.currentTouch = this.mTouch;
					}
					this.mTouch = null;
					UICamera.Notify(base.gameObject, "OnPress", false);
					UICamera.Notify(base.gameObject, "OnHover", false);
				}
				else
				{
					this.mDragging = true;
					this.OnDragDropStart();
				}
			}
		}

		protected override void OnDragStart()
		{
			if (!this.interactable)
			{
				return;
			}
			if (!base.enabled || this.mTouch != UICamera.currentTouch)
			{
				return;
			}
			DebugConsole.LogToChannel(13, "c#OnDragStart");
			if (this.restriction != UIDragDropItem.Restriction.None)
			{
				if (this.restriction == UIDragDropItem.Restriction.Horizontal)
				{
					Vector2 totalDelta = this.mTouch.totalDelta;
					if (Mathf.Abs(totalDelta.y / totalDelta.x) > this.RestrictionSensitivity)
					{
						return;
					}
				}
				else if (this.restriction == UIDragDropItem.Restriction.Vertical)
				{
					Vector2 totalDelta2 = this.mTouch.totalDelta;
					if (Mathf.Abs(totalDelta2.x / totalDelta2.y) > this.RestrictionSensitivity)
					{
						return;
					}
				}
				else if (this.restriction == UIDragDropItem.Restriction.PressAndHold)
				{
					return;
				}
			}
			this.StartDragging();
		}
	}
}
