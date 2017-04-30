using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Extends.EXNGUI.Core.Compoment
{
	public class UISimpleBtn : MonoBehaviour
	{
		[HideInInspector]
		public List<EventDelegate> onClick = new List<EventDelegate>();

		[SerializeField]
		private UISprite _bk;

		[SerializeField]
		private UILabel _nameLabel;

		[SerializeField]
		private string _enabledFlaseSprName = "通用按钮-灰色";

		private string _enabledTureName = string.Empty;

		[SerializeField]
		private bool _btnEnabled = true;

		public string text
		{
			get
			{
				return this._nameLabel.text;
			}
			set
			{
				this._nameLabel.text = value;
			}
		}

		public bool btnEnabled
		{
			get
			{
				return this._btnEnabled;
			}
			set
			{
				if (this._btnEnabled == value)
				{
					return;
				}
				this._btnEnabled = value;
				base.GetComponent<Collider>().enabled = value;
				this.UpdateState();
			}
		}

		private void Start()
		{
			this.InitEnabledTureName();
			UIButton component = base.GetComponent<UIButton>();
			if (component != null)
			{
				this.onClick.AddRange(component.onClick);
				UnityEngine.Object.Destroy(component);
			}
			this.UpdateState();
		}

		private void OnClick()
		{
			EventDelegate.Execute(this.onClick);
		}

		public void SetClickListener(EventDelegate.Callback listener)
		{
			this.onClick.Clear();
			this.onClick.Add(new EventDelegate(listener));
		}

		private void UpdateState()
		{
			this.InitEnabledTureName();
			this._bk.spriteName = ((!this._btnEnabled) ? ((!this._enabledFlaseSprName.IsNullOrEmpty()) ? this._enabledFlaseSprName : this._enabledTureName) : this._enabledTureName);
		}

		private void InitEnabledTureName()
		{
			if (this._enabledTureName == string.Empty)
			{
				this._enabledTureName = this._bk.spriteName;
			}
		}
	}
}
