using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("GameObject")]
	public class GetAllChildGameObjects : ActionTask
	{
		[BlackboardOnly]
		public BBParameter<List<GameObject>> saveAs;

		public bool recursive;

		protected override void OnExecute()
		{
			List<Transform> list = new List<Transform>();
			foreach (Transform transform in base.agent.transform)
			{
				list.Add(transform);
				if (this.recursive)
				{
					list.AddRange(this.Get(transform));
				}
			}
			this.saveAs.value = (from t in list
			select t.gameObject).ToList<GameObject>();
			base.EndAction();
		}

		private List<Transform> Get(Transform parent)
		{
			List<Transform> list = new List<Transform>();
			foreach (Transform transform in parent)
			{
				list.Add(transform);
				list.AddRange(this.Get(transform));
			}
			return list;
		}
	}
}
