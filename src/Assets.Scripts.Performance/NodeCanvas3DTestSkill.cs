using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Performance
{
	[Serializable]
	public class NodeCanvas3DTestSkill
	{
		public string Tag;

		public string Name;

		public int DMG;

		public bool IsDamageSkill;

		public bool IsTreatSkill;

		[HideInInspector]
		public List<string> TagLabels = new List<string>();
	}
}
