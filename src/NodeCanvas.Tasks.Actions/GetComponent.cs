using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("GameObject")]
	public class GetComponent<T> : ActionTask<Transform> where T : Component
	{
		[BlackboardOnly]
		public BBParameter<T> saveAs;

		protected override string info
		{
			get
			{
				return string.Format("Get {0} as {1}", typeof(T).Name, this.saveAs.ToString());
			}
		}

		protected override void OnExecute()
		{
			T component = base.agent.GetComponent<T>();
			this.saveAs.value = component;
			base.EndAction(new bool?(component != null));
		}
	}
}
