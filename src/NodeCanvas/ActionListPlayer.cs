using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Serialization;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace NodeCanvas
{
	[AddComponentMenu("NodeCanvas/Action List")]
	public class ActionListPlayer : MonoBehaviour, ISerializationCallbackReceiver, ITaskSystem
	{
		private ActionList _actionList;

		[SerializeField]
		private Blackboard _blackboard;

		[SerializeField]
		private List<UnityEngine.Object> _objectReferences;

		[SerializeField]
		private string _serializedList;

		public ActionList actionList
		{
			get
			{
				return this._actionList;
			}
			set
			{
				this._actionList = value;
				this.SendTaskOwnerDefaults();
			}
		}

		public Component agent
		{
			get
			{
				return this;
			}
		}

		public IBlackboard blackboard
		{
			get
			{
				return this._blackboard;
			}
			set
			{
				if (this._blackboard != value)
				{
					this._blackboard = (Blackboard)value;
					this.SendTaskOwnerDefaults();
				}
			}
		}

		public float elapsedTime
		{
			get
			{
				return this.actionList.elapsedTime;
			}
		}

		public UnityEngine.Object baseObject
		{
			get
			{
				return this;
			}
		}

		public void OnBeforeSerialize()
		{
			if (Application.isPlaying)
			{
				return;
			}
			this._objectReferences = new List<UnityEngine.Object>();
			this._serializedList = JSON.Serialize(typeof(ActionList), this.actionList, false, this._objectReferences);
		}

		public void OnAfterDeserialize()
		{
			this.actionList = JSON.Deserialize<ActionList>(this._serializedList, this._objectReferences);
			if (this.actionList == null)
			{
				this.actionList = (ActionList)Task.Create(typeof(ActionList), this);
			}
		}

		public void SendTaskOwnerDefaults()
		{
			this.actionList.SetOwnerSystem(this);
			foreach (ActionTask current in this.actionList.actions)
			{
				current.SetOwnerSystem(this);
			}
		}

		public void SendEvent(EventData eventData)
		{
			Debug.LogWarning("Sending events to action lists has no effect");
		}

		[ContextMenu("Play")]
		public void Play()
		{
			if (!Application.isPlaying)
			{
				return;
			}
			this.Play(this, this.blackboard, null);
		}

		public void Play(Action<bool> OnFinish)
		{
			this.Play(this, this.blackboard, OnFinish);
		}

		public void Play(Component agent, IBlackboard blackboard, Action<bool> OnFinish)
		{
			this.actionList.ExecuteAction(agent, blackboard, OnFinish);
		}
	}
}
