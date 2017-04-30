using System;
using UnityEngine;

namespace Assets.Scripts.Tools.NGUI.Component
{
	public class UIClickListener : MonoBehaviour
	{
		public Action<GameObject> onClick;

		public static UIClickListener Get(GameObject go)
		{
			UIClickListener uIClickListener = go.GetComponent<UIClickListener>();
			if (uIClickListener == null)
			{
				uIClickListener = go.AddComponent<UIClickListener>();
			}
			return uIClickListener;
		}

		private void OnClick()
		{
			if (this.onClick != null)
			{
				this.onClick(base.gameObject);
			}
		}

		private void OnDestroy()
		{
			this.onClick = null;
		}
	}
}
