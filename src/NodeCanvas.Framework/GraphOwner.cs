using ParadoxNotion;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NodeCanvas.Framework
{
	public abstract class GraphOwner : MonoBehaviour
	{
		public enum EnableAction
		{
			EnableBahaviour,
			DoNothing
		}

		public enum DisableAction
		{
			DisableBehaviour,
			PauseBehaviour,
			DoNothing
		}

		[HideInInspector]
		public GraphOwner.EnableAction enableAction;

		[HideInInspector]
		public GraphOwner.DisableAction disableAction;

		private Dictionary<Graph, Graph> instances = new Dictionary<Graph, Graph>();

		private bool startCalled;

		private static bool isQuiting;

		public abstract Graph graph
		{
			get;
			set;
		}

		public abstract IBlackboard blackboard
		{
			get;
			set;
		}

		public abstract Type graphType
		{
			get;
		}

		public bool graphIsLocal
		{
			get
			{
				if (this.graph == null)
				{
					return false;
				}
				List<IScriptableComponent> list = base.GetComponents(typeof(IScriptableComponent)).Cast<IScriptableComponent>().ToList<IScriptableComponent>();
				return list.Contains(this.graph);
			}
		}

		public bool isRunning
		{
			get
			{
				return this.graph != null && this.graph.isRunning;
			}
		}

		public bool isPaused
		{
			get
			{
				return this.graph != null && this.graph.isPaused;
			}
		}

		public float elapsedTime
		{
			get
			{
				return (!(this.graph != null)) ? 0f : this.graph.elapsedTime;
			}
		}

		public abstract void StartBehaviour();

		public abstract void StartBehaviour(Action callback);

		public abstract void PauseBehaviour();

		public abstract void StopBehaviour();

		protected Graph GetInstance(Graph originalGraph)
		{
			if (originalGraph == null)
			{
				return null;
			}
			if (!Application.isPlaying)
			{
				return originalGraph;
			}
			if (this.instances.Values.Contains(originalGraph))
			{
				return originalGraph;
			}
			Graph graph;
			if (this.instances.ContainsKey(originalGraph))
			{
				graph = this.instances[originalGraph];
			}
			else
			{
				graph = Graph.Clone<Graph>(originalGraph);
				this.instances[originalGraph] = graph;
			}
			graph.agent = this;
			graph.blackboard = this.blackboard;
			return graph;
		}

		public void SendEvent(string eventName)
		{
			this.SendEvent(new EventData(eventName));
		}

		public void SendEvent<T>(string eventName, T eventValue)
		{
			this.SendEvent(new EventData<T>(eventName, eventValue));
		}

		public void SendEvent(EventData eventData)
		{
			if (this.graph != null)
			{
				this.graph.SendEvent(eventData);
			}
		}

		public static void SendGlobalEvent(EventData eventData)
		{
			Graph.SendGlobalEvent(eventData);
		}

		public void SendTaskMessage(string name)
		{
			this.SendTaskMessage(name, null);
		}

		public void SendTaskMessage(string name, object arg)
		{
			if (this.graph != null)
			{
				this.graph.SendTaskMessage(name, arg);
			}
		}

		protected void OnApplicationQuit()
		{
			GraphOwner.isQuiting = true;
		}

		protected void Awake()
		{
			if (this.graphIsLocal)
			{
				this.instances[this.graph] = this.graph;
			}
			else
			{
				this.graph = this.GetInstance(this.graph);
			}
		}

		protected void Start()
		{
			this.startCalled = true;
			if (this.enableAction == GraphOwner.EnableAction.EnableBahaviour)
			{
				this.StartBehaviour();
			}
		}

		protected void OnEnable()
		{
			if (this.startCalled && this.enableAction == GraphOwner.EnableAction.EnableBahaviour)
			{
				this.StartBehaviour();
			}
		}

		protected void OnDisable()
		{
			if (GraphOwner.isQuiting)
			{
				return;
			}
			if (this.disableAction == GraphOwner.DisableAction.DisableBehaviour)
			{
				this.StopBehaviour();
			}
			if (this.disableAction == GraphOwner.DisableAction.PauseBehaviour)
			{
				this.PauseBehaviour();
			}
		}

		protected void OnDestroy()
		{
			if (GraphOwner.isQuiting)
			{
				return;
			}
			this.StopBehaviour();
			foreach (Graph current in this.instances.Values)
			{
				UnityEngine.Object.Destroy(current);
			}
		}
	}
	public abstract class GraphOwner<T> : GraphOwner where T : Graph
	{
		[HideInInspector, SerializeField]
		private T _graph;

		[HideInInspector, SerializeField]
		private Blackboard _blackboard;

		public sealed override Graph graph
		{
			get
			{
				return this.behaviour;
			}
			set
			{
				this.behaviour = (T)((object)value);
			}
		}

		public sealed override IBlackboard blackboard
		{
			get
			{
				if (this._blackboard == null)
				{
					this._blackboard = base.GetComponent<Blackboard>();
				}
				return this._blackboard;
			}
			set
			{
				if (this._blackboard != value)
				{
					this._blackboard = (Blackboard)value;
					this.UpdateReferences();
				}
			}
		}

		public sealed override Type graphType
		{
			get
			{
				return typeof(T);
			}
		}

		public T behaviour
		{
			get
			{
				return this._graph;
			}
			set
			{
				if (this._graph != value)
				{
					this._graph = (T)((object)base.GetInstance(value));
					this.UpdateReferences();
				}
			}
		}

		private void UpdateReferences()
		{
			if (this.graph != null)
			{
				this.graph.agent = this;
				this.graph.blackboard = this.blackboard;
			}
		}

		public sealed override void StartBehaviour()
		{
			this.behaviour = (T)((object)base.GetInstance(this.behaviour));
			if (this.behaviour != null)
			{
				T behaviour = this.behaviour;
				behaviour.StartGraph(this, this.blackboard, null);
			}
		}

		public sealed override void StartBehaviour(Action callback)
		{
			this.behaviour = (T)((object)base.GetInstance(this.behaviour));
			if (this.behaviour != null)
			{
				T behaviour = this.behaviour;
				behaviour.StartGraph(this, this.blackboard, callback);
			}
		}

		public sealed override void PauseBehaviour()
		{
			if (this.behaviour != null)
			{
				T behaviour = this.behaviour;
				behaviour.Pause();
			}
		}

		public sealed override void StopBehaviour()
		{
			if (this.behaviour != null)
			{
				T behaviour = this.behaviour;
				behaviour.Stop();
			}
		}

		public void StartBehaviour(T newGraph)
		{
			this.SwitchBehaviour(newGraph);
		}

		public void StartBehaviour(T newGraph, Action callback)
		{
			this.SwitchBehaviour(newGraph, callback);
		}

		public void SwitchBehaviour(T newGraph)
		{
			this.SwitchBehaviour(newGraph, null);
		}

		public void SwitchBehaviour(T newGraph, Action callback)
		{
			this.StopBehaviour();
			this.behaviour = newGraph;
			this.StartBehaviour(callback);
		}
	}
}
