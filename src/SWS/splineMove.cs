using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Core.PathCore;
using DG.Tweening.Plugins.Options;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;

namespace SWS
{
	[AddComponentMenu("Simple Waypoint System/splineMove")]
	public class splineMove : MonoBehaviour
	{
		public enum TimeValue
		{
			time,
			speed
		}

		public enum LoopType
		{
			none,
			loop,
			pingPong,
			random,
			yoyo
		}

		public PathManager pathContainer;

		public bool onStart;

		public bool moveToPath;

		public bool reverse;

		public int startPoint;

		[HideInInspector]
		public int currentPoint;

		public bool closeLoop;

		public bool local;

		public float lookAhead;

		public float sizeToAdd;

		public splineMove.TimeValue timeValue = splineMove.TimeValue.speed;

		public float speed = 5f;

		private float originSpeed;

		public AnimationCurve animEaseType;

		public splineMove.LoopType loopType;

		[HideInInspector]
		public Vector3[] waypoints;

		private Vector3[] wpPos;

		[HideInInspector]
		public List<UnityEvent> events = new List<UnityEvent>();

		public Action onReachedEnd;

		public PathType pathType = PathType.CatmullRom;

		public PathMode pathMode = PathMode.Full3D;

		public Ease easeType = Ease.Linear;

		public AxisConstraint lockPosition;

		public AxisConstraint lockRotation;

		[HideInInspector]
		public Tweener tween;

		private System.Random rand = new System.Random();

		private int[] rndArray;

		private void Start()
		{
			if (this.onStart)
			{
				this.StartMove();
			}
		}

		public void StartMove()
		{
			if (this.pathContainer == null)
			{
				Debug.LogWarning(base.gameObject.name + " has no path! Please set Path Container.");
				return;
			}
			this.waypoints = this.pathContainer.GetPathPoints(this.local);
			this.originSpeed = this.speed;
			this.startPoint = Mathf.Clamp(this.startPoint, 0, this.waypoints.Length - 1);
			int num = this.startPoint;
			if (this.reverse)
			{
				Array.Reverse(this.waypoints);
				num = this.waypoints.Length - 1 - num;
			}
			this.Initialize(num);
			this.Stop();
			this.CreateTween();
		}

		private void Initialize(int startAt = 0)
		{
			if (!this.moveToPath)
			{
				startAt = 0;
			}
			this.wpPos = new Vector3[this.waypoints.Length - startAt];
			for (int i = 0; i < this.wpPos.Length; i++)
			{
				this.wpPos[i] = this.waypoints[i + startAt] + new Vector3(0f, this.sizeToAdd, 0f);
			}
			for (int j = this.events.Count; j <= this.pathContainer.GetEventsCount() - 1; j++)
			{
				this.events.Add(new UnityEvent());
			}
		}

		private void CreateTween()
		{
			TweenParams tweenParams = new TweenParams();
			if (this.timeValue == splineMove.TimeValue.speed)
			{
				tweenParams.SetSpeedBased(true);
			}
			if (this.loopType == splineMove.LoopType.yoyo)
			{
				tweenParams.SetLoops(-1, new DG.Tweening.LoopType?(DG.Tweening.LoopType.Yoyo));
			}
			if (this.easeType == Ease.Unset)
			{
				tweenParams.SetEase(this.animEaseType);
			}
			else
			{
				tweenParams.SetEase(this.easeType, null, null);
			}
			if (this.moveToPath)
			{
				tweenParams.OnWaypointChange(new TweenCallback<int>(this.OnWaypointReached));
			}
			else
			{
				if (this.loopType == splineMove.LoopType.random)
				{
					this.RandomizeWaypoints();
				}
				else if (this.loopType == splineMove.LoopType.yoyo)
				{
					tweenParams.OnStepComplete(new TweenCallback(this.ReachedEnd));
				}
				Vector3 position = this.wpPos[0];
				if (this.local)
				{
					position = this.pathContainer.transform.TransformPoint(position);
				}
				base.transform.position = position;
				tweenParams.OnWaypointChange(new TweenCallback<int>(this.OnWaypointChange));
				tweenParams.OnComplete(new TweenCallback(this.ReachedEnd));
			}
			if (this.local)
			{
				this.tween = base.transform.DOLocalPath(this.wpPos, this.originSpeed, this.pathType, this.pathMode, 10, null).SetAs(tweenParams).SetOptions(this.closeLoop, this.lockPosition, this.lockRotation).SetLookAt(this.lookAhead, null, null);
			}
			else
			{
				this.tween = base.transform.DOPath(this.wpPos, this.originSpeed, this.pathType, this.pathMode, 10, null).SetAs(tweenParams).SetOptions(this.closeLoop, this.lockPosition, this.lockRotation).SetLookAt(this.lookAhead, null, null);
			}
			if (!this.moveToPath && this.startPoint > 0)
			{
				this.GoToWaypoint(this.startPoint);
				this.startPoint = 0;
			}
			if (this.originSpeed != this.speed)
			{
				this.ChangeSpeed(this.speed);
			}
		}

		private void OnWaypointReached(int index)
		{
			if (index <= 0)
			{
				return;
			}
			this.Stop();
			this.moveToPath = false;
			this.Initialize(0);
			this.CreateTween();
		}

		private void OnWaypointChange(int index)
		{
			index = this.pathContainer.GetWaypointIndex(index);
			if (index == -1)
			{
				return;
			}
			if (this.loopType != splineMove.LoopType.yoyo && this.reverse)
			{
				index = this.waypoints.Length - 1 - index;
			}
			if (this.loopType == splineMove.LoopType.random)
			{
				index = this.rndArray[index];
			}
			this.currentPoint = index;
			if (this.events == null || this.events.Count - 1 < index || this.events[index] == null || (this.loopType == splineMove.LoopType.random && index == this.rndArray[this.rndArray.Length - 1]))
			{
				return;
			}
			this.events[index].Invoke();
		}

		private void ReachedEnd()
		{
			if (this.onReachedEnd != null)
			{
				this.onReachedEnd();
			}
			switch (this.loopType)
			{
			case splineMove.LoopType.none:
				return;
			case splineMove.LoopType.loop:
				this.currentPoint = 0;
				this.CreateTween();
				break;
			case splineMove.LoopType.pingPong:
				this.reverse = !this.reverse;
				Array.Reverse(this.waypoints);
				this.Initialize(0);
				this.CreateTween();
				break;
			case splineMove.LoopType.random:
				this.RandomizeWaypoints();
				this.CreateTween();
				break;
			case splineMove.LoopType.yoyo:
				this.reverse = !this.reverse;
				break;
			}
		}

		private void RandomizeWaypoints()
		{
			this.Initialize(0);
			this.rndArray = new int[this.wpPos.Length];
			for (int i = 0; i < this.rndArray.Length; i++)
			{
				this.rndArray[i] = i;
			}
			int j = this.wpPos.Length;
			while (j > 1)
			{
				int num = this.rand.Next(j--);
				Vector3 vector = this.wpPos[j];
				this.wpPos[j] = this.wpPos[num];
				this.wpPos[num] = vector;
				int num2 = this.rndArray[j];
				this.rndArray[j] = this.rndArray[num];
				this.rndArray[num] = num2;
			}
			Vector3 vector2 = this.wpPos[0];
			int num3 = this.rndArray[0];
			for (int k = 0; k < this.wpPos.Length; k++)
			{
				if (this.rndArray[k] == this.currentPoint)
				{
					this.rndArray[k] = num3;
					this.wpPos[0] = this.wpPos[k];
					this.wpPos[k] = vector2;
				}
			}
			this.rndArray[0] = this.currentPoint;
		}

		public void GoToWaypoint(int index)
		{
			if (this.tween == null)
			{
				return;
			}
			if (this.reverse)
			{
				index = this.waypoints.Length - 1 - index;
			}
			this.tween.ForceInit();
			this.tween.GotoWaypoint(index, true);
		}

		public void Pause(float seconds = 0f)
		{
			base.StopCoroutine(this.Wait(0f));
			if (this.tween != null)
			{
				this.tween.Pause<Tweener>();
			}
			if (seconds > 0f)
			{
				base.StartCoroutine(this.Wait(seconds));
			}
		}

		[DebuggerHidden]
		private IEnumerator Wait(float secs = 0f)
		{
			splineMove.<Wait>c__Iterator2C <Wait>c__Iterator2C = new splineMove.<Wait>c__Iterator2C();
			<Wait>c__Iterator2C.secs = secs;
			<Wait>c__Iterator2C.<$>secs = secs;
			<Wait>c__Iterator2C.<>f__this = this;
			return <Wait>c__Iterator2C;
		}

		public void Resume()
		{
			base.StopCoroutine(this.Wait(0f));
			if (this.tween != null)
			{
				this.tween.Play<Tweener>();
			}
		}

		public void Reverse()
		{
			this.reverse = !this.reverse;
			float fullPosition = 0f;
			if (this.tween != null)
			{
				fullPosition = this.tween.Duration(false) - this.tween.Elapsed(false);
			}
			this.startPoint = this.waypoints.Length - 1 - this.currentPoint;
			this.StartMove();
			this.tween.ForceInit();
			this.tween.fullPosition = fullPosition;
		}

		public void SetPath(PathManager newPath)
		{
			this.Stop();
			this.pathContainer = newPath;
			this.StartMove();
		}

		public void Stop()
		{
			base.StopAllCoroutines();
			if (this.tween != null)
			{
				this.tween.Kill(false);
			}
			this.tween = null;
		}

		public void ResetToStart()
		{
			this.Stop();
			this.currentPoint = 0;
			if (this.pathContainer)
			{
				base.transform.position = this.pathContainer.waypoints[this.currentPoint].position + new Vector3(0f, this.sizeToAdd, 0f);
			}
		}

		public void ChangeSpeed(float value)
		{
			float timeScale;
			if (this.timeValue == splineMove.TimeValue.speed)
			{
				timeScale = value / this.originSpeed;
			}
			else
			{
				timeScale = this.originSpeed / value;
			}
			this.speed = value;
			if (this.tween != null)
			{
				this.tween.timeScale = timeScale;
			}
		}
	}
}
