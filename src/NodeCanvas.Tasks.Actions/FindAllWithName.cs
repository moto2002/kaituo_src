using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("GameObject"), Description("Note that this is slow.\nAction will end in Failure if no objects are found")]
	public class FindAllWithName : ActionTask
	{
		[RequiredField]
		public BBParameter<string> searchName = "GameObject";

		[BlackboardOnly]
		public BBParameter<List<GameObject>> saveAs;

		protected override string info
		{
			get
			{
				return string.Concat(new object[]
				{
					"GetObjects '",
					this.searchName,
					"' as ",
					this.saveAs
				});
			}
		}

		protected override void OnExecute()
		{
			List<GameObject> list = new List<GameObject>();
			GameObject[] array = UnityEngine.Object.FindObjectsOfType<GameObject>();
			for (int i = 0; i < array.Length; i++)
			{
				GameObject gameObject = array[i];
				if (gameObject.name == this.searchName.value)
				{
					list.Add(gameObject);
				}
			}
			this.saveAs.value = list;
			base.EndAction(new bool?(list.Count != 0));
		}
	}
}
