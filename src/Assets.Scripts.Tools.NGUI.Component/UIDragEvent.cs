using System;
using UnityEngine;

namespace Assets.Scripts.Tools.NGUI.Component
{
	public class UIDragEvent : MonoBehaviour
	{
		public Action<Vector2> OnDragEnd;

		private Vector2 dragDelta;

		private bool started;

		private void OnPress(bool isPressed)
		{
			if (isPressed)
			{
				this.dragDelta = Vector2.zero;
			}
			else if (this.OnDragEnd != null)
			{
				this.OnDragEnd(this.dragDelta);
			}
		}

		private void OnDrag(Vector2 delta)
		{
			this.dragDelta += delta;
		}
	}
}
