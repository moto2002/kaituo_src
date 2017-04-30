using System;
using System.Collections.Generic;

namespace Assets.Scripts.Game.World.Map
{
	public class MapPathfinding
	{
		private readonly Dictionary<MapPoint, bool> minList = new Dictionary<MapPoint, bool>();

		private readonly Dictionary<MapPoint, int> pathCost = new Dictionary<MapPoint, int>();

		private readonly Dictionary<MapPoint, MapPoint> pathLink = new Dictionary<MapPoint, MapPoint>();

		private readonly Dictionary<string, MapPoint> pointDic;

		private readonly Dictionary<MapPoint, bool> unknownList = new Dictionary<MapPoint, bool>();

		public MapPathfinding(Dictionary<string, MapPoint> points)
		{
			this.pointDic = points;
		}

		public List<MapPoint> GetPath(MapPoint from, MapPoint to)
		{
			Dictionary<MapPoint, MapPoint> dictionary = this.DijkstraBake(from);
			List<MapPoint> list = new List<MapPoint>();
			MapPoint mapPoint = to;
			while (dictionary.ContainsKey(mapPoint))
			{
				list.Add(mapPoint);
				mapPoint = dictionary[mapPoint];
			}
			return list;
		}

		private Dictionary<MapPoint, MapPoint> DijkstraBake(MapPoint from)
		{
			this.pathLink.Clear();
			this.pathCost.Clear();
			this.minList.Clear();
			this.unknownList.Clear();
			this.pathCost[from] = 0;
			this.unknownList[from] = true;
			do
			{
				int num = 999999999;
				MapPoint mapPoint = null;
				foreach (MapPoint current in this.unknownList.Keys)
				{
					int num2 = this.pathCost[current];
					if (num2 < num)
					{
						num = num2;
						mapPoint = current;
					}
				}
				int num3 = this.pathCost[mapPoint];
				foreach (string current2 in mapPoint.GetLinkWays().Keys)
				{
					MapPoint key = this.pointDic[current2];
					if (!this.minList.ContainsKey(key))
					{
						int num4 = num3 + 1;
						if (this.unknownList.ContainsKey(key))
						{
							if (num4 < this.pathCost[key])
							{
								this.pathCost[key] = num4;
								this.pathLink[key] = mapPoint;
							}
						}
						else
						{
							this.pathCost[key] = num4;
							this.pathLink[key] = mapPoint;
							this.unknownList[key] = true;
						}
					}
				}
				this.unknownList.Remove(mapPoint);
				this.minList[mapPoint] = true;
			}
			while (this.unknownList.Count != 0);
			return this.pathLink;
		}
	}
}
