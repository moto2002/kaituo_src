using Assets.Tools.Script.Helper;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Extends.EXNGUI.Compoment
{
	public class UIJumpLabel : MonoBehaviour
	{
		public GameObject demoLabelObj;

		protected int labelHeight;

		private readonly List<GameObject> _labels = new List<GameObject>();

		private bool _inited;

		private int spacingX;

		private string _text;

		public string Text
		{
			get
			{
				return this._text;
			}
			set
			{
				if (!this._inited)
				{
					return;
				}
				int num = value.Length - this._labels.Count;
				for (int i = 0; i < num; i++)
				{
					this._labels.Add(base.gameObject.AddInstantiate(this.demoLabelObj));
				}
				for (int j = 0; j < this._labels.Count; j++)
				{
					this._labels[j].SetActive(j < value.Length);
				}
				int num2 = 0;
				for (int k = 0; k < value.Length; k++)
				{
					UILabel component = this._labels[k].GetComponent<UILabel>();
					component.alpha = 1f;
					component.text = value[k].ToString();
					this._labels[k].transform.SetLocalPositionX((float)num2);
					num2 = (int)(this._labels[k].transform.localPosition.x + (float)component.width + (float)this.spacingX);
				}
				this._text = value;
			}
		}

		private void Start()
		{
			this.Init();
			UILabel component = this.demoLabelObj.GetComponent<UILabel>();
			this.Text = component.text;
		}

		private void Init()
		{
			UILabel component = this.demoLabelObj.GetComponent<UILabel>();
			this.labelHeight = component.height;
			this.spacingX = component.spacingX;
			if (component == null)
			{
				throw new Exception("the GameObject 'DemoLabelObj' mast have UILabel");
			}
			component.alpha = 0f;
			this._inited = true;
		}

		private void Update()
		{
			long time = DateTime.Now.Ticks / 10000L;
			for (int i = 0; i < this._text.Length; i++)
			{
				this.UpdateLabel(this._labels[i], i, time);
			}
		}

		protected virtual void UpdateLabel(GameObject label, int labelIndex, long time)
		{
			time %= 1000000L;
			float num = (float)time / 100f;
			num = (float)((double)(num - (float)labelIndex) % 25.132741228718345);
			if ((double)num > 3.1415926535897931)
			{
				label.transform.SetLocalPositionY(0f);
			}
			else
			{
				float num2 = (float)Math.Sin((double)num);
				label.transform.SetLocalPositionY(num2 * (float)this.labelHeight / 2f);
			}
		}
	}
}
