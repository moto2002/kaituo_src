using System;

public struct EmojiInfo
{
	public bool Def;

	public int finalSize;

	public int size;

	public string emojiName;

	public bool isAnimation;

	public int startSpaceIdx;

	public int emojiLength;

	public float gapLength;

	public float newLineOffset;

	public int line;

	public bool newLine;

	public int vertIdx;

	public static EmojiInfo Default()
	{
		return new EmojiInfo
		{
			Def = true
		};
	}

	public static bool operator !=(EmojiInfo e1, EmojiInfo e2)
	{
		return e1.Def != e2.Def;
	}

	public static bool operator ==(EmojiInfo e1, EmojiInfo e2)
	{
		return e1.Def == e2.Def;
	}
}
