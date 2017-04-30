using System;
using UnityEngine;

namespace Assets.Scripts.Tools.NGUI.Component
{
	public class UITweenLabelColor : UITweener
	{
		public Color fromMain = Color.white;

		public Color toMain = Color.white;

		public Color fromOutline = Color.white;

		public Color toOutline = Color.white;

		public Color fromTop = Color.white;

		public Color toTop = Color.white;

		public Color fromDown = Color.white;

		public Color toDown = Color.white;

		private bool mCached;

		private UILabel label;

		public Color mainColor
		{
			get
			{
				if (!this.mCached)
				{
					this.Cache();
				}
				if (this.label != null)
				{
					return this.label.color;
				}
				return Color.black;
			}
			set
			{
				if (!this.mCached)
				{
					this.Cache();
				}
				if (this.label != null)
				{
					this.label.color = value;
				}
			}
		}

		public Color outLineColor
		{
			get
			{
				if (!this.mCached)
				{
					this.Cache();
				}
				if (this.label != null)
				{
					return this.label.effectColor;
				}
				return Color.black;
			}
			set
			{
				if (!this.mCached)
				{
					this.Cache();
				}
				if (this.label != null)
				{
					this.label.effectColor = value;
				}
			}
		}

		public Color topColor
		{
			get
			{
				if (!this.mCached)
				{
					this.Cache();
				}
				if (this.label != null)
				{
					return this.label.gradientTop;
				}
				return Color.black;
			}
			set
			{
				if (!this.mCached)
				{
					this.Cache();
				}
				if (this.label != null)
				{
					this.label.gradientTop = value;
				}
			}
		}

		public Color downColor
		{
			get
			{
				if (!this.mCached)
				{
					this.Cache();
				}
				if (this.label != null)
				{
					return this.label.gradientBottom;
				}
				return Color.black;
			}
			set
			{
				if (!this.mCached)
				{
					this.Cache();
				}
				if (this.label != null)
				{
					this.label.gradientBottom = value;
				}
			}
		}

		private void Cache()
		{
			this.mCached = true;
			this.label = base.GetComponent<UILabel>();
		}

		protected override void OnUpdate(float factor, bool isFinished)
		{
			this.mainColor = Color.Lerp(this.fromMain, this.toMain, factor);
			this.outLineColor = Color.Lerp(this.fromOutline, this.toOutline, factor);
			this.topColor = Color.Lerp(this.fromTop, this.toTop, factor);
			this.downColor = Color.Lerp(this.fromDown, this.toDown, factor);
		}
	}
}
