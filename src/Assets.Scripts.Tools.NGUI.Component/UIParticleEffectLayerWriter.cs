using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Tools.NGUI.Component
{
	public class UIParticleEffectLayerWriter : MonoBehaviour
	{
		public static Dictionary<UIParticleEffectLayer, UIWidget> Widgets = new Dictionary<UIParticleEffectLayer, UIWidget>();

		public UIParticleEffectLayer EffectLayer;

		public UIWidget Widget;

		private void Awake()
		{
			this.Init();
		}

		public void Init()
		{
			if (this.Widget == null)
			{
				this.Widget = base.GetComponent<UIWidget>();
			}
			UIParticleEffectLayerWriter.Widgets[this.EffectLayer] = this.Widget;
		}

		public void OnDestroy()
		{
			UIParticleEffectLayerWriter.Widgets[this.EffectLayer] = null;
		}
	}
}
