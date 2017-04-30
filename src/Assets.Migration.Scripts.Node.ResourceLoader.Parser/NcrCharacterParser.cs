using Assets.Migration.Scripts.Node.ResourceLoader.Core;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Assets.Migration.Scripts.Node.ResourceLoader.Parser
{
	public class NcrCharacterParser : NcrParser
	{
		public const string UnitInstanceIdTag = "[id]";

		public const string UnitUnitIdTag = "[unitid]";

		private List<int> unitInstanceIds;

		private bool ignore;

		protected override void ParserOriginalParameter(NcrData loadData)
		{
			this.ignore = false;
			loadData.CacheData = new List<int>();
			this.unitInstanceIds = (List<int>)loadData.CacheData;
			string text = loadData.OriginalParameter;
			text = base.ReplaceBlackboard(text);
			if (text.Contains("[id]"))
			{
				string[] variableNames = this.blackboard.GetVariableNames(typeof(int));
				for (int i = 0; i < variableNames.Length; i++)
				{
					string variableName = variableNames[i];
					int id = this.GetId(text, variableName);
					if (id > 0)
					{
						this.unitInstanceIds.Add(id);
					}
				}
			}
			else
			{
				int num = this.TryGetId(text);
				if (num > 0)
				{
					this.unitInstanceIds.Add(num);
				}
				else if (num == 0)
				{
					this.ignore = true;
				}
			}
		}

		protected override List<string> ConvertParameter(string originalString)
		{
			return null;
		}

		protected override bool OnMatchTest(NcrData loadData)
		{
			return loadData.LoadType == NcrType.Character || loadData.LoadType == NcrType.CharacterGameObject;
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
					string value = match2.Groups[2].ToString();
					return Convert.ToInt32(value);
				}
			}
			return -1;
		}

		private int TryGetId(string originalParameter)
		{
			string pattern = "(.*)\\[([0-9]*)\\](.*)";
			Regex regex = new Regex(pattern);
			Match match = regex.Match(originalParameter);
			if (match.Success)
			{
				string value = match.Groups[2].ToString();
				return Convert.ToInt32(value);
			}
			return -1;
		}
	}
}
