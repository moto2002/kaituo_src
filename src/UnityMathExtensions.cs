using System;
using UnityEngine;

public static class UnityMathExtensions
{
	public static float DistanceTo(this GameObject go, GameObject otherGO)
	{
		return Vector3.Distance(go.transform.position, otherGO.transform.position);
	}

	public static float DistanceTo(this GameObject go, Vector3 pos)
	{
		return Vector3.Distance(go.transform.position, pos);
	}

	public static float DistanceTo(this Vector3 start, Vector3 dest)
	{
		return Vector3.Distance(start, dest);
	}

	public static float DistanceTo(this Transform start, Transform dest)
	{
		return Vector3.Distance(start.position, dest.position);
	}
}
