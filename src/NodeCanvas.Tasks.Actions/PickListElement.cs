using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using System.Collections.Generic;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Blackboard/Lists")]
	public class PickListElement<T> : ActionTask
	{
		[BlackboardOnly, RequiredField]
		public BBParameter<List<T>> targetList;

		public BBParameter<int> index;

		[BlackboardOnly]
		public BBParameter<T> saveAs;

		protected override void OnExecute()
		{
			if (this.index.value < 0 || this.index.value >= this.targetList.value.Count)
			{
				base.EndAction(new bool?(false));
				return;
			}
			this.saveAs.value = this.targetList.value[this.index.value];
			base.EndAction(new bool?(true));
		}
	}
}
