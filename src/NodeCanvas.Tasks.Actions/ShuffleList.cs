using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using System.Collections;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Blackboard/Lists")]
	public class ShuffleList : ActionTask
	{
		[BlackboardOnly, RequiredField]
		public BBParameter<IList> targetList;

		protected override void OnExecute()
		{
			IList value = this.targetList.value;
			for (int i = value.Count - 1; i > 0; i--)
			{
				int index = (int)Mathf.Floor(UnityEngine.Random.value * (float)(i + 1));
				object value2 = value[i];
				value[i] = value[index];
				value[index] = value2;
			}
			base.EndAction();
		}
	}
}
