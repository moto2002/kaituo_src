using NodeCanvas.Framework;
using ParadoxNotion.Design;
using ParadoxNotion.Services;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("UGUI"), Description("Returns true when the selected event is triggered on the selected agent.\nYou can use this for both GUI and 3D objects.\nPlease make sure that Unity Event Systems are setup correctly")]
	public class InterceptEvent : ConditionTask<Transform>
	{
		public EventTriggerType eventType;

		protected override string info
		{
			get
			{
				return this.eventType.ToString();
			}
		}

		protected override string OnInit()
		{
			MessageRouter messageRouter = base.agent.GetComponent<MessageRouter>();
			if (messageRouter == null)
			{
				messageRouter = base.agent.gameObject.AddComponent<MessageRouter>();
			}
			messageRouter.Listen(this, "On" + this.eventType.ToString());
			return null;
		}

		protected override bool OnCheck()
		{
			return false;
		}

		private void OnPointerEnter(PointerEventData eventData)
		{
			base.YieldReturn(true);
		}

		private void OnPointerExit(PointerEventData eventData)
		{
			base.YieldReturn(true);
		}

		private void OnPointerDown(PointerEventData eventData)
		{
			base.YieldReturn(true);
		}

		private void OnPointerUp(PointerEventData eventData)
		{
			base.YieldReturn(true);
		}

		private void OnPointerClick(PointerEventData eventData)
		{
			base.YieldReturn(true);
		}

		private void OnDrag(PointerEventData eventData)
		{
			base.YieldReturn(true);
		}

		private void OnDrop(BaseEventData eventData)
		{
			base.YieldReturn(true);
		}

		private void OnScroll(PointerEventData eventData)
		{
			base.YieldReturn(true);
		}

		private void OnUpdateSelected(BaseEventData eventData)
		{
			base.YieldReturn(true);
		}

		private void OnSelect(BaseEventData eventData)
		{
			base.YieldReturn(true);
		}

		private void OnDeselect(BaseEventData eventData)
		{
			base.YieldReturn(true);
		}

		private void OnMove(AxisEventData eventData)
		{
			base.YieldReturn(true);
		}

		private void OnSubmit(BaseEventData eventData)
		{
			base.YieldReturn(true);
		}
	}
}
