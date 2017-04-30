using System;
using UnityEngine;

namespace XQ.Framework.Lua.Utility
{
	public class SetTimeScale : MonoBehaviour
	{
		public bool enableScale0;

		public void EnableScale()
		{
			Time.timeScale = 0f;
		}

		public void DisableScale()
		{
			Time.timeScale = 1f;
		}

		private void OnEnable()
		{
			if (this.enableScale0)
			{
				this.EnableScale();
			}
		}

		private void OnDisable()
		{
			this.DisableScale();
		}
	}
}
