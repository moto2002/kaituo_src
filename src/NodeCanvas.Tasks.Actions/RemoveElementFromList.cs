using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using System.Collections.Generic;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Blackboard/Lists"), Description("Remove an element from the target list")]
	public class RemoveElementFromList<T> : ActionTask
	{
		[BlackboardOnly, RequiredField]
		public BBParameter<List<T>> targetList;

		public BBParameter<T> targetElement;

		protected override void OnExecute()
		{
			this.targetList.value.Remove(this.targetElement.value);
			base.EndAction(new bool?(true));
		}
	}
}
