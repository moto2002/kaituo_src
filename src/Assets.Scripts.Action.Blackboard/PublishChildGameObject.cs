using Assets.Scripts.Action.Core;
using Assets.Scripts.Tool;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace Assets.Scripts.Action.Blackboard
{
	[Category("✫ GOG/Blackboard"), Name("Publish Child GameObject")]
	public class PublishChildGameObject : DevisableAction
	{
		public BBParameter<GameObject> Root;

		public string ChildPath;

		public string To;

		protected override void OnExecute()
		{
			Transform transform = this.Root.value.transform.FindChild(this.ChildPath);
			base.blackboard.SetOrAddValue(this.To, transform.gameObject);
			base.EndAction();
		}
	}
}
