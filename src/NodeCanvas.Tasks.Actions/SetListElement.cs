using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using System.Collections.Generic;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Blackboard/Lists")]
	public class SetListElement<T> : ActionTask
	{
		[BlackboardOnly, RequiredField]
		public BBParameter<List<T>> targetList;

		public BBParameter<int> index;

		public BBParameter<T> newValue;

		protected override void OnExecute()
		{
			if (this.index.value < 0 || this.index.value >= this.targetList.value.Count)
			{
				base.EndAction(new bool?(false));
				return;
			}
			this.targetList.value[this.index.value] = this.newValue.value;
			base.EndAction(new bool?(true));
		}
	}
}
