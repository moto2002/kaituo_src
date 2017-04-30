using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("GameObject")]
	public class DestroyGameObject : ActionTask<Transform>
	{
		protected override void OnUpdate()
		{
			UnityEngine.Object.Destroy(base.agent.gameObject);
			base.EndAction();
		}
	}
}
