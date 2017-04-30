using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UnityEngine;

public static class NGUITextExt
{
	public static UIAtlas curEmojiAtlas;

	private static int mNativeLine;

	private static readonly EmojiInfo DefaultEmoji = EmojiInfo.Default();

	private static EmojiInfo mEmojiInfo = NGUITextExt.DefaultEmoji;

	private static CharacterInfo mTempChar;

	public static bool WrapText(string text, out string finalText, bool keepCharCount, bool wrapLineColors, bool useEllipsis = false, UILabelEmoji emojiLabel = null)
	{
		if (NGUIText.regionWidth < 1 || NGUIText.regionHeight < 1 || NGUIText.finalLineHeight < 1f)
		{
			finalText = string.Empty;
			return false;
		}
		float num = (NGUIText.maxLines <= 0) ? ((float)NGUIText.regionHeight) : Mathf.Min((float)NGUIText.regionHeight, NGUIText.finalLineHeight * (float)NGUIText.maxLines);
		int num2 = (NGUIText.maxLines <= 0) ? 1000000 : NGUIText.maxLines;
		num2 = Mathf.FloorToInt(Mathf.Min((float)num2, num / NGUIText.finalLineHeight) + 0.01f);
		if (num2 == 0)
		{
			finalText = string.Empty;
			return false;
		}
		NGUITextExt.mNativeLine = 0;
		NGUITextExt.mEmojiInfo = NGUITextExt.DefaultEmoji;
		if (string.IsNullOrEmpty(text))
		{
			text = " ";
		}
		NGUIText.Prepare(text);
		StringBuilder stringBuilder = new StringBuilder();
		int length = text.Length;
		float num3 = (float)NGUIText.regionWidth;
		int num4 = 0;
		int i = 0;
		int num5 = 1;
		int prev = 0;
		bool flag = true;
		bool flag2 = true;
		bool flag3 = false;
		Color color = NGUIText.tint;
		int num6 = 0;
		bool flag4 = false;
		bool flag5 = false;
		bool flag6 = false;
		bool flag7 = false;
		bool flag8 = false;
		if (!NGUIText.useSymbols)
		{
			wrapLineColors = false;
		}
		if (wrapLineColors)
		{
			NGUIText.mColors.Add(color);
			stringBuilder.Append("[");
			stringBuilder.Append(NGUIText.EncodeColor(color));
			stringBuilder.Append("]");
		}
		while (i < length)
		{
			char c = text[i];
			if (c > '⿿')
			{
				flag3 = true;
			}
			if (c == '\n')
			{
				if (num5 == num2)
				{
					break;
				}
				num3 = (float)NGUIText.regionWidth;
				if (num4 < i)
				{
					stringBuilder.Append(text.Substring(num4, i - num4 + 1));
				}
				else
				{
					stringBuilder.Append(c);
				}
				if (wrapLineColors)
				{
					for (int j = 0; j < NGUIText.mColors.size; j++)
					{
						stringBuilder.Insert(stringBuilder.Length - 1, "[-]");
					}
					for (int k = 0; k < NGUIText.mColors.size; k++)
					{
						stringBuilder.Append("[");
						stringBuilder.Append(NGUIText.EncodeColor(NGUIText.mColors[k]));
						stringBuilder.Append("]");
					}
				}
				flag = true;
				num5++;
				num4 = i + 1;
				prev = 0;
				NGUITextExt.mNativeLine++;
				emojiLabel.totalLine++;
			}
			else
			{
				if (NGUIText.encoding)
				{
					if (!wrapLineColors)
					{
						if (NGUITextExt.ParseSymbol(text, ref i))
						{
							if (NGUITextExt.mEmojiInfo != NGUITextExt.DefaultEmoji)
							{
								NGUITextExt.mEmojiInfo.gapLength = NGUITextExt.mEmojiInfo.gapLength + (float)emojiLabel.gapSet;
								float num7 = NGUITextExt.mEmojiInfo.gapLength + emojiLabel.offsetWidth * NGUIText.fontScale;
								if (num7 > num3)
								{
									stringBuilder.Append(text.Substring(num4, Mathf.Max(0, NGUITextExt.mEmojiInfo.startSpaceIdx - num4)));
									NGUITextExt.EndLine(ref stringBuilder, ref emojiLabel.totalLine);
									num3 = (float)NGUIText.regionWidth - num7;
									num4 = NGUITextExt.mEmojiInfo.startSpaceIdx;
									NGUITextExt.mEmojiInfo.newLine = keepCharCount;
								}
								else
								{
									num3 -= num7;
								}
								if (NGUITextExt.mEmojiInfo.line != emojiLabel.totalLine)
								{
									NGUITextExt.mEmojiInfo.startSpaceIdx = NGUITextExt.mEmojiInfo.startSpaceIdx + (emojiLabel.totalLine - NGUITextExt.mNativeLine);
								}
								NGUITextExt.mEmojiInfo.line = emojiLabel.totalLine;
								if (emojiLabel)
								{
									emojiLabel.emojiList.Add(NGUITextExt.mEmojiInfo);
								}
								float newLineOffset;
								if (!emojiLabel.emojiLineHeightOffset.TryGetValue(emojiLabel.totalLine, out newLineOffset))
								{
									emojiLabel.emojiLineHeightOffset.Add(emojiLabel.totalLine, NGUITextExt.mEmojiInfo.newLineOffset);
								}
								else
								{
									if (NGUITextExt.mEmojiInfo.newLineOffset > newLineOffset)
									{
										newLineOffset = NGUITextExt.mEmojiInfo.newLineOffset;
									}
									emojiLabel.emojiLineHeightOffset[emojiLabel.totalLine] = newLineOffset;
								}
								NGUITextExt.mEmojiInfo = NGUITextExt.DefaultEmoji;
							}
							i--;
							goto IL_9EE;
						}
					}
					else if (NGUITextExt.ParseSymbol(text, ref i, NGUIText.mColors, NGUIText.premultiply, ref num6, ref flag4, ref flag5, ref flag6, ref flag7, ref flag8))
					{
						if (flag8)
						{
							color = NGUIText.mColors[NGUIText.mColors.size - 1];
							color.a *= NGUIText.mAlpha * NGUIText.tint.a;
						}
						else
						{
							color = NGUIText.tint * NGUIText.mColors[NGUIText.mColors.size - 1];
							color.a *= NGUIText.mAlpha;
						}
						int l = 0;
						int num8 = NGUIText.mColors.size - 2;
						while (l < num8)
						{
							color.a *= NGUIText.mColors[l].a;
							l++;
						}
						i--;
						if (num4 < i)
						{
							stringBuilder.Append(text.Substring(num4, i - num4 + 1));
						}
						else
						{
							stringBuilder.Append(c);
						}
						num4 = i + 1;
						goto IL_9EE;
					}
				}
				BMSymbol bMSymbol = (!NGUIText.useSymbols) ? null : NGUIText.GetSymbol(text, i, length);
				float num9;
				if (bMSymbol == null)
				{
					float glyphWidth = NGUIText.GetGlyphWidth((int)c, prev);
					if (glyphWidth == 0f && !NGUIText.IsSpace((int)c))
					{
						goto IL_9EE;
					}
					num9 = NGUIText.finalSpacingX + glyphWidth;
				}
				else
				{
					num9 = NGUIText.finalSpacingX + (float)bMSymbol.advance * NGUIText.fontScale;
				}
				num3 -= num9;
				if (NGUIText.IsSpace((int)c) && !flag3 && num4 < i)
				{
					int num10 = i - num4 + 1;
					if (num5 == num2 && num3 <= 0f && i < length)
					{
						char c2 = text[i];
						if (c2 < ' ' || NGUIText.IsSpace((int)c2))
						{
							num10--;
						}
					}
					stringBuilder.Append(text.Substring(num4, num10));
					flag = false;
					num4 = i + 1;
				}
				if (Mathf.RoundToInt(num3) < 0)
				{
					if (flag || num5 == num2)
					{
						if (useEllipsis && num5 == num2 && i > 1)
						{
							float num11 = NGUIText.GetGlyphWidth(46, 46) * 3f;
							if (num11 < (float)NGUIText.regionWidth)
							{
								num3 += num9;
								int num12 = i;
								int num13 = 0;
								while (num12 > 1 && num3 < num11)
								{
									num12--;
									char prev2 = text[num12 - 1];
									char ch = text[num12];
									bool flag9 = num3 == 0f && NGUIText.IsSpace((int)ch);
									num3 += NGUIText.GetGlyphWidth((int)ch, (int)prev2);
									if (num12 < num4 && !flag9)
									{
										num13++;
									}
								}
								if (num3 >= num11)
								{
									if (num13 > 0)
									{
										stringBuilder.Length = Mathf.Max(0, stringBuilder.Length - num13);
									}
									stringBuilder.Append(text.Substring(num4, Mathf.Max(0, num12 - num4)));
									while (stringBuilder.Length > 0 && NGUIText.IsSpace((int)stringBuilder[stringBuilder.Length - 1]))
									{
										stringBuilder.Length--;
									}
									stringBuilder.Append("...");
									num5++;
									i = (num4 = num12);
									break;
								}
							}
						}
						stringBuilder.Append(text.Substring(num4, Mathf.Max(0, i - num4)));
						bool flag10 = NGUIText.IsSpace((int)c);
						if (!flag10 && !flag3)
						{
							flag2 = false;
						}
						if (wrapLineColors && NGUIText.mColors.size > 0)
						{
							stringBuilder.Append("[-]");
						}
						if (num5++ == num2)
						{
							num4 = i;
							break;
						}
						if (keepCharCount)
						{
							NGUITextExt.ReplaceSpaceWithNewline(ref stringBuilder, ref emojiLabel.totalLine);
						}
						else
						{
							NGUITextExt.EndLine(ref stringBuilder, ref emojiLabel.totalLine);
						}
						if (wrapLineColors)
						{
							for (int m = 0; m < NGUIText.mColors.size; m++)
							{
								stringBuilder.Insert(stringBuilder.Length - 1, "[-]");
							}
							for (int n = 0; n < NGUIText.mColors.size; n++)
							{
								stringBuilder.Append("[");
								stringBuilder.Append(NGUIText.EncodeColor(NGUIText.mColors[n]));
								stringBuilder.Append("]");
							}
						}
						flag = true;
						if (flag10)
						{
							num4 = i + 1;
							num3 = (float)NGUIText.regionWidth;
						}
						else
						{
							num4 = i;
							num3 = (float)NGUIText.regionWidth - num9;
						}
						prev = 0;
					}
					else
					{
						flag = true;
						num3 = (float)NGUIText.regionWidth;
						i = num4 - 1;
						prev = 0;
						if (num5++ == num2)
						{
							break;
						}
						if (keepCharCount)
						{
							NGUITextExt.ReplaceSpaceWithNewline(ref stringBuilder, ref emojiLabel.totalLine);
						}
						else
						{
							NGUITextExt.EndLine(ref stringBuilder, ref emojiLabel.totalLine);
						}
						if (wrapLineColors)
						{
							for (int num14 = 0; num14 < NGUIText.mColors.size; num14++)
							{
								stringBuilder.Insert(stringBuilder.Length - 1, "[-]");
							}
							for (int num15 = 0; num15 < NGUIText.mColors.size; num15++)
							{
								stringBuilder.Append("[");
								stringBuilder.Append(NGUIText.EncodeColor(NGUIText.mColors[num15]));
								stringBuilder.Append("]");
							}
						}
						goto IL_9EE;
					}
				}
				else
				{
					prev = (int)c;
				}
				if (bMSymbol != null)
				{
					i += bMSymbol.length - 1;
					prev = 0;
				}
			}
			IL_9EE:
			i++;
		}
		if (num4 < i)
		{
			stringBuilder.Append(text.Substring(num4, i - num4));
		}
		if (wrapLineColors && NGUIText.mColors.size > 0)
		{
			stringBuilder.Append("[-]");
		}
		finalText = stringBuilder.ToString();
		NGUIText.mColors.Clear();
		return flag2 && (i == length || num5 <= Mathf.Min(NGUIText.maxLines, num2));
	}

	public static bool ParseSymbol(string text, ref int index)
	{
		int num = 1;
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		bool flag5 = false;
		return NGUITextExt.ParseSymbol(text, ref index, null, false, ref num, ref flag, ref flag2, ref flag3, ref flag4, ref flag5);
	}

	public static bool ParseSymbol(string text, ref int index, BetterList<Color> colors, bool premultiply, ref int sub, ref bool bold, ref bool italic, ref bool underline, ref bool strike, ref bool ignoreColor)
	{
		int length = text.Length;
		if (index + 3 > length || text[index] != '[')
		{
			return false;
		}
		if (text[index + 2] == ']')
		{
			if (text[index + 1] == '-')
			{
				if (colors != null && colors.size > 1)
				{
					colors.RemoveAt(colors.size - 1);
				}
				index += 3;
				return true;
			}
			string text2 = text.Substring(index, 3);
			string text3 = text2;
			switch (text3)
			{
			case "[b]":
				bold = true;
				index += 3;
				return true;
			case "[i]":
				italic = true;
				index += 3;
				return true;
			case "[u]":
				underline = true;
				index += 3;
				return true;
			case "[s]":
				strike = true;
				index += 3;
				return true;
			case "[c]":
				ignoreColor = true;
				index += 3;
				return true;
			}
		}
		if (index + 4 > length)
		{
			return false;
		}
		if (text[index + 3] == ']')
		{
			string text4 = text.Substring(index, 4);
			string text3 = text4;
			switch (text3)
			{
			case "[/b]":
				bold = false;
				index += 4;
				return true;
			case "[/i]":
				italic = false;
				index += 4;
				return true;
			case "[/u]":
				underline = false;
				index += 4;
				return true;
			case "[/s]":
				strike = false;
				index += 4;
				return true;
			case "[/c]":
				ignoreColor = false;
				index += 4;
				return true;
			}
			char ch = text[index + 1];
			char ch2 = text[index + 2];
			if (NGUIText.IsHex(ch) && NGUIText.IsHex(ch2))
			{
				int num2 = NGUIMath.HexToDecimal(ch) << 4 | NGUIMath.HexToDecimal(ch2);
				NGUIText.mAlpha = (float)num2 / 255f;
				index += 4;
				return true;
			}
		}
		if (index + 5 > length)
		{
			return false;
		}
		if (text[index + 4] == ']')
		{
			string text5 = text.Substring(index, 5);
			string text3 = text5;
			if (text3 != null)
			{
				if (NGUITextExt.<>f__switch$map7 == null)
				{
					NGUITextExt.<>f__switch$map7 = new Dictionary<string, int>(2)
					{
						{
							"[sub]",
							0
						},
						{
							"[sup]",
							1
						}
					};
				}
				int num;
				if (NGUITextExt.<>f__switch$map7.TryGetValue(text3, out num))
				{
					if (num == 0)
					{
						sub = 1;
						index += 5;
						return true;
					}
					if (num == 1)
					{
						sub = 2;
						index += 5;
						return true;
					}
				}
			}
		}
		if (index + 6 > length)
		{
			return false;
		}
		if (text[index + 5] == ']')
		{
			string text6 = text.Substring(index, 6);
			string text3 = text6;
			switch (text3)
			{
			case "[/sub]":
				sub = 0;
				index += 6;
				return true;
			case "[/sup]":
				sub = 0;
				index += 6;
				return true;
			case "[/url]":
				index += 6;
				return true;
			}
		}
		if (text[index + 1] == 'e' && text[index + 2] == 'm' && text[index + 3] == '=')
		{
			if (text[index + 4] == ']')
			{
				return false;
			}
			int num3 = index;
			int num4 = text.IndexOf(']', index + 3);
			if (num4 != -1)
			{
				index = num4 + 1;
				NGUITextExt.mEmojiInfo = default(EmojiInfo);
				string text7 = text.Substring(num3 + 4, num4 - 4 - num3);
				num4 = text7.IndexOf(',');
				if (num4 != -1)
				{
					int num5 = 0;
					int.TryParse(text7.Substring(0, num4), out num5);
					NGUITextExt.mEmojiInfo.size = num5;
					NGUITextExt.mEmojiInfo.finalSize = (int)((float)num5 * NGUIText.fontScale);
					NGUITextExt.mEmojiInfo.emojiName = text7.Substring(num4 + 1);
				}
				else
				{
					NGUITextExt.mEmojiInfo.size = (int)NGUITextExt.GetEmojiSize(text7).x;
					NGUITextExt.mEmojiInfo.finalSize = (int)((float)NGUITextExt.mEmojiInfo.size * NGUIText.fontScale);
					NGUITextExt.mEmojiInfo.emojiName = text7;
				}
				if (NGUITextExt.mEmojiInfo.emojiName[NGUITextExt.mEmojiInfo.emojiName.Length - 1] == '.')
				{
					NGUITextExt.mEmojiInfo.isAnimation = true;
					NGUITextExt.mEmojiInfo.emojiName = NGUITextExt.mEmojiInfo.emojiName.Substring(0, NGUITextExt.mEmojiInfo.emojiName.Length - 1);
				}
				NGUITextExt.mEmojiInfo.gapLength = (float)NGUITextExt.mEmojiInfo.finalSize + NGUIText.finalSpacingX;
				NGUITextExt.mEmojiInfo.newLineOffset = (float)NGUITextExt.mEmojiInfo.finalSize - (float)NGUIText.fontSize * NGUIText.fontScale;
				if (NGUITextExt.mEmojiInfo.newLineOffset < 0f)
				{
					NGUITextExt.mEmojiInfo.newLineOffset = 0f;
				}
				NGUITextExt.mEmojiInfo.startSpaceIdx = num3;
				NGUITextExt.mEmojiInfo.emojiLength = index - num3;
				return true;
			}
			return false;
		}
		else if (text[index + 1] == 'u' && text[index + 2] == 'r' && text[index + 3] == 'l' && text[index + 4] == '=')
		{
			int num6 = text.IndexOf(']', index + 4);
			if (num6 != -1)
			{
				index = num6 + 1;
				return true;
			}
			index = text.Length;
			return true;
		}
		else
		{
			if (index + 8 > length)
			{
				return false;
			}
			if (text[index + 7] == ']')
			{
				Color color = NGUIText.ParseColor24(text, index + 1);
				if (NGUIText.EncodeColor24(color) != text.Substring(index + 1, 6).ToUpper())
				{
					return false;
				}
				if (colors != null)
				{
					color.a = colors[colors.size - 1].a;
					if (premultiply && color.a != 1f)
					{
						color = Color.Lerp(NGUIText.mInvisible, color, color.a);
					}
					colors.Add(color);
				}
				index += 8;
				return true;
			}
			else
			{
				if (index + 10 > length)
				{
					return false;
				}
				if (text[index + 9] != ']')
				{
					return false;
				}
				Color color2 = NGUIText.ParseColor32(text, index + 1);
				if (NGUIText.EncodeColor32(color2) != text.Substring(index + 1, 8).ToUpper())
				{
					return false;
				}
				if (colors != null)
				{
					if (premultiply && color2.a != 1f)
					{
						color2 = Color.Lerp(NGUIText.mInvisible, color2, color2.a);
					}
					colors.Add(color2);
				}
				index += 10;
				return true;
			}
		}
	}

	public static void Print(string text, BetterList<Vector3> verts, BetterList<Vector2> uvs, BetterList<Color> cols, UILabelEmoji emojiLabel)
	{
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		int size = verts.size;
		NGUIText.Prepare(text);
		NGUIText.mColors.Add(Color.white);
		NGUIText.mAlpha = 1f;
		int prev = 0;
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = (float)NGUIText.finalSize;
		Color a = (NGUIText.tint * NGUIText.gradientBottom).GammaToLinearSpace();
		Color b = (NGUIText.tint * NGUIText.gradientTop).GammaToLinearSpace();
		Color color = NGUIText.tint;
		Color item = color.GammaToLinearSpace();
		int length = text.Length;
		Rect rect = default(Rect);
		float num5 = 0f;
		float num6 = 0f;
		float num7 = num4 * NGUIText.pixelDensity;
		bool flag = false;
		int num8 = 0;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		bool flag5 = false;
		bool flag6 = false;
		if (NGUIText.bitmapFont != null)
		{
			rect = NGUIText.bitmapFont.uvRect;
			num5 = rect.width / (float)NGUIText.bitmapFont.texWidth;
			num6 = rect.height / (float)NGUIText.bitmapFont.texHeight;
		}
		float num9 = 0f;
		int num10 = -1;
		int num11 = 0;
		float num12;
		if (emojiLabel.emojiLineHeightOffset.TryGetValue(0, out num12))
		{
			num2 += num12;
		}
		int i = 0;
		int num13 = 1;
		while (i < length)
		{
			int num14 = (int)text[i];
			float num15 = num;
			if (num14 == 10)
			{
				if (num > num3)
				{
					num3 = num;
				}
				if (NGUIText.alignment != NGUIText.Alignment.Left)
				{
					NGUIText.Align(verts, size, num - NGUIText.finalSpacingX, 4);
					size = verts.size;
				}
				num = 0f;
				num2 += NGUIText.finalLineHeight;
				if (emojiLabel.emojiLineHeightOffset.TryGetValue(num13++, out num12))
				{
					num2 += num12;
				}
				prev = 0;
			}
			else if (emojiLabel.emojiList.Count > num11 && num14 == 91 && text[i + 1] == 'e' && text[i + 2] == 'm' && text[i + 3] == '=')
			{
				EmojiInfo value = emojiLabel.emojiList[num11];
				if (value.newLine && text[i - 1] != '\n')
				{
					num = 0f;
					num2 += NGUIText.finalLineHeight;
					prev = 0;
				}
				value.vertIdx = verts.size;
				emojiLabel.emojiList[num11] = value;
				if (num == 0f)
				{
					verts.Add(new Vector3(num + (float)value.finalSize, -num2));
				}
				else if (num9 != 0f && num10 != value.startSpaceIdx)
				{
					verts.Add(new Vector3(num + (float)value.finalSize, (verts.size != 0) ? (verts[verts.size - 1].y - num9) : 0f));
				}
				else
				{
					verts.Add(new Vector3(num + (float)value.finalSize, (verts.size != 0) ? verts[verts.size - 1].y : 0f));
				}
				num += value.gapLength;
				i += value.emojiLength - 1;
				num11++;
				num10 = value.startSpaceIdx + value.emojiLength;
			}
			else if (num14 < 32)
			{
				prev = num14;
			}
			else if (NGUIText.encoding && NGUITextExt.ParseSymbol(text, ref i, NGUIText.mColors, NGUIText.premultiply, ref num8, ref flag2, ref flag3, ref flag4, ref flag5, ref flag6))
			{
				if (flag6)
				{
					color = NGUIText.mColors[NGUIText.mColors.size - 1];
					color.a *= NGUIText.mAlpha * NGUIText.tint.a;
				}
				else
				{
					color = NGUIText.tint * NGUIText.mColors[NGUIText.mColors.size - 1];
					color.a *= NGUIText.mAlpha;
				}
				item = color.GammaToLinearSpace();
				int j = 0;
				int num16 = NGUIText.mColors.size - 2;
				while (j < num16)
				{
					color.a *= NGUIText.mColors[j].a;
					j++;
				}
				if (NGUIText.gradient)
				{
					a = (NGUIText.gradientBottom * color).GammaToLinearSpace();
					b = (NGUIText.gradientTop * color).GammaToLinearSpace();
				}
				i--;
			}
			else
			{
				BMSymbol bMSymbol = (!NGUIText.useSymbols) ? null : NGUIText.GetSymbol(text, i, length);
				if (bMSymbol != null)
				{
					float num17 = num + (float)bMSymbol.offsetX * NGUIText.fontScale;
					float num18 = num17 + (float)bMSymbol.width * NGUIText.fontScale;
					float num19 = -(num2 + (float)bMSymbol.offsetY * NGUIText.fontScale);
					float num20 = num19 - (float)bMSymbol.height * NGUIText.fontScale;
					if (Mathf.RoundToInt(num + (float)bMSymbol.advance * NGUIText.fontScale) > NGUIText.regionWidth)
					{
						if (num == 0f)
						{
							return;
						}
						if (NGUIText.alignment != NGUIText.Alignment.Left && size < verts.size)
						{
							NGUIText.Align(verts, size, num - NGUIText.finalSpacingX, 4);
							size = verts.size;
						}
						num17 -= num;
						num18 -= num;
						num20 -= NGUIText.finalLineHeight;
						num19 -= NGUIText.finalLineHeight;
						num = 0f;
						num2 += NGUIText.finalLineHeight;
					}
					verts.Add(new Vector3(num17, num20));
					verts.Add(new Vector3(num17, num19));
					verts.Add(new Vector3(num18, num19));
					verts.Add(new Vector3(num18, num20));
					num += NGUIText.finalSpacingX + (float)bMSymbol.advance * NGUIText.fontScale;
					i += bMSymbol.length - 1;
					prev = 0;
					if (uvs != null)
					{
						Rect uvRect = bMSymbol.uvRect;
						float xMin = uvRect.xMin;
						float yMin = uvRect.yMin;
						float xMax = uvRect.xMax;
						float yMax = uvRect.yMax;
						uvs.Add(new Vector2(xMin, yMin));
						uvs.Add(new Vector2(xMin, yMax));
						uvs.Add(new Vector2(xMax, yMax));
						uvs.Add(new Vector2(xMax, yMin));
					}
					if (cols != null)
					{
						if (NGUIText.symbolStyle == NGUIText.SymbolStyle.Colored)
						{
							for (int k = 0; k < 4; k++)
							{
								cols.Add(item);
							}
						}
						else
						{
							Color white = Color.white;
							white.a = item.a;
							for (int l = 0; l < 4; l++)
							{
								cols.Add(white);
							}
						}
					}
				}
				else
				{
					NGUIText.GlyphInfo glyph = NGUIText.GetGlyph(num14, prev);
					if (glyph != null)
					{
						prev = num14;
						num9 = glyph.v0.y;
						if (num8 != 0)
						{
							NGUIText.GlyphInfo expr_737_cp_0 = glyph;
							expr_737_cp_0.v0.x = expr_737_cp_0.v0.x * 0.75f;
							NGUIText.GlyphInfo expr_74F_cp_0 = glyph;
							expr_74F_cp_0.v0.y = expr_74F_cp_0.v0.y * 0.75f;
							NGUIText.GlyphInfo expr_767_cp_0 = glyph;
							expr_767_cp_0.v1.x = expr_767_cp_0.v1.x * 0.75f;
							NGUIText.GlyphInfo expr_77F_cp_0 = glyph;
							expr_77F_cp_0.v1.y = expr_77F_cp_0.v1.y * 0.75f;
							if (num8 == 1)
							{
								NGUIText.GlyphInfo expr_79F_cp_0 = glyph;
								expr_79F_cp_0.v0.y = expr_79F_cp_0.v0.y - NGUIText.fontScale * (float)NGUIText.fontSize * 0.4f;
								NGUIText.GlyphInfo expr_7C4_cp_0 = glyph;
								expr_7C4_cp_0.v1.y = expr_7C4_cp_0.v1.y - NGUIText.fontScale * (float)NGUIText.fontSize * 0.4f;
							}
							else
							{
								NGUIText.GlyphInfo expr_7EE_cp_0 = glyph;
								expr_7EE_cp_0.v0.y = expr_7EE_cp_0.v0.y + NGUIText.fontScale * (float)NGUIText.fontSize * 0.05f;
								NGUIText.GlyphInfo expr_813_cp_0 = glyph;
								expr_813_cp_0.v1.y = expr_813_cp_0.v1.y + NGUIText.fontScale * (float)NGUIText.fontSize * 0.05f;
							}
						}
						float num17 = glyph.v0.x + num;
						float num20 = glyph.v0.y - num2;
						float num18 = glyph.v1.x + num;
						float num19 = glyph.v1.y - num2;
						float num21 = glyph.advance;
						if (NGUIText.finalSpacingX < 0f)
						{
							num21 += NGUIText.finalSpacingX;
						}
						if (Mathf.RoundToInt(num + num21) > NGUIText.regionWidth)
						{
							if (num == 0f)
							{
								return;
							}
							if (NGUIText.alignment != NGUIText.Alignment.Left && size < verts.size)
							{
								NGUIText.Align(verts, size, num - NGUIText.finalSpacingX, 4);
								size = verts.size;
							}
							num17 -= num;
							num18 -= num;
							num20 -= NGUIText.finalLineHeight;
							num19 -= NGUIText.finalLineHeight;
							num = 0f;
							num2 += NGUIText.finalLineHeight;
							num15 = 0f;
						}
						if (NGUIText.IsSpace(num14))
						{
							if (flag4)
							{
								num14 = 95;
							}
							else if (flag5)
							{
								num14 = 45;
							}
						}
						num += ((num8 != 0) ? ((NGUIText.finalSpacingX + glyph.advance) * 0.75f) : (NGUIText.finalSpacingX + glyph.advance));
						if (num8 != 0)
						{
							num = Mathf.Round(num);
						}
						if (!NGUIText.IsSpace(num14))
						{
							if (uvs != null)
							{
								if (NGUIText.bitmapFont != null)
								{
									glyph.u0.x = rect.xMin + num5 * glyph.u0.x;
									glyph.u2.x = rect.xMin + num5 * glyph.u2.x;
									glyph.u0.y = rect.yMax - num6 * glyph.u0.y;
									glyph.u2.y = rect.yMax - num6 * glyph.u2.y;
									glyph.u1.x = glyph.u0.x;
									glyph.u1.y = glyph.u2.y;
									glyph.u3.x = glyph.u2.x;
									glyph.u3.y = glyph.u0.y;
								}
								int m = 0;
								int num22 = (!flag2) ? 1 : 4;
								while (m < num22)
								{
									uvs.Add(glyph.u0);
									uvs.Add(glyph.u1);
									uvs.Add(glyph.u2);
									uvs.Add(glyph.u3);
									m++;
								}
							}
							if (cols != null)
							{
								if (glyph.channel == 0 || glyph.channel == 15)
								{
									if (NGUIText.gradient)
									{
										float num23 = num7 + glyph.v0.y / NGUIText.fontScale;
										float num24 = num7 + glyph.v1.y / NGUIText.fontScale;
										num23 /= num7;
										num24 /= num7;
										NGUIText.s_c0 = Color.Lerp(a, b, num23);
										NGUIText.s_c1 = Color.Lerp(a, b, num24);
										int n = 0;
										int num25 = (!flag2) ? 1 : 4;
										while (n < num25)
										{
											cols.Add(NGUIText.s_c0);
											cols.Add(NGUIText.s_c1);
											cols.Add(NGUIText.s_c1);
											cols.Add(NGUIText.s_c0);
											n++;
										}
									}
									else
									{
										int num26 = 0;
										int num27 = (!flag2) ? 4 : 16;
										while (num26 < num27)
										{
											cols.Add(item);
											num26++;
										}
									}
								}
								else
								{
									Color color2 = color;
									color2 *= 0.49f;
									switch (glyph.channel)
									{
									case 1:
										color2.b += 0.51f;
										break;
									case 2:
										color2.g += 0.51f;
										break;
									case 4:
										color2.r += 0.51f;
										break;
									case 8:
										color2.a += 0.51f;
										break;
									}
									Color item2 = color2.GammaToLinearSpace();
									int num28 = 0;
									int num29 = (!flag2) ? 4 : 16;
									while (num28 < num29)
									{
										cols.Add(item2);
										num28++;
									}
								}
							}
							if (!flag2)
							{
								if (!flag3)
								{
									verts.Add(new Vector3(num17, num20));
									verts.Add(new Vector3(num17, num19));
									verts.Add(new Vector3(num18, num19));
									verts.Add(new Vector3(num18, num20));
								}
								else
								{
									float num30 = (float)NGUIText.fontSize * 0.1f * ((num19 - num20) / (float)NGUIText.fontSize);
									verts.Add(new Vector3(num17 - num30, num20));
									verts.Add(new Vector3(num17 + num30, num19));
									verts.Add(new Vector3(num18 + num30, num19));
									verts.Add(new Vector3(num18 - num30, num20));
								}
							}
							else
							{
								for (int num31 = 0; num31 < 4; num31++)
								{
									float num32 = NGUIText.mBoldOffset[num31 * 2];
									float num33 = NGUIText.mBoldOffset[num31 * 2 + 1];
									float num34 = (!flag3) ? 0f : ((float)NGUIText.fontSize * 0.1f * ((num19 - num20) / (float)NGUIText.fontSize));
									verts.Add(new Vector3(num17 + num32 - num34, num20 + num33));
									verts.Add(new Vector3(num17 + num32 + num34, num19 + num33));
									verts.Add(new Vector3(num18 + num32 + num34, num19 + num33));
									verts.Add(new Vector3(num18 + num32 - num34, num20 + num33));
								}
							}
							if (flag4 || flag5)
							{
								NGUIText.GlyphInfo glyph2 = NGUIText.GetGlyph((!flag5) ? 95 : 45, prev);
								if (glyph2 != null)
								{
									if (uvs != null)
									{
										if (NGUIText.bitmapFont != null)
										{
											glyph2.u0.x = rect.xMin + num5 * glyph2.u0.x;
											glyph2.u2.x = rect.xMin + num5 * glyph2.u2.x;
											glyph2.u0.y = rect.yMax - num6 * glyph2.u0.y;
											glyph2.u2.y = rect.yMax - num6 * glyph2.u2.y;
										}
										float x = (glyph2.u0.x + glyph2.u2.x) * 0.5f;
										int num35 = 0;
										int num36 = (!flag2) ? 1 : 4;
										while (num35 < num36)
										{
											uvs.Add(new Vector2(x, glyph2.u0.y));
											uvs.Add(new Vector2(x, glyph2.u2.y));
											uvs.Add(new Vector2(x, glyph2.u2.y));
											uvs.Add(new Vector2(x, glyph2.u0.y));
											num35++;
										}
									}
									if (flag && flag5)
									{
										num20 = (-num2 + glyph2.v0.y) * 0.75f;
										num19 = (-num2 + glyph2.v1.y) * 0.75f;
									}
									else
									{
										num20 = -num2 + glyph2.v0.y;
										num19 = -num2 + glyph2.v1.y;
									}
									if (flag2)
									{
										for (int num37 = 0; num37 < 4; num37++)
										{
											float num38 = NGUIText.mBoldOffset[num37 * 2];
											float num39 = NGUIText.mBoldOffset[num37 * 2 + 1];
											verts.Add(new Vector3(num15 + num38, num20 + num39));
											verts.Add(new Vector3(num15 + num38, num19 + num39));
											verts.Add(new Vector3(num + num38, num19 + num39));
											verts.Add(new Vector3(num + num38, num20 + num39));
										}
									}
									else
									{
										verts.Add(new Vector3(num15, num20));
										verts.Add(new Vector3(num15, num19));
										verts.Add(new Vector3(num, num19));
										verts.Add(new Vector3(num, num20));
									}
									if (NGUIText.gradient)
									{
										float num40 = num7 + glyph2.v0.y / NGUIText.fontScale;
										float num41 = num7 + glyph2.v1.y / NGUIText.fontScale;
										num40 /= num7;
										num41 /= num7;
										NGUIText.s_c0 = Color.Lerp(a, b, num40);
										NGUIText.s_c1 = Color.Lerp(a, b, num41);
										int num42 = 0;
										int num43 = (!flag2) ? 1 : 4;
										while (num42 < num43)
										{
											cols.Add(NGUIText.s_c0);
											cols.Add(NGUIText.s_c1);
											cols.Add(NGUIText.s_c1);
											cols.Add(NGUIText.s_c0);
											num42++;
										}
									}
									else
									{
										int num44 = 0;
										int num45 = (!flag2) ? 4 : 16;
										while (num44 < num45)
										{
											cols.Add(item);
											num44++;
										}
									}
								}
							}
						}
					}
				}
			}
			i++;
		}
		if (NGUIText.alignment != NGUIText.Alignment.Left && size < verts.size)
		{
			NGUIText.Align(verts, size, num - NGUIText.finalSpacingX, 4);
			size = verts.size;
		}
		NGUIText.mColors.Clear();
	}

	public static Vector2 CalculatePrintedSize(string text, float defaultWidth)
	{
		Vector2 zero = Vector2.zero;
		if (!string.IsNullOrEmpty(text))
		{
			float num = 0f;
			if (NGUIText.encoding)
			{
				text = NGUITextExt.StripSymbols(text, ref num, defaultWidth);
			}
			NGUIText.Prepare(text);
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			int length = text.Length;
			int prev = 0;
			for (int i = 0; i < length; i++)
			{
				int num5 = (int)text[i];
				if (num5 == 10)
				{
					if (num2 > num4)
					{
						num4 = num2;
					}
					num2 = 0f;
					num3 += NGUIText.finalLineHeight;
				}
				else if (num5 >= 32)
				{
					BMSymbol bMSymbol = (!NGUIText.useSymbols) ? null : NGUIText.GetSymbol(text, i, length);
					if (bMSymbol == null)
					{
						float num6 = NGUIText.GetGlyphWidth(num5, prev);
						if (num6 != 0f)
						{
							num6 += NGUIText.finalSpacingX;
							if (Mathf.RoundToInt(num2 + num6) > NGUIText.regionWidth)
							{
								if (num2 > num4)
								{
									num4 = num2 - NGUIText.finalSpacingX;
								}
								num2 = num6;
								num3 += NGUIText.finalLineHeight;
							}
							else
							{
								num2 += num6;
							}
							prev = num5;
						}
					}
					else
					{
						float num7 = NGUIText.finalSpacingX + (float)bMSymbol.advance * NGUIText.fontScale;
						if (Mathf.RoundToInt(num2 + num7) > NGUIText.regionWidth)
						{
							if (num2 > num4)
							{
								num4 = num2 - NGUIText.finalSpacingX;
							}
							num2 = num7;
							num3 += NGUIText.finalLineHeight;
						}
						else
						{
							num2 += num7;
						}
						i += bMSymbol.sequence.Length - 1;
						prev = 0;
					}
				}
			}
			zero.x = ((num2 <= num4) ? num4 : (num2 - NGUIText.finalSpacingX));
			zero.y = num3 + NGUIText.finalLineHeight;
			zero.x += num;
		}
		return zero;
	}

	[DebuggerHidden, DebuggerStepThrough]
	public static void EndLine(ref StringBuilder s, ref int totalLine)
	{
		int num = s.Length - 1;
		if (num > 0 && NGUIText.IsSpace((int)s[num]))
		{
			s[num] = '\n';
		}
		else
		{
			s.Append('\n');
		}
		totalLine++;
	}

	[DebuggerHidden, DebuggerStepThrough]
	public static void ReplaceSpaceWithNewline(ref StringBuilder s, ref int totalLine)
	{
		int num = s.Length - 1;
		if (num > 0 && NGUIText.IsSpace((int)s[num]))
		{
			s[num] = '\n';
		}
		totalLine++;
	}

	public static Vector2 CalcHalfFullChar(string text)
	{
		Vector2 zero = Vector2.zero;
		int length = text.Length;
		for (int i = 0; i < length; i++)
		{
			if (text[i] > '⿿')
			{
				zero.y += 1f;
			}
			else
			{
				zero.x += 1f;
			}
		}
		return zero;
	}

	public static string StripSymbols(string text)
	{
		if (text != null)
		{
			int i = 0;
			int length = text.Length;
			while (i < length)
			{
				char c = text[i];
				if (c == '[')
				{
					int num = 0;
					bool flag = false;
					bool flag2 = false;
					bool flag3 = false;
					bool flag4 = false;
					bool flag5 = false;
					int num2 = i;
					if (NGUITextExt.ParseSymbol(text, ref num2, null, false, ref num, ref flag, ref flag2, ref flag3, ref flag4, ref flag5))
					{
						text = text.Remove(i, num2 - i);
						length = text.Length;
						continue;
					}
				}
				i++;
			}
		}
		return text;
	}

	private static string StripSymbols(string text, ref float placeholder, float defaultWidth = 0f)
	{
		if (text != null)
		{
			int i = 0;
			int num = 0;
			int num2 = 0;
			int length = text.Length;
			while (i < length)
			{
				char c = text[i];
				if (c != '[')
				{
					goto IL_B7;
				}
				int num3 = 0;
				bool flag = false;
				bool flag2 = false;
				bool flag3 = false;
				bool flag4 = false;
				bool flag5 = false;
				int num4 = i;
				if (!NGUITextExt.ParseSymbol(text, ref num4, null, false, ref num3, ref flag, ref flag2, ref flag3, ref flag4, ref flag5))
				{
					goto IL_B7;
				}
				text = text.Remove(i, num4 - i);
				length = text.Length;
				if (NGUITextExt.mEmojiInfo != NGUITextExt.DefaultEmoji)
				{
					placeholder += NGUITextExt.mEmojiInfo.gapLength;
					if (num2 + 1 == num)
					{
						placeholder += defaultWidth / 2f;
					}
					NGUITextExt.mEmojiInfo = NGUITextExt.DefaultEmoji;
					num2 = num;
				}
				IL_BB:
				num++;
				continue;
				IL_B7:
				i++;
				goto IL_BB;
			}
		}
		return text;
	}

	public static float NativeDyncFontWidth(char c, Font font)
	{
		if (font != null)
		{
			font.RequestCharactersInTexture(".", NGUIText.finalSize, NGUIText.fontStyle);
			if (!font.GetCharacterInfo('.', out NGUITextExt.mTempChar, NGUIText.finalSize, NGUIText.fontStyle) || (float)NGUITextExt.mTempChar.maxY == 0f)
			{
				font.RequestCharactersInTexture("1", NGUIText.finalSize, NGUIText.fontStyle);
				if (!font.GetCharacterInfo('1', out NGUITextExt.mTempChar, NGUIText.finalSize, NGUIText.fontStyle))
				{
					return 0f;
				}
			}
			return (float)NGUITextExt.mTempChar.maxX;
		}
		return 0f;
	}

	public static UIEmojiSprite AddEmojiSprite(this GameObject go, UIAtlas atlas, string spriteName, int depth = 2147483647)
	{
		UIEmojiSprite uIEmojiSprite = go.AddWidget(depth);
		uIEmojiSprite.type = UIBasicSprite.Type.Simple;
		uIEmojiSprite.atlas = atlas;
		uIEmojiSprite.spriteName = spriteName;
		return uIEmojiSprite;
	}

	private static Vector2 GetEmojiSize(string emoji)
	{
		if (!NGUITextExt.curEmojiAtlas)
		{
			return Vector2.one;
		}
		UISpriteData sprite = NGUITextExt.curEmojiAtlas.GetSprite(emoji);
		return (sprite != null) ? new Vector2((float)sprite.width, (float)sprite.height) : Vector2.one;
	}
}
