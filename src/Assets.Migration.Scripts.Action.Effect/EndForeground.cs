using Assets.Scripts.Action.Core;
using ParadoxNotion.Design;
using System;

namespace Assets.Migration.Scripts.Action.Effect
{
	[Category("✫ GOG/Effect"), Name("Foreground End")]
	public class EndForeground : DevisableAction
	{
		protected override void OnExecute()
		{
			ForegroundBehavior.Instance.Close();
			base.EndAction();
		}
	}
}
