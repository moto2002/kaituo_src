using ParadoxNotion.Design;
using System;

namespace NodeCanvas.Framework.Internal
{
	[Description("Please resolve the MissingNode issue by either replacing the node or importing the missing node type in the project"), DoNotList]
	public sealed class MissingNode : Node
	{
		public string missingType;

		public string recoveryState;

		public override string name
		{
			get
			{
				return string.Format("<color=#ff6457>{0}</color>", "! Missing Node !");
			}
		}

		public override Type outConnectionType
		{
			get
			{
				return null;
			}
		}

		public override int maxInConnections
		{
			get
			{
				return 0;
			}
		}

		public override int maxOutConnections
		{
			get
			{
				return 0;
			}
		}

		public override bool allowAsPrime
		{
			get
			{
				return false;
			}
		}

		public override bool showCommentsBottom
		{
			get
			{
				return false;
			}
		}
	}
}
