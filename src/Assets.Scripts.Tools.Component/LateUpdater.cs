using System;
using UnityEngine;

namespace Assets.Scripts.Tools.Component
{
	public class LateUpdater : MonoBehaviour
	{
		public Action OnLateUpdate;

		private void LateUpdate()
		{
			if (this.OnLateUpdate != null)
			{
				this.OnLateUpdate();
			}
		}
	}
}
