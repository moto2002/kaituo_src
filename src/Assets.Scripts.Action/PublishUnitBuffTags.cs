using Assets.Scripts.Action.Core;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Action
{
	[Category("obsolete/Battle"), Name("Publish unit buff tag")]
	public class PublishUnitBuffTags : DevisableAction
	{
		public enum BuffSelectUnitType
		{
			InstanceId,
			Character
		}

		public PublishUnitBuffTags.BuffSelectUnitType UnitType;

		public BBParameter<RpgCharacter> Character;

		public BBParameter<int> InstanceId;

		public string Condition = string.Empty;

		public bool FirstOne = true;

		public BBParameter<string> TargetTag;

		public BBParameter<List<string>> TargetTagList;

		protected override void OnExecute()
		{
			PublishUnitBuffTags.BuffSelectUnitType unitType = this.UnitType;
			if (unitType != PublishUnitBuffTags.BuffSelectUnitType.InstanceId)
			{
				if (unitType != PublishUnitBuffTags.BuffSelectUnitType.Character)
				{
					throw new ArgumentOutOfRangeException();
				}
				int num = this.Character.value.InstanceId;
			}
			else
			{
				int num = this.InstanceId.value;
			}
			base.EndAction();
		}
	}
}
