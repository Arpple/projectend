﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class ArrayExtension
{
	/// <summary>
	/// Shuffle the specified list.
	/// implement Fish-Yates shuffle algorithm
	/// <see href="https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle"/>
	/// </summary>
	/// <param name="list">List.</param>
	/// <typeparam name="T">The 1st type parameter.</typeparam>
	public static T[] Shuffle<T>(this T[] array)
	{
		for(int i = array.Length - 1; i > 0; i--)
		{
			int j = Random.Range(0,i + 1);
			array.Swap(i, j);
		}
		return array;
	}

	/// <summary>
	/// Swap the specified array items at index1 and index2.
	/// </summary>
	/// <param name="array">Array.</param>
	/// <param name="index1">Index1.</param>
	/// <param name="index2">Index2.</param>
	/// <typeparam name="T">The 1st type parameter.</typeparam>
	public static T[] Swap<T>(this T[] array, int index1, int index2)
	{
		T temp = array[index1];
		array[index1] = array[index2];
		array[index2] = temp;
		return array;
	}

	/// <summary>
	/// Gets the random single item from array.
	/// </summary>
	/// <returns>The random.</returns>
	/// <param name="array">Array.</param>
	/// <typeparam name="T">The 1st type parameter.</typeparam>
	public static T GetRandom<T>(this T[] array)
	{
		int i = Random.Range(0, array.Length);
		return array[i];
	}
}
