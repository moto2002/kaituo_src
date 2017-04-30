using System;
using UnityEngine;

namespace Assets.Extends.EXNGUI.Compoment
{
	public class UIPopupListLabel : MonoBehaviour
	{
		public UILabel Label;

		public UIPopupList PoplList;

		public void Start()
		{
			this.Label.text = this.PoplList.value;
			this.PoplList.onChange.Add(new EventDelegate(new EventDelegate.Callback(this.OnChange)));
		}

		private void OnChange()
		{
			this.Label.text = this.PoplList.value;
		}
	}
}
