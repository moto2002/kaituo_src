using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using System.Collections.Generic;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Blackboard/Lists")]
	public class AddElementToList<T> : ActionTask
	{
		[BlackboardOnly, RequiredField]
		public BBParameter<List<T>> targetList;

		public BBParameter<T> targetElement;

		protected override void OnExecute()
		{
			this.targetList.value.Add(this.targetElement.value);
			base.EndAction();
		}
	}
}
