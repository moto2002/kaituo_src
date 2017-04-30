using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ParadoxNotion.Services
{
	public class MessageRouter : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IDragHandler, IScrollHandler, IUpdateSelectedHandler, ISelectHandler, IDeselectHandler, IMoveHandler, ISubmitHandler
	{
		private readonly Dictionary<string, List<object>> listeners = new Dictionary<string, List<object>>();

		public void OnPointerEnter(PointerEventData eventData)
		{
			this.Send("OnPointerEnter", eventData);
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			this.Send("OnPointerExit", eventData);
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			this.Send("OnPointerDown", eventData);
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			this.Send("OnPointerUp", eventData);
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			this.Send("OnPointerClick", eventData);
		}

		public void OnDrag(PointerEventData eventData)
		{
			this.Send("OnDrag", eventData);
		}

		public void OnDrop(BaseEventData eventData)
		{
			this.Send("OnDrop", eventData);
		}

		public void OnScroll(PointerEventData eventData)
		{
			this.Send("OnScroll", eventData);
		}

		public void OnUpdateSelected(BaseEventData eventData)
		{
			this.Send("OnUpdateSelected", eventData);
		}

		public void OnSelect(BaseEventData eventData)
		{
			this.Send("OnSelect", eventData);
		}

		public void OnDeselect(BaseEventData eventData)
		{
			this.Send("OnDeselect", eventData);
		}

		public void OnMove(AxisEventData eventData)
		{
			this.Send("OnMove", eventData);
		}

		public void OnSubmit(BaseEventData eventData)
		{
			this.Send("OnSubmit", eventData);
		}

		private void OnAnimatorIK(int layerIndex)
		{
			this.Send("OnAnimatorIK", layerIndex);
		}

		private void OnBecameInvisible()
		{
			this.Send("OnBecameInvisible", null);
		}

		private void OnBecameVisible()
		{
			this.Send("OnBecameVisible", null);
		}

		private void OnCollisionEnter(Collision collisionInfo)
		{
			this.Send("OnCollisionEnter", collisionInfo);
		}

		private void OnCollisionExit(Collision collisionInfo)
		{
			this.Send("OnCollisionExit", collisionInfo);
		}

		private void OnCollisionStay(Collision collisionInfo)
		{
			this.Send("OnCollisionStay", collisionInfo);
		}

		private void OnCollisionEnter2D(Collision2D collisionInfo)
		{
			this.Send("OnCollisionEnter2D", collisionInfo);
		}

		private void OnCollisionExit2D(Collision2D collisionInfo)
		{
			this.Send("OnCollisionExit2D", collisionInfo);
		}

		private void OnCollisionStay2D(Collision2D collisionInfo)
		{
			this.Send("OnCollisionStay2D", collisionInfo);
		}

		private void OnTriggerEnter(Collider other)
		{
			this.Send("OnTriggerEnter", other);
		}

		private void OnTriggerExit(Collider other)
		{
			this.Send("OnTriggerExit", other);
		}

		private void OnTriggerStay(Collider other)
		{
			this.Send("OnTriggerStay", other);
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			this.Send("OnTriggerEnter2D", other);
		}

		private void OnTriggerExit2D(Collider2D other)
		{
			this.Send("OnTriggerExit2D", other);
		}

		private void OnTriggerStay2D(Collider2D other)
		{
			this.Send("OnTriggerStay2D", other);
		}

		private void OnMouseDown()
		{
			this.Send("OnMouseDown", null);
		}

		private void OnMouseDrag()
		{
			this.Send("OnMouseDrag", null);
		}

		private void OnMouseEnter()
		{
			this.Send("OnMouseEnter", null);
		}

		private void OnMouseExit()
		{
			this.Send("OnMouseExit", null);
		}

		private void OnMouseOver()
		{
			this.Send("OnMouseOver", null);
		}

		private void OnMouseUp()
		{
			this.Send("OnMouseUp", null);
		}

		public void OnCustomEvent(EventData eventData)
		{
			Debug.Log(string.Format("<b>Event Send to ({0}): </b> '{1}'", base.name, eventData.name));
			this.Send("OnCustomEvent", eventData);
		}

		public void Listen(object target, string toMessage)
		{
			if (!this.listeners.ContainsKey(toMessage))
			{
				this.listeners[toMessage] = new List<object>();
			}
			if (!this.listeners[toMessage].Contains(target))
			{
				this.listeners[toMessage].Add(target);
			}
		}

		public void Forget(object target)
		{
			if (target == null)
			{
				return;
			}
			foreach (string current in this.listeners.Keys)
			{
				object[] array = this.listeners[current].ToArray();
				for (int i = 0; i < array.Length; i++)
				{
					object obj = array[i];
					if (obj == target)
					{
						this.listeners[current].Remove(target);
					}
				}
			}
		}

		public void Forget(object target, string forgetMessage)
		{
			if (target == null || !this.listeners.ContainsKey(forgetMessage))
			{
				return;
			}
			object[] array = this.listeners[forgetMessage].ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				object obj = array[i];
				if (obj == target)
				{
					this.listeners[forgetMessage].Remove(target);
				}
			}
		}

		public void Send(string message, object arg)
		{
			if (!this.listeners.ContainsKey(message))
			{
				return;
			}
			for (int i = 0; i < this.listeners[message].Count; i++)
			{
				object obj = this.listeners[message][i];
				if (obj != null)
				{
					MethodInfo methodInfo = obj.GetType().RTGetMethod(message, true);
					if (methodInfo != null)
					{
						object[] arg_6E_0;
						if (methodInfo.GetParameters().Length == 1)
						{
							(arg_6E_0 = new object[1])[0] = arg;
						}
						else
						{
							arg_6E_0 = null;
						}
						object[] parameters = arg_6E_0;
						if (methodInfo.ReturnType == typeof(IEnumerator))
						{
							MonoManager.current.StartCoroutine((IEnumerator)methodInfo.Invoke(obj, parameters));
						}
						else
						{
							methodInfo.Invoke(obj, parameters);
						}
					}
				}
			}
		}
	}
}
