using Assets.Scripts.Action.Core;
using Assets.Tools.Script.Helper;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace Assets.Scripts.Action
{
	[Category("✫ GOG/Effect"), Name("Play prefab effect")]
	public class PlayEffect : DevisableAction
	{
		public static PlayEffect LastPlay;

		public bool IsDynamicPrefab;

		public BBParameter<GameObject> DynamicPrefab;

		public GameObject Prefab;

		public BBParameter<GameObject> Target;

		public bool ByInstantiate;

		public float Life;

		public LayerMask PlayLayer;

		private GameObject effect;

		private bool isPause;

		private float pauseStartTime;

		public void Pause()
		{
			this.isPause = true;
			this.pauseStartTime = base.elapsedTime;
			this.effect.SetActive(false);
		}

		public void Resume()
		{
			this.isPause = false;
			this.Life += base.elapsedTime - this.pauseStartTime;
			this.effect.SetActive(true);
		}

		public void Close()
		{
			if (this.ByInstantiate)
			{
				UnityEngine.Object.Destroy(this.effect);
			}
			this.effect = null;
			base.EndAction();
		}

		protected override void OnExecute()
		{
			GameObject gameObject;
			if (this.IsDynamicPrefab)
			{
				gameObject = ((this.DynamicPrefab != null) ? this.DynamicPrefab.value : null);
			}
			else
			{
				gameObject = this.Prefab;
			}
			if (gameObject == null)
			{
				base.EndAction();
				return;
			}
			Transform transform = this.Target.value.transform;
			if (!this.IsDynamicPrefab || this.ByInstantiate)
			{
				this.effect = UnityEngine.Object.Instantiate<GameObject>(gameObject);
			}
			else
			{
				this.effect = gameObject;
			}
			this.effect.SetActive(true);
			this.effect.transform.parent = transform;
			this.effect.transform.localPosition = Vector3.zero;
			this.effect.transform.localRotation = Quaternion.identity;
			int layer;
			bool flag = LayerMaskExtension.ValueToLayer.TryGetValue((uint)this.PlayLayer.value, out layer);
			if (flag)
			{
				this.effect.SetLayerWidthChildren(layer);
			}
			if (Math.Abs(this.Life) < 0.0001f)
			{
				base.EndAction();
			}
			PlayEffect.LastPlay = this;
		}

		protected override void OnUpdate()
		{
			if (this.isPause)
			{
				return;
			}
			if (this.Life > 0f && base.elapsedTime > this.Life && this.effect != null)
			{
				if (this.ByInstantiate)
				{
					UnityEngine.Object.Destroy(this.effect);
				}
				this.effect = null;
			}
			if (this.effect == null && base.elapsedTime > 0f)
			{
				base.EndAction();
			}
		}

		protected override void OnStop()
		{
			if (this.effect != null)
			{
				DebugConsole.LogToChannel(22, "OnStop");
				if (this.ByInstantiate)
				{
					UnityEngine.Object.Destroy(this.effect);
				}
				this.effect = null;
			}
		}
	}
}
