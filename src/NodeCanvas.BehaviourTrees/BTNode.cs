using NodeCanvas.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NodeCanvas.BehaviourTrees
{
	public abstract class BTNode : Node
	{
		public sealed override Type outConnectionType
		{
			get
			{
				return typeof(BTConnection);
			}
		}

		public sealed override int maxInConnections
		{
			get
			{
				return 1;
			}
		}

		public override int maxOutConnections
		{
			get
			{
				return 0;
			}
		}

		public sealed override bool allowAsPrime
		{
			get
			{
				return true;
			}
		}

		public override bool showCommentsBottom
		{
			get
			{
				return true;
			}
		}

		public T AddChild<T>(int childIndex) where T : BTNode
		{
			if (base.outConnections.Count >= this.maxOutConnections && this.maxOutConnections != -1)
			{
				return (T)((object)null);
			}
			T t = base.graph.AddNode<T>();
			base.graph.ConnectNodes(this, t, childIndex);
			return t;
		}

		public T AddChild<T>() where T : BTNode
		{
			if (base.outConnections.Count >= this.maxOutConnections && this.maxOutConnections != -1)
			{
				return (T)((object)null);
			}
			T t = base.graph.AddNode<T>();
			base.graph.ConnectNodes(this, t);
			return t;
		}

		public List<BTNode> GetAllChildNodesRecursively(bool includeThis)
		{
			List<BTNode> list = new List<BTNode>();
			if (includeThis)
			{
				list.Add(this);
			}
			using (IEnumerator<Node> enumerator = (from c in base.outConnections
			select c.targetNode).GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					BTNode bTNode = (BTNode)enumerator.Current;
					list.AddRange(bTNode.GetAllChildNodesRecursively(true));
				}
			}
			return list;
		}

		public Dictionary<BTNode, int> GetAllChildNodesWithDepthRecursively(bool includeThis, int startIndex)
		{
			Dictionary<BTNode, int> dictionary = new Dictionary<BTNode, int>();
			if (includeThis)
			{
				dictionary[this] = startIndex;
			}
			using (IEnumerator<Node> enumerator = (from c in base.outConnections
			select c.targetNode).GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					BTNode bTNode = (BTNode)enumerator.Current;
					foreach (KeyValuePair<BTNode, int> current in bTNode.GetAllChildNodesWithDepthRecursively(true, startIndex + 1))
					{
						dictionary[current.Key] = current.Value;
					}
				}
			}
			return dictionary;
		}
	}
}
