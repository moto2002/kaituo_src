using Assets.Scripts.Action.Core;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace Assets.Scripts.Action.General
{
	[Category("✫ GOG/General"), Name("GameObject active")]
	public class GameObjectAvtiveAction : DevisableAction
	{
		public BBParameter<GameObject> Target;

		public bool Active;

		protected override void OnExecute()
		{
			this.Target.value.SetActive(this.Active);
			base.EndAction();
		}
	}
}
