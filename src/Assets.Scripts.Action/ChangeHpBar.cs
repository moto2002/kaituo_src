using Assets.Migration.Scripts.Anim;
using Assets.Scripts.Action.Core;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;

namespace Assets.Scripts.Action
{
	[Category("obsolete/Character"), Name("Change hp bar")]
	public class ChangeHpBar : DevisableAction
	{
		public BBParameter<RpgCharacter> Character;

		public BBParameter<int> ToHp;

		public BBParameter<float> ChangeTime;

		public bool IgnoreTimeScale;

		private float changeTime;

		protected override void OnExecute()
		{
			RpgCharacter value = this.Character.value;
			Bind2dHpBar bind2dHpBar = Bind2dHpBar.Create(value, null, 3f);
			this.changeTime = this.ChangeTime.value;
			if (Math.Abs(this.changeTime) < 0.001f)
			{
				bind2dHpBar.HpTo(this.ToHp.value);
				base.EndAction();
			}
			else
			{
				bind2dHpBar.HpTo(this.ToHp.value, this.changeTime, this.IgnoreTimeScale, new Action(base.EndAction));
			}
		}
	}
}
