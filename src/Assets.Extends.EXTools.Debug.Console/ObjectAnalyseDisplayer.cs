using Assets.Tools.Script.Reflec;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace Assets.Extends.EXTools.Debug.Console
{
	public class ObjectAnalyseDisplayer : IObjectAnalyseDisplayer
	{
		private FullDebugConsole _debugConsole;

		private Stack<object> _objectList = new Stack<object>();

		private Stack<string> _objectNames = new Stack<string>();

		private object _currObj;

		private string _currName;

		private GUIStyle _btnGuiStyle;

		private List<IObjectDebugAnalyse> _objectAnalyses = new List<IObjectDebugAnalyse>();

		protected GUIStyle BtnGuiStyle
		{
			get
			{
				if (this._btnGuiStyle == null)
				{
					this._btnGuiStyle = new GUIStyle("button")
					{
						normal = 
						{
							textColor = Color.white
						},
						alignment = TextAnchor.MiddleLeft
					};
				}
				this._btnGuiStyle.fontSize = this.Pixel(20);
				return this._btnGuiStyle;
			}
		}

		public ObjectAnalyseDisplayer(FullDebugConsole debugConsole)
		{
			this._debugConsole = debugConsole;
		}

		public void Show()
		{
			this.OnShowObject(this._currObj, this._currName);
		}

		public void ShowNewObject(object obj, string objName)
		{
			this._objectList.Clear();
			this._objectNames.Clear();
			this.OnShowObject(obj, objName);
		}

		public void RegisterObjectAnalyse(IObjectDebugAnalyse debugAnalyse)
		{
			this._objectAnalyses.Add(debugAnalyse);
		}

		private void ShowObjectOnBack(object obj, string objName)
		{
			this.OnShowObject(obj, objName);
		}

		public void ShowObjectChild(object obj, string objName)
		{
			this._objectList.Push(this._currObj);
			this._objectNames.Push(this._currName);
			this.OnShowObject(obj, objName);
		}

		public void OnShowObject(object obj, string objName)
		{
			this.GUILayoutBtn(string.Format("==={0}===", objName));
			this._currObj = obj;
			this._currName = objName;
			for (int i = 0; i < this._objectAnalyses.Count; i++)
			{
				IObjectDebugAnalyse objectDebugAnalyse = this._objectAnalyses[i];
				if (objectDebugAnalyse.IsActiveBy(obj))
				{
					objectDebugAnalyse.Show(obj, objName, this);
					return;
				}
			}
			if (this.IsBasicType(obj))
			{
				this.ShowSimpleObject(obj, objName);
			}
			else if (obj is IEnumerable)
			{
				this.ShowEnumerableObject(obj, objName);
			}
			else if (obj is SimpleMethodReflect)
			{
				this.ShowMethodObject(obj as SimpleMethodReflect, objName);
			}
			else if (obj is GameObject)
			{
				this.ShowGameObject(obj as GameObject, objName);
			}
			else
			{
				this.ShowClassObject(obj, objName);
			}
		}

		private void ShowGameObject(GameObject obj, string objName)
		{
			this.GUILayoutBtn("---Components---");
			Component[] components = obj.GetComponents<Component>();
			for (int i = 0; i < components.Length; i++)
			{
				Component component = components[i];
				this.ShowClassTypeProperty(component, objName, component.GetType().Name);
			}
			this.GUILayoutBtn("---object---");
			this.ShowClassObject(obj, objName);
		}

		private void ShowEnumerableObject(object obj, string objName)
		{
			this.GUILayoutBtn("---IEnumerable---");
			if (obj is List<NameableObject>)
			{
				List<NameableObject> list = obj as List<NameableObject>;
				foreach (NameableObject current in list)
				{
					this.ShowProperty(current.Value, objName, current.Name);
				}
			}
			else if (obj is IDictionary)
			{
				IDictionary dictionary = obj as IDictionary;
				foreach (object current2 in dictionary.Keys)
				{
					object obj2 = dictionary[current2];
					if (current2 != null)
					{
						this.ShowProperty(current2, objName, "key");
					}
					else
					{
						this.ShowProperty("null", objName, "key");
					}
					if (obj2 != null)
					{
						this.ShowProperty(obj2, objName, "value");
					}
					else
					{
						this.ShowProperty("null", objName, "value");
					}
				}
			}
			else
			{
				IEnumerable enumerable = obj as IEnumerable;
				foreach (object current3 in enumerable)
				{
					if (current3 != null)
					{
						this.ShowProperty(current3, objName, "element");
					}
					else
					{
						this.ShowProperty("null", objName, "element");
					}
				}
			}
			this.GUILayoutBtn("---object---");
			this.ShowClassObject(obj, objName);
		}

		private void ShowSimpleObject(object obj, string objName)
		{
			this.ShowBasicTypeProperty(obj, objName, objName);
		}

		private void ShowClassObject(object obj, string objName)
		{
			try
			{
				Type type = obj.GetType();
				PropertyInfo[] properties = type.GetProperties();
				for (int i = 0; i < properties.Length; i++)
				{
					PropertyInfo propertyInfo = properties[i];
					try
					{
						this.ShowProperty(propertyInfo.GetValue(obj, null), objName, propertyInfo.Name);
					}
					catch (Exception)
					{
					}
				}
				FieldInfo[] fields = type.GetFields();
				for (int j = 0; j < fields.Length; j++)
				{
					FieldInfo fieldInfo = fields[j];
					try
					{
						this.ShowProperty(fieldInfo.GetValue(obj), objName, fieldInfo.Name);
					}
					catch (Exception)
					{
					}
				}
				MethodInfo[] methods = type.GetMethods();
				MethodInfo[] array = methods;
				for (int k = 0; k < array.Length; k++)
				{
					MethodInfo methodInfo = array[k];
					try
					{
						this.ShowMethodProperty(obj, objName, methodInfo);
					}
					catch (Exception)
					{
					}
				}
			}
			catch (Exception var_11_D5)
			{
				this.GUILayoutBtn("Exception,at show class");
			}
		}

		private void ShowMethodObject(SimpleMethodReflect debugMethodReflect, string objName)
		{
			for (int i = 0; i < debugMethodReflect.parameters.Count; i++)
			{
				debugMethodReflect.parameters[i] = this._debugConsole.GUILayoutTextField(debugMethodReflect.parameters[i]);
			}
			if (this.GUILayoutBtn("Call " + debugMethodReflect.method.Name))
			{
				object obj = debugMethodReflect.Call();
				this.ShowObjectChild(obj, objName + " return");
			}
		}

		public void ShowMethodProperty(object v, string objName, MethodInfo methodInfo)
		{
			try
			{
				if (!methodInfo.Name.StartsWith("get_") && SimpleMethodReflect.IsSimpleMethod(methodInfo, v) && this.GUILayoutBtn("Method --> " + methodInfo.Name))
				{
					this.ShowObjectChild(new SimpleMethodReflect(methodInfo, v), string.Format("{0}.{1}", objName, methodInfo.Name));
				}
			}
			catch (Exception)
			{
				this.GUILayoutBtn("Exception,at show method");
			}
		}

		public void ShowProperty(object v, string objName, string propertyName)
		{
			try
			{
				if (this.IsBasicType(v))
				{
					this.ShowBasicTypeProperty(v, objName, propertyName);
				}
				else if (v is Transform)
				{
					this.ShowTransformTypeProperty(v as Transform, objName, propertyName);
				}
				else
				{
					this.ShowClassTypeProperty(v, objName, propertyName);
				}
			}
			catch
			{
				this.GUILayoutBtn("Exception,at show property");
			}
		}

		private void ShowClassTypeProperty(object v, string objName, string propertyName)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("{0}  {1}", v.GetType().Name, propertyName);
			if (this.GUILayoutBtn(stringBuilder.ToString()))
			{
				this.ShowObjectChild(v, string.Format("{0}.{1}", objName, propertyName));
			}
		}

		private void ShowBasicTypeProperty(object v, object objName, string propertyName)
		{
			try
			{
				StringBuilder stringBuilder = new StringBuilder();
				if (v == null)
				{
					stringBuilder.AppendFormat("{0}  {1}", propertyName, "null");
				}
				else if (v is Type)
				{
					stringBuilder.AppendFormat("{0}  {1}  {2}", "Type", propertyName, v);
				}
				else
				{
					Type type = v.GetType();
					if (type.IsEnum)
					{
						stringBuilder.AppendFormat("{0}  {1}  {2}  {3}", new object[]
						{
							"Enum",
							type.Name,
							propertyName,
							v
						});
					}
					else if (type.IsValueType || type == typeof(string))
					{
						stringBuilder.AppendFormat("{0}  {1}  {2}", type.Name, propertyName, v);
					}
					else
					{
						stringBuilder.AppendFormat("{0}  {1}  {2}", type.Name, propertyName, v);
					}
				}
				this.GUILayoutBtn(stringBuilder.ToString());
			}
			catch
			{
				this.GUILayoutBtn("Exception,at show property");
			}
		}

		private void ShowTransformTypeProperty(Transform v, string objName, string propertyName)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("{0}  {1}  {2}  {3}", new object[]
			{
				"Transform",
				propertyName,
				v.gameObject.name,
				(!v.gameObject.activeSelf) ? "activeFalse" : "activeTrue"
			});
			if (this.GUILayoutBtn(stringBuilder.ToString()))
			{
				this.ShowObjectChild(v, objName + "." + propertyName);
			}
		}

		public bool IsBasicType(object v)
		{
			if (v == null)
			{
				return true;
			}
			Type type = v.GetType();
			return (type.IsValueType && !(v is Vector3) && !(v is Vector2) && !(v is Vector4) && !(v is Quaternion)) || type.IsEnum || v is string || v is Type;
		}

		public bool GUILayoutBtn(string str)
		{
			return GUILayout.Button(str, this.BtnGuiStyle, new GUILayoutOption[]
			{
				GUILayout.Height((float)this.Pixel(30))
			});
		}

		public bool Back()
		{
			if (this._objectList.Count == 0)
			{
				return true;
			}
			this.ShowObjectOnBack(this._objectList.Pop(), this._objectNames.Pop());
			return false;
		}

		public int Pixel(int value)
		{
			return this._debugConsole.GetPixelValue(value);
		}
	}
}
