using System;
using UnityEngine;

namespace Assets.Extends.EXNGUI.Compoment
{
	public class UIColorCtrl : MonoBehaviour
	{
		public UIWidget[] Children;

		public void SetColor(Color color)
		{
			for (int i = 0; i < this.Children.Length; i++)
			{
				UIWidget uIWidget = this.Children[i];
				uIWidget.color = color;
			}
		}

		public void SetColor(float r, float g, float b, float a)
		{
			this.SetColor(new Color(r, g, b, a));
		}
	}
}
