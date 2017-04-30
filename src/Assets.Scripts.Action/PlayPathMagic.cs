using Assets.Scripts.Action.Core;
using Assets.Scripts.Tools.Component;
using Assets.Tools.Script.Go;
using Jacovone;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Action
{
	[Category("✫ GOG/PathMagic"), Name("Play Path Magic")]
	public class PlayPathMagic : DevisableAction
	{
		public static PlayPathMagic LastPlayPath;

		public static Dictionary<int, PlayPathMagic> PlayingPath = new Dictionary<int, PlayPathMagic>();

		public PathMagic PathPrefab;

		public int PlayId;

		public bool IgnoreTimeScale;

		public PathPutType PutType;

		public PathFollowType FollowType;

		public PathCameraLookType CameraLookType;

		public Vector3 PutPosition;

		public Vector3 PutOffset;

		public Vector3 PutAngle;

		public BBParameter<GameObject> Target;

		public BBParameter<GameObject> LookAt;

		public Vector3 LookAtOffset;

		public PathMagic Path;

		private Transform target;

		private bool pausing;

		public static void ClearPath()
		{
			GameObject secondaryHost = ParasiticComponent.GetSecondaryHost("PlayPathMagicRoot");
			UnityEngine.Object.Destroy(secondaryHost);
		}

		public void Pause()
		{
			this.Path.Pause();
			this.pausing = true;
		}

		public void Resume()
		{
			PlayPathMagic.LastPlayPath = this;
			this.Path.Play();
			this.pausing = false;
		}

		public void Stop()
		{
			this.Path.StopWithoutUpdate();
			this.pausing = false;
		}

		protected override void OnExecute()
		{
			try
			{
				this.pausing = false;
				PlayPathMagic.LastPlayPath = this;
				if (this.PlayId != 0)
				{
					PlayPathMagic.PlayingPath[this.PlayId] = this;
				}
				if (this.Path == null)
				{
					GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.PathPrefab.gameObject);
					GameObject secondaryHost = ParasiticComponent.GetSecondaryHost("PlayPathMagicRoot");
					gameObject.transform.parent = secondaryHost.transform;
					this.Path = gameObject.GetComponent<PathMagic>();
				}
				if (this.Target != null)
				{
					GameObject value = this.Target.value;
					if (value != null)
					{
						this.target = this.Target.value.transform;
					}
				}
				switch (this.PutType)
				{
				case PathPutType.WorldPosition:
					this.Path.transform.position = this.PutPosition;
					this.Path.transform.rotation = Quaternion.Euler(this.PutAngle);
					break;
				case PathPutType.FollowTarget:
					this.Path.transform.position = this.target.position + this.PutOffset;
					this.Path.transform.rotation = this.target.rotation;
					break;
				case PathPutType.FollowTargetOnlyPosition:
					this.Path.transform.position = this.target.position + this.PutOffset;
					this.Path.transform.rotation = Quaternion.Euler(this.target.TransformDirection(this.PutAngle));
					break;
				default:
					throw new ArgumentOutOfRangeException();
				}
				switch (this.CameraLookType)
				{
				case PathCameraLookType.DisableOrientation:
					this.Path.DisableOrientation = true;
					this.Path.GlobalLookAt = null;
					this.Path.GlobalFollowPath = false;
					break;
				case PathCameraLookType.FollowPath:
					this.Path.DisableOrientation = false;
					this.Path.GlobalLookAt = null;
					this.Path.GlobalFollowPath = true;
					break;
				case PathCameraLookType.LookAt:
					Main3DCamera.Instance.SetLookAtAgent(this.LookAt.value.transform, this.LookAtOffset);
					this.Path.DisableOrientation = false;
					this.Path.GlobalLookAt = Main3DCamera.Instance.LookAtAgent;
					this.Path.GlobalFollowPath = false;
					break;
				case PathCameraLookType.Prefabricated:
					break;
				default:
					throw new ArgumentOutOfRangeException();
				}
				this.Path.Target = Main3DCamera.Instance.Level1;
				this.Path.gameObject.SetActive(true);
				this.Path.AutoStart = true;
				this.Path.IgnoreTimeScale = this.IgnoreTimeScale;
				this.Path.StopWithoutUpdate();
				PathMagic expr_2C6 = this.Path;
				expr_2C6.OnStopPlay = (Action)Delegate.Combine(expr_2C6.OnStopPlay, new Action(this.OnPathPlayEnd));
				this.Path.Play();
			}
			catch (Exception ex)
			{
				DebugConsole.Log(new object[]
				{
					ex
				});
				DebugConsole.Log(new object[]
				{
					PlayPathMagic.PlayingPath != null,
					this.PathPrefab != null
				});
				DebugConsole.Log(new object[]
				{
					this.PathPrefab.gameObject != null
				});
				DebugConsole.Log(new object[]
				{
					this.Path != null
				});
				DebugConsole.Log(new object[]
				{
					this.Target != null
				});
				DebugConsole.Log(new object[]
				{
					this.Target.value != null
				});
				throw;
			}
		}

		protected void OnPathPlayEnd()
		{
			if (!this.Path.IsPlaying && !this.pausing)
			{
				if (PlayPathMagic.PlayingPath.ContainsKey(this.PlayId))
				{
					PlayPathMagic.PlayingPath.Remove(this.PlayId);
				}
				PathMagic expr_47 = this.Path;
				expr_47.OnStopPlay = (Action)Delegate.Remove(expr_47.OnStopPlay, new Action(this.OnPathPlayEnd));
				base.EndAction();
			}
		}

		protected override void OnUpdate()
		{
			if (this.Path.IsPlaying)
			{
				switch (this.FollowType)
				{
				case PathFollowType.DisableFollow:
					break;
				case PathFollowType.FollowTargetPosition:
					this.Path.transform.position = this.target.position + this.PutOffset;
					break;
				case PathFollowType.FollowTargetPositionXZ:
				{
					Vector3 vector = this.target.position + this.PutOffset;
					this.Path.transform.position = new Vector3(vector.x, this.Path.transform.position.y, vector.z);
					break;
				}
				default:
					throw new ArgumentOutOfRangeException();
				}
			}
		}
	}
}
