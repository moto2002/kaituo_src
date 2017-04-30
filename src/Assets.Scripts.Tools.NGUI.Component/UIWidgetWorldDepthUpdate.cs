using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Tools.NGUI.Component
{
	[ExecuteInEditMode]
	public class UIWidgetWorldDepthUpdate : MonoBehaviour
	{
		public float ZeroDepth;

		public float DepthOffset = 1f;

		public float BeginDepth;

		public List<UIWidget> Widgets;

		public Transform TestObject;

		private float lastDepth = -3.40282347E+38f;

		public void Start()
		{
			if (this.TestObject == null)
			{
				this.TestObject = base.transform;
			}
			if (this.Widgets == null)
			{
				this.Widgets = new List<UIWidget>();
			}
		}

		public void Update()
		{
			if (Math.Abs(this.TestObject.localPosition.y - this.lastDepth) > 0.0001f)
			{
				int depth = (int)(this.BeginDepth - (this.TestObject.localPosition.y - this.ZeroDepth) / this.DepthOffset);
				for (int i = this.Widgets.Count - 1; i >= 0; i--)
				{
					this.Widgets[i].depth = depth;
				}
				this.lastDepth = this.TestObject.localPosition.y;
			}
		}
	}
}
