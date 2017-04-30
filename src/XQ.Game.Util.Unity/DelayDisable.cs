using System;
using UnityEngine;

namespace XQ.Game.Util.Unity
{
	public class DelayDisable : MonoBehaviour
	{
		public float DelayTime;

		public void OnEnable()
		{
			base.CancelInvoke("CancelActive");
			base.Invoke("CancelActive", this.DelayTime);
		}

		private void OnDisable()
		{
			base.CancelInvoke("CancelActive");
		}

		private void CancelActive()
		{
			base.gameObject.SetActive(false);
		}
	}
}
