using Assets.Scripts.Action.Core;
using Assets.Scripts.Tools.Component;
using Assets.Tools.Script.Helper;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace Assets.Scripts.Action
{
	[Category("obsolete/Camera"), Name("Supper background")]
	public class SupperBackground : DevisableAction
	{
		public GameObject BackgroundPrefab;

		public LayerMask wantLayers;

		public float RunTime = 1f;

		private int cullingMask;

		private GameObject supperBackgroundRoot;

		protected override void OnExecute()
		{
			if (this.RunTime > 0f)
			{
				this.cullingMask = Main3DCamera.Instance.Camera.cullingMask;
				Main3DCamera.Instance.Camera.cullingMask = this.wantLayers.value;
				Main3DCamera.Instance.Camera.clearFlags = CameraClearFlags.Depth;
				this.supperBackgroundRoot = new GameObject("supperBackgroundRoot");
				this.supperBackgroundRoot.transform.position = new Vector3(3444f, 3444f, 3444f);
				Camera camera = this.supperBackgroundRoot.AddComponent<Camera>();
				camera.depth = -2f;
				GameObject gameObject = this.supperBackgroundRoot.AddInstantiate(this.BackgroundPrefab);
				gameObject.transform.parent = this.supperBackgroundRoot.transform;
				gameObject.transform.localPosition = new Vector3(0f, 0f, 10f);
				gameObject.transform.localScale = this.BackgroundPrefab.transform.localScale;
			}
			else
			{
				base.EndAction();
			}
		}

		protected override void OnUpdate()
		{
			if (base.elapsedTime >= this.RunTime)
			{
				Main3DCamera.Instance.Camera.cullingMask = this.cullingMask;
				Main3DCamera.Instance.Camera.clearFlags = CameraClearFlags.Skybox;
				UnityEngine.Object.Destroy(this.supperBackgroundRoot);
				base.EndAction();
			}
		}
	}
}
