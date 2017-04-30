using System;
using UnityEngine;

namespace Assets.Scripts.Performance
{
	[Serializable]
	public class NodeCanvas3DTestUnit
	{
		public int InstId;

		public string Avatar;

		public string Name;

		public NodeCanvas3DTestUnitAttr UnitAtt;

		public int Camp;

		[HideInInspector]
		public int AttackerType;

		public bool __isUnit = true;
	}
}
