using NodeCanvas.Framework.Internal;
using ParadoxNotion;
using ParadoxNotion.Serialization;
using ParadoxNotion.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace NodeCanvas.Framework
{
	[Serializable]
	public abstract class Graph : ScriptableObject, ISerializationCallbackReceiver, ITaskSystem, IScriptableComponent
	{
		[SerializeField]
		private string _serializedGraph;

		[SerializeField]
		private List<UnityEngine.Object> _objectReferences;

		[SerializeField]
		private bool _deserializationFailed;

		private string _name = string.Empty;

		private string _comments = string.Empty;

		private Vector2 _translation = new Vector2(-5000f, -5000f);

		private List<Node> _nodes = new List<Node>();

		private Node _primeNode;

		private List<CanvasGroup> _canvasGroups;

		private IBlackboard _localBlackboard;

		[NonSerialized]
		private Component _agent;

		[NonSerialized]
		private IBlackboard _blackboard;

		[NonSerialized]
		private static List<Graph> runningGraphs = new List<Graph>();

		[NonSerialized]
		private float timeStarted;

		[NonSerialized]
		private bool _isRunning;

		[NonSerialized]
		private bool _isPaused;

		public event Action OnFinish
		{
			[MethodImpl(32)]
			add
			{
				this.OnFinish = (Action)Delegate.Combine(this.OnFinish, value);
			}
			[MethodImpl(32)]
			remove
			{
				this.OnFinish = (Action)Delegate.Remove(this.OnFinish, value);
			}
		}

		UnityEngine.Object ITaskSystem.baseObject
		{
			get
			{
				return this;
			}
		}

		public bool deserializationFailed
		{
			get
			{
				return this._deserializationFailed;
			}
		}

		public abstract Type baseNodeType
		{
			get;
		}

		public abstract bool requiresAgent
		{
			get;
		}

		public abstract bool requiresPrimeNode
		{
			get;
		}

		public abstract bool autoSort
		{
			get;
		}

		public new string name
		{
			get
			{
				return (!string.IsNullOrEmpty(this._name)) ? this._name : base.name;
			}
			set
			{
				this._name = value;
			}
		}

		public string graphComments
		{
			get
			{
				return this._comments;
			}
			set
			{
				this._comments = value;
			}
		}

		public float elapsedTime
		{
			get
			{
				return (!this.isRunning && !this.isPaused) ? 0f : (Time.time - this.timeStarted);
			}
		}

		public bool isRunning
		{
			get
			{
				return this._isRunning;
			}
			private set
			{
				this._isRunning = value;
			}
		}

		public bool isPaused
		{
			get
			{
				return this._isPaused;
			}
			private set
			{
				this._isPaused = value;
			}
		}

		public List<Node> allNodes
		{
			get
			{
				return this._nodes;
			}
			private set
			{
				this._nodes = value;
			}
		}

		public Node primeNode
		{
			get
			{
				return this._primeNode;
			}
			set
			{
				if (this._primeNode != value)
				{
					if (value != null && !value.allowAsPrime)
					{
						return;
					}
					if (this.isRunning)
					{
						if (this._primeNode != null)
						{
							this._primeNode.Reset(true);
						}
						if (value != null)
						{
							value.Reset(true);
						}
					}
					this.RecordUndo("Set Start");
					this._primeNode = value;
					this.UpdateNodeIDs(true);
				}
			}
		}

		public List<CanvasGroup> canvasGroups
		{
			get
			{
				return this._canvasGroups;
			}
			set
			{
				this._canvasGroups = value;
			}
		}

		public Vector2 translation
		{
			get
			{
				return this._translation;
			}
			set
			{
				this._translation = value;
			}
		}

		public Component agent
		{
			get
			{
				return this._agent;
			}
			set
			{
				if (!object.ReferenceEquals(this._agent, value))
				{
					this._agent = value;
					this.UpdateReferences();
				}
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
				if (!object.ReferenceEquals(this._blackboard, value))
				{
					this._blackboard = value;
					this.UpdateReferences();
				}
			}
		}

		public IBlackboard localBlackboard
		{
			get
			{
				if (this._localBlackboard == null)
				{
					this._localBlackboard = new BlackboardSource();
					this._localBlackboard.name = "Local Blackboard";
				}
				return this._localBlackboard;
			}
		}

		public void OnBeforeSerialize()
		{
			if (Application.isPlaying)
			{
				return;
			}
			this._serializedGraph = this.Serialize(false, this._objectReferences);
		}

		public void OnAfterDeserialize()
		{
			this.Deserialize(this._serializedGraph, this._objectReferences);
		}

		public string Serialize(bool pretyJson, List<UnityEngine.Object> objectReferences = null)
		{
			if (this._deserializationFailed)
			{
				this._deserializationFailed = false;
				return this._serializedGraph;
			}
			if (objectReferences == null)
			{
				objectReferences = (this._objectReferences = new List<UnityEngine.Object>());
			}
			else
			{
				objectReferences.Clear();
			}
			this.UpdateNodeIDs(true);
			return JSON.Serialize(typeof(GraphSerializationData), new GraphSerializationData(this), pretyJson, objectReferences);
		}

		public bool Deserialize(string serializedGraph, List<UnityEngine.Object> objectReferences = null)
		{
			if (string.IsNullOrEmpty(serializedGraph))
			{
				return false;
			}
			if (objectReferences == null)
			{
				objectReferences = this._objectReferences;
			}
			bool result;
			try
			{
				GraphSerializationData data = JSON.Deserialize<GraphSerializationData>(serializedGraph, objectReferences);
				if (this.LoadGraphData(data))
				{
					this._deserializationFailed = false;
					result = true;
				}
				else
				{
					this._deserializationFailed = true;
					result = false;
				}
			}
			catch (Exception ex)
			{
				Debug.LogError(string.Format("Deserialization Error: '{0}'\n'{1}'\nPlease report bug", ex.Message, ex.StackTrace), this);
				this._deserializationFailed = true;
				result = false;
			}
			return result;
		}

		private bool LoadGraphData(GraphSerializationData data)
		{
			if (data == null)
			{
				Debug.LogError("Can't Load graph, cause of null GraphSerializationData provided");
				return false;
			}
			if (data.type != base.GetType())
			{
				Debug.LogError("Can't Load graph, cause of different Graph type serialized and required");
				return false;
			}
			data.Reconstruct(this);
			this._name = data.name;
			this._comments = data.comments;
			this._translation = data.translation;
			this._nodes = data.nodes;
			this._primeNode = data.primeNode;
			this._canvasGroups = data.canvasGroups;
			this._localBlackboard = data.localBlackboard;
			this.Validate();
			return true;
		}

		public void CopySerialized(Graph target)
		{
			target.Deserialize(this.Serialize(false, target._objectReferences), null);
		}

		protected void OnEnable()
		{
			if (!Application.isPlaying)
			{
				this.OnValidate();
			}
		}

		protected void OnDisable()
		{
		}

		protected void OnDestroy()
		{
		}

		protected void OnValidate()
		{
			this.UpdateNodeIDs(true);
			this.UpdateReferences();
			foreach (Node current in this.allNodes)
			{
				current.OnValidate(this);
			}
			this.OnGraphValidate();
		}

		public void Validate()
		{
			this.OnValidate();
		}

		protected virtual void OnGraphValidate()
		{
		}

		public static T Clone<T>(T graph) where T : Graph
		{
			T result = UnityEngine.Object.Instantiate<T>(graph);
			result.name = result.name.Replace("(Clone)", string.Empty);
			return result;
		}

		public static List<Node> CopyNodesToGraph(List<Node> nodes, Graph targetGraph)
		{
			if (targetGraph == null)
			{
				return null;
			}
			List<Node> list = new List<Node>();
			Dictionary<Connection, KeyValuePair<int, int>> dictionary = new Dictionary<Connection, KeyValuePair<int, int>>();
			foreach (Node current in nodes)
			{
				Node node = current.Duplicate(targetGraph);
				list.Add(node);
				if (current == current.graph.primeNode && targetGraph != current.graph)
				{
					targetGraph.primeNode = node;
				}
				foreach (Connection current2 in current.outConnections)
				{
					dictionary[current2] = new KeyValuePair<int, int>(nodes.IndexOf(current2.sourceNode), nodes.IndexOf(current2.targetNode));
				}
			}
			foreach (KeyValuePair<Connection, KeyValuePair<int, int>> current3 in dictionary)
			{
				if (current3.Value.Value != -1)
				{
					Node newSource = list[current3.Value.Key];
					Node newTarget = list[current3.Value.Value];
					current3.Key.Duplicate(newSource, newTarget);
				}
			}
			foreach (Node current4 in list)
			{
				current4.OnValidate(targetGraph);
			}
			return list;
		}

		private void UpdateReferences()
		{
			this.UpdateNodeBBFields();
			this.SendTaskOwnerDefaults();
		}

		private void UpdateNodeBBFields()
		{
			foreach (Node current in this.allNodes)
			{
				BBParameter.SetBBFields(current, this.blackboard);
			}
		}

		public void SendTaskOwnerDefaults()
		{
			foreach (Task current in this.GetAllTasksOfType<Task>())
			{
				current.SetOwnerSystem(this);
			}
		}

		public void SendEvent(EventData eventData)
		{
			if (eventData != null && this.isRunning && this.agent != null)
			{
				this.agent.gameObject.SendMessage("OnCustomEvent", eventData, SendMessageOptions.DontRequireReceiver);
			}
		}

		public static void SendGlobalEvent(string name)
		{
			Graph.SendGlobalEvent(new EventData(name));
		}

		public static void SendGlobalEvent<T>(string name, T value)
		{
			Graph.SendGlobalEvent(new EventData<T>(name, value));
		}

		public static void SendGlobalEvent(EventData eventData)
		{
			foreach (Graph current in Graph.runningGraphs)
			{
				current.SendEvent(eventData);
			}
		}

		public void SendTaskMessage(string name, object argument = null)
		{
			foreach (Task current in this.GetAllTasksOfType<Task>())
			{
				MethodInfo methodInfo = current.GetType().RTGetMethod(name, false);
				if (methodInfo != null)
				{
					object arg_4A_0;
					if (methodInfo.GetParameters().Length == 0)
					{
						arg_4A_0 = null;
					}
					else
					{
						(arg_4A_0 = new object[1])[0] = argument;
					}
					object[] parameters = arg_4A_0;
					methodInfo.Invoke(current, parameters);
				}
			}
		}

		public void StartGraph(Component agent, IBlackboard blackboard, Action callback = null)
		{
			if (this.isRunning)
			{
				if (callback != null)
				{
					this.OnFinish = (Action)Delegate.Combine(this.OnFinish, callback);
				}
				Debug.LogWarning("<b>Graph:</b> Graph is already Active");
				return;
			}
			if (agent == null && this.requiresAgent)
			{
				Debug.LogWarning("<b>Graph:</b> You've tried to start a graph with null Agent.");
				return;
			}
			if (this.primeNode == null && this.requiresPrimeNode)
			{
				Debug.LogWarning("<b>Graph:</b> You've tried to start graph without 'Start' node");
				return;
			}
			if (blackboard == null)
			{
				if (agent != null)
				{
					Debug.Log("<b>Graph:</b> Graph started without blackboard. Looking for blackboard on agent '" + agent.gameObject + "'...", agent.gameObject);
					blackboard = (agent.GetComponent(typeof(IBlackboard)) as IBlackboard);
					if (blackboard != null)
					{
						Debug.Log("<b>Graph:</b> Blackboard found");
					}
				}
				if (blackboard == null)
				{
					Debug.LogWarning("<b>Graph:</b> Started with null Blackboard. Using Local instead...");
					blackboard = this.localBlackboard;
				}
			}
			this.UpdateNodeIDs(true);
			if (this.blackboard != blackboard || this.blackboard == null)
			{
				this.blackboard = blackboard;
			}
			if (this.agent != agent || this.agent == null)
			{
				this.agent = agent;
			}
			if (callback != null)
			{
				this.OnFinish = callback;
			}
			this.isRunning = true;
			if (!this.isPaused)
			{
				this.timeStarted = Time.time;
				foreach (Node current in this.allNodes)
				{
					current.OnGraphStarted();
				}
			}
			this.isPaused = false;
			Graph.runningGraphs.Add(this);
			MonoManager.AddMethod(new Action(this.OnGraphUpdate));
			this.OnGraphStarted();
		}

		public void Stop()
		{
			if (!this.isRunning && !this.isPaused)
			{
				return;
			}
			Graph.runningGraphs.Remove(this);
			MonoManager.RemoveMethod(new Action(this.OnGraphUpdate));
			this.isRunning = false;
			this.isPaused = false;
			this.OnGraphStoped();
			foreach (Node current in this.allNodes)
			{
				current.Reset(false);
				current.OnGraphStoped();
			}
			if (this.OnFinish != null)
			{
				this.OnFinish();
				this.OnFinish = null;
			}
		}

		public void Pause()
		{
			if (!this.isRunning)
			{
				return;
			}
			Graph.runningGraphs.Remove(this);
			MonoManager.RemoveMethod(new Action(this.OnGraphUpdate));
			this.isRunning = false;
			this.isPaused = true;
			this.OnGraphPaused();
			foreach (Node current in this.allNodes)
			{
				current.OnGraphPaused();
			}
		}

		protected virtual void OnGraphStarted()
		{
		}

		protected virtual void OnGraphUpdate()
		{
		}

		protected virtual void OnGraphStoped()
		{
		}

		protected virtual void OnGraphPaused()
		{
		}

		public Node GetNodeWithID(int searchID)
		{
			if (searchID <= this.allNodes.Count && searchID >= 0)
			{
				return this.allNodes.Find((Node n) => n.ID == searchID);
			}
			return null;
		}

		public List<T> GetAllNodesOfType<T>() where T : Node
		{
			return this.allNodes.OfType<T>().ToList<T>();
		}

		public T GetNodeWithTag<T>(string name) where T : Node
		{
			foreach (T current in this.allNodes.OfType<T>())
			{
				if (current.tag == name)
				{
					return current;
				}
			}
			return (T)((object)null);
		}

		public List<T> GetNodesWithTag<T>(string name) where T : Node
		{
			List<T> list = new List<T>();
			foreach (T current in this.allNodes.OfType<T>())
			{
				if (current.tag == name)
				{
					list.Add(current);
				}
			}
			return list;
		}

		public List<T> GetAllTagedNodes<T>() where T : Node
		{
			List<T> list = new List<T>();
			foreach (T current in this.allNodes.OfType<T>())
			{
				if (!string.IsNullOrEmpty(current.tag))
				{
					list.Add(current);
				}
			}
			return list;
		}

		public T GetNodeWithName<T>(string name) where T : Node
		{
			foreach (T current in this.allNodes.OfType<T>())
			{
				if (this.StripNameColor(current.name).ToLower() == name.ToLower())
				{
					return current;
				}
			}
			return (T)((object)null);
		}

		private string StripNameColor(string name)
		{
			if (name.StartsWith("<") && name.EndsWith(">"))
			{
				name = name.Replace(name.Substring(0, name.IndexOf(">") + 1), string.Empty);
				name = name.Replace(name.Substring(name.IndexOf("<"), name.LastIndexOf(">") + 1 - name.IndexOf("<")), string.Empty);
			}
			return name;
		}

		public List<Node> GetRootNodes()
		{
			return (from n in this.allNodes
			where n.inConnections.Count == 0
			select n).ToList<Node>();
		}

		public List<T> GetAllNestedGraphs<T>(bool recursive) where T : Graph
		{
			List<T> list = new List<T>();
			foreach (IGraphAssignable current in this.allNodes.OfType<IGraphAssignable>())
			{
				if (current.nestedGraph is T)
				{
					if (!list.Contains((T)((object)current.nestedGraph)))
					{
						list.Add((T)((object)current.nestedGraph));
					}
					if (recursive)
					{
						list.AddRange(current.nestedGraph.GetAllNestedGraphs<T>(recursive));
					}
				}
			}
			return list;
		}

		public List<T> GetAllTasksOfType<T>() where T : Task
		{
			List<Task> list = new List<Task>();
			List<T> list2 = new List<T>();
			foreach (Node current in this.allNodes)
			{
				if (current is ITaskAssignable && (current as ITaskAssignable).task != null)
				{
					list.Add((current as ITaskAssignable).task);
				}
				if (current is ISubTasksContainer)
				{
					list.AddRange((current as ISubTasksContainer).GetTasks());
				}
				foreach (Connection current2 in current.outConnections)
				{
					if (current2 is ITaskAssignable && (current2 as ITaskAssignable).task != null)
					{
						list.Add((current2 as ITaskAssignable).task);
					}
					if (current2 is ISubTasksContainer)
					{
						list.AddRange((current2 as ISubTasksContainer).GetTasks());
					}
				}
			}
			foreach (Task current3 in list)
			{
				if (current3 is ActionList)
				{
					list2.AddRange((current3 as ActionList).actions.OfType<T>());
				}
				if (current3 is ConditionList)
				{
					list2.AddRange((current3 as ConditionList).conditions.OfType<T>());
				}
				if (current3 is T)
				{
					list2.Add((T)((object)current3));
				}
			}
			return list2;
		}

		public BBParameter[] GetDefinedParameters()
		{
			List<BBParameter> bbParams = new List<BBParameter>();
			List<object> list = new List<object>();
			list.AddRange(this.GetAllTasksOfType<Task>().Cast<object>());
			list.AddRange(this.allNodes.Cast<object>());
			foreach (object current in list)
			{
				if (current is Task)
				{
					Task task = (Task)current;
					if (task.agentIsOverride && !string.IsNullOrEmpty(task.overrideAgentParameterName))
					{
						bbParams.Add(typeof(Task).RTGetField("overrideAgent", true).GetValue(task) as BBParameter);
					}
				}
				BBParameter.ParseObject(current, delegate(BBParameter bbParam)
				{
					if (bbParam != null && bbParam.useBlackboard && !bbParam.isNone)
					{
						bbParams.Add(bbParam);
					}
				});
			}
			return bbParams.ToArray();
		}

		public void CreateDefinedParameterVariables(IBlackboard bb)
		{
			BBParameter[] definedParameters = this.GetDefinedParameters();
			for (int i = 0; i < definedParameters.Length; i++)
			{
				BBParameter bBParameter = definedParameters[i];
				bb.AddVariable(bBParameter.name, bBParameter.varType);
			}
			this.UpdateReferences();
		}

		public void UpdateNodeIDs(bool alsoReorderList)
		{
			int lastID = 0;
			if (this.primeNode != null)
			{
				lastID = this.primeNode.AssignIDToGraph(lastID);
			}
			for (int i = 0; i < this.allNodes.Count; i++)
			{
				if (this.allNodes[i].inConnections.Count == 0)
				{
					lastID = this.allNodes[i].AssignIDToGraph(lastID);
				}
			}
			for (int j = 0; j < this.allNodes.Count; j++)
			{
				this.allNodes[j].ResetRecursion();
			}
			if (alsoReorderList)
			{
				this.allNodes = (from node in this.allNodes
				orderby node.ID
				select node).ToList<Node>();
			}
		}

		public T AddNode<T>() where T : Node
		{
			return (T)((object)this.AddNode(typeof(T)));
		}

		public T AddNode<T>(Vector2 pos) where T : Node
		{
			return (T)((object)this.AddNode(typeof(T), pos));
		}

		public Node AddNode(Type nodeType)
		{
			return this.AddNode(nodeType, new Vector2(50f, 50f));
		}

		public Node AddNode(Type nodeType, Vector2 pos)
		{
			if (!nodeType.RTIsSubclassOf(this.baseNodeType))
			{
				Debug.LogWarning(string.Concat(new object[]
				{
					nodeType,
					" can't be added to ",
					base.GetType().FriendlyName(),
					" graph"
				}));
				return null;
			}
			Node node = Node.Create(this, nodeType, pos);
			this.RecordUndo("New Node");
			this.allNodes.Add(node);
			if (this.primeNode == null)
			{
				this.primeNode = node;
			}
			this.UpdateNodeIDs(false);
			return node;
		}

		public void RemoveNode(Node node)
		{
			if (!this.allNodes.Contains(node))
			{
				Debug.LogWarning("Node is not part of this graph");
				return;
			}
			node.OnDestroy();
			Connection[] array = node.inConnections.ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				Connection connection = array[i];
				this.RemoveConnection(connection);
			}
			Connection[] array2 = node.outConnections.ToArray();
			for (int j = 0; j < array2.Length; j++)
			{
				Connection connection2 = array2[j];
				this.RemoveConnection(connection2);
			}
			this.RecordUndo("Delete Node");
			this.allNodes.Remove(node);
			if (node == this.primeNode)
			{
				this.primeNode = this.GetNodeWithID(2);
			}
			this.UpdateNodeIDs(false);
		}

		public Connection ConnectNodes(Node sourceNode, Node targetNode)
		{
			return this.ConnectNodes(sourceNode, targetNode, sourceNode.outConnections.Count);
		}

		public Connection ConnectNodes(Node sourceNode, Node targetNode, int indexToInsert)
		{
			if (!targetNode.IsNewConnectionAllowed(sourceNode))
			{
				return null;
			}
			this.RecordUndo("New Connection");
			Connection connection = Connection.Create(sourceNode, targetNode, indexToInsert);
			sourceNode.OnChildConnected(indexToInsert);
			targetNode.OnParentConnected(targetNode.inConnections.IndexOf(connection));
			this.UpdateNodeIDs(false);
			return connection;
		}

		public void RemoveConnection(Connection connection)
		{
			if (Application.isPlaying)
			{
				connection.Reset(true);
			}
			this.RecordUndo("Delete Connection");
			connection.OnDestroy();
			connection.sourceNode.OnChildDisconnected(connection.sourceNode.outConnections.IndexOf(connection));
			connection.targetNode.OnParentDisconnected(connection.targetNode.inConnections.IndexOf(connection));
			connection.sourceNode.outConnections.Remove(connection);
			connection.targetNode.inConnections.Remove(connection);
			this.UpdateNodeIDs(false);
		}

		private void RecordUndo(string name)
		{
		}
	}
}
