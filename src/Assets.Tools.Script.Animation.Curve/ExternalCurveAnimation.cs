using Assets.Tools.Script.Go;
using Assets.Tools.Script.Helper;
using System;
using UnityEngine;

namespace Assets.Tools.Script.Animation.Curve
{
	public class ExternalCurveAnimation : CurveAnimation
	{
		public Action<float, float> externalPlayer;

		public ExternalCurveAnimation CloneCurveAnimation(GameObject attachTo = null)
		{
			attachTo = (attachTo ?? ParasiticComponent.parasiteHost);
			ExternalCurveAnimation component = attachTo.AddInstantiate(base.gameObject).GetComponent<ExternalCurveAnimation>();
			component.Reset();
			return component;
		}

		public ExternalCurveAnimation SetExternalPlayer(Action<float, float> externalPlayer)
		{
			this.externalPlayer = externalPlayer;
			return this;
		}

		protected override void OnPlay(float time, float value)
		{
			if (this.externalPlayer != null)
			{
				this.externalPlayer(time, value);
			}
		}
	}
}
