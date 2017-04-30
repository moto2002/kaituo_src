using Assets.Scripts.Action.Core;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace Assets.Migration.Scripts.Action.Effect
{
	[Category("✫ GOG/Effect"), Name("Change Foreground Color")]
	public class ChangeForegroundBackColor : DevisableAction
	{
		public Color ToColor;

		public float Time;

		protected override void OnExecute()
		{
			ForegroundBehavior.Instance.TweenColor(this.Time, ForegroundBehavior.Instance.Color, this.ToColor, new Action(base.EndAction));
		}
	}
}
