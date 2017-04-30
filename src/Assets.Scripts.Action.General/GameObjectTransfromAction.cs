using Assets.Scripts.Action.Core;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace Assets.Scripts.Action.General
{
	[Category("✫ GOG/General"), Name("Transfrom to target")]
	public class GameObjectTransfromAction : DevisableAction
	{
		public BBParameter<GameObject> GameObject;

		public BBParameter<GameObject> Target;

		public Vector3 PositionOffset;

		public Vector3 RotationOffset;

		protected override void OnExecute()
		{
			GameObject value = this.Target.value;
			GameObject value2 = this.GameObject.value;
			Transform parent = value2.transform.parent;
			value2.transform.parent = value.transform;
			value2.transform.localPosition = this.PositionOffset;
			value2.transform.localRotation = Quaternion.Euler(this.RotationOffset);
			value2.transform.parent = parent;
			base.EndAction();
		}
	}
}
