using System;
using UnityEngine;

namespace Assets.Scripts.Tools.NGUI.Component
{
	[RequireComponent(typeof(UIEventListener))]
	public class UIEventConcentrator : MonoBehaviour
	{
		public UIEventListener[] EventListeners;

		public UIEventListener EventListener;

		public bool onSubmit;

		public bool onClick;

		public bool onDoubleClick;

		public bool onHover;

		public bool onPress;

		public bool onSelect;

		public bool onScroll;

		public bool onDragStart;

		public bool onDrag;

		public bool onDragOver;

		public bool onDragOut;

		public bool onDragEnd;

		public bool onDrop;

		public bool onKey;

		public bool onTooltip;

		private void Start()
		{
			if (this.onSubmit)
			{
				for (int i = 0; i < this.EventListeners.Length; i++)
				{
					UIEventListener uIEventListener = this.EventListeners[i];
					UIEventListener expr_1C = uIEventListener;
					expr_1C.onSubmit = (UIEventListener.VoidDelegate)Delegate.Combine(expr_1C.onSubmit, this.EventListener.onSubmit);
				}
			}
			if (this.onClick)
			{
				for (int j = 0; j < this.EventListeners.Length; j++)
				{
					UIEventListener uIEventListener2 = this.EventListeners[j];
					UIEventListener expr_6A = uIEventListener2;
					expr_6A.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(expr_6A.onClick, this.EventListener.onClick);
				}
			}
			if (this.onDoubleClick)
			{
				for (int k = 0; k < this.EventListeners.Length; k++)
				{
					UIEventListener uIEventListener3 = this.EventListeners[k];
					UIEventListener expr_BC = uIEventListener3;
					expr_BC.onDoubleClick = (UIEventListener.VoidDelegate)Delegate.Combine(expr_BC.onDoubleClick, this.EventListener.onDoubleClick);
				}
			}
			if (this.onHover)
			{
				for (int l = 0; l < this.EventListeners.Length; l++)
				{
					UIEventListener uIEventListener4 = this.EventListeners[l];
					UIEventListener expr_111 = uIEventListener4;
					expr_111.onHover = (UIEventListener.BoolDelegate)Delegate.Combine(expr_111.onHover, this.EventListener.onHover);
				}
			}
			if (this.onPress)
			{
				for (int m = 0; m < this.EventListeners.Length; m++)
				{
					UIEventListener uIEventListener5 = this.EventListeners[m];
					UIEventListener expr_166 = uIEventListener5;
					expr_166.onPress = (UIEventListener.BoolDelegate)Delegate.Combine(expr_166.onPress, this.EventListener.onPress);
				}
			}
			if (this.onSelect)
			{
				for (int n = 0; n < this.EventListeners.Length; n++)
				{
					UIEventListener uIEventListener6 = this.EventListeners[n];
					UIEventListener expr_1BB = uIEventListener6;
					expr_1BB.onSelect = (UIEventListener.BoolDelegate)Delegate.Combine(expr_1BB.onSelect, this.EventListener.onSelect);
				}
			}
			if (this.onScroll)
			{
				for (int num = 0; num < this.EventListeners.Length; num++)
				{
					UIEventListener uIEventListener7 = this.EventListeners[num];
					UIEventListener expr_210 = uIEventListener7;
					expr_210.onScroll = (UIEventListener.FloatDelegate)Delegate.Combine(expr_210.onScroll, this.EventListener.onScroll);
				}
			}
			if (this.onDragStart)
			{
				for (int num2 = 0; num2 < this.EventListeners.Length; num2++)
				{
					UIEventListener uIEventListener8 = this.EventListeners[num2];
					UIEventListener expr_265 = uIEventListener8;
					expr_265.onDragStart = (UIEventListener.VoidDelegate)Delegate.Combine(expr_265.onDragStart, this.EventListener.onDragStart);
				}
			}
			if (this.onDrag)
			{
				for (int num3 = 0; num3 < this.EventListeners.Length; num3++)
				{
					UIEventListener uIEventListener9 = this.EventListeners[num3];
					UIEventListener expr_2BA = uIEventListener9;
					expr_2BA.onDrag = (UIEventListener.VectorDelegate)Delegate.Combine(expr_2BA.onDrag, this.EventListener.onDrag);
				}
			}
			if (this.onDragOver)
			{
				for (int num4 = 0; num4 < this.EventListeners.Length; num4++)
				{
					UIEventListener uIEventListener10 = this.EventListeners[num4];
					UIEventListener expr_30F = uIEventListener10;
					expr_30F.onDragOver = (UIEventListener.VoidDelegate)Delegate.Combine(expr_30F.onDragOver, this.EventListener.onDragOver);
				}
			}
			if (this.onDragOut)
			{
				for (int num5 = 0; num5 < this.EventListeners.Length; num5++)
				{
					UIEventListener uIEventListener11 = this.EventListeners[num5];
					UIEventListener expr_364 = uIEventListener11;
					expr_364.onDragOut = (UIEventListener.VoidDelegate)Delegate.Combine(expr_364.onDragOut, this.EventListener.onDragOut);
				}
			}
			if (this.onDragEnd)
			{
				for (int num6 = 0; num6 < this.EventListeners.Length; num6++)
				{
					UIEventListener uIEventListener12 = this.EventListeners[num6];
					UIEventListener expr_3B9 = uIEventListener12;
					expr_3B9.onDragEnd = (UIEventListener.VoidDelegate)Delegate.Combine(expr_3B9.onDragEnd, this.EventListener.onDragEnd);
				}
			}
			if (this.onDrop)
			{
				for (int num7 = 0; num7 < this.EventListeners.Length; num7++)
				{
					UIEventListener uIEventListener13 = this.EventListeners[num7];
					UIEventListener expr_40E = uIEventListener13;
					expr_40E.onDrop = (UIEventListener.ObjectDelegate)Delegate.Combine(expr_40E.onDrop, this.EventListener.onDrop);
				}
			}
			if (this.onKey)
			{
				for (int num8 = 0; num8 < this.EventListeners.Length; num8++)
				{
					UIEventListener uIEventListener14 = this.EventListeners[num8];
					UIEventListener expr_463 = uIEventListener14;
					expr_463.onKey = (UIEventListener.KeyCodeDelegate)Delegate.Combine(expr_463.onKey, this.EventListener.onKey);
				}
			}
			if (this.onTooltip)
			{
				for (int num9 = 0; num9 < this.EventListeners.Length; num9++)
				{
					UIEventListener uIEventListener15 = this.EventListeners[num9];
					UIEventListener expr_4B8 = uIEventListener15;
					expr_4B8.onTooltip = (UIEventListener.BoolDelegate)Delegate.Combine(expr_4B8.onTooltip, this.EventListener.onTooltip);
				}
			}
		}
	}
}
