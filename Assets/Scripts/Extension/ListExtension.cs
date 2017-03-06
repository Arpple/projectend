using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class ListExtension
{
	/// <summary>
	/// Shuffle the specified list.
	/// implement Fish-Yates shuffle algorithm
	/// <see href="https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle"/>
	/// </summary>
	/// <param name="list">List.</param>
	/// <typeparam name="T">The 1st type parameter.</typeparam>
	public static List<T> Shuffle<T>(this List<T> list)
	{
		for(int i = list.Count - 1; i > 0; i--)
		{
			int j = Random.Range(0,i);
			list.Swap(i, j);
		}
		return list;
	}

	public static List<T> Swap<T>(this List<T> list, int index1, int index2)
	{
		T temp = list[index1];
		list[index1] = list[index2];
		list[index2] = temp;
		return list;
	}
}
