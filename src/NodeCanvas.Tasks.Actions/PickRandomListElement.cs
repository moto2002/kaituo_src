using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Blackboard/Lists")]
	public class PickRandomListElement<T> : ActionTask
	{
		[RequiredField]
		public BBParameter<List<T>> targetList;

		public BBParameter<T> saveAs;

		protected override void OnExecute()
		{
			if (this.targetList.value.Count <= 0)
			{
				base.EndAction(new bool?(false));
				return;
			}
			this.saveAs.value = this.targetList.value[UnityEngine.Random.Range(0, this.targetList.value.Count)];
			base.EndAction(new bool?(true));
		}
	}
}
