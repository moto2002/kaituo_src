using Assets.Migration.Scripts.Node.ResourceLoader.Core;
using System;
using System.Collections.Generic;

namespace Assets.Migration.Scripts.Node.ResourceLoader.Parser
{
	public class NcrGameObjectParser : NcrParser
	{
		protected override void ParserOriginalParameter(NcrData loadData)
		{
		}

		protected override List<string> ConvertParameter(string originalString)
		{
			string item = base.ReplaceBlackboard(originalString);
			return new List<string>
			{
				item
			};
		}

		protected override bool OnMatchTest(NcrData loadData)
		{
			return loadData.LoadType == NcrType.GameObject;
		}
	}
}
