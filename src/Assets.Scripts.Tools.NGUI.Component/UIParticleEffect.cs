using Assets.Extends.EXNGUI.Render;
using Assets.Tools.Script.Helper;
using System;
using UnityEngine;

namespace Assets.Scripts.Tools.NGUI.Component
{
	public class UIParticleEffect : MonoBehaviour
	{
		public UIParticleEffectLayer EffectLayer;

		public int QueueOffset;

		public bool IncludeChildren;

		public void Start()
		{
			UIWidget w = null;
			if (UIParticleEffectLayerWriter.Widgets.ContainsKey(this.EffectLayer))
			{
				w = UIParticleEffectLayerWriter.Widgets[this.EffectLayer];
			}
			if (this.IncludeChildren)
			{
				this.InitWithChildren(w);
			}
			else
			{
				this.InitObject(w, base.gameObject);
			}
		}

		private void InitWithChildren(UIWidget w)
		{
			base.transform.ForEachAllChildren(delegate(Transform t)
			{
				this.InitObject(w, t.gameObject);
				return true;
			});
		}

		private void InitObject(UIWidget w, GameObject obj)
		{
			ParticleSystem component = obj.GetComponent<ParticleSystem>();
			Renderer component2 = obj.GetComponent<Renderer>();
			if (component != null)
			{
				RenderQueueOverSprite4Particle renderQueueOverSprite4Particle = obj.AddComponent<RenderQueueOverSprite4Particle>();
				renderQueueOverSprite4Particle.particle = component;
				renderQueueOverSprite4Particle.Sprite = w;
				renderQueueOverSprite4Particle.AutoAdjust = true;
				renderQueueOverSprite4Particle.QueueOffset = this.QueueOffset;
			}
			else if (component2 != null)
			{
				RenderQueueOverSprite4GameObject renderQueueOverSprite4GameObject = obj.AddComponent<RenderQueueOverSprite4GameObject>();
				renderQueueOverSprite4GameObject.toChangeGameObject = obj;
				renderQueueOverSprite4GameObject.Sprite = w;
				renderQueueOverSprite4GameObject.AutoAdjust = true;
				renderQueueOverSprite4GameObject.QueueOffset = this.QueueOffset;
			}
		}
	}
}
