using Assets.Scripts.Action.Core;
using Assets.Scripts.Tools.Component;
using Assets.Tools.Script.Go;
using Jacovone;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;
using XQ.Framework.Utility.Debug;

namespace Assets.Scripts.Action
{
	[Category("✫ GOG/PathMagic"), Name("Tween With Path Magic")]
	public class TweenPathMagic : DevisableAction
	{
		public static PathMagic TweenPath;

		public bool IgnoreTimeScale;

		public PathChangeType TargetPositionType;

		public PathChangeRotationType TargetRotationType;

		public float Speed = 1f;

		public BBParameter<GameObject> Target;

		public BBParameter<GameObject> LookAt;

		public Vector3 LookAtOffset;

		public Vector3 TargetPosition;

		public Vector3 TargetRotation;

		protected override void OnExecute()
		{
			if (TweenPathMagic.TweenPath == null)
			{
				GameObject gameObject = new GameObject("PathMagicTween");
				GameObject secondaryHost = ParasiticComponent.GetSecondaryHost("PlayPathMagicRoot");
				gameObject.transform.parent = secondaryHost.transform;
				TweenPathMagic.TweenPath = gameObject.AddComponent<PathMagic>();
				TweenPathMagic.TweenPath.waypoints = new Waypoint[2];
				TweenPathMagic.TweenPath.waypoints[0] = new Waypoint();
				TweenPathMagic.TweenPath.waypoints[1] = new Waypoint();
			}
			Vector3 position = Vector3.zero;
			Quaternion quaternion = Quaternion.identity;
			Vector3 position2 = Main3DCamera.Instance.Level1.transform.position;
			Quaternion rotation = Main3DCamera.Instance.Level1.transform.rotation;
			Transform transform = null;
			if (this.Target != null)
			{
				GameObject value = this.Target.value;
				if (value != null)
				{
					transform = value.transform;
				}
			}
			switch (this.TargetPositionType)
			{
			case PathChangeType.FollowTarget:
				position = transform.position;
				break;
			case PathChangeType.RelativeTargetValue:
				position = transform.TransformPoint(this.TargetPosition);
				break;
			case PathChangeType.AbsoluteValue:
				position = this.TargetPosition;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			switch (this.TargetRotationType)
			{
			case PathChangeRotationType.Keep:
				quaternion = rotation;
				break;
			case PathChangeRotationType.LookAt:
				break;
			case PathChangeRotationType.FollowTarget:
				quaternion = transform.rotation;
				break;
			case PathChangeRotationType.RelativeTargetValue:
				quaternion = Quaternion.Euler(transform.TransformDirection(this.TargetRotation));
				break;
			case PathChangeRotationType.AbsoluteValue:
				quaternion = Quaternion.Euler(this.TargetRotation);
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			UDebug.Debug(string.Concat(new object[]
			{
				quaternion.x,
				",",
				quaternion.y,
				",",
				quaternion.z
			}), new object[0]);
			TweenPathMagic.TweenPath.transform.position = Vector3.zero;
			TweenPathMagic.TweenPath.transform.rotation = Quaternion.identity;
			TweenPathMagic.TweenPath.waypoints[0].position = position2;
			TweenPathMagic.TweenPath.waypoints[0].rotation = rotation.eulerAngles;
			TweenPathMagic.TweenPath.waypoints[0].InTangent = Vector3.zero;
			TweenPathMagic.TweenPath.waypoints[0].OutTangent = Vector3.zero;
			TweenPathMagic.TweenPath.waypoints[0].Velocity = 1f;
			TweenPathMagic.TweenPath.waypoints[1].position = position;
			TweenPathMagic.TweenPath.waypoints[1].rotation = quaternion.eulerAngles;
			TweenPathMagic.TweenPath.waypoints[1].InTangent = Vector3.zero;
			TweenPathMagic.TweenPath.waypoints[1].OutTangent = Vector3.zero;
			TweenPathMagic.TweenPath.waypoints[1].Velocity = 1f;
			TweenPathMagic.TweenPath.Waypoints = TweenPathMagic.TweenPath.waypoints;
			TweenPathMagic.TweenPath.VelocityBias = this.Speed;
			if (this.TargetRotationType == PathChangeRotationType.LookAt)
			{
				Main3DCamera.Instance.SetLookAtAgent(this.LookAt.value.transform, this.LookAtOffset);
				TweenPathMagic.TweenPath.GlobalLookAt = Main3DCamera.Instance.LookAtAgent;
			}
			else
			{
				TweenPathMagic.TweenPath.GlobalLookAt = null;
			}
			TweenPathMagic.TweenPath.Target = Main3DCamera.Instance.Level1;
			TweenPathMagic.TweenPath.AutoStart = true;
			TweenPathMagic.TweenPath.IgnoreTimeScale = this.IgnoreTimeScale;
			TweenPathMagic.TweenPath.StopWithoutUpdate();
			PathMagic expr_3AC = TweenPathMagic.TweenPath;
			expr_3AC.OnStopPlay = (Action)Delegate.Combine(expr_3AC.OnStopPlay, new Action(this.OnPathPlayEnd));
			TweenPathMagic.TweenPath.Play();
		}

		private void OnPathPlayEnd()
		{
			PathMagic expr_05 = TweenPathMagic.TweenPath;
			expr_05.OnStopPlay = (Action)Delegate.Remove(expr_05.OnStopPlay, new Action(this.OnPathPlayEnd));
			base.EndAction();
		}
	}
}
