using Assets.Tools.Serialization;
using ParadoxNotion.Serialization;
using System;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Performance
{
	public class NodeCanvas3DTest : MonoBehaviour
	{
		public NodeCanvas3DTestSkillNodeData Data;

		public string SceneName;

		public GameObject BattleUnitInfoBarLeftObject;

		public GameObject BattleUnitInfoBarRightObject;

		public GameObject BattleUnitInfoPopLabelLeftObject;

		public GameObject BattleUnitInfoPopLabelRightObject;

		public string GetData()
		{
			this.Data.TargetsCount = this.Data.Targets.Count;
			this.Data.Attacker.AttackerType = ((!this.Data.Attacker.__isUnit) ? 2 : 1);
			foreach (NodeCanvas3DTestUnit current in this.Data.Targets)
			{
				current.AttackerType = ((!current.__isUnit) ? 2 : 1);
			}
			this.Data.AttackerCamp = this.Data.Attacker.Camp;
			this.Data.AttackerIsUnit = this.Data.Attacker.__isUnit;
			this.Data.AttackerInstId = this.Data.Attacker.InstId;
			this.Data.IsDamageSkill = this.Data.Skill.IsDamageSkill;
			this.Data.IsTreatSkill = this.Data.Skill.IsTreatSkill;
			this.Data.Skill.TagLabels = this.Data.Skill.Tag.Split(new char[]
			{
				','
			}).ToList<string>();
			if (this.Data.TargetsCount > 0)
			{
				this.Data.MainTarget = this.Data.Targets[0].JsonClone<NodeCanvas3DTestUnit>();
				this.Data.MainTargetCamp = this.Data.MainTarget.Camp;
				this.Data.MainTargetInstId = this.Data.MainTarget.InstId;
			}
			return JSON.Serialize<NodeCanvas3DTestSkillNodeData>(this.Data, false, null);
		}
	}
}
