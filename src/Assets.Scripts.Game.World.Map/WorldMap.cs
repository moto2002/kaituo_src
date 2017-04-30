using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game.World.Map
{
	public class WorldMap : MonoBehaviour
	{
		private static int MapPointGUID;

		public List<MapPoint> Points;

		public List<MapWay> Ways;

		public GameObject SwsRoot;

		public PathManagerPool PathManagerPool;

		private Dictionary<string, MapPoint> _pointDic;

		private MapPathfinding pathfinding;

		private Dictionary<string, MapPoint> pointDic
		{
			get
			{
				if (this._pointDic == null)
				{
					this._pointDic = new Dictionary<string, MapPoint>();
					this.Build();
				}
				return this._pointDic;
			}
		}

		private void Start()
		{
		}

		public void Build()
		{
			this.pointDic.Clear();
			for (int i = 0; i < this.Points.Count; i++)
			{
				MapPoint mapPoint = this.Points[i];
				this.pointDic[mapPoint.MapPointID] = mapPoint;
				mapPoint.SetPointGUID(++WorldMap.MapPointGUID);
			}
			for (int j = 0; j < this.Ways.Count; j++)
			{
				MapWay mapWay = this.Ways[j];
				this.pointDic[mapWay.FromPointID].AddWay(mapWay);
				this.pointDic[mapWay.ToPointID].AddWay(mapWay);
			}
			this.pathfinding = new MapPathfinding(this.pointDic);
		}

		public MapPoint GetMapPoint(string id)
		{
			return this.pointDic[id];
		}

		public void SetToPoint(GameObject obj, string id)
		{
			MapPoint mapPoint = this.pointDic[id];
			obj.transform.position = mapPoint.Path.position;
		}

		public void MoveToPoint(GameObject obj, float speed, bool initialOrientation, string fromId, string toId)
		{
			MapPoint mapPoint = this.pointDic[fromId];
			MapPoint to = this.pointDic[toId];
			List<MapPoint> path = this.pathfinding.GetPath(mapPoint, to);
			List<Transform> list = new List<Transform>();
			path.Add(mapPoint);
			for (int i = path.Count - 1; i >= 0; i--)
			{
				MapPoint mapPoint2 = path[i];
				MapPoint mapPoint3 = (i - 1 < 0) ? null : path[i - 1];
				list.Add(mapPoint2.Path);
				if (mapPoint3 != null)
				{
					mapPoint2.AppendWayPathTo(mapPoint3.MapPointID, list);
				}
			}
			MapUnit mapUnit = obj.GetComponent<MapUnit>();
			if (mapUnit == null)
			{
				mapUnit = obj.AddComponent<MapUnit>();
			}
			mapUnit.Init(this);
			mapUnit.Move(list, speed, initialOrientation, false);
		}
	}
}
