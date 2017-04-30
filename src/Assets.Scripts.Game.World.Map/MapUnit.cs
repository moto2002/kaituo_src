using Assets.Tools.Script.Helper;
using DG.Tweening;
using SWS;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game.World.Map
{
	public class MapUnit : MonoBehaviour
	{
		public bool IsFaceToLeft;

		public Action OnMoveEnd;

		public Action<bool> OnOrientationChanged;

		private bool isPlaying;

		private bool isSplineMoving;

		private PathManager movePath;

		private float moveSpeed;

		private splineMove splineMove;

		private Vector3 lastUnitPosition;

		private WorldMap worldRoot;

		private int frame;

		public void Init(WorldMap worldMap)
		{
			if (worldMap.SwsRoot == null)
			{
				GameObject gameObject = worldMap.gameObject.AddEmptyGameObject();
				gameObject.name = "SWSRoot";
				worldMap.SwsRoot = gameObject;
				WaypointManager waypointManager = worldMap.SwsRoot.AddComponent<WaypointManager>();
				worldMap.PathManagerPool = new PathManagerPool(waypointManager.transform);
			}
			this.worldRoot = worldMap;
		}

		public void Move(List<Transform> path, float speed, bool initialOrientation, bool moveToPath)
		{
			this.IsFaceToLeft = initialOrientation;
			this.frame = 0;
			this.isPlaying = true;
			this.isSplineMoving = true;
			this.moveSpeed = speed;
			if (this.splineMove == null)
			{
				this.splineMove = base.GetComponent<splineMove>();
			}
			if (this.splineMove == null)
			{
				this.splineMove = base.gameObject.AddComponent<splineMove>();
				this.splineMove.onStart = false;
				this.splineMove.moveToPath = false;
				this.splineMove.reverse = false;
				this.splineMove.local = true;
				this.splineMove.startPoint = 0;
				this.splineMove.sizeToAdd = 0f;
				this.splineMove.speed = speed;
				this.splineMove.timeValue = splineMove.TimeValue.speed;
				this.splineMove.easeType = Ease.Linear;
				this.splineMove.loopType = splineMove.LoopType.none;
				this.splineMove.pathType = PathType.CatmullRom;
				this.splineMove.pathMode = PathMode.Ignore;
				this.splineMove.lockPosition = AxisConstraint.None;
			}
			if (this.movePath == null)
			{
				this.movePath = this.CreatePathManager();
			}
			for (int i = 0; i < path.Count; i++)
			{
				Transform transform = path[i];
				transform.parent = this.worldRoot.SwsRoot.transform;
			}
			this.movePath.waypoints = path.ToArray();
			this.splineMove.onReachedEnd = new Action(this.MoveArrive);
			this.splineMove.speed = this.moveSpeed;
			this.splineMove.moveToPath = moveToPath;
			this.splineMove.SetPath(this.movePath);
		}

		public void Stop()
		{
			this.isPlaying = false;
			this.isSplineMoving = false;
			if (this.splineMove != null)
			{
				this.splineMove.Stop();
			}
		}

		public void Pause()
		{
			if (this.splineMove != null)
			{
				this.splineMove.ChangeSpeed(0f);
			}
		}

		public void Resume()
		{
			if (this.splineMove != null)
			{
				this.splineMove.ChangeSpeed(this.moveSpeed);
			}
		}

		private void MoveArrive()
		{
			this.isSplineMoving = false;
		}

		private PathManager CreatePathManager()
		{
			PathManager pathManager = null;
			while (pathManager == null)
			{
				pathManager = this.worldRoot.PathManagerPool.GetInstance();
			}
			return pathManager;
		}

		private void LateUpdate()
		{
			if (this.isPlaying)
			{
				if (this.frame > 0)
				{
					if (base.transform.localPosition.x > this.lastUnitPosition.x)
					{
						if (this.IsFaceToLeft)
						{
							this.IsFaceToLeft = false;
							if (this.OnOrientationChanged != null)
							{
								this.OnOrientationChanged(this.IsFaceToLeft);
							}
						}
					}
					else if (base.transform.localPosition.x < this.lastUnitPosition.x && !this.IsFaceToLeft)
					{
						this.IsFaceToLeft = true;
						if (this.OnOrientationChanged != null)
						{
							this.OnOrientationChanged(this.IsFaceToLeft);
						}
					}
				}
				this.lastUnitPosition = base.transform.localPosition;
				if (!this.isSplineMoving)
				{
					this.isPlaying = false;
					if (this.OnMoveEnd != null)
					{
						this.OnMoveEnd();
					}
				}
				this.frame++;
			}
		}

		private void OnDestroy()
		{
			if (this.movePath != null)
			{
				this.worldRoot.PathManagerPool.ReturnInstance(this.movePath);
			}
		}
	}
}
