using System;
using System.Collections.Generic;

namespace XQ.ProjectX.Service
{
	public class NPCInfo
	{
		public string NPCId;

		public bool Visible;

		public int Friendliness;

		public List<string> ElementList;

		public Dictionary<string, int> Relationship;

		public int Timestamp;
	}
}
