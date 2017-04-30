using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Extends.EXNGUI.Compoment
{
	[RequireComponent(typeof(UISprite))]
	public class UIClip : MonoBehaviour
	{
		public enum Style
		{
			Once,
			Loop,
			PingPong
		}

		public UIClip.Style playStyle;

		public string clipName;

		public string suffix;

		public float frameTime;

		public int fromIndex;

		public int toIndex;

		public string indexParse;

		public bool adjustSize = true;

		public float sizeScale = 1f;

		public bool autoStart;

		public bool stopOnDisable = true;

		public Action<UIClip> onPlayEndSignal;

		private List<string> _animSpriteNames;

		private UISprite _sprite;

		private bool _forward;

		public bool isPlaying
		{
			get;
			private set;
		}

		public int currFrame
		{
			get;
			private set;
		}

		public int totalFrame
		{
			get;
			private set;
		}

		private void Awake()
		{
			this.Init();
		}

		public void Init()
		{
			if (this._sprite == null)
			{
				this._sprite = base.GetComponent<UISprite>();
				this._animSpriteNames = new List<string>(4);
				this.isPlaying = false;
				this._forward = true;
				this.RebuildSpriteList();
				if (this.autoStart)
				{
					this.GoToAndPlay(0);
				}
				else
				{
					this.GoToAndStop(0);
				}
			}
		}

		public void GoToAndPlay(int frame)
		{
			this.isPlaying = true;
			this.currFrame = frame;
			this._sprite.spriteName = this._animSpriteNames[this.currFrame];
			this.AdjustSize();
			base.CancelInvoke("PlayClip");
			base.InvokeRepeating("PlayClip", this.frameTime, this.frameTime);
		}

		public void GoToAndStop(int frame)
		{
			this.isPlaying = false;
			this.currFrame = frame;
			this._sprite.spriteName = this._animSpriteNames[this.currFrame];
			this.AdjustSize();
			base.CancelInvoke("PlayClip");
		}

		public void Play()
		{
			if (this.isPlaying)
			{
				return;
			}
			this.isPlaying = true;
			base.CancelInvoke("PlayClip");
			base.InvokeRepeating("PlayClip", this.frameTime, this.frameTime);
		}

		public void Stop()
		{
			this.isPlaying = false;
			base.CancelInvoke("PlayClip");
		}

		public void RebuildSpriteList()
		{
			this._animSpriteNames.Clear();
			if (this.clipName.IsNOTNullOrEmpty() && this.toIndex > this.fromIndex)
			{
				this.totalFrame = this.toIndex - this.fromIndex + 1;
				for (int i = this.fromIndex; i <= this.toIndex; i++)
				{
					this._animSpriteNames.Add(this.clipName + i.ToString((!this.indexParse.IsNullOrEmpty()) ? this.indexParse : string.Empty) + this.suffix);
				}
			}
			else if (this.clipName.IsNOTNullOrEmpty())
			{
				List<UISpriteData> spriteList = this._sprite.atlas.spriteList;
				int j = 0;
				int count = spriteList.Count;
				while (j < count)
				{
					UISpriteData uISpriteData = spriteList[j];
					if (uISpriteData.name.StartsWith(this.clipName))
					{
						this._animSpriteNames.Add(uISpriteData.name);
					}
					j++;
				}
				this.totalFrame = this._animSpriteNames.Count;
				this._animSpriteNames.Sort();
			}
			else
			{
				List<UISpriteData> spriteList2 = this._sprite.atlas.spriteList;
				this.totalFrame = this._sprite.atlas.spriteList.Count;
				int k = 0;
				int count2 = spriteList2.Count;
				while (k < count2)
				{
					this._animSpriteNames.Add(spriteList2[k].name);
					k++;
				}
				this._animSpriteNames.Sort();
			}
		}

		public void SnapFrame()
		{
			if (this._sprite == null || this._sprite.atlas == null)
			{
				return;
			}
			int num = 2147483647;
			int num2 = -2147483648;
			for (int i = 0; i < this._sprite.atlas.spriteList.Count; i++)
			{
				UISpriteData uISpriteData = this._sprite.atlas.spriteList[i];
				if (uISpriteData.name.StartsWith(this.clipName))
				{
					string value = uISpriteData.name.Substring(this.clipName.Length, uISpriteData.name.Length - this.clipName.Length);
					int num3 = Convert.ToInt32(value);
					if (num3 < num)
					{
						num = num3;
					}
					if (num3 > num2)
					{
						num2 = num3;
					}
				}
			}
			this.fromIndex = num;
			this.toIndex = num2;
		}

		private void OnEnable()
		{
			if (this.stopOnDisable)
			{
				if (this.autoStart)
				{
					this.GoToAndPlay(0);
				}
				else
				{
					this.GoToAndStop(0);
				}
			}
		}

		private void OnDisable()
		{
			if (this.stopOnDisable)
			{
				this.Stop();
			}
		}

		private void PlayClip()
		{
			int num = this.currFrame;
			if (this._forward)
			{
				num++;
				if (num >= this.totalFrame)
				{
					switch (this.playStyle)
					{
					case UIClip.Style.Once:
						this.Stop();
						num = this.currFrame;
						if (this.onPlayEndSignal != null)
						{
							this.onPlayEndSignal(this);
						}
						break;
					case UIClip.Style.Loop:
						num = 0;
						if (this.onPlayEndSignal != null)
						{
							this.onPlayEndSignal(this);
						}
						break;
					case UIClip.Style.PingPong:
						this._forward = false;
						num = this.currFrame - 1;
						break;
					default:
						throw new ArgumentOutOfRangeException();
					}
				}
			}
			else
			{
				num--;
				if (num < 0)
				{
					this._forward = true;
					num = 1;
				}
			}
			this.currFrame = num;
			this._sprite.spriteName = this._animSpriteNames[this.currFrame];
			this.AdjustSize();
		}

		private void AdjustSize()
		{
			if (this.adjustSize)
			{
				this._sprite.MakePixelPerfect();
				this._sprite.width = (int)((float)this._sprite.width * this.sizeScale);
				this._sprite.height = (int)((float)this._sprite.height * this.sizeScale);
			}
		}
	}
}
