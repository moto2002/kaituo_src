using System;
using UnityEngine;

public static class UnityTransformExtensions
{
	public static void SetPositionX(this Transform t, float newX)
	{
		t.position = t.position.SetPositionX(newX);
	}

	public static Vector3 SetPositionX(this Vector3 v3, float newX)
	{
		return new Vector3(newX, v3.y, v3.z);
	}

	public static void SetPositionY(this Transform t, float newY)
	{
		t.position = t.position.SetPositionY(newY);
	}

	public static Vector3 SetPositionY(this Vector3 v3, float newY)
	{
		return new Vector3(v3.x, newY, v3.z);
	}

	public static void SetPositionZ(this Transform t, float newZ)
	{
		t.position = t.position.SetPositionZ(newZ);
	}

	public static Vector3 SetPositionZ(this Vector3 v3, float newZ)
	{
		return new Vector3(v3.x, v3.y, newZ);
	}

	public static float GetPositionX(this Transform t)
	{
		return t.position.x;
	}

	public static float GetPositionY(this Transform t)
	{
		return t.position.y;
	}

	public static float GetPositionZ(this Transform t)
	{
		return t.position.z;
	}
}
