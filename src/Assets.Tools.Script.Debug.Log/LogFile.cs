using Assets.Tools.Script.Core;
using Assets.Tools.Script.Serialized.LocalCache;
using System;
using UnityEngine;

namespace Assets.Tools.Script.Debug.Log
{
	public class LogFile
	{
		public static void TxtFile(string content, string fileName = "log")
		{
			try
			{
				Loom.QueueOnMainThread(delegate
				{
					try
					{
						LcStringFile lcStringFile = new LcStringFile(fileName);
						content = "\r\n" + DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss") + "\r\n" + content;
						DebugConsole.Log(content);
						if (lcStringFile.HasCache())
						{
							string value = lcStringFile.Value;
							lcStringFile.Value = value + content;
						}
						else
						{
							lcStringFile.Value = content;
						}
					}
					catch (Exception var_2_7E)
					{
					}
				});
			}
			catch (Exception)
			{
			}
		}

		public static string GetFile(string fileName)
		{
			LcStringFile lcStringFile = new LcStringFile(fileName);
			return lcStringFile.Value;
		}

		public static void Screenshot(string fileName)
		{
			try
			{
				Loom.QueueOnMainThread(delegate
				{
					try
					{
						Application.CaptureScreenshot(string.Concat(new string[]
						{
							"Log_",
							fileName,
							"_",
							DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss"),
							".png"
						}));
					}
					catch (Exception var_0_4B)
					{
					}
				});
			}
			catch (Exception)
			{
			}
		}
	}
}
