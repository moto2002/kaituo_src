using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("Camera")]
	public class FadeIn : ActionTask
	{
		public float fadeTime = 1f;

		protected override void OnExecute()
		{
			Debug.LogError("gog FadeIn only");
			base.EndAction();
		}

		protected override void OnUpdate()
		{
			if (base.elapsedTime >= this.fadeTime)
			{
				base.EndAction();
			}
		}
	}
}
