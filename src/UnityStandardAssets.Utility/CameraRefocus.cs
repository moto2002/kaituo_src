using System;
using UnityEngine;

namespace UnityStandardAssets.Utility
{
	public class CameraRefocus
	{
		public Camera Camera;

		public Vector3 Lookatpoint;

		public Transform Parent;

		private Vector3 m_OrigCameraPos;

		private bool m_Refocus;

		public CameraRefocus(Camera camera, Transform parent, Vector3 origCameraPos)
		{
			this.m_OrigCameraPos = origCameraPos;
			this.Camera = camera;
			this.Parent = parent;
		}

		public void ChangeCamera(Camera camera)
		{
			this.Camera = camera;
		}

		public void ChangeParent(Transform parent)
		{
			this.Parent = parent;
		}

		public void GetFocusPoint()
		{
			RaycastHit raycastHit;
			if (Physics.Raycast(this.Parent.transform.position + this.m_OrigCameraPos, this.Parent.transform.forward, out raycastHit, 100f))
			{
				this.Lookatpoint = raycastHit.point;
				this.m_Refocus = true;
				return;
			}
			this.m_Refocus = false;
		}

		public void SetFocusPoint()
		{
			if (this.m_Refocus)
			{
				this.Camera.transform.LookAt(this.Lookatpoint);
			}
		}
	}
}
