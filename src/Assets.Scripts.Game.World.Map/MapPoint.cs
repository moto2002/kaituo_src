using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game.World.Map
{
	public class MapPoint : MonoBehaviour
	{
		private readonly Dictionary<string, MapWay> linkWays = new Dictionary<string, MapWay>();

		private int guid;

		public string MapPointID;

		public Transform Path;

		public Action<MapPoint> OnClickEvent;

		public void AddWay(MapWay way)
		{
			string key = (!(way.FromPointID == this.MapPointID)) ? way.FromPointID : way.ToPointID;
			this.linkWays[key] = way;
		}

		public Dictionary<string, MapWay> GetLinkWays()
		{
			return this.linkWays;
		}

		public override int GetHashCode()
		{
			return this.guid;
		}

		public void SetPointGUID(int guid)
		{
			this.guid = guid;
		}

		public void AppendWayPathTo(string toWayPointId, List<Transform> paths)
		{
			MapWay mapWay = this.linkWays[toWayPointId];
			if (mapWay.FromPointID == this.MapPointID)
			{
				for (int i = 0; i < mapWay.Path.Length; i++)
				{
					Transform item = mapWay.Path[i];
					paths.Add(item);
				}
			}
			else
			{
				for (int j = mapWay.Path.Length - 1; j >= 0; j--)
				{
					Transform item2 = mapWay.Path[j];
					paths.Add(item2);
				}
			}
		}

		private void OnClick()
		{
			if (this.OnClickEvent != null)
			{
				this.OnClickEvent(this);
			}
		}
	}
}
