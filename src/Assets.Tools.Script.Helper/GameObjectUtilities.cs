using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Tools.Script.Helper
{
	public static class GameObjectUtilities
	{
		public static Bounds GetBoundsWithChildren(this GameObject obj)
		{
			Renderer[] componentsInChildren = obj.GetComponentsInChildren<Renderer>();
			if (componentsInChildren.Length == 0)
			{
				throw new Exception("no child in this gameobject");
			}
			Vector3 min = componentsInChildren[0].bounds.min;
			Vector3 max = componentsInChildren[0].bounds.max;
			for (int i = 1; i < componentsInChildren.Length; i++)
			{
				Renderer renderer = componentsInChildren[i];
				if (renderer.bounds.min.x < min.x)
				{
					min.x = renderer.bounds.min.x;
				}
				if (renderer.bounds.min.y < min.y)
				{
					min.y = renderer.bounds.min.y;
				}
				if (renderer.bounds.min.z < min.z)
				{
					min.z = renderer.bounds.min.z;
				}
				if (renderer.bounds.max.x > max.x)
				{
					max.x = renderer.bounds.max.x;
				}
				if (renderer.bounds.max.y > max.y)
				{
					max.y = renderer.bounds.max.y;
				}
				if (renderer.bounds.max.z > max.z)
				{
					max.z = renderer.bounds.max.z;
				}
			}
			Bounds result = new Bounds((min + max) / 2f, new Vector3(Math.Abs(min.x - max.x), Math.Abs(min.y - max.y), Math.Abs(min.z - max.z)));
			return result;
		}

		public static bool IsActive(this GameObject obj)
		{
			return obj && obj.activeInHierarchy;
		}

		public static GameObject Parent(this GameObject obj)
		{
			if (obj == null || obj.transform.parent == null)
			{
				return null;
			}
			return obj.transform.parent.gameObject;
		}

		public static void ClearChildrenImmediate(this GameObject parent)
		{
			List<GameObject> list = new List<GameObject>();
			foreach (Transform transform in parent.transform)
			{
				list.Add(transform.gameObject);
			}
			foreach (GameObject current in list)
			{
				UnityEngine.Object.DestroyImmediate(current);
			}
		}

		public static void ClearChildren(this GameObject parent)
		{
			List<GameObject> list = new List<GameObject>();
			foreach (Transform transform in parent.transform)
			{
				list.Add(transform.gameObject);
			}
			foreach (GameObject current in list)
			{
				UnityEngine.Object.Destroy(current);
			}
		}

		public static GameObject AddEmptyGameObject(this GameObject parent)
		{
			return new GameObject
			{
				transform = 
				{
					parent = parent.transform,
					localPosition = Vector3.zero,
					localScale = Vector3.one,
					localRotation = Quaternion.identity
				},
				layer = parent.layer
			};
		}

		public static GameObject AddInstantiate(this GameObject parent, GameObject src)
		{
			return parent.AddInstantiate(src, Vector3.zero, Vector3.one, Quaternion.identity, true);
		}

		public static GameObject AddInstantiate(this GameObject parent, GameObject src, Vector3 position, Vector3 scale, Quaternion quaternion, bool withParentLayer = true)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(src);
			gameObject.transform.parent = parent.transform;
			gameObject.transform.localPosition = position;
			gameObject.transform.localScale = scale;
			gameObject.transform.localRotation = quaternion;
			if (withParentLayer)
			{
				gameObject.SetLayerWidthChildren(parent.layer);
			}
			return gameObject;
		}

		public static List<GameObject> GetChildren(this GameObject parent)
		{
			List<GameObject> list = new List<GameObject>();
			foreach (Transform transform in parent.transform)
			{
				list.Add(transform.gameObject);
			}
			return list;
		}

		public static GameObject GetChildByName(this GameObject parent, string name)
		{
			foreach (Transform transform in parent.transform)
			{
				if (transform.gameObject.name == name)
				{
					return transform.gameObject;
				}
			}
			return null;
		}

		public static GameObject GetParentByName(this GameObject child, string name)
		{
			if (child.name == name)
			{
				return child;
			}
			if (child.transform.parent != null)
			{
				return child.transform.parent.gameObject.GetParentByName(name);
			}
			return null;
		}

		public static bool IsChildBy(this GameObject child, GameObject parent)
		{
			Transform[] componentsInChildren = parent.GetComponentsInChildren<Transform>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				Transform transform = componentsInChildren[i];
				if (transform.gameObject == child)
				{
					return true;
				}
			}
			return false;
		}

		public static Transform GetChildByNameRecursion(this Transform parent, string name)
		{
			Transform transform = parent.transform.FindChild(name);
			if (transform == null)
			{
				for (int i = 0; i < parent.transform.childCount; i++)
				{
					transform = parent.transform.GetChild(i).GetChildByNameRecursion(name);
					if (transform != null)
					{
						return transform;
					}
				}
				return null;
			}
			return transform;
		}

		public static void SetLayerWidthChildren(this GameObject parent, int layer)
		{
			parent.layer = layer;
			foreach (Transform transform in parent.transform)
			{
				transform.gameObject.SetLayerWidthChildren(layer);
			}
		}

		public static void SetLayerToCameraCullingMask(this GameObject obj, Camera camera)
		{
			if (camera.cullingMask == 0)
			{
				return;
			}
			int num = 1 << obj.layer;
			int cullingMask = camera.cullingMask;
			if ((num & cullingMask) == 0)
			{
				for (int i = 0; i < 100; i++)
				{
					if ((1 << i & cullingMask) != 0)
					{
						obj.SetLayerWidthChildren(i);
						break;
					}
				}
			}
		}

		public static void ForEachAllChildren(this Transform obj, Func<Transform, bool> doFunc)
		{
			obj.TraverseTransform(doFunc);
		}

		private static bool TraverseTransform(this Transform obj, Func<Transform, bool> doFunc)
		{
			if (!doFunc(obj))
			{
				return false;
			}
			for (int i = 0; i < obj.childCount; i++)
			{
				Transform child = obj.GetChild(i);
				if (!child.TraverseTransform(doFunc))
				{
					return false;
				}
			}
			return true;
		}

		public static void NormalizationGameObject(GameObject obj)
		{
			obj.transform.localPosition = Vector3.zero;
			obj.transform.localScale = Vector3.one;
		}

		public static void NormalizationTransform(Transform transform)
		{
			transform.localPosition = Vector3.zero;
			transform.localScale = Vector3.one;
		}

		public static void SetTransformParentAndNormalization(Transform transform, Transform parent)
		{
			transform.parent = parent;
			transform.localPosition = Vector3.zero;
			transform.localScale = Vector3.one;
		}

		public static void SetGameObjectParentAndNormalization(GameObject obj, Transform parent)
		{
			obj.transform.parent = parent;
			obj.transform.localPosition = Vector3.zero;
			obj.transform.localScale = Vector3.one;
		}

		public static void SetTransformProperty(Transform transform, string name, Transform parent, float localPositionX, float localPositionY, float localPositionZ, float localScaleX, float localScaleY, float localScaleZ)
		{
			transform.name = name;
			transform.parent = parent;
			transform.localPosition = new Vector3(localPositionX, localPositionY, localPositionZ);
			transform.localScale = new Vector3(localScaleX, localScaleY, localScaleZ);
		}
	}
}
