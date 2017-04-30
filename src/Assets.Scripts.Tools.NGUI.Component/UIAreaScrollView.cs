using System;
using UnityEngine;

namespace Assets.Scripts.Tools.NGUI.Component
{
	public class UIAreaScrollView : UIScrollView
	{
		public Bounds ScrollBounds;

		public override Bounds bounds
		{
			get
			{
				return this.ScrollBounds;
			}
		}
	}
}
