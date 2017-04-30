using Assets.Migration.Scripts.Action.Effect;
using Assets.Tools.Script.Helper;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;
using XQ.Game.Util.Unity;

namespace Assets.Scripts.Tools.Component
{
	public class Main3DCamera : MonoBehaviour
	{
		public static Main3DCamera Instance;

		public Transform Level1;

		public Transform Level2;

		public Transform Level3;

		public ForegroundBehavior ForegroundBehavior;

		public AnimationPlayer Animation;

		public Camera Camera;

		private Transform lookAtAgent;

		private Vector3 defaultPosition;

		private Quaternion defaultQuaternion;

		private Dictionary<string, Camera> cameras;

		private Dictionary<Camera, LayerMask> cameraDefaultMasks;

		private Dictionary<PostEffectsBase, bool> postEffects;

		public Transform LookAtAgent
		{
			get
			{
				if (this.lookAtAgent == null)
				{
					this.lookAtAgent = new GameObject
					{
						name = "lookAtAgent"
					}.transform;
				}
				return this.lookAtAgent;
			}
		}

		public void Start()
		{
			Main3DCamera.Instance = this;
			if (this.Level1 == null)
			{
				this.Level1 = base.transform;
			}
			if (this.Level2 == null)
			{
				this.Level2 = base.transform;
			}
			if (this.Level3 == null)
			{
				this.Level3 = base.transform;
			}
			this.defaultPosition = base.transform.position;
			this.defaultQuaternion = base.transform.rotation;
			if (this.Animation == null)
			{
				this.Animation = base.GetComponent<AnimationPlayer>();
			}
			if (this.Camera == null)
			{
				this.Camera = base.GetComponentInChildren<Camera>();
			}
			if (this.ForegroundBehavior == null)
			{
				this.ForegroundBehavior = base.GetComponentInChildren<ForegroundBehavior>();
			}
			this.cameraDefaultMasks = new Dictionary<Camera, LayerMask>(4);
			this.cameras = new Dictionary<string, Camera>(4);
			base.transform.ForEachAllChildren(delegate(Transform child)
			{
				Camera component = child.GetComponent<Camera>();
				if (component != null)
				{
					this.cameras.Add(component.name, component);
					this.cameraDefaultMasks.Add(component, component.cullingMask);
				}
				return true;
			});
			this.postEffects = new Dictionary<PostEffectsBase, bool>();
			PostEffectsBase[] componentsInChildren = base.GetComponentsInChildren<PostEffectsBase>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				PostEffectsBase postEffectsBase = componentsInChildren[i];
				this.postEffects[postEffectsBase] = postEffectsBase.enabled;
			}
		}

		public Camera GetCamera(string cameraName)
		{
			Camera result;
			this.cameras.TryGetValue(cameraName, out result);
			return result;
		}

		public void PlayEntryAnim()
		{
			this.Animation.Play("CameraPreview");
		}

		public void PlayDefaultAnim()
		{
			base.transform.position = this.defaultPosition;
			base.transform.rotation = this.defaultQuaternion;
			this.Animation.Play("CameraDefault");
		}

		public void StopAnim()
		{
			this.Animation.Stop();
		}

		public void Restore()
		{
			this.ForegroundBehavior.Color = Color.clear;
		}

		public void SetPostEffectActive(bool active)
		{
			if (active)
			{
				foreach (KeyValuePair<PostEffectsBase, bool> current in this.postEffects)
				{
					current.Key.enabled = current.Value;
				}
			}
			else
			{
				foreach (KeyValuePair<PostEffectsBase, bool> current2 in this.postEffects)
				{
					current2.Key.enabled = false;
				}
			}
		}

		public void SetForegroundCameraActive(bool active)
		{
			Camera foregroundCamera = this.ForegroundBehavior.ForegroundCamera;
			foregroundCamera.enabled = active;
		}

		public void SetLookAtAgent(Transform target, Vector3 offset)
		{
			this.LookAtAgent.parent = target;
			this.LookAtAgent.localPosition = offset;
		}

		public void LookAt(Transform target, Vector3 offset)
		{
			this.SetLookAtAgent(target, offset);
			this.Level1.LookAt(this.LookAtAgent);
		}

		private void Update()
		{
			Camera foregroundCamera = this.ForegroundBehavior.ForegroundCamera;
			if (foregroundCamera.enabled)
			{
				foregroundCamera.fieldOfView = this.Camera.fieldOfView;
			}
		}
	}
}
