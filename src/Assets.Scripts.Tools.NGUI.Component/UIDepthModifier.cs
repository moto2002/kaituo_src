using System;
using UnityEngine;

namespace Assets.Scripts.Tools.NGUI.Component
{
	public class UIDepthModifier : MonoBehaviour
	{
		private int depth;

		private UIWidget[] allWidgets;

		private int[] widgetDepths;

		public int Depth
		{
			get
			{
				return this.depth;
			}
			set
			{
				if (this.allWidgets == null)
				{
					this.UpdateWidget();
				}
				this.depth = value;
				for (int i = 0; i < this.allWidgets.Length; i++)
				{
					UIWidget uIWidget = this.allWidgets[i];
					uIWidget.depth = this.widgetDepths[i] + this.depth;
				}
			}
		}

		public void UpdateWidget()
		{
			this.allWidgets = base.GetComponentsInChildren<UIWidget>();
			this.widgetDepths = new int[this.allWidgets.Length];
			for (int i = 0; i < this.allWidgets.Length; i++)
			{
				UIWidget uIWidget = this.allWidgets[i];
				this.widgetDepths[i] = uIWidget.depth;
			}
		}
	}
}
