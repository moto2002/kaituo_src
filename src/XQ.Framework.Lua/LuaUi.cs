using Assets.Tools.Script.Attributes;
using Assets.Tools.Script.Editor.Tool;
using LuaInterface;
using NodeCanvas.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XQ.Framework.Lua.Utility;

namespace XQ.Framework.Lua
{
	public class LuaUi : MonoBehaviour
	{
		[Serializable]
		public class LuaUiField
		{
			public UnityEngine.Object Source;

			[InspectorStyle("FieldName", "LuaUiFieldName")]
			public string FieldName;

			[InspectorStyle("FieldType", "LuaUiFieldType")]
			public UnityEngine.Object FieldType;

			public bool IsPublic;
		}

		[Serializable]
		public class LuaUiEvent
		{
			public GameObject Node;

			[InspectorStyle("Events", "LuaUiEvent")]
			public string EventName;
		}

		[Serializable]
		public class LuaUiLife
		{
			public bool OnEnable = true;

			public bool OnDisable = true;

			public bool Dispose = true;

			[HideInInspector]
			public LuaFunction OnEnableCallBack;

			[HideInInspector]
			public LuaFunction OnDisableCallBack;

			[HideInInspector]
			public LuaFunction DisposeCallBack;

			[HideInInspector]
			public bool Active;
		}

		public string FileName;

		public List<LuaUi.LuaUiField> Fields;

		public List<LuaUi.LuaUiEvent> Events;

		public Blackboard Blackboard;

		public LuaUi.LuaUiLife Life;

		public LuaTable BindingTable;

		private PrefabReleaseInfo releaseInfo;

		public void Initialize(LuaTable outputFields, LuaTable bindingTable)
		{
			if (!base.GetComponent<ILuaScriptBase>() && !base.isActiveAndEnabled)
			{
				this.releaseInfo = ResourceManager.SetGCPrefabRes(this, new Action(this.OnDestroy));
			}
			this.BindingTable = bindingTable;
			if (this.Life != null)
			{
				if (this.Life.Active)
				{
					this.InitLife(bindingTable);
				}
				else
				{
					this.Life = null;
				}
			}
			this.GetFields(outputFields);
			this.ManulAddEvent(bindingTable);
			this.Fields = null;
			this.Events = null;
			this.Blackboard = null;
			this.Life = null;
		}

		public UnityEngine.Object GetField(int index)
		{
			Debug.LogFormat("GetField is obsolete, replace lua file with LuaUi at {0}".SetColor(Color.yellow), new object[]
			{
				base.gameObject.name
			});
			UnityEngine.Object result;
			try
			{
				result = this.Fields[index].FieldType;
			}
			catch (Exception arg)
			{
				Debug.LogError(string.Format("{0} get field({2}) error:\r\n{1}", this.FileName, arg, index));
				result = null;
			}
			return result;
		}

		public void GetFields(LuaTable outputFields)
		{
			for (int i = 0; i < this.Fields.Count; i++)
			{
				outputFields[i + 1] = this.Fields[i].FieldType;
			}
			if (this.Blackboard != null)
			{
				foreach (Variable current in this.Blackboard.variables.Values)
				{
					object value = current.value;
					string name = current.name;
					if (value is IList)
					{
						LuaTable luaTable = outputFields[name] as LuaTable;
						IList list = current.value as IList;
						for (int j = 0; j < list.Count; j++)
						{
							luaTable[j + 1] = list[j];
						}
					}
					else
					{
						outputFields[name] = value;
					}
				}
			}
		}

		public void ManulAddEvent(LuaTable bindingTable)
		{
			for (int i = 0; i < this.Events.Count; i++)
			{
				LuaUi.LuaUiEvent luaUiEvent = this.Events[i];
				string eventName = luaUiEvent.EventName;
				LuaUtil.AddEventListener(bindingTable, luaUiEvent.Node, eventName);
			}
		}

		public void InitLife(LuaTable boundTable)
		{
			if (this.Life.Dispose)
			{
				this.Life.DisposeCallBack = boundTable.RawGetLuaFunction("Dispose");
			}
			if (this.Life.OnDisable)
			{
				this.Life.OnDisableCallBack = boundTable.RawGetLuaFunction("OnDisable");
			}
			if (this.Life.OnEnable)
			{
				this.Life.OnEnableCallBack = boundTable.RawGetLuaFunction("OnEnable");
			}
		}

		private void Awake()
		{
			if (this.releaseInfo != null)
			{
				this.releaseInfo.HandDestroy = false;
				this.releaseInfo = null;
			}
		}

		private void OnDestroy()
		{
			if (this.Life != null)
			{
				if (this.Life.OnEnableCallBack != null)
				{
					this.Life.OnEnableCallBack.Dispose();
				}
				if (this.Life.OnDisableCallBack != null)
				{
					this.Life.OnDisableCallBack.Dispose();
				}
				if (this.Life.DisposeCallBack != null)
				{
					this.Life.DisposeCallBack.Call();
					this.Life.DisposeCallBack.Dispose();
				}
				this.Life = null;
			}
			if (this.BindingTable != null)
			{
				this.BindingTable.Dispose();
				this.BindingTable = null;
			}
			this.Fields = null;
			this.Events = null;
			this.Blackboard = null;
			this.Life = null;
			this.releaseInfo = null;
		}

		private void OnEnable()
		{
			if (this.Life != null && this.Life.OnEnableCallBack != null)
			{
				this.Life.OnEnableCallBack.Call();
			}
		}

		private void OnDisable()
		{
			if (this.Life != null && this.Life.OnDisableCallBack != null)
			{
				this.Life.OnDisableCallBack.Call();
			}
		}
	}
}
