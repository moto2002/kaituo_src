using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace XQ.Framework.Utility.Debug
{
	public static class UDebug
	{
		private struct LogInfo
		{
			public readonly LogType type;

			public readonly string format;

			public readonly object[] args;

			public readonly object msg;

			public LogInfo(LogType type, object msg, string format, object[] args)
			{
				this.type = type;
				this.msg = msg;
				this.format = format;
				this.args = args;
			}
		}

		public static bool OpenLog;

		private static int logIdx;

		private static readonly List<UDebug.LogInfo> logs;

		private static readonly Thread logThread;

		private static readonly UDebug.LogInfo empty;

		static UDebug()
		{
			UDebug.OpenLog = false;
			UDebug.logIdx = 0;
			UDebug.logs = new List<UDebug.LogInfo>(128);
			UDebug.empty = default(UDebug.LogInfo);
			if (UDebug.logThread != null)
			{
				return;
			}
			UDebug.logThread = new Thread(new ThreadStart(UDebug.DoLog))
			{
				IsBackground = true
			};
			UDebug.logThread.Start();
		}

		private static void DoLog()
		{
			while (true)
			{
				if (UDebug.logs.Count > 0)
				{
					UDebug.LogInfo orSetLog = UDebug.GetOrSetLog(false, LogType.Log, null, null, new object[0]);
					if (orSetLog.args != null)
					{
						UDebug.ToLogFormat(orSetLog.type, orSetLog.format, orSetLog.args);
					}
					else if (orSetLog.format != null)
					{
						UDebug.ToLog(orSetLog.type, orSetLog.format);
					}
					else
					{
						UDebug.ToLog(orSetLog.type, orSetLog.msg);
					}
				}
				Thread.Sleep(5);
			}
		}

		private static void ToLog(LogType type, object msg)
		{
			switch (type)
			{
			case LogType.Error:
				UnityEngine.Debug.LogError(msg);
				return;
			case LogType.Assert:
				break;
			case LogType.Warning:
				UnityEngine.Debug.LogWarning(msg);
				return;
			case LogType.Log:
				UnityEngine.Debug.Log(msg);
				return;
			case LogType.Exception:
				UnityEngine.Debug.LogException(msg as Exception);
				break;
			default:
				return;
			}
		}

		private static void ToLogFormat(LogType type, string msg, object[] args)
		{
			switch (type)
			{
			case LogType.Error:
				UnityEngine.Debug.LogErrorFormat(msg, args);
				break;
			case LogType.Assert:
				break;
			case LogType.Warning:
				UnityEngine.Debug.LogWarningFormat(msg, args);
				return;
			case LogType.Log:
				UnityEngine.Debug.LogFormat(msg, args);
				return;
			default:
				return;
			}
		}

		private static UDebug.LogInfo GetOrSetLog(bool set, LogType type, object msg, string format, params object[] args)
		{
			if (set)
			{
				UDebug.logs.Add(new UDebug.LogInfo(type, msg, format, args));
			}
			else if (UDebug.logs.Count > 0)
			{
				UDebug.LogInfo arg_5E_0 = UDebug.logs[UDebug.logIdx];
				if (++UDebug.logIdx == UDebug.logs.Count)
				{
					UDebug.logIdx = 0;
					UDebug.logs.Clear();
				}
				return arg_5E_0;
			}
			return UDebug.empty;
		}

		public static void Debug(string format, params object[] args)
		{
			if (UDebug.OpenLog)
			{
				UDebug.GetOrSetLog(true, LogType.Log, null, format, args);
			}
		}

		public static void Debug(object debug)
		{
			if (UDebug.OpenLog)
			{
				UDebug.GetOrSetLog(true, LogType.Log, debug, null, new object[0]);
			}
		}

		public static void Warn(string format, params object[] args)
		{
			UDebug.GetOrSetLog(true, LogType.Warning, null, format, args);
		}

		public static void Error(string format, params object[] args)
		{
			UDebug.GetOrSetLog(true, LogType.Error, null, format, args);
		}

		public static void Error(object msg)
		{
			UDebug.GetOrSetLog(true, LogType.Error, msg, null, new object[0]);
		}
	}
}
