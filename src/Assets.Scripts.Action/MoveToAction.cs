using Assets.Scripts.Action.Core;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace Assets.Scripts.Action
{
	[Category("✫ GOG/Character"), Name("Move character")]
	public class MoveToAction : DevisableAction
	{
		public enum CharacterMoveType
		{
			Target,
			Position
		}

		public BBParameter<RpgCharacter> Character;

		public string AnimName;

		public float MoveTime;

		public MoveToAction.CharacterMoveType MoveType;

		public bool IsLocal;

		public BBParameter<GameObject> ToTarget;

		public Vector3 Offset;

		public BBParameter<Vector3> To;

		protected override void OnExecute()
		{
			Vector3 position;
			if (this.MoveType == MoveToAction.CharacterMoveType.Position)
			{
				position = this.To.value;
			}
			else if (this.IsLocal)
			{
				Vector3 vector = this.ToTarget.value.transform.localToWorldMatrix.MultiplyPoint(this.Offset);
				position = vector;
			}
			else
			{
				position = this.ToTarget.value.transform.position + this.Offset;
			}
			RpgCharacter value = this.Character.value;
			if (this.MoveTime <= 0f)
			{
				value.transform.position = position;
				base.EndAction();
			}
			else
			{
				value.OnMoveEndSignal.AddEventListener(new Action<RpgCharacter>(this.OnMoveEndHander));
				value.MoveTo(position, this.MoveTime, this.AnimName);
			}
		}

		private void OnMoveEndHander(RpgCharacter obj)
		{
			this.Character.value.OnMoveEndSignal.RemoveEventListener(new Action<RpgCharacter>(this.OnMoveEndHander));
			base.EndAction();
		}
	}
}
