using System;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Tools.Script.Helper
{
	public static class CollectionHelper
	{
		public static T[] FindAll<T>(this T[] array, Func<T, bool> meet)
		{
			List<T> list = new List<T>();
			for (int i = 0; i < array.Length; i++)
			{
				T t = array[i];
				if (meet(t))
				{
					list.Add(t);
				}
			}
			return list.ToArray();
		}

		public static List<T> WhereValue<T>(this List<T> listsrc, Func<T, bool> meet)
		{
			List<T> list = new List<T>();
			foreach (T current in listsrc)
			{
				if (meet(current))
				{
					list.Add(current);
				}
			}
			return list;
		}

		public static T FirstOrDefaultValue<T>(this IEnumerable<T> listsrc, Func<T, bool> meet)
		{
			foreach (T current in listsrc)
			{
				if (meet(current))
				{
					return current;
				}
			}
			return default(T);
		}

		public static bool AnyValue<T>(this IEnumerable<T> listsrc, T value)
		{
			foreach (T current in listsrc)
			{
				if (object.Equals(current, value))
				{
					return true;
				}
			}
			return false;
		}

		public static bool AllValue<T>(this IEnumerable<T> listsrc, T value)
		{
			foreach (T current in listsrc)
			{
				if (!object.Equals(current, value))
				{
					return false;
				}
			}
			return true;
		}

		public static bool AnyValue<T>(this IEnumerable<T> listsrc, Func<T, bool> meet)
		{
			foreach (T current in listsrc)
			{
				if (meet(current))
				{
					return true;
				}
			}
			return false;
		}

		public static bool AllValue<T>(this IEnumerable<T> listsrc, Func<T, bool> meet)
		{
			foreach (T current in listsrc)
			{
				if (!meet(current))
				{
					return false;
				}
			}
			return true;
		}

		public static bool ContainsValue<T>(this IEnumerable<T> listsrc, Func<T, bool> meet)
		{
			foreach (T current in listsrc)
			{
				if (meet(current))
				{
					return true;
				}
			}
			return false;
		}

		public static bool ContainsValue<T>(this IEnumerable<T> listsrc, T value)
		{
			foreach (T current in listsrc)
			{
				if (object.Equals(current, value))
				{
					return true;
				}
			}
			return false;
		}

		public static bool ContainsValue<T>(this T[] listsrc, T value)
		{
			for (int i = 0; i < listsrc.Length; i++)
			{
				T t = listsrc[i];
				if (object.Equals(t, value))
				{
					return true;
				}
			}
			return false;
		}

		public static List<T> CopyList<T>(this List<T> listsrc)
		{
			List<T> list = new List<T>();
			for (int i = 0; i < listsrc.Count; i++)
			{
				list.Add(listsrc[i]);
			}
			return list;
		}

		public static List<T> CopyIEnumerableToList<T>(this IEnumerable<T> listsrc)
		{
			List<T> list = new List<T>();
			foreach (T current in listsrc)
			{
				list.Add(current);
			}
			return list;
		}

		public static void RemoveAts<T>(this List<T> src, List<int> indexs)
		{
			indexs.Sort();
			for (int i = 0; i < indexs.Count; i++)
			{
				indexs[i] -= i;
			}
			for (int j = 0; j < indexs.Count; j++)
			{
				src.RemoveAt(indexs[j]);
			}
		}

		public static T[] Add<T>(this T[] src, T[] src2)
		{
			T[] array = new T[src.Length + src2.Length];
			int num = 0;
			for (int i = 0; i < src.Length; i++)
			{
				array[num++] = src[i];
			}
			for (int j = 0; j < src2.Length; j++)
			{
				array[num++] = src2[j];
			}
			return array;
		}

		public static void Append(this IDictionary target, IDictionary src)
		{
			foreach (object current in src.Keys)
			{
				try
				{
					target.Add(current, src[current]);
				}
				catch (Exception var_2_2B)
				{
				}
			}
		}

		public static List<TKey> Subtract<TKey, TValue, TValueB>(this Dictionary<TKey, TValue> target, Dictionary<TKey, TValueB> subtrahend)
		{
			List<TKey> list = new List<TKey>();
			foreach (TKey current in target.Keys)
			{
				if (!subtrahend.ContainsKey(current))
				{
					list.Add(current);
				}
			}
			return list;
		}

		public static List<TKey> Intersection<TKey, TValue, TValueB>(this Dictionary<TKey, TValue> target, Dictionary<TKey, TValueB> other)
		{
			List<TKey> list = new List<TKey>();
			foreach (TKey current in target.Keys)
			{
				if (other.ContainsKey(current))
				{
					list.Add(current);
				}
			}
			return list;
		}

		public static List<TKey> DifferentThan<TKey, TValue, TValueB>(this Dictionary<TKey, TValue> target, Dictionary<TKey, TValueB> contrast)
		{
			List<TKey> list = new List<TKey>();
			foreach (TKey current in target.Keys)
			{
				if (contrast.ContainsKey(current))
				{
					TValueB tValueB = contrast[current];
					if (tValueB.Equals(target[current]))
					{
						list.Add(current);
					}
				}
			}
			return list;
		}

		public static void GetChangeList<T>(List<T> oldList, List<T> newList, out List<T> addList, out List<T> deleteList, out List<T> holdList, Func<T, T, bool> isEqual)
		{
			CollectionHelper.<GetChangeList>c__AnonStorey69<T> <GetChangeList>c__AnonStorey = new CollectionHelper.<GetChangeList>c__AnonStorey69<T>();
			<GetChangeList>c__AnonStorey.isEqual = isEqual;
			addList = new List<T>();
			deleteList = new List<T>();
			holdList = new List<T>();
			T oldElm;
			using (List<T>.Enumerator enumerator = oldList.GetEnumerator())
			{
				T newElm;
				while (enumerator.MoveNext())
				{
					oldElm = enumerator.Current;
					bool flag = newList.Count != 0 && newList.AnyValue((T newElm) => <GetChangeList>c__AnonStorey.isEqual(oldElm, newElm));
					if (flag)
					{
						holdList.Add(oldElm);
					}
					else
					{
						deleteList.Add(oldElm);
					}
				}
			}
			foreach (T newElm in newList)
			{
				T newElm;
				if (oldList.Count == 0 || !oldList.AnyValue((T oldElm) => <GetChangeList>c__AnonStorey.isEqual(oldElm, newElm)))
				{
					addList.Add(newElm);
				}
			}
		}

		public static T GetFirstKey<T, V>(this IDictionary<T, V> dic)
		{
			using (IEnumerator<T> enumerator = dic.Keys.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					return enumerator.Current;
				}
			}
			return default(T);
		}

		public static V GetFirstValue<T, V>(this IDictionary<T, V> dic)
		{
			using (IEnumerator<V> enumerator = dic.Values.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					return enumerator.Current;
				}
			}
			return default(V);
		}
	}
}
