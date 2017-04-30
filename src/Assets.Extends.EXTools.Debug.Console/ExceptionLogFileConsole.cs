using Assets.Tools.Script.Debug.Console;
using Assets.Tools.Script.Debug.Log;
using System;

namespace Assets.Extends.EXTools.Debug.Console
{
	public class ExceptionLogFileConsole : IDebugConsole
	{
		public void Log(string msg)
		{
		}

		public void Log(params object[] msgs)
		{
			for (int i = 0; i < msgs.Length; i++)
			{
				object obj = msgs[i];
				if (obj is Exception)
				{
					LogFile.TxtFile(obj.ToString(), "error/" + DateTime.Now.ToString("yy-MM-dd") + "_error");
				}
			}
		}

		public void LogToChannel(int channel, string msg)
		{
		}

		public void LogToChannel(int channel, params object[] msgs)
		{
			for (int i = 0; i < msgs.Length; i++)
			{
				object obj = msgs[i];
				if (obj is Exception)
				{
					LogFile.TxtFile(obj.ToString(), "error/" + DateTime.Now.ToString("yy-MM-dd") + "_error");
				}
			}
		}

		public void LogStackTrace()
		{
		}

		public void AddButton(string btnName, Action clickHandler)
		{
		}

		public void RemoveButton(string btnName)
		{
		}

		public void AddTopString(string stringName, string content)
		{
		}

		public void RemoveTopString(string stringName)
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
