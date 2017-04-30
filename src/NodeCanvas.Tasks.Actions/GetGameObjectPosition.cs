using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("GameObject"), Obsolete("Use Get Property instead")]
	public class GetGameObjectPosition : ActionTask<Transform>
	{
		[BlackboardOnly]
		public BBParameter<Vector3> saveAs;

		protected override string info
		{
			get
			{
				return string.Concat(new object[]
				{
					"Get ",
					base.agentInfo,
					" position as ",
					this.saveAs
				});
			}
		}

		protected override void OnExecute()
		{
			this.saveAs.value = base.agent.position;
			base.EndAction();
		}
	}
}
