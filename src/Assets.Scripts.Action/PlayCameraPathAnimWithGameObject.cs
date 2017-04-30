using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace Assets.Scripts.Action
{
	[Category("obsolete/Camera"), Name("Play camera animation(game object)")]
	public class PlayCameraPathAnimWithGameObject : ActionWithEndType
	{
		public BBParameter<GameObject> Target;

		public BBParameter<GameObject> Source;

		public string AnimName;

		protected override void OnExecute()
		{
			base.EndActionWithEndType();
		}
	}
}
