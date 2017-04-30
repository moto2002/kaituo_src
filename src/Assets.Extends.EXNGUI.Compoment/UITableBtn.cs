using Assets.Tools.Script.Event;
using Assets.Tools.Script.Helper;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Extends.EXNGUI.Compoment
{
	public class UITableBtn : MonoBehaviour
	{
		[SerializeField]
		private TableBtnPage[] _btnPages;

		public UIButton defaultPage;

		public readonly Signal<UITableBtn> onPageSignal = new Signal<UITableBtn>();

		private Dictionary<UIButton, TableBtnPage> Pages;

		private TableBtnPage _currPage;

		public TableBtnPage currPage
		{
			get
			{
				return this._currPage;
			}
		}

		private void Awake()
		{
			this.Pages = new Dictionary<UIButton, TableBtnPage>();
			if (this._btnPages.Length > 0)
			{
				int num = 0;
				TableBtnPage[] btnPages = this._btnPages;
				for (int i = 0; i < btnPages.Length; i++)
				{
					TableBtnPage btnPage = btnPages[i];
					this.AddPage(btnPage, num++);
				}
				this.defaultPage = (this.defaultPage ?? this._btnPages[0].btn);
				this.PageTo(this.defaultPage);
			}
		}

		private void AddPage(TableBtnPage btnPage, int index)
		{
			btnPage.tableBtn = this;
			btnPage.index = index;
			btnPage.btn.onClick.Add(new EventDelegate(new EventDelegate.Callback(btnPage.PageTo)));
			btnPage.btn.isEnabled = true;
			NGUITools.SetActive(btnPage.page, false);
			this.Pages.Add(btnPage.btn, btnPage);
		}

		public void PageTo(int index)
		{
			if (this.Pages != null)
			{
				TableBtnPage tableBtnPage = this.Pages.Values.FirstOrDefaultValue((TableBtnPage e) => e.index == index);
				this.PageTo(tableBtnPage.btn);
			}
			else
			{
				this.defaultPage = this._btnPages[index].btn;
			}
		}

		public void PageTo(UIButton btn)
		{
			if (this._currPage != null)
			{
				this._currPage.btn.isEnabled = true;
				NGUITools.SetActive(this._currPage.page, false);
			}
			if (this.Pages.ContainsKey(btn))
			{
				this._currPage = this.Pages[btn];
				this._currPage.btn.isEnabled = false;
				NGUITools.SetActive(this._currPage.page, true);
			}
			else
			{
				this._currPage = null;
			}
			this.onPageSignal.Dispatch(this);
		}
	}
}
