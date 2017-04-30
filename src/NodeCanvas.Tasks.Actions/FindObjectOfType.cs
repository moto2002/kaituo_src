using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("GameObject"), Description("Note that this is very slow")]
	public class FindObjectOfType<T> : ActionTask where T : Component
	{
		[BlackboardOnly]
		public BBParameter<T> saveComponentAs;

		[BlackboardOnly]
		public BBParameter<GameObject> saveGameObjectAs;

		protected override void OnExecute()
		{
			T t = UnityEngine.Object.FindObjectOfType<T>();
			if (t != null)
			{
				this.saveComponentAs.value = t;
				this.saveGameObjectAs.value = t.gameObject;
				base.EndAction(new bool?(true));
				return;
			}
			base.EndAction(new bool?(false));
		}
	}
}
