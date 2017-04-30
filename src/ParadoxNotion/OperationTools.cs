using System;
using UnityEngine;

namespace ParadoxNotion
{
	public static class OperationTools
	{
		public static string GetOperationString(OperationMethod om)
		{
			if (om == OperationMethod.Set)
			{
				return " = ";
			}
			if (om == OperationMethod.Add)
			{
				return " += ";
			}
			if (om == OperationMethod.Subtract)
			{
				return " -= ";
			}
			if (om == OperationMethod.Multiply)
			{
				return " *= ";
			}
			if (om == OperationMethod.Divide)
			{
				return " /= ";
			}
			if (om == OperationMethod.Modulus)
			{
				return " %= ";
			}
			return string.Empty;
		}

		public static float Operate(float a, float b, OperationMethod om)
		{
			if (om == OperationMethod.Set)
			{
				return b;
			}
			if (om == OperationMethod.Add)
			{
				return a + b;
			}
			if (om == OperationMethod.Subtract)
			{
				return a - b;
			}
			if (om == OperationMethod.Multiply)
			{
				return a * b;
			}
			if (om == OperationMethod.Divide)
			{
				return a / b;
			}
			if (om == OperationMethod.Modulus)
			{
				return a % b;
			}
			return a;
		}

		public static int Operate(int a, int b, OperationMethod om)
		{
			if (om == OperationMethod.Set)
			{
				return b;
			}
			if (om == OperationMethod.Add)
			{
				return a + b;
			}
			if (om == OperationMethod.Subtract)
			{
				return a - b;
			}
			if (om == OperationMethod.Multiply)
			{
				return a * b;
			}
			if (om == OperationMethod.Divide)
			{
				return a / b;
			}
			if (om == OperationMethod.Modulus)
			{
				return a % b;
			}
			return a;
		}

		public static Vector3 Operate(Vector3 a, Vector3 b, OperationMethod om)
		{
			if (om == OperationMethod.Set)
			{
				return b;
			}
			if (om == OperationMethod.Add)
			{
				return a + b;
			}
			if (om == OperationMethod.Subtract)
			{
				return a - b;
			}
			if (om == OperationMethod.Multiply)
			{
				return Vector3.Scale(a, b);
			}
			if (om == OperationMethod.Divide)
			{
				return new Vector3(a.x / b.x, a.y / b.y, a.z / b.z);
			}
			if (om == OperationMethod.Modulus)
			{
				return new Vector3(a.x % b.x, a.y % b.y, a.z % b.z);
			}
			return a;
		}

		public static string GetCompareString(CompareMethod cm)
		{
			if (cm == CompareMethod.EqualTo)
			{
				return " == ";
			}
			if (cm == CompareMethod.GreaterThan)
			{
				return " > ";
			}
			if (cm == CompareMethod.LessThan)
			{
				return " < ";
			}
			return string.Empty;
		}

		public static bool Compare(float a, float b, CompareMethod cm, float floatingPoint)
		{
			if (cm == CompareMethod.EqualTo)
			{
				return Mathf.Abs(a - b) <= floatingPoint;
			}
			if (cm == CompareMethod.GreaterThan)
			{
				return a > b;
			}
			return cm != CompareMethod.LessThan || a < b;
		}

		public static bool Compare(int a, int b, CompareMethod cm)
		{
			if (cm == CompareMethod.EqualTo)
			{
				return a == b;
			}
			if (cm == CompareMethod.GreaterThan)
			{
				return a > b;
			}
			return cm != CompareMethod.LessThan || a < b;
		}
	}
}
