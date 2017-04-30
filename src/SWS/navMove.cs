using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;

namespace SWS
{
	[AddComponentMenu("Simple Waypoint System/navMove"), RequireComponent(typeof(NavMeshAgent))]
	public class navMove : MonoBehaviour
	{
		public enum LoopType
		{
			none,
			loop,
			pingPong,
			random
		}

		public PathManager pathContainer;

		public bool onStart;

		public bool moveToPath;

		public bool reverse;

		public int startPoint;

		[HideInInspector]
		public int currentPoint;

		public bool closeLoop;

		public bool updateRotation = true;

		[HideInInspector]
		public List<UnityEvent> events = new List<UnityEvent>();

		public navMove.LoopType loopType;

		[HideInInspector]
		public Transform[] waypoints;

		private bool repeat;

		private NavMeshAgent agent;

		private System.Random rand = new System.Random();

		private int rndIndex;

		private bool waiting;

		private void Awake()
		{
			this.agent = base.GetComponent<NavMeshAgent>();
		}

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
			this.waypoints = new Transform[this.pathContainer.waypoints.Length];
			Array.Copy(this.pathContainer.waypoints, this.waypoints, this.pathContainer.waypoints.Length);
			this.startPoint = Mathf.Clamp(this.startPoint, 0, this.waypoints.Length - 1);
			int num = this.startPoint;
			if (this.reverse)
			{
				Array.Reverse(this.waypoints);
				num = this.waypoints.Length - 1 - num;
			}
			this.currentPoint = num;
			for (int i = this.events.Count; i <= this.waypoints.Length - 1; i++)
			{
				this.events.Add(new UnityEvent());
			}
			this.Stop();
			base.StartCoroutine(this.Move());
		}

		[DebuggerHidden]
		private IEnumerator Move()
		{
			navMove.<Move>c__Iterator27 <Move>c__Iterator = new navMove.<Move>c__Iterator27();
			<Move>c__Iterator.<>f__this = this;
			return <Move>c__Iterator;
		}

		[DebuggerHidden]
		private IEnumerator NextWaypoint()
		{
			navMove.<NextWaypoint>c__Iterator28 <NextWaypoint>c__Iterator = new navMove.<NextWaypoint>c__Iterator28();
			<NextWaypoint>c__Iterator.<>f__this = this;
			return <NextWaypoint>c__Iterator;
		}

		[DebuggerHidden]
		private IEnumerator WaitForDestination()
		{
			navMove.<WaitForDestination>c__Iterator29 <WaitForDestination>c__Iterator = new navMove.<WaitForDestination>c__Iterator29();
			<WaitForDestination>c__Iterator.<>f__this = this;
			return <WaitForDestination>c__Iterator;
		}

		private void OnWaypointChange(int index)
		{
			if (this.reverse)
			{
				index = this.waypoints.Length - 1 - index;
			}
			if (this.events == null || this.events.Count - 1 < index || this.events[index] == null)
			{
				return;
			}
			this.events[index].Invoke();
		}

		[DebuggerHidden]
		private IEnumerator ReachedEnd()
		{
			navMove.<ReachedEnd>c__Iterator2A <ReachedEnd>c__Iterator2A = new navMove.<ReachedEnd>c__Iterator2A();
			<ReachedEnd>c__Iterator2A.<>f__this = this;
			return <ReachedEnd>c__Iterator2A;
		}

		private void RandomizeWaypoints()
		{
			Array.Copy(this.pathContainer.waypoints, this.waypoints, this.pathContainer.waypoints.Length);
			int i = this.waypoints.Length;
			while (i > 1)
			{
				int num = this.rand.Next(i--);
				Transform transform = this.waypoints[i];
				this.waypoints[i] = this.waypoints[num];
				this.waypoints[num] = transform;
			}
			Transform y = this.pathContainer.waypoints[this.currentPoint];
			for (int j = 0; j < this.waypoints.Length; j++)
			{
				if (this.waypoints[j] == y)
				{
					Transform transform2 = this.waypoints[0];
					this.waypoints[0] = this.waypoints[j];
					this.waypoints[j] = transform2;
					break;
				}
			}
			this.rndIndex = 0;
		}

		public void GoToWaypoint(int index)
		{
			if (this.reverse)
			{
				index = this.waypoints.Length - 1 - index;
			}
			this.Stop();
			this.currentPoint = index;
			this.agent.Warp(this.waypoints[index].position);
			base.StartCoroutine(this.NextWaypoint());
		}

		public void Pause(float seconds = 0f)
		{
			base.StopCoroutine(this.Wait(0f));
			this.waiting = true;
			this.agent.Stop();
			if (seconds > 0f)
			{
				base.StartCoroutine(this.Wait(seconds));
			}
		}

		[DebuggerHidden]
		private IEnumerator Wait(float secs = 0f)
		{
			navMove.<Wait>c__Iterator2B <Wait>c__Iterator2B = new navMove.<Wait>c__Iterator2B();
			<Wait>c__Iterator2B.secs = secs;
			<Wait>c__Iterator2B.<$>secs = secs;
			<Wait>c__Iterator2B.<>f__this = this;
			return <Wait>c__Iterator2B;
		}

		public void Resume()
		{
			base.StopCoroutine(this.Wait(0f));
			this.waiting = false;
			this.agent.Resume();
		}

		public void Reverse()
		{
			this.reverse = !this.reverse;
			if (this.reverse)
			{
				this.startPoint = this.currentPoint - 1;
			}
			else
			{
				Array.Reverse(this.waypoints);
				this.startPoint = this.waypoints.Length - this.currentPoint;
			}
			this.moveToPath = true;
			this.StartMove();
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
			if (this.agent.enabled)
			{
				this.agent.Stop();
			}
		}

		public void ResetToStart()
		{
			this.Stop();
			this.currentPoint = 0;
			if (this.pathContainer)
			{
				this.agent.Warp(this.pathContainer.waypoints[this.currentPoint].position);
			}
		}

		public void ChangeSpeed(float value)
		{
			this.agent.speed = value;
		}
	}
}
