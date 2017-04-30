using System;
using UnityEngine;

public static class RectHelper
{
	public static Rect Rect100
	{
		get
		{
			return new Rect(0f, 0f, 100f, 100f);
		}
	}

	public static Rect Rect20
	{
		get
		{
			return new Rect(0f, 0f, 20f, 20f);
		}
	}

	public static Rect Rect0
	{
		get
		{
			return new Rect(0f, 0f, 0f, 0f);
		}
	}

	public static Vector2 Center(this Rect rect)
	{
		return rect.position + new Vector2(rect.width / 2f, rect.height / 2f);
	}

	public static Vector2 TopLeft(this Rect rect)
	{
		return rect.position;
	}

	public static Vector2 TopRight(this Rect rect)
	{
		return rect.position.DeltaXNew(rect.width);
	}

	public static Vector2 BottomLeft(this Rect rect)
	{
		return rect.position.DeltaYNew(rect.height);
	}

	public static Vector2 BottomRight(this Rect rect)
	{
		return rect.position + new Vector2(rect.width, rect.height);
	}

	public static Rect ToPostion(this Rect rect, Vector2 pos)
	{
		return new Rect(rect)
		{
			position = pos
		};
	}

	public static Rect SizeNew(this Rect rect, float sizeDelta)
	{
		Rect result = new Rect(rect.position.x - sizeDelta, rect.position.y - sizeDelta, rect.width + sizeDelta * 2f, rect.height + sizeDelta * 2f);
		return result;
	}

	public static Rect Delta(this Rect rect, Vector2 delta)
	{
		Rect result = new Rect(rect.position + delta, new Vector2(rect.width, rect.height));
		return result;
	}
}
