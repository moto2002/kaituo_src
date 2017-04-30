using System;
using UnityEngine;

namespace Assets.Scripts.Tools.Component
{
	public class NcSoloist : MonoBehaviour
	{
		public float SoloTime;

		[NonSerialized]
		public bool IsFinish;

		private void OnEnable()
		{
			this.IsFinish = false;
			if ((double)this.SoloTime > 0.0001)
			{
				base.Invoke("EndSolo", this.SoloTime);
			}
		}

		private void OnDisable()
		{
			base.CancelInvoke("EndSolo");
		}

		private void EndSolo()
		{
			this.IsFinish = true;
		}
	}
}
