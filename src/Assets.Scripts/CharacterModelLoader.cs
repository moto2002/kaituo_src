using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
	public class CharacterModelLoader
	{
		public const string UnitPrefix = "Unit_instanceId_";

		private static Dictionary<string, GameObject> loaded = new Dictionary<string, GameObject>();

		public static string GetUnitName(int instanceId)
		{
			return string.Format("{0}{1}", "Unit_instanceId_", instanceId);
		}

		public static void LoadUnit(int instanceId, Action<RpgCharacter> onLoadComplete)
		{
		}

		public static void LoadUnit(int instanceId, string resPath, Action<RpgCharacter> onLoadComplete)
		{
			string unitName = CharacterModelLoader.GetUnitName(instanceId);
			CharacterModelLoader.LoadUnit(unitName, resPath, delegate(RpgCharacter character)
			{
				character.InstanceId = instanceId;
				onLoadComplete(character);
			});
		}

		public static void LoadUnit(string characterName, string resPath, Action<RpgCharacter> onLoadComplete)
		{
		}
	}
}
