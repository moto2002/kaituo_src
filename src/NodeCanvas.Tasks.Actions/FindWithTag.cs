using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("GameObject")]
	public class FindWithTag : ActionTask
	{
		[RequiredField, TagField]
		public string searchTag = "Untagged";

		[BlackboardOnly]
		public BBParameter<GameObject> saveAs;

		protected override string info
		{
			get
			{
				return string.Concat(new object[]
				{
					"GetObject '",
					this.searchTag,
					"' as ",
					this.saveAs
				});
			}
		}

		protected override void OnExecute()
		{
			this.saveAs.value = GameObject.FindWithTag(this.searchTag);
			base.EndAction(new bool?(true));
		}
	}
}
