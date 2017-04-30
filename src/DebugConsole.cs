using Assets.Tools.Script.Debug.Console;
using System;
using UnityEngine;

public class DebugConsole
{
	private static IDebugConsole _consoleImpl;

	public static IDebugConsole consoleImpl
	{
		get
		{
			IDebugConsole arg_17_0;
			if ((arg_17_0 = DebugConsole._consoleImpl) == null)
			{
				arg_17_0 = (DebugConsole._consoleImpl = new EmptyDebugConsole());
			}
			return arg_17_0;
		}
		set
		{
			DebugConsole._consoleImpl = value;
		}
	}

	public static void SetActive(bool active)
	{
		DebugConsole.consoleImpl.SetConsoleActive(active);
	}

	public static void AddTopString(string stringName, string content)
	{
		DebugConsole.consoleImpl.AddTopString(stringName, content);
	}

	public static void RemoveTopString(string stringName)
	{
		DebugConsole.consoleImpl.RemoveTopString(stringName);
	}

	public static void AddButton(string btnName, Action clickHandler)
	{
		DebugConsole.consoleImpl.AddButton(btnName, clickHandler);
	}

	public static void RemoveButton(string btnName)
	{
		DebugConsole.consoleImpl.RemoveButton(btnName);
	}

	public static void LogStackTrace()
	{
		DebugConsole.consoleImpl.LogStackTrace();
	}

	public static void Log(string msg)
	{
		DebugConsole.consoleImpl.Log(msg);
	}

	public static void Log(params object[] msgs)
	{
		DebugConsole.consoleImpl.Log(msgs);
	}

	public static void LogToChannel(int channel, string msg)
	{
		DebugConsole.consoleImpl.LogToChannel(channel, msg);
	}

	public static void LogToChannel(int channel, params object[] msgs)
	{
		DebugConsole.consoleImpl.LogToChannel(channel, msgs);
	}

	public static void DebugBreak()
	{
		Debug.Break();
	}

	public static void Clear(int level)
	{
		DebugConsole.consoleImpl.Clear(level);
	}

	public static string GetText()
	{
		return DebugConsole.consoleImpl.GetText();
	}
}
