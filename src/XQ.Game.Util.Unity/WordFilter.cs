using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using XQ.Framework.Lua.Utility;

namespace XQ.Game.Util.Unity
{
	public class WordFilter
	{
		private static Dictionary<char, IList<string>> maskWords;

		public static void Init()
		{
			string monoFileContent = LuaUtil.GetMonoFileContent("Data/GlobalConfig", "MaskWords.txt");
			WordFilter.HandleKeyWords(monoFileContent, ',');
		}

		public static void HandleKeyWords(string text, char separator)
		{
			if (string.IsNullOrEmpty(text))
			{
				WordFilter.maskWords = new Dictionary<char, IList<string>>();
			}
			else
			{
				string[] array = text.Split(new char[]
				{
					separator
				});
				WordFilter.maskWords = new Dictionary<char, IList<string>>(array.Length / 4);
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					string text2 = array2[i];
					if (!(text2 == string.Empty))
					{
						if (WordFilter.maskWords.ContainsKey(text2[0]))
						{
							WordFilter.maskWords[text2[0]].Add(text2);
						}
						else
						{
							WordFilter.maskWords.Add(text2[0], new List<string>
							{
								text2
							});
						}
					}
				}
			}
		}

		public static string Filter(string str)
		{
			if (string.IsNullOrEmpty(str))
			{
				return string.Empty;
			}
			int length = str.Length;
			StringBuilder stringBuilder = new StringBuilder(length);
			bool flag = true;
			for (int i = 0; i < length; i++)
			{
				if (WordFilter.maskWords.ContainsKey(str[i]))
				{
					foreach (string current in WordFilter.maskWords[str[i]])
					{
						flag = true;
						int num = i;
						string text = current;
						for (int j = 0; j < text.Length; j++)
						{
							char c = text[j];
							if (num >= length || c != str[num++])
							{
								flag = false;
								break;
							}
						}
						if (flag)
						{
							i += current.Length - 1;
							stringBuilder.Append('*', current.Length);
							break;
						}
					}
					if (!flag)
					{
						stringBuilder.Append(str[i]);
					}
				}
				else
				{
					stringBuilder.Append(str[i]);
				}
			}
			return stringBuilder.ToString();
		}

		public static bool Verify(string str)
		{
			return WordFilter.Filter(str) == str;
		}

		public static bool AccountPunctuationVerify(string str)
		{
			if (str.Contains("/n") || str.Contains("/r"))
			{
				return false;
			}
			string pattern = "^[A-Za-z0-9\\u4e00-\\u9fa5/_/@/.]+$";
			Regex regex = new Regex(pattern);
			return regex.IsMatch(str);
		}

		public static bool RegexVerify(string str, string pattern)
		{
			Regex regex = new Regex(pattern);
			return regex.IsMatch(str);
		}
	}
}
