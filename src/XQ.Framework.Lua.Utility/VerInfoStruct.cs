using System;
using System.IO;

namespace XQ.Framework.Lua.Utility
{
	public class VerInfoStruct
	{
		public string curVer;

		public string verUrl;

		public string patchUrl;

		public bool editorNoUpdate;

		public bool noVerInfo;

		public long patchFileVer;

		public string zipFileVer;

		public static int VER_POS = 1;

		public static int URL_POS = 2;

		public static int FILE_VER_POS = 3;

		public static VerInfoStruct New(bool tmp = false)
		{
			return new VerInfoStruct
			{
				editorNoUpdate = tmp,
				noVerInfo = tmp
			};
		}

		public void UpdateURL(string url)
		{
			this.verUrl = Path.Combine(url, this.verUrl.Substring(this.verUrl.LastIndexOf('/') + 1)).Replace("\\", "/");
			this.patchUrl = Path.Combine(url, "patch").Replace("\\", "/");
		}

		public string GetPatchFileURL(string ver)
		{
			return Path.Combine(this.patchUrl, string.Format("patch_{0}_{1}.zip", ver, ver.CRCHash(false, 1012))).Replace("\\", "/");
		}

		public string FullSetupVersion(string ver)
		{
			return (!ver.EndsWith("_full", StringComparison.OrdinalIgnoreCase)) ? null : ver.Substring(0, ver.LastIndexOf('_'));
		}

		public string GetVersion(string ver)
		{
			return (!ver.EndsWith("_full")) ? ver : ver.Substring(0, ver.LastIndexOf('_'));
		}
	}
}
