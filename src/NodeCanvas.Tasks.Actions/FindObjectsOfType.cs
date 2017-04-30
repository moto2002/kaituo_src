using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("GameObject"), Description("Note that this is very slow")]
	public class FindObjectsOfType<T> : ActionTask where T : Component
	{
		[BlackboardOnly]
		public BBParameter<List<GameObject>> saveGameObjects;

		[BlackboardOnly]
		public BBParameter<List<T>> saveComponents;

		protected override void OnExecute()
		{
			T[] array = UnityEngine.Object.FindObjectsOfType<T>();
			if (array != null && array.Length != 0)
			{
				this.saveGameObjects.value = (from o in array
				select o.gameObject).ToList<GameObject>();
				this.saveComponents.value = array.ToList<T>();
				base.EndAction(new bool?(true));
				return;
			}
			base.EndAction(new bool?(false));
		}
	}
}
