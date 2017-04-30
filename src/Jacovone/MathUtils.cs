using System;
using UnityEngine;

namespace Jacovone
{
	public class MathUtils
	{
		public static Quaternion QuaternionBezier(Quaternion p, Quaternion prevP, Quaternion nextP, Quaternion nextNextP, float stepPos)
		{
			Quaternion quaternion = MathUtils.QuaternionNormalize(Quaternion.Slerp(Quaternion.Slerp(prevP, p, 2f), nextP, 0.5f));
			Quaternion a = MathUtils.QuaternionNormalize(Quaternion.Slerp(Quaternion.Slerp(p, nextP, 2f), nextNextP, 0.5f));
			Quaternion quaternion2 = MathUtils.QuaternionNormalize(Quaternion.Slerp(a, nextP, 2f));
			Quaternion quaternion3 = Quaternion.Slerp(p, quaternion, stepPos);
			Quaternion a2 = Quaternion.Slerp(quaternion, quaternion2, stepPos);
			Quaternion b = Quaternion.Slerp(quaternion2, nextP, stepPos);
			Quaternion a3 = Quaternion.Slerp(quaternion3, quaternion3, stepPos);
			Quaternion b2 = Quaternion.Slerp(a2, b, stepPos);
			return Quaternion.Slerp(a3, b2, stepPos);
		}

		public static Quaternion QuaternionNormalize(Quaternion q)
		{
			float num = Mathf.Sqrt(q.x * q.x + q.y * q.y + q.z * q.z + q.w * q.w);
			if (num > 0f)
			{
				q.x /= num;
				q.y /= num;
				q.z /= num;
				q.w /= num;
			}
			else
			{
				q.x = 0f;
				q.y = 0f;
				q.z = 0f;
				q.w = 1f;
			}
			return q;
		}

		public static Vector3 Vector3Bezier(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
		{
			float num = t * t;
			float d = t * num;
			float num2 = 1f - t;
			float num3 = num2 * num2;
			float d2 = num2 * num3;
			Vector3 a = default(Vector3);
			a = d2 * p0;
			a += 3f * num3 * t * p1;
			a += 3f * num2 * num * p2;
			return a + d * p3;
		}

		public static float FloatBezier(float p0, float p1, float p2, float p3, float t)
		{
			float num = t * t;
			float num2 = t * num;
			float num3 = 1f - t;
			float num4 = num3 * num3;
			float num5 = num3 * num4;
			float num6 = num5 * p0;
			num6 += 3f * num4 * t * p1;
			num6 += 3f * num3 * num * p2;
			return num6 + num2 * p3;
		}
	}
}
