using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Task.AgentTypeAttribute(typeof(Transform)), Category("✫ Blackboard/Lists"), Description("Will sort the gameobjects in the target list by their distance to the agent (closer first) and save that list to the blackboard")]
	public class SortGameObjectListByDistance : ActionTask
	{
		[BlackboardOnly, RequiredField]
		public BBParameter<List<GameObject>> targetList;

		[BlackboardOnly]
		public BBParameter<List<GameObject>> saveAs;

		public bool reverse;

		protected override string info
		{
			get
			{
				return string.Concat(new object[]
				{
					"Sort ",
					this.targetList,
					" by distance as ",
					this.saveAs
				});
			}
		}

		protected override void OnExecute()
		{
			this.saveAs.value = (from go in this.targetList.value
			orderby Vector3.Distance(go.transform.position, base.agent.transform.position)
			select go).ToList<GameObject>();
			if (this.reverse)
			{
				this.saveAs.value.Reverse();
			}
			base.EndAction();
		}
	}
}
