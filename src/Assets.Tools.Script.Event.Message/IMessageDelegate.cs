using System;

namespace Assets.Tools.Script.Event.Message
{
	public interface IMessageDelegate
	{
		string messageName
		{
			get;
		}

		bool Execute(object arg);

		bool Execute();
	}
}
