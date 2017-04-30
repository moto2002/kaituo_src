using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("GameObject")]
	public class InstantiateGameObject : ActionTask<Transform>
	{
		public BBParameter<Vector3> clonePosition;

		[BlackboardOnly]
		public BBParameter<GameObject> saveCloneAs;

		protected override string info
		{
			get
			{
				return string.Concat(new object[]
				{
					"Instantiate ",
					base.agentInfo,
					" at ",
					this.clonePosition,
					" as ",
					this.saveCloneAs
				});
			}
		}

		protected override void OnExecute()
		{
			this.saveCloneAs.value = (GameObject)UnityEngine.Object.Instantiate(base.agent.gameObject, this.clonePosition.value, Quaternion.identity);
			base.EndAction();
		}
	}
}
