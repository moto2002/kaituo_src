using System;
using UnityEngine;

namespace Assets.Tools.Script.Helper
{
	public static class UnityValueHelper
	{
		public static Quaternion GetQuaternion(float x, float y, float z)
		{
			return new Quaternion
			{
				eulerAngles = new Vector3(x, y, z)
			};
		}

		public static void SetRotationX(this Transform transform, float x)
		{
			Vector3 eulerAngles = transform.rotation.eulerAngles;
			transform.rotation = UnityValueHelper.GetQuaternion(x, eulerAngles.y, eulerAngles.z);
		}

		public static void SetRotationY(this Transform transform, float y)
		{
			Vector3 eulerAngles = transform.rotation.eulerAngles;
			transform.rotation = UnityValueHelper.GetQuaternion(eulerAngles.x, y, eulerAngles.z);
		}

		public static void SetRotationZ(this Transform transform, float z)
		{
			Vector3 eulerAngles = transform.rotation.eulerAngles;
			transform.rotation = UnityValueHelper.GetQuaternion(eulerAngles.x, eulerAngles.y, z);
		}

		public static void SetRotation(this Transform transform, float x, float y, float z)
		{
			transform.rotation = UnityValueHelper.GetQuaternion(x, y, z);
		}

		public static void SetLocalPositionX(this Transform transform, float x)
		{
			Vector3 localPosition = new Vector3(x, transform.localPosition.y, transform.localPosition.z);
			transform.localPosition = localPosition;
		}

		public static void SetLocalPositionY(this Transform transform, float y)
		{
			Vector3 localPosition = new Vector3(transform.localPosition.x, y, transform.localPosition.z);
			transform.localPosition = localPosition;
		}

		public static void SetLocalPositionZ(this Transform transform, float z)
		{
			Vector3 localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, z);
			transform.localPosition = localPosition;
		}

		public static void SetPositionX(this Transform transform, float x)
		{
			transform.position = new Vector3(x, transform.position.y, transform.position.z);
		}

		public static void SetPositionY(this Transform transform, float y)
		{
			transform.position = new Vector3(transform.position.x, y, transform.position.z);
		}

		public static void SetPositionZ(this Transform transform, float z)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y, z);
		}

		public static Vector3 GetLookToAngle(this Transform transform, Transform lookTo)
		{
			Quaternion localRotation = transform.localRotation;
			transform.LookAt(lookTo);
			Quaternion localRotation2 = transform.localRotation;
			transform.localRotation = localRotation;
			return localRotation2.eulerAngles;
		}

		public static Vector3 GetLookToAngle(this Transform transform, Vector3 lookTo)
		{
			Quaternion localRotation = transform.localRotation;
			transform.LookAt(lookTo);
			Quaternion localRotation2 = transform.localRotation;
			transform.localRotation = localRotation;
			return localRotation2.eulerAngles;
		}

		public static Color GetModifyAlpha(this Color color, float a)
		{
			return new Color(color.r, color.g, color.b, a);
		}

		public static Vector3 IntoN180To180(this Vector3 v, bool n180 = true, bool p180 = true)
		{
			v.x %= 360f;
			if (v.x < -180f || (!n180 && v.x == -180f))
			{
				v.x += 360f;
			}
			else if (v.x > 180f || (!p180 && v.x == 180f))
			{
				v.x -= 360f;
			}
			v.y %= 360f;
			if (v.y < -180f || (!n180 && v.y == -180f))
			{
				v.y += 360f;
			}
			else if (v.y > 180f || (!p180 && v.y == 180f))
			{
				v.y -= 360f;
			}
			v.z %= 360f;
			if (v.z < -180f || (!n180 && v.z == -180f))
			{
				v.z += 360f;
			}
			else if (v.z > 180f || (!p180 && v.z == 180f))
			{
				v.z -= 360f;
			}
			return v;
		}

		public static Vector3 IntoN180To180(this Vector3 v, Vector3 reference)
		{
			int num = ((reference.x >= 0f) ? 0 : 1) + ((reference.y >= 0f) ? 0 : 1) + ((reference.z >= 0f) ? 0 : 1);
			int num2 = ((reference.x <= 0f) ? 0 : 1) + ((reference.y <= 0f) ? 0 : 1) + ((reference.z <= 0f) ? 0 : 1);
			return v.IntoN180To180(num > num2, num2 > num);
		}
	}
}
