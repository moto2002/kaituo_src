using System;
using UnityEngine;

namespace Assets.Scripts.Tools.NGUI.Component
{
	public class UIUnBoundsSprite : UISprite
	{
		private Vector3[] unbounds = new Vector3[]
		{
			Vector3.zero,
			Vector3.zero,
			Vector3.zero,
			Vector3.zero
		};

		public override Vector3[] worldBounds
		{
			get
			{
				Vector3 vector = base.transform.position.SetPositionZ(0f);
				this.unbounds[0] = vector;
				this.unbounds[1] = vector;
				this.unbounds[2] = vector;
				this.unbounds[3] = vector;
				return this.unbounds;
			}
		}
	}
}
