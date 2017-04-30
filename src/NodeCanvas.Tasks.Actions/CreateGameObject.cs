using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("GameObject")]
	public class CreateGameObject : ActionTask
	{
		public BBParameter<string> objectName;

		public BBParameter<Vector3> position;

		public BBParameter<Vector3> rotation;

		[BlackboardOnly]
		public BBParameter<GameObject> saveAs;

		protected override void OnExecute()
		{
			GameObject gameObject = new GameObject(this.objectName.value);
			gameObject.transform.position = this.position.value;
			gameObject.transform.eulerAngles = this.rotation.value;
			this.saveAs.value = gameObject;
			base.EndAction();
		}
	}
}
