using System;
using System.Collections.Generic;

namespace NodeCanvas.DialogueTrees
{
	public class MultipleChoiceRequestInfo
	{
		public readonly Dictionary<IStatement, int> options = new Dictionary<IStatement, int>();

		public readonly float availableTime;

		public readonly Action<int> SelectOption;

		public MultipleChoiceRequestInfo(Dictionary<IStatement, int> options, float availableTime, Action<int> callback)
		{
			this.options = options;
			this.availableTime = availableTime;
			this.SelectOption = callback;
		}
	}
}
