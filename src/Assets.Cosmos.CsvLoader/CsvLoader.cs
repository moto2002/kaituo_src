using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Cosmos.CsvLoader
{
	public class CsvLoader
	{
		public static List<List<string>> Array;

		public static void load(string path)
		{
			TextAsset textAsset = Resources.Load(path, typeof(TextAsset)) as TextAsset;
			string[] array = textAsset.text.Replace("\n", string.Empty).Split(new char[]
			{
				"\r"[0]
			});
			CsvLoader.Array = new List<List<string>>();
			for (int i = 0; i < array.Length; i++)
			{
				if (!array[i].Contains("//") && array[i].Length != 0)
				{
					CsvLoader.Array.Add(CsvLoader.Split(array[i]));
				}
			}
		}

		public static List<List<string>> Read(string text)
		{
			List<List<string>> list = new List<List<string>>();
			string[] array = text.Replace("\n", string.Empty).Split(new char[]
			{
				"\r"[0]
			});
			for (int i = 0; i < array.Length; i++)
			{
				if (!array[i].Contains("//") && array[i].Length != 0)
				{
					list.Add(CsvLoader.Split(array[i]));
				}
			}
			return list;
		}

		public static List<string> Split(string strline)
		{
			List<string> list = new List<string>();
			string[] array = strline.Split(new char[]
			{
				','
			});
			string text = string.Empty;
			bool flag = false;
			int i = 0;
			while (i < array.Length)
			{
				string text2 = array[i];
				if (!CsvLoader.IfOddQuota(text2))
				{
					goto IL_70;
				}
				flag = !flag;
				if (flag)
				{
					goto IL_70;
				}
				text += text2;
				text = text.Substring(1, text.Length - 1);
				list.Add(text);
				text = string.Empty;
				IL_8C:
				i++;
				continue;
				IL_70:
				if (flag)
				{
					text += text2;
					goto IL_8C;
				}
				list.Add(text2);
				goto IL_8C;
			}
			return list;
		}

		private static bool IfOddQuota(string dataLine)
		{
			int num = 0;
			for (int i = 0; i < dataLine.Length; i++)
			{
				if (dataLine[i] == '"')
				{
					num++;
				}
			}
			bool result = false;
			if (num % 2 == 1)
			{
				result = true;
			}
			return result;
		}
	}
}
