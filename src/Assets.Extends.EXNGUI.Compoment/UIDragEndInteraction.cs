using Assets.Extends.EXNGUI.Core.Input;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Extends.EXNGUI.Compoment
{
	public class UIDragEndInteraction : EventDelegateFunction
	{
		private static readonly Dictionary<int, UIDragEndInteraction> _uiDragEndInteractionGroup = new Dictionary<int, UIDragEndInteraction>();

		public int group;

		public bool isMainInGroup = true;

		private bool _draging;

		private Vector3 _startPoint;

		[HideInInspector]
		public Vector3 offset;

		private void Start()
		{
			if (this.isMainInGroup && !UIDragEndInteraction._uiDragEndInteractionGroup.ContainsKey(this.group))
			{
				UIDragEndInteraction._uiDragEndInteractionGroup.Add(this.group, this);
			}
		}

		public void OnDrag(Vector2 delta)
		{
			if (this.isMainInGroup)
			{
				if (!this._draging)
				{
					this._startPoint = Input.mousePosition;
					this._draging = true;
				}
			}
			else if (UIDragEndInteraction._uiDragEndInteractionGroup.ContainsKey(this.group))
			{
				UIDragEndInteraction._uiDragEndInteractionGroup[this.group].OnDrag(delta);
			}
		}

		public void OnDragEnd()
		{
			if (this.isMainInGroup)
			{
				this._draging = false;
				this.offset = this._startPoint - Input.mousePosition;
				EventDelegate.Execute(this.EventDelegates);
			}
			else if (UIDragEndInteraction._uiDragEndInteractionGroup.ContainsKey(this.group))
			{
				UIDragEndInteraction._uiDragEndInteractionGroup[this.group].OnDragEnd();
			}
		}

		private void OnDestroy()
		{
			if (this.isMainInGroup)
			{
				UIDragEndInteraction._uiDragEndInteractionGroup.Remove(this.group);
			}
		}
	}
}
