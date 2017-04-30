using System;
using UnityEngine;

public static class UnityExtensions
{
	public static string ToV2String(this Vector2 v2)
	{
		return string.Format("{0}, {1}", v2.x, v2.y);
	}

	public static string ToV3String(this Vector3 v3)
	{
		return string.Format("{0}, {1}, {2}", v3.x, v3.y, v3.z);
	}
}
