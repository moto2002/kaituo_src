using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("GameObject")]
	public class RemoveComponent<T> : ActionTask<Transform> where T : Component
	{
		protected override string info
		{
			get
			{
				return string.Format("Remove '{0}'", typeof(T).Name);
			}
		}

		protected override void OnExecute()
		{
			T component = base.agent.GetComponent<T>();
			if (component != null)
			{
				UnityEngine.Object.Destroy(component);
				base.EndAction(new bool?(true));
				return;
			}
			base.EndAction(new bool?(false));
		}
	}
}
