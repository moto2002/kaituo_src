using System;
using System.Text.RegularExpressions;

namespace ParadoxNotion
{
	public static class StringExtensions
	{
		public static string SplitCamelCase(this string s)
		{
			if (string.IsNullOrEmpty(s))
			{
				return s;
			}
			s = char.ToUpper(s[0]) + s.Substring(1);
			return Regex.Replace(s, "(?<=[a-z])([A-Z])", " $1").Trim();
		}

		public static string GetCapitals(this string s)
		{
			string text = string.Empty;
			for (int i = 0; i < s.Length; i++)
			{
				char c = s[i];
				if (char.IsUpper(c))
				{
					text += c.ToString();
				}
			}
			return text.Trim();
		}
	}
}
