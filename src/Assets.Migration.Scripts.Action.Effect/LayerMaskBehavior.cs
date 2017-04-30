using System;
using UnityEngine;
using XQ.Framework.Utility;

namespace Assets.Migration.Scripts.Action.Effect
{
	public class LayerMaskBehavior : MonoBehaviour
	{
		public Camera TargetCamera;

		public LayerMask CullingMask;

		public Color MaskColor;

		public int MaskTextureSize = 1024;

		public float ElaspedSeconds;

		private Camera maskCamera;

		private GUITexture maskGUITexture;

		private RenderTexture maskRenderTexture;

		private float startTime;

		public void StartMask(Camera targetCamera, LayerMask cullingMask, Color maskColor, int maskTextureSize, float elaspedSeconds)
		{
			if (targetCamera == null)
			{
				return;
			}
			this.TargetCamera = targetCamera;
			this.CullingMask = cullingMask;
			this.MaskColor = maskColor;
			this.MaskTextureSize = maskTextureSize;
			this.ElaspedSeconds = elaspedSeconds;
			this.Init();
			base.enabled = true;
			this.startTime = Time.realtimeSinceStartup;
		}

		public void StopMask()
		{
			base.enabled = false;
		}

		private void Awake()
		{
		}

		private void Update()
		{
			if (!base.enabled)
			{
				return;
			}
			if (this.maskCamera == null)
			{
				return;
			}
			if (this.ElaspedSeconds > 0f && Time.realtimeSinceStartup - this.startTime > this.ElaspedSeconds)
			{
				this.StopMask();
				return;
			}
			int pixelLightCount = QualitySettings.pixelLightCount;
			QualitySettings.pixelLightCount = 0;
			base.transform.position = this.TargetCamera.transform.position;
			base.transform.rotation = this.TargetCamera.transform.rotation;
			this.maskCamera.Render();
			QualitySettings.pixelLightCount = pixelLightCount;
		}

		private void OnGUI()
		{
			Rect position = new Rect(0f, 0f, (float)Screen.width, (float)Screen.height);
			GUI.DrawTexture(position, this.maskRenderTexture, ScaleMode.StretchToFill);
		}

		private void Init()
		{
			if (this.maskRenderTexture == null)
			{
				this.maskRenderTexture = new RenderTexture(this.MaskTextureSize, this.MaskTextureSize, 16);
				this.maskRenderTexture.name = "__Mask" + base.GetInstanceID();
				this.maskRenderTexture.isPowerOfTwo = true;
				this.maskRenderTexture.hideFlags = HideFlags.DontSave;
			}
			this.maskCamera = base.GetComponent<Camera>();
			this.UpdateCameraModes(this.TargetCamera, this.maskCamera);
			this.maskCamera.cullingMask = this.CullingMask;
			this.maskCamera.targetTexture = this.maskRenderTexture;
			this.maskCamera.SetReplacementShader(ShaderHelper.Find("Unlit//Color"), null);
		}

		private void UpdateCameraModes(Camera src, Camera dest)
		{
			if (dest == null)
			{
				return;
			}
			dest.clearFlags = CameraClearFlags.Color;
			dest.backgroundColor = this.MaskColor;
			dest.farClipPlane = src.farClipPlane;
			dest.nearClipPlane = src.nearClipPlane;
			dest.orthographic = src.orthographic;
			dest.fieldOfView = src.fieldOfView;
			dest.aspect = src.aspect;
			dest.orthographicSize = src.orthographicSize;
		}
	}
}
