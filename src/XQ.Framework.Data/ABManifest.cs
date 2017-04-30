using System;
using System.Collections.Generic;
using UnityEngine;

namespace XQ.Framework.Data
{
	public class ABManifest : ResourceRef
	{
		public class DependRef
		{
			public string PKGFile;

			public string DependName;
		}

		public bool NoData;

		public bool UseDataDir;

		public bool IsPacth;

		public string PKGFile;

		public GameObject Panel;

		public List<ABManifest.DependRef> DependRefList;

		public override void Clear(string objectKey)
		{
			base.Clear(objectKey);
			this.Panel = null;
		}
	}
}
