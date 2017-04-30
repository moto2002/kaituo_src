using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("GameObject"), Description("Action will end in Failure if no objects are found")]
	public class FindAllWithTag : ActionTask
	{
		[RequiredField, TagField]
		public string searchTag = "Untagged";

		[BlackboardOnly]
		public BBParameter<List<GameObject>> saveAs;

		protected override string info
		{
			get
			{
				return string.Concat(new object[]
				{
					"GetObjects '",
					this.searchTag,
					"' as ",
					this.saveAs
				});
			}
		}

		protected override void OnExecute()
		{
			this.saveAs.value = GameObject.FindGameObjectsWithTag(this.searchTag).ToList<GameObject>();
			base.EndAction(new bool?(this.saveAs.value.Count != 0));
		}
	}
}
