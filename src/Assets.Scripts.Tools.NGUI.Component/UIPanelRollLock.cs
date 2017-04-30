using Assets.Tools.Script.Helper;
using System;
using UnityEngine;

namespace Assets.Scripts.Tools.NGUI.Component
{
	public class UIPanelRollLock : MonoBehaviour
	{
		private UIPanel panel;

		private Transform panelTransform;

		private Transform lockAnchor;

		private Vector3 lockAnchorPosition;

		public static void Lock(UIPanel panel, GameObject anchor)
		{
			UIPanelRollLock uIPanelRollLock = panel.gameObject.GetComponent<UIPanelRollLock>();
			if (uIPanelRollLock == null)
			{
				uIPanelRollLock = panel.gameObject.AddComponent<UIPanelRollLock>();
			}
			if (uIPanelRollLock.panel == panel && uIPanelRollLock.lockAnchor == anchor.transform && uIPanelRollLock.enabled)
			{
				return;
			}
			uIPanelRollLock.panel = panel;
			uIPanelRollLock.panelTransform = panel.transform;
			uIPanelRollLock.lockAnchor = anchor.transform;
			uIPanelRollLock.lockAnchorPosition = anchor.transform.localPosition;
			uIPanelRollLock.enabled = true;
		}

		public static void Unlock(UIPanel panel)
		{
			UIPanelRollLock component = panel.gameObject.GetComponent<UIPanelRollLock>();
			if (component != null)
			{
				component.enabled = false;
				component.panel = null;
				component.panelTransform = null;
				component.lockAnchor = null;
			}
		}

		public void LateUpdate()
		{
			if (this.lockAnchor != null)
			{
				Vector3 vector = this.lockAnchor.localPosition - this.lockAnchorPosition;
				this.panelTransform.SetLocalPositionX(this.panelTransform.localPosition.x - vector.x);
				this.panel.clipOffset = new Vector2(this.panel.clipOffset.x + vector.x, this.panel.clipOffset.y);
				this.lockAnchorPosition = this.lockAnchor.localPosition;
			}
		}
	}
}
