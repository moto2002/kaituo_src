using System;
using UnityEngine;

namespace Assets.Scripts.Tools.NGUI.Component
{
	public class UIStateButton : MonoBehaviour
	{
		public GameObject Normal;

		public GameObject Press;

		private void Start()
		{
			this.Normal.SetActive(true);
			this.Press.SetActive(false);
		}

		private void OnPress(bool isDown)
		{
			this.Normal.SetActive(!isDown);
			this.Press.SetActive(isDown);
		}
	}
}
