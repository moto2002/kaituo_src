using NodeCanvas.Framework;
using System;

namespace NodeCanvas.BehaviourTrees
{
	public abstract class BTDecorator : BTNode
	{
		public sealed override int maxOutConnections
		{
			get
			{
				return 1;
			}
		}

		public sealed override bool showCommentsBottom
		{
			get
			{
				return false;
			}
		}

		protected Connection decoratedConnection
		{
			get
			{
				Connection result;
				try
				{
					result = base.outConnections[0];
				}
				catch
				{
					result = null;
				}
				return result;
			}
		}

		protected Node decoratedNode
		{
			get
			{
				Node result;
				try
				{
					result = base.outConnections[0].targetNode;
				}
				catch
				{
					result = null;
				}
				return result;
			}
		}
	}
}
