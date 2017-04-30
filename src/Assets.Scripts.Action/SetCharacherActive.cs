using Assets.Scripts.Action.Core;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;

namespace Assets.Scripts.Action
{
	[Category("✫ GOG/Character"), Name("Set character active")]
	public class SetCharacherActive : DevisableAction
	{
		public BBParameter<RpgCharacter> Character;

		public bool Active;

		protected override void OnExecute()
		{
			RpgCharacter value = this.Character.value;
			value.gameObject.SetActive(this.Active);
			base.EndAction();
		}
	}
}
