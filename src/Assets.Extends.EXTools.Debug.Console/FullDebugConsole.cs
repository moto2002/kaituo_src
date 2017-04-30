using Assets.Script.Mvc.Pool;
using Assets.Tools.Script.Debug.Console;
using Assets.Tools.Script.Debug.Log;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using UnityEngine;
using XQ.Framework.Utility.Debug;

namespace Assets.Extends.EXTools.Debug.Console
{
	public class FullDebugConsole : MonoBehaviour, IDebugConsole
	{
		public int DefaultHeight = 1080;

		public int ConsoleWidth = 600;

		public int ConsoleHeight = 600;

		public IObjectAnalyseDisplayer AnalyseDisplayer;

		[HideInInspector]
		public int CurrViewChannel;

		public readonly Dictionary<int, string> ActiveChannels;

		public readonly Dictionary<string, Action> EventBtns = new Dictionary<string, Action>();

		public readonly Dictionary<string, string> TopStrings = new Dictionary<string, string>();

		public readonly List<NameableObject> ObjectList = new List<NameableObject>();

		public readonly Pool<NameableObject> NameableObjectPool = new Pool<NameableObject>();

		private bool _viewEnabled;

		protected int ViewMode = 1;

		private Vector2 ScrollPosition;

		private GUIStyle _textFieldGuiStyle;

		private GUIStyle _btnGuiStyle;

		private GUIStyle _hSliderGuiStyle;

		private GUIStyle _vSliderGuiStyle;

		private Rect dragWindowRect;

		protected bool ViewEnabled
		{
			get
			{
				return this._viewEnabled;
			}
			set
			{
				if (this._viewEnabled != value)
				{
					this._viewEnabled = value;
					this.OnEnabledChange(this._viewEnabled);
				}
			}
		}

		protected GUIStyle TextFieldGuiStyle
		{
			get
			{
				if (this._textFieldGuiStyle == null)
				{
					this._textFieldGuiStyle = new GUIStyle("textfield");
					this._textFieldGuiStyle.normal.textColor = Color.white;
				}
				this._textFieldGuiStyle.fontSize = this.GetPixelValue(20);
				return this._textFieldGuiStyle;
			}
		}

		protected GUIStyle BtnGuiStyle
		{
			get
			{
				if (this._btnGuiStyle == null)
				{
					this._btnGuiStyle = new GUIStyle("button");
					this._btnGuiStyle.normal.textColor = Color.white;
				}
				this._btnGuiStyle.fontSize = this.GetPixelValue(20);
				return this._btnGuiStyle;
			}
		}

		protected GUIStyle HSliderGuiStyle
		{
			get
			{
				if (this._hSliderGuiStyle == null)
				{
					this._hSliderGuiStyle = new GUIStyle("horizontalscrollbar");
				}
				this._hSliderGuiStyle.fixedHeight = (float)this.GetPixelValue(48);
				return this._hSliderGuiStyle;
			}
		}

		protected GUIStyle VSliderGuiStyle
		{
			get
			{
				if (this._vSliderGuiStyle == null)
				{
					this._vSliderGuiStyle = new GUIStyle("verticalscrollbar");
				}
				this._vSliderGuiStyle.fixedWidth = (float)this.GetPixelValue(48);
				return this._vSliderGuiStyle;
			}
		}

		public FullDebugConsole()
		{
			this.ActiveChannels = new Dictionary<int, string>
			{
				{
					0,
					string.Empty
				}
			};
			this.CurrViewChannel = 0;
			this.AnalyseDisplayer = new ObjectAnalyseDisplayer(this);
		}

		protected virtual void Awake()
		{
			DebugConsole.consoleImpl = this;
			this.dragWindowRect = new Rect(0f, 0f, (float)this.GetPixelValue(this.ConsoleWidth), (float)this.GetPixelValue(this.ConsoleHeight));
		}

		protected virtual void OnEnabledChange(bool enable)
		{
		}

		public virtual void AddTopString(string stringName, string content)
		{
			if (this.TopStrings.ContainsKey(stringName))
			{
				this.TopStrings[stringName] = content;
			}
			else
			{
				this.TopStrings.Add(stringName, content);
			}
		}

		public virtual void RemoveTopString(string stringName)
		{
			if (this.TopStrings.ContainsKey(stringName))
			{
				this.TopStrings.Remove(stringName);
			}
		}

		public virtual void SetConsoleActive(bool consoleActive)
		{
			this.ViewEnabled = consoleActive;
		}

		public virtual void Clear(int level)
		{
			if (level == 1)
			{
				this.ClearTextLogs();
			}
			else if (level == 2)
			{
				this.ClearObjectLogs();
			}
			else if (level == 3)
			{
				this.ClearEventButton();
			}
			else
			{
				this.ClearTextLogs();
				this.ClearObjectLogs();
				this.ClearEventButton();
				this.ViewMode = 1;
			}
		}

		public string GetText()
		{
			return this.ActiveChannels[this.CurrViewChannel];
		}

		public virtual void AddButton(string btnName, Action todo)
		{
			if (this.EventBtns.ContainsKey(btnName))
			{
				return;
			}
			this.EventBtns.Add(btnName, todo);
		}

		public virtual void RemoveButton(string btnName)
		{
			if (this.EventBtns.ContainsKey(btnName))
			{
				this.EventBtns.Remove(btnName);
			}
		}

		public virtual void LogStackTrace()
		{
			string msg = new StackTrace().ToString();
			this.Log(msg);
		}

		public virtual void Log(string msg)
		{
			this.LogToChannel(0, msg);
		}

		public virtual void Log(params object[] msgs)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Capacity = msgs.Length * 8;
			for (int i = 0; i < msgs.Length; i++)
			{
				object obj = msgs[i];
				if (obj == null)
				{
					stringBuilder.Append("NullObject");
				}
				else
				{
					if (obj is Exception)
					{
						LogFile.TxtFile(obj.ToString(), string.Format("error/{0}_error", DateTime.Now.ToString("yy-MM-dd")));
					}
					stringBuilder.Append(obj);
					stringBuilder.Append(" ");
					this.CheckObjectAndAddToList(obj, (i <= 0) ? null : (msgs[i - 1] as string));
				}
			}
			this.Log(stringBuilder.ToString());
		}

		public virtual void LogToChannel(int channel, string msg)
		{
			if (!this.ActiveChannels.ContainsKey(channel))
			{
				this.AddActiveChannel(channel);
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(this.ActiveChannels[channel]).Append(msg).Append("\r\n");
			this.ActiveChannels[channel] = stringBuilder.ToString();
			UDebug.Debug(msg, new object[0]);
		}

		public virtual void LogToChannel(int channel, params object[] msgs)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Capacity = msgs.Length * 8;
			for (int i = 0; i < msgs.Length; i++)
			{
				object obj = msgs[i];
				if (obj == null)
				{
					stringBuilder.Append("NullObject");
				}
				else
				{
					if (obj is Exception)
					{
						LogFile.TxtFile(obj.ToString(), string.Format("error/{0}_error", DateTime.Now.ToString("yy-MM-dd")));
					}
					stringBuilder.Append(obj);
					stringBuilder.Append(" ");
					this.CheckObjectAndAddToList(obj, (i <= 0) ? null : (msgs[i - 1] as string));
				}
			}
			this.LogToChannel(channel, stringBuilder.ToString());
		}

		protected void AddActiveChannel(int channel)
		{
			if (!this.ActiveChannels.ContainsKey(channel))
			{
				this.ActiveChannels.Add(channel, string.Empty);
			}
		}

		public virtual void RemoveActiveChannel(int channel)
		{
			if (this.ActiveChannels.ContainsKey(channel))
			{
				this.ActiveChannels.Remove(channel);
			}
		}

		protected virtual void OnDestroy()
		{
			this.AnalyseDisplayer = null;
			this.ActiveChannels.Clear();
			this.EventBtns.Clear();
			this.TopStrings.Clear();
			this.ObjectList.Clear();
			this.NameableObjectPool.Clear();
		}

		protected virtual void Update()
		{
			if (Input.GetMouseButtonDown(2))
			{
				this.ViewEnabled = !this.ViewEnabled;
			}
		}

		protected virtual void OnGUI()
		{
			if (this.ViewEnabled)
			{
				this.dragWindowRect = GUILayout.Window(0, this.dragWindowRect, delegate(int id)
				{
					this.Window();
					GUI.DragWindow();
				}, "DebugConsole", new GUILayoutOption[0]);
			}
		}

		protected virtual void Window()
		{
			GUI.skin.label.richText = true;
			GUI.skin.button.richText = true;
			GUI.skin.box.richText = true;
			GUI.skin.textArea.richText = true;
			GUI.skin.textField.richText = true;
			GUI.skin.toggle.richText = true;
			GUI.skin.window.richText = true;
			GUILayout.BeginHorizontal(new GUILayoutOption[]
			{
				GUILayout.Width((float)this.GetPixelValue(this.ConsoleWidth))
			});
			foreach (string current in this.TopStrings.Values)
			{
				if (this.GUILayoutBtn(current))
				{
				}
			}
			GUILayout.EndHorizontal();
			GUILayout.BeginVertical(new GUILayoutOption[0]);
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			this.ShowInternalButton();
			GUILayout.EndHorizontal();
			GUILayout.BeginVertical(new GUILayoutOption[0]);
			string[] array = this.EventBtns.Keys.ToArray<string>();
			bool flag = false;
			for (int i = 0; i < array.Length; i++)
			{
				if (i % 4 == 0)
				{
					if (flag)
					{
						GUILayout.EndHorizontal();
					}
					GUILayout.BeginHorizontal(new GUILayoutOption[0]);
					flag = true;
				}
				string text = array[i];
				if (this.GUILayoutBtn(text) && this.EventBtns.ContainsKey(text))
				{
					this.EventBtns[text]();
				}
			}
			if (flag)
			{
				GUILayout.EndHorizontal();
			}
			GUILayout.EndVertical();
			GUILayout.EndVertical();
			this.ShowConsole();
		}

		protected virtual void CheckObjectAndAddToList(object obj, string objName)
		{
			if (!(obj is string) && obj.GetType().IsClass && !(obj is Type) && !(obj is Exception))
			{
				NameableObject instance = this.NameableObjectPool.GetInstance();
				instance.Name = ((objName == null) ? string.Format("_Elm {0}", this.ObjectList.Count) : objName);
				instance.Value = obj;
				this.ObjectList.Add(instance);
			}
		}

		protected void ShowInternalButton()
		{
			if (this.ViewMode == 1)
			{
				if (this.ActiveChannels.ContainsKey(this.CurrViewChannel) && this.ActiveChannels[this.CurrViewChannel].Length == 0)
				{
					if (this.GUILayoutBtn("清除所有Log"))
					{
						this.ClearTextLogs();
					}
				}
				else if (this.GUILayoutBtn("清除Log") && this.ActiveChannels.ContainsKey(this.CurrViewChannel))
				{
					this.ActiveChannels[this.CurrViewChannel] = string.Empty;
				}
				if (this.GUILayoutBtn("当前channel" + this.CurrViewChannel))
				{
					List<int> list = this.ActiveChannels.Keys.ToList<int>();
					list.Sort((int l, int r) => l - r);
					for (int i = 0; i < list.Count; i++)
					{
						int num = list[i];
						if (num > this.CurrViewChannel)
						{
							this.CurrViewChannel = num;
							break;
						}
						if (i == list.Count - 1)
						{
							this.CurrViewChannel = list[0];
						}
					}
				}
				if (this.GUILayoutBtn("Object视图"))
				{
					this.AnalyseDisplayer.ShowNewObject(this.ObjectList, "Debug");
					this.ViewMode = 2;
					this.ScrollPosition = Vector2.zero;
				}
			}
			else if (this.ViewMode == 2)
			{
				if (this.GUILayoutBtn("清除所有Object"))
				{
					this.ClearObjectLogs();
				}
				if (this.GUILayoutBtn("返回"))
				{
					if (this.AnalyseDisplayer.Back())
					{
						this.ViewMode = 1;
					}
					this.ScrollPosition = Vector2.zero;
				}
			}
		}

		protected void ShowConsole()
		{
			this.ScrollPosition = this.BeginGUIScrollView(this.ScrollPosition);
			if (this.ViewMode == 1)
			{
				if (this.ActiveChannels.ContainsKey(this.CurrViewChannel))
				{
					this.ActiveChannels[this.CurrViewChannel] = this.GUILayoutTextField(this.ActiveChannels[this.CurrViewChannel]);
				}
			}
			else if (this.ViewMode == 2)
			{
				this.AnalyseDisplayer.Show();
			}
			else if (this.ViewMode == 3)
			{
			}
			GUILayout.EndScrollView();
		}

		protected Vector2 BeginGUIScrollView(Vector2 v)
		{
			return GUILayout.BeginScrollView(v, this.HSliderGuiStyle, this.VSliderGuiStyle, new GUILayoutOption[]
			{
				GUILayout.Height((float)this.GetPixelValue(this.ConsoleHeight)),
				GUILayout.Width((float)this.GetPixelValue(this.ConsoleWidth))
			});
		}

		public bool GUILayoutBtn(string str)
		{
			return GUILayout.Button(str, this.BtnGuiStyle, new GUILayoutOption[]
			{
				GUILayout.Height((float)this.GetPixelValue(40)),
				GUILayout.Width((float)this.GetPixelValue(150))
			});
		}

		protected virtual void ClearTextLogs()
		{
			for (int i = 0; i < this.ActiveChannels.Keys.ToList<int>().Count; i++)
			{
				int num = this.ActiveChannels.Keys.ToList<int>()[i];
				if (num < 10000)
				{
					this.ActiveChannels[num] = string.Empty;
				}
			}
		}

		protected virtual void ClearObjectLogs()
		{
			foreach (NameableObject current in this.ObjectList)
			{
				this.NameableObjectPool.ReturnInstance(current);
			}
			this.ObjectList.Clear();
		}

		protected virtual void ClearEventButton()
		{
			this.EventBtns.Clear();
		}

		public string GUILayoutTextField(string str)
		{
			string result;
			try
			{
				if (str.Length > 10000)
				{
					str = str.Substring(str.Length - 10000, 10000);
				}
				result = GUILayout.TextField(str, this.TextFieldGuiStyle, new GUILayoutOption[0]);
			}
			catch (Exception)
			{
				result = str;
			}
			return result;
		}

		public int GetPixelValue(int value)
		{
			return Screen.height * value / this.DefaultHeight;
		}
	}
}
