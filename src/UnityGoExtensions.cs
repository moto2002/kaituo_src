using System;
using UnityEngine;

public static class UnityGoExtensions
{
	public static bool IsActive(this GameObject go)
	{
		return go != null && go.activeSelf;
	}
}
