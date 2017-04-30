using System;
using UnityEngine;

namespace Assets.Migration.Scripts.Action
{
	public class TargetFollowTool : MonoBehaviour
	{
		public GameObject Target;

		public bool WithRotation = true;

		public Vector3 Offset;

		private bool follow = true;

		public void Stop()
		{
			this.follow = false;
			UnityEngine.Object.Destroy(this);
		}

		public void LateUpdate()
		{
			if (!this.follow)
			{
				return;
			}
			base.transform.position = this.Target.transform.position + this.Offset;
			if (this.WithRotation)
			{
				base.transform.rotation = this.Target.transform.rotation;
			}
		}
	}
}
