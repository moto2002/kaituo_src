using System;
using UnityEngine;

namespace Assets.Scripts.Tools.Component
{
	public class NcAutoDisable : MonoBehaviour
	{
		public float AutoDisable;

		private void OnEnable()
		{
			if ((double)this.AutoDisable > 0.0001)
			{
				base.Invoke("CloseVisible", this.AutoDisable);
			}
		}

		private void OnDisable()
		{
			base.CancelInvoke("CloseVisible");
		}

		private void CloseVisible()
		{
			base.gameObject.SetActive(false);
		}
	}
}
