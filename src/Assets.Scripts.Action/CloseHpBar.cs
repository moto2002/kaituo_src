using Assets.Migration.Scripts.Anim;
using Assets.Scripts.Action.Core;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;

namespace Assets.Scripts.Action
{
	[Category("obsolete/Character"), Name("Close hp bar")]
	public class CloseHpBar : DevisableAction
	{
		public BBParameter<RpgCharacter> Character;

		protected override void OnExecute()
		{
			RpgCharacter value = this.Character.value;
			Bind2dHpBar.Destroy(value);
			base.EndAction();
		}
	}
}
