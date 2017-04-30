using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace FullSerializer
{
	public class fsJsonParser
	{
		private int _start;

		private string _input;

		private readonly StringBuilder _cachedStringBuilder = new StringBuilder(256);

		private fsJsonParser(string input)
		{
			this._input = input;
			this._start = 0;
		}

		private fsResult MakeFailure(string message)
		{
			int num = Math.Max(0, this._start - 20);
			int length = Math.Min(50, this._input.Length - num);
			string warning = string.Concat(new string[]
			{
				"Error while parsing: ",
				message,
				"; context = <",
				this._input.Substring(num, length),
				">"
			});
			return fsResult.Fail(warning);
		}

		private bool TryMoveNext()
		{
			if (this._start < this._input.Length)
			{
				this._start++;
				return true;
			}
			return false;
		}

		private bool HasValue()
		{
			return this.HasValue(0);
		}

		private bool HasValue(int offset)
		{
			return this._start + offset >= 0 && this._start + offset < this._input.Length;
		}

		private char Character()
		{
			return this.Character(0);
		}

		private char Character(int offset)
		{
			return this._input[this._start + offset];
		}

		private void SkipSpace()
		{
			while (this.HasValue())
			{
				char c = this.Character();
				if (char.IsWhiteSpace(c))
				{
					this.TryMoveNext();
				}
				else
				{
					if (!this.HasValue(1) || this.Character(0) != '/')
					{
						break;
					}
					if (this.Character(1) == '/')
					{
						while (this.HasValue() && !Environment.NewLine.Contains(string.Empty + this.Character()))
						{
							this.TryMoveNext();
						}
					}
					else if (this.Character(1) == '*')
					{
						this.TryMoveNext();
						this.TryMoveNext();
						while (this.HasValue(1))
						{
							if (this.Character(0) == '*' && this.Character(1) == '/')
							{
								this.TryMoveNext();
								this.TryMoveNext();
								this.TryMoveNext();
								break;
							}
							this.TryMoveNext();
						}
					}
				}
			}
		}

		private bool IsHex(char c)
		{
			return (c >= '0' && c <= '9') || (c >= 'a' && c <= 'f') || (c >= 'A' && c <= 'F');
		}

		private uint ParseSingleChar(char c1, uint multipliyer)
		{
			uint result = 0u;
			if (c1 >= '0' && c1 <= '9')
			{
				result = (uint)(c1 - '0') * multipliyer;
			}
			else if (c1 >= 'A' && c1 <= 'F')
			{
				result = (uint)(c1 - 'A' + '\n') * multipliyer;
			}
			else if (c1 >= 'a' && c1 <= 'f')
			{
				result = (uint)(c1 - 'a' + '\n') * multipliyer;
			}
			return result;
		}

		private uint ParseUnicode(char c1, char c2, char c3, char c4)
		{
			uint num = this.ParseSingleChar(c1, 4096u);
			uint num2 = this.ParseSingleChar(c2, 256u);
			uint num3 = this.ParseSingleChar(c3, 16u);
			uint num4 = this.ParseSingleChar(c4, 1u);
			return num + num2 + num3 + num4;
		}

		private fsResult TryUnescapeChar(out char escaped)
		{
			this.TryMoveNext();
			if (!this.HasValue())
			{
				escaped = ' ';
				return this.MakeFailure("Unexpected end of input after \\");
			}
			char c = this.Character();
			switch (c)
			{
			case 'n':
				this.TryMoveNext();
				escaped = '\n';
				return fsResult.Success;
			case 'o':
			case 'p':
			case 'q':
			case 's':
				IL_52:
				switch (c)
				{
				case 'a':
					this.TryMoveNext();
					escaped = '\a';
					return fsResult.Success;
				case 'b':
					this.TryMoveNext();
					escaped = '\b';
					return fsResult.Success;
				case 'c':
				case 'd':
				case 'e':
					IL_73:
					if (c == '/')
					{
						this.TryMoveNext();
						escaped = '/';
						return fsResult.Success;
					}
					if (c == '0')
					{
						this.TryMoveNext();
						escaped = '\0';
						return fsResult.Success;
					}
					if (c == '"')
					{
						this.TryMoveNext();
						escaped = '"';
						return fsResult.Success;
					}
					if (c != '\\')
					{
						escaped = '\0';
						return this.MakeFailure(string.Format("Invalid escape sequence \\{0}", this.Character()));
					}
					this.TryMoveNext();
					escaped = '\\';
					return fsResult.Success;
				case 'f':
					this.TryMoveNext();
					escaped = '\f';
					return fsResult.Success;
				}
				goto IL_73;
			case 'r':
				this.TryMoveNext();
				escaped = '\r';
				return fsResult.Success;
			case 't':
				this.TryMoveNext();
				escaped = '\t';
				return fsResult.Success;
			case 'u':
				this.TryMoveNext();
				if (this.IsHex(this.Character(0)) && this.IsHex(this.Character(1)) && this.IsHex(this.Character(2)) && this.IsHex(this.Character(3)))
				{
					uint num = this.ParseUnicode(this.Character(0), this.Character(1), this.Character(2), this.Character(3));
					this.TryMoveNext();
					this.TryMoveNext();
					this.TryMoveNext();
					this.TryMoveNext();
					escaped = (char)num;
					return fsResult.Success;
				}
				escaped = '\0';
				return this.MakeFailure(string.Format("invalid escape sequence '\\u{0}{1}{2}{3}'\n", new object[]
				{
					this.Character(0),
					this.Character(1),
					this.Character(2),
					this.Character(3)
				}));
			}
			goto IL_52;
		}

		private fsResult TryParseExact(string content)
		{
			for (int i = 0; i < content.Length; i++)
			{
				if (this.Character() != content[i])
				{
					return this.MakeFailure("Expected " + content[i]);
				}
				if (!this.TryMoveNext())
				{
					return this.MakeFailure("Unexpected end of content when parsing " + content);
				}
			}
			return fsResult.Success;
		}

		private fsResult TryParseTrue(out fsData data)
		{
			fsResult result = this.TryParseExact("true");
			if (result.Succeeded)
			{
				data = new fsData(true);
				return fsResult.Success;
			}
			data = null;
			return result;
		}

		private fsResult TryParseFalse(out fsData data)
		{
			fsResult result = this.TryParseExact("false");
			if (result.Succeeded)
			{
				data = new fsData(false);
				return fsResult.Success;
			}
			data = null;
			return result;
		}

		private fsResult TryParseNull(out fsData data)
		{
			fsResult result = this.TryParseExact("null");
			if (result.Succeeded)
			{
				data = new fsData();
				return fsResult.Success;
			}
			data = null;
			return result;
		}

		private bool IsSeparator(char c)
		{
			return char.IsWhiteSpace(c) || c == ',' || c == '}' || c == ']';
		}

		private fsResult TryParseNumber(out fsData data)
		{
			int start = this._start;
			while (this.TryMoveNext() && this.HasValue() && !this.IsSeparator(this.Character()))
			{
			}
			string text = this._input.Substring(start, this._start - start);
			if (text.Contains(".") || text.Contains("e") || text.Contains("E") || text == "Infinity" || text == "-Infinity" || text == "NaN")
			{
				double f;
				if (!double.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out f))
				{
					data = null;
					return this.MakeFailure("Bad double format with " + text);
				}
				data = new fsData(f);
				return fsResult.Success;
			}
			else
			{
				long i;
				if (!long.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out i))
				{
					data = null;
					return this.MakeFailure("Bad Int64 format with " + text);
				}
				data = new fsData(i);
				return fsResult.Success;
			}
		}

		private fsResult TryParseString(out string str)
		{
			this._cachedStringBuilder.Length = 0;
			if (this.Character() != '"' || !this.TryMoveNext())
			{
				str = string.Empty;
				return this.MakeFailure("Expected initial \" when parsing a string");
			}
			while (this.HasValue() && this.Character() != '"')
			{
				char c = this.Character();
				if (c == '\\')
				{
					char value;
					fsResult result = this.TryUnescapeChar(out value);
					if (result.Failed)
					{
						str = string.Empty;
						return result;
					}
					this._cachedStringBuilder.Append(value);
				}
				else
				{
					this._cachedStringBuilder.Append(c);
					if (!this.TryMoveNext())
					{
						str = string.Empty;
						return this.MakeFailure("Unexpected end of input when reading a string");
					}
				}
			}
			if (!this.HasValue() || this.Character() != '"' || !this.TryMoveNext())
			{
				str = string.Empty;
				return this.MakeFailure("No closing \" when parsing a string");
			}
			str = this._cachedStringBuilder.ToString();
			return fsResult.Success;
		}

		private fsResult TryParseArray(out fsData arr)
		{
			if (this.Character() != '[')
			{
				arr = null;
				return this.MakeFailure("Expected initial [ when parsing an array");
			}
			if (!this.TryMoveNext())
			{
				arr = null;
				return this.MakeFailure("Unexpected end of input when parsing an array");
			}
			this.SkipSpace();
			List<fsData> list = new List<fsData>();
			while (this.HasValue() && this.Character() != ']')
			{
				fsData item;
				fsResult result = this.RunParse(out item);
				if (result.Failed)
				{
					arr = null;
					return result;
				}
				list.Add(item);
				this.SkipSpace();
				if (this.HasValue() && this.Character() == ',')
				{
					if (!this.TryMoveNext())
					{
						break;
					}
					this.SkipSpace();
				}
			}
			if (!this.HasValue() || this.Character() != ']' || !this.TryMoveNext())
			{
				arr = null;
				return this.MakeFailure("No closing ] for array");
			}
			arr = new fsData(list);
			return fsResult.Success;
		}

		private fsResult TryParseObject(out fsData obj)
		{
			if (this.Character() != '{')
			{
				obj = null;
				return this.MakeFailure("Expected initial { when parsing an object");
			}
			if (!this.TryMoveNext())
			{
				obj = null;
				return this.MakeFailure("Unexpected end of input when parsing an object");
			}
			this.SkipSpace();
			Dictionary<string, fsData> dictionary = new Dictionary<string, fsData>((!fsGlobalConfig.IsCaseSensitive) ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal);
			while (this.HasValue() && this.Character() != '}')
			{
				this.SkipSpace();
				string text;
				fsResult result = this.TryParseString(out text);
				if (result.Failed)
				{
					obj = null;
					return result;
				}
				this.SkipSpace();
				if (!this.HasValue() || this.Character() != ':' || !this.TryMoveNext())
				{
					obj = null;
					return this.MakeFailure("Expected : after key \"" + text + "\"");
				}
				this.SkipSpace();
				fsData value;
				result = this.RunParse(out value);
				if (result.Failed)
				{
					obj = null;
					return result;
				}
				dictionary.Add(text, value);
				this.SkipSpace();
				if (this.HasValue() && this.Character() == ',')
				{
					if (!this.TryMoveNext())
					{
						break;
					}
					this.SkipSpace();
				}
			}
			if (!this.HasValue() || this.Character() != '}' || !this.TryMoveNext())
			{
				obj = null;
				return this.MakeFailure("No closing } for object");
			}
			obj = new fsData(dictionary);
			return fsResult.Success;
		}

		private fsResult RunParse(out fsData data)
		{
			this.SkipSpace();
			if (!this.HasValue())
			{
				data = null;
				return this.MakeFailure("Unexpected end of input");
			}
			char c = this.Character();
			switch (c)
			{
			case '"':
			{
				string str;
				fsResult result = this.TryParseString(out str);
				if (result.Failed)
				{
					data = null;
					return result;
				}
				data = new fsData(str);
				return fsResult.Success;
			}
			case '#':
			case '$':
			case '%':
			case '&':
			case '\'':
			case '(':
			case ')':
			case '*':
			case ',':
			case '/':
				IL_90:
				if (c == 'I' || c == 'N')
				{
					goto IL_CD;
				}
				if (c == '[')
				{
					return this.TryParseArray(out data);
				}
				if (c == 'f')
				{
					return this.TryParseFalse(out data);
				}
				if (c == 'n')
				{
					return this.TryParseNull(out data);
				}
				if (c == 't')
				{
					return this.TryParseTrue(out data);
				}
				if (c != '{')
				{
					data = null;
					return this.MakeFailure("unable to parse; invalid token \"" + this.Character() + "\"");
				}
				return this.TryParseObject(out data);
			case '+':
			case '-':
			case '.':
			case '0':
			case '1':
			case '2':
			case '3':
			case '4':
			case '5':
			case '6':
			case '7':
			case '8':
			case '9':
				goto IL_CD;
			}
			goto IL_90;
			IL_CD:
			return this.TryParseNumber(out data);
		}

		public static fsResult Parse(string input, out fsData data)
		{
			if (string.IsNullOrEmpty(input))
			{
				data = null;
				return fsResult.Fail("No input");
			}
			fsJsonParser fsJsonParser = new fsJsonParser(input);
			return fsJsonParser.RunParse(out data);
		}

		public static fsData Parse(string input)
		{
			fsData result;
			fsJsonParser.Parse(input, out result).AssertSuccess();
			return result;
		}
	}
}
