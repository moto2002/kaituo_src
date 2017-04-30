using Assets.Script.Mvc.Pool;
using Assets.Tools.Script.Helper;
using SWS;
using System;
using UnityEngine;

namespace Assets.Scripts.Game.World.Map
{
	public class PathManagerPool : Pool<PathManager>
	{
		private static int PathManagerGUID;

		private readonly Transform swsRoot;

		public PathManagerPool(Transform swsRoot)
		{
			this.swsRoot = swsRoot;
		}

		protected override object CreateObject()
		{
			GameObject gameObject = this.swsRoot.gameObject.AddEmptyGameObject();
			PathManagerPool.PathManagerGUID++;
			gameObject.name = string.Format("PathManager{0}", PathManagerPool.PathManagerGUID);
			return gameObject.AddComponent<PathManager>();
		}
	}
}
