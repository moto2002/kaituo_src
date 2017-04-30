using System;
using System.Collections.Generic;
using UnityEngine;

namespace NodeCanvas.Framework.Internal
{
	public class GraphSerializationData
	{
		private readonly float SerializationVersion = 2.2f;

		public float version;

		public Type type;

		public string name;

		public string comments;

		public Vector2 translation;

		public List<Node> nodes;

		public List<Connection> connections;

		public Node primeNode;

		public List<NodeCanvas.Framework.CanvasGroup> canvasGroups;

		public IBlackboard localBlackboard;

		public GraphSerializationData()
		{
		}

		public GraphSerializationData(Graph graph)
		{
			this.version = this.SerializationVersion;
			this.type = graph.GetType();
			this.name = graph.name;
			this.comments = graph.graphComments;
			this.translation = graph.translation;
			this.nodes = graph.allNodes;
			this.canvasGroups = graph.canvasGroups;
			this.localBlackboard = graph.localBlackboard;
			List<Connection> list = new List<Connection>();
			foreach (Node current in this.nodes)
			{
				if (current is ISerializationCallbackReceiver)
				{
					(current as ISerializationCallbackReceiver).OnBeforeSerialize();
				}
				foreach (Connection current2 in current.outConnections)
				{
					list.Add(current2);
				}
			}
			this.connections = list;
			this.primeNode = graph.primeNode;
		}

		public void Reconstruct(Graph graph)
		{
			foreach (Connection current in this.connections)
			{
				current.sourceNode.outConnections.Add(current);
				current.targetNode.inConnections.Add(current);
			}
			foreach (Node current2 in this.nodes)
			{
				current2.graph = graph;
				if (current2 is ISerializationCallbackReceiver)
				{
					(current2 as ISerializationCallbackReceiver).OnAfterDeserialize();
				}
			}
		}
	}
}
