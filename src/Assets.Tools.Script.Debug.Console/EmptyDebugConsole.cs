using System;

namespace Assets.Tools.Script.Debug.Console
{
	public class EmptyDebugConsole : IDebugConsole
	{
		public void Log(string msg)
		{
		}

		public void Log(params object[] msgs)
		{
		}

		public void LogStackTrace()
		{
		}

		public void LogToChannel(int channel, string msg)
		{
		}

		public void LogToChannel(int channel, params object[] msgs)
		{
		}

		public void AddButton(string name, Action clickHandler)
		{
		}

		public void RemoveButton(string name)
		{
		}

		public void AddTopString(string name, string content)
		{
		}

		public void RemoveTopString(string name)
		{
		}

		public void SetConsoleActive(bool consoleActive)
		{
		}

		public void Clear(int level)
		{
		}

		public string GetText()
		{
			return string.Empty;
		}
	}
}
