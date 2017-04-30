using Assets.Tools.Script.Debug.Log;
using Assets.Tools.Script.File;
using System;
using System.Text;
using UnityEngine;

namespace Assets.Extends.EXTools.Debug
{
	public class ApplicationErrorLog : MonoBehaviour
	{
		public const string ErrorFolder = "error/";

		private void Start()
		{
			Application.logMessageReceivedThreaded += new Application.LogCallback(this.OnErrorHandler);
		}

		public void OnDestroy()
		{
			Application.logMessageReceivedThreaded -= new Application.LogCallback(this.OnErrorHandler);
		}

		public string GetAllErrors()
		{
			string[] files = ESFile.GetFiles("error/");
			StringBuilder stringBuilder = new StringBuilder();
			string[] array = files;
			for (int i = 0; i < array.Length; i++)
			{
				string text = array[i];
				string text2 = text.Substring(0, text.Length - 4);
				stringBuilder.Append("\r\n");
				stringBuilder.Append("error/");
				stringBuilder.Append(text2);
				stringBuilder.Append("\r\n");
				string file = LogFile.GetFile("error/" + text2);
				if (file != null)
				{
					stringBuilder.Append("c");
					stringBuilder.Append(file);
				}
			}
			return stringBuilder.ToString();
		}

		public void DeleteAllErrors()
		{
			ESFile.Delete("error/");
		}

		private void OnErrorHandler(string condition, string stacktrace, LogType type)
		{
			if (type == LogType.Error || type == LogType.Exception)
			{
				string msg = "ERROR: " + condition + "\r\nstacktrace:\r\n" + stacktrace;
				DebugConsole.Log(msg);
			}
		}
	}
}
