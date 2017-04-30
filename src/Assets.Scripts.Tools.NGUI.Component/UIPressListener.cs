using System;
using UnityEngine;

namespace Assets.Scripts.Tools.NGUI.Component
{
	public class UIPressListener : MonoBehaviour
	{
		public Action<GameObject, bool> onPress;

		public static UIPressListener Get(GameObject go)
		{
			UIPressListener uIPressListener = go.GetComponent<UIPressListener>();
			if (uIPressListener == null)
			{
				uIPressListener = go.AddComponent<UIPressListener>();
			}
			return uIPressListener;
		}

		private void OnPress(bool isPressed)
		{
			if (this.onPress != null)
			{
				this.onPress(base.gameObject, isPressed);
			}
		}

		private void OnDestroy()
		{
			this.onPress = null;
		}
	}
}
