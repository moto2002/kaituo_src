using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using System.Collections;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Blackboard/Lists")]
	public class ClearList : ActionTask
	{
		[BlackboardOnly, RequiredField]
		public BBParameter<IList> targetList;

		protected override void OnExecute()
		{
			this.targetList.value.Clear();
			base.EndAction(new bool?(true));
		}
	}
}
