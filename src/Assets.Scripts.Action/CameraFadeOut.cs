using Assets.Scripts.Action.Core;
using Assets.Scripts.Tools.NGUI.Component;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace Assets.Scripts.Action
{
	[Category("✫ GOG/Camera"), Name("Fade Out")]
	public class CameraFadeOut : DevisableAction
	{
		public Color Color = new Color(0f, 0f, 0f, 1f);

		public float Time;

		protected override void OnExecute()
		{
			GameObject gameObject = GlobalGameObject.GlobalObjects["UpSceneFade"];
			TweenColor component = gameObject.GetComponent<TweenColor>();
			component.from = gameObject.GetComponent<UISprite>().color;
			component.to = this.Color;
			component.duration = this.Time;
			component.AddOnFinished(new EventDelegate(new EventDelegate.Callback(base.EndAction))
			{
				oneShot = true
			});
			component.ResetToBeginning();
			component.PlayForward();
		}
	}
}
