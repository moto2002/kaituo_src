using Assets.Migration.Scripts.Node.ResourceLoader.Core;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Assets.Migration.Scripts.Node.ResourceLoader.Parser
{
	public class NcrBuffTagGameObjectParser : NcrParser
	{
		public const string BuffTagGameObjectTag = "Btg_";

		public const string BuffTagGameObjectPathTag = "[path]";

		public const string BuffTagGameObjectIdTag = "[id]";

		private int characterId;

		private List<string> labels;

		private string originalParameter;

		private List<string> paths;

		protected override void ParserOriginalParameter(NcrData loadData)
		{
			this.originalParameter = base.ReplaceBlackboard(loadData.OriginalParameter);
			this.characterId = this.TryGetId(this.originalParameter);
			this.originalParameter = this.originalParameter.Replace(string.Format("[{0}]", this.characterId), string.Empty);
			this.labels = this.GetBuffTag();
			if (this.labels != null && this.labels.Count > 0)
			{
				this.paths = new List<string>();
				for (int i = 0; i < this.labels.Count; i++)
				{
					string tagName = this.labels[i];
					string path = this.GetPath(this.originalParameter, tagName);
					if (path != null)
					{
						this.paths.Add(path);
					}
				}
			}
			else
			{
				this.labels = null;
				this.paths = null;
			}
		}

		protected override List<string> ConvertParameter(string originalString)
		{
			List<string> list = new List<string>();
			if (this.paths == null)
			{
				return list;
			}
			string text = base.ReplaceBlackboard(originalString);
			for (int i = 0; i < this.paths.Count; i++)
			{
				string newValue = this.paths[i];
				string text2 = text.Replace("[path]", newValue);
				text2 = text2.Replace("[id]", this.characterId.ToString());
				list.Add(text2);
			}
			return list;
		}

		protected override bool OnMatchTest(NcrData loadData)
		{
			return loadData.LoadType == NcrType.GameObject && loadData.OriginalParameter.StartsWith("Btg_");
		}

		private string GetPath(string matchString, string tagName)
		{
			if (!matchString.StartsWith("Btg_"))
			{
				return null;
			}
			string pattern = "(.*)(\\[path\\])(.*)";
			Regex regex = new Regex(pattern);
			Match match = regex.Match(matchString);
			if (match.Success)
			{
				string arg = match.Groups[1].ToString();
				string arg2 = match.Groups[3].ToString();
				string pattern2 = string.Format("({0})(.*)({1})", arg, arg2);
				Regex regex2 = new Regex(pattern2);
				Match match2 = regex2.Match(tagName);
				if (match2.Success)
				{
					return match2.Groups[2].ToString();
				}
			}
			return null;
		}

		private int TryGetId(string originalParameter)
		{
			string pattern = "(.*)\\[([0-9]*)\\]";
			Regex regex = new Regex(pattern);
			Match match = regex.Match(originalParameter);
			if (match.Success)
			{
				string value = match.Groups[2].ToString();
				return Convert.ToInt32(value);
			}
			return -1;
		}

		private List<string> GetBuffTag()
		{
			return null;
		}
	}
}
