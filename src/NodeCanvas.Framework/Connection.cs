using NodeCanvas.Framework.Internal;
using ParadoxNotion.Serialization;
using System;
using UnityEngine;

namespace NodeCanvas.Framework
{
	public abstract class Connection
	{
		[SerializeField]
		private Node _sourceNode;

		[SerializeField]
		private Node _targetNode;

		[SerializeField]
		private bool _isActive = true;

		[NonSerialized]
		private Status _status = Status.Resting;

		public Node sourceNode
		{
			get
			{
				return this._sourceNode;
			}
			protected set
			{
				this._sourceNode = value;
			}
		}

		public Node targetNode
		{
			get
			{
				return this._targetNode;
			}
			protected set
			{
				this._targetNode = value;
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
				if (this._isActive && !value)
				{
					this.Reset(true);
				}
				this._isActive = value;
			}
		}

		public Status connectionStatus
		{
			get
			{
				return this._status;
			}
			set
			{
				this._status = value;
			}
		}

		protected Graph graph
		{
			get
			{
				return this.sourceNode.graph;
			}
		}

		public Connection()
		{
		}

		public static Connection Create(Node source, Node target, int sourceIndex)
		{
			if (source == null || target == null)
			{
				Debug.LogError("Can't Create a Connection without providing Source and Target Nodes");
				return null;
			}
			if (source is MissingNode)
			{
				Debug.LogError("Creating new Connections from a 'MissingNode' is not allowed. Please resolve the MissingNode node first");
				return null;
			}
			Connection connection = (Connection)Activator.CreateInstance(source.outConnectionType);
			connection.sourceNode = source;
			connection.targetNode = target;
			source.outConnections.Insert(sourceIndex, connection);
			target.inConnections.Add(connection);
			connection.OnValidate(sourceIndex, target.inConnections.IndexOf(connection));
			return connection;
		}

		public Connection Duplicate(Node newSource, Node newTarget)
		{
			if (newSource == null || newTarget == null)
			{
				Debug.LogError("Can't Duplicate a Connection without providing NewSource and NewTarget Nodes");
				return null;
			}
			Connection connection = JSON.Deserialize<Connection>(JSON.Serialize(typeof(Connection), this, false, null), null);
			connection.SetSource(newSource);
			connection.SetTarget(newTarget);
			ITaskAssignable taskAssignable = this as ITaskAssignable;
			if (taskAssignable != null && taskAssignable.task != null)
			{
				(connection as ITaskAssignable).task = taskAssignable.task.Duplicate(this.graph);
			}
			connection.OnValidate(newSource.outConnections.IndexOf(connection), newTarget.inConnections.IndexOf(connection));
			return connection;
		}

		public virtual void OnValidate(int sourceIndex, int targetIndex)
		{
		}

		public virtual void OnDestroy()
		{
		}

		public void SetSource(Node newSource)
		{
			newSource.outConnections.Add(this);
			this.sourceNode.outConnections.Remove(this);
			this.sourceNode = newSource;
		}

		public void SetTarget(Node newTarget)
		{
			newTarget.inConnections.Add(this);
			this.targetNode.inConnections.Remove(this);
			this.targetNode = newTarget;
		}

		public Status Execute(Component agent, IBlackboard blackboard)
		{
			if (!this.isActive)
			{
				return Status.Resting;
			}
			this.connectionStatus = this.targetNode.Execute(agent, blackboard);
			return this.connectionStatus;
		}

		public void Reset(bool recursively = true)
		{
			if (this.connectionStatus == Status.Resting)
			{
				return;
			}
			this.connectionStatus = Status.Resting;
			if (recursively)
			{
				this.targetNode.Reset(recursively);
			}
		}
	}
}
