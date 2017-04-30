using Assets.Tools.Script.Caller;
using System;
using System.Collections.Generic;

namespace Assets.Tools.Script.Debug
{
	public class RunningTimeLog
	{
		private static readonly Dictionary<string, DateTime> _tickTime = new Dictionary<string, DateTime>();

		public static double Run(Action a, int times = 1)
		{
			DateTime now = DateTime.Now;
			for (int i = 0; i < times; i++)
			{
				a();
			}
			DateTime now2 = DateTime.Now;
			return (now2 - now).TotalMilliseconds;
		}

		public static double RunAndPrint(Action a, int times = 1)
		{
			double num = RunningTimeLog.Run(a, times);
			DebugConsole.Log(new object[]
			{
				"a:RunningTime ",
				num
			});
			return num;
		}

		public static double RunAndContrast(Action a, Action b, int times = 1)
		{
			double num = RunningTimeLog.Run(a, times);
			double num2 = RunningTimeLog.Run(b, times);
			return num - num2;
		}

		public static void RunAndPrintInDisperseFrame(Action[] testFunctions, int times, int frame)
		{
			double[] totalMilliseconds = new double[testFunctions.Length];
			double currFrame = 0.0;
			FrameCall.Call(delegate
			{
				for (int i = 0; i < testFunctions.Length; i++)
				{
					totalMilliseconds[i] += RunningTimeLog.Run(testFunctions[i], times);
				}
				currFrame += 1.0;
				bool flag = currFrame < (double)frame;
				if (!flag)
				{
					for (int j = 0; j < testFunctions.Length; j++)
					{
						DebugConsole.Log(new object[]
						{
							j + ":RunningTime ",
							totalMilliseconds[j]
						});
					}
				}
				return flag;
			});
		}

		public static void TickTime(string tag)
		{
			RunningTimeLog._tickTime[tag] = DateTime.Now;
		}

		public static void LogDistanceTickTime(string tag)
		{
			DebugConsole.Log(string.Format("{0}:{1} ms", tag, (DateTime.Now - RunningTimeLog._tickTime[tag]).TotalMilliseconds));
			RunningTimeLog._tickTime.Remove(tag);
		}
	}
}
