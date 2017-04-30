using Assets.Scripts.Action.Core;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace Assets.Scripts.Action
{
	[Category("✫ GOG/Character"), Name("Publish character anchor")]
	public class PublishCharacterAnchorPoint : DevisableAction
	{
		public BBParameter<RpgCharacter> Character;

		public BBParameter<string> AnchorPointName;

		public BBParameter<GameObject> AnchorPoint;

		protected override void OnExecute()
		{
			RpgCharacter value = this.Character.value;
			GameObject anchorPoint = value.GetAnchorPoint(this.AnchorPointName.value);
			this.AnchorPoint.value = anchorPoint;
			base.EndAction();
		}
	}
}
