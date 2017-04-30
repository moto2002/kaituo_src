using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Assets.Script.SeferRaziel.Implement.Unity.Data.CsvDB
{
	public class CsvDataBaseRole
	{
		public static void load(string path)
		{
			TextAsset textAsset = Resources.Load(path, typeof(TextAsset)) as TextAsset;
			string text = textAsset.text;
			CsvDataBaseRole.Read(text);
		}

		public static string Write(List<List<string>> array)
		{
			StringBuilder stringBuilder = new StringBuilder();
			string empty = string.Empty;
			for (int i = 0; i < array.Count; i++)
			{
				List<string> row = array[i];
				stringBuilder.Append(CsvDataBaseRole.WriteLine(row));
				if (i != array.Count - 1)
				{
					stringBuilder.Append("\r\n");
				}
			}
			return stringBuilder.ToString();
		}

		public static string WriteLine(List<string> row)
		{
			string text = string.Empty;
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < row.Count; i++)
			{
				string text2 = row[i];
				text = text2.Replace("\"", "\"\"");
				bool flag = text.Contains(",");
				if (flag)
				{
					stringBuilder.Append("\"");
				}
				stringBuilder.Append(text);
				if (flag)
				{
					stringBuilder.Append("\"");
				}
				if (i != row.Count - 1)
				{
					stringBuilder.Append(",");
				}
			}
			return stringBuilder.ToString();
		}

		public static List<List<string>> Read(string raw)
		{
			string[] array = raw.Replace("\n", string.Empty).Split(new char[]
			{
				"\r"[0]
			});
			List<List<string>> list = new List<List<string>>();
			for (int i = 0; i < array.Length; i++)
			{
				if (!array[i].Contains("//") && array[i].Length != 0)
				{
					list.Add(CsvDataBaseRole.ReadLine(array[i]));
				}
			}
			return list;
		}

		public static List<string> ReadLine(string strline)
		{
			List<string> list = new List<string>();
			if (strline.Length == 0)
			{
				return list;
			}
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
				if (!CsvDataBaseRole.IfOddQuota(text2))
				{
					goto IL_9C;
				}
				flag = !flag;
				if (flag)
				{
					goto IL_9C;
				}
				text += text2;
				int num = text.IndexOf("\"\"");
				if (num > 0)
				{
					text = text.Remove(num, 1);
				}
				text = text.Substring(1, text.Length - 2);
				list.Add(text);
				text = string.Empty;
				IL_BD:
				i++;
				continue;
				IL_9C:
				if (flag)
				{
					text = text + text2 + ",";
					goto IL_BD;
				}
				list.Add(text2);
				goto IL_BD;
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
