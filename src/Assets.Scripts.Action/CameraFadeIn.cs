using Assets.Scripts.Action.Core;
using Assets.Scripts.Tools.NGUI.Component;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace Assets.Scripts.Action
{
	[Category("✫ GOG/Camera"), Name("Fade In")]
	public class CameraFadeIn : DevisableAction
	{
		public Color Color = new Color(0f, 0f, 0f, 1f);

		public float Time;

		protected override void OnExecute()
		{
			GameObject gameObject = GlobalGameObject.GlobalObjects["UpSceneFade"];
			TweenColor component = gameObject.GetComponent<TweenColor>();
			component.from = this.Color;
			component.to = new Color(0f, 0f, 0f, 0f);
			component.AddOnFinished(new EventDelegate(new EventDelegate.Callback(base.EndAction))
			{
				oneShot = true
			});
			component.duration = this.Time;
			component.ResetToBeginning();
			component.PlayForward();
		}
	}
}
