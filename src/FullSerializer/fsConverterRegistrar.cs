using FullSerializer.Internal;
using FullSerializer.Internal.DirectConverters;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace FullSerializer
{
	public class fsConverterRegistrar
	{
		public static AnimationCurve_DirectConverter Register_AnimationCurve_DirectConverter;

		public static Bounds_DirectConverter Register_Bounds_DirectConverter;

		public static GUIStyleState_DirectConverter Register_GUIStyleState_DirectConverter;

		public static GUIStyle_DirectConverter Register_GUIStyle_DirectConverter;

		public static Gradient_DirectConverter Register_Gradient_DirectConverter;

		public static Keyframe_DirectConverter Register_Keyframe_DirectConverter;

		public static LayerMask_DirectConverter Register_LayerMask_DirectConverter;

		public static RectOffset_DirectConverter Register_RectOffset_DirectConverter;

		public static Rect_DirectConverter Register_Rect_DirectConverter;

		public static List<Type> Converters;

		static fsConverterRegistrar()
		{
			fsConverterRegistrar.Converters = new List<Type>();
			FieldInfo[] declaredFields = typeof(fsConverterRegistrar).GetDeclaredFields();
			for (int i = 0; i < declaredFields.Length; i++)
			{
				FieldInfo fieldInfo = declaredFields[i];
				if (fieldInfo.Name.StartsWith("Register_"))
				{
					fsConverterRegistrar.Converters.Add(fieldInfo.FieldType);
				}
			}
			MethodInfo[] declaredMethods = typeof(fsConverterRegistrar).GetDeclaredMethods();
			for (int j = 0; j < declaredMethods.Length; j++)
			{
				MethodInfo methodInfo = declaredMethods[j];
				if (methodInfo.Name.StartsWith("Register_"))
				{
					methodInfo.Invoke(null, null);
				}
			}
		}
	}
}
