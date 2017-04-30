using Assets.Scripts.Action.Core;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace Assets.Migration.Scripts.Action.Effect
{
	[Category("✫ GOG/Effect"), Name("Foreground Start")]
	public class StartForeground : DevisableAction
	{
		public Color Color;

		protected override void OnExecute()
		{
			ForegroundBehavior.Instance.Show();
			ForegroundBehavior.Instance.SetBackgroundColor(this.Color);
			base.EndAction();
		}
	}
}
