using Assets.Scripts;
using Assets.Scripts.Tool;
using NodeCanvas;
using NodeCanvas.BehaviourTrees;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using XQ.Framework.Utility.Debug;

namespace Assets.Migration.Scripts.Node
{
	[Category("obsolete/Program"), Name("Resource table")]
	public class CharacterLoadTable : BTNode
	{
		public class CharacterLoadData
		{
			public string Source;

			public string ResourcePath;

			public string BlackboardGameObjectName;

			public string BlackboardCharacterName;

			[NonSerialized]
			public List<int> LoadIds = new List<int>();
		}

		public List<CharacterLoadTable.CharacterLoadData> Datas = new List<CharacterLoadTable.CharacterLoadData>();

		private IBlackboard blackboard;

		private int loadingCharacterCount;

		private int loadState;

		private Dictionary<int, string> toLoadUnit = new Dictionary<int, string>();

		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			if (this.loadState == 0)
			{
				this.blackboard = blackboard;
				this.toLoadUnit.Clear();
				foreach (CharacterLoadTable.CharacterLoadData current in this.Datas)
				{
					this.GetIdFromSource(current, this.toLoadUnit);
				}
				foreach (KeyValuePair<int, string> current2 in this.toLoadUnit)
				{
					this.loadingCharacterCount++;
					CharacterModelLoader.LoadUnit(current2.Key, new Action<RpgCharacter>(this.LoadCharacterComplete));
				}
				this.loadState = 1;
			}
			if (this.loadState == 1 && this.loadingCharacterCount == 0)
			{
				this.loadState = 2;
			}
			if (this.loadState == 2)
			{
				foreach (CharacterLoadTable.CharacterLoadData current3 in this.Datas)
				{
					foreach (int current4 in current3.LoadIds)
					{
						string name = this.ReplaceId(current3.BlackboardCharacterName, current4);
						string name2 = this.ReplaceId(current3.BlackboardGameObjectName, current4);
						string unitName = CharacterModelLoader.GetUnitName(current4);
						RpgCharacter value = blackboard.GetValue<RpgCharacter>(unitName);
						GameObject gameObject = value.gameObject;
						blackboard.SetOrAddValue(name, value);
						blackboard.SetOrAddValue(name2, gameObject);
					}
				}
				this.loadState = 3;
			}
			if (this.loadState == 3)
			{
				base.status = Status.Success;
			}
			else
			{
				base.status = Status.Running;
			}
			return base.status;
		}

		private void GetIdFromSource(CharacterLoadTable.CharacterLoadData loadData, Dictionary<int, string> ids)
		{
			loadData.LoadIds.Clear();
			string[] variableNames = this.blackboard.GetVariableNames(typeof(int));
			string[] array = variableNames;
			for (int i = 0; i < array.Length; i++)
			{
				string variableName = array[i];
				int id = this.GetId(loadData.Source, variableName);
				if (id > 0)
				{
					loadData.LoadIds.Add(id);
					string unitName = CharacterModelLoader.GetUnitName(id);
					Variable variable = this.blackboard.GetVariable(unitName, null);
					if (variable == null || variable.value == null)
					{
						ids[id] = this.ReplaceId(loadData.ResourcePath, id);
					}
				}
			}
		}

		private int GetId(string matchString, string variableName)
		{
			string pattern = "(.*)(\\[id\\])(.*)";
			Regex regex = new Regex(pattern);
			Match match = regex.Match(matchString);
			if (match.Success)
			{
				string arg = match.Groups[1].ToString();
				string arg2 = match.Groups[3].ToString();
				string pattern2 = string.Format("({0})([0-9]*)({1})", arg, arg2);
				Regex regex2 = new Regex(pattern2);
				Match match2 = regex2.Match(variableName);
				if (match2.Success)
				{
					string text = match2.Groups[2].ToString();
					UDebug.Debug("csbraces1:" + text, new object[0]);
					return Convert.ToInt32(text);
				}
			}
			return -1;
		}

		private string ReplaceId(string targetString, int id)
		{
			return targetString.Replace("[id]", id.ToString());
		}

		private void LoadCharacterComplete(RpgCharacter rpgCharacter)
		{
			this.blackboard.SetOrAddValue(rpgCharacter.CharacterName, rpgCharacter);
			UDebug.Debug("add character to blackboard:" + rpgCharacter.CharacterName, new object[0]);
			this.loadingCharacterCount--;
		}
	}
}
