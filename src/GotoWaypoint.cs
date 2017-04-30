using Jacovone;
using System;
using UnityEngine;

[RequireComponent(typeof(PathMagic))]
public class GotoWaypoint : MonoBehaviour
{
	public int requestedWaypoint;

	private PathMagic pathMagic;

	private int lastRequestedWaypoint = -1;

	private float lastRequestedPos;

	private void Start()
	{
		this.pathMagic = base.GetComponent<PathMagic>();
		this.requestedWaypoint = 0;
	}

	private void Update()
	{
		if (this.lastRequestedWaypoint != this.requestedWaypoint)
		{
			this.lastRequestedWaypoint = this.requestedWaypoint;
			this.lastRequestedPos = this.ComputePosForWaypoint(this.pathMagic, this.lastRequestedWaypoint);
		}
		this.pathMagic.CurrentPos = Mathf.Lerp(this.pathMagic.CurrentPos, this.lastRequestedPos, 0.1f);
	}

	private float CalcPosForWaypointIndex(PathMagic pm, int index)
	{
		return (float)index / ((float)pm.waypoints.Length - ((!pm.loop) ? 1f : 0f));
	}

	public float ComputePosForWaypoint(PathMagic pm, int waypoint)
	{
		float num = 0f;
		float num2 = 0.0001f;
		if (!pm.presampledPath)
		{
			num = this.CalcPosForWaypointIndex(pm, waypoint);
		}
		else
		{
			int num3 = 0;
			while (pm.WaypointSamples[num3] != waypoint)
			{
				num += pm.SamplesDistances[num3++];
			}
			num /= pm.TotalDistance;
			float num4 = num;
			Vector3 a;
			Quaternion quaternion;
			float num5;
			int num6;
			pm.sampledPositionAndRotationAndVelocityAndWaypointAtPos(num4, out a, out quaternion, out num5, out num6);
			float num7;
			do
			{
				num7 = Vector3.Distance(a, pm.Waypoints[waypoint].Position);
				num4 += num2;
				if (num4 > 1f)
				{
					num4 = 1f;
				}
				pm.sampledPositionAndRotationAndVelocityAndWaypointAtPos(num4, out a, out quaternion, out num5, out num6);
			}
			while (Vector3.Distance(a, pm.Waypoints[waypoint].Position) <= num7 && num4 < 1f);
			num = num4;
		}
		return num;
	}
}
