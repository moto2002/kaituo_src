using System;
using UnityEngine;

namespace Assets.Scripts.Tools.NGUI.Component
{
	public class UITweenObjectsActive : UITweener
	{
		public GameObject[] Objects;

		public bool from;

		public bool to;

		protected override void OnUpdate(float factor, bool isFinished)
		{
			for (int i = 0; i < this.Objects.Length; i++)
			{
				GameObject gameObject = this.Objects[i];
				gameObject.SetActive((factor >= 1f) ? this.from : this.to);
			}
		}
	}
}
