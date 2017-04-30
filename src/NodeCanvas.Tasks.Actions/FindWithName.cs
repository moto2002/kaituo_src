using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("GameObject")]
	public class FindWithName : ActionTask
	{
		[RequiredField]
		public BBParameter<string> gameObjectName;

		[BlackboardOnly]
		public BBParameter<GameObject> saveAs;

		protected override string info
		{
			get
			{
				return string.Concat(new object[]
				{
					"Find Object ",
					this.gameObjectName,
					" as ",
					this.saveAs
				});
			}
		}

		protected override void OnExecute()
		{
			this.saveAs.value = GameObject.Find(this.gameObjectName.value);
			base.EndAction();
		}
	}
}
