using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;

namespace Assets.Scripts.FightingScene.Tool
{
	[Category("obsolete/Battle"), Name("Contains result")]
	public class ContainsAttackResultType : ConditionTask
	{
		protected override bool OnCheck()
		{
			return false;
		}
	}
}
