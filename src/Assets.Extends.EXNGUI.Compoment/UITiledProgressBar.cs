using System;
using UnityEngine;

namespace Assets.Extends.EXNGUI.Compoment
{
	[RequireComponent(typeof(UISprite))]
	public class UITiledProgressBar : MonoBehaviour
	{
		public int fullWidth = -1;

		public int defaultValue;

		public UILabel currLabel;

		public UILabel maxLabel;

		private UISprite _sprite;

		private bool _inited;

		private float _maxValue = 1f;

		private float _currValue;

		public float MaxValue
		{
			get
			{
				return this._maxValue;
			}
			set
			{
				if (!this._inited)
				{
					this.Init();
				}
				this._maxValue = value;
				if (this.maxLabel != null)
				{
					this.maxLabel.text = this._maxValue.ToString();
				}
				this.UpdateProgress();
			}
		}

		public float CurrValue
		{
			get
			{
				return this._currValue;
			}
			set
			{
				if (!this._inited)
				{
					this.Init();
				}
				this._currValue = value;
				if (this._currValue > this._maxValue)
				{
					this._currValue = this._maxValue;
				}
				if (this.currLabel != null)
				{
					this.currLabel.text = this._currValue.ToString();
				}
				this.UpdateProgress();
			}
		}

		private void Awake()
		{
			if (!this._inited)
			{
				this.Init();
			}
		}

		private void UpdateProgress()
		{
			this._sprite.width = (int)(this.CurrValue / this.MaxValue * (float)this.fullWidth);
		}

		private void Init()
		{
			this._inited = true;
			this._sprite = base.GetComponent<UISprite>();
			this._sprite.pivot = UIWidget.Pivot.Left;
			if (this.fullWidth < 0)
			{
				this.fullWidth = this._sprite.width;
			}
			this.CurrValue = (float)this.defaultValue;
		}
	}
}
