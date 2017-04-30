using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using System.Collections;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Blackboard/Lists")]
	public class GetListCount : ActionTask
	{
		[BlackboardOnly, RequiredField]
		public BBParameter<IList> targetList;

		[BlackboardOnly]
		public BBParameter<int> saveAs;

		protected override void OnExecute()
		{
			this.saveAs.value = this.targetList.value.Count;
			base.EndAction(new bool?(true));
		}
	}
}
