using NodeCanvas;
using NodeCanvas.BehaviourTrees;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Action.Program
{
	[Category("obsolete/Program"), Name("Play behaviour tree")]
	public class PlayBehaviorTreePrefab : BTNode
	{
		private static Dictionary<string, GameObject> cache = new Dictionary<string, GameObject>();

		public BBParameter<string> PrefabName;

		private BehaviourTreeOwner treeOwner;

		private bool started;

		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			return base.status;
		}
	}
}
