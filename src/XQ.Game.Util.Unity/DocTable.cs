using System;
using System.Collections.Generic;

namespace XQ.Game.Util.Unity
{
	public class DocTable
	{
		public static List<Dictionary<string, string>> Decode(string text)
		{
			return DocTable.Decode(text.Split(new string[]
			{
				"\r\n"
			}, StringSplitOptions.None));
		}

		public static List<Dictionary<string, string>> Decode(string[] allLines)
		{
			List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
			string[] array = allLines[1].Split(new char[]
			{
				','
			});
			int num = array.Length;
			Dictionary<string, string> dictionary = null;
			int num2 = 0;
			for (int i = 2; i < allLines.Length; i++)
			{
				if (num2 % num == 0)
				{
					num2 = 0;
					dictionary = new Dictionary<string, string>();
					list.Add(dictionary);
				}
				dictionary.Add(array[num2], allLines[i]);
				num2++;
			}
			return list;
		}
	}
}
