using System;
using UnityEngine;

namespace Assets.Extends.EXNGUI.Compoment
{
	[Serializable]
	public class TableBtnPage
	{
		public UIButton btn;

		public GameObject page;

		[HideInInspector]
		public UITableBtn tableBtn;

		[HideInInspector]
		public int index;

		public void PageTo()
		{
			this.tableBtn.PageTo(this.btn);
		}
	}
}
