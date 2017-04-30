using System;

namespace Assets.Tools.Script.Debug.Console
{
	public interface IDebugConsole
	{
		void Log(string msg);

		void Log(params object[] msgs);

		void LogStackTrace();

		void LogToChannel(int channel, string msg);

		void LogToChannel(int channel, params object[] msgs);

		void AddButton(string btnName, Action clickHandler);

		void RemoveButton(string btnName);

		void AddTopString(string stringName, string content);

		void RemoveTopString(string stringName);

		void SetConsoleActive(bool consoleActive);

		void Clear(int level);

		string GetText();
	}
}
