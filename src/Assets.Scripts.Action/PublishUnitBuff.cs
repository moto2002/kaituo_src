using Assets.Scripts.Action.Core;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;

namespace Assets.Scripts.Action
{
	[Category("obsolete/Battle"), Name("Publish unit buff")]
	public class PublishUnitBuff : DevisableAction
	{
		public enum BuffSelectUnitType
		{
			InstanceId,
			Character
		}

		public PublishUnitBuff.BuffSelectUnitType UnitType;

		public BBParameter<RpgCharacter> Character;

		public BBParameter<int> InstanceId;

		protected override void OnExecute()
		{
			base.EndAction();
		}
	}
}
