using Assets.Scripts.Tool;
using Assets.Scripts.Tools.Component;
using Assets.Tools.Script.Caller;
using LitJson;
using NodeCanvas;
using NodeCanvas.BehaviourTrees;
using NodeCanvas.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Performance
{
	public class BTProxy : MonoBehaviour
	{
		public Action OnPlayEnd;

		public BehaviourTreeOwner BehaviourTreeOwner;

		public Blackboard Blackboard;

		[HideInInspector]
		public bool RestoreBlackboardOnPlayEnd = true;

		private Dictionary<string, object> blackboardList;

		private Dictionary<string, Type> blackboardTypeList;

		private float playTime;

		private float startTime;

		public bool IsPlaying
		{
			get;
			private set;
		}

		public GameObject OwnerObject
		{
			get
			{
				return this.BehaviourTreeOwner.gameObject;
			}
		}

		public void CacheBlackboard()
		{
			if (this.blackboardList == null)
			{
				this.blackboardTypeList = new Dictionary<string, Type>();
				this.blackboardList = new Dictionary<string, object>();
				foreach (Variable current in this.Blackboard.variables.Values)
				{
					this.blackboardList.Add(current.name, current.value);
					this.blackboardTypeList.Add(current.name, current.varType);
				}
			}
		}

		public void RestoreBlackboard()
		{
			this.Blackboard.variables.Clear();
			foreach (KeyValuePair<string, object> current in this.blackboardList)
			{
				this.Blackboard.SetOrAddValue(current.Key, current.Value, this.blackboardTypeList[current.Key]);
			}
		}

		public void SetValue(string key, object value)
		{
			this.Blackboard.SetOrAddValue(key, value);
		}

		public void SetJsonValue(string key, string json)
		{
			JsonData value = null;
			if (json.IsNOTNullOrEmpty())
			{
				try
				{
					value = JsonMapper.ToObject(json);
				}
				catch (Exception var_1_19)
				{
				}
			}
			this.Blackboard.SetOrAddValue(key, value, typeof(JsonData));
		}

		public void AddValue(string key, object value, Type type)
		{
			this.Blackboard.SetOrAddValue(key, value, type);
		}

		public object GetValue(string key)
		{
			return this.Blackboard.GetVariable(key, null).value;
		}

		public bool HasKey(string key)
		{
			return this.Blackboard.variables.ContainsKey(key);
		}

		public List<string> GetKeys()
		{
			List<string> list = new List<string>();
			foreach (string current in this.Blackboard.variables.Keys)
			{
				list.Add(current);
			}
			return list;
		}

		public void Play(Action onEnd)
		{
			this.PlayWithTime(-1f, onEnd);
		}

		public void PlayWithTime(float playTime, Action onEnd)
		{
			this.OnPlayEnd = onEnd;
			this.IsPlaying = true;
			this.startTime = Time.time;
			this.playTime = playTime;
			Main3DCamera.Instance.StopAnim();
			base.gameObject.SetActive(true);
			this.BehaviourTreeOwner.gameObject.SetActive(true);
			this.BehaviourTreeOwner.StartBehaviour();
			FrameCall.Call(new Func<bool>(this.CheckPlay));
		}

		public void Stop()
		{
			this.BehaviourTreeOwner.StopBehaviour();
		}

		public void Clear()
		{
			this.OnPlayEnd = null;
			this.BehaviourTreeOwner = null;
			this.Blackboard = null;
			if (this.blackboardList != null)
			{
				this.blackboardList.Clear();
			}
			if (this.blackboardTypeList != null)
			{
				this.blackboardTypeList.Clear();
			}
		}

		private bool CheckPlay()
		{
			if (this.playTime > 0f && Time.time - this.startTime > this.playTime)
			{
				this.Stop();
			}
			Status rootStatus = this.BehaviourTreeOwner.rootStatus;
			bool isRunning = this.BehaviourTreeOwner.isRunning;
			if (rootStatus == Status.Error || rootStatus == Status.Failure)
			{
				this.IsPlaying = false;
				DebugConsole.Log(new object[]
				{
					"Running Error",
					base.gameObject.name
				});
				UnityEngine.Object.Destroy(base.gameObject);
				if (this.OnPlayEnd != null)
				{
					Action onPlayEnd = this.OnPlayEnd;
					this.OnPlayEnd = null;
					onPlayEnd();
				}
			}
			else if (rootStatus == Status.Success || !isRunning)
			{
				this.IsPlaying = false;
				this.BehaviourTreeOwner.gameObject.SetActive(false);
				if (this.RestoreBlackboardOnPlayEnd)
				{
					this.RestoreBlackboard();
				}
				if (this.OnPlayEnd != null)
				{
					Action onPlayEnd2 = this.OnPlayEnd;
					this.OnPlayEnd = null;
					onPlayEnd2();
				}
			}
			return rootStatus == Status.Running && isRunning;
		}
	}
}
