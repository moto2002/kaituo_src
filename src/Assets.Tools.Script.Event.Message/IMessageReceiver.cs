using System;
using System.Collections.Generic;

namespace Assets.Tools.Script.Event.Message
{
	public interface IMessageReceiver
	{
		IEnumerable<IMessageDelegate> GetDelegates();
	}
}
