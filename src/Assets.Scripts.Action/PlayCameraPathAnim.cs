using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace Assets.Scripts.Action
{
	[Category("obsolete/Camera"), Name("Play camera animation")]
	public class PlayCameraPathAnim : ActionWithEndType
	{
		public BBParameter<Transform> Target;

		public BBParameter<Transform> Source;

		public string AnimName;

		protected override void OnExecute()
		{
			base.EndActionWithEndType();
		}
	}
}
