using System;
using System.Collections.Generic;
using UnityEngine;

public static class LayerMaskExtension
{
	public static Dictionary<uint, int> ValueToLayer = new Dictionary<uint, int>
	{
		{
			1u,
			0
		},
		{
			2u,
			1
		},
		{
			4u,
			2
		},
		{
			8u,
			3
		},
		{
			16u,
			4
		},
		{
			32u,
			5
		},
		{
			64u,
			6
		},
		{
			128u,
			7
		},
		{
			256u,
			8
		},
		{
			512u,
			9
		},
		{
			1024u,
			10
		},
		{
			2048u,
			11
		},
		{
			4096u,
			12
		},
		{
			8192u,
			13
		},
		{
			16384u,
			14
		},
		{
			32768u,
			15
		},
		{
			65536u,
			16
		},
		{
			131072u,
			17
		},
		{
			262144u,
			18
		},
		{
			524288u,
			19
		},
		{
			1048576u,
			20
		},
		{
			2097152u,
			21
		},
		{
			4194304u,
			22
		},
		{
			8388608u,
			23
		},
		{
			16777216u,
			24
		},
		{
			33554432u,
			25
		},
		{
			67108864u,
			26
		},
		{
			134217728u,
			27
		},
		{
			268435456u,
			28
		},
		{
			536870912u,
			29
		},
		{
			1073741824u,
			30
		},
		{
			2147483648u,
			31
		}
	};

	public static LayerMask Create(params string[] layerNames)
	{
		return LayerMaskExtension.NamesToMask(layerNames);
	}

	public static LayerMask Create(params int[] layerNumbers)
	{
		return LayerMaskExtension.LayerNumbersToMask(layerNumbers);
	}

	public static LayerMask NamesToMask(params string[] layerNames)
	{
		LayerMask layerMask = 0;
		for (int i = 0; i < layerNames.Length; i++)
		{
			string layerName = layerNames[i];
			layerMask |= 1 << LayerMask.NameToLayer(layerName);
		}
		return layerMask;
	}

	public static LayerMask LayerNumbersToMask(params int[] layerNumbers)
	{
		LayerMask layerMask = 0;
		for (int i = 0; i < layerNumbers.Length; i++)
		{
			int num = layerNumbers[i];
			layerMask |= 1 << num;
		}
		return layerMask;
	}

	public static LayerMask Inverse(this LayerMask original)
	{
		return ~original;
	}

	public static LayerMask AddToMask(this LayerMask original, params string[] layerNames)
	{
		return original | LayerMaskExtension.NamesToMask(layerNames);
	}

	public static LayerMask RemoveFromMask(this LayerMask original, params string[] layerNames)
	{
		LayerMask mask = ~original;
		return ~(mask | LayerMaskExtension.NamesToMask(layerNames));
	}

	public static LayerMask RemoveFromMask(this LayerMask original, int layer)
	{
		LayerMask mask = ~original;
		return ~(mask | layer);
	}

	public static LayerMask RemoveFromMask(int original, int layer)
	{
		LayerMask mask = ~original;
		return ~(mask | layer);
	}

	public static string[] MaskToNames(this LayerMask original)
	{
		List<string> list = new List<string>();
		for (int i = 0; i < 32; i++)
		{
			int num = 1 << i;
			if ((original & num) == num)
			{
				string text = LayerMask.LayerToName(i);
				if (!string.IsNullOrEmpty(text))
				{
					list.Add(text);
				}
			}
		}
		return list.ToArray();
	}

	public static string MaskToString(this LayerMask original)
	{
		return original.MaskToString(", ");
	}

	public static string MaskToString(this LayerMask original, string delimiter)
	{
		return string.Join(delimiter, original.MaskToNames());
	}

	public static bool IsInLayerMask(this GameObject obj, LayerMask mask)
	{
		return (mask.value & 1 << obj.layer) > 0;
	}
}
