using Assets.Migration.Scripts.Anim;
using Assets.Scripts.Action.Core;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace Assets.Scripts.Action
{
	[Category("✫ GOG/Character"), Name("Show hp bar")]
	public class ShowHpBar : DevisableAction
	{
		public BBParameter<RpgCharacter> Character;

		public BBParameter<GameObject> TargetPoint;

		public float Size = 3f;

		protected override void OnExecute()
		{
			RpgCharacter value = this.Character.value;
			Bind2dHpBar.Create(value, this.TargetPoint.value, this.Size);
			base.EndAction();
		}
	}
}
