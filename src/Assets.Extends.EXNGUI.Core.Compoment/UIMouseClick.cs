using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Extends.EXNGUI.Core.Compoment
{
	public class UIMouseClick : MonoBehaviour
	{
		[HideInInspector]
		public List<EventDelegate> onClick = new List<EventDelegate>();

		private void OnClick()
		{
			EventDelegate.Execute(this.onClick);
		}
	}
}
