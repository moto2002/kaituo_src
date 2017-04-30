using ParadoxNotion;
using ParadoxNotion.Design;
using ParadoxNotion.Serialization;
using ParadoxNotion.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NodeCanvas.Framework
{
	[Serializable]
	public abstract class Node
	{
		[SerializeField]
		private Vector2 _position = Vector2.zero;

		[SerializeField]
		private string _name;

		[SerializeField]
		private string _tag;

		[SerializeField]
		private string _comment;

		[SerializeField]
		private bool _isBreakpoint;

		private Graph _graph;

		private List<Connection> _inConnections = new List<Connection>();

		private List<Connection> _outConnections = new List<Connection>();

		[NonSerialized]
		private Status _status = Status.Resting;

		[NonSerialized]
		private string _nodeName;

		[NonSerialized]
		private int _ID;

		public Vector2 nodePosition
		{
			get
			{
				return this._position;
			}
			set
			{
				this._position = value;
			}
		}

		public Graph graph
		{
			get
			{
				return this._graph;
			}
			set
			{
				this._graph = value;
			}
		}

		private string customName
		{
			get
			{
				return this._name;
			}
			set
			{
				this._name = value;
			}
		}

		public string tag
		{
			get
			{
				return this._tag;
			}
			set
			{
				this._tag = value;
			}
		}

		public string nodeComment
		{
			get
			{
				return this._comment;
			}
			set
			{
				this._comment = value;
			}
		}

		public bool isBreakpoint
		{
			get
			{
				return this._isBreakpoint;
			}
			set
			{
				this._isBreakpoint = value;
			}
		}

		public List<Connection> inConnections
		{
			get
			{
				return this._inConnections;
			}
			protected set
			{
				this._inConnections = value;
			}
		}

		public List<Connection> outConnections
		{
			get
			{
				return this._outConnections;
			}
			protected set
			{
				this._outConnections = value;
			}
		}

		public virtual string name
		{
			get
			{
				if (!string.IsNullOrEmpty(this.customName))
				{
					return this.customName;
				}
				if (string.IsNullOrEmpty(this._nodeName))
				{
					NameAttribute nameAttribute = base.GetType().RTGetAttribute(false);
					this._nodeName = ((nameAttribute == null) ? base.GetType().FriendlyName().SplitCamelCase() : nameAttribute.name);
				}
				return this._nodeName;
			}
			set
			{
				this.customName = value;
			}
		}

		public abstract int maxInConnections
		{
			get;
		}

		public abstract int maxOutConnections
		{
			get;
		}

		public abstract Type outConnectionType
		{
			get;
		}

		public abstract bool allowAsPrime
		{
			get;
		}

		public abstract bool showCommentsBottom
		{
			get;
		}

		public int ID
		{
			get
			{
				return this._ID;
			}
			private set
			{
				this._ID = value;
			}
		}

		public Status status
		{
			get
			{
				return this._status;
			}
			protected set
			{
				this._status = value;
			}
		}

		protected Component graphAgent
		{
			get
			{
				return (!(this.graph != null)) ? null : this.graph.agent;
			}
		}

		protected IBlackboard graphBlackboard
		{
			get
			{
				IBlackboard arg_24_0;
				if (this.graph != null)
				{
					IBlackboard blackboard = this.graph.blackboard;
					arg_24_0 = blackboard;
				}
				else
				{
					arg_24_0 = null;
				}
				return arg_24_0;
			}
		}

		private bool isChecked
		{
			get;
			set;
		}

		public Node()
		{
		}

		public static Node Create(Graph targetGraph, Type nodeType, Vector2 pos)
		{
			if (targetGraph == null)
			{
				Debug.LogError("Can't Create a Node without providing a Target Graph");
				return null;
			}
			Node node = (Node)Activator.CreateInstance(nodeType);
			node.graph = targetGraph;
			node.nodePosition = pos;
			BBParameter.SetBBFields(node, targetGraph.blackboard);
			node.OnValidate(targetGraph);
			return node;
		}

		public Node Duplicate(Graph targetGraph)
		{
			if (targetGraph == null)
			{
				Debug.LogError("Can't duplicate a Node without providing a Target Graph");
				return null;
			}
			Node node = JSON.Deserialize<Node>(JSON.Serialize(typeof(Node), this, false, null), null);
			targetGraph.allNodes.Add(node);
			node.inConnections.Clear();
			node.outConnections.Clear();
			if (targetGraph == this.graph)
			{
				node.nodePosition += new Vector2(50f, 50f);
			}
			node.graph = targetGraph;
			BBParameter.SetBBFields(node, targetGraph.blackboard);
			ITaskAssignable taskAssignable = this as ITaskAssignable;
			if (taskAssignable != null && taskAssignable.task != null)
			{
				(node as ITaskAssignable).task = taskAssignable.task.Duplicate(this.graph);
			}
			node.OnValidate(targetGraph);
			return node;
		}

		public virtual void OnValidate(Graph assignedGraph)
		{
		}

		public virtual void OnDestroy()
		{
		}

		public Status Execute(Component agent, IBlackboard blackboard)
		{
			if (this.isChecked)
			{
				return this.Error("Infinite Loop. Please check for other errors that may have caused this in the log.");
			}
			this.isChecked = true;
			this.status = this.OnExecute(agent, blackboard);
			this.isChecked = false;
			return this.status;
		}

		protected Status Error(string log)
		{
			Debug.LogError(string.Concat(new object[]
			{
				"<b>Graph Error:</b> '",
				log,
				"' On node '",
				this.name,
				"' ID ",
				this.ID,
				" | On graph '",
				this.graph.name,
				"'"
			}));
			return Status.Error;
		}

		public void Reset(bool recursively = true)
		{
			if (this.status == Status.Resting || this.isChecked)
			{
				return;
			}
			this.OnReset();
			this.status = Status.Resting;
			this.isChecked = true;
			for (int i = 0; i < this.outConnections.Count; i++)
			{
				this.outConnections[i].Reset(recursively);
			}
			this.isChecked = false;
		}

		public void SendEvent(EventData eventData)
		{
			this.graph.SendEvent(eventData);
		}

		protected Coroutine StartCoroutine(IEnumerator routine)
		{
			return MonoManager.current.StartCoroutine(routine);
		}

		public void SubscribeToMessage(params string[] messages)
		{
			this.SubscribeToMessage(this.graphAgent, messages);
		}

		public void SubscribeToMessage(Component messageAgent, params string[] messages)
		{
			if (messageAgent == null)
			{
				return;
			}
			MessageRouter messageRouter = messageAgent.GetComponent<MessageRouter>();
			if (messageRouter == null)
			{
				messageRouter = messageAgent.gameObject.AddComponent<MessageRouter>();
			}
			for (int i = 0; i < messages.Length; i++)
			{
				messageRouter.Listen(this, messages[i]);
			}
		}

		public void UnSubscribeFromMessages()
		{
			this.UnSubscribeFromMessages(this.graphAgent);
		}

		public void UnSubscribeFromMessages(Component messageAgent)
		{
			if (messageAgent == null)
			{
				return;
			}
			MessageRouter component = messageAgent.GetComponent<MessageRouter>();
			if (component == null)
			{
				Debug.LogWarning("Unsubscribing from non subscribed agent event messages");
				return;
			}
			component.Forget(this);
		}

		public bool IsNewConnectionAllowed(Node sourceNode)
		{
			if (this == sourceNode)
			{
				Debug.LogWarning("Node can't connect to itself");
				return false;
			}
			if (sourceNode.outConnections.Count >= sourceNode.maxOutConnections && sourceNode.maxOutConnections != -1)
			{
				Debug.LogWarning("Source node can have no more out connections.");
				return false;
			}
			if (this == this.graph.primeNode && this.maxInConnections == 1)
			{
				Debug.LogWarning("Target node can have no more connections");
				return false;
			}
			if (this.maxInConnections <= this.inConnections.Count && this.maxInConnections != -1)
			{
				Debug.LogWarning("Target node can have no more connections");
				return false;
			}
			return true;
		}

		public int AssignIDToGraph(int lastID)
		{
			if (this.isChecked)
			{
				return lastID;
			}
			this.isChecked = true;
			lastID++;
			this.ID = lastID;
			for (int i = 0; i < this.outConnections.Count; i++)
			{
				lastID = this.outConnections[i].targetNode.AssignIDToGraph(lastID);
			}
			return lastID;
		}

		public void ResetRecursion()
		{
			if (!this.isChecked)
			{
				return;
			}
			this.isChecked = false;
			for (int i = 0; i < this.outConnections.Count; i++)
			{
				this.outConnections[i].targetNode.ResetRecursion();
			}
		}

		public List<Node> GetParentNodes()
		{
			if (this.inConnections.Count != 0)
			{
				return (from c in this.inConnections
				select c.sourceNode).ToList<Node>();
			}
			return new List<Node>();
		}

		public List<Node> GetChildNodes()
		{
			if (this.outConnections.Count != 0)
			{
				return (from c in this.outConnections
				select c.targetNode).ToList<Node>();
			}
			return new List<Node>();
		}

		protected virtual Status OnExecute(Component agent, IBlackboard blackboard)
		{
			return this.status;
		}

		protected virtual void OnReset()
		{
		}

		public virtual void OnParentConnected(int connectionIndex)
		{
		}

		public virtual void OnParentDisconnected(int connectionIndex)
		{
		}

		public virtual void OnChildConnected(int connectionIndex)
		{
		}

		public virtual void OnChildDisconnected(int connectionIndex)
		{
		}

		public virtual void OnGraphStarted()
		{
		}

		public virtual void OnGraphStoped()
		{
		}

		public virtual void OnGraphPaused()
		{
		}

		public sealed override string ToString()
		{
			ITaskAssignable taskAssignable = this as ITaskAssignable;
			return string.Format("{0} ({1})", this.name, (taskAssignable == null || taskAssignable.task == null) ? string.Empty : taskAssignable.task.ToString());
		}

		public void OnDrawGizmos()
		{
			if (this is ITaskAssignable && (this as ITaskAssignable).task != null)
			{
				(this as ITaskAssignable).task.OnDrawGizmos();
			}
		}

		public void OnDrawGizmosSelected()
		{
			if (this is ITaskAssignable && (this as ITaskAssignable).task != null)
			{
				(this as ITaskAssignable).task.OnDrawGizmosSelected();
			}
		}
	}
}
