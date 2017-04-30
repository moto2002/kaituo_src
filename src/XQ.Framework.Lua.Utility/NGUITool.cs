using Assets.Extends.EXNGUI.Compoment;
using Assets.Scripts.Tools.NGUI.Component;
using System;
using UnityEngine;
using XQ.Framework.Utility.Debug;

namespace XQ.Framework.Lua.Utility
{
	public static class NGUITool
	{
		public static void StopAllTweener()
		{
			UITweener.StopAllTweeners();
		}

		public static void LockPanelRoll(UIPanel panel, GameObject anchor)
		{
			UIPanelRollLock.Lock(panel, anchor);
		}

		public static void UnlockPanelRoll(UIPanel panel)
		{
			UIPanelRollLock.Unlock(panel);
		}

		public static void ClearTweenerEvent(GameObject obj)
		{
			UITweener[] componentsInChildren = obj.GetComponentsInChildren<UITweener>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				UITweener uITweener = componentsInChildren[i];
				uITweener.onFinished.Clear();
			}
		}

		public static void StopAndClearTweenerEvent(GameObject obj)
		{
			UITweener[] componentsInChildren = obj.GetComponentsInChildren<UITweener>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				UITweener uITweener = componentsInChildren[i];
				uITweener.enabled = false;
				uITweener.onFinished.Clear();
			}
		}

		public static void CancelSpringPosition(GameObject obj)
		{
			SpringPosition component = obj.GetComponent<SpringPosition>();
			UnityEngine.Object.Destroy(component);
		}

		public static void ChangAllChildColor(Transform tf, Color color)
		{
			UIWidget[] componentsInChildren = tf.GetComponentsInChildren<UIWidget>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].color = color;
			}
		}

		public static void SetColliderEnable(BoxCollider collider, bool enabled)
		{
			collider.enabled = enabled;
		}

		public static void SetColliderEnable(GameObject colliderObj, bool enabled)
		{
			BoxCollider component = colliderObj.GetComponent<BoxCollider>();
			if (component != null)
			{
				component.enabled = enabled;
			}
		}

		public static GameObject GetCurrTouchObject()
		{
			try
			{
				return NGUITool.RaycastCurrTouchObject();
			}
			catch (Exception debug)
			{
				UDebug.Debug(debug);
			}
			return null;
		}

		public static GameObject GetCurrOffsetTouchObject(Vector2 offset)
		{
			UICamera.MouseOrTouch mouseOrTouch = UICamera.GetTouch(152324584, true);
			mouseOrTouch.pos = new Vector2(Input.mousePosition.x + offset.x, Input.mousePosition.y + offset.y);
			UICamera.Raycast(mouseOrTouch);
			return mouseOrTouch.current;
		}

		public static GameObject RaycastCurrTouchObject()
		{
			UICamera.MouseOrTouch mouseOrTouch = UICamera.GetTouch(152324583, true);
			mouseOrTouch.pos = Input.mousePosition;
			UICamera.Raycast(mouseOrTouch);
			return mouseOrTouch.current;
		}

		public static UICamera GetTopUICamera()
		{
			float num = -3.40282347E+38f;
			UICamera result = null;
			foreach (UICamera current in UICamera.list)
			{
				if (current.cachedCamera.depth > num)
				{
					result = current;
					num = current.cachedCamera.depth;
				}
			}
			return result;
		}

		public static UIRoot GetTopUIRoot()
		{
			float num = -3.40282347E+38f;
			UICamera uICamera = null;
			foreach (UICamera current in UICamera.list)
			{
				int layer = current.gameObject.layer;
				if (current.cachedCamera.depth > num && (layer == 8 || layer == 25 || layer == 5 || layer == 12) && current.gameObject.activeInHierarchy)
				{
					uICamera = current;
					num = current.cachedCamera.depth;
				}
			}
			if (uICamera != null)
			{
				return uICamera.GetComponentInParent<UIRoot>();
			}
			return null;
		}

		public static AnimationCurve GetTweenerCurve(GameObject from)
		{
			UITweener component = from.GetComponent<UITweener>();
			if (component != null)
			{
				return component.animationCurve;
			}
			return null;
		}

		public static void CopyTweener(GameObject from, GameObject to)
		{
			UITweener[] components = from.GetComponents<UITweener>();
			UITweener[] array = components;
			for (int i = 0; i < array.Length; i++)
			{
				UITweener uITweener = array[i];
				UITweener to2 = to.AddComponent(uITweener.GetType()) as UITweener;
				uITweener.CopyTo(to2);
			}
		}

		public static void PlayTweenerGroup(GameObject obj, int group)
		{
			UIPlayTweenGroup uIPlayTweenGroup = obj.GetComponent<UIPlayTweenGroup>();
			if (uIPlayTweenGroup == null)
			{
				uIPlayTweenGroup = obj.AddComponent<UIPlayTweenGroup>();
			}
			uIPlayTweenGroup.RefreshTweener();
			uIPlayTweenGroup.Play(group);
		}

		public static void PlayObjectTweenerGroup(GameObject from, GameObject to, int group, Action onEnd)
		{
			UIPlayTweenGroup uIPlayTweenGroup = to.GetComponent<UIPlayTweenGroup>();
			if (uIPlayTweenGroup == null)
			{
				uIPlayTweenGroup = to.AddComponent<UIPlayTweenGroup>();
			}
			uIPlayTweenGroup.RefreshTweener();
			if (!uIPlayTweenGroup.HasGroup(group))
			{
				NGUITool.CopyTweener(from, to);
				uIPlayTweenGroup.RefreshTweener();
			}
			uIPlayTweenGroup.PlayWithEnd(group, onEnd);
		}

		public static void SetTextureUV(UITexture texture, float x, float y, float w, float h)
		{
			texture.uvRect = new Rect(x, y, w, h);
		}

		public static RaycastHit CameraRaycastHit(Camera _camera, Vector3 _targetPos)
		{
			RaycastHit result;
			Physics.Raycast(_camera.ScreenPointToRay(_targetPos), out result);
			return result;
		}
	}
}
