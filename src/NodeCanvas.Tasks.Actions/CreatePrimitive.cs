using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("GameObject")]
	public class CreatePrimitive : ActionTask
	{
		public BBParameter<string> objectName;

		public BBParameter<Vector3> position;

		public BBParameter<Vector3> rotation;

		public BBParameter<PrimitiveType> type;

		[BlackboardOnly]
		public BBParameter<GameObject> saveAs;

		protected override void OnExecute()
		{
			GameObject gameObject = GameObject.CreatePrimitive(this.type.value);
			gameObject.name = this.objectName.value;
			gameObject.transform.position = this.position.value;
			gameObject.transform.eulerAngles = this.rotation.value;
			this.saveAs.value = gameObject;
			base.EndAction();
		}
	}
}
