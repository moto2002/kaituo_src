using NodeCanvas.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assets.Migration.Scripts.Node.ResourceLoader.Core
{
	public abstract class NcrParser
	{
		protected IBlackboard blackboard;

		private List<string> tagParts = new List<string>();

		private StringBuilder tagPart = new StringBuilder();

		private List<string> tagNames = new List<string>();

		private StringBuilder tagName = new StringBuilder();

		private StringBuilder tagStringResult = new StringBuilder();

		private NcrLoader loader;

		public bool AppendToLoaderIfMatch(IBlackboard blackboard, NcrData loadData)
		{
			this.blackboard = blackboard;
			bool flag = this.IsMatch(blackboard, loadData);
			if (flag)
			{
				this.ParserOriginalParameter(loadData);
				loadData.BlackboardName = this.ConvertParameter(loadData.OriginalBlackboardName);
				loadData.Path = this.ConvertParameter(loadData.OriginalPath);
				this.loader.Append(loadData);
			}
			return flag;
		}

		public void BindingLoader(NcrLoader loader)
		{
			this.loader = loader;
		}

		public virtual string GetTip()
		{
			return null;
		}

		protected abstract void ParserOriginalParameter(NcrData loadData);

		protected bool IsMatch(IBlackboard blackboard, NcrData loadData)
		{
			return this.OnMatchTest(loadData);
		}

		protected abstract List<string> ConvertParameter(string originalString);

		protected abstract bool OnMatchTest(NcrData loadData);

		protected string ReplaceBlackboard(string src)
		{
			Func<string, string> convertTag = delegate(string variableName)
			{
				Variable variable = this.blackboard.GetVariable(variableName, null);
				if (variable != null)
				{
					object value = variable.value;
					if (value != null)
					{
						return value.ToString();
					}
				}
				return string.Empty;
			};
			return this.ReplaceSpecialTag(src, '<', '>', convertTag);
		}

		protected string ReplaceSpecialTag(string src, char leftTag, char rightTag, Func<string, string> convertTag)
		{
			bool flag = false;
			for (int i = 0; i < src.Length; i++)
			{
				char c = src[i];
				if (c == leftTag)
				{
					flag = true;
					if (this.tagPart.Length > 0)
					{
						this.tagParts.Add(this.tagPart.ToString());
						this.tagPart.Remove(0, this.tagPart.Length);
					}
					else
					{
						this.tagParts.Add(string.Empty);
					}
				}
				else if (c == rightTag)
				{
					flag = false;
					if (this.tagName.Length > 0)
					{
						this.tagNames.Add(this.tagName.ToString());
						this.tagName.Remove(0, this.tagName.Length);
					}
					else
					{
						this.tagNames.Add(string.Empty);
					}
				}
				else if (flag)
				{
					this.tagName.Append(c);
				}
				else
				{
					this.tagPart.Append(c);
				}
			}
			if (this.tagPart.Length > 0)
			{
				this.tagParts.Add(this.tagPart.ToString());
			}
			for (int j = 0; j < this.tagParts.Count; j++)
			{
				this.tagStringResult.Append(this.tagParts[j]);
				if (j < this.tagNames.Count)
				{
					string arg = this.tagNames[j];
					string value = convertTag(arg);
					this.tagStringResult.Append(value);
				}
			}
			string result = this.tagStringResult.ToString();
			if (this.tagStringResult.Length > 0)
			{
				this.tagStringResult.Remove(0, this.tagStringResult.Length);
			}
			this.tagParts.Clear();
			this.tagNames.Clear();
			if (this.tagPart.Length > 0)
			{
				this.tagPart.Remove(0, this.tagPart.Length);
			}
			if (this.tagName.Length > 0)
			{
				this.tagName.Remove(0, this.tagName.Length);
			}
			return result;
		}
	}
}
