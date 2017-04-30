using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("GameObject"), Description("Get the closer game object to the agent from within a list of game objects and save it in the blackboard.")]
	public class GetCloserGameObjectInList : ActionTask<Transform>
	{
		[RequiredField]
		public BBParameter<List<GameObject>> list;

		[BlackboardOnly]
		public BBParameter<GameObject> saveAs;

		protected override string info
		{
			get
			{
				return string.Concat(new object[]
				{
					"Get Closer from '",
					this.list,
					"' as ",
					this.saveAs
				});
			}
		}

		protected override void OnExecute()
		{
			if (this.list.value.Count == 0)
			{
				base.EndAction(new bool?(false));
				return;
			}
			float num = float.PositiveInfinity;
			GameObject value = null;
			foreach (GameObject current in this.list.value)
			{
				float num2 = Vector3.Distance(base.agent.position, current.transform.position);
				if (num2 < num)
				{
					num = num2;
					value = current;
				}
			}
			this.saveAs.value = value;
			base.EndAction(new bool?(true));
		}
	}
}
