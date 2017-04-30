using Assets.Scripts.Action.Core;
using Assets.Tools.Script.Helper;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace Assets.Scripts.Action
{
	[Category("✫ GOG/Effect"), Name("Play prefab effect(UI)")]
	public class PlayUIEffect : DevisableAction
	{
		private static Transform uiTransfrom;

		public static PlayUIEffect LastPlay;

		public bool IsDynamicPrefab;

		public BBParameter<GameObject> DynamicPrefab;

		public GameObject Prefab;

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
			UnityEngine.Object.Destroy(this.effect);
			base.EndAction();
		}

		protected override void OnExecute()
		{
			GameObject gameObject = null;
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
			if (PlayUIEffect.uiTransfrom == null)
			{
				foreach (UIRoot current in UIRoot.list)
				{
					if (current.gameObject.name == "UI Root (Battle2D)")
					{
						PlayUIEffect.uiTransfrom = current.gameObject.GetChildByName("3DUIEffect").transform;
					}
				}
			}
			this.effect = UnityEngine.Object.Instantiate<GameObject>(gameObject);
			this.effect.SetActive(true);
			this.effect.transform.parent = PlayUIEffect.uiTransfrom;
			this.effect.transform.position = gameObject.transform.position;
			this.effect.transform.rotation = Quaternion.Euler(PlayUIEffect.uiTransfrom.rotation.eulerAngles + gameObject.transform.rotation.eulerAngles);
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
			PlayUIEffect.LastPlay = this;
		}

		protected override void OnUpdate()
		{
			if (this.isPause)
			{
				return;
			}
			if (this.Life > 0f && base.elapsedTime > this.Life && this.effect != null)
			{
				UnityEngine.Object.Destroy(this.effect);
			}
			if (this.effect == null && base.elapsedTime > 0f)
			{
				base.EndAction();
			}
		}
	}
}
