using ParadoxNotion;
using ParadoxNotion.Design;
using ParadoxNotion.Serialization;
using ParadoxNotion.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace NodeCanvas.Framework
{
	[Serializable]
	public abstract class Task
	{
		[AttributeUsage(AttributeTargets.Class)]
		protected class AgentTypeAttribute : Attribute
		{
			public Type type;

			public AgentTypeAttribute(Type type)
			{
				this.type = type;
			}
		}

		[AttributeUsage(AttributeTargets.Class)]
		protected class EventReceiverAttribute : Attribute
		{
			public string[] eventMessages;

			public EventReceiverAttribute(params string[] args)
			{
				this.eventMessages = args;
			}
		}

		[AttributeUsage(AttributeTargets.Field)]
		protected class GetFromAgentAttribute : Attribute
		{
		}

		[Serializable]
		public class TaskAgent : BBParameter<UnityEngine.Object>
		{
			public new UnityEngine.Object value
			{
				get
				{
					if (!base.useBlackboard)
					{
						return this._value as Component;
					}
					UnityEngine.Object value = base.value;
					if (value is GameObject)
					{
						return (value as GameObject).transform;
					}
					if (value is Component)
					{
						return (Component)value;
					}
					return null;
				}
				set
				{
					this._value = value;
				}
			}

			protected override object objectValue
			{
				get
				{
					return this.value;
				}
				set
				{
					this.value = (UnityEngine.Object)value;
				}
			}
		}

		[SerializeField]
		private bool _isActive = true;

		[SerializeField]
		private Task.TaskAgent overrideAgent;

		[NonSerialized]
		private IBlackboard _blackboard;

		[NonSerialized]
		private ITaskSystem _ownerSystem;

		[NonSerialized]
		private Component current;

		[NonSerialized]
		private readonly Type _agentType;

		[NonSerialized]
		private readonly string _taskName;

		[NonSerialized]
		private readonly string _taskDescription;

		public ITaskSystem ownerSystem
		{
			get
			{
				return this._ownerSystem;
			}
			private set
			{
				this._ownerSystem = value;
			}
		}

		private Component ownerAgent
		{
			get
			{
				return (this.ownerSystem == null) ? null : this.ownerSystem.agent;
			}
		}

		private IBlackboard ownerBlackboard
		{
			get
			{
				IBlackboard arg_1E_0;
				if (this.ownerSystem != null)
				{
					IBlackboard blackboard = this.ownerSystem.blackboard;
					arg_1E_0 = blackboard;
				}
				else
				{
					arg_1E_0 = null;
				}
				return arg_1E_0;
			}
		}

		protected float ownerElapsedTime
		{
			get
			{
				return (this.ownerSystem == null) ? 0f : this.ownerSystem.elapsedTime;
			}
		}

		public ObsoleteAttribute isObsolete
		{
			get
			{
				return base.GetType().RTGetAttribute(true);
			}
		}

		public bool isActive
		{
			get
			{
				return this._isActive;
			}
			set
			{
				this._isActive = value;
			}
		}

		public string name
		{
			get
			{
				return this._taskName;
			}
		}

		public string description
		{
			get
			{
				return this._taskDescription;
			}
		}

		public virtual Type agentType
		{
			get
			{
				return this._agentType;
			}
		}

		public string summaryInfo
		{
			get
			{
				if (this is ActionTask)
				{
					return ((!this.agentIsOverride) ? string.Empty : "* ") + this.info;
				}
				if (this is ConditionTask)
				{
					return ((!this.agentIsOverride) ? string.Empty : "* ") + ((!(this as ConditionTask).invert) ? "If " : "If <b>!</b> ") + this.info;
				}
				return this.info;
			}
		}

		protected virtual string info
		{
			get
			{
				return this.name;
			}
		}

		public string agentInfo
		{
			get
			{
				if (this.overrideAgent == null)
				{
					return "<b>owner</b>";
				}
				return (this.overrideAgent == null) ? "*NULL*" : this.overrideAgent.ToString();
			}
		}

		public bool agentIsOverride
		{
			get
			{
				return this.overrideAgent != null;
			}
			private set
			{
				if (!value && this.overrideAgent != null)
				{
					this.overrideAgent = null;
				}
				if (value && this.overrideAgent == null)
				{
					this.overrideAgent = new Task.TaskAgent();
					this.overrideAgent.bb = this.blackboard;
				}
			}
		}

		public string overrideAgentParameterName
		{
			get
			{
				return (this.overrideAgent == null) ? null : this.overrideAgent.name;
			}
		}

		protected Component agent
		{
			get
			{
				if (this.current != null)
				{
					return this.current;
				}
				return (!this.agentIsOverride) ? ((!(this.ownerAgent != null) || this.agentType == null) ? null : this.ownerAgent.GetComponent(this.agentType)) : ((Component)this.overrideAgent.value);
			}
		}

		protected IBlackboard blackboard
		{
			get
			{
				if (this._blackboard == null)
				{
					this._blackboard = this.ownerBlackboard;
					this.UpdateBBFields(this._blackboard);
				}
				return this._blackboard;
			}
			private set
			{
				if (this._blackboard != value)
				{
					this._blackboard = value;
					this.UpdateBBFields(this._blackboard);
				}
			}
		}

		public Task()
		{
			Task.AgentTypeAttribute agentTypeAttribute = base.GetType().RTGetAttribute(true);
			this._agentType = ((agentTypeAttribute == null || (!typeof(Component).RTIsAssignableFrom(agentTypeAttribute.type) && !agentTypeAttribute.type.RTIsInterface())) ? null : agentTypeAttribute.type);
			NameAttribute nameAttribute = base.GetType().RTGetAttribute(false);
			this._taskName = ((nameAttribute == null) ? base.GetType().FriendlyName().SplitCamelCase() : nameAttribute.name);
			DescriptionAttribute descriptionAttribute = base.GetType().RTGetAttribute(true);
			this._taskDescription = ((descriptionAttribute == null) ? string.Empty : descriptionAttribute.description);
		}

		public static Task Create(Type type, ITaskSystem newOwnerSystem)
		{
			Task task = (Task)Activator.CreateInstance(type);
			task.SetOwnerSystem(newOwnerSystem);
			task.OnValidate(newOwnerSystem);
			return task;
		}

		public virtual Task Duplicate(ITaskSystem newOwnerSystem)
		{
			Task task = JSON.Deserialize<Task>(JSON.Serialize(typeof(Task), this, false, null), null);
			task.SetOwnerSystem(newOwnerSystem);
			task.OnValidate(newOwnerSystem);
			return task;
		}

		protected virtual void OnValidate(ITaskSystem newOwnerSystem)
		{
		}

		public void SetOwnerSystem(ITaskSystem newOwnerSystem)
		{
			if (newOwnerSystem == null)
			{
				Debug.LogError("ITaskSystem set in task is null");
				return;
			}
			this.ownerSystem = newOwnerSystem;
			this.UpdateBBFields(newOwnerSystem.blackboard);
		}

		private void UpdateBBFields(IBlackboard bb)
		{
			BBParameter.SetBBFields(this, bb);
			if (this.overrideAgent != null)
			{
				this.overrideAgent.bb = bb;
			}
		}

		protected Coroutine StartCoroutine(IEnumerator routine)
		{
			return MonoManager.current.StartCoroutine(routine);
		}

		protected void SendEvent(EventData eventData)
		{
			if (this.ownerSystem != null)
			{
				this.ownerSystem.SendEvent(eventData);
			}
		}

		protected virtual string OnInit()
		{
			return null;
		}

		protected bool Set(Component newAgent, IBlackboard newBB)
		{
			this.blackboard = newBB;
			bool result;
			if (this.agentIsOverride)
			{
				try
				{
					if (this.current.gameObject == ((Component)this.overrideAgent.value).gameObject)
					{
						result = true;
						return result;
					}
					result = this.Initialize((Component)this.overrideAgent.value, this.agentType);
					return result;
				}
				catch
				{
					result = this.Initialize((Component)this.overrideAgent.value, this.agentType);
					return result;
				}
			}
			try
			{
				if (this.current.gameObject == newAgent.gameObject)
				{
					result = true;
				}
				else
				{
					result = this.Initialize(newAgent, this.agentType);
				}
			}
			catch
			{
				result = this.Initialize(newAgent, this.agentType);
			}
			return result;
		}

		private bool Initialize(Component newAgent, Type newType)
		{
			this.UnsubscribeFromAgentEvents(this.agent);
			newAgent = ((newType == null || newType == typeof(Component) || !(newAgent != null)) ? newAgent : newAgent.GetComponent(newType));
			this.current = newAgent;
			if (newAgent == null && this.agentType != null)
			{
				return this.Error(string.Concat(new object[]
				{
					"Failed to change Agent to requested type '",
					this.agentType,
					"', for Task '",
					this.name,
					"' or new Agent is NULL. Does the Agent has the requested Component?"
				}));
			}
			Task.EventReceiverAttribute eventReceiverAttribute = base.GetType().RTGetAttribute(true);
			if (eventReceiverAttribute != null)
			{
				this.SubscribeToAgentEvents(newAgent, eventReceiverAttribute.eventMessages);
			}
			if (!this.InitializeAttributes(newAgent))
			{
				return false;
			}
			string text = this.OnInit();
			return text == null || this.Error(string.Format("'{0}' at Task '{1}'", text, this.name));
		}

		private bool InitializeAttributes(Component newAgent)
		{
			FieldInfo[] array = base.GetType().RTGetFields();
			for (int i = 0; i < array.Length; i++)
			{
				FieldInfo fieldInfo = array[i];
				object value = fieldInfo.GetValue(this);
				RequiredFieldAttribute requiredFieldAttribute = fieldInfo.RTGetAttribute(true);
				if (requiredFieldAttribute != null)
				{
					if (value == null || value.Equals(null))
					{
						return this.Error(string.Format("A required field for Task '{0}' is not set! Field '{1}'", this.name, fieldInfo.Name));
					}
					if (fieldInfo.FieldType == typeof(string) && string.IsNullOrEmpty((string)value))
					{
						return this.Error(string.Format("A required string field for Task '{0}' is not set! Field '{1}'", this.name, fieldInfo.Name));
					}
					if (typeof(BBParameter).RTIsAssignableFrom(fieldInfo.FieldType) && (value as BBParameter).isNull)
					{
						return this.Error(string.Format("A required BBParameter field value for Task '{0}' is not set! Field '{1}'", this.name, fieldInfo.Name));
					}
				}
				Task.GetFromAgentAttribute getFromAgentAttribute = fieldInfo.RTGetAttribute(true);
				if (getFromAgentAttribute != null)
				{
					if (!typeof(Component).RTIsAssignableFrom(fieldInfo.FieldType))
					{
						return this.Error(string.Format("You've used a GetFromAgent Attribute on a field {0} whos type does not derive Component on Task {1}", fieldInfo.Name, this.name));
					}
					fieldInfo.SetValue(this, newAgent.GetComponent(fieldInfo.FieldType));
					if (fieldInfo.GetValue(this) as UnityEngine.Object == null)
					{
						return this.Error(string.Format("GetFromAgent Attribute failed to get the required Component of type '{0}' from '{1}'. Does it exist?", fieldInfo.FieldType.Name, this.agent.gameObject.name));
					}
				}
			}
			return true;
		}

		private bool Error(string error)
		{
			Debug.LogError(string.Format("<b>Task Error:</b> {0} (Task Disabled)", error));
			return false;
		}

		public void SubscribeToAgentEvents(Component targetAgent, params string[] eventNames)
		{
			if (targetAgent == null)
			{
				return;
			}
			MessageRouter messageRouter = targetAgent.GetComponent<MessageRouter>();
			if (messageRouter == null)
			{
				messageRouter = targetAgent.gameObject.AddComponent<MessageRouter>();
			}
			for (int i = 0; i < eventNames.Length; i++)
			{
				messageRouter.Listen(this, eventNames[i]);
			}
		}

		public void UnsubscribeFromAgentEvents(Component targetAgent)
		{
			if (targetAgent == null)
			{
				return;
			}
			MessageRouter component = targetAgent.GetComponent<MessageRouter>();
			if (component != null)
			{
				component.Forget(this);
			}
		}

		public string[] GetErrors()
		{
			List<string> list = new List<string>();
			if (this.agent == null && this.agentType != null)
			{
				list.Add("Null Agent");
			}
			FieldInfo[] array = base.GetType().RTGetFields();
			for (int i = 0; i < array.Length; i++)
			{
				FieldInfo fieldInfo = array[i];
				if (this.isObsolete != null)
				{
					list.Add(string.Format("The Task is obsolete '{0}': <b>'{1}'</b>", this.name, this.isObsolete.Message));
				}
				if (fieldInfo.RTGetAttribute(true) != null)
				{
					if (fieldInfo.GetValue(this) == null || fieldInfo.GetValue(this).Equals(null))
					{
						list.Add("Required field in task is null");
					}
					if (fieldInfo.FieldType == typeof(string) && string.IsNullOrEmpty((string)fieldInfo.GetValue(this)))
					{
						list.Add("Required string field in task is empty");
					}
					if (typeof(BBParameter).RTIsAssignableFrom(fieldInfo.FieldType) && (fieldInfo.GetValue(this) as BBParameter).isNull)
					{
						list.Add("Required BBParameter field in task resolves to null");
					}
				}
			}
			return (list.Count <= 0) ? null : list.ToArray();
		}

		public sealed override string ToString()
		{
			return string.Format("{0} {1}", this.agentInfo, this.summaryInfo);
		}

		public virtual void OnDrawGizmos()
		{
		}

		public virtual void OnDrawGizmosSelected()
		{
		}
	}
}
