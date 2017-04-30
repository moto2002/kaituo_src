using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace FullSerializer
{
	public static class fsJsonPrinter
	{
		private static void InsertSpacing(TextWriter stream, int count)
		{
			for (int i = 0; i < count; i++)
			{
				stream.Write("    ");
			}
		}

		private static string EscapeString(string str)
		{
			bool flag = false;
			int i = 0;
			while (i < str.Length)
			{
				char c = str[i];
				int num = Convert.ToInt32(c);
				if (num < 0 || num > 127)
				{
					flag = true;
					break;
				}
				char c2 = c;
				switch (c2)
				{
				case '\0':
				case '\a':
				case '\b':
				case '\t':
				case '\n':
				case '\f':
				case '\r':
					goto IL_87;
				case '\u0001':
				case '\u0002':
				case '\u0003':
				case '\u0004':
				case '\u0005':
				case '\u0006':
				case '\v':
					IL_70:
					if (c2 != '"' && c2 != '\\')
					{
						goto IL_8E;
					}
					goto IL_87;
				}
				goto IL_70;
				IL_8E:
				if (flag)
				{
					break;
				}
				i++;
				continue;
				IL_87:
				flag = true;
				goto IL_8E;
			}
			if (!flag)
			{
				return str;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int j = 0; j < str.Length; j++)
			{
				char c3 = str[j];
				int num2 = Convert.ToInt32(c3);
				if (num2 >= 0 && num2 <= 127)
				{
					char c2 = c3;
					switch (c2)
					{
					case '\0':
						stringBuilder.Append("\\0");
						goto IL_1F9;
					case '\u0001':
					case '\u0002':
					case '\u0003':
					case '\u0004':
					case '\u0005':
					case '\u0006':
					case '\v':
						IL_136:
						if (c2 == '"')
						{
							stringBuilder.Append("\\\"");
							goto IL_1F9;
						}
						if (c2 != '\\')
						{
							stringBuilder.Append(c3);
							goto IL_1F9;
						}
						stringBuilder.Append("\\\\");
						goto IL_1F9;
					case '\a':
						stringBuilder.Append("\\a");
						goto IL_1F9;
					case '\b':
						stringBuilder.Append("\\b");
						goto IL_1F9;
					case '\t':
						stringBuilder.Append("\\t");
						goto IL_1F9;
					case '\n':
						stringBuilder.Append("\\n");
						goto IL_1F9;
					case '\f':
						stringBuilder.Append("\\f");
						goto IL_1F9;
					case '\r':
						stringBuilder.Append("\\r");
						goto IL_1F9;
					}
					goto IL_136;
				}
				stringBuilder.Append(c3);
				IL_1F9:;
			}
			return stringBuilder.ToString();
		}

		private static void BuildCompressedString(fsData data, TextWriter stream)
		{
			switch (data.Type)
			{
			case fsDataType.Array:
			{
				stream.Write('[');
				bool flag = false;
				foreach (fsData current in data.AsList)
				{
					if (flag)
					{
						stream.Write(',');
					}
					flag = true;
					fsJsonPrinter.BuildCompressedString(current, stream);
				}
				stream.Write(']');
				break;
			}
			case fsDataType.Object:
			{
				stream.Write('{');
				bool flag2 = false;
				foreach (KeyValuePair<string, fsData> current2 in data.AsDictionary)
				{
					if (flag2)
					{
						stream.Write(',');
					}
					flag2 = true;
					stream.Write('"');
					stream.Write(current2.Key);
					stream.Write('"');
					stream.Write(":");
					fsJsonPrinter.BuildCompressedString(current2.Value, stream);
				}
				stream.Write('}');
				break;
			}
			case fsDataType.Double:
				stream.Write(fsJsonPrinter.ConvertDoubleToString(data.AsDouble));
				break;
			case fsDataType.Int64:
				stream.Write(data.AsInt64);
				break;
			case fsDataType.Boolean:
				if (data.AsBool)
				{
					stream.Write("true");
				}
				else
				{
					stream.Write("false");
				}
				break;
			case fsDataType.String:
				stream.Write('"');
				stream.Write(fsJsonPrinter.EscapeString(data.AsString));
				stream.Write('"');
				break;
			case fsDataType.Null:
				stream.Write("null");
				break;
			}
		}

		private static void BuildPrettyString(fsData data, TextWriter stream, int depth)
		{
			switch (data.Type)
			{
			case fsDataType.Array:
				if (data.AsList.Count == 0)
				{
					stream.Write("[]");
				}
				else
				{
					bool flag = false;
					stream.Write('[');
					stream.WriteLine();
					foreach (fsData current in data.AsList)
					{
						if (flag)
						{
							stream.Write(',');
							stream.WriteLine();
						}
						flag = true;
						fsJsonPrinter.InsertSpacing(stream, depth + 1);
						fsJsonPrinter.BuildPrettyString(current, stream, depth + 1);
					}
					stream.WriteLine();
					fsJsonPrinter.InsertSpacing(stream, depth);
					stream.Write(']');
				}
				break;
			case fsDataType.Object:
			{
				stream.Write('{');
				stream.WriteLine();
				bool flag2 = false;
				foreach (KeyValuePair<string, fsData> current2 in data.AsDictionary)
				{
					if (flag2)
					{
						stream.Write(',');
						stream.WriteLine();
					}
					flag2 = true;
					fsJsonPrinter.InsertSpacing(stream, depth + 1);
					stream.Write('"');
					stream.Write(current2.Key);
					stream.Write('"');
					stream.Write(": ");
					fsJsonPrinter.BuildPrettyString(current2.Value, stream, depth + 1);
				}
				stream.WriteLine();
				fsJsonPrinter.InsertSpacing(stream, depth);
				stream.Write('}');
				break;
			}
			case fsDataType.Double:
				stream.Write(fsJsonPrinter.ConvertDoubleToString(data.AsDouble));
				break;
			case fsDataType.Int64:
				stream.Write(data.AsInt64);
				break;
			case fsDataType.Boolean:
				if (data.AsBool)
				{
					stream.Write("true");
				}
				else
				{
					stream.Write("false");
				}
				break;
			case fsDataType.String:
				stream.Write('"');
				stream.Write(fsJsonPrinter.EscapeString(data.AsString));
				stream.Write('"');
				break;
			case fsDataType.Null:
				stream.Write("null");
				break;
			}
		}

		public static void PrettyJson(fsData data, TextWriter outputStream)
		{
			fsJsonPrinter.BuildPrettyString(data, outputStream, 0);
		}

		public static string PrettyJson(fsData data)
		{
			StringBuilder stringBuilder = new StringBuilder();
			string result;
			using (StringWriter stringWriter = new StringWriter(stringBuilder))
			{
				fsJsonPrinter.BuildPrettyString(data, stringWriter, 0);
				result = stringBuilder.ToString();
			}
			return result;
		}

		public static void CompressedJson(fsData data, StreamWriter outputStream)
		{
			fsJsonPrinter.BuildCompressedString(data, outputStream);
		}

		public static string CompressedJson(fsData data)
		{
			StringBuilder stringBuilder = new StringBuilder();
			string result;
			using (StringWriter stringWriter = new StringWriter(stringBuilder))
			{
				fsJsonPrinter.BuildCompressedString(data, stringWriter);
				result = stringBuilder.ToString();
			}
			return result;
		}

		private static string ConvertDoubleToString(double d)
		{
			if (double.IsInfinity(d) || double.IsNaN(d))
			{
				return d.ToString(CultureInfo.InvariantCulture);
			}
			string text = d.ToString(CultureInfo.InvariantCulture);
			if (!text.Contains(".") && !text.Contains("e") && !text.Contains("E"))
			{
				text += ".0";
			}
			return text;
		}
	}
}
