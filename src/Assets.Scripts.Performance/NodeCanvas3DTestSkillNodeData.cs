using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Performance
{
	[Serializable]
	public class NodeCanvas3DTestSkillNodeData
	{
		public NodeCanvas3DTestUnit Attacker = new NodeCanvas3DTestUnit();

		public List<NodeCanvas3DTestUnit> Targets = new List<NodeCanvas3DTestUnit>();

		public NodeCanvas3DTestSkill Skill = new NodeCanvas3DTestSkill();

		public bool IsMainTargetDied;

		public int UserCamp;

		[HideInInspector]
		public int TargetsCount;

		[HideInInspector]
		public int AttackerInstId;

		[HideInInspector]
		public int MainTargetInstId;

		[HideInInspector]
		public bool IsDamageSkill;

		[HideInInspector]
		public bool IsTreatSkill;

		[HideInInspector]
		public bool AttackerIsUnit;

		[HideInInspector]
		public NodeCanvas3DTestUnit MainTarget;

		[HideInInspector]
		public int AttackerCamp;

		[HideInInspector]
		public int MainTargetCamp;
	}
}
