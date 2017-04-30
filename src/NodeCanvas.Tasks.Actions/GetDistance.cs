using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("GameObject")]
	public class GetDistance : ActionTask<Transform>
	{
		[RequiredField]
		public BBParameter<GameObject> target;

		[BlackboardOnly]
		public BBParameter<float> saveAs;

		protected override string info
		{
			get
			{
				return string.Format("Get Distance to {0}", this.target.ToString());
			}
		}

		protected override void OnExecute()
		{
			this.saveAs.value = Vector3.Distance(base.agent.position, this.target.value.transform.position);
			base.EndAction();
		}
	}
}
