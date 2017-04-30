using System;
using UnityEngine;

public class TileWorld : MonoBehaviour
{
	public static Vector3 NoFloor = new Vector3(-1f, -1f, -1f);

	public static TileWorld instance;

	public Vector3[] FloorPosition;

	public int Height = 80;

	public int Width = 80;

	public Vector3 GetFloorPosition(int indexX, int indexY)
	{
		return this.FloorPosition[indexY * this.Width + indexX];
	}

	private void Awake()
	{
		TileWorld.instance = this;
	}
}
