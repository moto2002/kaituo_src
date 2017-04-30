using Assets.Tools.Script.Caller;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;

namespace Assets.Scripts.Action
{
	[Category("obsolete/Character"), Name("Turn round character")]
	public class LookToAction : ActionWithEndType
	{
		public BBParameter<RpgCharacter> Character;

		public BBParameter<RpgCharacter> LookTo;

		public float TurnBackTime;

		protected override void OnExecute()
		{
			this.Character.value.TurnToLook(this.LookTo.value.transform.position, this.TurnBackTime);
			base.EndActionWithEndType();
		}

		protected override void OnEndWithAction()
		{
			DelayCall.Call(new Action(base.EndAction), this.TurnBackTime, false);
		}
	}
}
